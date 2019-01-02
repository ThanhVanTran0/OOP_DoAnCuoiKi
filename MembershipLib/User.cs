using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MembershipLib.ATT;

namespace MembershipLib
{
    public class User
    {
        int id;
        string name;
        string password;
        int _role;
        public User()
        {

        }
        public User(string name,string password,string _role)
        {
            this.name = name;
            this.password = password;
            this._role = Int32.Parse(_role);
        }


        [IdentityAttribute]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int Role
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }
    }
}