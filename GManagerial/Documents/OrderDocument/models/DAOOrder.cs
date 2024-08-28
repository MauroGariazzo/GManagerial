using GManagerial.DBConnectors;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;


namespace GManagerial.Documents.OrderDocument.models
{
    internal class DAOOrder:IDAOOrder
    {
        IDBConnector _dbConnector;
        public DAOOrder(IDBConnector _dbConnector)
        {
            this._dbConnector = _dbConnector;
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            DAOOrderProduct daoOrderProduct = new DAOOrderProduct(_dbConnector);

            string query = "SELECT O.ID, O.SUPPLIER_FK, O.CREATIONDATE, O.TAXAMOUNT, O.TOTALDOCUMENTAMOUNT, O.TOTALDOCUMENTAMOUNTWITHTAX, " +
                           "S.SUPPLIER_NAME, S.REGION, S.PROVINCE, S.PROVINCESIGLE, S.CITY, S.ADDRESS, S.ZIP_CODE, S.RECIPIENT_CODE, " +
                           "S.PHONE, S.MOBILE, S.VAT, S.ID_TAX, S.EMAIL, S.PEC, S.NOTES " +
                           "FROM ORDERTBL O JOIN SUPPLIERSTBL S ON O.SUPPLIER_FK = S.SUPPLIER_ID";

            try
            {
                _dbConnector.Open();
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                TotalDocumentAmount = Convert.ToDecimal(reader["TOTALDOCUMENTAMOUNT"]),
                                TotalDocumentAmountWithTax = Convert.ToDecimal(reader["TOTALDOCUMENTAMOUNTWITHTAX"]),
                                CreationDate = Convert.ToDateTime(reader["CREATIONDATE"]),
                                TaxAmount = Convert.ToDecimal(reader["TAXAMOUNT"]),
                                Products = daoOrderProduct.GetOrderProducts(Convert.ToInt32(reader["ID"]))
                            };

                            Supplier supplier = new Supplier
                            {
                                ID = Convert.ToInt32(reader["SUPPLIER_FK"]),
                                SupplierName = Convert.ToString(reader["SUPPLIER_NAME"]),
                                Region = Convert.ToString(reader["REGION"]),
                                Province = Convert.ToString(reader["PROVINCE"]),
                                ProvinceSigle = Convert.ToString(reader["PROVINCESIGLE"]),
                                City = Convert.ToString(reader["CITY"]),
                                Address = Convert.ToString(reader["ADDRESS"]),
                                ZipCode = Convert.ToString(reader["ZIP_CODE"]),
                                RecipientCode = Convert.ToString(reader["RECIPIENT_CODE"]),
                                Telephone = Convert.ToString(reader["PHONE"]),
                                Mobile = Convert.ToString(reader["MOBILE"]),
                                Vat = Convert.ToString(reader["VAT"]),
                                IdTax = Convert.ToString(reader["ID_TAX"]),
                                Email = Convert.ToString(reader["EMAIL"]),
                                Pec = Convert.ToString(reader["PEC"]),
                                Notes = Convert.ToString(reader["NOTES"])
                            };

                            order.Supplier = supplier;
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _dbConnector.Close();
            }

            return orders;
        }


        public int Insert(Order order)
        {
            int idOrder = 0;
            string query = "INSERT INTO ORDERTBL(SUPPLIER_FK, CREATIONDATE, TOTALDOCUMENTAMOUNT, TOTALDOCUMENTAMOUNTWITHTAX, TAXAMOUNT)" +
                   " VALUES(@SUPPLIER_FK, @CREATIONDATE, @TOTALDOCUMENTAMOUNT, @TOTALDOCUMENTAMOUNTWITHTAX, @TAXAMOUNT);" +
                   " SELECT SCOPE_IDENTITY();";

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@SUPPLIER_FK", order.Supplier.ID);
                    command.Parameters.AddWithValue("@CREATIONDATE", order.CreationDate);
                    command.Parameters.AddWithValue("@TOTALDOCUMENTAMOUNT", order.TotalDocumentAmount);
                    command.Parameters.AddWithValue("@TOTALDOCUMENTAMOUNTWITHTAX", order.TotalDocumentAmount);
                    command.Parameters.AddWithValue("@TAXAMOUNT", order.TotalDocumentAmount);

                    idOrder = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);                
            }
            _dbConnector.Close();
            return idOrder;
        }
    }
}
