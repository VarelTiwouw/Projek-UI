using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Projek_UI
{
    public partial class FormPenjualan : Form
    {
        public FormPenjualan()
        {
            InitializeComponent();
            this.Load += FormPenjualan_Load;
        }
        private void FormPenjualan_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dataGridViewPenjualan.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewPenjualan.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewPenjualan.Columns.Add("HargaBarang", "Harga Barang");
            dataGridViewPenjualan.Columns.Add("JumlahBarang", "Jumlah Barang");
            dataGridViewPenjualan.Columns.Add("TotalHarga", "Total Harga");

            DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn
            {
                HeaderText = "Hapus",
                Name = "btnHapus",
                Text = "Hapus",
                UseColumnTextForButtonValue = true
            };
            dataGridViewPenjualan.Columns.Add(btnHapus);

            dataGridViewPenjualan.Columns["KodeBarang"].Width = 100;
            dataGridViewPenjualan.Columns["NamaBarang"].Width = 150;
            dataGridViewPenjualan.Columns["HargaBarang"].Width = 120;
            dataGridViewPenjualan.Columns["JumlahBarang"].Width = 100;
            dataGridViewPenjualan.Columns["TotalHarga"].Width = 120;
            dataGridViewPenjualan.Columns["btnHapus"].Width = 80;

            dataGridViewPenjualan.CellClick += dataGridViewPenjualan_CellClick;
            dataGridViewPenjualan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void SetBarang(string id_barang, string nama_barang, decimal harga_jual, decimal stock_barang)
        {
            txtKodeBarang.Text = id_barang;
            txtNamaBarang.Text = nama_barang;
            txtHargaBarang.Text = harga_jual.ToString("C0", new CultureInfo("id-ID"));
            txtStokBarang.Text = stock_barang.ToString();

        }
        private void btnTambahBarang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKodeBarang.Text) || string.IsNullOrEmpty(txtJumlahBarang.Text))
            {
                MessageBox.Show("Pastikan kode barang dan jumlah telah diisi.");
                return;
            }

            if (int.TryParse(txtJumlahBarang.Text, out int jumlahBarang) &&
                decimal.TryParse(txtHargaBarang.Text, NumberStyles.Currency, new CultureInfo("id-ID"), out decimal hargaJual))
            {
                decimal totalHarga = jumlahBarang * hargaJual;
                dataGridViewPenjualan.Rows.Add(txtKodeBarang.Text, txtNamaBarang.Text, hargaJual, jumlahBarang, totalHarga);

                UpdateStockInDatabase(txtKodeBarang.Text, jumlahBarang);

                ClearTextFields();

                UpdateSubTotal();
            }
            else
            {
                MessageBox.Show("Jumlah atau harga tidak valid.");
            }
        }

    
        private void UpdateStockInDatabase(string kodeBarang, int jumlahDibeli)
        {
            string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE tb_produk SET stock_barang = stock_barang - @jumlahDibeli WHERE id_barang = @kodeBarang";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jumlahDibeli", jumlahDibeli);
                    cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void dataGridViewPenjualan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPenjualan.Columns["btnHapus"].Index && e.RowIndex >= 0)
            {
                try
                {
                    string kodeBarang = dataGridViewPenjualan.Rows[e.RowIndex].Cells["KodeBarang"].Value.ToString();
                    int jumlahDibeli = int.Parse(dataGridViewPenjualan.Rows[e.RowIndex].Cells["JumlahBarang"].Value.ToString());

                    RestoreStockInDatabase(kodeBarang, jumlahDibeli);

                    dataGridViewPenjualan.Rows.RemoveAt(e.RowIndex);

                    UpdateSubTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat menghapus barang: " + ex.Message);
                }
            }
        }


        private void RestoreStockInDatabase(string kodeBarang, int jumlahDikembalikan)
        {
            string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE tb_produk SET stock_barang = stock_barang + @jumlahDikembalikan WHERE id_barang = @kodeBarang";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jumlahDikembalikan", jumlahDikembalikan);
                    cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void UpdateSubTotal()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dataGridViewPenjualan.Rows)
            {
                subTotal += Convert.ToDecimal(row.Cells["TotalHarga"].Value);
            }
            lblSubTotal.Text = subTotal.ToString("C0", new CultureInfo("id-ID"));
        }


        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            UpdateKembalian();
        }
        private void UpdateKembalian()
        {
            if (decimal.TryParse(txtBayar.Text, NumberStyles.Currency, new CultureInfo("id-ID"), out decimal bayar) &&
        decimal.TryParse(lblSubTotal.Text, NumberStyles.Currency, new CultureInfo("id-ID"), out decimal subTotal))
            {
                decimal kembalian = bayar - subTotal;
                lblKembalian.Text = kembalian >= 0 ? kembalian.ToString("C0", new CultureInfo("id-ID")) : "Rp0";
            }
            else
            {
                lblKembalian.Text = "Rp0";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearTextFields();
            lblKembalian.Text = "Rp0";
            lblSubTotal.Text = "Rp0";
            dataGridViewPenjualan.Rows.Clear();
        }
        private void ClearTextFields()
        {
            txtKodeBarang.Clear();
            txtNamaBarang.Clear();
            txtHargaBarang.Clear();
            txtJumlahBarang.Clear();
            txtBayar.Clear();
            txtStokBarang.Clear();
        }

        private void FormSearch_OnItemSelected(string id_barang, string nama_barang, decimal harga_jual)
        {
            txtKodeBarang.Text = id_barang;
            txtNamaBarang.Text = nama_barang;
            txtHargaBarang.Text = harga_jual.ToString();
        }

        private void lblKembalian_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtBayar.Text, out decimal bayar) && decimal.TryParse(lblSubTotal.Text, out decimal subTotal))
            {
                decimal kembalian = bayar - subTotal;
                lblKembalian.Text = kembalian.ToString("C0", new CultureInfo("id-ID"));
            }
        }

        private void SaveDetailTransaksi(int idTransaksi)
        {
            string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                foreach (DataGridViewRow row in dataGridViewPenjualan.Rows)
                {
                    if (row.IsNewRow) continue;

                    string kodeBarang = row.Cells["KodeBarang"].Value.ToString();
                    int jumlahBarang = Convert.ToInt32(row.Cells["JumlahBarang"].Value);
                    decimal hargaBarang = Convert.ToDecimal(row.Cells["HargaBarang"].Value);
                    decimal subtotal = jumlahBarang * hargaBarang;

                    string checkQuery = "SELECT COUNT(*) FROM tb_detail_transaksi WHERE id_transaksi = @idTransaksi AND id_barang = @kodeBarang";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@idTransaksi", idTransaksi);
                        checkCmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count == 0)
                        {

                            string insertQuery = "INSERT INTO tb_detail_transaksi (id_transaksi, id_barang, jumlah, subtotal) " +
                                                 "VALUES (@idTransaksi, @kodeBarang, @jumlah, @subtotal)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@idTransaksi", idTransaksi);
                                insertCmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                                insertCmd.Parameters.AddWithValue("@jumlah", jumlahBarang);
                                insertCmd.Parameters.AddWithValue("@subtotal", subtotal);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }







        private void btnSearch2_Click(object sender, EventArgs e)
        {
            FormSearchBarang formSearch = new FormSearchBarang(this);
            formSearch.Show();
        }
        private void dg_tabletransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            int idTransaksi = InsertTransaksi();

   
            SaveDetailTransaksi(idTransaksi);

            FormCetak formCetak = new FormCetak(idTransaksi);
            formCetak.Show();

        }

        private int InsertTransaksi()
        {
            int idTransaksi = 0;
            decimal totalHarga;

            if (!decimal.TryParse(lblSubTotal.Text, NumberStyles.Currency, new CultureInfo("id-ID"), out totalHarga))
            {
                MessageBox.Show("Format subtotal tidak valid.", "Kesalahan");
                return 0;
            }

            DateTime tanggalTransaksi = DateTime.Now;
            string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT id_transaksi FROM tb_transaksi WHERE tanggal_transaksi = @tanggal AND total_harga = @totalHarga";
                using (MySqlCommand checkCmd = new MySqlCommand(query, conn))
                {
                    checkCmd.Parameters.AddWithValue("@tanggal", tanggalTransaksi);
                    checkCmd.Parameters.AddWithValue("@totalHarga", totalHarga);
                    object result = checkCmd.ExecuteScalar();

                    if (result == null) 
                    {
                        string insertQuery = "INSERT INTO tb_transaksi (tanggal_transaksi, total_harga) VALUES (@tanggal, @totalHarga)";
                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@tanggal", tanggalTransaksi);
                            cmd.Parameters.AddWithValue("@totalHarga", totalHarga);
                            cmd.ExecuteNonQuery();
                            idTransaksi = (int)cmd.LastInsertedId;
                        }
                    }
                    else
                    {
                        idTransaksi = Convert.ToInt32(result); 
                    }
                }
            }
            return idTransaksi;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        private void txtKembalian_Enter(object sender, EventArgs e)
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
        private void txtKodeBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_kodetransaksi_Click(object sender, EventArgs e)
        {

        }

        private void FormPenjualan_Load_1(object sender, EventArgs e)
        {

        }
    }
}
