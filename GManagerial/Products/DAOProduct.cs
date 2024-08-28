using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GManagerial.WareHouse.models;
using GManagerial.DBConnectors;
using GManagerial.Products.ChildForms;

namespace GManagerial.Products
{
    internal class DAOProduct : IDAOProduct
    {
        IDBConnector _dbConnector;
        public DAOProduct(IDBConnector _dbConnector)
        {
            this._dbConnector = _dbConnector;
        }
        public int Insert(Product product)
        {
            int idProduct;

            string query = "IF NOT EXISTS (SELECT 1 FROM PRODUCTSTBL WHERE PRODUCT_NAME = @PRODUCT_NAME) BEGIN " +
                "INSERT INTO PRODUCTSTBL(PRODUCT_NAME,DESCRIPTION,ID_BRAND,CATEGORY_ID,SUBCATEGORY_ID,MANUFACTURING_DATE,ENERGY_CLASS, SERIAL_NUMBER,POWER,ENERGY_CONSUMPTION,NOTES,HEIGHT,WIDTH," +
                "WEIGHT,DEPTH,IMAGE, RESIZEDIMAGE, LASTSUPPLIERSELECTED) VALUES(@PRODUCT_NAME,@DESCRIPTION,@ID_BRAND,@CATEGORY_ID,@SUBCATEGORY_ID, @PRODUCT_MANUFACTURINGDATE,@PRODUCT_ENERGYCLASS," +
                "@PRODUCT_SERIALNUMBER,@PRODUCT_POWER,@PRODUCT_ENERGYCONSUMPTION,@PRODUCT_NOTES,@PRODUCT_HEIGHT,@PRODUCT_WIDTH,@PRODUCT_WEIGHT, @PRODUCT_DEPTH, @IMAGE, @RESIZED_IMAGE, " +
                "@LASTSUPPLIERSELECTED);SELECT SCOPE_IDENTITY();END";

            try
            {
                this._dbConnector.Open();
                SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());

                command.Parameters.AddWithValue("@PRODUCT_NAME", product.ProductName);
                command.Parameters.AddWithValue("@DESCRIPTION", product.Description);
                command.Parameters.AddWithValue("@ID_BRAND", product.BrandP.ID); //se l'id non è settato sarà uguale a 0
                command.Parameters.AddWithValue("@CATEGORY_ID", product.CategoryObj.ID);
                command.Parameters.AddWithValue("@SUBCATEGORY_ID", product.SubCategory.ID);

                if (product.ManufacturingDate != string.Empty) { command.Parameters.AddWithValue("@PRODUCT_MANUFACTURINGDATE", product.ManufacturingDate); }
                else { { command.Parameters.AddWithValue("@PRODUCT_MANUFACTURINGDATE", DBNull.Value); } }

                command.Parameters.AddWithValue("@PRODUCT_ENERGYCLASS", product.EnergyClass);
                command.Parameters.AddWithValue("@PRODUCT_SERIALNUMBER", product.SerialNumber);

                if (product.GetPower == null) { command.Parameters.AddWithValue("@PRODUCT_POWER", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_POWER", product.GetPower); }


                if (product.GetEnergyConsumption == null) { command.Parameters.AddWithValue("@PRODUCT_ENERGYCONSUMPTION", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_ENERGYCONSUMPTION", product.GetEnergyConsumption); }


                if (product.GetHeight == null) { command.Parameters.AddWithValue("@PRODUCT_HEIGHT", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_HEIGHT", product.GetHeight); }


                if (product.GetWidth == null) { command.Parameters.AddWithValue("@PRODUCT_WIDTH", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_WIDTH", product.GetWidth); }


                if (product.GetWeight == null) { command.Parameters.AddWithValue("@PRODUCT_WEIGHT", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_WEIGHT", product.GetWeight); }


                if (product.GetDepth == null) { command.Parameters.AddWithValue("@PRODUCT_DEPTH", DBNull.Value); }
                else { command.Parameters.AddWithValue("@PRODUCT_DEPTH", product.GetDepth); }

                if (product.Image != null) { command.Parameters.AddWithValue("@IMAGE", product.ConvertImageToArrayBytes()); }
                else { command.Parameters.AddWithValue("@IMAGE", System.Data.SqlTypes.SqlBinary.Null); }

                if (product.ResizedImage != null) { command.Parameters.AddWithValue("@RESIZED_IMAGE", product.ConvertResizeImageToArrayBytes()); }
                else { command.Parameters.AddWithValue("@RESIZED_IMAGE", System.Data.SqlTypes.SqlBinary.Null); }

                command.Parameters.AddWithValue("@PRODUCT_NOTES", product.Notes);

                command.Parameters.AddWithValue("@LASTSUPPLIERSELECTED", product.LastSupplierSelected);

                idProduct = Convert.ToInt32(command.ExecuteScalar());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                idProduct = 0;
            }
            _dbConnector.Close();
            return idProduct;
        }

        public Dictionary<int, Product> GetAll()
        {
            string query = "SELECT * , B.BRAND_NAME, C.CATEGORY_NAME, S.SUBCATEGORY_NAME FROM PRODUCTSTBL P JOIN BRANDTBL B ON P.ID_BRAND = B.ID_BRAND JOIN CATEGORIESTBL C ON " +
                "C.CATEGORY_ID = P.CATEGORY_ID JOIN SUBCATEGORYTBL S ON S.SUBCATEGORY_ID = P.SUBCATEGORY_ID";

            Dictionary<int, Product> products = new Dictionary<int, Product>();

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    using (SqlDataReader reader = this._dbConnector.Load(command))
                    {
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
                            product.LastSupplierSelected = Convert.ToInt32(reader["LASTSUPPLIERSELECTED"]);

                            if (reader["DEPTH"] == DBNull.Value) { product.SetDepth(string.Empty); }
                            else { product.SetDepth(Convert.ToString(reader["DEPTH"])); }

                            if (reader["HEIGHT"] == DBNull.Value) { product.SetHeight(string.Empty); }
                            else { product.SetHeight(Convert.ToString(reader["HEIGHT"])); }

                            if (reader["WIDTH"] == DBNull.Value) { product.SetWidth(string.Empty); }
                            else { product.SetWidth(Convert.ToString(reader["WIDTH"])); }

                            if (reader["WEIGHT"] == DBNull.Value) { product.SetWeight(string.Empty); }
                            else { product.SetWeight(Convert.ToString(reader["WEIGHT"])); }

                            if (reader["POWER"] == DBNull.Value) { product.SetPower(string.Empty); }
                            else { product.SetPower(Convert.ToString(reader["POWER"])); }

                            if (reader["ENERGY_CONSUMPTION"] == DBNull.Value) { product.SetEnergyConsumption(string.Empty); }
                            else { product.SetEnergyConsumption(Convert.ToString(reader["ENERGY_CONSUMPTION"])); }

                            if (!reader.IsDBNull(reader.GetOrdinal("MANUFACTURING_DATE"))) { product.ManufacturingDate = Convert.ToString(reader["MANUFACTURING_DATE"]).Substring(0, 10); }
                            else { product.ManufacturingDate = string.Empty; }

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
                    }
                    this._dbConnector.Close();
                }
            }

            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return products;
            }
            _dbConnector.Close();
            return products;
        }
        public void Update(Product product)
        {
            string query = "UPDATE PRODUCTSTBL SET PRODUCT_NAME = @PRODUCT_NAME, DESCRIPTION = @DESCRIPTION, ID_BRAND = @ID_BRAND, CATEGORY_ID = @CATEGORY_ID,SUBCATEGORY_ID = @SUBCATEGORY_ID," +
                "MANUFACTURING_DATE = @MANUFACTURING_DATE, ENERGY_CLASS = @ENERGY_CLASS, HEIGHT = @HEIGHT, WIDTH = @WIDTH, WEIGHT = @WEIGHT, DEPTH = @DEPTH, SERIAL_NUMBER = @SERIAL_NUMBER," +
                "POWER = @POWER, ENERGY_CONSUMPTION = @ENERGY_CONSUMPTION, IMAGE = @IMAGE, RESIZEDIMAGE = @RESIZEDIMAGE, NOTES = @NOTES, LASTSUPPLIERSELECTED = @LASTSUPPLIERSELECTED" +
                " WHERE PRODUCT_ID = @PRODUCT_ID"; //da completare*/

            try
            {
                this._dbConnector.Open();
                SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());

                command.Parameters.AddWithValue("@PRODUCT_ID", product.ID);
                command.Parameters.AddWithValue("@PRODUCT_NAME", product.ProductName);
                command.Parameters.AddWithValue("@DESCRIPTION", product.Description);
                command.Parameters.AddWithValue("@ID_BRAND", product.BrandP.ID); //se l'id non è settato sarà uguale a 0
                command.Parameters.AddWithValue("@CATEGORY_ID", product.CategoryObj.ID);
                command.Parameters.AddWithValue("@SUBCATEGORY_ID", product.SubCategory.ID);
                command.Parameters.AddWithValue("@ENERGY_CLASS", product.EnergyClass);
                command.Parameters.AddWithValue("@SERIAL_NUMBER", product.SerialNumber);
                command.Parameters.AddWithValue("@NOTES", product.Notes);


                if (product.ManufacturingDate != string.Empty) { command.Parameters.AddWithValue("@MANUFACTURING_DATE", product.ManufacturingDate); }
                else { { command.Parameters.AddWithValue("@MANUFACTURING_DATE", DBNull.Value); } }

                if (product.GetPower == null) { command.Parameters.AddWithValue("@POWER", DBNull.Value); }
                else { command.Parameters.AddWithValue("@POWER", product.GetPower); }
                if (product.GetEnergyConsumption == null) { command.Parameters.AddWithValue("@ENERGY_CONSUMPTION", DBNull.Value); }
                else { command.Parameters.AddWithValue("@ENERGY_CONSUMPTION", product.GetEnergyConsumption); }

                if (product.GetHeight == null) { command.Parameters.AddWithValue("@HEIGHT", DBNull.Value); }
                else { command.Parameters.AddWithValue("@HEIGHT", product.GetHeight); }


                if (product.GetWidth == null) { command.Parameters.AddWithValue("@WIDTH", DBNull.Value); }
                else { command.Parameters.AddWithValue("@WIDTH", product.GetWidth); }

                if (product.GetWeight == null) { command.Parameters.AddWithValue("@WEIGHT", DBNull.Value); }
                else { command.Parameters.AddWithValue("@WEIGHT", product.GetWeight); }

                if (product.GetDepth == null) { command.Parameters.AddWithValue("@DEPTH", DBNull.Value); }
                else { command.Parameters.AddWithValue("@DEPTH", product.GetDepth); }

                if (product.Image != null) { command.Parameters.AddWithValue("@IMAGE", product.ConvertImageToArrayBytes()); }
                else { command.Parameters.AddWithValue("@IMAGE", System.Data.SqlTypes.SqlBinary.Null); }

                if (product.ResizedImage != null) { command.Parameters.AddWithValue("@RESIZEDIMAGE", product.ConvertResizeImageToArrayBytes()); }
                else { command.Parameters.AddWithValue("@RESIZEDIMAGE", System.Data.SqlTypes.SqlBinary.Null); }
                command.Parameters.AddWithValue("@LASTSUPPLIERSELECTED", product.LastSupplierSelected);


                this._dbConnector.Update(command);
            }

            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return;
            }

            this._dbConnector.Close();
        }

        public void Delete(Product product, string queryDelete)
        {
            try
            {
                this._dbConnector.Open();
                using (SqlCommand command = new SqlCommand(queryDelete, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", product.ID);
                    this._dbConnector.Delete(command);
                }
            }


            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return;
            }

            this._dbConnector.Close();
        }

        public Dictionary<int, Product> GetProductsSearch(string searchValue, string category, string subcategory, string brand, string query, Supplier supplier)
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>();

            try
            {
                this._dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    if (!(supplier is null))
                    {
                        command.Parameters.AddWithValue("@SUPPLIER_ID", supplier.ID);
                    }

                    command.Parameters.AddWithValue("@SEARCHVALUE", $"%{searchValue}%");
                    command.Parameters.AddWithValue("@CATEGORY_NAME", $"%{category}%");
                    command.Parameters.AddWithValue("@SUBCATEGORY_NAME", $"%{subcategory}%");
                    command.Parameters.AddWithValue("@BRAND_NAME", $"%{brand}%");

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
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

                            if (reader["DEPTH"] == DBNull.Value) { product.SetDepth(string.Empty); }
                            else { product.SetDepth(Convert.ToString(reader["DEPTH"])); }

                            if (reader["HEIGHT"] == DBNull.Value) { product.SetHeight(string.Empty); }
                            else { product.SetHeight(Convert.ToString(reader["HEIGHT"])); }

                            if (reader["WIDTH"] == DBNull.Value) { product.SetWidth(string.Empty); }
                            else { product.SetWidth(Convert.ToString(reader["WIDTH"])); }

                            if (reader["WEIGHT"] == DBNull.Value) { product.SetWeight(string.Empty); }
                            else { product.SetWeight(Convert.ToString(reader["WEIGHT"])); }

                            if (reader["POWER"] == DBNull.Value) { product.SetPower(string.Empty); }
                            else { product.SetPower(Convert.ToString(reader["POWER"])); }

                            if (reader["ENERGY_CONSUMPTION"] == DBNull.Value) { product.SetEnergyConsumption(string.Empty); }
                            else { product.SetEnergyConsumption(Convert.ToString(reader["ENERGY_CONSUMPTION"])); }

                            if (!reader.IsDBNull(reader.GetOrdinal("MANUFACTURING_DATE"))) { product.ManufacturingDate = Convert.ToString(reader["MANUFACTURING_DATE"]).Substring(0, 10); }
                            else { product.ManufacturingDate = string.Empty; }

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
                    }
                }
            }


            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return products;

            }
            _dbConnector.Close();
            return products;
        }


