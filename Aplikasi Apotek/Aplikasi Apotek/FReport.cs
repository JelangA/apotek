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
    public partial class FReport : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        Koneksi koneksi = new Koneksi();
        public FReport()
        {
            InitializeComponent();
        }

        private void FReport_Load(object sender, EventArgs e)
        {
            Tampildata();
        }

        void Tampildata()
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select tgl_transaksi, total_bayar from tbl_transaksi", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_transaksi");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_transaksi";
            }
            catch (Exception x)
            {
                MessageBox.Show("Data Gagal Di Tampilkan {{" + x.Message + "}}");
            }
            conn.Close();
        }

        public void LoadCharOmset()
        {
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("char data gagal di load");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select tgl_transaksi, total_bayar from tbl_transaksi", conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    this.chartOmset.Series["omset"].Points.AddXY(rd.GetString("tgl_transaksi"), rd.GetInt64("total_bayar"));
                }
                
            }
            catch (Exception x)
            {
                MessageBox.Show("Data Gagal Di Tampilkan {{" + x.Message + "}}");
            }
            conn.Close();
        }
    }
}
