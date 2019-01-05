using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public abstract  class MembershipProvider
    {
        public abstract bool ValidationUser(string username);
        public abstract MembershipUser CreateUser(string username, string password);
        public abstract bool deleteUser();
        public  abstract MembershipUser findUser(string username);
    }
}
