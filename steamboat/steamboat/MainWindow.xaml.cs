using steamboat.components;
using steamboat.WPF;
using System.Collections.Generic;
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
		public List<SteamAccount> AccountList = new List<SteamAccount>();

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

		public void NewAccount(SteamAccount account)
		{
			AccountList.Add(account);
			Listbox_Accounts.Items.Add(account.Name);
		}

		private void ListBox_NewAccount(object sender, RoutedEventArgs e)
		{
			AddAccount AddWin = new AddAccount();
			AddWin.Owner = this;
			AddWin.Show();
		}

		private void Listbox_Accounts_MouseDoubleClick(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show(AccountList[Listbox_Accounts.SelectedIndex].Name.ToString() + "\n" + AccountList[Listbox_Accounts.SelectedIndex].Password.ToString());
		}
	}
}
