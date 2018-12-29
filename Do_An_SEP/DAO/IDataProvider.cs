using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An_SEP
{
    public interface IDataProvider
    {
        string nameConnection { get; set; }

        bool Create();
        bool Update(string query);
        bool Delete(string query);

        void Read(string query);

        bool Connect();
        bool Close();
    }
}