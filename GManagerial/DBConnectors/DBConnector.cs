using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.DBConnectors
{
    internal class DBConnector:IDBConnector
    {
        SqlConnection _connection;
        public DBConnector(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnectionObj()
        {
            return _connection;
        }

        public void Insert(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }

        public SqlDataReader Load(SqlCommand command)
        {
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void Update(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }

        public void Delete(SqlCommand command) 
        {
            command.ExecuteNonQuery();
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close() 
        {
            _connection.Close();   
        }


    }
}
