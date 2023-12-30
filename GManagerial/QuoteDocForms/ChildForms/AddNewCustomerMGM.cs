using GManagerial.CustomerMGM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    class AddNewCustomerMGM
    {
        private string connectionString;
        private ComboBox customerCB;
        public List<int> customerListID;
        public AddNewCustomerMGM(ComboBox customerCB)
        {
            //this.connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
            this.connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
            this.customerCB = customerCB;
            this.customerListID = new List<int>();
        }


        public void GetAllCustomers()
        {
            string query = "SELECT id_customer,name FROM customerTbl";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nome = reader["name"].ToString();
                    int id = reader.GetInt32(reader.GetOrdinal("id_customer"));
                    customerCB.Items.Add(nome);
                    customerListID.Add(id);
                }
            }

        }


        public int GetCustomerID()
        {
            return 0;
        }
    }
}
