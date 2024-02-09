using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;



namespace GManagerial
{
    static class GeoClass
    {
        static string connstring = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
       // static string connstring = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static public List<string> GetRegions()
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


        static public List<string> GetProv(string regionSelected)
        {
            
            List<string> provinces = new List<string>();

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                string query = "SELECT PROVINCIA FROM [Gmanagerial].[dbo].[munic] WHERE REGIONE = '" + regionSelected + "'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string prov = reader["PROVINCIA"].ToString();
                            if (!provinces.Contains(prov))
                            {
                                provinces.Add(prov);
                            }
                        }
                    }
                    
                }
            }
            
            return provinces;
        }



        static public List<string> GetAllMunicipies(string provSelected)
        {
            List<string> municipies = new List<string>();

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                string query = "SELECT COMUNE FROM [Gmanagerial].[dbo].[munic] WHERE PROVINCIA = '" + provSelected + "'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string munic = reader["COMUNE"].ToString();
                            if (!municipies.Contains(munic))
                            {
                                municipies.Add(munic);
                            }
                        }
                    }
                }
            }

            return municipies;

        }

    }

}




