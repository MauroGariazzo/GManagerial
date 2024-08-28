using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.DBConnectors;


namespace GManagerial.WareHouse.models
{
    internal class DAOWareHouse : IDAOWareHouse
    {
        private IDBConnector _dbConnector;
        public DAOWareHouse(IDBConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public int Insert(Warehouse wareHouse)
        {
            string query = "INSERT INTO WAREHOUSETBL(WAREHOUSE_NAME, REGION, PROVINCE, CITY, ADDRESS, ZIP_CODE, DESCRIPTION) VALUES(@WAREHOUSE_NAME, @REGION, @PROVINCE, @CITY," +
                " @ADDRESS, @ZIP_CODE, @DESCRIPTION);SELECT SCOPE_IDENTITY();";
            int id_warehouse = 0;

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();

                    command.Parameters.AddWithValue("@WAREHOUSE_NAME", wareHouse.Warehouse_Name);
                    command.Parameters.AddWithValue("@REGION", wareHouse.Region);
                    command.Parameters.AddWithValue("@PROVINCE", wareHouse.Province);
                    command.Parameters.AddWithValue("@CITY", wareHouse.City);
                    command.Parameters.AddWithValue("@ADDRESS", wareHouse.Address);
                    command.Parameters.AddWithValue("@ZIP_CODE", wareHouse.ZipCode);
                    command.Parameters.AddWithValue("@DESCRIPTION", wareHouse.Description);

                    id_warehouse = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch (Exception ex)
            {
                if (_dbConnector.GetConnectionObj().State == ConnectionState.Open)
                {
                    _dbConnector.Close();
                }
                MessageBox.Show(ex.Message);
                return id_warehouse;
            }

            _dbConnector.Close();
            return id_warehouse;
        }

        public Dictionary<int, Warehouse> GetAll()
        {
            string query = "SELECT * FROM WAREHOUSETBL";
            Dictionary<int, Warehouse> warehouses = new Dictionary<int, Warehouse>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();
                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            Warehouse wareHouse = new Warehouse();

                            wareHouse.ID = Convert.ToInt32(reader["WAREHOUSE_ID"]);
                            wareHouse.Warehouse_Name = Convert.ToString(reader["WAREHOUSE_NAME"]);
                            wareHouse.Region = Convert.ToString(reader["REGION"]);
                            wareHouse.Province = Convert.ToString(reader["PROVINCE"]);
                            wareHouse.City = Convert.ToString(reader["CITY"]);
                            wareHouse.Address = Convert.ToString(reader["ADDRESS"]);
                            wareHouse.ZipCode = Convert.ToString(reader["ZIP_CODE"]);
                            wareHouse.Description = Convert.ToString(reader["DESCRIPTION"]);

                            warehouses.Add(wareHouse.ID, wareHouse);
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
                return warehouses;
            }
            _dbConnector.Close();
            return warehouses;
        }

        public void Update(Warehouse wareHouse)
        {
            string query = "UPDATE WAREHOUSETBL SET WAREHOUSE_NAME = @WAREHOUSE_NAME, REGION = @REGION, PROVINCE = @PROVINCE, CITY = @CITY, ADDRESS = @ADDRESS, " +
                "ZIP_CODE = @ZIP_CODE, DESCRIPTION = @DESCRIPTION WHERE WAREHOUSE_ID = @WAREHOUSE_ID";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();

                    command.Parameters.AddWithValue("@WAREHOUSE_ID", wareHouse.ID);
                    command.Parameters.AddWithValue("@WAREHOUSE_NAME", wareHouse.Warehouse_Name);
                    command.Parameters.AddWithValue("@REGION", wareHouse.Region);
                    command.Parameters.AddWithValue("@PROVINCE", wareHouse.Province);
                    command.Parameters.AddWithValue("@CITY", wareHouse.City);
                    command.Parameters.AddWithValue("@ADDRESS", wareHouse.Address);
                    command.Parameters.AddWithValue("@ZIP_CODE", wareHouse.ZipCode);
                    command.Parameters.AddWithValue("@DESCRIPTION", wareHouse.Description);

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
        public void Delete(Warehouse wareHouse)
        {
            string query = "DELETE FROM WAREHOUSETBL WHERE WAREHOUSE_ID = @WAREHOUSE_ID";

            try
            {
                _dbConnector.Open();

                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    command.Parameters.AddWithValue("@WAREHOUSE_ID", wareHouse.ID);
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
    }
}
