using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.DBConnectors
{
    internal interface IDBConnector
    {
        void Insert(SqlCommand commandy);
        SqlDataReader Load(SqlCommand command);

        SqlConnection GetConnectionObj();
        void Update(SqlCommand command);
        void Delete(SqlCommand command);  
        void Open();
        void Close();   
    }
}
