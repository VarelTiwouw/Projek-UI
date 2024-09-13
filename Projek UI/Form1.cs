using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projek_UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Varel" && txtPassword.Text == "123")
            {
                FormPenjualan formPenjualan = new FormPenjualan();
                formPenjualan.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah");
            }
        }
    }
}
