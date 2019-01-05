using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MembershipLib.DAO;
using MembershipLib;
using System.Reflection;

namespace MembershipLib.BUS
{
    public class BUSObj<T> : BUS<T>
    {
        public DAO<T> dao { get; set; }

        public bool CheckValidate(T t)
        {
            return false;
        }

        public BUSObj(DAO<T> _dao) {
            this.dao = _dao;
        }

        public BUSObj()
        {
        }

        public bool Delete(T t)
        {
            T delObj = dao.Find(t);
            if (delObj == null)
                return false;
            return dao.Delete(t);
        }

        public T FindByKey(string key, string value)
        {
            return dao.FindByKey(key, value);
        }

        public string GetPermission(string t)
        {
            return null;
        }

        public bool Insert(T t)
        {
            T findObj = dao.Find(t);
            if (findObj != null)
                return false;
            return dao.Insert(t);
        }

        public List<T> selectAll()
        {
            return null;
        }

        public DataTable selectAllTable()
        {
            return dao.selectAllTable();
        }

        public bool Update(T t)
        {
            T findObject = dao.Find(t);
            if (findObject == null)
                return false;

            Type type = typeof(T);

            bool hasUpdate = false;

            PropertyInfo[] pop = type.GetProperties();
            foreach (var item in pop)
            {
                if(item.GetValue(t) != item.GetValue(findObject))
                {
                    hasUpdate = true;
                    break;
                }
            }

            if(!hasUpdate)
            {
                return false;
            }
            return dao.Update(t);
        }
    }
}
