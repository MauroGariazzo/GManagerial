using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.DBConnectors;

namespace GManagerial.Products.SellPrices
{
    internal class DAOSellPrice:IDAOSellPrice
    {
        private IDBConnector _dBConnector;
        public DAOSellPrice(IDBConnector dBConnector) 
        {
            this._dBConnector = dBConnector;
        }
        public Dictionary<string, SellPrice> GetAll(Product product)
        {
            string query = "SELECT * FROM SELLPRODUCTPRICES WHERE PRODUCT_ID = @PRODUCTID";
            Dictionary<string, SellPrice> prices = new Dictionary<string, SellPrice>();

            try
            {
                _dBConnector.Open();
                using(SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@PRODUCTID", product.ID);

                    using(SqlDataReader reader = _dBConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            SellPrice price = new SellPrice();
                            price.Id = Convert.ToInt32(reader["SELLPRICE_ID"]);
                            price.ProductId = Convert.ToInt32(reader["PRODUCT_ID"]);
                            price.SupplierId = Convert.ToInt32(reader["SUPPLIER_ID"]);
                            price.ListPrice = Convert.ToString(reader["LISTPRICE"]);
                            price.SetPrice(Convert.ToString(reader["PRICE"]));

                            prices.Add((price.ListPrice), price);
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (_dBConnector.GetConnectionObj().State == System.Data.ConnectionState.Open)
                {
                    _dBConnector.Close();
                }
            }

            _dBConnector.Close();
            return prices;
        }
        public void Insert(SellPrice sellprice)
        {
            string query = "INSERT INTO SELLPRODUCTPRICES(PRODUCT_ID,SUPPLIER_ID,PRICE,LISTPRICE) VALUES(@PRODUCTID,@SUPPLIERID,@PRICE,@LISTPRICE)";

            try
            {
                _dBConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@PRODUCTID", sellprice.ProductId);
                    command.Parameters.AddWithValue("@SUPPLIERID", sellprice.SupplierId);
                    command.Parameters.AddWithValue("@PRICE", sellprice.GetPrice());
                    command.Parameters.AddWithValue("@LISTPRICE", sellprice.ListPrice);

                    _dBConnector.Insert(command);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                if(_dBConnector.GetConnectionObj().State == System.Data.ConnectionState.Open)
                {
                    _dBConnector.Close();
                }
            }
            _dBConnector.Close();
        }

        public void Update(SellPrice sellprice) 
        {
            string query = "UPDATE SELLPRODUCTPRICES SET PRODUCT_ID = @PRODUCTID, SUPPLIER_ID = @SUPPLIERID, PRICE = @PRICE, LISTPRICE = @LISTPRICE WHERE SELLPRICE_ID = @SELLPRICEID";

            try
            {
                _dBConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@PRODUCTID", sellprice.ProductId);
                    command.Parameters.AddWithValue("@SUPPLIERID", sellprice.SupplierId);
                    command.Parameters.AddWithValue("@PRICE", sellprice.GetPrice());
                    command.Parameters.AddWithValue("@LISTPRICE", sellprice.ListPrice);
                    command.Parameters.AddWithValue("@SELLPRICEID", sellprice.Id);


                    _dBConnector.Update(command);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (_dBConnector.GetConnectionObj().State == System.Data.ConnectionState.Open)
                {
                    _dBConnector.Close();
                }
            }      
            _dBConnector.Close();
        }

        public void Delete(int productId, int supplierId) 
        {
            string query = "DELETE FROM SELLPRODUCTPRICES WHERE PRODUCT_ID = @PRODUCTID AND SUPPLIER_ID = @SUPPLIERID";

            try
            {
                _dBConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dBConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@PRODUCTID", productId);
                    command.Parameters.AddWithValue("@SUPPLIERID", supplierId);

                    _dBConnector.Delete(command);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (_dBConnector.GetConnectionObj().State == System.Data.ConnectionState.Open)
                {
                    _dBConnector.Close();
                }
            }
            _dBConnector.Close();
        }
    }
}
