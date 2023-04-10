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
    public partial class FAdminNav : Form
    {
        private DataSet ds;
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        Koneksi koneksi = new Koneksi();

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childPanel.Controls.Add(childForm);
            childPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public FAdminNav()
        {
            InitializeComponent();
        }

        private void FAdminNav_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = koneksi.getKon();
            conn.Open();
            try
            {
                ds = new DataSet();
                cmd = new MySqlCommand("select * from tbl_log", conn);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "tbl_log");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tbl_log";
            }catch(Exception x)
            {
                MessageBox.Show("Data Gagal Ditampilkan{{" + x.Message + "}}");
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new FManageUser());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new FObat());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new FReport());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FLogin().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            } 
        }
    }
}
