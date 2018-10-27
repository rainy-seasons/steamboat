using Steamboat.Commands;
using Steamboat.Components;
using Steamboat.Views;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace Steamboat.ViewModels
{
    public class EditAccountViewModel : ViewModelBase
    {
        public EditAccountViewModel()
        {
            MainWindow MW = ((MainWindow)Application.Current.MainWindow);
            selectedAccount = App.Controller.Accounts[MW.Listbox_Accounts.SelectedIndex];
            Name = selectedAccount.Name;
            UserName = selectedAccount.Username;
            Password = _fakePassword;
        }

        public ICommand EditCommand => new Command<Window>(EditAccount);

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private const string _fakePassword = "12345678";
        private string _name;
        private string _password;
        private string _userName;
        private SteamAccount selectedAccount;

        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        private void EditAccount(Window editWindows)
        {
            var securePassword = new SecureString();
            foreach (char c in Password)
                securePassword.AppendChar(c);
            securePassword.MakeReadOnly();
            SteamAccount account = new SteamAccount(Name, UserName, securePassword);
            account.Id = selectedAccount.Id;
            account.Iv = selectedAccount.Iv;
            App.Controller.EditAccount(account);
            this.CloseWindow((Window)editWindows);
        }
    }
}