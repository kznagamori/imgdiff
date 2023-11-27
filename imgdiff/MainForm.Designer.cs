namespace imgdiff
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.top_toolStrip = new System.Windows.Forms.ToolStrip();
            this.prev_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.next_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ReCompare_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.over_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.diff_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomin_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomout_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.scale_toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.num_toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sum_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.search_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.search_toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.background_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.bottom_statusStrip = new System.Windows.Forms.StatusStrip();
            this.BottomInfo_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.left_pictureBox = new System.Windows.Forms.PictureBox();
            this.left_toolStrip = new System.Windows.Forms.ToolStrip();
            this.leftdiropen_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.leftdir_toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.left_histroy_toolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.right_pictureBox = new System.Windows.Forms.PictureBox();
            this.right_toolStrip = new System.Windows.Forms.ToolStrip();
            this.rightdiropen_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rightdir_toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.right_histroy_toolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.diffColor_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.blend_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pictbox_timer = new System.Windows.Forms.Timer(this.components);
            this.top_toolStrip.SuspendLayout();
            this.bottom_statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).BeginInit();
            this.left_toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).BeginInit();
            this.right_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_toolStrip
            // 
            this.top_toolStrip.AllowItemReorder = true;
            this.top_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prev_toolStripButton,
            this.next_toolStripButton,
            this.toolStripSeparator1,
            this.ReCompare_toolStripButton,
            this.over_toolStripButton,
            this.blend_toolStripButton,
            this.diff_toolStripButton,
            this.toolStripSeparator2,
            this.zoomin_toolStripButton,
            this.zoomout_toolStripButton,
            this.scale_toolStripTextBox,
            this.toolStripSeparator3,
            this.num_toolStripTextBox,
            this.sum_toolStripLabel,
            this.toolStripSeparator4,
            this.search_toolStripButton,
            this.search_toolStripTextBox,
            this.toolStripSeparator5,
            this.background_toolStripComboBox,
            this.diffColor_toolStripComboBox});
            this.top_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.top_toolStrip.Name = "top_toolStrip";
            this.top_toolStrip.Size = new System.Drawing.Size(906, 25);
            this.top_toolStrip.TabIndex = 0;
            this.top_toolStrip.Text = "toolStrip1";
            // 
            // prev_toolStripButton
            // 
            this.prev_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prev_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("prev_toolStripButton.Image")));
            this.prev_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prev_toolStripButton.Name = "prev_toolStripButton";
            this.prev_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.prev_toolStripButton.Text = "戻る";
            this.prev_toolStripButton.ToolTipText = "戻る（←）";
            this.prev_toolStripButton.Click += new System.EventHandler(this.prev_toolStripButton_Click);
            // 
            // next_toolStripButton
            // 
            this.next_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.next_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("next_toolStripButton.Image")));
            this.next_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.next_toolStripButton.Name = "next_toolStripButton";
            this.next_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.next_toolStripButton.Text = "進む";
            this.next_toolStripButton.ToolTipText = "進む（→）";
            this.next_toolStripButton.Click += new System.EventHandler(this.next_toolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ReCompare_toolStripButton
            // 
            this.ReCompare_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReCompare_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ReCompare_toolStripButton.Image")));
            this.ReCompare_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReCompare_toolStripButton.Name = "ReCompare_toolStripButton";
            this.ReCompare_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ReCompare_toolStripButton.Text = "再度比較（R）";
            this.ReCompare_toolStripButton.Click += new System.EventHandler(this.ReCompare_toolStripButton_Click);
            // 
            // over_toolStripButton
            // 
            this.over_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.over_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("over_toolStripButton.Image")));
            this.over_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.over_toolStripButton.Name = "over_toolStripButton";
            this.over_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.over_toolStripButton.Text = "左→右（Space）";
            this.over_toolStripButton.Click += new System.EventHandler(this.over_toolStripButton_Click);
            // 
            // diff_toolStripButton
            // 
            this.diff_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.diff_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("diff_toolStripButton.Image")));
            this.diff_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.diff_toolStripButton.Name = "diff_toolStripButton";
            this.diff_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.diff_toolStripButton.Text = "差分描画（D)";
            this.diff_toolStripButton.ToolTipText = "差分描画（D)";
            this.diff_toolStripButton.Click += new System.EventHandler(this.diff_toolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomin_toolStripButton
            // 
            this.zoomin_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomin_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomin_toolStripButton.Image")));
            this.zoomin_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomin_toolStripButton.Name = "zoomin_toolStripButton";
            this.zoomin_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.zoomin_toolStripButton.Text = "拡大（Z)";
            this.zoomin_toolStripButton.Click += new System.EventHandler(this.zoomin_toolStripButton_Click);
            // 
            // zoomout_toolStripButton
            // 
            this.zoomout_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomout_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomout_toolStripButton.Image")));
            this.zoomout_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomout_toolStripButton.Name = "zoomout_toolStripButton";
            this.zoomout_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.zoomout_toolStripButton.Text = "縮小（X）";
            this.zoomout_toolStripButton.Click += new System.EventHandler(this.zoomout_toolStripButton_Click);
            // 
            // scale_toolStripTextBox
            // 
            this.scale_toolStripTextBox.Name = "scale_toolStripTextBox";
            this.scale_toolStripTextBox.ReadOnly = true;
            this.scale_toolStripTextBox.Size = new System.Drawing.Size(50, 25);
            this.scale_toolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // num_toolStripTextBox
            // 
            this.num_toolStripTextBox.Name = "num_toolStripTextBox";
            this.num_toolStripTextBox.Size = new System.Drawing.Size(50, 25);
            this.num_toolStripTextBox.Text = "0";
            this.num_toolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_toolStripTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num_toolStripTextBox_KeyDown);
            // 
            // sum_toolStripLabel
            // 
            this.sum_toolStripLabel.Name = "sum_toolStripLabel";
            this.sum_toolStripLabel.Size = new System.Drawing.Size(18, 22);
            this.sum_toolStripLabel.Text = "/0";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // search_toolStripButton
            // 
            this.search_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.search_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("search_toolStripButton.Image")));
            this.search_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.search_toolStripButton.Name = "search_toolStripButton";
            this.search_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.search_toolStripButton.Text = "ファイル名の画像を比較";
            this.search_toolStripButton.Click += new System.EventHandler(this.search_toolStripButton_Click);
            // 
            // search_toolStripTextBox
            // 
            this.search_toolStripTextBox.Name = "search_toolStripTextBox";
            this.search_toolStripTextBox.Size = new System.Drawing.Size(160, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // background_toolStripComboBox
            // 
            this.background_toolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.background_toolStripComboBox.Items.AddRange(new object[] {
            "背景：黒",
            "背景：白",
            "背景：チェック"});
            this.background_toolStripComboBox.Name = "background_toolStripComboBox";
            this.background_toolStripComboBox.Size = new System.Drawing.Size(120, 25);
            this.background_toolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.background_toolStripComboBox_SelectedIndexChanged);
            // 
            // bottom_statusStrip
            // 
            this.bottom_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BottomInfo_toolStripStatusLabel});
            this.bottom_statusStrip.Location = new System.Drawing.Point(0, 368);
            this.bottom_statusStrip.Name = "bottom_statusStrip";
            this.bottom_statusStrip.Size = new System.Drawing.Size(906, 22);
            this.bottom_statusStrip.TabIndex = 1;
            // 
            // BottomInfo_toolStripStatusLabel
            // 
            this.BottomInfo_toolStripStatusLabel.Name = "BottomInfo_toolStripStatusLabel";
            this.BottomInfo_toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.left_pictureBox);
            this.splitContainer1.Panel1.Controls.Add(this.left_toolStrip);
            this.splitContainer1.Panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.splitContainer1_Panel1_Scroll);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.right_pictureBox);
            this.splitContainer1.Panel2.Controls.Add(this.right_toolStrip);
            this.splitContainer1.Panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.splitContainer1_Panel2_Scroll);
            this.splitContainer1.Size = new System.Drawing.Size(906, 343);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.TabIndex = 3;
            // 
            // left_pictureBox
            // 
            this.left_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.left_pictureBox.Location = new System.Drawing.Point(0, 25);
            this.left_pictureBox.Name = "left_pictureBox";
            this.left_pictureBox.Size = new System.Drawing.Size(450, 318);
            this.left_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.left_pictureBox.TabIndex = 1;
            this.left_pictureBox.TabStop = false;
            this.left_pictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.left_pictureBox_DragDrop);
            this.left_pictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.left_pictureBox_DragEnter);
            // 
            // left_toolStrip
            // 
            this.left_toolStrip.AllowDrop = true;
            this.left_toolStrip.CanOverflow = false;
            this.left_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftdiropen_toolStripButton,
            this.leftdir_toolStripTextBox,
            this.left_histroy_toolStripSplitButton});
            this.left_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.left_toolStrip.Name = "left_toolStrip";
            this.left_toolStrip.Size = new System.Drawing.Size(450, 25);
            this.left_toolStrip.Stretch = true;
            this.left_toolStrip.TabIndex = 0;
            this.left_toolStrip.DragDrop += new System.Windows.Forms.DragEventHandler(this.left_toolStrip_DragDrop);
            this.left_toolStrip.DragEnter += new System.Windows.Forms.DragEventHandler(this.left_toolStrip_DragEnter);
            // 
            // leftdiropen_toolStripButton
            // 
            this.leftdiropen_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftdiropen_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("leftdiropen_toolStripButton.Image")));
            this.leftdiropen_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftdiropen_toolStripButton.Name = "leftdiropen_toolStripButton";
            this.leftdiropen_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.leftdiropen_toolStripButton.Text = "ディレクトリを開く";
            this.leftdiropen_toolStripButton.Click += new System.EventHandler(this.leftdiropen_toolStripButton_Click);
            // 
            // leftdir_toolStripTextBox
            // 
            this.leftdir_toolStripTextBox.AutoSize = false;
            this.leftdir_toolStripTextBox.Name = "leftdir_toolStripTextBox";
            this.leftdir_toolStripTextBox.ReadOnly = true;
            this.leftdir_toolStripTextBox.Size = new System.Drawing.Size(200, 25);
            // 
            // left_histroy_toolStripSplitButton
            // 
            this.left_histroy_toolStripSplitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.left_histroy_toolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.left_histroy_toolStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("left_histroy_toolStripSplitButton.Image")));
            this.left_histroy_toolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.left_histroy_toolStripSplitButton.Name = "left_histroy_toolStripSplitButton";
            this.left_histroy_toolStripSplitButton.Size = new System.Drawing.Size(32, 22);
            this.left_histroy_toolStripSplitButton.Text = "履歴";
            // 
            // right_pictureBox
            // 
            this.right_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.right_pictureBox.Location = new System.Drawing.Point(0, 25);
            this.right_pictureBox.Name = "right_pictureBox";
            this.right_pictureBox.Size = new System.Drawing.Size(452, 318);
            this.right_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.right_pictureBox.TabIndex = 2;
            this.right_pictureBox.TabStop = false;
            this.right_pictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.right_pictureBox_DragDrop);
            this.right_pictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.right_pictureBox_DragEnter);
            // 
            // right_toolStrip
            // 
            this.right_toolStrip.AllowDrop = true;
            this.right_toolStrip.CanOverflow = false;
            this.right_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightdiropen_toolStripButton,
            this.rightdir_toolStripTextBox,
            this.right_histroy_toolStripSplitButton});
            this.right_toolStrip.Location = new System.Drawing.Point(0, 0);
            this.right_toolStrip.Name = "right_toolStrip";
            this.right_toolStrip.Size = new System.Drawing.Size(452, 25);
            this.right_toolStrip.TabIndex = 1;
            this.right_toolStrip.DragDrop += new System.Windows.Forms.DragEventHandler(this.right_toolStrip_DragDrop);
            this.right_toolStrip.DragEnter += new System.Windows.Forms.DragEventHandler(this.right_toolStrip_DragEnter);
            // 
            // rightdiropen_toolStripButton
            // 
            this.rightdiropen_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightdiropen_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rightdiropen_toolStripButton.Image")));
            this.rightdiropen_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightdiropen_toolStripButton.Name = "rightdiropen_toolStripButton";
            this.rightdiropen_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.rightdiropen_toolStripButton.Text = "ディレクトリを開く";
            this.rightdiropen_toolStripButton.Click += new System.EventHandler(this.rightdiropen_toolStripButton_Click);
            // 
            // rightdir_toolStripTextBox
            // 
            this.rightdir_toolStripTextBox.Name = "rightdir_toolStripTextBox";
            this.rightdir_toolStripTextBox.ReadOnly = true;
            this.rightdir_toolStripTextBox.Size = new System.Drawing.Size(200, 25);
            // 
            // right_histroy_toolStripSplitButton
            // 
            this.right_histroy_toolStripSplitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.right_histroy_toolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.right_histroy_toolStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("right_histroy_toolStripSplitButton.Image")));
            this.right_histroy_toolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.right_histroy_toolStripSplitButton.Name = "right_histroy_toolStripSplitButton";
            this.right_histroy_toolStripSplitButton.Size = new System.Drawing.Size(32, 22);
            this.right_histroy_toolStripSplitButton.Text = "履歴";
            // 
            // diffColor_toolStripComboBox
            // 
            this.diffColor_toolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diffColor_toolStripComboBox.Items.AddRange(new object[] {
            "差異：黄",
            "差異：赤",
            "差異：赤⇒黄"});
            this.diffColor_toolStripComboBox.Name = "diffColor_toolStripComboBox";
            this.diffColor_toolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.diffColor_toolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.diffColor_toolStripComboBox_SelectedIndexChanged);
            // 
            // blend_toolStripButton
            // 
            this.blend_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.blend_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("blend_toolStripButton.Image")));
            this.blend_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.blend_toolStripButton.Name = "blend_toolStripButton";
            this.blend_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.blend_toolStripButton.Text = "ブレンディング描画（B）";
            this.blend_toolStripButton.ToolTipText = "ブレンディング描画（B）";
            this.blend_toolStripButton.Click += new System.EventHandler(this.blend_toolStripButton_Click);
            // 
            // pictbox_timer
            // 
            this.pictbox_timer.Interval = 1000;
            this.pictbox_timer.Tick += new System.EventHandler(this.pictbox_timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 390);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bottom_statusStrip);
            this.Controls.Add(this.top_toolStrip);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "画像を目視で比較";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.top_toolStrip.ResumeLayout(false);
            this.top_toolStrip.PerformLayout();
            this.bottom_statusStrip.ResumeLayout(false);
            this.bottom_statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).EndInit();
            this.left_toolStrip.ResumeLayout(false);
            this.left_toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).EndInit();
            this.right_toolStrip.ResumeLayout(false);
            this.right_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip top_toolStrip;
		private System.Windows.Forms.ToolStripButton prev_toolStripButton;
		private System.Windows.Forms.ToolStripButton next_toolStripButton;
		private System.Windows.Forms.StatusStrip bottom_statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel BottomInfo_toolStripStatusLabel;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip left_toolStrip;
		private System.Windows.Forms.ToolStripButton leftdiropen_toolStripButton;
		private System.Windows.Forms.ToolStripTextBox leftdir_toolStripTextBox;
		private System.Windows.Forms.ToolStrip right_toolStrip;
		private System.Windows.Forms.ToolStripButton rightdiropen_toolStripButton;
		private System.Windows.Forms.ToolStripTextBox rightdir_toolStripTextBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton zoomin_toolStripButton;
		private System.Windows.Forms.ToolStripButton zoomout_toolStripButton;
		private System.Windows.Forms.PictureBox left_pictureBox;
		private System.Windows.Forms.PictureBox right_pictureBox;
		private System.Windows.Forms.ToolStripButton ReCompare_toolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox scale_toolStripTextBox;
		private System.Windows.Forms.ToolStripButton over_toolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripTextBox num_toolStripTextBox;
		private System.Windows.Forms.ToolStripLabel sum_toolStripLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton search_toolStripButton;
		private System.Windows.Forms.ToolStripTextBox search_toolStripTextBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripComboBox background_toolStripComboBox;
        private System.Windows.Forms.ToolStripSplitButton left_histroy_toolStripSplitButton;
        private System.Windows.Forms.ToolStripSplitButton right_histroy_toolStripSplitButton;
        private System.Windows.Forms.ToolStripButton diff_toolStripButton;
        private System.Windows.Forms.ToolStripComboBox diffColor_toolStripComboBox;
        private System.Windows.Forms.ToolStripButton blend_toolStripButton;
        private System.Windows.Forms.Timer pictbox_timer;
    }
}

