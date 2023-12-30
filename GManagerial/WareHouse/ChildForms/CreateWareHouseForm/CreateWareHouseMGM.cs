using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.WareHouse
{
    class CreateWareHouseMGM
    {
        static private string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        //static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";



        static public void InsertMovement(string quantity, int product_id, int supplier_id)
        {
            string query = "INSERT INTO LOADSTOCKTBL(quantity, operation_date, Product_id, Supplier_id, Warehouse_id)" +
                "VALUES (@quantity, @operation_date, @Product_id, @Supplier_id, @Warehouse_id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int result;

                    if (int.TryParse(quantity, out result))
                    {
                        command.Parameters.AddWithValue("@quantity", quantity);
                    }

                    else
                    {
                        return;
                    }

                    command.Parameters.AddWithValue("@operation_date", DateTime.Now);
                    command.Parameters.AddWithValue("@Product_id", product_id);
                    command.Parameters.AddWithValue("@Supplier_id", supplier_id);
                    command.Parameters.AddWithValue("@Warehouse_id", 1);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
