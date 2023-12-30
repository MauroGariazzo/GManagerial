using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;
using GManagerial.WareHouse.ChildForms;

namespace GManagerial.WareHouse
{
    class WareHouseProductMGM
    {
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
         //static private string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static public void LoadWareHouse(int idWareHouse, DataGridView WareHouseDGV)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT P.Product_id, P.Product_Name, wp.supplier_id, S.Company_Name, stock, minimum_stock FROM WAREHOUSEPRODUCT wp " +
                "JOIN PRODUCTSTBL P ON WP.Product_ID = P.Product_ID " +
                "JOIN SuppliersTbl S ON WP.Supplier_id = S.Supplier_ID WHERE WareHouse_ID = " + idWareHouse;

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                bool checkBoxColumnExists = false;
                foreach (DataGridViewColumn column in WareHouseDGV.Columns)
                {
                    if (column.Name == "chkColumn")
                    {
                        checkBoxColumnExists = true;
                        break;
                    }
                }

                if (!checkBoxColumnExists)
                {
                    DataGridViewCheckBoxColumn checkBoxDataGridViewColumn = new DataGridViewCheckBoxColumn();
                    checkBoxDataGridViewColumn.Name = "chkColumn";
                    checkBoxDataGridViewColumn.HeaderText = "";
                    WareHouseDGV.Columns.Insert(0, checkBoxDataGridViewColumn);
                }

                WareHouseDGV.DataSource = dataTable;

                WareHouseDGV.AutoGenerateColumns = false;
            }
        }

        //stock -> giacenza , min_stock -> minimo di scorta
        static public void LoadMerchInWareHouseDB(int product_id, int supplier_id, int stock, int warehouse_id, 
            string um, char nec, int min_stock = 0) 
        {
            string query = "";
            if (nec == 'n')
            {
                query = "INSERT INTO WAREHOUSEPRODUCT(Product_id, Supplier_id, stock, WareHouse_ID, um)" +
                    "VALUES(@Product_id, @Supplier_id, @stock, @WareHouse_ID, @um)";
            }

            else
            {
                query = "UPDATE WAREHOUSEPRODUCT SET STOCK = STOCK + @stock, um = @um " +
                    "WHERE Product_id = @Product_id AND Supplier_id = @Supplier_id AND WareHouse_ID = @WareHouse_ID";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_id", product_id);
                    command.Parameters.AddWithValue("@Supplier_id", supplier_id);
                    command.Parameters.AddWithValue("@WareHouse_ID", warehouse_id);
                    command.Parameters.AddWithValue("@stock", stock);               
                   // command.Parameters.AddWithValue("@minimum_stock", min_stock);
                    command.Parameters.AddWithValue("@um", um);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        static public Boolean checkIfProductExist(int product_id, int supplier_id, int warehouse_id)
        {
            string query = "SELECT * FROM WAREHOUSEPRODUCT WHERE PRODUCT_ID = @PRODUCT_ID AND SUPPLIER_ID = @SUPPLIER_ID AND WAREHOUSE_ID = @WAREHOUSE_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", product_id);
                    command.Parameters.AddWithValue("@SUPPLIER_ID", supplier_id);
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {                        
                            connection.Close();
                            return true;
                        }

                        else
                        {
                            connection.Close();
                            return false;
                        }
                    }
                }

            }
        }

        static public void InsertUnderStockIntoProduct(int product_id, int supplier_id, int warehouse_id, int min_stock)
        {
            string query = "UPDATE WAREHOUSEPRODUCT SET MINIMUM_STOCK = @MINIMUM_STOCK WHERE Product_id = @Product_id AND " +
                "Supplier_id = @Supplier_id AND WAREHOUSE_ID = @WAREHOUSE_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_id", product_id);
                    command.Parameters.AddWithValue("@Supplier_id", supplier_id);
                    command.Parameters.AddWithValue("@WareHouse_ID", warehouse_id);
                    command.Parameters.AddWithValue("@MINIMUM_STOCK", min_stock);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

         }

        static public int ShowUnderStockProduct(int product_id, int supplier_id, int warehouse_id)
        {
            string query = "SELECT MINIMUM_STOCK FROM WAREHOUSEPRODUCT WHERE Product_id = @Product_id AND Supplier_id = @Supplier_id AND WAREHOUSE_ID = @WAREHOUSE_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_id", product_id);
                    command.Parameters.AddWithValue("@Supplier_id", supplier_id);
                    command.Parameters.AddWithValue("@WareHouse_ID", warehouse_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Verifica se ci sono righe restituite
                        {
                            try
                            {
                                return reader.GetInt32(0); // Ottieni il valore della colonna MINIMUM_STOCK
                            }

                            catch(System.Data.SqlTypes.SqlNullValueException)
                            {
                                return 0;
                            }
                        }
                    }
                }
            }

            return 0;
        }


        //metodo che serve per capire quant'è il numero presente in magazzino di quel prodotto indipendentemente dal 
        //fornitore e dal magazzino
        static public int ShowStock(int product_id)
        {
            string query = "SELECT SUM(Stock) AS TotalStock FROM WAREHOUSEPRODUCT WHERE Product_id = @Product_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_id", product_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Verifica se ci sono righe restituite
                        {
                            try
                            {
                                return reader.GetInt32(0); // Ottieni il valore della colonna MINIMUM_STOCK
                            }

                            catch (System.Data.SqlTypes.SqlNullValueException)
                            {
                                return 0;
                            }
                        }
                    }
                }
            }

            return 0;
        }

    }
}
