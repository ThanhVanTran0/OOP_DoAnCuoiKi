using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_SEP.BUS
{
    public interface BUS<T>
    {
        IDataProvider provider { get; set; }
        bool Insert(T t);
        bool Update(T t);

        bool Delete(T t);
    }
}
