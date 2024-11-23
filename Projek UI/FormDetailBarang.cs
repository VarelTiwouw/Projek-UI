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
    public partial class FormDetailBarang : Form
    {
        private int idTransaksi;

        public FormDetailBarang(int idTransaksi)
        {
            InitializeComponent();
            this.idTransaksi = idTransaksi;
            this.Load += FormDetailBarang_Load;
        }

        private void FormDetailBarang_Load(object sender, EventArgs e)
        {
            
            InitializeDataGridView();
            LoadDetailBarang();
        }

        private void InitializeDataGridView()
        {
            if (dataGridViewDetailBarang.Columns["idBarang"] == null)
                dataGridViewDetailBarang.Columns.Add("idBarang", "ID Barang");
            if (dataGridViewDetailBarang.Columns["namaBarang"] == null)
                dataGridViewDetailBarang.Columns.Add("namaBarang", "Nama Barang");
            if (dataGridViewDetailBarang.Columns["hargaBarang"] == null)
                dataGridViewDetailBarang.Columns.Add("hargaBarang", "Harga Barang");
            if (dataGridViewDetailBarang.Columns["jumlah"] == null)
                dataGridViewDetailBarang.Columns.Add("jumlah", "Jumlah");
            if (dataGridViewDetailBarang.Columns["subtotal"] == null)
                dataGridViewDetailBarang.Columns.Add("subtotal", "Subtotal");

            dataGridViewDetailBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDetailBarang()
        {
            string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT tb_produk.id_barang, tb_produk.nama_barang, tb_produk.harga_jual, " +
                               "tb_detail_transaksi.jumlah, tb_detail_transaksi.subtotal " +
                               "FROM tb_detail_transaksi " +
                               "JOIN tb_produk ON tb_detail_transaksi.id_barang = tb_produk.id_barang " +
                               "WHERE tb_detail_transaksi.id_transaksi = @idTransaksi";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idTransaksi", idTransaksi);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        dataGridViewDetailBarang.Rows.Clear();

                        while (reader.Read())
                        {
                           
                            dataGridViewDetailBarang.Rows.Add(
                                reader["id_barang"].ToString(),
                                reader["nama_barang"].ToString(),
                                Convert.ToDecimal(reader["harga_jual"]).ToString("C0", new CultureInfo("id-ID")),
                                Convert.ToInt32(reader["jumlah"]),
                                Convert.ToDecimal(reader["subtotal"]).ToString("C0", new CultureInfo("id-ID"))
                            );
                        }
                    }
                }
            }

           
            HitungTotalHarga();
        }

        private void HitungTotalHarga()
        {
            decimal totalHarga = 0;

          
            foreach (DataGridViewRow row in dataGridViewDetailBarang.Rows)
            {
                if (row.Cells["subtotal"].Value != null)
                {
            
                    decimal subtotal;
                    bool isValid = decimal.TryParse(row.Cells["subtotal"].Value.ToString(), NumberStyles.Currency, new CultureInfo("id-ID"), out subtotal);

                    if (isValid)
                    {
                        totalHarga += subtotal;
                    }
                    else
                    {

                        Console.WriteLine("Invalid subtotal format: " + row.Cells["subtotal"].Value);
                    }
                }
            }

        
            lbl_total.Text = "Total: " + totalHarga.ToString("C0", new CultureInfo("id-ID"));
        }
        private void dataGridViewDetailBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_kembali_Click(object sender, EventArgs e)
        {
            FormLaporanPenjualan formLaporanPenjualan = null;

          
            foreach (Form frm in this.MdiParent.MdiChildren)
            {
                if (frm is FormLaporanPenjualan)
                {
                    formLaporanPenjualan = (FormLaporanPenjualan)frm;
                    break;
                }
            }

         
            if (formLaporanPenjualan == null)
            {
                formLaporanPenjualan = new FormLaporanPenjualan();
                formLaporanPenjualan.MdiParent = this.MdiParent;  
                formLaporanPenjualan.Show();
            }
            else
            {
       
                formLaporanPenjualan.Activate();
            }
        }

        private void lbl_total_Click(object sender, EventArgs e)
        {

        }

        private void FormDetailBarang_Load_1(object sender, EventArgs e)
        {

        }
    }
}
