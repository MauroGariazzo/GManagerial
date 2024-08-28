using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial.Products.ChildForms
{
    class ImageMGM
    {
        //static public string connstring = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connstring = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";


        /*static public void InsertImageToDB(string filepath, int objectID)
        {
            if (filepath != null)
            {
                byte[] fileData = System.IO.File.ReadAllBytes(filepath);

                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();

                    string query = "UPDATE PRODUCTSTBL SET IMAGE = @FILEDATA WHERE PRODUCT_ID = @PRODUCT_ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FILEDATA", fileData);
                        command.Parameters.AddWithValue("@PRODUCT_ID", objectID);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }*/

        static public void InsertImageToDB(string filepath, int objectID)
        {
            if (filepath != null)
            {
                byte[] OI = System.IO.File.ReadAllBytes(filepath);

                using (Image originalImage = Image.FromFile(filepath))
                {

                    using (Image resizedImage = new Bitmap(originalImage, 100, 100))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            resizedImage.Save(ms, ImageFormat.Jpeg); 

                            byte[] fileData = ms.ToArray();

                            using (SqlConnection connection = new SqlConnection(connstring))
                            {
                                connection.Open();

                                string query = "UPDATE PRODUCTSTBL SET IMAGE = @FILEDATA, resizedImage = @RESIZED_FILEDATA WHERE PRODUCT_ID = @PRODUCT_ID";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@FILEDATA", OI);
                                    command.Parameters.AddWithValue("@RESIZED_FILEDATA", fileData);
                                    command.Parameters.AddWithValue("@PRODUCT_ID", objectID);                              

                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
        }



        static public void LoadImage(PictureBox pictureBox, int product_id, PictureBox pictureTemp)
        {
            string query = "SELECT IMAGE FROM PRODUCTSTBL WHERE PRODUCT_ID = @PRODUCT_ID";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", product_id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("IMAGE")))
                            {
                                // Leggi i dati binari dell'immagine dal database
                                byte[] imageBytes = (byte[])reader["IMAGE"];

                                // Crea un oggetto MemoryStream e carica i dati binari dell'immagine
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    // Carica l'immagine dal MemoryStream e assegnala al PictureBox
                                    pictureBox.Image = Image.FromStream(ms);
                                    pictureTemp.Image = Image.FromStream(ms);
                                }
                            }
                           
                        }
                    }
                }
            }
        }


        static public void deleteImage(int product_id)
        {
            string query = "UPDATE PRODUCTSTBL SET IMAGE = NULL, RESIZEDIMAGE = NULL WHERE PRODUCT_ID = @PRODUCT_ID";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PRODUCT_ID", product_id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
