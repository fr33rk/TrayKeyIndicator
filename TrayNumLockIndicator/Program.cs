using System;
using System.Windows.Forms;
using PL.Logger;

namespace TrayNumLockIndicator
{
	internal static class Program
	{
		private static ILogFile mLogFile;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			mLogFile = new LogFile("Main");
			mLogFile.WriteLogStart();

			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new FrmMain());
			}
			catch (Exception e)
			{
				mLogFile.Error(e.ToString());
				throw;
			}

			mLogFile.WriteLogEnd();
		}
	}
}