using MembershipLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.Factory
{
    public class DAOFactory
    {
        private static DAOFactory INSTANCE = null;

        public static DAOFactory GetInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new DAOFactory();
            return INSTANCE;
        }

        public DAOObj<T> CreateDAO<T>(DATATYPE type, IDataProvider dataProvider)
        {
            DAOObj<T> obj = null;
            if (type == DATATYPE.SQL)
                obj = new SqlDaoObj<T>(dataProvider);
            if (type == DATATYPE.MYSQL)
                obj = new MySqlDaoObj<T>(dataProvider);
            return obj;
        }
    }
}
