using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GManagerial.DBConnectors;

namespace GManagerial.Products.ChildForms
{
    internal class DAOCategory : IDAOCategory
    {
        IDBConnector _dbConnector;

        public DAOCategory(IDBConnector dBConnector) 
        {
            this._dbConnector = dBConnector;
        }
        public void Insert(ICategory category)
        {
            string query = "INSERT INTO CATEGORIESTBL(CATEGORY_NAME) VALUES(@CATEGORY_NAME)";
            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());  //query, oggetto sql connection che contiene la stringa di connessione
            this._dbConnector.Open();   //(oggetto sql connection.open)          
            command.Parameters.AddWithValue("@CATEGORY_NAME", category.CategoryName);
            this._dbConnector.Insert(command);
            this._dbConnector.Close();
        }
        public List<ICategory> GetAll()
        {
            return new List<ICategory>();   
        }

        public Dictionary<string, ICategory> GetAllDictionaries()
        {
            string query = "SELECT CATEGORY_ID, CATEGORY_NAME FROM CATEGORIESTBL";
            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());
            this._dbConnector.Open();
            SqlDataReader reader = this._dbConnector.Load(command);

            Dictionary<string, ICategory> ret = new Dictionary<string, ICategory>();

            while (reader.Read())

            {
                Category category = new Category();
                category.ID = Convert.ToInt32(reader["CATEGORY_ID"]);
                category.CategoryName = reader["CATEGORY_NAME"].ToString();

               // if (Convert.ToInt32(reader["CATEGORY_ID"]) != 1)
                //{
                    ret[category.CategoryName] = category;  //se esiste già una chiave con il nome ariston, il suo valore verrà sovvrascritto con il nuovo oggetto
                //}

            }
            this._dbConnector.Close();

            return ret;
        }
        public void Update(ICategory category)
        {
            string query = "UPDATE CATEGORIESTBL SET CATEGORY_NAME = @CATEGORY_NAME WHERE CATEGORY_ID = @CATEGORY_ID";

            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()); // _dbConnector.GetConnectionObj() -> oggetto sqlconnection (sqlconnection m_connection = new SqlConnection(connectionString);)
            this._dbConnector.Open();

            command.Parameters.AddWithValue("@CATEGORY_NAME", category.CategoryName);
            command.Parameters.AddWithValue("@CATEGORY_ID", category.ID);


            this._dbConnector.Update(command);
            this._dbConnector.Close();
        }
        public void Delete(ICategory category)
        {
            string updateQuery = "UPDATE PRODUCTSTBL SET CATEGORY_ID = @NEWCATEGORY_ID WHERE CATEGORY_ID = @CATEGORY_ID";
            string query = "DELETE FROM CATEGORIESTBL WHERE CATEGORY_ID = @CATEGORY_ID";

            SqlCommand command = new SqlCommand(updateQuery, _dbConnector.GetConnectionObj());
            SqlCommand command2 = new SqlCommand(query, _dbConnector.GetConnectionObj());

            this._dbConnector.Open();
            command.Parameters.AddWithValue("@NEWCATEGORY_ID", 1);
            command.Parameters.AddWithValue("@CATEGORY_ID", category.ID);
            command2.Parameters.AddWithValue("@CATEGORY_ID", category.ID);

            this._dbConnector.Update(command);
            this._dbConnector.Delete(command2);

            this._dbConnector.Close();
        }

        public bool CheckIfCategoryAlreadyExist(string category)
        {
            string categoriesQuery = "SELECT * FROM CATEGORIESTBL WHERE CATEGORY_NAME = @CATEGORY_NAME";

            SqlCommand command = new SqlCommand(categoriesQuery, _dbConnector.GetConnectionObj());

            _dbConnector.Open();
            command.Parameters.AddWithValue("@CATEGORY_NAME", category);

            SqlDataReader sqlDataReaderreader =_dbConnector.Load(command);

            if (sqlDataReaderreader.HasRows)
            {
                _dbConnector.Close();
                return true;
            }

            _dbConnector.Close();   
            return false;
        }
    }
}
