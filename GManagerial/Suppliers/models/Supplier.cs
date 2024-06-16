using GManagerial.Attachments;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GManagerial
{
    internal class Supplier:ISupplier, IAttachmentParent
    {
        private int _ID;
        private string _supplierName;
        private string _idTax;
        private string _vat;
        private string _recipientCode;
        private string _region;
        private string _province;
        private string _provinceSigle;
        private string _address;
        private string _city;
        private string _telephone;
        private string _mobile;
        private string _zipCode;
        private string _email;
        private string _pec;
        private string _notes;
        private Dictionary<int, IAttachment> _attachments;
        private Dictionary<int, IAttachment> _tempAttachments;
        private Dictionary<int, IAttachment> _attachmentsToDelete;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string SupplierName 
        { 
            get { return _supplierName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _supplierName = value;
                }

                else
                {
                    throw new ArgumentException("Non puoi creare un fornitore senza nome");
                }
            } 
        }

        public string IdTax { get { return _idTax; } set { _idTax = value; } }
        public string Vat { get { return _vat; } set { _vat = value; } }
        public string RecipientCode { get { return _recipientCode; } set { _recipientCode = value; } }
        public string Region { get { return _region; } set { _region = value; } }
        public string Province { get { return _province; } set { _province = value; } }
        public string ProvinceSigle { get { return _provinceSigle; } set { _provinceSigle = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Telephone { get { return _telephone; } 
            set
            {
                _telephone = value;
            } }
        public string Mobile { get { return _mobile; }
            set
            {
                _mobile = value;
            } }
        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                if (value.Length <= 5)
                {
                    _zipCode = value;
                }

                else
                {
                    throw new Exception("Cap non valido");
                }
            }
        }

        public string Email { get { return _email; }
            set
            {
                _email = value;
            } }
        public string Pec { get { return _pec; }
            set
            {
                _pec = value;
            } }
        public string Notes 
        { 
            get 
            {
                if(_notes is null)
                {
                    return string.Empty;
                }
                return _notes; 
            } 
            set
            {
                _notes = value;
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

    }
}
