using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace steamboat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			SteamRunning();
		}

		private void SteamRunning()
		{
			Process[] pname = Process.GetProcessesByName("Steam");
			if (pname.Length == 0)
			{
				Label_SteamStatus.Foreground = Brushes.Red;
				Label_SteamStatus.Content = "Offline";
			}
			else
			{
				Label_SteamStatus.Foreground = Brushes.Green;
				Label_SteamStatus.Content = "Online";
			}
		}
	}
}
