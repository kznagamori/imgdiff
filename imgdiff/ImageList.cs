using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
namespace imgdiff
{
    internal class ImageList : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public string Path { get; private set; }
        public List<string> FileList { get; private set; }
        public int Count
        {
            get
            {
                if (this.FileList != null)
                {
                    return this.FileList.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        private Regex _FileExtRegex = new Regex(@".*\.jpg|.*\.Jpeg|.*\.png|.*\.bmp");

        public ImageList(string path)
        {
            this.IsDisposed = false;
            this.Path = path;
            IEnumerable<string> files = null;
            if (System.IO.Directory.Exists(path))
            {
                files = from file in Directory.GetFiles(path)
                        where this._FileExtRegex.IsMatch(file)
                       select file;
            }
            else
            {
                files = new List<string>() { path };

            }
            this.FileList = new List<string>();
            foreach (string file in files)
            {
                this.FileList.Add(file);
            }
        }

        public ImageList(string[] filelist)
        {
            this.IsDisposed = false;
            this.Path = System.IO.Path.GetDirectoryName(filelist[0]);
            this.FileList = new List<string>();
            IEnumerable<string> files = from file in filelist
                                        where this._FileExtRegex.IsMatch(file)
                                        select file;
            foreach (string file in files)
            {
                this.FileList.Add(file);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }
        protected virtual void Dispose(bool dispoing)
        {
            if (this.IsDisposed)
            {
                return;
            }
            if (dispoing)
            {
                // Release Managed
                this.FileList = null;
            }
            // Release Unmanaged

            this.IsDisposed = true;

            // Release Extend Class
        }

        public Image GetImage(int index)
        {
            Image img = null;
            if (this.FileList != null)
            {
                if (index >= 0 && index < this.FileList.Count)
                {
                    using (FileStream fs = new FileStream(this.FileList[index], FileMode.Open, FileAccess.Read))
                    {
                        try
                        {
                            img = GetImage(fs);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            return img;
        }


        private bool CompareFileName(string file0, string file1)
        {
            string f0 = System.IO.Path.GetFileNameWithoutExtension(file0);
            string f1 = System.IO.Path.GetFileNameWithoutExtension(file1);

            return (f0 == f1) || f1.StartsWith(f0 + "_") || f0.StartsWith(f1 + "_");
        }
        public int GetIndex(string name)
        {
            if (this.FileList != null)
            {

                var result = this.FileList.Select((value, index) => new { value, index} ).Where((w, index) => CompareFileName(name, w.value)).ToList();
                if (result.Count() == 1)
                {
                    return result[0].index;
                }
            }
            return -1;
        }

        public Image GetImage(string name)
        {
            Image img = null;
            int index = GetIndex(name);
            if (index >= 0)
            {
                img = GetImage(index);
            }
            return img;
        }

        private Image Convert32bppARGBFrom32bppRGB(Image img)
        {
            try
            {
                Bitmap argb = null;
                BitmapData src = null;
                BitmapData dst = null;
                argb = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
                try
                {
                    src = ((Bitmap)img).LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, img.PixelFormat);
                    dst = argb.LockBits(new Rectangle(0, 0, argb.Width, argb.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                    byte[] tmp = new byte[src.Stride * src.Height];
                    Marshal.Copy(src.Scan0, tmp, 0, src.Stride * src.Height);
                    Marshal.Copy(tmp, 0, dst.Scan0, dst.Stride * dst.Height);
                    tmp = null;
                }
                catch
                {

                }
                finally
                {
                    if (dst != null)
                    {
                        argb.UnlockBits(dst);
                    }
                    if (src != null)
                    {
                        ((Bitmap)img).UnlockBits(src);
                    }
                    img.Dispose();
                    img = null;
                    img = argb;
                }
            }
            catch
            {

            }
            return img;
        }

        private Image GetImage(FileStream fs)
        {
            Image img = null;
            Image argb = null;
            try
            {
                img = System.Drawing.Image.FromStream(fs);
                if (img != null && img.PixelFormat == PixelFormat.Format32bppRgb)
                {
                    img = Convert32bppARGBFrom32bppRGB(img);
                }
            }
            catch
            {
                if (img != null)
                {
                    img.Dispose();
                    img = null;
                }
                if (argb != null)
                {
                    argb.Dispose();
                    argb = null;
                }
            }
            return img;
        }
    }
}
