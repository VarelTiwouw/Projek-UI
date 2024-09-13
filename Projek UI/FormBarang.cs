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
    public partial class FormBarang : Form
    {
        public FormBarang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPenjualan formPenjualan = new FormPenjualan();
            formPenjualan.Show();
            this.Hide();
        }

        private void Barang_Click(object sender, EventArgs e)
        {
            FormBarang formBarang = new FormBarang();
            formBarang.Show();
            this.Hide();
        }

        private void Statistik_Click(object sender, EventArgs e)
        {
            FormStatistik formStatistik = new FormStatistik();
            formStatistik.Show();
            this.Hide();
        }

        private void Laporan_Click(object sender, EventArgs e)
        {
            FormLaporan formLaporan = new FormLaporan();
            formLaporan.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
