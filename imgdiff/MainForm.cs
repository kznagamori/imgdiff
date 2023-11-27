using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace imgdiff
{
	public partial class MainForm : Form
	{
		private int _DiffIndex = 0;
        private int _Scale = 0;
        private Bitmap _LeftBitmap = null;
        private Bitmap _RightBitmap = null;
		private bool _IsOver = false;
        private bool _IsBlend = false;
        private bool _IsDiff = false;
        private Color _DiffColor = Color.Transparent;
        private Brush _BackBrush;
        private ImageList _LeftFiles = null;
        private ImageList _RightFiles = null;

        private History _History = null;
        private HistoryMenu _LeftHistoryMenu = null;
        private HistoryMenu _RightHistoryMenu = null;

        private const int DIRTEXTBOXOFFSET = 80;
		public MainForm()
		{
			InitializeComponent();
			this.Disposed += this.ThisDispose;
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.Init();
		}

		private void Init()
		{
            this._Scale = 0;
			this._IsOver = false;
            this._IsBlend = false;

            this.scale_toolStripTextBox.Text = ((int)(100 * Math.Pow(2, this._Scale))).ToString() + @"%";
			this.leftdir_toolStripTextBox.Size =
                new Size(this.left_toolStrip.Width - DIRTEXTBOXOFFSET, this.leftdir_toolStripTextBox.Height);
			this.rightdir_toolStripTextBox.Size =
                new Size(this.right_toolStrip.Width - DIRTEXTBOXOFFSET, this.rightdir_toolStripTextBox.Height);
			this.background_toolStripComboBox.SelectedIndex = 0;
            this.diffColor_toolStripComboBox.SelectedIndex = 0;

            this._BackBrush = Brushes.Black;

            this._History = new History();

            this._LeftHistoryMenu = new HistoryMenu(this._History, this.left_histroy_toolStripSplitButton);
            this._LeftHistoryMenu.ClickEvent += this.LeftHistoryEvent;

            this._RightHistoryMenu = new HistoryMenu(this._History, this.right_histroy_toolStripSplitButton);
            this._RightHistoryMenu.ClickEvent += this.RightHistoryEvent;

            this.left_pictureBox.AllowDrop = true;
            this.right_pictureBox.AllowDrop = true;

            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScroll = true;


            this.left_pictureBox.Dock = DockStyle.None;
            this.right_pictureBox.Dock = DockStyle.None;
        }

        private void ThisDispose(object sender, EventArgs e)
		{
            if (this._History != null)
            {
                this._History.Dispose();
                this._History = null;
            }
		}

		private void prev_toolStripButton_Click(object sender, EventArgs e)
		{
			this._DiffIndex--;
			this._IsOver = false;
			if (this._LeftFiles != null && this._DiffIndex < 0)
			{
				this._DiffIndex = this._LeftFiles.Count - 1;
			}
			this.ShowImage();
		}

		private void next_toolStripButton_Click(object sender, EventArgs e)
		{
			this._DiffIndex++;
			this._IsOver = false;
            if (this._LeftFiles != null && this._DiffIndex >= this._LeftFiles.Count)
			{
				this._DiffIndex = 0;
			}
			this.ShowImage();
		}

		private void zoomin_toolStripButton_Click(object sender, EventArgs e)
		{
            this._Scale++;
            this.scale_toolStripTextBox.Text = ((int)(100 * Math.Pow(2, this._Scale))).ToString() + @"%";
            this.ShowImage();
		}

		private void zoomout_toolStripButton_Click(object sender, EventArgs e)
		{
            this._Scale--;
            this.scale_toolStripTextBox.Text = ((int)(100 * Math.Pow(2, this._Scale))).ToString() + @"%";
            this.ShowImage();
		}

		private void leftdiropen_toolStripButton_Click(object sender, EventArgs e)
		{
            CommonOpenFileDialog fbd = new CommonOpenFileDialog();
			fbd.Title = "イメージ比較元のディレクトリを指定してください。";
            fbd.InitialDirectory = @"C:";
            fbd.IsFolderPicker = true;
            if (fbd.ShowDialog() == CommonFileDialogResult.Ok)
            {
				this.leftdir_toolStripTextBox.Text = fbd.FileName;
                if (this._History != null)
                {
                    this._History.Add(fbd.FileName);
                }
                if (this._LeftFiles != null)
                {
                    this._LeftFiles.Dispose();
                    this._LeftFiles = null;
                }
                this._LeftFiles = new ImageList(fbd.FileName);
				this._DiffIndex = 0;
                if (this._LeftFiles != null)
                {
                    this.sum_toolStripLabel.Text = @"/" + this._LeftFiles.Count.ToString();
                }
				this._IsOver = false;
				this.ShowImage();
			}
		}

		private void rightdiropen_toolStripButton_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog fbd = new CommonOpenFileDialog();
			fbd.Title = "イメージ比較先のディレクトリを指定してください。";
            fbd.InitialDirectory = @"C:";
            fbd.IsFolderPicker = true;
            if (fbd.ShowDialog() == CommonFileDialogResult.Ok)
			{
				this.rightdir_toolStripTextBox.Text = fbd.FileName;
                if (this._History != null)
                {
                    this._History.Add(fbd.FileName);
                }
                if (this._RightFiles != null)
                {
                    this._RightFiles.Dispose();
                    this._RightFiles = null;
                }
                this._RightFiles = new ImageList(fbd.FileName);
                this._DiffIndex = 0;
				this._IsOver = false;
				this.ShowImage();
			}
		}

		private void ShowImage()
		{
            string left_name = null;
            Image left_img = null;
            Image right_img = null;
			
			if (this._LeftFiles != null)
			{
                if (this._LeftFiles.Count > 0)
                {
                    this.num_toolStripTextBox.Text = (this._DiffIndex + 1).ToString();
                    left_name = this._LeftFiles.FileList[this._DiffIndex];
                    this.BottomInfo_toolStripStatusLabel.Text
                        = this.search_toolStripTextBox.Text
                        = System.IO.Path.GetFileName(left_name);
                    left_img = this._LeftFiles.GetImage(this._DiffIndex);
                }
                else
                {
                    this.num_toolStripTextBox.Text = (0).ToString();
                }
            }
            if (this._RightFiles != null && left_name != null)
            {
                if (this._RightFiles.Count > 0)
                {
                    right_img = this._RightFiles.GetImage(System.IO.Path.GetFileName(left_name));
                }
            }
            try
            {
                float left_scale, right_scale;
                left_scale = right_scale = (float)(Math.Pow(2, this._Scale));

                if (left_img == null)
                {
                    left_img = this.left_pictureBox.ErrorImage;
                    left_scale = 1.0f;
                    this.left_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    this.left_pictureBox.Size = this.splitContainer1.Panel1.Size;
                }
                else
                {
                    this.left_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                }
                this._LeftBitmap = new Bitmap((int)(left_img.Width * left_scale), (int)(left_img.Height * left_scale),
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(this._LeftBitmap))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
					g.FillRectangle(this._BackBrush, 0, 0, (int)(left_img.Width * left_scale), (int)(left_img.Height * left_scale));
                    g.DrawImage(left_img, 0, 0, (int)(left_img.Width * left_scale), (int)(left_img.Height * left_scale));
                }
                if (right_img == null)
                {
                    right_img = this.right_pictureBox.ErrorImage;
                    right_scale = 1.0f;
                    this.right_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    this.right_pictureBox.Size = this.splitContainer1.Panel2.Size;

                }
                else
                {
                    this.right_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                }
                this._RightBitmap = new Bitmap((int)(right_img.Width * right_scale), (int)(right_img.Height * right_scale),
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(this._RightBitmap))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.FillRectangle(this._BackBrush, 0, 0, (int)(right_img.Width * right_scale), (int)(right_img.Height * right_scale));
                    g.DrawImage(right_img, 0, 0, (int)(right_img.Width * right_scale), (int)(right_img.Height * right_scale));
                }
                if (this._IsOver)
				{
                    this.splitContainer1.SplitterDistance = splitContainer1.ClientSize.Width / 2;
                    this.splitContainer1.Panel1Collapsed = false;

                    this.left_pictureBox.Image = this.left_pictureBox.ErrorImage;
					this.right_pictureBox.Image = this._LeftBitmap;
				}
                else if (this._IsBlend)
                {
                    this.splitContainer1.SplitterDistance = 0;
                    this.splitContainer1.Panel1Collapsed = true;


                    float[][] matrixItems ={
                       new float[] {1, 0, 0, 0, 0},
                       new float[] {0, 1, 0, 0, 0},
                       new float[] {0, 0, 1, 0, 0},
                       new float[] {0, 0, 0, 0.5f, 0},
                       new float[] {0, 0, 0, 0, 1}};
                    ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
                    ImageAttributes imageAtt = new ImageAttributes();
                    imageAtt.SetColorMatrix(
                       colorMatrix,
                       ColorMatrixFlag.Default,
                       ColorAdjustType.Bitmap);
                        using (Graphics g = Graphics.FromImage(this._RightBitmap))
                        {
                            g.InterpolationMode = InterpolationMode.NearestNeighbor;
                            g.FillRectangle(this._BackBrush, 0, 0, (int)(right_img.Width * right_scale), (int)(right_img.Height * right_scale));
                            g.DrawImage(left_img, 0, 0, (int)(left_img.Width * left_scale), (int)(left_img.Height * left_scale));
                            g.DrawImage(right_img, new Rectangle(0, 0, (int)(right_img.Width * right_scale), (int)(right_img.Height * right_scale)),
                                0, 0, (int)(right_img.Width), (int)(right_img.Height), GraphicsUnit.Pixel, imageAtt);
                        }
                        this.left_pictureBox.Image = this.left_pictureBox.ErrorImage;
                        this.right_pictureBox.Image = this._RightBitmap;

                }
                else if (this._IsDiff)
                {
                    this.splitContainer1.SplitterDistance = splitContainer1.ClientSize.Width / 2;
                    this.splitContainer1.Panel1Collapsed = false;

                    int width = Math.Max(this._LeftBitmap.Width, this._RightBitmap.Width);
                    int height = Math.Max(this._LeftBitmap.Height, this._RightBitmap.Height);

                    Bitmap diffBmp = new Bitmap(width, height);         // 返却する差分の画像。
                    if (this.diffColor_toolStripComboBox.SelectedIndex == 2)
                    {
                        if (this._DiffColor == Color.Red)
                        {
                            this._DiffColor = Color.Yellow;
                        }
                        else
                        {
                            this._DiffColor = Color.Red;
                        }
                    }
                    Color diffColor = this._DiffColor;
                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            try
                            {
                                Color color1 = this._LeftBitmap.GetPixel(i, j);
                                if (color1 == this._RightBitmap.GetPixel(i, j))
                                {
                                    diffBmp.SetPixel(i, j, color1);
                                }
                                else
                                {
                                    diffBmp.SetPixel(i, j, diffColor);
                                }
                            }
                            catch
                            {
                                // 画像のサイズが違う時は、ピクセルを取得できずにエラーとなるが、ここでは「差分」として扱う。
                                diffBmp.SetPixel(i, j, diffColor);
                            }
                        }
                    }
                    this._RightBitmap= diffBmp;
                    this.left_pictureBox.Image = this._LeftBitmap;
                    this.right_pictureBox.Image = this._RightBitmap;
                }
                else
				{
                    this.splitContainer1.SplitterDistance = splitContainer1.ClientSize.Width / 2;
                    this.splitContainer1.Panel1Collapsed = false;

                    this.left_pictureBox.Image = this._LeftBitmap;
					this.right_pictureBox.Image = this._RightBitmap;
				}
                GC.Collect();
            }
            catch
            {
            }
		}

		private void ReCompare_toolStripButton_Click(object sender, EventArgs e)
		{
			this._IsOver = false;
			this.ShowImage();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
            this.leftdir_toolStripTextBox.Size =
                new Size(this.left_toolStrip.Width - DIRTEXTBOXOFFSET, this.leftdir_toolStripTextBox.Height);
            this.rightdir_toolStripTextBox.Size =
                new Size(this.right_toolStrip.Width - DIRTEXTBOXOFFSET, this.rightdir_toolStripTextBox.Height);
		}

		private void over_toolStripButton_Click(object sender, EventArgs e)
		{
			this._IsOver = !this._IsOver;
			this.ShowImage();
		}

		private void num_toolStripTextBox_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                try
                {
                    int num = int.Parse(num_toolStripTextBox.Text);
                    if (this._LeftFiles != null
                        && num >= 1 && num <= this._LeftFiles.Count)
                    {
                        this._DiffIndex = num - 1;
                        this._IsOver = false;
                        this.ShowImage();
                    }
                }
                catch
                {

                }
            }
		}

		private void search_toolStripButton_Click(object sender, EventArgs e)
		{
			if (this.scale_toolStripTextBox.Text != "")
			{
                if (this._LeftFiles != null)
				{
                    int index = this._LeftFiles.GetIndex(this.search_toolStripTextBox.Text);
                    if (index >= 0)
                    {
						this._DiffIndex = index;
						this._IsOver = false;
						this.ShowImage();
						return;
					}
				}

			}
		}

		private void background_toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				switch (this.background_toolStripComboBox.SelectedIndex)
				{
					default:
					case 0:
						this._BackBrush = Brushes.Black;
						break;
					case 1:
						this._BackBrush = Brushes.White;
						break;
					case 2:
						this._BackBrush = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.Gray, Color.White);
						break;
				}
                this.ShowImage();
			}
			catch
			{
				this._BackBrush = Brushes.Black;
			}
		}

        private void LeftHistoryEvent(object sender, HistoryMenuEventArgs e)
        {
            this.leftdir_toolStripTextBox.Text = e.FileName;
            if (this._LeftFiles != null)
            {
                this._LeftFiles.Dispose();
                this._LeftFiles = null;
            }
            this._LeftFiles = new ImageList(e.FileName);
            this._DiffIndex = 0;
            if (this._LeftFiles != null)
            {
                this.sum_toolStripLabel.Text = @"/" + this._LeftFiles.Count.ToString();
            }
            this._IsOver = false;
            this.ShowImage();

        }

        private void RightHistoryEvent(object sender, HistoryMenuEventArgs e)
        {
            this.rightdir_toolStripTextBox.Text = e.FileName;
            if (this._RightFiles != null)
            {
                this._RightFiles.Dispose();
                this._RightFiles = null;
            }
            this._RightFiles = new ImageList(e.FileName);
            this._DiffIndex = 0;
            this._IsOver = false;
            this.ShowImage();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    this.next_toolStripButton_Click(sender, e);
                    break;
                case Keys.Left:
                    this.prev_toolStripButton_Click(sender, e);
                    break;
                case Keys.Space:
                    this.over_toolStripButton_Click(sender, e);
                    break;
                case Keys.R:
                    this.ReCompare_toolStripButton_Click(sender, e);
                    break;
                case Keys.Z:
                    this.zoomin_toolStripButton_Click(sender, e);
                    break;
                case Keys.X:
                    this.zoomout_toolStripButton_Click(sender, e);
                    break;
                case Keys.D:
                    this.diff_toolStripButton_Click(sender, e);
                    break;
                case Keys.B:
                    this.blend_toolStripButton_Click(sender, e);
                    break;
            }
        }

        private void LeftDragDrop(object sender, DragEventArgs e, bool isGetDir = false)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length > 0)
            {
                string path = "";
                if (isGetDir)
                {
                    path = System.IO.Path.GetDirectoryName(fileName[0]);
                }
                else
                {
                    path = fileName[0];
                }

                this.leftdir_toolStripTextBox.Text = path;
                if (this._History != null)
                {
                    this._History.Add(path);
                }
                if (this._LeftFiles != null)
                {
                    this._LeftFiles.Dispose();
                    this._LeftFiles = null;
                }
                this._LeftFiles = new ImageList(path);
                this._DiffIndex = 0;
                if (this._LeftFiles != null)
                {
                    this.sum_toolStripLabel.Text = @"/" + this._LeftFiles.Count.ToString();
                }
                this._IsOver = false;
                this.ShowImage();
            }
        }
        private void RightDragDrop(object sender, DragEventArgs e, bool isGetDir = false)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length > 0)
            {
                string path = "";
                if (isGetDir)
                {
                    path = System.IO.Path.GetDirectoryName(fileName[0]);
                }
                else
                {
                    path = fileName[0];
                }
                this.rightdir_toolStripTextBox.Text = path;
                if (this._History != null)
                {
                    this._History.Add(path);
                }
                if (this._RightFiles != null)
                {
                    this._RightFiles.Dispose();
                    this._RightFiles = null;
                }
                this._RightFiles = new ImageList(path);
                this._DiffIndex = 0;
                this._IsOver = false;
                this.ShowImage();
            }
        }
        private void DragEnterEvent(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void left_pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            this.LeftDragDrop(sender, e, false);
        }

        private void right_pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            this.RightDragDrop(sender, e, false);
        }

        private void left_toolStrip_DragDrop(object sender, DragEventArgs e)
        {
            this.LeftDragDrop(sender, e);
        }

        private void right_toolStrip_DragDrop(object sender, DragEventArgs e)
        {
            this.RightDragDrop(sender, e);
        }

        private void left_toolStrip_DragEnter(object sender, DragEventArgs e)
        {
            this.DragEnterEvent(sender, e);
        }

        private void right_toolStrip_DragEnter(object sender, DragEventArgs e)
        {
            this.DragEnterEvent(sender, e);
        }

        private void left_pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            this.DragEnterEvent(sender, e);
        }

        private void right_pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            this.DragEnterEvent(sender, e);
        }

        private void diff_toolStripButton_Click(object sender, EventArgs e)
        {
            if (this._IsDiff)
            {
                this._IsDiff = false;
            }
            else
            {
                this._IsDiff = true;
            }
            this.ShowImage();
        }
        private void blend_toolStripButton_Click(object sender, EventArgs e)
        {
            if (this._IsBlend)
            {
                this._IsBlend = false;
            }
            else
            {
                this._IsBlend = true;
            }
            this.ShowImage();
        }
        private void splitContainer1_Panel1_Scroll(object sender, ScrollEventArgs e)
        {
            MoveLinkageScrollableControl(sender as Panel, splitContainer1.Panel2);
        }

        private void splitContainer1_Panel2_Scroll(object sender, ScrollEventArgs e)
        {
            MoveLinkageScrollableControl(sender as Panel, splitContainer1.Panel1);
        }
        private void MoveLinkageScrollableControl(Panel self, Panel linkage)
        {
            int x = self.HorizontalScroll.Value;
            int y = self.VerticalScroll.Value;
            linkage.AutoScrollPosition = new System.Drawing.Point(x, y);
        }

        private void pictbox_timer_Tick(object sender, EventArgs e)
        {
            this.ShowImage();
        }

        private void diffColor_toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.pictbox_timer.Enabled)
            {
                if (this.diffColor_toolStripComboBox.SelectedIndex == 2)
                {
                    this.pictbox_timer.Enabled = true;
                }
            }
            else
            {
                if (this.diffColor_toolStripComboBox.SelectedIndex != 2)
                {
                    this.pictbox_timer.Enabled = false;
                }
            }
            switch (this.diffColor_toolStripComboBox.SelectedIndex)
            {
                case 0:
                    this._DiffColor = Color.Yellow;
                    break;
                case 1:
                    this._DiffColor = Color.Red;
                    break;
                case 2:
                    this._DiffColor = Color.Yellow;
                    break;
                default:
                    this._DiffColor = Color.Transparent;
                    break;
            }
            this.ShowImage();

        }
    }
}
