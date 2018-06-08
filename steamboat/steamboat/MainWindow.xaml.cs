using System.Windows;
using System.Windows.Media;

namespace steamboat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Steam steam = new Steam();

		public MainWindow()
		{
			InitializeComponent();
			if (steam.IsRunning())
			{
				Label_SteamStatus.Foreground = Brushes.ForestGreen;
				Label_SteamStatus.Content    = "online";
			}
			else
			{
				Label_SteamStatus.Foreground = Brushes.Red;
				Label_SteamStatus.Content    = "offline";
			}
		}

		private void button_KillSteam_Click(object sender, RoutedEventArgs e)
		{
			if (steam.IsRunning())
				steam.Kill();
		}
	}
}
