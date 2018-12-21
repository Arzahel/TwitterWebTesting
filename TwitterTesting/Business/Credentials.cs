using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterTesting
{
    public class Credentials
    {
        private string Name { get; set; }
        private string Login { get; set; }
        private string Password { get; set; }
        private string AccountID { get; set; }

        public Credentials(string NAME, string LOGIN, string PASSWORD, string id)
        {
            Name = NAME;
            Login = LOGIN;
            Password = PASSWORD;
            AccountID = id;
        }

        public string GetName() { return Name; }
        public string GetLogin() { return Login; }
        public string GetPassword() { return Password; }
        public string GetID() { return AccountID; }
    }
}
