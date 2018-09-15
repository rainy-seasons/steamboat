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
            // build a new account and save it
            //SteamAccount Account = new SteamAccount(tb_username.Text, passwordBox.ToString());
            MessageBox.Show(string.Format("username: {0}, \npassword: {1}", tb_username.Text, passwordBox.Password.ToString()));
        }
    }
}
