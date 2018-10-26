using SQLite;
using Steamboat.Utils;
using System;
using System.Security;

namespace Steamboat.Components
{
    public class SteamAccount
    {
        public SteamAccount()
        {
            Iv = Crypto.GetNewEntropy();
        }

        public SteamAccount(string username, SecureString password)
        {
            Name = username;
            Username = username;
            SecurePassword = password;
            Iv = Crypto.GetNewEntropy();
        }

        public SteamAccount(string name, string username, SecureString password)
        {
            Name = name;
            Username = username;
            SecurePassword = password;
            Iv = Crypto.GetNewEntropy();
        }

        public string EncryptedPassword { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public byte[] Iv { get; set; }
        public string Name { get; set; }

        [Ignore]
        public SecureString SecurePassword { get; set; }

        public string Username { get; set; }
    }
}
