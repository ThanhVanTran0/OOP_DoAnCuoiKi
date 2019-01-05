using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class MembershipDefault : MembershipProvider
    {
        private List<MembershipUser> membershipUser;

      public MembershipDefault()
        {
            membershipUser = new List<MembershipUser>();
        }

        public override MembershipUser CreateUser(string username, string password)
        {
            MembershipUser user = new MembershipUser(username, password);
            membershipUser.Add(user);
            return user;
        }

        public override bool deleteUser()
        {
            return true;
        }

        public override MembershipUser findUser(string username)
        {
            for (int i = 0; i < membershipUser.Count; i++)
            {
                if (membershipUser[i].Username == username)
                    return membershipUser[i];
            }
            return null;
        }

        public override bool ValidationUser(string username)
        {
            return true;
        }
    }
}
