using MembershipLib.BUS;
using MembershipLib.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib
{
    public class Moudle
    {
        Dictionary<Type, object> moudle = new Dictionary<Type, object>();
        public static Moudle INSTANCE = new Moudle();

        private Moudle()
        {
            Init();
        }
        public void Init()
        {
            string connect = @"Data Source=DESKTOP-R4KLFLJ\SQLEXPRESS;Initial Catalog=OOP_CUOI_KI;Integrated Security=True";
            IDataProvider dataProvider = new SQLDataProvider(connect);
            dataProvider.Open();
            SetModel<IDataProvider>(dataProvider);

            DAOObj<Role> dao = new SqlDaoObj<Role>(dataProvider);
            BUSObj<Role> bus = new BUSObj<Role>(dao);

            SetModel<DAOObj<Role>>(dao);
            SetModel<BUSObj<Role>>(bus);

        }

        public void SetModel<Inf>(Inf model)
        {
            moudle[typeof(Inf)] = model;
        }
        public Inf GetModel<Inf>()
        {
            if (moudle.ContainsKey(typeof(Inf)) == false)
                return default(Inf);
            return (Inf)moudle[typeof(Inf)];
        }
    }
}
