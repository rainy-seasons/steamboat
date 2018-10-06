using System;
using Microsoft.Win32;
using steamboat.Utils;
using System.Diagnostics;
using System.Windows;

namespace steamboat
{
	class Steam
	{
		string steamPath;
		Process steamProc;

		public string SteamPath
		{
			get { return steamPath; }
			set { steamPath = value; }
		}

		public void CheckPath()
		{
			if (string.IsNullOrEmpty(Properties.Settings.Default["SteamPath"].ToString()))
			{
				SetPath();
			}
			else
			{
				steamPath = Properties.Settings.Default["SteamPath"].ToString();
			}
		}

		public void SetPath()
		{
			if (IsRunning())
			{
                // SteamPath = steamProc.GetMainModuleFileName();
                SteamPath = steamProc.MainModule.FileName;
				Properties.Settings.Default["SteamPath"] = SteamPath;
				Properties.Settings.Default.Save();
			}
			else
			{
				MessageBox.Show("Could not find steam.\nPlease navigate to and provide Steam.exe");
				OpenFileDialog ofd = new OpenFileDialog();
				if (ofd.ShowDialog() == true)
					Properties.Settings.Default["SteamPath"] = ofd.FileName;
			}
		}

		public bool IsRunning()
		{
			Process[] proc = Process.GetProcessesByName("Steam");
			if (proc.Length == 0)
				return false;
			steamProc = proc[0];
			return true;
		}

		public void Kill()
		{
			steamProc.Kill();
		}

	    public void Run(string username, string password)
	    {
	        if (IsRunning())
	        {
                throw new InvalidOperationException("Steam is already running");
	        }

            CheckPath();

	        Process.Start(SteamPath, $"-login {username} {password}");
	    }
	}
}
