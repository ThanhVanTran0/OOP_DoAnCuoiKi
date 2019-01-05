using MembershipLib.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.BUS
{
    public class UserBUS : BUS<User>
    {
        public UserBUS(DAO<User> dao)
        {
            this.dao = dao;
        }

        public DAO<User> dao { get; set; }

        public bool Delete(User user)
        {
            User user1 = dao.Find(user);
            if (user1 == null)
                return false;
            return dao.Delete(user1);
        }

        public bool Insert(User user)
        {
            User user1 = dao.Find(user);
            if (user1 != null)
                return false;
            return dao.Insert(user);
        }

        public List<User> selectAll()
        {
            return dao.selectAll();
        }

        public DataTable selectAllTable()
        {
            return dao.selectAllTable();
        }

        public bool Update(User user)
        {
            User user1 = dao.FindByKey("Id", user.Id.ToString());
            if (user1 == null)
                return false;
            if (user1.Name == user.Name && user1.Pass == user.Pass && user1.Role == user.Role)
                return false;
            return dao.Update(user);
        }

        public bool CheckValidate(User user)
        {
            User _user = dao.FindByKey("name", user.Name);
            if (_user == null) return false;
            return true;
        }
        public string GetPermission(string t)
        {
            return "";
        }

        public User FindByKey(string key, string value)
        {
            return dao.FindByKey(key, value);
        }
    }
}
