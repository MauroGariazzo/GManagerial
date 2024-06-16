using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.DBConnectors;


namespace GManagerial.Geo.models
{
    internal class DAOGeo:IDAOGeo
    {
        private IDBConnector _dbConnector;

        public DAOGeo(IDBConnector dBConnector)
        {
            _dbConnector = dBConnector;
        }

        public List<string> GetRegions()
        {
            List<string> regions = new List<string>
            {
                "",
                "Abruzzo",
                "Basilicata",
                "Calabria",
                "Campania",
                "Emilia-Romagna",
                "Friuli-Venezia Giulia",
                "Lazio",
                "Liguria",
                "Lombardia",
                "Marche",
                "Molise",
                "Piemonte",
                "Puglia",
                "Sardegna",
                "Sicilia",
                "Toscana",
                "Trentino-Alto Adige",
                "Umbria",
                "Valle d Aosta",
                "Veneto"
            };

            return regions;
        }

        public Dictionary<string, string> GetProvinces(string region)
        {
            string query = "SELECT DISTINCT PROVINCE, PROVINCEINITIALS FROM GEO WHERE REGION = @REGION";
            Dictionary<string,string> provinces = new Dictionary<string, string>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();

                    command.Parameters.AddWithValue("@REGION", region);
                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            string province = reader["PROVINCE"].ToString();
                            string provinceInitials = reader["PROVINCEINITIALS"].ToString();

                            provinces.Add(province, provinceInitials);
                        }
                    }
                }
            }

            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            _dbConnector.Close();
            return provinces;
        }

        public List<string> GetCities(string province)
        {
            string query = "SELECT DISTINCT CITY FROM GEO WHERE PROVINCE = @PROVINCE";
            List<string> cities = new List<string>();

            try
            {
                using (SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj()))
                {
                    _dbConnector.Open();

                    command.Parameters.AddWithValue("@PROVINCE", province);
                    using (SqlDataReader reader = _dbConnector.Load(command))
                    {
                        while (reader.Read())
                        {
                            string city = reader["CITY"].ToString();
                            cities.Add(city);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            _dbConnector.Close();
            return cities;
        }
    }
}
