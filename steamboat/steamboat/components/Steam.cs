using steamboat.Utils;
using System.Diagnostics;

namespace steamboat
{
	class Steam
	{
		string steamPath;

		public string SteamPath
		{
			get { return steamPath; }
			set { steamPath = value; }
		}

		public void SetPath()
		{
			if (IsRunning())
			{
				var proc = Process.GetProcessesByName("Steam")[0];
				SteamPath = proc.GetMainModuleFileName();
			}

			//this.steamPath = path;
		}

		public bool IsRunning()
		{
			Process[] proc = Process.GetProcessesByName("Steam");
			if (proc.Length == 0)
				return false;
			return true;
		}

		public void Kill()
		{
			Process[] proc = Process.GetProcessesByName("Steam");
			proc[0].Kill();
		}
	}
}
