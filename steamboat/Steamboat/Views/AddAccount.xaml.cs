using Steamboat.Components;
using System.Text.RegularExpressions;
using System.Windows;

namespace Steamboat.Views
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            SteamAccount Account = new SteamAccount(tb_username.Text, passwordBox.SecurePassword);
            ((MainWindow)Application.Current.MainWindow).NewAccount(Account);
            this.Close();
        }

        private bool TestString(string str)
        {
            // Only allow alphanumerics and spaces
            return Regex.IsMatch(str, @"^[A-Za-z0-9\s@]*$");
        }
    }
}