        public Dictionary<int, Product> GetUnmatchedProductsInWareHouse(Warehouse warehouse) //prodotti che non si trovano in alcun magazzino
        {
            string query = "SELECT *, B.BRAND_NAME, C.CATEGORY_NAME, S.SUBCATEGORY_NAME FROM PRODUCTSTBL P LEFT JOIN WAREHOUSEPRODUCT WP ON P.PRODUCT_ID = WP.PRODUCT_ID " +
                "JOIN BRANDTBL B ON P.ID_BRAND = B.ID_BRAND JOIN CATEGORIESTBL C ON P.CATEGORY_ID = C.CATEGORY_ID JOIN SUBCATEGORYTBL S ON P.SUBCATEGORY_ID = S.SUBCATEGORY_ID" +
                " WHERE WP.WAREHOUSE_ID != @WAREHOUSE_ID OR WP.PRODUCT_ID IS NULL";


            Dictionary<int, Product> products = new Dictionary<int, Product>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse.ID);


                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
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

                            if (product.ManufacturingDate != null) { command.Parameters.AddWithValue("@MANUFACTURING_DATE", product.ManufacturingDate.ToString()); }
                            else { { command.Parameters.AddWithValue("@MANUFACTURING_DATE", DBNull.Value); } }
                            if (reader["DEPTH"] == DBNull.Value) { product.SetDepth(string.Empty); }
                            else { product.SetDepth(Convert.ToString(reader["DEPTH"])); }

