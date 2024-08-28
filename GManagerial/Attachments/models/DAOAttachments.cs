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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NGeo.Yahoo.PlaceFinder;
using GManagerial.DBConnectors;

namespace GManagerial.Attachments
{
    internal class DAOAttachments : IDAOAttchments
    {

        private IDBConnector _dbConnector;
        private string _queryInsert, _queryDelete;
        public DAOAttachments(IDBConnector dBConnector, string queryInsert, string queryDelete)
        {
            this._dbConnector = dBConnector;

            this._queryInsert = queryInsert;
            this._queryDelete = queryDelete;
        }

        public int Insert(IAttachment attachment)
        {
            SqlCommand insertAttachmentIntoAttachmentsTbl = new SqlCommand(this._queryInsert, _dbConnector.GetConnectionObj());

            _dbConnector.Open();
            IconConverter converter = new IconConverter();

            byte[] iconImageData = (byte[])converter.ConvertTo(attachment.Icon, typeof(byte[]));

            string filepath = attachment.Path;
            byte[] fileData = System.IO.File.ReadAllBytes(filepath);

            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@FILENAME", attachment.FileName);
            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@PATH", attachment.Path);
            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@IMAGE", iconImageData);
            insertAttachmentIntoAttachmentsTbl.Parameters.AddWithValue("@FILEDATA", fileData);

            int idAttachment = Convert.ToInt32(insertAttachmentIntoAttachmentsTbl.ExecuteScalar());

            _dbConnector.Close();

            return idAttachment;
        }

        public void Delete(IAttachment attachment)
        {
            SqlCommand sqlCommand = new SqlCommand(this._queryDelete, _dbConnector.GetConnectionObj());
            _dbConnector.Open();

            sqlCommand.Parameters.AddWithValue("@ID_ATTACHMENT", attachment.AttachmentObjID);

            _dbConnector.Delete(sqlCommand);
            this._dbConnector.Close();
        }


    }
}
