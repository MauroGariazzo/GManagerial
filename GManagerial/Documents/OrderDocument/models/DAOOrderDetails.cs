using GManagerial.DBConnectors;
using System;
using System.Data.SqlClient;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace GManagerial.Documents.OrderDocument.models
{
    internal class DAOOrderDetails
    {
        private DBConnector _dbConnector;

        public DAOOrderDetails(DBConnector dBConnector) 
        {
            _dbConnector = dBConnector;
        }
        public void Insert(OrderDetails orderDetails)
        {
            string query = "INSERT INTO ORDERDETAILSTBL(ORDER_FK, PRODUCT_FK) VALUES (@ORDER_FK, @PRODUCT_FK)";
            try
            {
                _dbConnector.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    sqlCommand.Parameters.AddWithValue("@ORDER_FK", orderDetails.FkOrder);
                    sqlCommand.Parameters.AddWithValue("@PRODUCT_FK", orderDetails.FkProduct);                    

                    _dbConnector.Insert(sqlCommand);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _dbConnector.Close();
        }
    }
}
