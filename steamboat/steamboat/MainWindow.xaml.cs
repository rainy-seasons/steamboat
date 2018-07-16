using System.Threading;
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
			CheckSteam();
		}

		private void button_KillSteam_Click(object sender, RoutedEventArgs e)
		{
			if (steam.IsRunning())
				steam.Kill();
			Thread.Sleep(200);
			CheckSteam();
		}

		private void CheckSteam()
		{
			if (steam.IsRunning())
			{
				Label_SteamStatus.Foreground = Brushes.ForestGreen;
				Label_SteamStatus.Content = "running";
			}
			else
			{
				Label_SteamStatus.Foreground = Brushes.Red;
				Label_SteamStatus.Content = "offline";
			}
		}

		private void ListBox_NewAccount(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Not Yet Implemented.");
		}
	}
}
