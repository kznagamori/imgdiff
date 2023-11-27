using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace imgdiff
{
    internal class HistoryEventArgs
    {
        public string FileName { get; private set; }

        public HistoryEventArgs(string file_name)
        {
            this.FileName = file_name;
        }
    }

    internal delegate void HistoryEventHandler(object sender, HistoryEventArgs e);

    internal class History : IDisposable
    {
        public List<string> HistroyList { get; private set; }
        public bool IsDisposed { get; private set; }
        private string HISTORY_FILE = @"\History.xml";
        private int MAX_HISTORY_NUM = 10;

        public event HistoryEventHandler AddEvent = delegate { };

        public History()
        {
            this.IsDisposed = false;
            this.HistroyList = new List<string>();
            this.LoadFile();
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
                this.StoreFile();
                this.HistroyList = null;
            }
            // Release Unmanaged

            this.IsDisposed = true;
            // Release Extend Class
        }
        public void Add(string history)
        {
            if (this.HistroyList == null)
            {
                this.HistroyList = new List<string>();
            }
            if (this.HistroyList.Count > MAX_HISTORY_NUM)
            {
                for (int i = 0; i < this.HistroyList.Count - 1; i++)
                {
                    this.HistroyList[i] = this.HistroyList[i + 1];
                }
                this.HistroyList[this.HistroyList.Count - 1] = history;
            }
            else
            {
                this.HistroyList.Add(history);
            }
            this.AddEvent(this, new HistoryEventArgs(history));
        }
        private void LoadFile()
        {
            string path = Application.StartupPath + HISTORY_FILE;
            if (System.IO.File.Exists(path))
            {
                System.Xml.Serialization.XmlSerializer serializer
                    = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
                using (System.IO.FileStream fs 
                    = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    try
                    {
                        this.HistroyList = (List<string>)serializer.Deserialize(fs);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
        }

        private void StoreFile()
        {
            string path = Application.StartupPath + HISTORY_FILE;
            System.Xml.Serialization.XmlSerializer serializer
                = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
            using (System.IO.FileStream fs
                = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate))
            {
                try
                {
                    serializer.Serialize(fs, this.HistroyList);
                }
                catch
                {

                }
                finally
                {
                    fs.Close();
                }
            }
        }
    }

    internal class HistoryMenuEventArgs
    {
        public string FileName { get; private set; }

        public HistoryMenuEventArgs(string file_name)
        {
            this.FileName = file_name;
        }
    }

    internal delegate void HistoryMenuEventHandler(object sender, HistoryMenuEventArgs e);

    internal class HistoryMenu : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public History History { get; private set; }
        public ToolStripSplitButton SplitButton { get; private set; }

        public event HistoryMenuEventHandler ClickEvent = delegate { };
        
        public HistoryMenu(History history, ToolStripSplitButton split_button)
        {
            this.IsDisposed = false;
            this.History = history;
            this.History.AddEvent += this.HistoryAdd;

            this.SplitButton = split_button;
            this.RebuildSplitButton();
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
            }
            // Release Unmanaged

            this.IsDisposed = true;
            // Release Extend Class
        }

        private void RebuildSplitButton()
        {
            if (this.SplitButton != null)
            {
                this.SplitButton.DropDown.Items.Clear();
                foreach (string path in this.History.HistroyList)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = path;
                    item.Click += this.Click;
                    this.SplitButton.DropDown.Items.Add(item);
                }
            }
        }

        private void Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.ClickEvent(sender, new HistoryMenuEventArgs(item.Text));
        }

        private void HistoryAdd(object sender, HistoryEventArgs e)
        {
            this.RebuildSplitButton();
        }
    }


}
