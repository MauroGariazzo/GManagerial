using GManagerial.DBConnectors;
using GManagerial.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GManagerial
{
    internal class DAOSupplier:IDAOSupplier
    {
        private IDBConnector _dbConnector;
        public DAOSupplier(IDBConnector dbConnector) 
        {
            this._dbConnector = dbConnector;
        }
        public int Insert(Supplier supplier)
        {
            int id_Supplier;

            string query = "IF NOT EXISTS (SELECT 1 FROM SUPPLIERSTBL WHERE SUPPLIER_NAME = @SUPPLIER_NAME) BEGIN " +
                "INSERT INTO SUPPLIERSTBL(SUPPLIER_NAME, REGION, PROVINCE, PROVINCESIGLE, CITY,ADDRESS, ZIP_CODE, RECIPIENT_CODE, PHONE, MOBILE, VAT, ID_TAX, EMAIL, PEC, NOTES)" +
                "VALUES(@SUPPLIER_NAME, @REGION, @PROVINCE, @PROVINCESIGLE, @CITY, @ADDRESS, @ZIP_CODE, @RECIPIENT_CODE, @PHONE, @MOBILE, @VAT, @ID_TAX, @EMAIL, @PEC, @NOTES);SELECT SCOPE_IDENTITY();END";

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {

                    command.Parameters.AddWithValue("@SUPPLIER_NAME", supplier.SupplierName);
                    if (!(supplier.Region is null))
                    {
                        command.Parameters.AddWithValue("@REGION", supplier.Region);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@REGION", DBNull.Value);
                    }

                    if (!(supplier.Province is null))
                    { command.Parameters.AddWithValue("@PROVINCE", supplier.Province);
                    }
                    else { command.Parameters.AddWithValue("@PROVINCE", DBNull.Value); }

                    if (!(supplier.ProvinceSigle is null)) { command.Parameters.AddWithValue("@PROVINCESIGLE", supplier.ProvinceSigle); }
                    else {command.Parameters.AddWithValue("@PROVINCESIGLE", DBNull.Value); }

                    if(!(supplier.City is null)) command.Parameters.AddWithValue("@CITY", supplier.City);
                    else { command.Parameters.AddWithValue("@CITY", DBNull.Value); }

                    if (!(supplier.Address is null)) { command.Parameters.AddWithValue("@ADDRESS", supplier.Address); }
                    else
                    {
                        command.Parameters.AddWithValue("@ADDRESS", DBNull.Value);
                    }


                    if (!(supplier.ZipCode is null)) { command.Parameters.AddWithValue("@ZIP_CODE", supplier.ZipCode); }
                    else
                    {
                        command.Parameters.AddWithValue("@ZIP_CODE", DBNull.Value);
                    }

                    if (!(supplier.RecipientCode is null))
                        command.Parameters.AddWithValue("@RECIPIENT_CODE", supplier.RecipientCode);
                    else
                    {
                        command.Parameters.AddWithValue("@RECIPIENT_CODE", DBNull.Value);
                    }


                    if (!(supplier.Email is null)) { command.Parameters.AddWithValue("@PHONE", supplier.Telephone); }
                    else
                    { command.Parameters.AddWithValue("@PHONE", DBNull.Value); }

                    if (!(supplier.Mobile is null))
                        command.Parameters.AddWithValue("@MOBILE", supplier.Mobile);
                    else
                    {
                        command.Parameters.AddWithValue("@MOBILE", DBNull.Value);
                    }

                    if (!(supplier.Vat is null))
                        command.Parameters.AddWithValue("@VAT", supplier.Vat);
                    else
                    {
                        command.Parameters.AddWithValue("@VAT", DBNull.Value);
                    }
                    if (!(supplier.IdTax is null))
                        command.Parameters.AddWithValue("@ID_TAX", supplier.IdTax);
                    else
                    {
                        command.Parameters.AddWithValue("@ID_TAX", DBNull.Value);
                    }

                    if (!(supplier.Email is null))
                    {
                        command.Parameters.AddWithValue("@EMAIL", supplier.Email);
                    }

                    else
                    {
                        command.Parameters.AddWithValue("@EMAIL", DBNull.Value);
                    }

                    if (!(supplier.Telephone is null))
                    { command.Parameters.AddWithValue("@PEC", supplier.Pec); }
                    else
                    {
                        command.Parameters.AddWithValue("@PEC", DBNull.Value);
                    }

                    if (!(supplier.Notes is null)) { command.Parameters.AddWithValue("@NOTES", supplier.Notes); }
                    else { command.Parameters.AddWithValue("@NOTES", DBNull.Value); }

                    id_Supplier = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch(Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }

                MessageBox.Show(ex.Message);
                id_Supplier = 0;
            }

            _dbConnector.Close();
            return id_Supplier;
        }

        public Dictionary<int, Supplier> GetAll()
        {
            string query = "SELECT * FROM SUPPLIERSTBL";

            Dictionary<int, Supplier> suppliers = new Dictionary<int, Supplier>();

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();

                            supplier.ID = Convert.ToInt32(reader["SUPPLIER_ID"]);
                            supplier.SupplierName = Convert.ToString(reader["SUPPLIER_NAME"]);
                            supplier.Region = Convert.ToString(reader["REGION"]);
                            supplier.Province = Convert.ToString(reader["PROVINCE"]);
                            supplier.ProvinceSigle = Convert.ToString(reader["PROVINCESIGLE"]);
                            supplier.City = Convert.ToString(reader["CITY"]);
                            supplier.Address = Convert.ToString(reader["ADDRESS"]);
                            supplier.ZipCode = Convert.ToString(reader["ZIP_CODE"]);
                            supplier.RecipientCode = Convert.ToString(reader["RECIPIENT_CODE"]);
                            supplier.Telephone = Convert.ToString(reader["PHONE"]);
                            supplier.Mobile = Convert.ToString(reader["MOBILE"]);
                            supplier.Vat = Convert.ToString(reader["VAT"]);
                            supplier.IdTax = Convert.ToString(reader["ID_TAX"]);
                            supplier.Email = Convert.ToString(reader["EMAIL"]);
                            supplier.Pec = Convert.ToString(reader["PEC"]);
                            supplier.Notes = Convert.ToString(reader["NOTES"]);

                            suppliers.Add(supplier.ID, supplier);
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
            }

            _dbConnector.Close();
            return suppliers;
        }
        public void Update(Supplier supplier)
        {
            string query = "UPDATE SUPPLIERSTBL SET SUPPLIER_NAME = @SUPPLIER_NAME, ADDRESS = @ADDRESS, CITY = @CITY, ZIP_CODE = @ZIP_CODE, RECIPIENT_CODE = @RECIPIENT_CODE, " +
                "PHONE = @PHONE, MOBILE = @MOBILE, VAT = @VAT, ID_TAX = @ID_TAX, EMAIL = @EMAIL, PEC = @PEC, NOTES = @NOTES, REGION = @REGION, PROVINCE = @PROVINCE, " +
                "PROVINCESIGLE = @PROVINCESIGLE WHERE SUPPLIER_ID = @SUPPLIER_ID";

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {

                    command.Parameters.AddWithValue("@SUPPLIER_ID", supplier.ID);
                    command.Parameters.AddWithValue("@SUPPLIER_NAME", supplier.SupplierName);
                    command.Parameters.AddWithValue("@REGION", supplier.Region);
                    command.Parameters.AddWithValue("@PROVINCE", supplier.Province);
                    command.Parameters.AddWithValue("@PROVINCESIGLE", supplier.ProvinceSigle);
                    command.Parameters.AddWithValue("@CITY", supplier.City);
                    command.Parameters.AddWithValue("@ADDRESS", supplier.Address);
                    command.Parameters.AddWithValue("@ZIP_CODE", supplier.ZipCode);
                    command.Parameters.AddWithValue("@RECIPIENT_CODE", supplier.RecipientCode);
                    command.Parameters.AddWithValue("@PHONE", supplier.Telephone);
                    command.Parameters.AddWithValue("@MOBILE", supplier.Mobile);
                    command.Parameters.AddWithValue("@VAT", supplier.Vat);
                    command.Parameters.AddWithValue("@ID_TAX", supplier.IdTax);
                    command.Parameters.AddWithValue("@EMAIL", supplier.Email);
                    command.Parameters.AddWithValue("@PEC", supplier.Pec);
                    command.Parameters.AddWithValue("@NOTES", supplier.Notes);

                    _dbConnector.Update(command);
                    _dbConnector.Close();
                }
            }

            catch(Exception ex) 
            {
                if(_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Delete(Supplier supplier, string query)
        {
            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@SUPPLIER_ID", supplier.ID);
                    _dbConnector.Delete(command);
                }
            }

            catch(Exception ex) 
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                
                MessageBox.Show(ex.Message);
            }

            _dbConnector.Close();
        }

        public Dictionary<int, Supplier> GetSuppliersSearch(string searchValue, string region, string province, string city, string query)
        {
            Dictionary<int, Supplier> suppliers = new Dictionary<int, Supplier>();

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@SEARCHVALUE", $"%{searchValue}%");
                    command.Parameters.AddWithValue("@REGION", $"%{region}%");
                    command.Parameters.AddWithValue("@PROVINCE", $"%{province}%");
                    command.Parameters.AddWithValue("@CITY", $"%{city}%");

                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();

                            supplier.ID = Convert.ToInt32(reader["SUPPLIER_ID"]);
                            supplier.SupplierName = Convert.ToString(reader["SUPPLIER_NAME"]);
                            supplier.Region = Convert.ToString(reader["REGION"]);
                            supplier.Province = Convert.ToString(reader["PROVINCE"]);
                            supplier.City = Convert.ToString(reader["CITY"]);
                            supplier.Address = Convert.ToString(reader["ADDRESS"]);
                            supplier.ZipCode = Convert.ToString(reader["ZIP_CODE"]);
                            supplier.RecipientCode = Convert.ToString(reader["RECIPIENT_CODE"]);
                            supplier.Telephone = Convert.ToString(reader["PHONE"]);
                            supplier.Mobile = Convert.ToString(reader["MOBILE"]);
                            supplier.Vat = Convert.ToString(reader["VAT"]);
                            supplier.IdTax = Convert.ToString(reader["ID_TAX"]);
                            supplier.Email = Convert.ToString(reader["EMAIL"]);
                            supplier.Pec = Convert.ToString(reader["PEC"]);
                            supplier.Notes = Convert.ToString(reader["NOTES"]);

                            suppliers.Add(supplier.ID, supplier);
                        }
                    }
                }
                _dbConnector.Close();
                return suppliers;
            }
               

            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return suppliers;

            }

        }

    }
}
