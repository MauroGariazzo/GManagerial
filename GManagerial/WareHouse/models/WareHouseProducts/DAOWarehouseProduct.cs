using GManagerial.DBConnectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.Products;
using System.IO;
using System.Drawing;

namespace GManagerial.WareHouse.models.WareHouseProducts
{
    internal class DAOWarehouseProduct
    {
        private DBConnector _dbConnector;
        public DAOWarehouseProduct(DBConnector dbConnector)
        {
            this._dbConnector = dbConnector;
        }

        public Dictionary<int, WareHouseProduct> GetAll(Warehouse wareHouse)
        {
            string query = "SELECT * FROM WAREHOUSEPRODUCT WP JOIN PRODUCTSTBL P ON WP.PRODUCT_ID = P.PRODUCT_ID WHERE WAREHOUSE_ID = @WAREHOUSE_ID";
            Dictionary<int, WareHouseProduct> wareHouseProducts = new Dictionary<int, WareHouseProduct>();
            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", wareHouse.ID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WareHouseProduct wareHouseProduct = new WareHouseProduct();
                            wareHouseProduct.Id = Convert.ToInt32(reader["ID"]);
                            wareHouseProduct = new WareHouseProduct()
                            {
                                Id = Convert.ToInt32(reader["PRODUCT_ID"]),
                                ProductName = Convert.ToString(reader["PRODUCT_NAME"]),
                                Description = Convert.ToString(reader["DESCRIPTION"])
                            };
                            wareHouseProduct.Stock = Convert.ToInt32(Convert.ToInt32(reader["STOCK"]));

                            object objResizedImage = reader["RESIZEDIMAGE"];

                            if (objResizedImage != DBNull.Value)
                            {
                                byte[] resizeImageBytes = (byte[])reader["RESIZEDIMAGE"]; //->per il datagridview

                                using (MemoryStream ms = new MemoryStream(resizeImageBytes))
                                {
                                    wareHouseProduct.ResizedImage = Image.FromStream(ms);
                                }
                            }

                            wareHouseProducts.Add(wareHouseProduct.Id, wareHouseProduct);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (_dbConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dbConnector.Close();
                }
            }
            _dbConnector.Close();
            return wareHouseProducts;
        }

        public void Insert(WareHouseProduct wareHouseProduct)
        {
            string query = "INSERT INTO WAREHOUSEPRODUCT(PRODUCT_ID, WAREHOUSE_ID,STOCK) VALUES(@PRODUCT_ID, @WAREHOUSE_ID, @STOCK)";

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", wareHouseProduct.ID);
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", wareHouseProduct.WarehouseProps.ID);
                    command.Parameters.AddWithValue("@STOCK", wareHouseProduct.Stock);

                    _dbConnector.Insert(command);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dbConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dbConnector.Close();
                }
            }

            _dbConnector.Close();
        }

        public void Update(WareHouseProduct wareHouseProduct, string query)
        {
            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@STOCK", wareHouseProduct.Stock);
                    command.Parameters.AddWithValue("@PRODUCT_ID", wareHouseProduct.ID);
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", wareHouseProduct.WarehouseProps.ID);

                    _dbConnector.Update(command);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dbConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dbConnector.Close();
                }
            }
            _dbConnector.Close();
        }

        public bool IsTheProductAlreadyInserted(WareHouseProduct wareHouseProduct)
        {
            string query = "SELECT * FROM WAREHOUSEPRODUCT WHERE PRODUCT_ID = @PRODUCT_ID AND WAREHOUSE_ID = @WAREHOUSE_ID";
            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", wareHouseProduct.ID);
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", wareHouseProduct.WarehouseProps.ID);

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        if (reader.HasRows)
                        {
                            _dbConnector.Close();
                            return true;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                /*if(_dbConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dbConnector.Close();
                }*/
            }
            _dbConnector.Close();
            return false;
        }

        public void Delete(Warehouse warehouse, WareHouseProduct wareHouseProduct)
        {
            string query = "DELETE FROM WAREHOUSEPRODUCT WHERE WAREHOUSE_ID = @WAREHOUSE_ID AND ID = @ID";

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse.ID);
                    command.Parameters.AddWithValue("@ID", wareHouseProduct.Id);
                    _dbConnector.Delete(command);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dbConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dbConnector.Close();
                }
            }
            _dbConnector.Close();
        }

        public void DeleteAllWarehouseProducts(Warehouse warehouse) 
        {
            string query = "DELETE FROM WAREHOUSEPRODUCT WHERE WAREHOUSE_ID = @WAREHOUSE_ID";

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse.ID);
                    _dbConnector.Delete(command);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dbConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dbConnector.Close();
                }
            }
            _dbConnector.Close();
        }

    }
}
