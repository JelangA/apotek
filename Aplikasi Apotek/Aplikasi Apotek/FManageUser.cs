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
    public partial class FManageUser : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        Koneksi koneksi = new Koneksi();
        public FManageUser()
        {
            InitializeComponent();
        }

        void bersih()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "pilih";
            Tampildata();
        }

        void Tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_user", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_user");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_user";
            }
            catch (Exception x)
            {
                MessageBox.Show("Data Gagal Di Tampilkan {{" + x.Message + "}}");
            }
            conn.Close();
        }

        //void TampilCmb()
        //{
        //    MySqlConnection conn = koneksi.getKon();
        //    conn.Open();
        //    try
        //    {
        //        ds = new DataSet();
        //        cmd = new MySqlCommand("select {{Data}} from tbl_user", conn);
        //        rd = cmd.ExecuteReader();
        //        while(rd.Read()){
        //            comboBox1.Items.Add(rd[0].ToString());
        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        MessageBox.Show("ComboBox Gagal Di Tambahkan {{" + x.Message + "}}");
        //    }
        //    rd.Close();
        //    conn.Close();
        //}

        private void FManageUser_Load(object sender, EventArgs e)
        {
            bersih();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBox1.TextLength != 0
                || textBox2.TextLength != 0
                || textBox3.TextLength != 0
                || textBox4.TextLength != 0
                || textBox5.TextLength != 0
                || textBox6.TextLength != 0
               )
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("insert into `tbl_user` (`type_user`, `nama_user`, `alamat`, `telpon`, `username`, `password`) values ('" +
                        comboBox1.Text + "','" +
                        textBox1.Text + "','" +
                        textBox3.Text + "','" +
                        textBox2.Text + "','" +
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
                || textBox6.TextLength != 0
               )
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("update `tbl_user` set type_user='" +
                        comboBox1.Text + "',nama_user='" +
                        textBox1.Text + "',alamat='" +
                        textBox3.Text + "',telpon='" +
                        textBox2.Text + "',username='" +
                        textBox4.Text + "',password='" +
                        textBox5.Text + "' where id_user='" + textBox7.Text + "'", conn);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox7.Text = row.Cells[0].Value.ToString();
            comboBox1.Text = row.Cells[1].Value.ToString();
            textBox1.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox2.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
            textBox5.Text = row.Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hapus data?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlConnection conn = koneksi.getKon();
                conn.Open();
                try
                {
                    cmd = new MySqlCommand("delete from tbl_user where id_user='" + textBox7.Text + "'", conn);
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_user where nama_user like '%" + textBox6.Text + "%'", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_user");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_user";
            }
            catch (Exception x)
            {
                MessageBox.Show("Data Gagal Di Tampilkan {{" + x.Message + "}}");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
