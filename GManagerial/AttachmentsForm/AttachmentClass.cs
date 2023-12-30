using GManagerial.AttachmentsForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.CustomerForm.ChildForms
{
    class AttachmentClass
    {
        //static private readonly string connstring = "Data Source=MAUROG\\SQLEXPRESS;Initial Catalog=Gmanagerial;Integrated Security=True";
        static private string connstring = "Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True";
        public AttachmentClass()
        {
            
        }

        static public void LoadCustAttFromDB(int id_object, ListView fileListView, ref string path, ref int attachmentId, List<ListViewItem> TemporaryAttachmentsFromDB)
        {
            string query = "SELECT att.id_attachment, att.image, att.fileName, att.path FROM attachmentsTbl att JOIN customerTbl cust ON att.id_customer = cust.id_customer WHERE att.id_customer = @CustomerId";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", id_object);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ImageList imageList = new ImageList();
                        imageList.ImageSize = new Size(64, 64);

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1)) // Verifica che i dati binari dell'immagine non siano nulli
                            {
                                string fileName = reader.GetString(2);
                                path = reader.GetString(3);
                                attachmentId = reader.GetInt32(0);

                                byte[] imageData = (byte[])reader["image"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    Image image = Image.FromStream(ms);
                                    Icon iconImage = Icon.FromHandle(((Bitmap)image).GetHicon());
                                    imageList.Images.Add(iconImage);
                                }

                                ListViewItem listViewItem = new ListViewItem(fileName);
                                listViewItem.ImageIndex = imageList.Images.Count - 1;

                                Tag tag = new Tag();
                                tag.FilePath = path;
                                tag.IdAttachment = attachmentId;
                                tag.fileIcon = (Icon)Icon.FromHandle(new Bitmap(imageList.Images[imageList.Images.Count - 1]).GetHicon());


                                listViewItem.Tag = tag;

                                fileListView.Items.Add(listViewItem);

                                AttachmentGUI.AddItemToTemporaryAttachmentsFromDB(tag, TemporaryAttachmentsFromDB);
                            }
                        }

                        fileListView.LargeImageList = imageList;
                    }
                }
            }
        }


        static public void LoadProdAttFromDB(int id_object, ListView fileListView, ref string path, ref int attachmentId, List<ListViewItem> TemporaryAttachmentsFromDB)   //CARICA i files dal DB
        {
            string query = "SELECT att.id_attachment, att.image, att.fileName, att.path FROM attachmentsTbl att JOIN ProductsTbl prod ON att.product_ID = prod.Product_ID WHERE att.Product_ID = @Product_ID";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_ID", id_object);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ImageList imageList = new ImageList();
                        imageList.ImageSize = new Size(64, 64);

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(1)) // Verifica che i dati binari dell'immagine non siano nulli
                            {
                                string fileName = reader.GetString(2);
                                path = reader.GetString(3);
                                attachmentId = reader.GetInt32(0);

                                byte[] imageData = (byte[])reader["image"];

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    Image image = Image.FromStream(ms);
                                    Icon iconImage = Icon.FromHandle(((Bitmap)image).GetHicon());
                                    imageList.Images.Add(iconImage);
                                }

                                ListViewItem listViewItem = new ListViewItem(fileName);
                                listViewItem.ImageIndex = imageList.Images.Count - 1;

                                Tag tag = new Tag();
                                tag.FilePath = path;
                                tag.IdAttachment = attachmentId;
                                tag.fileIcon = (Icon)Icon.FromHandle(new Bitmap(imageList.Images[imageList.Images.Count - 1]).GetHicon());


                                listViewItem.Tag = tag;

                                fileListView.Items.Add(listViewItem);

                                AttachmentGUI.AddItemToTemporaryAttachmentsFromDB(tag, TemporaryAttachmentsFromDB);
                            }
                        }

                        fileListView.LargeImageList = imageList;
                    }
                }
            }
        }

        static public void DeleteFileFromDBCustomer(ListViewItem item, int id_customer) //CANCELLA i files dal DB
        {
            if (item.Tag is Tag tag)
            {
                int attachmentId = tag.IdAttachment;

                string deleteAttachmentQuery = "DELETE FROM ATTACHMENTSTBL WHERE ID_CUSTOMER = @idCustomer AND FILENAME = @fileName AND ID_ATTACHMENT = @attachmentId";

                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteAttachmentQuery, connection))  //ATTACHMENTSCLASS
                    {
                        command.Parameters.AddWithValue("@idCustomer", id_customer);
                        command.Parameters.AddWithValue("@fileName", item.Text);
                        command.Parameters.AddWithValue("@attachmentId", attachmentId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        static public void DeleteFileFromDBProduct(ListViewItem item, int product_id) //CANCELLA i files dal DB
        {
            if (item.Tag is Tag tag)
            {
                int attachmentId = tag.IdAttachment;

                string deleteAttachmentQuery = "DELETE FROM ATTACHMENTSTBL WHERE PRODUCT_ID = @PRODUCT_ID AND FILENAME = @fileName AND ID_ATTACHMENT = @attachmentId";

                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteAttachmentQuery, connection))  //ATTACHMENTSCLASS
                    {
                        command.Parameters.AddWithValue("@PRODUCT_ID", product_id);
                        command.Parameters.AddWithValue("@fileName", item.Text);
                        command.Parameters.AddWithValue("@attachmentId", attachmentId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        static public void TemporaryAttachmentsToDBCustomer(char nec, int id_object)
        {
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                foreach (ListViewItem item in AttachmentForm.TemporaryAttachments)
                {
                    if (item.Tag is Tag tag)
                    {
                        string filepath = tag.FilePath;
                        byte[] fileData = System.IO.File.ReadAllBytes(filepath);

                        Icon fileIcon = Icon.ExtractAssociatedIcon(filepath);

                        Bitmap iconBitmap = fileIcon.ToBitmap();

                        ImageConverter converter = new ImageConverter();
                        byte[] iconImageData = (byte[])converter.ConvertTo(iconBitmap, typeof(byte[]));

                        string query = "INSERT INTO ATTACHMENTSTBL (path, id_customer, fileData, fileName, image) VALUES (@FilePath, @CustomerID, @fileData, @FileName, @image)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FilePath", filepath);
                            command.Parameters.AddWithValue("@CustomerID", id_object);
                            command.Parameters.AddWithValue("@fileData", fileData);
                            command.Parameters.AddWithValue("@FileName", item.Text);
                            command.Parameters.AddWithValue("@image", iconImageData);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        static public void TemporaryAttachmentsToDBProduct(char nec, int id_object)  //-> funzione per inserire gli allegati del prodotto
        {
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                foreach (ListViewItem item in AttachmentForm.TemporaryAttachments)
                {
                    if (item.Tag is Tag tag)
                    {
                        string filepath = tag.FilePath;
                        byte[] fileData = System.IO.File.ReadAllBytes(filepath);

                        Icon fileIcon = Icon.ExtractAssociatedIcon(filepath);

                        Bitmap iconBitmap = fileIcon.ToBitmap();

                        ImageConverter converter = new ImageConverter();
                        byte[] iconImageData = (byte[])converter.ConvertTo(iconBitmap, typeof(byte[]));

                        string query = "INSERT INTO ATTACHMENTSTBL (path, Product_ID, fileData, fileName, image) VALUES (@FilePath, @Product_ID, @fileData, @FileName, @image)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FilePath", filepath);
                            command.Parameters.AddWithValue("@Product_ID", id_object);
                            command.Parameters.AddWithValue("@fileData", fileData);
                            command.Parameters.AddWithValue("@FileName", item.Text);
                            command.Parameters.AddWithValue("@image", iconImageData);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        static public List<object> LoadProdAttFromDB(int id_object)   //CARICA i files dal DB
        {
            string query = "SELECT att.id_attachment, att.image, att.fileName, att.fileData, att.path FROM attachmentsTbl att JOIN ProductsTbl " +
                "prod ON att.product_ID = prod.Product_ID WHERE att.Product_ID = @Product_ID";

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_ID", id_object);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int attachment_Id = reader.GetInt32(0);
                            byte[] imageData = (byte[])reader["image"];
                            string fileName = reader.GetString(2);
                            byte[] fileData = (byte[])reader["fileData"];
                            string path = reader.GetString(4);

                            List<object> attachmentRow = new List<object>() { attachment_Id, imageData, fileName, fileData, path };
                            return attachmentRow;
                        }

                        return null;    
                    }
                }
            }
        }

        static public List<object> LoadCustAttFromDB(int id_object)   //CARICA i files dal DB
        {
            string query = "SELECT att.id_attachment, att.image, att.fileName, att.fileData, att.path FROM attachmentsTbl att JOIN customerTbl cust " +
                "ON + att.id_customer = cust.id_customer WHERE att.id_customer = @CustomerId"; 

            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", id_object);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int attachment_Id = reader.GetInt32(0);
                            byte[] imageData = (byte[])reader["image"];
                            string fileName = reader.GetString(2);
                            byte[] fileData = (byte[])reader["fileData"];
                            string path = reader.GetString(4);

                            List<object> attachmentRow = new List<object>() { attachment_Id, imageData, fileName, fileData, path };
                            return attachmentRow;
                        }

                        return null;
                    }
                }
            }
        }

        static public void CopiedAttachmentsToDBProduct(List<object> attachmentRow, int id_object)  //-> funzione per inserire gli allegati del prodotto
        {
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                int attachment_Id = (int)attachmentRow[0];
                byte[] imageData = (byte[])attachmentRow[1];
                string fileName = (string)attachmentRow[2];
                byte[] fileData = (byte[])attachmentRow[3];
                string path = (string)attachmentRow[4];

                string query = "INSERT INTO ATTACHMENTSTBL(FILENAME, IMAGE, FILEDATA, PRODUCT_ID, PATH) VALUES (@FILENAME, @IMAGEDATA, @FILEDATA," +
                    " @PRODUCT_ID, @PATH)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_ID", id_object);
                    command.Parameters.AddWithValue("@fileData", fileData);
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@IMAGEDATA", imageData);
                    command.Parameters.AddWithValue("@PATH", path);

                    command.ExecuteNonQuery();
                }
            }
        }

        static public void CopiedAttachmentsToDBCustomer(List<object> attachmentRow, int id_object)  //-> funzione per inserire gli allegati del prodotto
        {
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();

                int attachment_Id = (int)attachmentRow[0];
                byte[] imageData = (byte[])attachmentRow[1];
                string fileName = (string)attachmentRow[2];
                byte[] fileData = (byte[])attachmentRow[3];
                string path = (string)attachmentRow[4];

                string query = "INSERT INTO ATTACHMENTSTBL(FILENAME, IMAGE, FILEDATA, ID_CUSTOMER, PATH) VALUES (@FILENAME, @IMAGEDATA, @FILEDATA," +
                    " @ID_CUSTOMER, @PATH)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_CUSTOMER", id_object);
                    command.Parameters.AddWithValue("@fileData", fileData);
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@IMAGEDATA", imageData);
                    command.Parameters.AddWithValue("@PATH", path);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
