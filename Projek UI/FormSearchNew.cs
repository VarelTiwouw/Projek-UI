using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Projek_UI
{
    public partial class FormSearchBarang : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private DataSet ds = new DataSet();
        private FormPenjualan formPenjualan;

        public FormSearchBarang(FormPenjualan formPenjualan)
        {
            InitializeComponent();
            this.formPenjualan = formPenjualan ?? throw new ArgumentNullException(nameof(formPenjualan), "FormPenjualan tidak boleh null.");
            string alamat = "server=localhost; database=db_biscash; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
        }

        private void FormSearchNew_Load(object sender, EventArgs e)
        {
            LoadData(""); 
        }
        private void LoadData(string keyword)
        {
            try
            {
                koneksi.Open();
                string query = "SELECT id_barang, nama_barang, harga_jual, stock_barang FROM tb_produk";

                
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " WHERE nama_barang LIKE @keyword";
                }

                MySqlCommand perintah = new MySqlCommand(query, koneksi);
                if (!string.IsNullOrEmpty(keyword))
                {
                    perintah.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                }

                adapter = new MySqlDataAdapter(perintah);
                ds.Clear();
                adapter.Fill(ds);
                dataGridViewBarang.DataSource = ds.Tables[0];

                dataGridViewBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


           
                dataGridViewBarang.Columns[0].Width = 100;
                dataGridViewBarang.Columns[0].HeaderText = "ID Barang";
                dataGridViewBarang.Columns[1].Width = 150;
                dataGridViewBarang.Columns[1].HeaderText = "Nama Barang";
                dataGridViewBarang.Columns[2].Width = 120;
                dataGridViewBarang.Columns[2].HeaderText = "Harga Jual";
                dataGridViewBarang.Columns[3].Width = 50;
                dataGridViewBarang.Columns[3].HeaderText = "Stok Barang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }
        private void txtCariBarang_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtCariBarang.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewBarang.SelectedRows.Count > 0)
            {           
                string id_barang = dataGridViewBarang.SelectedRows[0].Cells["id_barang"].Value?.ToString() ?? string.Empty;
                string nama_barang = dataGridViewBarang.SelectedRows[0].Cells["nama_barang"].Value?.ToString() ?? string.Empty;
                decimal harga_jual = Convert.ToDecimal(dataGridViewBarang.SelectedRows[0].Cells["harga_jual"].Value);
                decimal stock_barang = Convert.ToDecimal(dataGridViewBarang.SelectedRows[0].Cells["stock_barang"].Value);
             
                formPenjualan.SetBarang(id_barang, nama_barang, harga_jual, stock_barang);

                this.Close();
            }
            else
            {
                MessageBox.Show("Pilih barang terlebih dahulu.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnCariBarang_Click(object sender, EventArgs e)
        {
            LoadData(txtCariBarang.Text);
        }
    }
}
