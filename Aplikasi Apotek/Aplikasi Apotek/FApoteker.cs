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
    public partial class FApoteker : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        Koneksi koneksi = new Koneksi();
        public FApoteker()
        {
            InitializeComponent();
        }
        private void FResep_Load(object sender, EventArgs e)
        {
            bersih();
            dataGridView1.Columns[0].Visible = false;
        }



        void bersih()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";

            Tampildata();
        }

        void Tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_resep", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_resep");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_resep";
            }
            catch (Exception x)
            {
                MessageBox.Show("gagal mendapat data {{ " + x.Message + " }}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBox1.TextLength != 0
                || textBox2.TextLength != 0
                || textBox3.TextLength != 0
                || textBox4.TextLength != 0
                || textBox5.TextLength != 0
               )
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("insert into `tbl_resep` (`no_resep`, `tgl_resep`, `nama_pasien`, `nama_dokter`, `obat_dibeli`, `jumlah_obatresep`) values ('" +
                        textBox1.Text + "','" +
                        dateTimePicker1.Value.ToString("dd/MM/yyyy") + "','" +
                        textBox2.Text + "','" +
                        textBox3.Text + "','" +
                        textBox4.Text + "','" +
                        textBox5.Text + "')", conn);
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
                || textBox5.TextLength != 0

               )
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("update `tbl_resep` set no_resep='" +
                        textBox1.Text + "',tgl_resep='" +
                        dateTimePicker1.Value.ToString("dd/MM/yyyy") + "',nama_pasien='" +
                        textBox2.Text + "',nama_dokter='" +
                        textBox3.Text + "',obat_dibeli='" +
                        textBox4.Text + "',jumlah_obatresep='" +
                        textBox5.Text + "' where id_resep='" + textBox6.Text + "'", conn);
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
                    cmd = new MySqlCommand("delete from tbl_resep where id_resep='" + textBox6.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Hapus");
                    bersih();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
                }
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            textBox2.Text = row.Cells[3].Value.ToString();
            textBox3.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
            textBox5.Text = row.Cells[6].Value.ToString();
            textBox6.Text = row.Cells[0].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_resep where nama_pasien like '%" + textBox7.Text + "%' or nama_dokter like '%" + textBox7.Text + "%'", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_resep");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_resep";
            }
            catch (Exception x)
            {
                MessageBox.Show("Pencarian gagal {{" + x.Message + "}}");
            }
            conn.Close();
        }
    }
}
