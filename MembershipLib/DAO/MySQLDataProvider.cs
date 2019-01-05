using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipLib.DAO
{
    public class MySQLDataProvider : IDataProvider
    {

        private MySqlConnection connection;
        public string stringConnection
        {
            get; set;
        }

        public MySQLDataProvider(string _stringConnection)
        {
            this.stringConnection = _stringConnection;
        }

        public bool Close()
        {
            try
            {
                this.connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public void Execute(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

        }

        public void Execute(string query, List<DbParameter> listParam)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            foreach (var item in listParam)
            {
                cmd.Parameters.Add(item);
            }
            cmd.ExecuteNonQuery();
        }

        public DataTable ExecuteReturn(string query)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter cmd = new MySqlDataAdapter(query, connection);
            cmd.Fill(table);
            return table;
        }

        public DataTable ExecuteReturn(string query, List<DbParameter> listParam)
        {
            DataTable table = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            foreach (var item in listParam)
            {
                cmd.Parameters.Add(item);
            }
            MySqlDataAdapter adpater = new MySqlDataAdapter(cmd);
            adpater.Fill(table);
            return table;
        }

        public bool Open()
        {
            this.connection = new MySqlConnection(this.stringConnection);
            try
            {
                this.connection.Open();
                return true;
            }
            catch( Exception e)
            {
                return false;
            }
        }
    }
}
