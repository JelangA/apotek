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

        public int totalz;
        public double totalhasil;

        private string idUser;
        private string namaUser;

        private string Autoid()
        {
            try
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                cmd = new MySqlCommand("select no_transaksi from tbl_transaksi order by no_transaksi desc", conn);
                rd = cmd.ExecuteReader();
                rd.Read();
                if (rd.HasRows)
                {
                    string id = rd["no_transaksi"].ToString();
                    string angka = id.Substring(4, 4);
                    int num = Convert.ToInt32(angka) + 1;
                    string result = num.ToString();
                    if (result.Length == 1)
                    {
                        result = "000" + result;
                    }
                    else if (result.Length == 2)
                    {
                        result = "00" + result;
                    }
                    else if (result.Length == 3)
                    {
                        result = "0" + result;
                    }
                    else if (result.Length == 4)
                    {
                        result = "" + result;
                    }
                    string tanggal = DateTime.Now.ToString("ddMM");
                    string result2 = tanggal + result;
                    return result2;
                }
                else
                {
                    string result = "0001";
                    string tanggal = DateTime.Now.ToString("ddMM");
                    string result2 = tanggal + result;
                    return result2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }

        public static FAKasir instance;
        public FAKasir()
        {
            InitializeComponent();
            instance = this;
        }

        private void FAKasir_Load(object sender, EventArgs e)
        {
            bersih();
            getNamaUser();
        }

        void getNamaUser()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                cmd = new MySqlCommand("select id_user, nama_user from tbl_user where id_user ='" + FLogin.UserID + "'", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    idUser = rd[0].ToString();
                    namaUser = rd[1].ToString();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Auto id gagal {{ " + x.Message + " }} ");
            }
        }
        
        void Tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_ptransaksi order by id_ptransaksi desc", conn);
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
            label14.Text = Autoid();
        }

        public static void getObat(String namaObat, String hargaObat)
        {
            
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
                    cmd = new MySqlCommand("insert into `tbl_ptransaksi`(`type_resep`, `no_resep`, `tgl_resep`, `nama_pasien`, `nama_dokter`, `nama_obat`, `harga`, `quantity`, `no_transaksi`) values ('" +
                        textBox1.Text + "','" +
                        textBox2.Text + "','" +
                        textBox3.Value.ToString("dd/MM/yyyy") + "','" +
                        textBox4.Text + "','" +
                        textBox5.Text + "','" +
                        textBox6.Text + "','" +
                        textBox7.Text + "','" +
                        textBox8.Text + "','" +
                        Autoid() + "')", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Simpan");
                    if (totalhasil != 0)
                    {
                        totalz = (int)(totalhasil + (Convert.ToInt64(textBox7.Text) * Convert.ToInt64(textBox8.Text)));
                    }
                    else
                    {
                        totalz = (int)(Convert.ToInt64(textBox7.Text) * Convert.ToInt64(textBox8.Text));
                    }
                    labelTotal.Text = totalz.ToString();
                    totalhasil = (int)(Convert.ToInt64(labelTotal.Text));
                    bersih();

                }
                catch (Exception x)
                {
                    MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
                }
                conn.Close();
            }else{
                MessageBox.Show("Mohon Lengkapi Data");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            bersih();
            labelTotal.Text = "Total";
            labelKembali.Text = "Total Kembali";
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
                    labelKembali.Text = "";
                    labelTotal.Text = "";
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

        private void button6_Click(object sender, EventArgs e)
        {

        }
        //INSERT INTO `tbl_transaksi`(`id_transaksi`, `no_transaksi`, `tgl_transaksi`, `nama_kasir`, `total_bayar`, `id_user`, `id_obat`, `id_resep`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]','[value-8]')

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                cmd = new MySqlCommand("INSERT INTO `tbl_transaksi`(`no_transaksi`, `tgl_transaksi`, `nama_kasir`, `total_bayar`, `id_user`) VALUES ( '" + 
                   Autoid() + "','" + 
                   DateTime.Now.ToString("yyyy-MM-dd") + "','" +
                   namaUser +"','" +
                   totalz + "','" +
                   idUser + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di Simpan");
                totalz = 0;
                bersih();
            }
            catch (Exception x)
            {
                MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Autoid());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            labelKembali.Text = (Convert.ToInt64(textBox9.Text) - totalz).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FLogin().Show();

        }

        private void textBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Non Resep")
            {
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox8.Enabled = true;

                bersih();
            }
            else if (textBox1.Text == "Resep")
            {
                Resepbttn.Enabled = true;
                textBox8.Enabled = false;
                bersih();
            }
           
                
           
        }


        private void button9_Click(object sender, EventArgs e)
        {
            new ListObat("kasir").Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new ListResep().Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                cmd = new MySqlCommand("select harga from tbl_obat where nama_obat ='" + textBox6.Text + "'", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox7.Text = rd[0].ToString();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Auto id gagal {{ " + x.Message + " }} ");
            }
        }
    }
}
