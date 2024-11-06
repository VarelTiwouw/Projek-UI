using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projek_UI
{
    public partial class FormSearch : Form
    {
        public delegate void ItemSelectedHandler(string id_barang, string nama_barang, decimal harga_jual);
        public event ItemSelectedHandler OnItemSelected;

        private string connectionString = "Server=localhost;Database=db_biscash;User ID=root;Password=;SslMode=none;";
        public FormSearch()
        {
            InitializeComponent();
            LoadDataBarang();
        }

        private void FormSearchBarang_Load(object sender, EventArgs e)
        {

        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            if (dataGridViewBarang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewBarang.SelectedRows[0];
                string id_barang = selectedRow.Cells["id_barang"].Value.ToString();
                string nama_barang = selectedRow.Cells["nama_barang"].Value.ToString();
                decimal harga_jual = Convert.ToDecimal(selectedRow.Cells["harga_jual"].Value);

                // Mengirim data kembali ke FormUtama
                OnItemSelected?.Invoke(id_barang, nama_barang, harga_jual);

                // Menutup FormCariBarang setelah barang dipilih
                this.Close();
            }
            else
            {
                MessageBox.Show("Silakan pilih barang terlebih dahulu.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDataBarang()
        {
            string query = "SELECT id_barang, nama_barang, harga_jual FROM tb_produk";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewBarang.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message);
                }
            }
        }

    }
}
