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

namespace MembershipLib.LibForm
{
    public partial class BaseForm<T> : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            LoadData();
            Type type = typeof(T);
            lbTitle.Text = "Table " + type.Name;
        }

        private void LoadData()
        {
            BUSObj<T> bus = Moudle<T>.INSTANCE.GetModel<BUSObj<T>>();
            if (bus != null)
            {
                DataTable table = bus.selectAllTable();
                data.DataSource = table;
                data.Update();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add<T> add = new Add<T>();
            DialogResult res = add.ShowDialog();
            if (res == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)data.SelectedRows[0].DataBoundItem;
                T delObj = ConvertDataRow(row);
                if (Moudle<T>.INSTANCE.GetModel<BUSObj<T>>().Delete(delObj))
                    MessageBox.Show("Xóa thành công");
                else
                    MessageBox.Show("Lỗi xóa");
                LoadData();
            }
        }

        private T ConvertDataRow(DataRowView row)
        {
            Type type = typeof(T);
            PropertyInfo[] pop = type.GetProperties();
            T obj = (T)Activator.CreateInstance(typeof(T));
            foreach (var item in pop)
            {
                //Console.WriteLine(row[item.Name]);
                item.SetValue(obj, row[item.Name]);
            }
            return obj;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)data.SelectedRows[0].DataBoundItem;
            T objUpdate = ConvertDataRow(row);
            Add<T> add = new Add<T>(objUpdate);
            DialogResult res = add.ShowDialog();
            if (res == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
