using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.DBConnectors;

namespace GManagerial.Products.ChildForms.CategorySubForm.Models
{
    internal class DAOSubCategory : IDAOSubCategory
    {
        IDBConnector _dbConnector;

        public DAOSubCategory(IDBConnector dBConnector)
        {
            this._dbConnector = dBConnector;
        }
        public void Insert(ISubCategory subcategory, ICategory category)
        {
            string query = "INSERT INTO SUBCATEGORYTBL(SUBCATEGORY_NAME, PARENT_CATEGORY_ID) VALUES(@SUBCATEGORY_NAME, @PARENT_CATEGORY_ID)";

            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());  //query, oggetto sql connection che contiene la stringa di connessione
            this._dbConnector.Open();   //(oggetto sql connection.open)
                                        //
            command.Parameters.AddWithValue("@SUBCATEGORY_NAME", subcategory.SubCategoryName);
            command.Parameters.AddWithValue("@PARENT_CATEGORY_ID", category.ID);

            this._dbConnector.Insert(command);
            this._dbConnector.Close();
        }
        public List<ISubCategory> GetAll()
        {
            return new List<ISubCategory>();
        }

        public Dictionary<string, ISubCategory> GetAllDictionaries()
        {
            string query = "SELECT SUBCATEGORY_ID, SUBCATEGORY_NAME, PARENT_CATEGORY_ID FROM SUBCATEGORYTBL";
            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());
            this._dbConnector.Open();
            SqlDataReader reader = this._dbConnector.Load(command);

            Dictionary<string, ISubCategory> ret = new Dictionary<string, ISubCategory>();

            while (reader.Read())
            {
                try
                {
                    SubCategory subCategory = new SubCategory();
                    subCategory.ID = Convert.ToInt32(reader["SUBCATEGORY_ID"]);
                    subCategory.SubCategoryName = reader["SUBCATEGORY_NAME"].ToString();
                    subCategory.CategoryId = Convert.ToInt32(reader["PARENT_CATEGORY_ID"]);

                    ret[subCategory.SubCategoryName] = subCategory;  //se esiste già una chiave con il nome ariston, il suo valore verrà sovvrascritto con il nuovo oggetto
                }

                catch 
                {
                    MessageBox.Show("Errore nel caricamento delle sottocategorie", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            this._dbConnector.Close();

            return ret;
        }

        public Dictionary<string, ISubCategory> GetAllSubCategoriesFromACategoryDictionaries(ICategory category)
        {
            string query = "SELECT SUBCATEGORY_ID, SUBCATEGORY_NAME, PARENT_CATEGORY_ID FROM SUBCATEGORYTBL WHERE PARENT_CATEGORY_ID = @PARENT_CATEGORY_ID OR PARENT_CATEGORY_ID = 1";
            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()); //query , sqlconnection(oggetto che contiene la stringa di connessione)

            command.Parameters.AddWithValue("@PARENT_CATEGORY_ID", category.ID);

            this._dbConnector.Open();
            SqlDataReader reader = this._dbConnector.Load(command);

            Dictionary<string, ISubCategory> ret = new Dictionary<string, ISubCategory>();

            while (reader.Read())
            {
                SubCategory subCategory = new SubCategory();
                subCategory.ID = Convert.ToInt32(reader["SUBCATEGORY_ID"]);
                subCategory.SubCategoryName = reader["SUBCATEGORY_NAME"].ToString();
                subCategory.CategoryId = Convert.ToInt32(reader["PARENT_CATEGORY_ID"]);

                ret[subCategory.SubCategoryName] = subCategory;  //se esiste già una chiave con il nome ariston, il suo valore verrà sovvrascritto con il nuovo oggetto
            }
            this._dbConnector.Close();

            return ret;
        }
        public void Update(ISubCategory subCategory)
        {
            string query = "UPDATE SUBCATEGORYTBL SET SUBCATEGORY_NAME = @SUBCATEGORY_NAME WHERE SUBCATEGORY_ID = @SUBCATEGORY_ID";

            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()); // _dbConnector.GetConnectionObj() -> oggetto sqlconnection (sqlconnection m_connection = new SqlConnection(connectionString);)
            this._dbConnector.Open();

            command.Parameters.AddWithValue("@SUBCATEGORY_ID", subCategory.ID);
            command.Parameters.AddWithValue("@SUBCATEGORY_NAME", subCategory.SubCategoryName);

            this._dbConnector.Update(command);
            this._dbConnector.Close();
        }
        public void Delete(ISubCategory subCategory)
        {
            string updateQuery = "UPDATE PRODUCTSTBL SET SUBCATEGORY_ID = NULL WHERE SUBCATEGORY_ID = @SUBCATEGORY_ID";
            string deleteSubQuery = "DELETE FROM SUBCATEGORYTBL WHERE SUBCATEGORY_ID = @SUBCATEGORY_ID";

            SqlCommand command = new SqlCommand(updateQuery, _dbConnector.GetConnectionObj());
            SqlCommand command2 = new SqlCommand(deleteSubQuery, _dbConnector.GetConnectionObj());

            this._dbConnector.Open();
            command2.Parameters.AddWithValue("@SUBCATEGORY_ID", subCategory.ID);
            command.Parameters.AddWithValue("@SUBCATEGORY_ID", subCategory.ID);

            this._dbConnector.Update(command);
            this._dbConnector.Delete(command2);

            this._dbConnector.Close();
        }

        public void DeleteAllSubcategories(ICategory category)
        {
            string updateSubCategoryQuery = "UPDATE PRODUCTSTBL SET SUBCATEGORY_ID = NULL WHERE CATEGORY_ID = @CATEGORY_ID";
            string deleteSubCategoryQuery = "DELETE FROM SUBCATEGORYTBL WHERE PARENT_CATEGORY_ID = @PARENT_CATEGORY_ID";

            SqlCommand commandUpdateSubCategoryQuery = new SqlCommand(updateSubCategoryQuery, _dbConnector.GetConnectionObj());
            SqlCommand commandDeleteSubCategoryQuery = new SqlCommand(deleteSubCategoryQuery, _dbConnector.GetConnectionObj());

            this._dbConnector.Open();
            commandUpdateSubCategoryQuery.Parameters.AddWithValue("@CATEGORY_ID", category.ID);
            commandDeleteSubCategoryQuery.Parameters.AddWithValue("@PARENT_CATEGORY_ID", category.ID);

            this._dbConnector.Update(commandUpdateSubCategoryQuery);
            this._dbConnector.Delete(commandDeleteSubCategoryQuery);

            this._dbConnector.Close();
        }

        public bool CheckIfSubCategoryAlreadyExist(string subCategory, Category category)
        {
            string categoriesQuery = "SELECT * FROM SUBCATEGORYTBL WHERE SUBCATEGORY_NAME = @SUBCATEGORY_NAME AND PARENT_CATEGORY_ID = @PARENT_CATEGORY_ID";

            SqlCommand command = new SqlCommand(categoriesQuery, _dbConnector.GetConnectionObj());

            _dbConnector.Open();
            command.Parameters.AddWithValue("@SUBCATEGORY_NAME", subCategory);
            command.Parameters.AddWithValue("@PARENT_CATEGORY_ID", category.ID);

            SqlDataReader sqlDataReaderreader = _dbConnector.Load(command);

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
