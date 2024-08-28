using GManagerial.DBConnectors;
using GManagerial.Products;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GManagerial.Documents.OrderDocument.models
{
    internal class DAOOrderProduct : IDAOOrderProduct
    {
        private IDBConnector _dbConnector;

        public DAOOrderProduct(IDBConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }
        public int Insert(OrderProduct product)
        {
            int idOrderProduct = 0;
            string query = "INSERT INTO ORDERPRODUCT(QUANTITY, NETPRICE, DISCOUNT, TAX, AMOUNT, PRODUCT_FK) VALUES (@QUANTITY, @NETPRICE, @DISCOUNT, @TAX, @AMOUNT, @PRODUCT_FK); SELECT SCOPE_IDENTITY();";

            try
            {
                _dbConnector.Open();
                using (SqlCommand command = new SqlCommand(query,_dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@QUANTITY", product.Quantity);
                    command.Parameters.AddWithValue("@NETPRICE", product.Price);
                    command.Parameters.AddWithValue("@DISCOUNT", product.Discount);
                    command.Parameters.AddWithValue("@TAX", product.Tax);
                    command.Parameters.AddWithValue("@PRODUCT_FK", product.ID);
                    command.Parameters.AddWithValue("@AMOUNT", product.Amount);

                    idOrderProduct = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _dbConnector.Close();
            return idOrderProduct;
        }

        public List<OrderProduct> GetOrderProducts(int orderId)
        {
            string query = "SELECT ";
            return new List<OrderProduct>();
        }

        public void Update(OrderProduct product) 
        {

        }

        public Dictionary<int, OrderProduct> GetAll()
        {
            return new Dictionary<int, OrderProduct>();
        }

        public void Delete(OrderProduct product)
        {
        }
    }
}
