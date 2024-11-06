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
    public partial class FormPenjualanNew : Form
    {
        public FormPenjualanNew()
        {
            InitializeComponent();
        }

        private void txtKodeBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormPenjualanNew_Load(object sender, EventArgs e)
        {

        }

        private void txtNamaBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHargaBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJumlahBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubTotal_Enter(object sender, EventArgs e)
        {

        }

        private void txtTotal_Enter(object sender, EventArgs e)
        {

        }

        private void btnTambahBarang_Click(object sender, EventArgs e)
        {

        }

        private void dg_tabletransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKembalian_Enter(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtKodeBarang.Clear();
            txtNamaBarang.Clear();
            txtHargaBarang.Clear();
            txtJumlahBarang.Clear();
            
            
            txtBayar.Clear();
            

            dg_tabletransaksi.Rows.Clear();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FormSearch formSearch = new FormSearch();
            formSearch.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FormSearch formSearch = new FormSearch();
            formSearch.OnItemSelected += FormSearch_OnItemSelected;
            formSearch.ShowDialog();
        }

        private void FormSearch_OnItemSelected(string id_barang, string nama_barang, decimal harga_jual)
        {
            txtKodeBarang.Text = id_barang;
            txtNamaBarang.Text = nama_barang;
            txtHargaBarang.Text = harga_jual.ToString();
        }
    }
}
