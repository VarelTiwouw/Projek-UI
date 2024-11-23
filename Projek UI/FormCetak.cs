using MySql.Data.MySqlClient;
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
    public partial class FormCetak : Form
    {
        private int idTransaksi;
        public FormCetak(int idTransaksi)
        {
            InitializeComponent();
            this.idTransaksi = idTransaksi;
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {

                CrystalReportCetak report = new CrystalReportCetak();

                string connectionString = "server=localhost;user=root;database=db_biscash;password=;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM tb_transaksi INNER JOIN tb_detail_transaksi ON tb_transaksi.id_transaksi = tb_detail_transaksi.id_transaksi WHERE tb_transaksi.id_transaksi = @idTransaksi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idTransaksi", idTransaksi);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataSet dataSet = new DataSet();

                            dataSet.Clear();
                            adapter.Fill(dataSet, "tb_transaksi");

                            report.SetDataSource(dataSet);
                        }
                    }
                }

 
                crystalReportViewer1.ReportSource = null;
                crystalReportViewer1.ReportSource = report;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void FormCetak_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
