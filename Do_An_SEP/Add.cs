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
        private T mObject;
        private FORMTYPE formType;
        private string Title;
        public Add()
        {
            InitializeComponent();
            mObject = (T)Activator.CreateInstance(typeof(T));
            formType = FORMTYPE.ADD;
            Title = "Add";
        }

        public Add(T updateObj)
        {
            InitializeComponent();
            mObject = updateObj;
            formType = FORMTYPE.UPDATE;
            Title = "Update";
        }

        private void Add_Load(object sender, EventArgs e)
        {
            Type type = typeof(T);
            string name = type.Name;
            this.Text = Title + " " + name;
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
                tb.DataBindings.Add("Text", mObject, item.Name);
                nextY += 40;
            }


            Button button = new Button();
            button.Size = new Size(70, 30);
            button.Location = new Point(10, 10 + nextY);
            button.Name = "Button";

            button.Text = Title;
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(formType == FORMTYPE.ADD)
            {
                if (Moudle.INSTANCE.GetModel<BUS<T>>().Insert(mObject))
                {
                    MessageBox.Show("Insert thành công");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Insert lỗi");
                }
            }
            else
            {
                if (Moudle.INSTANCE.GetModel<BUSObj<T>>().Update(mObject))
                {
                    MessageBox.Show("Update thành công");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Update lỗi");
                }
            }
        }
    }
    public enum FORMTYPE
    {
        ADD,
        UPDATE
    }
}
