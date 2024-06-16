using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GManagerial.DBConnectors;


namespace GManagerial
{
    internal class DAOCustomer:IDAOCustomer
    {
        private IDBConnector _dbConnector;
        public DAOCustomer(IDBConnector dBConnector)
        {
            this._dbConnector = dBConnector;
        }
        public int Insert(Customer customer)
        {
            int idCustomer;

            string query = "INSERT INTO CUSTOMERTBL(NAME, ID_TAX, REGION, CITY, PROVINCE, ADDRESS, TELEPHONE, MOBILE, EMAIL, ZIP_CODE, PEC, NOTES, BIRTHDATE)"
                + "VALUES(@NAME, @ID_TAX, @REGION, @CITY, @PROVINCE, @ADDRESS, @TELEPHONE, @MOBILE, @EMAIL, @ZIP_CODE, @PEC, @NOTES, @BIRTHDATE);SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    this._dbConnector.Open();


                    command.Parameters.AddWithValue("@NAME", customer.Name);
                    command.Parameters.AddWithValue("@ID_TAX", customer.IdTax); //se l'id non è settato sarà uguale a 0
                    command.Parameters.AddWithValue("@REGION", customer.Region);
                    command.Parameters.AddWithValue("@PROVINCE", customer.Province);
                    command.Parameters.AddWithValue("@CITY", customer.City);
                    command.Parameters.AddWithValue("@ADDRESS", customer.Address);
                    command.Parameters.AddWithValue("@ZIP_CODE", customer.ZipCode);
                    command.Parameters.AddWithValue("@TELEPHONE", customer.Telephone);
                    command.Parameters.AddWithValue("@MOBILE", customer.Mobile);
                    command.Parameters.AddWithValue("@EMAIL", customer.Email);
                    command.Parameters.AddWithValue("@PEC", customer.Pec);
                    command.Parameters.AddWithValue("@NOTES", customer.Notes);
                    command.Parameters.AddWithValue("@BIRTHDATE", !string.IsNullOrEmpty(customer.BirthDate) ? (object)DateTime.Parse(customer.BirthDate) : DBNull.Value);


                    idCustomer = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                idCustomer = 0;
                return idCustomer;
            }
            
            _dbConnector.Close();

            return idCustomer;
        }

