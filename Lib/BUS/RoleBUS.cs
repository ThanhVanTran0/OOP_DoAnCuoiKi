using Lib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.BUS
{
    class RoleBUS : BUS<Role>
    {
        public RoleBUS(DAO<Role> dao)
        {
            this.dao = dao;
        }

        public DAO<Role> dao { get; set; }

        public bool Delete(Role role)
        {
            Role role1 = dao.Find(role);
            if (role1 == null)
                return false;
            return dao.Delete(role1);
        }

        public bool Insert(Role role)
        {
            Role role1 = dao.Find(role);
            if (role1 != null)
                return false;
            return dao.Insert(role);
        }

        public bool Update(Role role)
        {
            Role role1 = dao.Find(role);
            if (role1 == null)
                return false;
            if (role1.Name != role.Name)
                role1.Name = role.Name;
            return dao.Update(role1);
        }
    }
}
