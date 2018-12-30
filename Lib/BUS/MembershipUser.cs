using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class MembershipUser
    {
        private string username;
        private string password;
        private int role;
        private bool isLogin;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        public bool IsLogin { get => isLogin; set => isLogin = value; }

        public MembershipUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
