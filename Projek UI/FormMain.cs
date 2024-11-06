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
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }

        private void submenu_barang_Click(object sender, EventArgs e)
        {
            FormBarang formBarang = new FormBarang();
            formBarang.MdiParent = this;
            formBarang.Show();
        }

        private void submenu_penjualan_Click(object sender, EventArgs e)
        {
            FormPenjualan formPenjualan = new FormPenjualan();
            formPenjualan.MdiParent = this;
            formPenjualan.Show();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void formlaporanbarang_Click(object sender, EventArgs e)
        {
            FormLaporan formLaporan = new FormLaporan();
            formLaporan.MdiParent = this;
            formLaporan.Show();
        }

        private void submenu_logout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var frmLogin = new FrmLogin(); // Form login yang akan dibuka
                frmLogin.Show(); // Menampilkan form login
                this.Close(); // Menutup form saat ini (MainForm)
            }
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSignUp formSignUp = new FormSignUp();
            formSignUp.MdiParent = this;
            formSignUp.Show();
        }
    }
}

