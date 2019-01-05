using MembershipLib.ATT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.DAO
{
    public abstract class DAOObj<T> : DAO<T>
    {
        public IDataProvider dataProvider
        {
            get; set;
        }

        public DAOObj(IDataProvider _dataProvider)
        {
            this.dataProvider = _dataProvider;
        }

        public abstract bool Delete(T t);

        public abstract T Find(T t);

        public abstract T FindByKey(string key, string value);


        public abstract bool Insert(T t);

        public abstract List<T> selectAll();

        public abstract DataTable selectAllTable();

        public abstract bool Update(T t);

        public virtual T ConvertDataRow(DataRow row)
        {
            Type type = typeof(T);
            PropertyInfo[] pop = type.GetProperties();
            T obj = (T)Activator.CreateInstance(typeof(T));
            foreach (var item in pop)
            {
                item.SetValue(obj, row[item.Name]);
            }
            return obj;
        }
    }
}
