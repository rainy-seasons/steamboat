namespace steamboat.components
{
    public class SteamAccount
    {
        private string name;
        private string username;
        private string password;

        public SteamAccount()
        {
        }

        public SteamAccount(string username, string password)
        {
            this.name = username;
            this.username = username;
            this.password = password;
        }

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }
    }
}
