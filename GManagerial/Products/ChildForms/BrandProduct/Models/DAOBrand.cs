using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GManagerial.DBConnectors;

namespace GManagerial.Products.ChildForms
{
    internal class DAOBrand:IDAOBrand
    {
        private IDBConnector _dbConnector;
        public DAOBrand(IDBConnector dBConnector)
        {
            this._dbConnector = dBConnector;
        }

        public void Insert(IBrand brand)
        {
            string query = "INSERT INTO BRANDTBL(BRAND_NAME) VALUES(@BRAND_NAME)";

            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());  //query, oggetto sql connection che contiene la stringa di connessione
            this._dbConnector.Open();   //(oggetto sql connection.open)              SqlConnection m_connection = new SqlConnection(connectionString);

            command.Parameters.AddWithValue("@BRAND_NAME", brand.Name); 

            this._dbConnector.Insert(command);

            this._dbConnector.Close();   
        }

       
        public List<IBrand> GetAll()
        {
            string query = "SELECT ID_Brand, BRAND_NAME FROM BRANDTBL";
            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());
            this._dbConnector.Open();

            SqlDataReader reader = this._dbConnector.Load(command);
            List<IBrand> ret = new List<IBrand>();

            while (reader.Read())

            {
                Brand brand = new Brand();
                brand.ID = Convert.ToInt32(reader["ID_Brand"]);
                brand.Name = reader["BRAND_NAME"].ToString(); 

                if (Convert.ToInt32(reader["ID_Brand"]) != 1)
                {
                    ret.Add(brand);
                }

            }
            this._dbConnector.Close();

            return ret; 
        }

        public void Update(IBrand brand)
        {
            string query = "UPDATE BRANDTBL SET BRAND_NAME = @BRAND_NAME WHERE ID_BRAND = @ID_BRAND";
            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());
            this._dbConnector.Open();

            command.Parameters.AddWithValue("@BRAND_NAME", brand.Name);
            command.Parameters.AddWithValue("@ID_BRAND", brand.ID);

            this._dbConnector.Update(command);
            this._dbConnector.Close();
        }

        public Dictionary<string, IBrand> GetAllDictionaries()
        {
            string query = "SELECT ID_Brand, BRAND_NAME FROM BRANDTBL";
            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());
            this._dbConnector.Open();

            SqlDataReader reader = this._dbConnector.Load(command);
            Dictionary <string, IBrand> ret = new Dictionary<string, IBrand>();

            while (reader.Read())

            {
                Brand brand = new Brand();
                brand.ID = Convert.ToInt32(reader["ID_Brand"]);
                brand.Name = reader["BRAND_NAME"].ToString();

                //if (Convert.ToInt32(reader["ID_Brand"]) != 1)
               // {
                    ret[brand.Name] = brand;  //se esiste già una chiave con il nome ariston, il suo valore verrà sovvrascritto con il nuovo oggetto
                //}

            }
            this._dbConnector.Close();

            return ret;
        }

        public void Delete(IBrand brand) 
        {
            string updateQuery = "UPDATE PRODUCTSTBL SET BRAND_ID = @NEWBRAND_ID WHERE BRAND_ID = @BRAND_ID";
            string query = "DELETE FROM BRANDTBL WHERE ID_BRAND = @ID_BRAND";

            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());
            SqlCommand commandUpdate = new SqlCommand(updateQuery, _dbConnector.GetConnectionObj());


            this._dbConnector.Open();
            commandUpdate.Parameters.AddWithValue("@NEWBRAND_ID", 1);
            command.Parameters.AddWithValue("@ID_BRAND", brand.ID);

            this._dbConnector.Delete(command);         
            this._dbConnector.Close();  
        }

        public bool CheckIfBrandAlreadyExist(string brand)
        {
            string query = "SELECT * FROM BRANDTBL WHERE BRAND_NAME = @BRAND_NAME";

            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());
            this._dbConnector.Open();

            command.Parameters.AddWithValue("@BRAND_NAME", brand);
            SqlDataReader reader =  this._dbConnector.Load(command);

            if(reader.HasRows)
            {
                this._dbConnector.Close();
                return true;
            }

            this._dbConnector.Close();
            return false;   
        }

    }
}
