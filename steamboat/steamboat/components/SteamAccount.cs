using steamboat.Utils;
using System;
using System.Security;

namespace steamboat.components
{
    public class SteamAccount
    {
        public string Name { get; set; }
        public string Username { get; set; }

        public byte[] Iv { get; set; }
        public SecureString SecurePassword { get; set; }

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

        public string EncryptedPassword
        {
            get
            {
                // use the random iv to encrypt the password
                return Crypto.EncryptString(SecurePassword, Iv);
            }
        }

        /// <summary>
        /// Base64 encoded IV.
        /// Be sure to store this - need original IV to decrypt password
        /// </summary>
        public string EncodedIv
        {
            get
            {
                return Convert.ToBase64String(Iv);
            }
        }

        /// <summary>
        /// Example of decrypting password.
        /// </summary>
        public string DecryptedPassword
        {
            get
            {
                // use the original iv to decrypt the password
                return Crypto.DecryptString(EncryptedPassword, Iv);
            }
        }
    }
}
