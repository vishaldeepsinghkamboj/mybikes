using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybikes.Bus
{
    public class Loginpage
    {
        private string username;
        private string password;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public Loginpage()
        {
            this.username = "";
            this.password = "";
        }

        public Loginpage(string username, string password)
        {
            this.username = username;
            this.password = password;

        }

        public override string ToString()
        {
            string state;
            state = username + "  " + password;
            return state;

        }


    }
}
