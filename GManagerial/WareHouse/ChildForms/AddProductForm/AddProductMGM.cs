using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.Products.ChildForms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace GManagerial.WareHouse.ChildForms
{
    class AddProductMGM
    {
        //static private string connectionString = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connectionString = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
        static public void ProductsForm_Load(ListBox lbProducts)
        {
            string query = "SELECT Product_ID, Product_Name, resizedImage FROM productsTbl";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ItemTag item = new ItemTag();
                    item.Tag = reader.GetInt32(0);
                    item.Text = reader.GetString(1);
                    lbProducts.Items.Add(item);
                }
            }
        }

        static public void LoadProductAnagraphic(TextBox codArticleTB, TextBox snTB, TextBox brandTB, TextBox manfDateTB,
            TextBox categoryTB, TextBox subCategoryTB, TextBox descriptionTB, TextBox heightTB, TextBox depthTB,
            TextBox widthTB, TextBox weightTB, TextBox heightUM, TextBox depthUM, TextBox widthUM, TextBox weightUM,
            PictureBox image, int product_id) //heightTB, depthTB, widthTB, weightTB
        {
            string productQuery = "SELECT Product_ID, Product_Name, Serial_Number, image, Manufacturing_Date, Description," +
                "Height, Depth, Width, Weight, Height_Unit, Width_Unit, Weight_Unit, Depth_Unit" +
                " FROM productsTbl WHERE Product_ID = " + product_id;

            string categoryQuery = "SELECT CATEGORY_NAME FROM CATEGORIESTBL " +
                "WHERE Category_ID = (SELECT Category_ID FROM productsTbl WHERE Product_ID = " + product_id + ")";

            string subcategoryQuery = "SELECT SUBCATEGORY_NAME FROM SUBCATEGORYTBL" +
                " WHERE Subcategory_ID = (SELECT Subcategory_ID FROM productsTbl WHERE Product_ID = " + product_id + ")";

            string brandQuery = "SELECT b.Brand_Name FROM productsTbl p " +
                "INNER JOIN brandtbl b ON p.ID_Brand = b.ID_Brand WHERE p.Product_ID = " + product_id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(productQuery, connection);
                SqlDataReader productReader = command.ExecuteReader();

                while (productReader.Read())
                {
                    codArticleTB.Text = productReader.GetString(1);
                    snTB.Text = productReader.GetString(2);

                    if (!productReader.IsDBNull(3))
                    {
                        byte[] imageBytes = (byte[])productReader[3];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            image.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }

                    else
                    {
                        image.Image = null;
                    }

                    if (!productReader.IsDBNull(4))
                    {
                        manfDateTB.Text = productReader.GetString(4);
                    }

                    descriptionTB.Text = productReader.GetString(5);

                    heightTB.Text = productReader["Height"].ToString().Replace(",", ".");
                    widthTB.Text = productReader["Width"].ToString().Replace(",", ".");
                    depthTB.Text = productReader["Depth"].ToString().Replace(",", ".");
                    weightTB.Text = productReader["Weight"].ToString().Replace(",", ".");
                    
                         

                    heightUM.Text = productReader["Height_Unit"].ToString();
                    widthUM.Text = productReader["Width_Unit"].ToString();
                    weightUM.Text = productReader["Weight_Unit"].ToString();
                    depthUM.Text = productReader["Depth_Unit"].ToString();
                }

                productReader.Close();

                SqlCommand categoryCommand = new SqlCommand(categoryQuery, connection);
                string categoryName = categoryCommand.ExecuteScalar()?.ToString();
                categoryTB.Text = categoryName;

                SqlCommand subcategoryCommand = new SqlCommand(subcategoryQuery, connection);
                string subcategoryName = subcategoryCommand.ExecuteScalar()?.ToString();
                subCategoryTB.Text = subcategoryName;

                SqlCommand brandCommand = new SqlCommand(brandQuery, connection);
                string brandName = brandCommand.ExecuteScalar()?.ToString();
                brandTB.Text = brandName;

                connection.Close();
            }

        }


        //caricare nella lista prodotti solo i prodotti creati nel magazzino
        static public void WHProductsForm_Load(ListBox lbProducts, int warehouseID)
        {
            string query = "SELECT P.Product_ID, W.Supplier_id, P.Product_Name FROM ProductsTbl P JOIN WareHouseProduct W " +
                "ON P.Product_ID = W.Product_id WHERE W.WareHouse_ID = " + warehouseID;
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ItemTag item = new ItemTag();
                    item.Tag = reader.GetInt32(0);
                    item.Tag2 = reader.GetInt32(1);
                    item.Text = reader.GetString(2);
                    lbProducts.Items.Add(item);
                }
            }
        }
    }
}

