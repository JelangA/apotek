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
    public partial class FObat : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        Koneksi koneksi = new Koneksi();
        public FObat()
        {
            InitializeComponent();
        }

        void bersih()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Tampildata();

        }

        void Tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_obat", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_obat");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_obat";
            }
            catch (Exception x)
            {
                MessageBox.Show("Data Gagal Di Tampilkan {{" + x.Message + "}}");
            }
            conn.Close();
        }
        private void FObat_Load(object sender, EventArgs e)
        {
            Tampildata();
            bersih();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBox1.TextLength != 0
                || textBox2.TextLength != 0
                || textBox3.TextLength != 0
                || textBox4.TextLength != 0
                )
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("INSERT INTO `tbl_obat`(`kode_obat`, `nama_obat`, `expired_date`, `jumlah`, `harga`) VALUES ('" +
                        textBox1.Text + "','" +
                        textBox2.Text + "','" +
                        dateTimePicker1.Value.ToString() + "','" +
                        textBox3.Text + "','" +
                        textBox4.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Simpan");
                    bersih();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Mohon Lengkapi Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (
                textBox1.TextLength != 0
                || textBox2.TextLength != 0
                || textBox3.TextLength != 0
                || textBox4.TextLength != 0
               )
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("update `tbl_obat` set kode_obat='" +
                        textBox1.Text + "',nama_obat='" +
                        textBox2.Text + "',expired_date='" +
                        dateTimePicker1.Value.ToString() + "',jumlah='" +
                        textBox3.Text + "',harga='" +
                        textBox4.Text + "' where id_user='" + textBox5.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Simpan");
                    bersih();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Mohon Lengkapi Data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus data?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("delete from tbl_obat where id_obat='" + textBox5.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Hapus");
                    bersih();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Data Gagal DiHapus {{" + x.Message + "}}");
                }
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
            textBox5.Text = row.Cells[0].Value.ToString();
            dateTimePicker1.Text = row.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    ds = new DataSet();
                    cmd = new MySqlCommand("select * from tbl_obat where nama_obat like '%" + textBox6.Text + "%'", conn);
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(ds, "tbl_obat");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "tbl_obat";
                }
                catch (Exception x)
                {
                    MessageBox.Show("Pencarian gagal {{" + x.Message + "}}");
                }
                conn.Close();
        }
    }
}
