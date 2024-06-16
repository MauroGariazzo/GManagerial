using GManagerial.CustomerMGM;
using GManagerial.Products;
using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using GManagerial.CustomerForm.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial.Attachments
{
    internal class DAOAttachments:IDAOAttchments
    {

        private IDBConnector.IDBConnector _dbConnector;
        private string _querySelect, _queryInsert, _queryUpdate, _queryDelete;
        public DAOAttachments(IDBConnector.IDBConnector dBConnector, string querySelect, string queryInsert, string queryUpdate, string queryDelete)
        {
            this._dbConnector = dBConnector;

            this._querySelect = querySelect;
            this._queryInsert = queryInsert;
            this._queryUpdate = queryUpdate;
            this._queryDelete = queryDelete;
        }
        /*public void Insert(IAttachment attachment, int fk)
        {
            SqlCommand sqlCommand = new SqlCommand(this._queryInsert, _dbConnector.GetConnectionObj());
            _dbConnector.Open();

            Bitmap iconBitmap = new Bitmap(attachment.Icon);

            ImageConverter converter = new ImageConverter();
            byte[] iconImageData = (byte[])converter.ConvertTo(iconBitmap, typeof(byte[]));

            sqlCommand.Parameters.AddWithValue("@FILENAME", attachment.FileName);
            sqlCommand.Parameters.AddWithValue("@PATH", attachment.Path);
            sqlCommand.Parameters.AddWithValue("@IMAGE", iconImageData);
            sqlCommand.Parameters.AddWithValue("@FK", fk);

            this._dbConnector.Insert(sqlCommand);
            this._dbConnector.Close();
        }*/

        public void Insert(IAttachment attachment)
        {
            SqlCommand insertAttachmentIntoAttachmentsTbl = new SqlCommand(this._queryInsert, _dbConnector.GetConnectionObj());

            _dbConnector.Open();

            Bitmap iconBitmap = new Bitmap(attachment.Icon);
            ImageConverter converter = new ImageConverter();
            byte[] iconImageData = (byte[])converter.ConvertTo(iconBitmap, typeof(byte[]));

            string filepath = attachment.Path;
            byte[] fileData = System.IO.File.ReadAllBytes(filepath);

            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@FILENAME", attachment.FileName);
            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@PATH", attachment.Path);
            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@IMAGE", iconImageData);
            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@FILEDATA", fileData);

            this._dbConnector.Insert(insertAttachmentIntoAttachmentsTbl);
            this._dbConnector.Close();
        }

        /*private int GetAttachmentMaxId()
        {
            string query = "SELECT MAX(ID_ATTACHMENT) FROM ATTACHMENTSTBL";

            SqlCommand command = new SqlCommand(query, _dbConnector.GetConnectionObj());

            _dbConnector.Open();
            SqlDataReader sqlDataReader = _dbConnector.Load(command);


            _dbConnector.Close();

            return sqlDataReader.GetInt32(0);
        }

        public Dictionary<int, IAttachment> GetAll(int fk)
        {
            SqlCommand command = new SqlCommand(this._querySelect, _dbConnector.GetConnectionObj());
            _dbConnector.Open();

            command.Parameters.AddWithValue("@FK", fk);
            SqlDataReader sqlDataReader = _dbConnector.Load(command);
            Dictionary<int, IAttachment> ret = new Dictionary<int, IAttachment>();

            while (sqlDataReader.Read())
            {
                Attachment attachment = new Attachment();

                attachment.AttachmentObjID = Convert.ToInt32(sqlDataReader["ID_ATTACHMENT"]);
                byte[] imageData = (byte[])sqlDataReader["IMAGE"];

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    attachment.Icon = image;
                }

                attachment.FileName = Convert.ToString(sqlDataReader["FILENAME"]);
                attachment.Path = Convert.ToString(sqlDataReader["PATH"]);
                

                ret[attachment.AttachmentObjID] = attachment;
            }

            _dbConnector.Close();
            return ret;
        }
        public void Update(IAttachment attachment, int fk)
        {

            SqlCommand sqlCommand = new SqlCommand(this._queryUpdate, _dbConnector.GetConnectionObj());
            _dbConnector.Open();

            Bitmap iconBitmap = new Bitmap(attachment.Icon);

            ImageConverter converter = new ImageConverter();
            byte[] iconImageData = (byte[])converter.ConvertTo(iconBitmap, typeof(byte[]));

            sqlCommand.Parameters.AddWithValue("@FILENAME", attachment.FileName);
            sqlCommand.Parameters.AddWithValue("@PATH", attachment.Path);
            sqlCommand.Parameters.AddWithValue("@IMAGE", iconImageData);
            sqlCommand.Parameters.AddWithValue("@FK", fk);

            this._dbConnector.Update(sqlCommand);
            this._dbConnector.Close();
        }
        public void Delete(IAttachment attachment, int fk)
        {
            SqlCommand sqlCommand = new SqlCommand(this._queryDelete, _dbConnector.GetConnectionObj());
            _dbConnector.Open();

            sqlCommand.Parameters.AddWithValue("@ID_ATTACHMENT", attachment.AttachmentObjID);
            sqlCommand.Parameters.AddWithValue("@FK", fk);

            _dbConnector.Delete(sqlCommand);
            this._dbConnector.Close();
        }



    }
}