                            if (reader["HEIGHT"] == DBNull.Value) { product.SetHeight(string.Empty); }
                            else { product.SetHeight(Convert.ToString(reader["HEIGHT"])); }

                            if (reader["WIDTH"] == DBNull.Value) { product.SetWidth(string.Empty); }
                            else { product.SetWidth(Convert.ToString(reader["WIDTH"])); }

                            if (reader["WEIGHT"] == DBNull.Value) { product.SetWeight(string.Empty); }
                            else { product.SetWeight(Convert.ToString(reader["WEIGHT"])); }

                            if (reader["POWER"] == DBNull.Value) { product.SetPower(string.Empty); }
                            else { product.SetPower(Convert.ToString(reader["POWER"])); }

                            if (reader["ENERGY_CONSUMPTION"] == DBNull.Value) { product.SetEnergyConsumption(string.Empty); }
                            else { product.SetEnergyConsumption(Convert.ToString(reader["ENERGY_CONSUMPTION"])); }

                            if (!reader.IsDBNull(reader.GetOrdinal("MANUFACTURING_DATE"))) { product.ManufacturingDate = Convert.ToString(reader["MANUFACTURING_DATE"]).Substring(0, 10); }
                            else { product.ManufacturingDate = string.Empty; }

                            if (product.Image != null) { command.Parameters.AddWithValue("@IMAGE", product.ConvertImageToArrayBytes()); }
                            else { command.Parameters.AddWithValue("@IMAGE", System.Data.SqlTypes.SqlBinary.Null); }
                            object objResizedImage = reader["IMAGE"];

