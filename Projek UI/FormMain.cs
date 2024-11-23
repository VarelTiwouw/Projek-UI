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
        private Form activeForm = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void ShowForm(Form formToShow)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == formToShow.GetType())
                {
                    child.Show();
                    child.WindowState = FormWindowState.Maximized;
                    return;
                }
                child.Close(); 
            }

            formToShow.MdiParent = this;
            formToShow.WindowState = FormWindowState.Maximized;
            formToShow.Show();
        }

        private void MdiParent_SizeChanged(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.ClientSize = this.ClientSize; 
            }
        }

        private void submenu_barang_Click(object sender, EventArgs e)
        {
            ShowForm(new FormBarang());
        }

        private void submenu_penjualan_Click(object sender, EventArgs e)
        {
            ShowForm(new FormPenjualan());
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void formlaporanpenjualan_Click(object sender, EventArgs e)
        {
            ShowForm(new FormLaporanPenjualan());
        }

        private void submenu_logout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var frmLogin = new FrmLogin(); 
                frmLogin.Show(); 
                this.Close(); 
            }
        }
        private void btnLaporanPenjualan_Click(object sender, EventArgs e)
        {
            FormLaporanPenjualan laporanPenjualanForm = new FormLaporanPenjualan();
            laporanPenjualanForm.MdiParent = this;
            laporanPenjualanForm.Show();
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSignUp formSignUp = new FormSignUp();
            formSignUp.Show();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
    {
 
        child.WindowState = FormWindowState.Maximized;
    }
        }
    }
}

