﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace imgdiff
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			//if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
			//{
			//	MessageBox.Show("多重起動はできません。");
			//	return;
			//}
			Application.ThreadException += new ThreadExceptionEventHandler(ApplicationThreadException);
			Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(ApplicationUnhandledException);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
			return;
		}
		public static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.ToString(), "例外発生");
			Application.Exit();
			return;
		}
		public static void ApplicationUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			if (ex != null)
			{
				MessageBox.Show(ex.ToString(), "例外発生");
				Application.Exit();
			}
			return;
		}
	}
}
