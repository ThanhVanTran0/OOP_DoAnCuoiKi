using MembershipLib;
using MembershipLib.BUS;
using MembershipLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_SEP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //string connect = @"Data Source=DESKTOP-R4KLFLJ\SQLEXPRESS;Initial Catalog=OOP_CUOI_KI;Integrated Security=True";
            //IDataProvider dataProvider = new SQLDataProvider(connect);
            //dataProvider.Open();
            //DAOObj<User> daoUSer = new SqlDaoObj<User>(dataProvider);
            //BUSObj<User> busUser = new BUSObj<User>(daoUSer);
            ////busUser.Find(new User("thanh", "123456", "1"));
            ////daoUSer.Update(new User(2,"thanhvantran", "141250", "1"));

            Application.Run(new Form1<Role>());
        }
    }
}
