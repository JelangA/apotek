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
    public partial class FAKasir : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        Koneksi koneksi = new Koneksi();

        public FAKasir()
        {
            InitializeComponent();
        }

        private void FAKasir_Load(object sender, EventArgs e)
        {
            bersih();
        }

        void Tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_ptransaksi", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_ptransaksi");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_ptransaksi";
            }
            catch (Exception x)
            {
                MessageBox.Show("Data Gagal Di Tampilkan {{" + x.Message + "}}");
            }
            conn.Close();
        }

        void bersih()
        {
            textBox1.Text = "Pilih Type";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            Tampildata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBox1.Text != "Pilih Type"
                || textBox2.Text.Length != 0
                || textBox4.Text.Length != 0
                || textBox5.Text.Length != 0
                || textBox6.Text.Length != 0
                || textBox7.Text.Length != 0
                || textBox8.Text.Length != 0
                )
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("insert into `tbl_ptransaksi`(`type_resep`, `no_resep`, `tgl_resep`, `nama_pasien`, `nama_dokter`, `nama_obat`, `harga`, `quantity`) values ('" +
                        textBox1.Text + "','" +
                        textBox2.Text + "','" +
                        textBox3.Value.ToString("dd/MM/yyyy") + "','" +
                        textBox4.Text + "','" +
                        textBox5.Text + "','" +
                        textBox6.Text + "','" +
                        textBox7.Text + "','" +
                        textBox8.Text + "')", conn);
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

        private void button8_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus Semua yang terdapat pada tabel data?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("delete from tbl_ptransaksi", conn);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus data?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("delete from tbl_ptransaksi where id_ptransaksi='" + textBox10.Text + "'", conn);
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
            textBox10.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox6.Text = row.Cells[6].Value.ToString();
            textBox7.Text = row.Cells[7].Value.ToString();
            textBox8.Text = row.Cells[8].Value.ToString();
        }
    }
}
