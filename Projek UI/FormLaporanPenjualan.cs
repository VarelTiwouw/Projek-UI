using MySql.Data.MySqlClient;
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

namespace Projek_UI
{
    public partial class FormLaporanPenjualan : Form
    {
        public FormLaporanPenjualan()
        {
            InitializeComponent();
            this.Load += FormLaporanPenjualan_Load;
        }

        private void FormLaporanPenjualan_Load(object sender, EventArgs e)
        {
            
            InitializeDataGridView();
            LoadTransaksi();
        }

        private void InitializeDataGridView()
        {
            if (dataGridViewLaporanPenjualan.Columns["idTransaksi"] == null)
                dataGridViewLaporanPenjualan.Columns.Add("idTransaksi", "ID Transaksi");

            if (dataGridViewLaporanPenjualan.Columns["tanggalTransaksi"] == null)
                dataGridViewLaporanPenjualan.Columns.Add("tanggalTransaksi", "Tanggal Transaksi");

            if (dataGridViewLaporanPenjualan.Columns["totalHarga"] == null)
                dataGridViewLaporanPenjualan.Columns.Add("totalHarga", "Total Harga");

           
            if (dataGridViewLaporanPenjualan.Columns["btnCek"] == null)
            {
                DataGridViewButtonColumn btnCek = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi",
                    Name = "btnCek",
                    Text = "Cek",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewLaporanPenjualan.Columns.Add(btnCek);
            }

         
            dataGridViewLaporanPenjualan.CellClick += DataGridViewLaporanPenjualan_CellClick;
            dataGridViewLaporanPenjualan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadTransaksi()
        {
            dataGridViewLaporanPenjualan.Rows.Clear();

            string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_transaksi, tanggal_transaksi, total_harga FROM tb_transaksi";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewLaporanPenjualan.Rows.Add(
                                reader["id_transaksi"].ToString(),
                                Convert.ToDateTime(reader["tanggal_transaksi"]).ToString("dd-MM-yyyy"),
                                Convert.ToDecimal(reader["total_harga"]).ToString("C0", new CultureInfo("id-ID"))
                            );
                        }
                    }
                }
            }
        }

        private void DataGridViewLaporanPenjualan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewLaporanPenjualan.Columns["btnCek"].Index && e.RowIndex >= 0)
            {
                int idTransaksi = Convert.ToInt32(dataGridViewLaporanPenjualan.Rows[e.RowIndex].Cells["idTransaksi"].Value);

                FormDetailBarang formDetail = new FormDetailBarang(idTransaksi);
                formDetail.MdiParent = this.MdiParent;
                formDetail.Show();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerTanggal_ValueChanged(object sender, EventArgs e)
        {
            LoadTransaksi(dateTimePickerTanggal.Value);
        }

        private void LoadTransaksi(DateTime selectedDate)
        {
            dataGridViewLaporanPenjualan.Rows.Clear();

            string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_transaksi, tanggal_transaksi, total_harga FROM tb_transaksi WHERE DATE(tanggal_transaksi) = @selectedDate ORDER BY tanggal_transaksi DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"));
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridViewLaporanPenjualan.Rows.Add(
                                reader["id_transaksi"].ToString(),
                                Convert.ToDateTime(reader["tanggal_transaksi"]).ToString("dd-MM-yyyy"),
                                Convert.ToDecimal(reader["total_harga"]).ToString("C0", new CultureInfo("id-ID"))
                            );
                        }
                    }
                }
            }
        }

    }
}
