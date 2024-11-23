using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Projek_UI
{
    public partial class FormBarang : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;



        public FormBarang()
        {
            alamat = "server=localhost; database=db_biscash; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

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
        private void Laporan_Click(object sender, EventArgs e)
        {
            
        }

        private void logout_Click(object sender, EventArgs e)
        {
            FormBarang formBarang = new FormBarang();
            formBarang.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txt_id_barang.Text = row.Cells["id_barang"].Value.ToString();
                txt_nama_barang.Text = row.Cells["nama_barang"].Value.ToString();
                txt_harga_beli.Text = row.Cells["harga_beli"].Value.ToString();
                txt_harga_jual.Text = row.Cells["harga_jual"].Value.ToString();
                txt_stock_barang.Text = row.Cells["stock_barang"].Value.ToString();
                cb_satuan.Text = row.Cells["satuan_barang"].Value.ToString();


                btn_save.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
                btn_clear.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nama_barang.Text != "" && txt_harga_beli.Text != "" && txt_harga_jual.Text != "" && txt_stock_barang.Text != "")
                {

                    query = string.Format("insert into tb_produk values ('{0}','{1}','{2}','{3}','{4}', '{5}');", txt_id_barang.Text, txt_nama_barang.Text, txt_harga_beli.Text, txt_harga_jual.Text, txt_stock_barang.Text, cb_satuan.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        FormBarang_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal inser Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (dataGridView1.SelectedRows.Count > 0)
                {
                
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                   
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        Console.WriteLine("Column Name: " + row.Cells[cell.ColumnIndex].OwningColumn.Name);
                    }

               
                    txt_id_barang.Text = row.Cells["id_barang"].Value.ToString();
                    txt_nama_barang.Text = row.Cells["nama_barang"].Value.ToString();
                    txt_harga_beli.Text = row.Cells["harga_beli"].Value.ToString();
                    txt_harga_jual.Text = row.Cells["harga_jual"].Value.ToString();
                    txt_stock_barang.Text = row.Cells["stock_barang"].Value.ToString();
                    cb_satuan.Text = row.Cells["satuan_barang"].Value.ToString();

               
                    btn_save.Enabled = false; 
                    btn_update.Enabled = true;
                    btn_delete.Enabled = true; 
                    btn_clear.Enabled = true;  
                }
                else
                {

                    MessageBox.Show("Silakan pilih data terlebih dahulu di DataGridView!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_barang.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("Delete from tb_produk where id_barang = '{0}'", txt_id_barang.Text);
                        ds.Clear();
                        koneksi.Open();
                        perintah = new MySqlCommand(query, koneksi);
                        adapter = new MySqlDataAdapter(perintah);
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();
                        if (res == 1)
                        {
                            MessageBox.Show("Delete Data Suksess ...");
                        }
                        else
                        {
                            MessageBox.Show("Gagal Delete data");
                        }
                    }
                    FormBarang_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            try
            {
                FormBarang_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nama_barang.Text != "" && txt_harga_beli.Text != "" && txt_harga_jual.Text != "" && txt_stock_barang.Text != "" && cb_satuan.Text != "")
                {
                    string query = "UPDATE tb_produk SET nama_barang = @nama_barang, harga_beli = @harga_beli, harga_jual = @harga_jual, stock_barang = @stock_barang, satuan_barang = @satuan_barang WHERE id_barang = @id_barang";

                    koneksi.Open();
                    using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                    {
                        perintah.Parameters.AddWithValue("@nama_barang", txt_nama_barang.Text);
                        perintah.Parameters.AddWithValue("@harga_beli", txt_harga_beli.Text);
                        perintah.Parameters.AddWithValue("@harga_jual", txt_harga_jual.Text);
                        perintah.Parameters.AddWithValue("@stock_barang", txt_stock_barang.Text);
                        perintah.Parameters.AddWithValue("@satuan_barang", cb_satuan.Text);
                        perintah.Parameters.AddWithValue("@id_barang", txt_id_barang.Text);

                        int res = perintah.ExecuteNonQuery();

                        if (res == 1)
                        {
                            MessageBox.Show("Update Data Sukses!");
                            FormBarang_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Gagal Update Data.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak Lengkap!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (koneksi.State == System.Data.ConnectionState.Open)
                {
                    koneksi.Close();
                }
            }
        }

        private void cb_satuan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_nama_barang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_nama_barang.Text = txt_nama_barang.Text.ToUpper();
                txt_nama_barang.SelectionStart = txt_nama_barang.Text.Length;

                if (!string.IsNullOrEmpty(txt_nama_barang.Text))
                {
                    query = string.Format("SELECT * FROM tb_produk WHERE nama_barang LIKE '{0}%' ORDER BY nama_barang ASC", txt_nama_barang.Text);

                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    adapter.Fill(ds);
                    koneksi.Close();

                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    FormBarang_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txt_id_barang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_id_barang.Text))
                {
                    query = string.Format("SELECT * FROM tb_produk WHERE id_barang LIKE '{0}%' ORDER BY id_barang ASC", txt_id_barang.Text);

                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    adapter.Fill(ds);
                    koneksi.Close();

                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    FormBarang_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void FormBarang_Load(object sender, EventArgs e)
        {
            try
            {
                if (koneksi.State == System.Data.ConnectionState.Open)
                {
                    koneksi.Close();
                }

                koneksi.Open(); 

                query = "SELECT * FROM tb_produk";
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close(); 

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Barang";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "Nama Barang";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "Harga Beli";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[3].HeaderText = "Harga Jual";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderText = "Stock";
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[5].HeaderText = "Satuan Barang";

                txt_id_barang.Clear();
                txt_nama_barang.Clear();
                txt_harga_jual.Clear();
                txt_harga_beli.Clear();
                txt_stock_barang.Clear();
                cb_satuan.ResetText();
                txt_id_barang.Focus();
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                btn_clear.Enabled = true;
                btn_save.Enabled = true;
                btn_search.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (koneksi.State == System.Data.ConnectionState.Open)
                {
                    koneksi.Close();
                }
            }
        }
    }
}