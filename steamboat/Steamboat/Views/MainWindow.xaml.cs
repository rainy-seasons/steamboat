using Steamboat.Components;
using Steamboat.Utils;
using Steamboat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Steamboat.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm = new MainWindowViewModel();
        }

        private Steam steam = new Steam();
        private MainWindowViewModel vm;

        private void Listbox_Accounts_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?",
                string.Format("Delete {0}?", App.Controller.Accounts[Listbox_Accounts.SelectedIndex].Name),
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                App.Controller.RemoveAccount(App.Controller.Accounts[Listbox_Accounts.SelectedIndex]);
            }
        }

        private void Listbox_Accounts_Edit(object sender, RoutedEventArgs e)
        {
            EditAccount EditWin = new EditAccount();
            EditWin.Owner = this;
            EditWin.Show();
        }

        private void Listbox_Accounts_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (steam.IsRunning())
            {
                steam.Kill();
                Thread.Sleep(200);
            }

            var listBoxItem = VisualTreeHelpers.FindParent<ListBoxItem>((DependencyObject)e.OriginalSource);

            if (listBoxItem == null)
            {
                throw new InvalidOperationException("ListBoxItem not found");
            }

            var account = App.Controller.Accounts.First(ac => ac.Username.Equals(((SteamAccount)listBoxItem.Content).Username));
            string decryptedPassword = Crypto.DecryptString(account.EncryptedPassword, account.Iv);
            steam.Run(account.Username, decryptedPassword);
        }
    }
}
