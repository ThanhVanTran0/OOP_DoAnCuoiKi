using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_SEP.BUS
{
    class UserBUS : BUS<User>
    {
        public IDataProvider provider { get; set; }

        public UserBUS()
        {

            string connString = "Data Source=DESKTOP-251QNVR\\SQLEXPRESS;Initial Catalog=OOP;Integrated Security=True";

            this.provider = new SQLDataProvider(connString);
            if (this.provider.Open() == true)
            {
                MessageBox.Show("Connect thanh cong");
            }
            else
            {
                MessageBox.Show("Connect that bai");
            }
        }

        public bool Delete(User t)
        {
            string query = string.Format("delete from TableUser where ID={0}", t.Id);
            try
            {
                provider.Execute(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Insert(User t)
        {
            string query = string.Format("insert into TableUser(name,pass,Role) values('{0}','{0}',{0})", t.Name, t.Password, t.Role);
            try
            {
                provider.Execute(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(User t)
        {
            string query = string.Format("update TableUser set name='{0}', pass='{0}', Role={0} where ID={0}", t.Name, t.Password, t.Role, t.Id);
            try
            {
                provider.Execute(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
