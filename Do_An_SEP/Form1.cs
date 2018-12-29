using Do_An_SEP.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_SEP
{
    public partial class Form1 : Form
    {
        RoleBUS _roleBus = new RoleBUS();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Role role = new Role(1,nameRole.Text);
            if (_roleBus.Insert(role))
                MessageBox.Show("Thành công");
            else MessageBox.Show("Không thành công");
        }

        private void nameRole_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
