using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterWebTesting
{
    public class Credentials
    {
        private string name { get; set; }
        private string login { get; set; }
        private string password { get; set; }

        public Credentials(string NAME, string LOGIN, string PASSWORD)
        {
            name = NAME;
            login = LOGIN;
            password = PASSWORD;
        }

        public string GetName() { return name; }
        public string GetLogin() { return login; }
        public string GetPassword() { return password; }
    }
}
