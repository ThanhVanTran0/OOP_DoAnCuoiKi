using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAO
{
    class RoleDAO : DAO<Role>
    {
        public IDataProvider provider { get; set; }
        public IDataProvider dataProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public RoleDAO(IDataProvider dataProvider)
        {
            provider = dataProvider;
        }
        public bool Delete(Role role)
        {
            string query = string.Format("delete from Role where ID={0}", role.Id);
            try
            {
                provider.Execute(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Insert(Role role)
        {
            string query = string.Format("insert into Role(name) values(N'{0}')", role.Name);
            try
            {
                provider.Execute(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Role role)
        {
            string query = string.Format("update Role set name='{0}' where ID={0}", role.Name, role.Id);
            try
            {
                provider.Execute(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Role Find(Role t)
        {
            Role role = new Role();
            string query = string.Format("select * from Role where name='{0}'", t.Name);
            DataTable a = new DataTable();
            a = provider.ExecuteReturn(query);
            if (a == null || a.Rows.Count == 0)
                return null;
            role.Id = (int)a.Rows[0]["ID"];
            role.Name = (string)a.Rows[0]["name"];
            return role;
        }
    }
}
