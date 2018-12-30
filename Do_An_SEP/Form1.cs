using MembershipLib;
using MembershipLib.BUS;
using MembershipLib.DAO;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void nameRole_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void LoadData()
        {
            DataTable table = Moudle.INSTANCE.GetModel<BUS<Role>>().selectAllTable();
            data.DataSource = table;
            data.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add add = new Add();
          DialogResult res=  add.ShowDialog();
            if(res==DialogResult.OK)
            {
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = data.SelectedRows[0].Cells[1].Value.ToString();
            Role role = new Role(name);
            if (Moudle.INSTANCE.GetModel<BUS<Role>>().Delete(role))
                MessageBox.Show("thanh cong");
            else
                MessageBox.Show("that bai");
            LoadData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
