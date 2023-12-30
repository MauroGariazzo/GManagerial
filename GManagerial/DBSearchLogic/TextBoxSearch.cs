using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial
{
    static class TextBoxSearch
    {
        private static string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        //static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";

        //Datagridview customer
        public static void SearchCustomer(string searchBox, DataGridView CustomersDgv, System.Windows.Forms.ComboBox regionCB = null, System.Windows.Forms.ComboBox provCB = null, System.Windows.Forms.ComboBox cityCb = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_customer, name, region, province, municip FROM CUSTOMERTBL WHERE 1 = 1";

                if (!string.IsNullOrEmpty(searchBox))
                {
                    query += " AND (name LIKE @searchValue)";
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null && regionCB.SelectedItem.ToString() != "")
                    {
                        query += " AND REGION = @REGION";
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null && provCB.SelectedItem.ToString() != "")
                    {
                        query += " AND PROVINCE = @PROVINCE";
                    }
                }


                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null && cityCb.SelectedItem.ToString() != "")
                    {
                        query += " AND MUNICIP = @MUNICIP";
                    }
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchBox))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchBox + "%");
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null)
                    {
                        //ItemTag itemTag = regionCB.SelectedItem as ItemTag;
                        //int categoryID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@REGION", regionCB.SelectedItem.ToString());
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null)
                    {
                        //ItemTag itemTag = provCB.SelectedItem as ItemTag;
                        //int subcategoryID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@PROVINCE", provCB.SelectedItem.ToString());
                    }
                }

                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null)
                    {
                        //ItemTag itemTag = cityCb.SelectedItem as ItemTag;
                        //int brandID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@MUNICIP", cityCb.SelectedItem.ToString());
                    }
                }

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                CustomersDgv.DataSource = dataTable;
            }
        }

        //Listbox customer
        public static void SearchCustomer(string searchBox, ListBox lb, System.Windows.Forms.ComboBox regionCB = null, System.Windows.Forms.ComboBox provCB = null, System.Windows.Forms.ComboBox cityCb = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_customer, name, region, province, municip FROM CUSTOMERTBL WHERE 1 = 1";

                if (!string.IsNullOrEmpty(searchBox))
                {
                    query += " AND (name LIKE @searchValue)";
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null && regionCB.SelectedItem.ToString() != "")
                    {
                        query += " AND REGION = @REGION";
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null && provCB.SelectedItem.ToString() != "")
                    {
                        query += " AND PROVINCE = @PROVINCE";
                    }
                }


                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null && cityCb.SelectedItem.ToString() != "")
                    {
                        query += " AND MUNICIP = @MUNICIP";
                    }
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchBox))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchBox + "%");
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null)
                    {
                        //ItemTag itemTag = regionCB.SelectedItem as ItemTag;
                        //int categoryID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@REGION", regionCB.SelectedItem.ToString());
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null)
                    {
                        //ItemTag itemTag = provCB.SelectedItem as ItemTag;
                        //int subcategoryID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@PROVINCE", provCB.SelectedItem.ToString());
                    }
                }

                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null)
                    {
                        //ItemTag itemTag = cityCb.SelectedItem as ItemTag;
                        //int brandID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@MUNICIP", cityCb.SelectedItem.ToString());
                    }
                }

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                lb.DataSource = dataTable;
            }
        }

        //Datagridview supplier
        public static void SearchSupplier(string searchBox, DataGridView SupplierDgv, System.Windows.Forms.ComboBox regionCB = null, System.Windows.Forms.ComboBox provCB = null, System.Windows.Forms.ComboBox cityCb = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Supplier_ID, Company_Name, region, province, City FROM SUPPLIERSTBL WHERE Supplier_ID != 1";

                if (!string.IsNullOrEmpty(searchBox))
                {
                    query += " AND (Company_Name LIKE @searchValue)";
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null && regionCB.SelectedItem.ToString() != "")
                    {
                        query += " AND REGION = @REGION";
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null && provCB.SelectedItem.ToString() != "")
                    {
                        query += " AND PROVINCE = @PROVINCE";
                    }
                }


                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null && cityCb.SelectedItem.ToString() != "")
                    {
                        query += " AND CITY = @CITY";
                    }
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchBox))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchBox + "%");
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@REGION", regionCB.SelectedItem.ToString());
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@PROVINCE", provCB.SelectedItem.ToString());
                    }
                }

                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@CITY", cityCb.SelectedItem.ToString());
                    }
                }

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                SupplierDgv.DataSource = dataTable;
            }
        }


        public static void SearchSupplier(string searchBox, ListBox lb, System.Windows.Forms.ComboBox regionCB = null, System.Windows.Forms.ComboBox provCB = null, System.Windows.Forms.ComboBox cityCb = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Supplier_ID, Company_Name, region, province, City FROM SUPPLIERSTBL WHERE Supplier_ID != 1";

                if (!string.IsNullOrEmpty(searchBox))
                {
                    query += " AND (Company_Name LIKE @searchValue)";
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null && regionCB.SelectedItem.ToString() != "")
                    {
                        query += " AND REGION = @REGION";
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null && provCB.SelectedItem.ToString() != "")
                    {
                        query += " AND PROVINCE = @PROVINCE";
                    }
                }


                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null && cityCb.SelectedItem.ToString() != "")
                    {
                        query += " AND CITY = @CITY";
                    }
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchBox))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchBox + "%");
                }

                if (regionCB != null)
                {
                    if (regionCB.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@REGION", regionCB.SelectedItem.ToString());
                    }
                }

                if (provCB != null)
                {
                    if (provCB.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@PROVINCE", provCB.SelectedItem.ToString());
                    }
                }

                if (cityCb != null)
                {
                    if (cityCb.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@CITY", cityCb.SelectedItem.ToString());
                    }
                }

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                lb.DataSource = dataTable;
            }
        }

        public static void SearchProduct(string searchBox, DataGridView productsDgv, System.Windows.Forms.ComboBox categoryCB = null, System.Windows.Forms.ComboBox subCategoryCB = null, System.Windows.Forms.ComboBox brandCB = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Product_ID, Product_Name, Description, resizedImage FROM PRODUCTSTBL WHERE 1 = 1";

                if (!string.IsNullOrEmpty(searchBox))
                {
                    query += " AND (Product_Name LIKE @searchValue OR Description LIKE @searchValue)";
                }

                if (categoryCB != null)
                {
                    if (categoryCB.SelectedItem != null)
                    {
                        query += " AND Category_ID = @Category_ID";
                    }
                }

                if (subCategoryCB != null)
                {
                    if (subCategoryCB.SelectedItem != null)
                    {
                        query += " AND Subcategory_ID = @Subcategory_ID";
                    }
                }

                if (brandCB != null)
                {
                    if (brandCB.SelectedItem != null)
                    {
                        query += " AND ID_Brand = @ID_Brand";
                    }
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchBox))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchBox + "%");
                }

                if (categoryCB != null)
                {
                    if (categoryCB.SelectedItem != null)
                    {
                        ItemTag itemTag = categoryCB.SelectedItem as ItemTag;
                        int categoryID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@Category_ID", categoryID);
                    }
                }

                if (subCategoryCB != null)
                {
                    if (subCategoryCB.SelectedItem != null)
                    {
                        ItemTag itemTag = subCategoryCB.SelectedItem as ItemTag;
                        int subcategoryID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@Subcategory_ID", subcategoryID);
                    }
                }

                if (brandCB != null)
                {
                    if (brandCB.SelectedItem != null)
                    {
                        ItemTag itemTag = brandCB.SelectedItem as ItemTag;
                        int brandID = (int)itemTag.Tag;
                        command.Parameters.AddWithValue("@ID_Brand", brandID);
                    }
                }

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                productsDgv.DataSource = dataTable;
            }
        }

        //LISTBOX
        public static void SearchProduct(string searchBox, ListBox productsListBox, System.Windows.Forms.ComboBox categoryCB = null, System.Windows.Forms.ComboBox subCategoryCB = null, System.Windows.Forms.ComboBox brandCB = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Product_ID, Product_Name, Description, resizedImage FROM PRODUCTSTBL WHERE 1 = 1";

                if (!string.IsNullOrEmpty(searchBox))
                {
                    query += " AND (Product_Name LIKE @searchValue OR Description LIKE @searchValue)";
                }

                if (categoryCB != null && categoryCB.SelectedItem != null)
                {
                    ItemTag categoryItemTag = categoryCB.SelectedItem as ItemTag;
                    int categoryID = (int)categoryItemTag.Tag;
                    query += " AND Category_ID = @Category_ID";
                }

                if (subCategoryCB != null && subCategoryCB.SelectedItem != null)
                {
                    ItemTag subCategoryItemTag = subCategoryCB.SelectedItem as ItemTag;
                    int subcategoryID = (int)subCategoryItemTag.Tag;
                    query += " AND Subcategory_ID = @Subcategory_ID";
                }

                if (brandCB != null && brandCB.SelectedItem != null)
                {
                    ItemTag brandItemTag = brandCB.SelectedItem as ItemTag;
                    int brandID = (int)brandItemTag.Tag;
                    query += " AND ID_Brand = @ID_Brand";
                }

                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchBox))
                {
                    command.Parameters.AddWithValue("@searchValue", "%" + searchBox + "%");
                }

                if (categoryCB != null && categoryCB.SelectedItem != null)
                {
                    ItemTag itemTag = categoryCB.SelectedItem as ItemTag;
                    int categoryID = (int)itemTag.Tag;
                    command.Parameters.AddWithValue("@Category_ID", categoryID);
                }

                if (subCategoryCB != null && subCategoryCB.SelectedItem != null)
                {
                    ItemTag itemTag = subCategoryCB.SelectedItem as ItemTag;
                    int subcategoryID = (int)itemTag.Tag;
                    command.Parameters.AddWithValue("@Subcategory_ID", subcategoryID);
                }

                if (brandCB != null && brandCB.SelectedItem != null)
                {
                    ItemTag itemTag = brandCB.SelectedItem as ItemTag;
                    int brandID = (int)itemTag.Tag;
                    command.Parameters.AddWithValue("@ID_Brand", brandID);
                }

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                DataTable dataTable = dataSet.Tables[0];

                productsListBox.Items.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    ItemTag item = new ItemTag
                    {
                        Tag = (int)row["Product_ID"],
                        Text = row["Product_Name"].ToString()
                    };

                    productsListBox.Items.Add(item);
                }

                productsListBox.DisplayMember = "Product_Name"; // Imposta il campo da visualizzare
            }
        }



        public static void SearchSupplier(System.Windows.Forms.TextBox searchBox, DataGridView supplierDgv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Supplier_ID, Company_Name FROM SUPPLIERSTBL WHERE Company_Name LIKE @value";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", "%" + searchBox.Text + "%");

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                supplierDgv.DataSource = dataTable;
            }
        }


        //LISTBOX
        public static void SearchSupplier(System.Windows.Forms.TextBox searchBox, ListBox lb)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Supplier_ID, Company_Name FROM SUPPLIERSTBL WHERE Company_Name LIKE @value";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", "%" + searchBox.Text + "%");

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                lb.DataSource = dataTable;
            }
        }
        static public void catTSM_Load(ToolStripMenuItem catTSM)
        {
            string query = "SELECT CATEGORY_ID, CATEGORY_NAME FROM CATEGORIESTBL";

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True"))
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

                    ToolStripMenuItem childItem = new ToolStripMenuItem(categoryName);
                    catTSM.DropDownItems.Add(childItem);
                }

                reader.Close();
                connection.Close();
            }
        }
    }
}
