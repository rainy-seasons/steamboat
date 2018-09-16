using steamboat.components;
using System.Linq;
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
                this.Close();
            }
        }

        private bool TestString(string str)
        {
            if (!str.All(c => char.IsLetterOrDigit(c)) || str.Length < 2)
            {
                return false;
            }
            return true;
        }
    }
}
