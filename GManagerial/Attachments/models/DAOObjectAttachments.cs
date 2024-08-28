using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using GManagerial.DBConnectors;
using System.Drawing;

namespace GManagerial.Attachments
{
    internal class DAOObjectAttachments : IDAOObjectAttachemnts
    {
        private IDBConnector _dbConnector;
        private string _querySelect, _queryInsert, _queryDelete;


        public DAOObjectAttachments(IDBConnector dBConnector, string querySelect, string queryInsert, string queryDelete)
        {
            this._dbConnector = dBConnector;

            this._querySelect = querySelect;
            this._queryInsert = queryInsert; ;
            this._queryDelete = queryDelete;
        }
        public void Insert(int fk_object, int fk_attachment)
        {
            SqlCommand command = new SqlCommand(_queryInsert, _dbConnector.GetConnectionObj());

            _dbConnector.Open();
            command.Parameters.AddWithValue("@FK_OBJECT", fk_object);
            command.Parameters.AddWithValue("@FK_ATTACHMENT", fk_attachment);

            _dbConnector.Insert(command);

            this._dbConnector.Close();
        }

        public Dictionary<int, IAttachment> GetAll(int fk_object)
        {
            SqlCommand command = new SqlCommand(_querySelect, _dbConnector.GetConnectionObj());

            _dbConnector.Open();

            command.Parameters.AddWithValue("@FK_OBJECT", fk_object);
            SqlDataReader sqlDataReader = _dbConnector.Load(command);

            Dictionary<int, IAttachment> ret = new Dictionary<int, IAttachment>();

            while (sqlDataReader.Read())
            {
                Attachment attachment = new Attachment();

                attachment.AttachmentObjID = Convert.ToInt32(sqlDataReader["ID_ATTACHMENT"]);
                byte[] imageData = (byte[])sqlDataReader["IMAGE"];

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Icon icon = new Icon(ms);
                    attachment.Icon = icon;
                }

                attachment.FileName = Convert.ToString(sqlDataReader["FILENAME"]);
                attachment.Path = Convert.ToString(sqlDataReader["PATH"]);
                attachment.ObjectID = fk_object;

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    byte[] fileData = (byte[])sqlDataReader["FILEDATA"];
                    attachment.FileData = fileData;
                }

                ret[attachment.AttachmentObjID] = attachment;
            }

            _dbConnector.Close();
            return ret;
        }


        public void Delete(IAttachment attachment, int fk_object)
        {
            SqlCommand command = new SqlCommand(_queryDelete, _dbConnector.GetConnectionObj());

            _dbConnector.Open();

            command.Parameters.AddWithValue("@FK_OBJECT", fk_object);
            command.Parameters.AddWithValue("@FK_ATTACHMENT", attachment.AttachmentObjID);

            _dbConnector.Delete(command);
            _dbConnector.Close();
        }
    }
}
