using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial.Products.ChildForms
{
    class BrandMGM
    {
        static string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        //static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";

        static public void IsNewOrEdit(char nec, System.Windows.Forms.TextBox brandTB, int selectedItemID)
        {
            if(nec == 'n')
            {
                AddBrandDB(brandTB);
            }

            else
            {
                EditBrandDB(brandTB, selectedItemID);
            }
        }

        static public void AddBrandDB(System.Windows.Forms.TextBox brandTB)
        {
            string query = "INSERT INTO BRANDTBL(BRAND_NAME) VALUES(@BRAND_NAME)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BRAND_NAME", brandTB.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        static public void EditBrandDB(System.Windows.Forms.TextBox brandTB, int idBrand)
        {
            string query = "UPDATE BRANDTBL SET BRAND_NAME = @BRAND_NAME WHERE ID_BRAND = " + idBrand;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BRAND_NAME", brandTB.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
     
        }

        static public void LoadBrandDB(ListBox brandList)
        {
            string query = "SELECT ID_Brand, BRAND_NAME FROM BRANDTBL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ItemTag itemTag = new ItemTag();
                    itemTag.Tag = Convert.ToInt32(reader["ID_Brand"]);
                    itemTag.Text = reader["BRAND_NAME"].ToString();

                    if (Convert.ToInt32(reader["ID_Brand"]) != 1)
                    {
                        brandList.Items.Add(itemTag);
                    }
                    
                }
            }
        }

        static public void DeleteBrandDB(int idBrand)
        {
            string query = "DELETE FROM BRANDTBL WHERE ID_BRAND = " + idBrand;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
