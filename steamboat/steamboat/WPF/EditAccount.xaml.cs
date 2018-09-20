using System.Windows;

namespace steamboat.WPF
{
    /// <summary>
    /// Interaction logic for EditAccount.xaml
    /// </summary>
    public partial class EditAccount : Window
    {
        public EditAccount()
        {
            InitializeComponent();
            MainWindow MW = ((MainWindow)Application.Current.MainWindow);
            tb_username.Text = MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Name;
            passwordBox.Password = MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Password;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = ((MainWindow)Application.Current.MainWindow);
            MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Name = tb_name.Text;
            MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Username = tb_username.Text;
            MW.AccountList[MW.Listbox_Accounts.SelectedIndex].Password = passwordBox.Password.ToString();
            MW.Listbox_Accounts.Items[MW.Listbox_Accounts.SelectedIndex] = tb_name.Text;
            this.Close();
        }
    }
}
