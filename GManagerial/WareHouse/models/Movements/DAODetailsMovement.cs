using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GManagerial.WareHouse.models.WareHouseProducts;
using GManagerial.DBConnectors;
using System.Data.SqlClient;
using System.Windows.Forms;
using GManagerial.Products;
using System.IO;
using System.Drawing;

namespace GManagerial.WareHouse.models.Movements
{
    internal class DAODetailsMovement : IDAODetailsMovement
    {
        private IDBConnector _dBConnector;

        public DAODetailsMovement(IDBConnector dBConnector)
        {
            this._dBConnector = dBConnector;
        }
        public void Insert(WareHouseProduct wareHouseProduct, int movementId)
        {
            string query = "INSERT INTO MOVEMENTDETAILSTBL(MOVEMENT_ID, PRODUCT_ID, SUPPLIER_ID, WAREHOUSE_ID, QUANTITY, PRICE) " +
                "VALUES(@MOVEMENT_ID, @PRODUCT_ID, @SUPPLIER_ID, @WAREHOUSE_ID, @QUANTITY, @PRICE)";

            try
            {
                _dBConnector.Open();
                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@MOVEMENT_ID", movementId);
                    command.Parameters.AddWithValue("@PRODUCT_ID", wareHouseProduct.ID);
                    command.Parameters.AddWithValue("@SUPPLIER_ID", wareHouseProduct.SupplierProps.ID);
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", wareHouseProduct.WarehouseProps.ID);
                    command.Parameters.AddWithValue("@QUANTITY", wareHouseProduct.Stock);
                    decimal? price = wareHouseProduct.PriceSupplier is null ? 0.0M : wareHouseProduct.PriceSupplier;
                    command.Parameters.AddWithValue("@PRICE", price);

                    _dBConnector.Insert(command);
                }

            }

            catch (Exception ex)
            {
                if (_dBConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dBConnector.Close();
                }
                MessageBox.Show(ex.Message);
            }
            _dBConnector.Close();
        }

        public void Update(Product product) //id prodotto da settare a 0, qualora venisse cancellato e piuttosto che cancellare il prodotto sostituirlo con (prodotto cancellato o altro)
        {
            string query = "UPDATE MOVEMENTDETAILSTBL SET PRODUCT_ID = @ID WHERE PRODUCT_ID = @PRODUCT_ID";

            try
            {
                this._dBConnector.Open();
                SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj());

                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters.AddWithValue("@PRODUCT_ID", product.ID);
                this._dBConnector.Update(command);
            }

            catch (Exception ex)
            {
                if (_dBConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dBConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return;
            }

            this._dBConnector.Close();
        }

