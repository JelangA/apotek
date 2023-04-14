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
    public partial class ListResep : Form
    {

        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;

        Koneksi koneksi = new Koneksi();

        public static string noResep, tgl_resep, nama_pasien, nama_dokter, obat_dibeli, jumlah_obat;

        public static ListResep instance;
        public ListResep()
        {
            InitializeComponent();
            instance = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ListResep_Load(object sender, EventArgs e)
        {
            tampildata();
        }

        void tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select no_resep, tgl_resep, nama_pasien, nama_dokter, obat_dibeli, jumlah_obatresep from tbl_resep", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_resep");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_resep";
            }
            catch (Exception)
            {
                MessageBox.Show("data gagal");
            }
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            noResep = row.Cells["no_resep"].Value.ToString();
            tgl_resep = row.Cells["tgl_resep"].Value.ToString();
            nama_pasien = row.Cells["nama_pasien"].Value.ToString();
            nama_dokter = row.Cells["nama_dokter"].Value.ToString();
            obat_dibeli = row.Cells["obat_dibeli"].Value.ToString();
            jumlah_obat = row.Cells["jumlah_obatresep"].Value.ToString();
            labelResep.Text = row.Cells["no_resep"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAKasir.instance.textBox2.Text = noResep;
            FAKasir.instance.textBox3.Text = tgl_resep;
            FAKasir.instance.textBox4.Text = nama_pasien;
            FAKasir.instance.textBox5.Text = nama_dokter;
            FAKasir.instance.textBox6.Text = obat_dibeli;
            FAKasir.instance.textBox8.Text = jumlah_obat;
        }

        private void labelNama_Click(object sender, EventArgs e)
        {

        }
    }
}
