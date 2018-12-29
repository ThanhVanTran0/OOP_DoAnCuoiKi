using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Do_An_SEP
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

        public void Execute(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        public bool Open()
        {
            this.connection = new SqlConnection(this.stringConnection);
            try
            {
                this.connection.Open(); 
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}