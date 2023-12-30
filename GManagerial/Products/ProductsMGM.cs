using GManagerial.CustomerMGM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial.Products.ChildForms
{
    class ProductsMGM
    {
        //static private string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";

        static public void ProductsForm_Load(DataGridView productsDGV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Product_ID, Product_Name, resizedImage FROM productsTbl";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                bool checkBoxColumnExists = false;
                foreach (DataGridViewColumn column in productsDGV.Columns)
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
                    productsDGV.Columns.Insert(0, checkBoxDataGridViewColumn);
                }

                productsDGV.DataSource = dataTable;
                productsDGV.AutoGenerateColumns = false;
            }

        }


        static public void registerProduct(int categoryID, int subCategoryID, int brandID, char nec, System.Windows.Forms.TextBox codArticleTB, 
            System.Windows.Forms.TextBox snTB, System.Windows.Forms.TextBox manfDateTB, System.Windows.Forms.TextBox descriptionTB, 
            System.Windows.Forms.TextBox energyTB, System.Windows.Forms.TextBox powerTB, System.Windows.Forms.TextBox energyConsTB, 
            System.Windows.Forms.TextBox heightTB, System.Windows.Forms.TextBox widthTB, System.Windows.Forms.TextBox weightTB, System.Windows.Forms.TextBox depthTB,
            System.Windows.Forms.TextBox notesTB, System.Windows.Forms.ComboBox heightCB, System.Windows.Forms.ComboBox widthCB,
            System.Windows.Forms.ComboBox weightCB, System.Windows.Forms.ComboBox depthCB, System.Windows.Forms.ComboBox powerCB, 
            System.Windows.Forms.ComboBox energyConsCB, int Product_ID)
        {
            string query = "";
            if (nec == 'n' || nec == 'c')
            {
                query = "INSERT INTO PRODUCTSTBL(Product_Name,Description,ID_Brand,Category_ID,Subcategory_ID,Manufacturing_Date,Energy_Class," +
                    "Serial_Number,Power,Energy_Consumption,Notes,Height,Width,Weight,Depth,Height_Unit,Width_Unit,Weight_Unit,Depth_Unit," +
                    "Power_Unit,energyCons_unit)"
                + "VALUES(@Product_Name,@description,@ID_Brand,@Category_ID,@Subcategory_ID,@Manufacturing_Date,@Energy_Class,@Serial_Number," +
                "@Power,@Energy_Consumption,@Notes,@Height,@Width,@Weight,@Depth,@Height_Unit,@Width_Unit,@Weight_Unit,@Depth_Unit,@Power_Unit," +
                "@energyCons_unit)";
            }

            else if (nec == 'e')
            {
                query = "UPDATE PRODUCTSTBL SET Product_Name = @Product_Name, Description = @Description, ID_Brand = @ID_Brand, Category_ID = @Category_ID, " +
                    "Subcategory_ID = @Subcategory_ID, Manufacturing_Date = @Manufacturing_Date, Energy_Class = @Energy_Class," +
                    "Height = @Height, Width = @Width, Weight = @Weight, Depth = @Depth," +
                    "Serial_Number = @Serial_Number, Power = @Power, Energy_Consumption = @Energy_Consumption, Height_Unit = @Height_Unit," +
                    " Width_Unit = @Width_Unit, Weight_Unit = @Weight_Unit, Depth_Unit = @Depth_Unit, Power_Unit = @Power_Unit, " +
                    "energyCons_unit = @energyCons_unit WHERE Product_ID = " + Product_ID;
            }

            else
            {
                query = "";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", codArticleTB.Text);
                    command.Parameters.AddWithValue("@Serial_Number", snTB.Text);

                    if (manfDateTB.Text != "") { command.Parameters.AddWithValue("@Manufacturing_Date", manfDateTB.Text); }
                    else { command.Parameters.AddWithValue("@Manufacturing_Date", DBNull.Value); }

                    command.Parameters.AddWithValue("@Description", descriptionTB.Text);

                    if (brandID == 0)
                    {
                        command.Parameters.AddWithValue("@ID_Brand", 1);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ID_Brand", brandID);
                    }

                    command.Parameters.AddWithValue("@Category_ID", categoryID);
                    command.Parameters.AddWithValue("@Subcategory_ID", subCategoryID);
                    command.Parameters.AddWithValue("@Energy_Class", energyTB.Text);

                    if (powerTB.Text == "") { command.Parameters.Add("@Power", SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@Power", powerTB.Text); }

                    if (energyConsTB.Text == "") { command.Parameters.Add("@Energy_Consumption", SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@Energy_Consumption", energyConsTB.Text); }

                    if (heightTB.Text == "") { command.Parameters.Add("@Height", SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@Height", heightTB.Text); }

                    if (widthTB.Text == "") { command.Parameters.Add("@Width", SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@Width", widthTB.Text); }

                    if (weightTB.Text == "") { command.Parameters.Add("@Weight", SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@Weight", weightTB.Text); }

                    if (depthTB.Text == "") { command.Parameters.Add("@Depth", SqlDbType.Decimal).Value = DBNull.Value; }
                    else { command.Parameters.AddWithValue("@Depth", depthTB.Text); }

                    command.Parameters.AddWithValue("@Notes", notesTB.Text);
                    command.Parameters.AddWithValue("@Height_Unit", heightCB.Text);
                    command.Parameters.AddWithValue("@Width_Unit", widthCB.Text);
                    command.Parameters.AddWithValue("@Weight_Unit", weightCB.Text);
                    command.Parameters.AddWithValue("@Depth_Unit", depthCB.Text);
                    command.Parameters.AddWithValue("@Power_Unit", powerCB.Text);
                    command.Parameters.AddWithValue("@energyCons_unit", energyConsCB.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }


        static public void deleteProduct(int Product_ID)
        {                                                       //il codice dovrà ciclare sulla lista degli elementi che si vogliono cancellare (idrows)
            try
            {
                string deleteWareHouse = "DELETE FROM WAREHOUSEPRODUCT WHERE PRODUCT_ID = " + Product_ID;
                string deleteAttachmentQuery = "DELETE FROM ATTACHMENTSTBL WHERE Product_ID = " + Product_ID;
                string deleteProduct = "DELETE FROM PRODUCTSTBL WHERE Product_ID = " + Product_ID;
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteWareHouse, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deleteAttachmentQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deleteProduct, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        static public void LoadPowUnityMeasure(System.Windows.Forms.ComboBox powerCB, System.Windows.Forms.ComboBox energy_consCB)
        {
            powerCB.Items.Clear();  
            energy_consCB.Items.Clear();    

            string query = "SELECT UNIT_NAME FROM UNIT_OF_MEASURETBL WHERE UnityMisureType = 'POW'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string unityMeasure = reader["Unit_Name"].ToString();
                        powerCB.Items.Add(unityMeasure);
                        energy_consCB.Items.Add(unityMeasure);
                    }
                }
            }
        }


        static public void LoadLenUnityMeasure(System.Windows.Forms.ComboBox depthCB, System.Windows.Forms.ComboBox widthCB, System.Windows.Forms.ComboBox heightCB)
        {
            depthCB.Items.Clear();
            widthCB.Items.Clear();
            heightCB.Items.Clear(); 

            string query = "SELECT UNIT_NAME FROM UNIT_OF_MEASURETBL WHERE UnityMisureType = 'LENGTH'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string unityMeasure = reader["Unit_Name"].ToString();
                        depthCB.Items.Add(unityMeasure);
                        widthCB.Items.Add(unityMeasure);
                        heightCB.Items.Add(unityMeasure);
                    }
                }
            }
        }


        static public void LoadWeiUnityMeasure(System.Windows.Forms.ComboBox weightCB)
        {
            weightCB.Items.Clear();

            string query = "SELECT UNIT_NAME FROM UNIT_OF_MEASURETBL WHERE UnityMisureType = 'WEIGHT'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string unityMeasure = reader["Unit_Name"].ToString();
                        weightCB.Items.Add(unityMeasure);
                    }
                }
            }
        }

        static public void EditProduct(System.Windows.Forms.TextBox codArticleTB,
            System.Windows.Forms.TextBox snTB, System.Windows.Forms.TextBox manfDateTB, System.Windows.Forms.TextBox descriptionTB,
            System.Windows.Forms.TextBox energyTB, System.Windows.Forms.TextBox powerTB, System.Windows.Forms.TextBox energyConsTB,
            System.Windows.Forms.TextBox heightTB, System.Windows.Forms.TextBox widthTB, System.Windows.Forms.TextBox weightTB, System.Windows.Forms.TextBox depthTB,
            System.Windows.Forms.TextBox notesTB, System.Windows.Forms.ComboBox heightCB, System.Windows.Forms.ComboBox widthCB,
            System.Windows.Forms.ComboBox weightCB, System.Windows.Forms.ComboBox depthCB, System.Windows.Forms.ComboBox powerCB,
            System.Windows.Forms.ComboBox energyConsCB, DataGridView productsDGV, int Product_ID, System.Windows.Forms.ComboBox BrandCB,
            System.Windows.Forms.ComboBox categoryCB, System.Windows.Forms.ComboBox subCategoryCB)

        {
            string productQuery = "SELECT * FROM productsTbl WHERE Product_ID = " + Product_ID;
            string categoryQuery = "SELECT Category_ID, CATEGORY_NAME FROM CATEGORIESTBL WHERE Category_ID = (SELECT Category_ID FROM productsTbl WHERE Product_ID = " + Product_ID + ")";
            string subcategoryQuery = "SELECT SUBCATEGORY_NAME FROM SUBCATEGORYTBL WHERE Subcategory_ID = (SELECT Subcategory_ID FROM productsTbl WHERE Product_ID = " + Product_ID + ")";
            string brandQuery = "SELECT b.Brand_Name FROM productsTbl p INNER JOIN brandtbl b ON p.ID_Brand = b.ID_Brand WHERE p.Product_ID = " + Product_ID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand productCommand = new SqlCommand(productQuery, connection);
                SqlDataReader productReader = productCommand.ExecuteReader();

                if (productReader.Read())
                {
                    codArticleTB.Text = productReader["Product_Name"].ToString();
                    snTB.Text = productReader["Serial_Number"].ToString();
                    descriptionTB.Text = productReader["Description"].ToString();

                    if (productReader["Manufacturing_Date"].ToString() != "")
                    {
                        manfDateTB.Text = productReader["Manufacturing_Date"].ToString().Substring(0, 10);
                    }


                    if (heightTB != null)
                    {
                        heightTB.Text = productReader["Height"].ToString().Replace(",", ".");
                        widthTB.Text = productReader["Width"].ToString().Replace(",", ".");
                        depthTB.Text = productReader["Depth"].ToString().Replace(",", ".");
                        weightTB.Text = productReader["Weight"].ToString().Replace(",", ".");
                        powerTB.Text = productReader["Power"].ToString().Replace(",", ".");
                        energyConsTB.Text = productReader["Energy_Consumption"].ToString().Replace(",", ".");


                        energyTB.Text = productReader["Energy_Class"].ToString();
                        notesTB.Text = productReader["Notes"].ToString();

                        heightCB.SelectedItem = productReader["Height_Unit"].ToString();
                        widthCB.Text = productReader["Width_Unit"].ToString();
                        weightCB.Text = productReader["Weight_Unit"].ToString();
                        depthCB.Text = productReader["Depth_Unit"].ToString();
                        powerCB.Text = productReader["Power_Unit"].ToString();
                        energyConsCB.Text = productReader["energyCons_unit"].ToString();

                        productReader.Close();
                    }

                    else
                    {
                        productReader.Close();
                    }

                    SqlCommand brandCommand = new SqlCommand(brandQuery, connection);
                    string brandName = brandCommand.ExecuteScalar()?.ToString();

                    if (brandName == "-")
                    {
                        BrandCB.Text = "";
                    }

                    else
                    {
                        BrandCB.Text = brandName;
                    }

                }

                using (SqlCommand command = new SqlCommand(categoryQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", Product_ID);

                    //connection.Open();

                    SqlDataReader categoryReader = command.ExecuteReader();

                    if (categoryReader.HasRows)
                    {
                        while (categoryReader.Read())
                        {
                            int categoryId = categoryReader.GetInt32(0);
                            string categoryName = categoryReader.GetString(1);
                            categoryCB.Text = categoryName;
                            LoadSubCategories(categoryId, subCategoryCB);
                        }
                    }
                    categoryReader.Close();
                }


                using (SqlCommand subcategoryCommand = new SqlCommand(subcategoryQuery, connection))
                {
                    string subcategoryName = subcategoryCommand.ExecuteScalar()?.ToString();
                    subCategoryCB.Text = subcategoryName;
                }

                connection.Close();
            }
        }

        static public void LoadCategories(System.Windows.Forms.ComboBox categoryCB)
        {
            string query = "SELECT Category_ID, CATEGORY_NAME FROM CATEGORIESTBL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemTag item = new ItemTag();

                        item.Text = reader["CATEGORY_NAME"].ToString();
                        item.Tag = (int)reader["CATEGORY_ID"];

                        categoryCB.Items.Add(item);
                    }
                }
            }
        }


        static public void LoadSubCategories(int categoryID, System.Windows.Forms.ComboBox subCategoryCB)
        {
            string query = "SELECT Subcategory_ID, Subcategory_Name FROM SUBCATEGORYTBL WHERE Parent_Category_ID = " + categoryID;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemTag item = new ItemTag();

                        item.Text = reader["Subcategory_Name"].ToString();
                        item.Tag = (int)reader["Subcategory_ID"];

                        subCategoryCB.Items.Add(item);
                    }
                }
            }
        }

        static public void AllBrands(System.Windows.Forms.ComboBox BrandCB)
        {
            string query = "SELECT ID_Brand, Brand_Name FROM BRANDTBL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemTag item = new ItemTag();

                        item.Text = reader["Brand_Name"].ToString();
                        item.Tag = (int)reader["ID_Brand"];

                        if (reader["Brand_Name"].ToString() != "" && reader["Brand_Name"].ToString() != null)
                        {
                            BrandCB.Items.Add(item);
                        }
                    }
                }
            }
        }

        static public int maxIdProduct()
        {
            int maxId = 0;
            string query = "SELECT MAX(Product_ID) FROM productsTbl";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();
                    maxId = Convert.ToInt32(result);
                }
            }
            return maxId;
        }
    }
}



