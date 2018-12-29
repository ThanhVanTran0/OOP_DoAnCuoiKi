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
        UserBUS _userBUS = new UserBUS();
        public Form1()
        {
            InitializeComponent();
        }
    }
}
