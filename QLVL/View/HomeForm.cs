using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVL.View
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void btn_dkhome_Click(object sender, EventArgs e)
        {
            RegisterForm dk = new RegisterForm();
            dk.Show();
            this.Hide();

        }

        private void btn_dnhome_Click(object sender, EventArgs e)
        {
            LoginForm dn = new LoginForm();
            dn.Show();
            this.Hide();
            this.Hide();
        }
    }
}
