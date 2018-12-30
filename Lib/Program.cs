using Lib.BUS;
using Lib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    class Program
    {
        static void Main(string[] args)
        {
            string connect = "Data Source=DESKTOP-251QNVR\\SQLEXPRESS;Initial Catalog=OOP;Integrated Security=True";
            IDataProvider dataProvider = new SQLDataProvider(connect);
            if (dataProvider.Open())
                Console.WriteLine("Connect DB Thanh cong");
            else
                Console.WriteLine("Connect DB that bai");
            Role role = new Role("admin");
            RoleDAO roleDAO = new RoleDAO(dataProvider);
            RoleBUS roleBUS = new RoleBUS(roleDAO);
            if (roleBUS.Insert(role))
                Console.WriteLine("Thanh cong");
            else
                Console.WriteLine("That bai");
        }
    }
}
