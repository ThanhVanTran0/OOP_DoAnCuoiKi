using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MembershipLib
{
    public interface IDataProvider
    {
        string stringConnection { get; set; }
        void Execute(string query);
        DataTable ExecuteReturn(string query);
        bool Close();
        bool Open();
    }
}