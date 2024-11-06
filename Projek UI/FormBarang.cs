using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            FormBarang formBarang = new FormBarang();
            formBarang.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                if (txt_nama_barang.Text != "")
                {
                    query = string.Format("select * from tb_produk where nama_barang = '{0}'", txt_nama_barang.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txt_id_barang.Text = kolom["id_barang"].ToString();
                            txt_harga_beli.Text = kolom["harga_beli"].ToString();
                            txt_harga_jual.Text = kolom["harga_jual"].ToString();
                            txt_stock_barang.Text = kolom["stock_barang"].ToString();
                            cb_satuan.Text = kolom["satuan_barang"].ToString();

                        }
                        txt_nama_barang.Enabled = true;
                        dataGridView1.DataSource = ds.Tables[0];
                        btn_save.Enabled = false;
                        btn_update.Enabled = true;
                        btn_delete.Enabled = true;
                        btn_search.Enabled = false;
                        btn_clear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        FormBarang_Load(null, null);
                    }

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

                    query = string.Format("update tb_produk set nama_barang = '{0}', harga_beli = '{1}', harga_jual = '{2}', stock_barang = '{3}', satuan_barang = '{4}', where id_barang = '{5}'", txt_nama_barang.Text, txt_harga_beli.Text, txt_harga_jual.Text, txt_stock_barang.Text, cb_satuan.Text, txt_id_barang.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Suksess ...");
                        FormBarang_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Update Data . . . ");
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

        private void cb_satuan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_nama_barang_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tb_produk");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
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
                btn_clear.Enabled = false;
                btn_save.Enabled = true;
                btn_search.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
