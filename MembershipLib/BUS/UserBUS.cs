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
            throw new NotImplementedException();
        }

        public DataTable selectAllTable()
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            User user1 = dao.Find(user);
            if (user1 == null)
                return false;
            if (user1.Name != user.Name)
                user1.Name = user.Name;
            return dao.Update(user1);
        }
    }
}
