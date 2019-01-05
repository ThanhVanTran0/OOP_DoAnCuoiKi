using MembershipLib.BUS;
using MembershipLib.DAO;
using MembershipLib.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib
{
    public class Moudle<T>
    {
        Dictionary<Type, object> moudle = new Dictionary<Type, object>();
        public static Moudle<T> INSTANCE = new Moudle<T>();

        private Moudle()
        {
            Init();
        }
        public void Init()
        {
            string connect = @"Data Source=DESKTOP-R4KLFLJ\SQLEXPRESS;Initial Catalog=OOP_CUOI_KI;Integrated Security=True";
            //string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=OOP_CUOI_KI";
            IDataProvider dataProvider = DataProviderFactory.GetInstance().CreateDataProvider(DATATYPE.SQL, connect);
            dataProvider.Open();
            SetModel<IDataProvider>(dataProvider);

            DAOObj<T> dao = DAOFactory.GetInstance().CreateDAO<T>(DATATYPE.SQL, dataProvider);
            BUSObj<T> bus = new BUSObj<T>(dao);

            SetModel<BUSObj<T>>(bus);

            DAO<User> userdao = new UserDAO(dataProvider);
            BUS<User> userbus = new UserBUS(userdao);

            SetModel<BUS<User>>(userbus);

            DAO<Role> roleDao = new RoleDAO(dataProvider);
            BUS<Role> roleBus = new RoleBUS(roleDao);

            SetModel<BUS<Role>>(roleBus);
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
