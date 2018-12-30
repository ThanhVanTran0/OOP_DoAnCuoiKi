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
            string connect = "Data Source=DESKTOP-251QNVR\\SQLEXPRESS;Initial Catalog=OOP;Integrated Security=True";
            IDataProvider dataProvider = new SQLDataProvider(connect);
            dataProvider.Open();
            SetModel<IDataProvider>(dataProvider);
            RoleDAO roleDAO = new RoleDAO(dataProvider);
            RoleBUS roleBUS = new RoleBUS(roleDAO); 
            SetModel<DAO<Role>>(roleDAO);
            SetModel<BUS<Role>>(roleBUS);
        }

        public void SetModel<Inf>(Inf model)
        {

            moudle[typeof(Inf)] = model;
        }
        public Inf GetModel<Inf>()
        {
            return (Inf)moudle[typeof(Inf)];
        }

    }
}
