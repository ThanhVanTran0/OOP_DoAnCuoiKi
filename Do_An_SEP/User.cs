using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An_SEP
{
    public class User
    {
        string name;
        string password;
        Role _role;
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

        public Role Role
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