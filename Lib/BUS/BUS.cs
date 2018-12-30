using Lib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.BUS
{
    public interface BUS<T>
    {
        DAO<T> dao { get; set; }
        bool Insert(T t);
        bool Update(T t);

        bool Delete(T t);
    }
}
