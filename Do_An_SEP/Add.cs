using MembershipLib;
using MembershipLib.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MembershipLib.ATT;

namespace Do_An_SEP
{
    public partial class Add<T> : Form
    {
        private List<TextBox> arrTb;
        public Add()
        {
            InitializeComponent();
            arrTb = new List<TextBox>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Role role = new Role(name.Text);
            //if (Moudle.INSTANCE.GetModel<BUS<T>>().Insert(role))
            //{
            //    MessageBox.Show("Thanh cong");
            //    this.DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    MessageBox.Show("That bai");
            //    this.DialogResult = DialogResult.Cancel;
            //}
        }

        private void Add_Load(object sender, EventArgs e)
        {
            Type type = typeof(T);
            string name = type.Name;
            this.Text = "Add " + name;
            var prop = type.GetProperties();
            Size lbSize = new Size(100, 30);
            Point lbLocation = new Point(10, 10);

            Size tbSize = new Size(200, 30);
            Point tbLocation = new Point(130, 10);

            int nextY = 0;

            foreach (var item in prop)
            {
                var atts = item.GetCustomAttributes();
                bool res = false;
                foreach (var att in atts)
                {
                    if (att is IdentityAttribute)
                    {
                        res = true;
                        break;
                    }
                }
                if (res)
                    continue;


                Label lb = new Label();
                lb.Size = lbSize;
                lb.Location = new Point(lbLocation.X, lbLocation.Y + nextY);
                lb.Text = item.Name;
                lb.Name = "lb" + item.Name;
                this.Controls.Add(lb);

                TextBox tb = new TextBox();
                tb.Size = tbSize;
                tb.Location = new Point(tbLocation.X, tbLocation.Y + nextY);
                tb.Name = "txt" + item.Name;
                this.Controls.Add(tb);
                this.arrTb.Add(tb);
                nextY += 40;
            }

            Button btnOk = new Button();
            btnOk.Size = new Size(70, 30);
            btnOk.Location = new Point(10, 10 + nextY);
            btnOk.Name = "btnOK";
            btnOk.Text = "OK";
            this.Controls.Add(btnOk);
            btnOk.Click += new EventHandler(btnOk_Click);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string str = "";
            List<object> OBJ = new List<object>();
            foreach (var item in this.arrTb)
            {
                OBJ.Add(item.Text);
            }
            Type sa = typeof(T);
            T itemAdd = (T)sa.GetConstructors()[1].Invoke(OBJ.ToArray());
            if (Moudle.INSTANCE.GetModel<BUS<T>>().Insert(itemAdd))
            {
                MessageBox.Show("OK");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Loi");
            }
        }
    }
}
