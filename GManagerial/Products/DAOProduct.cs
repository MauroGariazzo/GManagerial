using GManagerial.Products.ChildForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products
{
    internal class DAOProduct:IDAOProduct
    {
        IDBConnector.IDBConnector dbConnector;
        public DAOProduct(IDBConnector.IDBConnector dBConnector) 
        {
            this.dbConnector = dBConnector;
        }
        public int Insert(IProduct product)
        {
            int idProduct;

            string query = "INSERT INTO PRODUCTSTBL(PRODUCT_NAME,DESCRIPTION,ID_BRAND,CATEGORY_ID,SUBCATEGORY_ID,MANUFACTURING_DATE,ENERGY_CLASS, SERIAL_NUMBER,POWER,ENERGY_CONSUMPTION,NOTES,HEIGHT," +
                "WIDTH,WEIGHT,DEPTH,IMAGE, RESIZEDIMAGE) VALUES(@PRODUCT_NAME,@DESCRIPTION,@ID_BRAND,@CATEGORY_ID,@SUBCATEGORY_ID, @PRODUCT_MANUFACTURINGDATE,@PRODUCT_ENERGYCLASS,@PRODUCT_SERIALNUMBER,@PRODUCT_POWER," +
                "@PRODUCT_ENERGYCONSUMPTION,@PRODUCT_NOTES,@PRODUCT_HEIGHT,@PRODUCT_WIDTH,@PRODUCT_WEIGHT, @PRODUCT_DEPTH, @IMAGE, @RESIZED_IMAGE);SELECT SCOPE_IDENTITY();"; //da inserire image

            SqlCommand command = new SqlCommand(query, dbConnector.GetConnectionObj());
            this.dbConnector.Open();

            try
            {
                command.Parameters.AddWithValue("@PRODUCT_NAME", product.ProductName);
                command.Parameters.AddWithValue("@DESCRIPTION", product.Description);
                command.Parameters.AddWithValue("@ID_BRAND", product.BrandP.ID); //se l'id non è settato sarà uguale a 0
                command.Parameters.AddWithValue("@CATEGORY_ID", product.CategoryObj.ID);
                command.Parameters.AddWithValue("@SUBCATEGORY_ID", product.SubCategory.ID);

                if (product.ManufacturingDate.ToString() != ""){command.Parameters.AddWithValue("@PRODUCT_MANUFACTURINGDATE", product.ManufacturingDate.ToString());}
                else { { command.Parameters.AddWithValue("@PRODUCT_MANUFACTURINGDATE", DBNull.Value); } }

                command.Parameters.AddWithValue("@PRODUCT_ENERGYCLASS", product.EnergyClass);
                command.Parameters.AddWithValue("@PRODUCT_SERIALNUMBER", product.SerialNumber);

                if (product.Power == null) { command.Parameters.AddWithValue("@PRODUCT_POWER", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_POWER", product.Power); }

                if (product.EnergyConsumption == null) { command.Parameters.AddWithValue("@PRODUCT_ENERGYCONSUMPTION", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_ENERGYCONSUMPTION", product.EnergyConsumption); }

                if(product.Height == null) { command.Parameters.AddWithValue("@PRODUCT_HEIGHT", DBNull.Value); }
                else{command.Parameters.AddWithValue("@PRODUCT_HEIGHT", product.Height);}

                if (product.Width == null) { command.Parameters.AddWithValue("@PRODUCT_WIDTH", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_WIDTH", product.Width); }

                if(product.Weight == null) { command.Parameters.AddWithValue("@PRODUCT_WEIGHT", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_WEIGHT", product.Weight); }

                if (product.Depth == null) { command.Parameters.AddWithValue("@PRODUCT_DEPTH", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_DEPTH", product.Depth); }

                if (product.Image != null){ command.Parameters.AddWithValue("@IMAGE", product.ConvertImageToArrayBytes()); }
                else { command.Parameters.AddWithValue("@IMAGE", System.Data.SqlTypes.SqlBinary.Null); }

                if (product.ResizedImage != null) { command.Parameters.AddWithValue("@RESIZED_IMAGE", product.ConvertResizeImageToArrayBytes()); }
                else { command.Parameters.AddWithValue("@RESIZED_IMAGE", System.Data.SqlTypes.SqlBinary.Null); }

                command.Parameters.AddWithValue("@PRODUCT_NOTES", product.Notes);

                //this.dbConnector.Insert(command); //invio i dati al db

                idProduct = Convert.ToInt32(command.ExecuteScalar());
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                idProduct = 0;
            }

            this.dbConnector.Close();

            return idProduct;
        }

        public Dictionary<int, IProduct> GetAll()
        {
            string query = "SELECT * , B.BRAND_NAME, C.CATEGORY_NAME, S.SUBCATEGORY_NAME FROM PRODUCTSTBL P JOIN BRANDTBL B ON P.ID_BRAND = B.ID_BRAND JOIN CATEGORIESTBL C ON " +
                "C.CATEGORY_ID = P.CATEGORY_ID JOIN SUBCATEGORYTBL S ON S.SUBCATEGORY_ID = P.SUBCATEGORY_ID";

            SqlCommand command = new SqlCommand(query, dbConnector.GetConnectionObj());
            this.dbConnector.Open();

            SqlDataReader reader = this.dbConnector.Load(command);

            Dictionary<int, IProduct> products = new Dictionary<int, IProduct>();

            while (reader.Read())

            {
                Product product = new Product();
                product.BrandP = new Brand();
                product.CategoryObj = new Category();
                product.SubCategory = new SubCategory();

                product.ID = Convert.ToInt32(reader["PRODUCT_ID"]);
                product.ProductName = reader["PRODUCT_NAME"].ToString();
                product.SerialNumber = reader["SERIAL_NUMBER"].ToString();
                product.Description = reader["DESCRIPTION"].ToString();
                product.BrandP.Name = reader["BRAND_NAME"].ToString();
                product.CategoryObj.CategoryName = reader["CATEGORY_NAME"].ToString();
                product.SubCategory.SubCategoryName = reader["SUBCATEGORY_NAME"].ToString();
                product.EnergyClass = reader["ENERGY_CLASS"].ToString();
                product.Notes = reader["NOTES"].ToString();

                if (reader["DEPTH"] == DBNull.Value) { product.Depth = null; }
                else { product.Depth = (Decimal)reader["DEPTH"]; }

                if (reader["HEIGHT"] == DBNull.Value) { product.Height = null; }
                else { product.Height = (Decimal)reader["HEIGHT"]; }

                if (reader["WIDTH"] == DBNull.Value) { product.Width = null; }
                else { product.Width = (Decimal)reader["WIDTH"]; }

                if (reader["WEIGHT"] == DBNull.Value) { product.Weight = null; }
                else { product.Weight = (Decimal)reader["WEIGHT"]; }

                if (reader["POWER"] == DBNull.Value) { product.Power = null; }
                else { product.Power = (Decimal)reader["POWER"]; }

                if (reader["ENERGY_CONSUMPTION"] == DBNull.Value) { product.EnergyConsumption = null; }
                else { product.EnergyConsumption = (Decimal)reader["ENERGY_CONSUMPTION"]; }

                if (!reader.IsDBNull(reader.GetOrdinal("MANUFACTURING_DATE"))) { product.ManufacturingDate = (DateTime?)reader["MANUFACTURING_DATE"]; }
                else { product.ManufacturingDate = null; }

                object objResizedImage = reader["RESIZEDIMAGE"];
                object objImage = reader["IMAGE"];


                if (objResizedImage != DBNull.Value)
                {
                    byte[] resizeImageBytes = (byte[])reader["RESIZEDIMAGE"]; //->per il datagridview

                    using (MemoryStream ms = new MemoryStream(resizeImageBytes))
                    {
                        product.ResizedImage = Image.FromStream(ms);
                    }
                }

                if (objImage != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])reader["IMAGE"];

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        product.Image = Image.FromStream(ms);
                    }
                }
                products.Add(product.ID, product);
            }

            this.dbConnector.Close();

            return products;
        }

     
        public void Update(IProduct product)
        {
            string query = "UPDATE PRODUCTSTBL SET PRODUCT_NAME = @PRODUCT_NAME, DESCRIPTION = @DESCRIPTION, ID_BRAND = @ID_BRAND, CATEGORY_ID = @CATEGORY_ID,SUBCATEGORY_ID = @SUBCATEGORY_ID," +
                "MANUFACTURING_DATE = @MANUFACTURING_DATE, ENERGY_CLASS = @ENERGY_CLASS, HEIGHT = @HEIGHT, WIDTH = @WIDTH, WEIGHT = @WEIGHT, DEPTH = @DEPTH, SERIAL_NUMBER = @SERIAL_NUMBER," +
                "POWER = @POWER, ENERGY_CONSUMPTION = @ENERGY_CONSUMPTION, IMAGE = @IMAGE, RESIZEDIMAGE = @RESIZEDIMAGE WHERE PRODUCT_ID = @PRODUCT_ID"; //da completare*/

            SqlCommand command = new SqlCommand(query, dbConnector.GetConnectionObj());

            this.dbConnector.Open();

            command.Parameters.AddWithValue("@PRODUCT_ID", product.ID);
            command.Parameters.AddWithValue("@PRODUCT_NAME", product.ProductName);
            command.Parameters.AddWithValue("@DESCRIPTION", product.Description);
            command.Parameters.AddWithValue("@ID_BRAND", product.BrandP.ID); //se l'id non è settato sarà uguale a 0
            command.Parameters.AddWithValue("@CATEGORY_ID", product.CategoryObj.ID);
            command.Parameters.AddWithValue("@SUBCATEGORY_ID", product.SubCategory.ID);
            command.Parameters.AddWithValue("@ENERGY_CLASS", product.EnergyClass);
            command.Parameters.AddWithValue("@SERIAL_NUMBER", product.SerialNumber);
            command.Parameters.AddWithValue("@NOTES", product.Notes);

            if (product.ManufacturingDate != null) { command.Parameters.AddWithValue("@MANUFACTURING_DATE", product.ManufacturingDate.ToString()); }
            else { { command.Parameters.AddWithValue("@MANUFACTURING_DATE", DBNull.Value); } }

            if (product.Power == null) { command.Parameters.AddWithValue("@POWER", DBNull.Value); }
            else { command.Parameters.AddWithValue("@POWER", product.Power); }

            if (product.EnergyConsumption == null) { command.Parameters.AddWithValue("@ENERGY_CONSUMPTION", DBNull.Value); }
            else { command.Parameters.AddWithValue("@ENERGY_CONSUMPTION", product.EnergyConsumption); }

            if (product.Height == null) { command.Parameters.AddWithValue("@HEIGHT", DBNull.Value); }
            else { command.Parameters.AddWithValue("@HEIGHT", product.Height); }

            if (product.Width == null) { command.Parameters.AddWithValue("@WIDTH", DBNull.Value); }
            else { command.Parameters.AddWithValue("@WIDTH", product.Width); }

            if (product.Weight == null) { command.Parameters.AddWithValue("@WEIGHT", DBNull.Value); }
            else { command.Parameters.AddWithValue("@WEIGHT", product.Weight); }

            if (product.Depth == null) { command.Parameters.AddWithValue("@DEPTH", DBNull.Value); }
            else { command.Parameters.AddWithValue("@DEPTH", product.Depth); }

            if (product.Image != null) { command.Parameters.AddWithValue("@IMAGE", product.ConvertImageToArrayBytes()); }
            else { command.Parameters.AddWithValue("@IMAGE", System.Data.SqlTypes.SqlBinary.Null); }

            if (product.ResizedImage != null) { command.Parameters.AddWithValue("@RESIZEDIMAGE", product.ConvertResizeImageToArrayBytes()); }
            else { command.Parameters.AddWithValue("@RESIZEDIMAGE", System.Data.SqlTypes.SqlBinary.Null); }

            this.dbConnector.Update(command);
            this.dbConnector.Close();
        }

        public void Delete(IProduct product) 
        {
            string deleteProduct = "DELETE FROM PRODUCTSTBL WHERE PRODUCT_ID = @PRODUCT_ID";
            SqlCommand command = new SqlCommand(deleteProduct, dbConnector.GetConnectionObj());
            command.Parameters.AddWithValue("@PRODUCT_ID", product.ID);
            this.dbConnector.Open();

            this.dbConnector.Delete(command);

            this.dbConnector.Close();
        }
    }
}
