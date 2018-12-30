using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public class User
    {
        int id;
        string name;
        string password;
        int _role;

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