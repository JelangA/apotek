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
    public partial class ListObat : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;

        Koneksi koneksi = new Koneksi();

        public static string namaObat;
        public static string hargaObat;

        public static ListObat instance;

        string namaforms;

        public ListObat(string namaform)
        {
            InitializeComponent();
            instance = this;
            namaforms = namaform;
        }

        private void ListObat_Load(object sender, EventArgs e)
        {
            tampildata();
            namaObat = "";
            hargaObat = "";
        }

        void tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select nama_obat, expired_date, jumlah, harga from tbl_obat", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_obat");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_obat";
            }
            catch (Exception)
            {
                MessageBox.Show("data gagal");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (namaforms == "kasir")
            {
                FAKasir.instance.textBox6.Text = namaObat;
                //FAKasir.instance.textBox7.Text = hargaObat;
            }
            else if (namaforms == "resep")
            {
                FApoteker.instance.textBox4.Text = namaObat;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            namaObat = row.Cells["nama_obat"].Value.ToString();
            hargaObat = row.Cells["harga"].Value.ToString();
            labelNama.Text = row.Cells["nama_obat"].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(namaObat + " || " + hargaObat);
        }
    }
}
