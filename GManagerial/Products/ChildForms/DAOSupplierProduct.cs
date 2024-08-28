using GManagerial.DBConnectors;
using GManagerial.WareHouse.ChildForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace GManagerial.Products.ChildForms.AddSupplier.models
{
    internal class DAOSupplierProduct : IDAOSupplierProduct
    {
        IDBConnector _dbConnector;
        public DAOSupplierProduct(IDBConnector _dbConnector)
        {
            this._dbConnector = _dbConnector;
        }

        public Dictionary<int, SupplierProduct> GetSelectedSuppliers(Product product_, string query)
        {
            Dictionary<int, SupplierProduct> supplierProducts = new Dictionary<int, SupplierProduct>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();
                    command.Parameters.AddWithValue("@PRODUCT_ID", product_.ID);

                    using (SqlDataReader reader = this._dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            SupplierProduct supplierProduct = new SupplierProduct();
                            Supplier supplier = new Supplier();
                            Product product = new Product();

                            supplierProduct.SupplierProps = supplier;

                            supplierProduct.SupplierProps.ID = Convert.ToInt32(reader["SUPPLIER_ID"]);
                            supplierProduct.Id = Convert.ToInt32(reader["PRODUCT_SUPPLIER_ID"]);
                            supplierProduct.SupplierProps.SupplierName = Convert.ToString(reader["SUPPLIER_NAME"]);

                            if (!product_.Equals(0))
                            {
                                supplierProduct.ProductProps = product;
                                //supplierProduct.ProductProps.ID = product_id;
                            }

                            string price = reader["SUPPLIER_PRICE"] == DBNull.Value ? null : Convert.ToString(reader["SUPPLIER_PRICE"]);
                            supplierProduct.SetSupplierPrice(price);

                            supplierProducts.Add(supplierProduct.SupplierProps.ID, supplierProduct);
                        }
                    }
                    this._dbConnector.Close();
                    return supplierProducts;
                }
            }
            catch (Exception ex)
            {
                if (this._dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    this._dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
            }
            return supplierProducts;
        }

        public void Insert(SupplierProduct supplierProduct, int id_product)
        {
            string query = "INSERT INTO PRODUCT_SUPPLIER(PRODUCT_ID,SUPPLIER_ID,SUPPLIER_PRICE) VALUES (@PRODUCT_ID, @SUPPLIER_ID,@SUPPLIER_PRICE)";
            //int idProductSupplier=0;
            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();
                    command.Parameters.AddWithValue("@PRODUCT_ID", id_product);
                    command.Parameters.AddWithValue("@SUPPLIER_ID", supplierProduct.SupplierProps.ID);

                    if (supplierProduct.GetSupplierPrice() == null)
                    { command.Parameters.AddWithValue("@SUPPLIER_PRICE", DBNull.Value); }

                    else { command.Parameters.AddWithValue("@SUPPLIER_PRICE", supplierProduct.GetSupplierPrice()); }

                    //idProductSupplier = Convert.ToInt32(command.ExecuteScalar());
                    //return idProductSupplier;
                    _dbConnector.Insert(command);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (_dbConnector.GetConnectionObj().State == System.Data.ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
            }

            _dbConnector.Close();
            //return idProductSupplier;
        }


        public void Delete(SupplierProduct supplierProduct, int id_product)
        {
            string query = "DELETE FROM PRODUCT_SUPPLIER WHERE SUPPLIER_ID = @SUPPLIER_ID AND PRODUCT_ID = @PRODUCT_ID";

            try
            {
                this._dbConnector.Open();
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@SUPPLIER_ID", supplierProduct.SupplierProps.ID);
                    command.Parameters.AddWithValue("@PRODUCT_ID", id_product);

                    this._dbConnector.Delete(command);
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
                return;
            }

        }

        public void Update(SupplierProduct supplierProduct)
        {
            string query = "UPDATE PRODUCT_SUPPLIER SET SUPPLIER_PRICE = @SUPPLIER_PRICE WHERE SUPPLIER_ID = @SUPPLIER_ID AND PRODUCT_ID = @PRODUCT_ID";

            try
            {
                this._dbConnector.Open();
                using (SqlCommand command = new SqlCommand(query, this._dbConnector.GetConnectionObj()))
                {
                    if (supplierProduct.GetSupplierPrice() != null)
                    {
                        command.Parameters.AddWithValue("@SUPPLIER_PRICE", supplierProduct.GetSupplierPrice());
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SUPPLIER_PRICE", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@SUPPLIER_ID", supplierProduct.SupplierProps.ID);
                    command.Parameters.AddWithValue("@PRODUCT_ID", supplierProduct.ProductProps.ID);


                    this._dbConnector.Update(command);
                    this._dbConnector.Close();

                }
            }

            catch (Exception ex)
            {
                if (this._dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    this._dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
            }
        }

        public Dictionary<int, SupplierProduct> GetUnselectedProducts(Product newproduct) //fornitori disponibili e non ancora abbinati al prodotto
        {
            Dictionary<int, SupplierProduct> product_suppliers = new Dictionary<int, SupplierProduct>();

            string query = @"SELECT S.*
                             FROM SUPPLIERSTBL S
                             LEFT JOIN
                             (SELECT SUPPLIER_ID
                             FROM PRODUCT_SUPPLIER
                             WHERE PRODUCT_ID = @PRODUCT_ID)
                             PS ON S.SUPPLIER_ID = PS.SUPPLIER_ID
                             WHERE PS.SUPPLIER_ID IS NULL AND S.SUPPLIER_ID != @ID";

            try
            {
                _dbConnector.Open();
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@ID", 1);
                    command.Parameters.AddWithValue("@PRODUCT_ID", newproduct.ID);

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            SupplierProduct supplierFiltered = new SupplierProduct();
                            Supplier supplier = new Supplier();
                            Product product = newproduct;

                            supplierFiltered.SupplierProps = supplier;
                            //supplierFiltered.Id = Convert.ToInt32(reader["PRODUCT_SUPPLIER_ID"]);
                            supplierFiltered.SupplierProps.ID = Convert.ToInt32(reader["SUPPLIER_ID"]);
                            supplierFiltered.SupplierProps.SupplierName = Convert.ToString(reader["SUPPLIER_NAME"]);
                            supplierFiltered.ProductProps = product;

                            product_suppliers.Add(supplierFiltered.SupplierProps.ID, supplierFiltered);
                        }
                    }
                }
                _dbConnector.Close();
                return product_suppliers;
            }

            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return product_suppliers;
            }
        }

        public Dictionary<int, Product> GetSupplierProducts(Supplier selectedsupplier)
        {
            Dictionary<int, Product> product_suppliers = new Dictionary<int, Product>();

            string query = @"SELECT * , B.BRAND_NAME, C.CATEGORY_NAME, SC.SUBCATEGORY_NAME, S.SUPPLIER_NAME
                                                        FROM PRODUCTSTBL P
                                                        JOIN PRODUCT_SUPPLIER PS
                                                        ON P.PRODUCT_ID = PS.PRODUCT_ID
                                                        JOIN SUPPLIERSTBL S
                                                        ON PS.SUPPLIER_ID = S.SUPPLIER_ID
                                                        JOIN BRANDTBL B
                                                        ON P.ID_BRAND = B.ID_BRAND
                                                        JOIN CATEGORIESTBL C
                                                        ON P.CATEGORY_ID = C.CATEGORY_ID
                                                        JOIN SUBCATEGORYTBL SC
                                                        ON P.SUBCATEGORY_ID = SC.SUBCATEGORY_ID
                                                        WHERE PS.SUPPLIER_ID = @SUPPLIER_ID";

            try
            {
                _dbConnector.Open();
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@SUPPLIER_ID", selectedsupplier.ID);

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

                            product_suppliers.Add(product.ID, product);
                        }
                    }
                }
                _dbConnector.Close();
                return product_suppliers;
            }

            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return product_suppliers;
            }
        }
    }
}
