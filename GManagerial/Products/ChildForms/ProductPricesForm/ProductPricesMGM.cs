using GManagerial.WareHouse.ChildForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products.ChildForms
{
    class ProductPricesMGM
    {

        //static string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
        public ProductPricesMGM()
        {

        }

        static public void LoadListSuppliers(ComboBox cbSupplier)
        {
            string query = "SELECT Supplier_ID, Company_Name FROM SUPPLIERSTBL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                cbSupplier.Items.Clear();

                while (reader.Read())
                {

                    ItemTag itemTag = new ItemTag();
                    itemTag.Tag = Convert.ToInt32(reader["Supplier_ID"]);
                    
                    itemTag.Text = reader["Company_Name"].ToString();

                    cbSupplier.Items.Add(itemTag);
                    cbSupplier.SelectedIndex = 0;
                }

                reader.Close();
                connection.Close();
            }

        }

        static public void InsertPrices(int product_id, int supplier_id, string comboBoxName, float? price, TextBox priceTB)
        {
            string query = "";

            Boolean HasRows = SearchProductsID(product_id, comboBoxName);

            if (!HasRows)
            {
                query = "INSERT INTO PRODUCT_PRICES(PRODUCT_ID, SUPPLIER_ID, ComboBoxName, Price) VALUES(@PRODUCT_ID, @SUPPLIER_ID, " +
                    "@COMBOBOXNAME, @Price)";
            }

            else
            {
                query = "UPDATE PRODUCT_PRICES SET PRODUCT_ID = @PRODUCT_ID, SUPPLIER_ID = @SUPPLIER_ID, ComboBoxName = @ComboBoxName, " +
                    "Price = @Price WHERE PRODUCT_ID = @PRODUCT_ID AND ComboBoxName = @COMBOBOXNAME";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", product_id);
                    command.Parameters.AddWithValue("@SUPPLIER_ID", supplier_id);
                    command.Parameters.AddWithValue("@COMBOBOXNAME", comboBoxName);

                    try
                    {
                        if (priceTB != null && priceTB.Text != "")
                        {
                            command.Parameters.AddWithValue("@Price", price);
                        }

                        else
                        {
                            command.Parameters.Add("@Price", SqlDbType.Decimal).Value = DBNull.Value;
                        }
                    }

                    catch (System.NullReferenceException)
                    {
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

        static public Boolean SearchProductsID(int product_id, string comboBoxName)
        {
            string query = "SELECT * FROM Product_Prices WHERE Product_ID = @PRODUCT_ID AND COMBOBOXNAME = @COMBOBOXNAME";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PRODUCT_ID", product_id);
                command.Parameters.AddWithValue("@COMBOBOXNAME", comboBoxName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }
        }

        static public void LoadPricesAndSelectedSupplier(TextBox tbPrice, ComboBox cbSuppl, int product_id)
        {
            string query = "SELECT SUPPL.Company_Name, PPS.Price, PPS.ComboBoxName FROM SuppliersTbl SUPPL JOIN Product_Prices PPS ON " +
            "SUPPL.Supplier_ID = PPS.Supplier_ID WHERE PPS.Product_ID = @Product_ID AND PPS.ComboBoxName = @ComboBoxName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Product_ID", product_id);
                command.Parameters.AddWithValue("@ComboBoxName", cbSuppl.Name);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string company_name = reader.GetString(0);
                    int index = cbSuppl.FindString(company_name);

                    if (index >= 0)
                    {
                        cbSuppl.SelectedIndex = index;
                    }

                    if (!reader.IsDBNull(1)) 
                    {
                        tbPrice.Text = reader.GetDecimal(1).ToString();
                    }
                    else
                    {
                        tbPrice.Text = ""; 
                    }

                }

                reader.Close();
                connection.Close();
            }
        }


        static public void DeletePrices(int product_id)
        {
            string query = "DELETE FROM PRODUCT_PRICES WHERE PRODUCT_ID = @PRODUCT_ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))  //ATTACHMENTSCLASS
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", product_id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
