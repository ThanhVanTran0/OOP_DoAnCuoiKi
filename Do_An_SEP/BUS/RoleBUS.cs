using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_SEP.BUS
{
    class RoleBUS : BUS<Role>
    {
        public IDataProvider provider { get; set; }

        public RoleBUS()
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
        public bool Delete(Role role)
        {
            string query = string.Format("delete from Role where ID={0}", role.Id);
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

        public bool Insert(Role role)
        {
            string query = string.Format("insert into Role(name) values(N'{0}')", role.Name);
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

        public bool Update(Role role)
        {
            string query = string.Format("update Role set name='{0}' where ID={0}", role.Name, role.Id);
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
