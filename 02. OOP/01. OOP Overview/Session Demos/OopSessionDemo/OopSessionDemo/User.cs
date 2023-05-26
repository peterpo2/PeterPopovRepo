using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSessionDemo
{
    public class User
    {
        public string userName;
        public string password;
        public string firstName;
        public string lastName;

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public User(string userName, string password, string firstName)
            : this(userName, password)
        {
            this.firstName = firstName;
        }

        public User(string userNameParameter, string password, string firstName, string lastName)
            : this(userNameParameter, password, firstName)
        {
            this.lastName = lastName;
        }
    }
}