        public Dictionary<int, Customer> GetAll()
        {
            string query = "SELECT * FROM CUSTOMERTBL";

            Dictionary<int, Customer> customers = new Dictionary<int, Customer>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();

                            customer.ID = Convert.ToInt32(reader["CUSTOMER_ID"]);
                            customer.Name = Convert.ToString(reader["NAME"]);
                            customer.IdTax = Convert.ToString(reader["ID_TAX"]);
                            if (reader["BIRTHDATE"] != DBNull.Value) { customer.BirthDate = Convert.ToString(reader["BIRTHDATE"]).Substring(0, 10); }
                            else { customer.BirthDate = string.Empty; }
                            customer.Region = Convert.ToString(reader["REGION"]);
                            customer.Province = Convert.ToString(reader["PROVINCE"]);
                            customer.City = Convert.ToString(reader["CITY"]);
                            customer.Address = Convert.ToString(reader["ADDRESS"]);
                            customer.ZipCode = Convert.ToString(reader["ZIP_CODE"]);
                            customer.Telephone = Convert.ToString(reader["TELEPHONE"]);
                            customer.Mobile = Convert.ToString(reader["MOBILE"]);
                            customer.Notes = Convert.ToString(reader["NOTES"]);

                            customers.Add(customer.ID, customer);

                        }
                    }
                }
            }

            catch(Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }

                MessageBox.Show(ex.Message);
                return null;
            }

            _dbConnector.Close();
            return customers;
        }

        public void Update(Customer customer)
        {
            string query = "UPDATE CUSTOMERTBL SET NAME = @NAME, EMAIL = @EMAIL, ID_TAX = @ID_TAX, REGION = @REGION, PROVINCE = @PROVINCE, CITY = @CITY, ADDRESS = @ADDRESS, TELEPHONE = @TELEPHONE," +
                "MOBILE = @MOBILE, PEC = @PEC, NOTES = @NOTES, ZIP_CODE = @ZIP_CODE, BIRTHDATE = @BIRTHDATE WHERE CUSTOMER_ID = @CUSTOMER_ID";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {

                    _dbConnector.Open();

                    command.Parameters.AddWithValue("@CUSTOMER_ID", customer.ID);
                    command.Parameters.AddWithValue("@NAME", customer.Name);
                    command.Parameters.AddWithValue("@EMAIL", customer.Email);
                    command.Parameters.AddWithValue("@ID_TAX", customer.IdTax);
                    command.Parameters.AddWithValue("@REGION", customer.Region);
                    command.Parameters.AddWithValue("@PROVINCE", customer.Province);
                    command.Parameters.AddWithValue("@CITY", customer.City);
                    command.Parameters.AddWithValue("@ADDRESS", customer.Address);
                    command.Parameters.AddWithValue("@TELEPHONE", customer.Telephone);
                    command.Parameters.AddWithValue("@MOBILE", customer.Mobile);
                    command.Parameters.AddWithValue("@PEC", customer.Pec);
                    command.Parameters.AddWithValue("@NOTES", customer.Notes);
                    command.Parameters.AddWithValue("@ZIP_CODE", customer.ZipCode);
                    command.Parameters.AddWithValue("@BIRTHDATE", !string.IsNullOrEmpty(customer.BirthDate) ? (object)DateTime.Parse(customer.BirthDate) : DBNull.Value);

                    _dbConnector.Update(command);
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

            _dbConnector.Close();
        }

        public void Delete(Customer customer)
        {
            string query = "DELETE FROM CUSTOMERTBL WHERE CUSTOMER_ID = @CUSTOMER_ID";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();
                    command.Parameters.AddWithValue("@CUSTOMER_ID", customer.ID);
                    _dbConnector.Delete(command);
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
            _dbConnector.Close();
        }

        public Dictionary<int, Customer> GetCutstomersSearch(string searchValue, string region, string province, string city, string query)
        {
            Dictionary<int, Customer> customers = new Dictionary<int, Customer>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();

                    command.Parameters.AddWithValue("@SEARCHVALUE", $"%{searchValue}%");
                    command.Parameters.AddWithValue("@REGION", $"%{region}%");
                    command.Parameters.AddWithValue("@PROVINCE", $"%{province}%");
                    command.Parameters.AddWithValue("@CITY", $"%{city}%");

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();

                            customer.ID = Convert.ToInt32(reader["CUSTOMER_ID"]);
                            customer.Name = Convert.ToString(reader["NAME"]);
                            customer.IdTax = Convert.ToString(reader["ID_TAX"]);
                            if (reader["BIRTHDATE"] != DBNull.Value) { customer.BirthDate = Convert.ToString(reader["BIRTHDATE"]).Substring(0, 10); }
                            else { customer.BirthDate = string.Empty; }
                            customer.Region = Convert.ToString(reader["REGION"]);
                            customer.Province = Convert.ToString(reader["PROVINCE"]);
                            customer.City = Convert.ToString(reader["CITY"]);
                            customer.Address = Convert.ToString(reader["ADDRESS"]);
                            customer.ZipCode = Convert.ToString(reader["ZIP_CODE"]);
                            customer.Telephone = Convert.ToString(reader["TELEPHONE"]);
                            customer.Mobile = Convert.ToString(reader["MOBILE"]);
                            customer.Notes = Convert.ToString(reader["NOTES"]);

                            customers.Add(customer.ID, customer);
                        }
                    }
                }
                _dbConnector.Close();
                return customers;
            }

            catch(Exception ex) 
            {
                if(_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    MessageBox.Show(ex.Message);
                    _dbConnector.Close();
                    return customers;
                }
            }
            return customers;

        }
    }
}
