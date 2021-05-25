using System;
using System.Collections.Generic;
using System.Text;

namespace MTParasPatel
{
    public class Login
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Login(int id, string username, string password)
        {
            ID = id;
            Username = username;
            Password = password;
        }
     

       






    }
}
