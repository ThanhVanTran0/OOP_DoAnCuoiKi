using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.DAO
{
    public class RoleDAO : DAO<Role>
    {
        public IDataProvider dataProvider { get; set; }

        public RoleDAO(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public bool Delete(Role role)
        {
            string query = string.Format("delete from Role where ID={0}", role.Id);
            try
            {
                dataProvider.Execute(query);
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
                dataProvider.Execute(query);
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
                dataProvider.Execute(query);
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
            a = dataProvider.ExecuteReturn(query);
            if (a == null || a.Rows.Count == 0)
                return null;
            role.Id = (int)a.Rows[0]["ID"];
            role.Name = (string)a.Rows[0]["name"];
            return role;
        }

        public Role FindByKey(string key, string value)
        {
            Role role = new Role();
            string query = string.Format("select * from Role where " + key + "='{0}'", value);
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            if (a == null || a.Rows.Count == 0)
                return null;
            role.Id = (int)a.Rows[0]["ID"];
            role.Name = (string)a.Rows[0]["name"];
            return role;
        }

        public List<Role> selectAll()
        {
            List<Role> list = new List<Role>();
            string query = string.Format("select * from Role");
            DataTable table = new DataTable();
            table = dataProvider.ExecuteReturn(query);
            foreach(DataRow row in table.Rows)
            {
                Role role = new Role();
                role.Id = (int) row["ID"];
                role.Name = (string)row["name"];
                list.Add(role);
            }
            return list;
        }

        public DataTable selectAllTable()
        {
            string query = string.Format("select * from Role");
            DataTable table = new DataTable();
            table = dataProvider.ExecuteReturn(query);
            return table;
        }
    }
}
