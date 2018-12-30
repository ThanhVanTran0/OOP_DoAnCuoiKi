using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib

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
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}