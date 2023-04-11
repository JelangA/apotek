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

namespace Aplikasi_Apotek
{
    public partial class FLogin : Form
    {
        private MySqlCommand cmd;
        private MySqlDataReader rd;

        Koneksi koneksi = new Koneksi();

        public static string UserID;
        public FLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                cmd = new MySqlCommand("select * from tbl_user where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", conn);
                rd = cmd.ExecuteReader();
                rd.Read();

                if (rd.HasRows)
                {
                    if (rd[1].ToString() == "Admin")
                    {
                        this.Hide();
                        UserID = rd[0].ToString();
                        new FAdminNav().Show();
                    }
                    else if (rd[1].ToString() == "Apoteker")
                    {
                        this.Hide();
                        UserID = rd[1].ToString();
                        new FApoteker().Show();
                    }
                    else if (rd[1].ToString() == "Kasir")
                    {
                        this.Hide();
                        UserID = rd[0].ToString();
                        new FAKasir().Show();
                    }
                    else
                    {
                        MessageBox.Show("username atau password Salah");
                    }

                }
                else
                {
                    MessageBox.Show("tidak ditemukan");
                }
                rd.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("gagal");
            }
            conn.Close();
        }
    }
}
