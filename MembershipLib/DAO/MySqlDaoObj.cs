using MembershipLib.ATT;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.DAO
{
    public class MySqlDaoObj<T> : DAOObj<T>
    {
        public MySqlDaoObj(IDataProvider _dataProvider) : base(_dataProvider)
        {
        }

        public override bool Delete(T t)
        {
            Type type = typeof(T);
            PropertyInfo[] pop = type.GetProperties();
            string query = "";
            List<DbParameter> list = new List<DbParameter>();
            foreach (var item in pop)
            {
                var atts = item.GetCustomAttributes();
                foreach (var att in atts)
                {
                    if (att is PrimaryKey)
                    {
                        query = string.Format("delete from {0} where {1}=@{1}", type.Name, item.Name);
                        list.Add(new MySqlParameter("@" + item.Name, item.GetValue(t)));
                        break;
                    }
                }
            }

            if (query != "")
            {
                try
                {
                    dataProvider.Execute(query, list);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }

        public override T Find(T t)
        {
            Type type = typeof(T);
            PropertyInfo[] pop = type.GetProperties();
            string query = "";
            List<DbParameter> list = new List<DbParameter>();
            foreach (var item in pop)
            {
                var atts = item.GetCustomAttributes();
                foreach (var att in atts)
                {
                    if (att is PrimaryKey)
                    {
                        query = string.Format("select * from {0} where {1}=@{1}", type.Name, item.Name);
                        list.Add(new MySqlParameter("@" + item.Name, item.GetValue(t)));
                        break;
                    }
                }
            }

            if (query != "")
            {
                DataTable a = new DataTable();
                a = dataProvider.ExecuteReturn(query, list);
                if (a.Rows.Count == 0)
                    return default(T);
                return this.ConvertDataRow(a.Rows[0]);
            }

            return default(T);
        }

        public override T FindByKey(string key, string value)
        {
            return default(T);
        }

        public override bool Insert(T t)
        {
            Type type = typeof(T);
            PropertyInfo[] pop = type.GetProperties();
            string query = "";
            List<DbParameter> list = new List<DbParameter>();

            string value = "";
            string param = "";

            foreach (var item in pop)
            {
                bool res = false;
                var atts = item.GetCustomAttributes();
                foreach (var att in atts)
                {
                    if (att is IdentityAttribute)
                    {
                        res = true;
                        break;
                    }
                }

                if (res == true)
                    continue;

                value += item.Name + ",";
                param += "@" + item.Name + ",";
                list.Add(new MySqlParameter("@" + item.Name, item.GetValue(t)));
            }

            value = value.Substring(0, value.Length - 1);
            param = param.Substring(0, param.Length - 1);

            query = "insert into " + type.Name + "(" + value + ") values(" + param + ")";

            try
            {
                dataProvider.Execute(query, list);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override List<T> selectAll()
        {
            return null;
        }

        public override DataTable selectAllTable()
        {
            Type type = typeof(T);
            string query = string.Format("select * from {0}", type.Name);
            DataTable a = new DataTable();
            a = dataProvider.ExecuteReturn(query);
            return a;
        }

        public override bool Update(T t)
        {
            Type type = typeof(T);
            PropertyInfo[] pop = type.GetProperties();
            string query = "";
            List<DbParameter> list = new List<DbParameter>();

            string value = "";
            string KeyValue = "";
            MySqlParameter keyParamater = null;

            foreach (var item in pop)
            {
                bool res = false;
                var atts = item.GetCustomAttributes();
                foreach (var att in atts)
                {
                    if (att is PrimaryKey)
                    {
                        res = true;
                        KeyValue = item.Name + "= @" + item.Name;
                        keyParamater = new MySqlParameter("@" + item.Name, item.GetValue(t));
                        break;
                    }
                }

                if (res == true)
                    continue;

                value += item.Name + "=@" + item.Name + ",";
                list.Add(new MySqlParameter("@" + item.Name, item.GetValue(t)));
            }

            value = value.Substring(0, value.Length - 1);
            list.Add(keyParamater);
            query = "update " + type.Name + " set " + value + " where " + KeyValue;

            try
            {
                dataProvider.Execute(query, list);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
