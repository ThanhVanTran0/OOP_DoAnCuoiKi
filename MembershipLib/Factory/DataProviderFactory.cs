using MembershipLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.Factory
{
    public class DataProviderFactory
    {
        private static DataProviderFactory INSTANCE = null;

        public static DataProviderFactory GetInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new DataProviderFactory();
            return INSTANCE;
        }

        public IDataProvider CreateDataProvider(DATATYPE datatype,string strConnection)
        {
            IDataProvider data = null;
            if (datatype == DATATYPE.SQL)
                data = new SQLDataProvider(strConnection);
            if (datatype == DATATYPE.MYSQL)
                data = new MySQLDataProvider(strConnection);
            return data;
        }
    }
    public enum DATATYPE
    {
        SQL,
        MYSQL
    }
}
