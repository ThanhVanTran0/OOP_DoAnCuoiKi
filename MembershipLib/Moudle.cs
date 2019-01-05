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
            RoleDAO roleDAO = new RoleDAO(dataProvider);
            RoleBUS roleBUS = new RoleBUS(roleDAO);

            UserDAO userDAO = new UserDAO(dataProvider);
            UserBUS userBUS = new UserBUS(userDAO);
            SetModel<DAO<Role>>(roleDAO);
            SetModel<BUS<Role>>(roleBUS);

            SetModel<DAO<User>>(userDAO);
            SetModel<BUS<User>>(userBUS);
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
