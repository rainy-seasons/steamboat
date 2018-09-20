using steamboat.components;
using System.Text.RegularExpressions;
using System.Windows;

namespace steamboat.WPF
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
            if (TestString(tb_username.Text) && TestString(passwordBox.Password.ToString()))
            {
                SteamAccount Account = new SteamAccount(tb_username.Text, passwordBox.Password.ToString());
                ((MainWindow)Application.Current.MainWindow).NewAccount(Account);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid username and password.");
            }
        }

        private bool TestString(string str)
        {
            // Only allow alphanumerics and spaces
            return Regex.IsMatch(str, @"^[A-Za-z0-9\s@]*$");
        }
    }
}
