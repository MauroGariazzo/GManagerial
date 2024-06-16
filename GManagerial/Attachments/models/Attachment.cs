using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GManagerial.Attachments;

namespace GManagerial
{
    internal class Attachment : IAttachment
    {
        private int _attachmentObjID;
        private string _extension;
        private Icon _icon;
        private string _path;
        private string _fileName;
        private int _objectID; //id dell'oggetto che sia un prodotto, cliente, fornitore
        private byte[] _fileData; //file trasformato in byte
        public Attachment()
        {

        }

        public string Extension { get { return _extension; } set { _extension = value; } }
        public int AttachmentObjID { get { return _attachmentObjID; } set { _attachmentObjID = value; } }
        public Icon Icon { get { return _icon;} set { _icon = value; } }
        public string Path { get { return _path;} set { _path = value; } }
        public string FileName { get { return _fileName;} set { _fileName = value; } }  
        public int ObjectID { get { return _objectID; } set { _objectID = value; } }

        public byte[] FileData { get { return _fileData;} set{ _fileData = value; } }
    }
}
