using System;
using steamboat.components;
using steamboat.Utils;
using steamboat.WPF;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
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
			steam.CheckPath();
            Crypto.GetNewEntropy();
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
		    if (steam.IsRunning())
		    {
                steam.Kill();
                Thread.Sleep(200);
		    }

		    var listBoxItem = VisualTreeHelpers.FindParent<ListBoxItem>((DependencyObject) e.OriginalSource);

		    if (listBoxItem == null)
		    {
                throw new InvalidOperationException("ListBoxItem not found");
		    }

		    var account = AccountList.First(ac => ac.Name.Equals((string) listBoxItem.Content));

            steam.Run(account.Name, account.DecryptedPassword);
		}

		private void Listbox_Accounts_Delete(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Are you sure?", 
				string.Format("Delete {0}?", AccountList[Listbox_Accounts.SelectedIndex].Name),
				MessageBoxButton.YesNo);

			if (result == MessageBoxResult.Yes)
			{
				AccountList.RemoveAt(Listbox_Accounts.SelectedIndex);
				Listbox_Accounts.Items.RemoveAt(Listbox_Accounts.SelectedIndex);
			}
		}

		private void Listbox_Accounts_Edit(object sender, RoutedEventArgs e)
		{
			EditAccount EditWin = new EditAccount();
			EditWin.Owner = this;
			EditWin.Show();
		}
	}
}
