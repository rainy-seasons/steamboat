using SQLite;
using Steamboat.Components;
using Steamboat.Utils;
using Steamboat.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamboat.Controllers
{
    public class MainController : ViewModelBase
    {
        public MainController()
        {
            Accounts = new ObservableCollection<SteamAccount>();
            Accounts = GetAllAccounts();
        }

        public SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(App.databasePath);
                    _connection.CreateTable<SteamAccount>();
                }
                return _connection;
            }
        }

        public ObservableCollection<SteamAccount> Accounts;
        private SQLiteConnection _connection;

        public void AddAccount(SteamAccount account)
        {
            account.EncryptedPassword = Crypto.EncryptString(account.SecurePassword, account.Iv);
            Connection.Insert(account);
            Accounts.Add(account);
        }

        public void EditAccount(SteamAccount account)
        {
            account.EncryptedPassword = Crypto.EncryptString(account.SecurePassword, account.Iv);
            Connection.Update(account);
        }

        public SteamAccount GetAccount(int id)
        {
            return Connection.Table<SteamAccount>().FirstOrDefault(customer => customer.Id == id);
        }

        public void RemoveAccount(SteamAccount account)
        {
            Connection.Delete(account);
            Accounts.Remove(account);
        }

        private ObservableCollection<SteamAccount> GetAllAccounts()
        {
            ObservableCollection<SteamAccount> accounts = new ObservableCollection<SteamAccount>();
            List<SteamAccount> list = Connection.Table<SteamAccount>().ToList();
            foreach (var item in list)
                accounts.Add(item);
            return accounts;
        }
    }
}
