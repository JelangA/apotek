using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplikasi_Apotek
{
    class Koneksi
    {
        public MySqlConnection getKon()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;username=root;password=;database=apotek;";
            return conn;
        }
    }
}