        public Dictionary<int, DetailsMovement> GetAll(Warehouse warehouse, Movement movement)
        {
            string query = @"SELECT DISTINCT MDT.MOVEMENTDETAILS_ID, MDT.QUANTITY,
                             WHM.CAUSAL, WHM.DATE, WHM.TYPE, WHM.MOVEMENT_ID, W.WAREHOUSE_ID, W.WAREHOUSE_NAME,
                             P.PRODUCT_ID, P.PRODUCT_NAME, P.RESIZEDIMAGE, P.DESCRIPTION,
                             S.SUPPLIER_ID, S.SUPPLIER_NAME,
                             MDT.PRICE
                             FROM MOVEMENTDETAILSTBL MDT
                             JOIN WAREHOUSE_MOVEMENTTBL WHM
                             ON WHM.MOVEMENT_ID = MDT.MOVEMENT_ID
                             JOIN  PRODUCTSTBL P
                             ON MDT.PRODUCT_ID = P.PRODUCT_ID
                             JOIN SUPPLIERSTBL S
                             ON MDT.SUPPLIER_ID = S.SUPPLIER_ID
                             JOIN WAREHOUSETBL W
                             ON MDT.WAREHOUSE_ID = W.WAREHOUSE_ID
                             JOIN WAREHOUSEPRODUCT WP
                             ON MDT.WAREHOUSE_ID = WP.WAREHOUSE_ID
                             WHERE MDT.WAREHOUSE_ID = @WAREHOUSE_ID
                             AND MDT.MOVEMENT_ID = @MOVEMENT_ID";

            Dictionary<int, DetailsMovement> detailsMovements = new Dictionary<int, DetailsMovement>();

            try
            {
                _dBConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse.ID);
                    command.Parameters.AddWithValue("@MOVEMENT_ID", movement.ID);

                    using (SqlDataReader reader = _dBConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            DetailsMovement detailsMovement = new DetailsMovement();
                            Product product = new Product();

                            detailsMovement.ID = Convert.ToInt32(reader["MOVEMENTDETAILS_ID"]);
                            detailsMovement.Quantity = Convert.ToInt32(reader["QUANTITY"]);

                            object objResizedImage = reader["RESIZEDIMAGE"];
                            if (objResizedImage != DBNull.Value)
                            {
                                byte[] resizeImageBytes = (byte[])reader["RESIZEDIMAGE"]; //->per il datagridview

                                using (MemoryStream ms = new MemoryStream(resizeImageBytes))
                                {
                                    product.ResizedImage = Image.FromStream(ms);
                                }
                            }

                            product.ID = Convert.ToInt32(reader["PRODUCT_ID"]);
                            product.ProductName = Convert.ToString(reader["PRODUCT_NAME"]);

                            detailsMovement.WarehouseproductProps = new WareHouseProduct();
                            //detailsMovement.WarehouseproductProps.ProductProps = product;
                            detailsMovement.WarehouseproductProps.PassProductMembers(product);                        
                            detailsMovement.WarehouseproductProps.SetPriceSupplier(Convert.ToString(reader["PRICE"]));

                            detailsMovement.SupplierProps = new Supplier() { ID = Convert.ToInt32(reader["SUPPLIER_ID"]), SupplierName = Convert.ToString(reader["SUPPLIER_NAME"]) };
                            detailsMovement.WarehouseProps = new Warehouse() { ID = Convert.ToInt32(reader["WAREHOUSE_ID"]), Warehouse_Name = Convert.ToString(reader["WAREHOUSE_NAME"]) };
                            detailsMovement.MovementType = Convert.ToString(reader["TYPE"]);
                            detailsMovement.MovementProps = new Movement() { ID = Convert.ToInt32(reader["MOVEMENT_ID"]), MovementType = Convert.ToString(reader["TYPE"]), DateMovement = Convert.ToDateTime(reader["DATE"]) };

                            detailsMovements.Add(detailsMovement.ID, detailsMovement);
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dBConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dBConnector.Close();
                }
            }
            _dBConnector.Close();
            return detailsMovements;
        }

        public void Delete(int id) //CANCELLARE TUTTI I MOVIMENTI DI UN PRODOTTO
        {
            string query = "DELETE FROM MOVEMENTDETAILSTBL WHERE MOVEMENT_ID = @MOVEMENT_ID";

            try
            {
                _dBConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@MOVEMENT_ID", id);
                    _dBConnector.Delete(command);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dBConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dBConnector.Close();
                }
            }
            _dBConnector.Close();
        }

        public void DeleteAllWarehouseDetailsMovement(Warehouse warehouse) //CANCELLARE TUTTI I MOVIMENTI DI UN PRODOTTO
        {
            string query = "DELETE FROM MOVEMENTDETAILSTBL WHERE WAREHOUSE_ID = @WAREHOUSE_ID";

            try
            {
                _dBConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", warehouse.ID);
                    _dBConnector.Delete(command);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dBConnector.GetConnectionObj().State.Equals(ConnectionState.Open))
                {
                    _dBConnector.Close();
                }
            }
            _dBConnector.Close();
        }
    }
}
