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
            throw new NotImplementedException();
        }

        public bool Delete(string query)
        {
            throw new NotImplementedException();
        }

        public void Read(string query)
        {
            throw new NotImplementedException();
        }

        public bool Update(string query)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string query)
        {
            throw new NotImplementedException();
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