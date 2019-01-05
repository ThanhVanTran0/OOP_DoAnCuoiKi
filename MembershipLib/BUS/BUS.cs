using MembershipLib.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.BUS
{
    public interface BUS<T>
    {
        DAO<T> dao { get; set; }
        bool Insert(T t);
        bool Update(T t);

        bool CheckValidate(T t);
        string GetPermission(string t);

        T FindByKey(string key, string value);
        bool Delete(T t);
        List<T> selectAll();
        DataTable selectAllTable();
    }
}