                            if (objResizedImage != DBNull.Value)
                            {
                                byte[] resizeImageBytes = (byte[])reader["IMAGE"]; //->per il datagridview

                                using (MemoryStream ms = new MemoryStream(resizeImageBytes))
                                {
                                    product.ResizedImage = Image.FromStream(ms);
                                }
                            }

                            products.Add(product.ID, product);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
            }

            _dbConnector.Close();
            return products;
        }

        public Dictionary<int, Product> GetWareHouseProducts(Warehouse warehouse) //prodotti che si trovano in quel determinato magazzino
        {

            string query = "SELECT *, B.BRAND_NAME, C.CATEGORY_NAME, S.SUBCATEGORY_NAME, WP.STOCK FROM PRODUCTSTBL P JOIN WAREHOUSEPRODUCT WP ON P.PRODUCT_ID = WP.PRODUCT_ID " +
                "JOIN BRANDTBL B ON P.ID_BRAND = B.ID_BRAND JOIN CATEGORIESTBL C ON P.CATEGORY_ID = C.CATEGORY_ID JOIN SUBCATEGORYTBL S ON P.SUBCATEGORY_ID = S.SUBCATEGORY_ID" +
                " WHERE WP.WAREHOUSE_ID = @WAREHOUSE_ID";

            Dictionary<int, Product> products = new Dictionary<int, Product>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse.ID);

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
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
                            product.Stock = Convert.ToInt32(reader["STOCK"]);

                            if (reader["DEPTH"] == DBNull.Value) { product.SetDepth(string.Empty); }
                            else { product.SetDepth(Convert.ToString(reader["DEPTH"])); }

                            if (reader["HEIGHT"] == DBNull.Value) { product.SetHeight(string.Empty); }
                            else { product.SetHeight(Convert.ToString(reader["HEIGHT"])); }

                            if (reader["WIDTH"] == DBNull.Value) { product.SetWidth(string.Empty); }
                            else { product.SetWidth(Convert.ToString(reader["WIDTH"])); }

                            if (reader["WEIGHT"] == DBNull.Value) { product.SetWeight(string.Empty); }
                            else { product.SetWeight(Convert.ToString(reader["WEIGHT"])); }

                            if (reader["POWER"] == DBNull.Value) { product.SetPower(string.Empty); }
                            else { product.SetPower(Convert.ToString(reader["POWER"])); }

                            if (reader["ENERGY_CONSUMPTION"] == DBNull.Value) { product.SetEnergyConsumption(string.Empty); }
                            else { product.SetEnergyConsumption(Convert.ToString(reader["ENERGY_CONSUMPTION"])); }

                            if (!reader.IsDBNull(reader.GetOrdinal("MANUFACTURING_DATE"))) { product.ManufacturingDate = Convert.ToString(reader["MANUFACTURING_DATE"]).Substring(0, 10); }
                            else { product.ManufacturingDate = string.Empty; }

                            object objResizedImage = reader["RESIZEDIMAGE"];

                            if (objResizedImage != DBNull.Value)
                            {
                                byte[] resizeImageBytes = (byte[])reader["RESIZEDIMAGE"]; //->per il datagridview

                                using (MemoryStream ms = new MemoryStream(resizeImageBytes))
                                {
                                    product.ResizedImage = Image.FromStream(ms);
                                }
                            }

                            products.Add(product.ID, product);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
            }

            _dbConnector.Close();
            return products;
        }


    }
}
