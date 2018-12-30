using MembershipLib;
using MembershipLib.BUS;
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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Role role = new Role(name.Text);
            if (Moudle.INSTANCE.GetModel<BUS<Role>>().Insert(role))
            {
                MessageBox.Show("Thanh cong");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("That bai");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
