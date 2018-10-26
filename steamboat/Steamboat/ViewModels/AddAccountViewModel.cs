using Steamboat.Commands;
using Steamboat.Components;
using Steamboat.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Steamboat.ViewModels
{
    public class AddAccountViewModel : ViewModelBase
    {
        public ICommand AddCommand => new Command<Window>(AddAcount);

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

        private string _name;
        private string _password;
        private string _userName;

        private void AddAcount(Window addWindow)
        {
            var securePassword = new SecureString();
            foreach (char c in Password)
                securePassword.AppendChar(c);
            securePassword.MakeReadOnly();
            SteamAccount Account = new SteamAccount(Name, UserName, securePassword);
            App.Controller.AddAccount(Account);
            this.CloseWindow((Window)addWindow);
        }

        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
