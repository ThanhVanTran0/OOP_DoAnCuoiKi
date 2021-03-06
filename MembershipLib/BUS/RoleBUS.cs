﻿using MembershipLib.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.BUS
{
    public class RoleBUS : BUS<Role>
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

        public List<Role> selectAll()
        {
            return dao.selectAll();
        }

        public DataTable selectAllTable()
        {
            return dao.selectAllTable();
        }

        public bool Update(Role role)
        {
            Role role1 = dao.FindByKey("id", role.Id.ToString());
            if(role1 == null)
                return false;
            if (role1.Name == role.Name)
                return false;
            return dao.Update(role);
        }
        public bool CheckValidate(Role role)
        {
            return false;
        }

        public string GetPermission(string t)
        {
            return "";
        }

        public Role FindByKey(string key, string value)
        {
            return dao.FindByKey(key, value);
        }
    }
}
