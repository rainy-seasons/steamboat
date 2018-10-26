using Steamboat.Commands;
using Steamboat.Components;
using Steamboat.Utils;
using Steamboat.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Steamboat.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            steam = new Steam();
            Accounts = App.Controller.Accounts;
            CheckSteamStatus();
            steam.CheckPath();
            Crypto.GetNewEntropy();
        }

        public ObservableCollection<SteamAccount> Accounts
        {
            get => _accounts;
            set => SetProperty(ref _accounts, value);
        }
        public ICommand KillProcessCommand => new Command(KillProcess);
        public ICommand ShowAddViewCommand => new Command<Window>(ShowAdView);

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private ObservableCollection<SteamAccount> _accounts;

        private string _status;

        private Steam steam;

        private void CheckSteamStatus()
        {
            Status = steam.IsRunning() ? "Running" : "Offline";
        }

        private void KillProcess()
        {
            if (steam.IsRunning())
                steam.Kill();
            Thread.Sleep(200);
            CheckSteamStatus();
        }

        private void ShowAdView(Window mainView)
        {
            AddAccount AddWin = new AddAccount();
            AddWin.Owner = mainView;
            AddWin.Show();
        }
    }
}
