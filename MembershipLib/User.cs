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
        string pass;
        int _role;
        public User()
        {

        }
        public User(int id,string name, string password, string _role)
        {
            this.id = id;
            this.name = name;
            this.pass = password;
            this._role = Int32.Parse(_role);
        }


        public User(string name,string password,string _role)
        {
            this.name = name;
            this.pass = password;
            this._role = Int32.Parse(_role);
        }

        [IdentityAttribute]
        [PrimaryKey]

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

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
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