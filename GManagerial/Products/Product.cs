using GeoAPI.IO;
using GManagerial.Attachments;
using GManagerial.DBConnectors;
using GManagerial.Products.ChildForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GManagerial.Products
{
    internal class Product: IProduct, IAttachmentParent
    {
        private int _ID;
        private string _product_name;
        private string _serialNumber;
        private string _manufacturingDate;

        private ICategory _categoryObj;
        private ISubCategory _subCategory;

        private string _description;
        private decimal? _height;
        private decimal? _width;
        private decimal? _depth;
        private decimal? _weight;
        private string _energyClass;
        private decimal? _power;
        private decimal? _energyConsumption;
        private string _notes;
        private string _barcode;
        private int _stock;
        private int _lastSupplierSelected;

        private System.Drawing.Image _image;
        private System.Drawing.Image _resizedImage;
        private IBrand _brandP;

        private Dictionary<int, IAttachment> _attachments;
        private Dictionary<int, IAttachment> _tempAttachments;
        private Dictionary<int, IAttachment> _attachmentsToDelete;

        //private IDBConnector.IDBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        //private DAOObjectAttachments _daoObjectAttachments;
    
        public Product()
        {
            this._description = string.Empty;
            this._serialNumber = string.Empty;
            this._notes = string.Empty;
            this._energyClass = string.Empty;
            //this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector, AttachmentQuery.SELECT_PRODUCT, AttachmentQuery.INSERT_PRODUCT, AttachmentQuery.DELETE_PRODUCT);
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string ProductName
        {
            get { return _product_name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _product_name = value;
                }
                else
                {
                    //MessageBox.Show("Non puoi lasciare il campo vuoto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new ArgumentException("Non puoi creare un articolo senza nome");
                }
            }
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }


        public string ManufacturingDate
        {
            get { return _manufacturingDate; }

            set 
            {
                DateTime dateConverted;

                if(DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/M/yyyy", "d/MM/yyyy", "d/M/yyyy" }, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateConverted))
                {
                    _manufacturingDate = Convert.ToString(dateConverted);
                }

                else
                if(value == string.Empty)
                {
                    _manufacturingDate = value;
                }

                else
                {
                    //MessageBox.Show("Data non corretta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new ParseException("Data non corretta");
                }
            }
        }

        public ICategory CategoryObj
        {
            get { return _categoryObj; }
            set { _categoryObj = value; }
        }

        public ISubCategory SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public void SetHeight(string value)
        {
            if(ConvertToDecimal(value) && value != string.Empty)
            {
                _height = Convert.ToDecimal(value);
            }
            else
            {
                _height = null;
            }
        }

        public Decimal? GetHeight
        {
            get { return _height; }
        }
        public void SetWidth(string value)
        {
            if(ConvertToDecimal(value) && value != string.Empty)
            {
                _width = Convert.ToDecimal(value);
            }
            else
            {
                _width = null;
            }
        }

        public Decimal? GetWidth
        {
            get { return _width; }
        }

        public decimal? GetDepth
        {
            get { return _depth; }
        }

        public void SetDepth(string value)
        {
            if (ConvertToDecimal(value) && value != string.Empty)
            {
                _depth = Convert.ToDecimal(value);
            }
            else
            {
                _depth = null;
            }
        }
        public void SetWeight(string value)
        {
            if (ConvertToDecimal(value) && value != string.Empty)
            {
                _weight = Convert.ToDecimal(value);
            }

            else
            {
                _weight = null;
            }
        }

        public decimal? GetWeight
        {
            get { return _weight; }
        }

        public string EnergyClass
        {
            get { return _energyClass; }
            set { _energyClass = value; }
        }

        public void SetPower(string value)
        {
            if (ConvertToDecimal(value) && value != string.Empty)
            {
                _power = Convert.ToDecimal(value);
            }

            else
            {
                _power = null;
            }
        }
        public decimal? GetPower
        {
            get { return _power; }
        }

        public void SetEnergyConsumption(string value)
        {
            if (ConvertToDecimal(value) && value != string.Empty)
            {
                _energyConsumption = Convert.ToDecimal(value);
            }
            else
            {
                _energyConsumption = null;
            }
        }

        public decimal? GetEnergyConsumption
        {
            get { return _energyConsumption; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        public System.Drawing.Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public System.Drawing.Image ResizedImage
        {
            get { return _resizedImage; }
            set { _resizedImage = value; }
        }
        public IBrand BrandP
        {
            get
            {
                return _brandP;
            }

            set 
            {
                _brandP = value; 
            }
        }


        public Dictionary<int, IAttachment> Attachments
        {
            get { return _attachments; }
            set { _attachments = value; }
        }

        public Dictionary<int, IAttachment> TempAttachments
        {
            get { return _tempAttachments; }
            set { _tempAttachments = value; }
        }

        public Dictionary<int, IAttachment> AttachmentsToDelete
        {
            get { return _attachmentsToDelete; }
            set { _attachmentsToDelete = value; }
        }

        public byte[] ConvertImageToArrayBytes()
        {
            byte[] byteImage;
            System.Drawing.Image image = new Bitmap(_image);

            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp); // Puoi specificare il formato desiderato
                byteImage = stream.ToArray();
            }

            return byteImage;
        }

        public byte[] ConvertResizeImageToArrayBytes()
        {
            byte[] fileData;

            using (System.Drawing.Image resizedImage = new Bitmap(_image, 100, 100))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    resizedImage.Save(ms, ImageFormat.Jpeg);

                    fileData = ms.ToArray();
                }
            }
            return fileData;
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        /*public void PopulateAttachmentsToDelete()
        {
            AttachmentsToDelete = _daoObjectAttachments.GetAll(ID); //popolo il dizionario prendendo i dati dalla query
        }

        public void PopulateAttachments()
        {
            Attachments = _daoObjectAttachments.GetAll(ID); //popolo il dizionario prendendo i dati dalla query
        }*/

        private bool ConvertToDecimal(string value)
        {
            if (Decimal.TryParse(value, out _) || value == string.Empty)
            {
                return true;
            }
            return false;
            //throw new ParseException("Errore nella conversione");
        }

        public int LastSupplierSelected
        {
            get { return _lastSupplierSelected; }
            set { _lastSupplierSelected = value; }
        }
    }

}
