using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GManagerial.Products.ChildForms
{
    static class CategoriesMGM
    {
        //static string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
        static public void InsertCatInDB(TextBox categoryTB)
        {
            string query = "INSERT INTO CATEGORIESTBL(CATEGORY_NAME) VALUES(@CATEGORY_NAME)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CATEGORY_NAME", categoryTB.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        static public void SubCatInDB(TextBox subCcategoryTB, int categoryID)
        {
            string query = "INSERT INTO SUBCATEGORYTBL(SUBCATEGORY_NAME, PARENT_CATEGORY_ID) VALUES(@SUBCATEGORY_NAME, @PARENT_CATEGORY_ID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SUBCATEGORY_NAME", subCcategoryTB.Text);   //bisogna anche aggiungere l'id del padre
                    command.Parameters.AddWithValue("@PARENT_CATEGORY_ID", categoryID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        static public void LoadCatFromDB(TreeView catTV)
        {
            string query = "SELECT CATEGORY_ID, CATEGORY_NAME FROM CATEGORIESTBL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int categoryId = Convert.ToInt32(reader["CATEGORY_ID"]);
                    string categoryName = reader["CATEGORY_NAME"].ToString();

                    TreeNode categoryNode = new TreeNode(categoryName);
                    categoryNode.Tag = categoryId; // Imposta l'ID categoria come Tag del nodo
                    catTV.Nodes.Add(categoryNode);


                    LoadSubCatFromDB(catTV, categoryId, categoryNode); // Passa il nodo categoria come parametro
                }

                reader.Close();
                connection.Close();
            }
        }

        static public void LoadSubCatFromDB(TreeView catTV, int categoryID, TreeNode parentNode)
        {
            string query = "SELECT Subcategory_ID, Subcategory_Name FROM SUBCATEGORYTBL WHERE Parent_Category_ID = " + categoryID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int subcategoryId = Convert.ToInt32(reader["Subcategory_ID"]);
                    string subcategoryName = reader["Subcategory_Name"].ToString();

                    TreeNode subcategoryNode = new TreeNode(subcategoryName);
                    subcategoryNode.Tag = subcategoryId;
                    parentNode.Nodes.Add(subcategoryNode); // Aggiungi il sottonodo al nodo categoria
                }

                reader.Close();
                connection.Close();
            }
        }

        static public void EditCat(int categoryID, TextBox categoryTB)
        {
            string query = "UPDATE CATEGORIESTBL SET Category_Name = @Category_Name WHERE Category_ID = " + categoryID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Category_Name", categoryTB.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        static public void EditSubCat(int subCategoryID, TextBox subCategoryTB)
        {
            string query = "UPDATE subCategoryTbl SET Subcategory_Name = @Subcategory_Name WHERE Subcategory_ID = " + subCategoryID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Subcategory_Name", subCategoryTB.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        static public void DeleteSub(int subCategoryID)
        {
            string query = "DELETE FROM subCategoryTbl WHERE Subcategory_ID = " + subCategoryID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        static public void DeleteCat(int CategoryID)
        {
            string query = "DELETE FROM categoriesTbl WHERE Category_ID = " + CategoryID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}

