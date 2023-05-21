using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra
{
    internal class MysqlConnector
    {
        private static MysqlConnector _instance = new();

        internal static MysqlConnector Instance { get => _instance; }
        public MySqlConnection Conn { get => conn; }

        private string connection;
        private MySqlConnection conn;

        private MysqlConnector()
        {
            connection = "server=127.0.0.1;uid=root;pwd=;database=pva";
            conn = new MySqlConnection(connection);
        }

        public bool Connect()
        {
            try
            {
                conn.Open();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Disconnect()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MySqlDataReader GetData(string command)
        {
            var cmd = new MySqlCommand(command, conn);

            return cmd.ExecuteReader();
        }

        public void InsertData(string command)
        {
            var cmd = new MySqlCommand(command, conn);
            cmd.ExecuteNonQuery();
        }



    }
}
