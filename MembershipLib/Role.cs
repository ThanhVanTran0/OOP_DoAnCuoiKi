using MembershipLib.ATT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MembershipLib

{
    public class Role
    {
        private int id;
        private string name;

        public Role()
        {
        }

        public Role(string name)
        {
            this.Name = name;
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
    }
}