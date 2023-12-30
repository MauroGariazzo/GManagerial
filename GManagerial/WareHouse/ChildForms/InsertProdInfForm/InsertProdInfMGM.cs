using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.WareHouse.ChildForms.InsertProdInfForm
{
    class InsertProdInfMGM
    {
        //static string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
        static public void LoadUM(ComboBox um)
        {
            string query = "SELECT Unit_Name FROM Unit_of_MeasureTbl WHERE UnityMisureType IS NULL UNION SELECT Unit_Name " +
                "FROM Unit_of_MeasureTbl WHERE Unit_Name != '-' AND UnityMisureType != 'POW'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    um.Items.Add(reader.GetString(0));  
                }
            }
        }


        static public void LoadProductListSuppliers(int product_id, ComboBox cbSupplier) //tutti i fornitori di quel prodotto
        {
            string query = "SELECT p.Supplier_ID, s.Company_Name FROM PRODUCT_PRICES p JOIN SUPPLIERSTBL s " +
                "ON s.Supplier_ID = p.Supplier_ID WHERE PRODUCT_ID = " + product_id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int countEmptySupplier = 0;

                while (reader.Read())
                {

                    ItemTag itemTag = new ItemTag();
                    itemTag.Tag = Convert.ToInt32(reader["Supplier_ID"]);

                    itemTag.Text = reader["Company_Name"].ToString();

                    if (itemTag.Text == "-")
                    {
                        countEmptySupplier++;
                    }

                    if (itemTag.Text == "-")
                    {
                        if (countEmptySupplier < 2)
                        {
                            cbSupplier.Items.Add(itemTag);
                        }
                    }

                    else
                    {
                        cbSupplier.Items.Add(itemTag);
                    }

                }

                reader.Close();
                connection.Close();

            }

        }
    }
}
