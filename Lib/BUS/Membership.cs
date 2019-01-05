using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Membership
    {
        private static Membership instance = null;
        private MembershipDefault membershipProvider;
        private Membership()
        {
            membershipProvider = new MembershipDefault();
        }
        private Membership(MembershipDefault membershipProvider)
        {
            this.membershipProvider = membershipProvider;
        }

        public static Membership GetInstance()
        {
            if (instance == null)
            {
                instance = new Membership();
            }
            return instance;
        }
        public bool ValidationUser(string username)
        {
            return membershipProvider.ValidationUser(username);

      
        }
        public bool createUser(string username,string password)
        {
            membershipProvider.CreateUser(username,password);
            return true;
        }

    }
}
