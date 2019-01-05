using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MembershipLib
{

    public class SQLDataProvider : IDataProvider
    {
        private SqlConnection connection;

        public string stringConnection { get; set; }

        public SQLDataProvider(string _stringConnection)
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



        public bool Open()
        {
            this.connection = new SqlConnection(this.stringConnection);
            try
            {
                this.connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void Execute(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public DataTable ExecuteReturn(string query)
        {
            DataTable table = new DataTable();
            SqlDataAdapter cmd = new SqlDataAdapter(query, connection);
            cmd.Fill(table);
            return table;
        }

        public void Execute(string query, List<DbParameter> listParam)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            foreach (var item in listParam)
            {
                cmd.Parameters.Add(item);
            }
            cmd.ExecuteNonQuery();
        }

        public DataTable ExecuteReturn(string query, List<DbParameter> listParam)
        {
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand(query, connection);
            foreach (var item in listParam)
            {
                cmd.Parameters.Add(item);
            }
            SqlDataAdapter adpater = new SqlDataAdapter(cmd);
            adpater.Fill(table);
            return table;
        }


    }
}