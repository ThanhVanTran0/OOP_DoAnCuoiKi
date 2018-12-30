using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAO
{
    public interface DAO<T>
    {
        IDataProvider dataProvider { get; set; }
        bool Insert(T t);
        bool Update(T t);
        bool Delete(T t);

        T Find(T t); 
    }
}
