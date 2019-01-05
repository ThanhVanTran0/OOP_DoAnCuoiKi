using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MembershipLib
{
    public interface IDataProvider
    {
        string stringConnection { get; set; }
        void Execute(string query);
        void Execute(string query, List<DbParameter> listParam);
        DataTable ExecuteReturn(string query);
        DataTable ExecuteReturn(string query, List<DbParameter> listParam);
        bool Close();
        bool Open();
    }
}