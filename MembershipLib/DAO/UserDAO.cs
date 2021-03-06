﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.DAO
{
    public class UserDAO : DAO<User>
    {
        public IDataProvider dataProvider { get; set; }

        public UserDAO(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public bool Delete(User t)
        {
            string query = string.Format("delete from dbo.[User] where ID={0}", t.Id);
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
            string query = string.Format("insert into dbo.[User](name,pass,Role) values('{0}','{1}',{2})", t.Name, t.Pass, t.Role);
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
            string query = string.Format("update dbo.[User] set name='{0}', pass='{1}', Role={2} where ID={3}", t.Name, t.Pass, t.Role, t.Id);
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
            string query = string.Format("select * from dbo.[User] where name='{0}'", t.Name);
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            if (a.Rows.Count == 0)
                return null;
            user.Id = (int)a.Rows[0]["ID"];
            user.Name = (string)a.Rows[0]["name"];
            user.Pass = (string)a.Rows[0]["pass"];
            user.Role = (int)a.Rows[0]["Role"];
            return user;
        }

        public User FindByName(string name)
        {
            User user = new User();
            string query = string.Format("select * from dbo.[User] where name='{0}'", name);
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            if (a.Rows.Count == 0)
                return null;
            user.Id = (int)a.Rows[0]["ID"];
            user.Name = (string)a.Rows[0]["name"];
            user.Pass = (string)a.Rows[0]["pass"];
            user.Role = (int)a.Rows[0]["Role"];
            return user;
        }

        public User FindByKey(string key, string value)
        {
            User user = new User();
            string query = string.Format("select * from dbo.[User] where " + key + " ='{0}'", value);
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            if (a.Rows.Count == 0)
                return null;
            user.Id = (int)a.Rows[0]["ID"];
            user.Name = (string)a.Rows[0]["name"];
            user.Pass = (string)a.Rows[0]["pass"];
            user.Role = (int)a.Rows[0]["Role"];
            return user;
        }

        public List<User> selectAll()
        {
            throw new NotImplementedException();
        }

        public DataTable selectAllTable()
        {
            User user = new User();
            string query = string.Format("select * from dbo.[User]");
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            return a;
        }
    }
}
