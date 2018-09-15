using steamboat.components;
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
            SteamAccount Account = new SteamAccount(tb_username.Text, passwordBox.Password.ToString());
            ((MainWindow)Application.Current.MainWindow).NewAccount(Account);
            this.Close();
        }
    }
}
