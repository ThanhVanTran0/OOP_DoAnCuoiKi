using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An_SEP
{
    public interface IDataProvider
    {
        string stringConnection { get; set; }

        bool Update(string query);
        bool Delete(string query);

        bool Insert(string query);

        void Read(string query);

        bool Close();
        bool Open();
    }
}