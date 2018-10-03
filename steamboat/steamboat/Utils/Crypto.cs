using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace steamboat.Utils
{
    static class Crypto
    {
        /// <summary>
        /// Returns a random byte sequence as encryption IV.
        /// </summary>
        /// <param name="ivLength">The length of the IV. Default to 32.</param>
        /// <returns>A random byte sequence.</returns>
        public static byte[] GetNewEntropy(int ivLength = 32)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                var entropy = new byte[ivLength];
                rng.GetBytes(entropy);
                return entropy;
            }
        }

        /// <summary>
        /// Encrypts a SecureString with given IV.
        /// </summary>
        /// <param name="plaintext">SecureString of plaintext password.</param>
        /// <param name="entropy">Random byte array used as IV.</param>
        /// <returns>Base64-encoded cipher text.</returns>
        public static string EncryptString(SecureString plaintext, byte[] entropy, 
            DataProtectionScope scope = DataProtectionScope.CurrentUser)
        {
            var encryptedBytes = ProtectedData.Protect(
                Encoding.Default.GetBytes(plaintext.ToInsecureString()),
                entropy,
                scope);

            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decrypts cipher text with original IV.
        /// </summary>
        /// <param name="cipher">Base64-encoded cipher.</param>
        /// <param name="entropy">Original entrypy used for encryption.</param>
        /// <returns>Plaintext.</returns>
        public static string DecryptString(string cipher, byte[] entropy,
            DataProtectionScope scope = DataProtectionScope.CurrentUser)
        {
            try
            {
                var decryptedBytes = ProtectedData.Unprotect(
                    Convert.FromBase64String(cipher), entropy, scope);
                return Encoding.Default.GetString(decryptedBytes);
            }
            catch (CryptographicException)
            {
                // decryption failure; handle properly
                throw;
            }
        }

        /// <summary>
        /// Converts SecureString to an insecure managed string.
        /// This is an insecure method.
        /// </summary>
        /// <returns>Managed string.</returns>
        public static string ToInsecureString(this SecureString input)
        {
            // get the pointer of SecureString
            var ptr = Marshal.SecureStringToBSTR(input);

            try
            {
                // convert pointer to managed string
                return Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                // free the pointer
                Marshal.ZeroFreeBSTR(ptr);
            }
        }
    }
}
