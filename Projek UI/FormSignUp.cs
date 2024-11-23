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
    public partial class FormSignUp : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormSignUp()
        {
            alamat = "server=localhost; database=db_biscash; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=db_biscash;Uid=root;Pwd=;";
            MySqlConnection koneksi = new MySqlConnection(connectionString);

            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    koneksi.Open();
                    string query = "INSERT INTO tb_user (username, password) VALUES (@username, @password)";

                    using (MySqlCommand perintah = new MySqlCommand(query, koneksi))
                    {
                        perintah.Parameters.AddWithValue("@username", txtUsername.Text);
                        perintah.Parameters.AddWithValue("@password", txtPassword.Text);

                        int res = perintah.ExecuteNonQuery();

                        if (res == 1)
                        {
                            MessageBox.Show("Insert Data Sukses!");
                            FormSignUp_Load(null, null); 

                            
                            FrmLogin frmLogin = Application.OpenForms["FrmLogin"] as FrmLogin;
                            if (frmLogin == null)
                            {
                                frmLogin = new FrmLogin(); 
                                frmLogin.Show();
                            }

                            
                            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                            {
                                Form openForm = Application.OpenForms[i];
                                if (openForm != this && openForm != frmLogin)
                                {
                                    openForm.Close();
                                }
                            }

                            
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Gagal insert Data.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Data tidak lengkap!");
            }
        }
    }   
}
