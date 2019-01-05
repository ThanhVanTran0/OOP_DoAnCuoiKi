using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.DAO
{
    public interface DAO<T>
    {
        IDataProvider dataProvider { get; set; }
        bool Insert(T t);
        bool Update(T t);
        bool Delete(T t);

        T FindByKey(string key, string value);
        T Find(T t);
        List<T> selectAll();
        DataTable selectAllTable();
    }
}
