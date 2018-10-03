using System.Windows;

namespace steamboat.WPF
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        const string _fakePassword = "12345678";

        public EditAccount()
        {
            InitializeComponent();
            MainWindow MW = ((MainWindow)Application.Current.MainWindow);
            tb_username.Text = MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Name;
            passwordBox.Password = _fakePassword;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = ((MainWindow)Application.Current.MainWindow);
            MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Name = tb_name.Text;
            MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Username = tb_username.Text;
            MW.AccountList[MW.Listbox_Accounts.SelectedIndex].SecurePassword = passwordBox.SecurePassword;
            MW.Listbox_Accounts.Items[MW.Listbox_Accounts.SelectedIndex] = tb_name.Text;
            this.Close();
        }
    }
}
