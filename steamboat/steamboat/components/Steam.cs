using System.Diagnostics;

namespace steamboat
{
    class Steam
	{
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
