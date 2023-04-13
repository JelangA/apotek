using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplikasi_Apotek
{
    
   
    class kodok
    {
        //===============================  Var

        //private DataSet ds;
        //private MySqlCommand cmd;
        //private MySqlDataAdapter da;
        //private MySqlDataReader rd;
        //Koneksi koneksi = new Koneksi();




        //===============================  bersih

        //void bersih()
        //{
        //    textBox1.Text = "";
        //    textBox2.Text = "";
        //    textBox3.Text = "";
        //    textBox4.Text = "";
        //    textBox5.Text = "";
        //    textBox6.Text = "";
        //    textBox7.Text = "";
        //    comboBox1.Text = "pilih";
        //    Tampildata();
        //}



        //===============================  tampil

        //void Tampildata()
        //{
        //    MySqlConnection conn = koneksi.getKon();
        //    conn.Open();
        //    try
        //    {
        //        ds = new DataSet();
        //        cmd = new MySqlCommand("select * from tbl_", conn);
        //        da = new MySqlDataAdapter(cmd);
        //        da.Fill(ds, "tbl_");
        //        dataGridView1.DataSource = ds;
        //        dataGridView1.DataMember = "tbl_";
        //    }
        //    catch (Exception x)
        //    {
        //        MessageBox.Show("Data Gagal Di Tampilkan {{" + x.Message + "}}");
        //    }
        //    conn.Close();
        //}



        //===============================  cmb

        //void TampilCmb()
        //{
        //    MySqlConnection conn = koneksi.getKon();
        //    conn.Open();
        //    try
        //    {
        //        ds = new DataSet();
        //        cmd = new MySqlCommand("select {{Data}} from tbl_{tabel}", conn);
        //        rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
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



        //==================================  Insert

        //void inserdata()
        //{
        //            if (
        //                textBox1.TextLength != 0
        //                || textBox2.TextLength != 0
        //                || textBox3.TextLength != 0
        //                || textBox4.TextLength != 0
        //                || textBox5.TextLength != 0
        //                || textBox6.TextLength != 0
        //               )
        //            {
        //                MySqlConnection conn = koneksi.getKon();
        //                conn.Open();
        //                try
        //                {
        //                    cmd = new MySqlCommand("insert into `tbl_user` (`type_user`, `nama_user`, `alamat`, `telpon`, `username`, `password`) values ('" +
        //                        comboBox1.Text + "','" +
        //                        textBox1.Text + "','" +
        //                        textBox2.Text + "','" +
        //                        textBox3.Text + "','" +
        //                        textBox4.Text + "','" +
        //                        textBox5.Text + "')", conn);
        //                    cmd.ExecuteNonQuery();
        //                    MessageBox.Show("Data Berhasil Di Simpan");
        //                    bersih();
        //                }
        //                catch (Exception x)
        //                {
        //                    MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
        //                }
        //                conn.Close();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Mohon Lengkapi Data");
        //            }
        //}



        //==================================  Update

        //void update()
        //{
        //    if (
        //        textBox1.TextLength != 0
        //        || textBox2.TextLength != 0
        //        || textBox3.TextLength != 0
        //        || textBox4.TextLength != 0
        //        || textBox5.TextLength != 0
        //        || textBox6.TextLength != 0
        //       )
        //    {
        //        MySqlConnection conn = koneksi.getKon();
        //        conn.Open();
        //        try
        //        {
        //            cmd = new MySqlCommand("update `tbl_user` set type_user='" +
        //                comboBox1.Text + "',nama_user='" +
        //                textBox1.Text + "',alamat='" +
        //                textBox2.Text + "',telpon='" +
        //                textBox3.Text + "',username='" +
        //                textBox4.Text + "',password='" +
        //                textBox5.Text + "' where id_user='" + textBox7.Text + "'", conn);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Data Berhasil Di Simpan");
        //            bersih();
        //        }
        //        catch (Exception x)
        //        {
        //            MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
        //        }
        //        conn.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Mohon Lengkapi Data");
        //    }
        //}


        //====================================  delete

        //void delete()
        //{
        //        if (MessageBox.Show("Hapus data?", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            MySqlConnection conn = koneksi.getKon();
        //            conn.Open();
        //            try
        //            {
        //                cmd = new MySqlCommand("delete from tbl_user where id_user='" + textBox7.Text + "'", conn);
        //                cmd.ExecuteNonQuery();
        //                MessageBox.Show("Data Berhasil Di Hapus");
        //                bersih();
        //            }
        //            catch (Exception x)
        //            {
        //                MessageBox.Show("Data Gagal Ditambahakan {{" + x.Message + "}}");
        //            }
        //            conn.Close();
        //        }
        //}

        //=====================================  data clixk

        //DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
        //textBox7.Text = row.Cells[0].Value.ToString();
        //    comboBox1.Text = row.Cells[1].Value.ToString();
        //    textBox1.Text = row.Cells[2].Value.ToString();
        //    textBox2.Text = row.Cells[3].Value.ToString();
        //    textBox3.Text = row.Cells[4].Value.ToString();
        //    textBox4.Text = row.Cells[5].Value.ToString();
        //    textBox5.Text = row.Cells[6].Value.ToString();




        //====================================== pencarian

        //void cari()
        //{
        //    MySqlConnection conn = koneksi.getKon();
        //    conn.Open();
        //    try
        //    {
        //        ds = new DataSet();
        //        cmd = new MySqlCommand("select * from tbl_user where nama_user like '%" + textBox6.Text + "%'", conn);
        //        da = new MySqlDataAdapter(cmd);
        //        da.Fill(ds, "tbl_user");
        //        dataGridView1.DataSource = ds;
        //        dataGridView1.DataMember = "tbl_user";
        //    }
        //    catch (Exception x)
        //    {
        //        MessageBox.Show("Pencarian gagal {{" + x.Message + "}}");
        //    }
        //    conn.Close();
        //}

    }
}
