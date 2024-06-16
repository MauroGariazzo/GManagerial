using GeoAPI.IO;
using GManagerial.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    internal class Customer : ICustomer, IAttachmentParent
    {
        public Customer() { }

        private int _id;
        private string _name;
        private string _idTax;
        private string _email;
        private string _telephone;
        private string _address;
        private string _city;
        private string _region;
        private string _province;
        private string _zipCode;
        private string _pec;
        private string _mobile;
        private string _notes;
        private string _birthDate;

        private Dictionary<int, IAttachment> _attachments;
        private Dictionary<int, IAttachment> _tempAttachments;
        private Dictionary<int, IAttachment> _attachmentsToDelete;

        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    //MessageBox.Show("Non puoi lasciare il campo vuoto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new ArgumentException("Non puoi creare un cliente senza nome");
                }
            }
        }

        public string IdTax
        {
            get { return _idTax; }
            set { _idTax = value; }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
            }
        }

        public string Address
        {
            get { return _address; }
                        set
            {
                _address = value;
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
            }
        }

        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;
            }
        }

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
                    throw new ArgumentException("Cap non valido");
                }
            }
        }
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public string Pec
        {
            get { return _pec; }
                        set
            {
                _pec = value;
            }
        }

        public string Province
        {
            get { return _province; }
                        set
            {
                _province = value;
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

        public string BirthDate
        {
            get
            {
                return _birthDate;
            }

            set
            {
                DateTime dateConverted;

                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy" }, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateConverted))
                {
                    _birthDate = Convert.ToString(dateConverted);
                }

                else
                if (value == string.Empty)
                {
                    _birthDate = value;
                }

                else
                {
                    //MessageBox.Show("Data non corretta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw new ParseException("Data non corretta");
                }
            }
        }
    }
}
