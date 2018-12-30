using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.DAO
{
    public class UserDAO:DAO<User>
    {
        public IDataProvider dataProvider { get; set; }

        public UserDAO(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public bool Delete(User t)
        {
            string query = string.Format("delete from TableUser where ID={0}", t.Id);
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

        public bool Insert(User t)
        {
            string query = string.Format("insert into TableUser(name,pass,Role) values('{0}','{0}',{0})", t.Name, t.Password, t.Role);
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

        public bool Update(User t)
        {
            string query = string.Format("update TableUser set name='{0}', pass='{0}', Role={0} where ID={0}", t.Name, t.Password, t.Role, t.Id);
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

        public User Find(User t)
        {
            User user = new User();
            string query = string.Format("select * from TableUser where ID='{0}'", t.Id);
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            user.Id = (int) a.Rows[0]["ID"];
            user.Name =(string) a.Rows[0]["name"];
            user.Password = (string) a.Rows[0]["pass"];
            user.Role = (int) a.Rows[0]["Role"];
            return user;
        }

        public List<User> selectAll()
        {
            throw new NotImplementedException();
        }

        public DataTable selectAllTable()
        {
            User user = new User();
            string query = string.Format("select * from TableUser");
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            return a;
        }
    }
}
