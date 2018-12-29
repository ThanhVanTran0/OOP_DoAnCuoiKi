using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Do_An_SEP
{
    public interface IDataProvider
    {
        string stringConnection { get; set; }
        void Execute(string query);
        bool Close();
        bool Open();
    }
}