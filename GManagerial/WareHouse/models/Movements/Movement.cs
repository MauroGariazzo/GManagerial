using GManagerial.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.WareHouse.models.Movements
{
    internal class Movement:IMovement, IAttachmentParent
    {
        private int _movement_ID;
        private string _movementType;
        private int _warehouse_id;
        private string _causal;
        private DateTime _date;

        private Dictionary<int, IAttachment> _attachments;
        private Dictionary<int, IAttachment> _tempAttachments;
        private Dictionary<int, IAttachment> _attachmentsToDelete;


        public Movement()
        {
            this._attachments = new Dictionary<int, IAttachment>();
            this._tempAttachments = new Dictionary<int, IAttachment>();
            this._attachmentsToDelete = new Dictionary<int, IAttachment>();
        }
        public int ID
        {
            get { return _movement_ID; }
            set { _movement_ID = value; }
        }

        public string MovementType
        {
            get { return _movementType; } 
            set 
            {
                if (!value.Equals(string.Empty))
                {
                    _movementType = value;
                }

                else
                {
                    MessageBox.Show("Tipo di movimento non valido");
                }
            }
        }

        public int WareHouseFK
        {
            get { return _warehouse_id; }
            set { _warehouse_id = value; }
        }

        public DateTime DateMovement
        {
            get { return _date; } 
            set { _date = value; }
        }

        public string Causal
        {
            get { return _causal; }
            set { _causal = value; }
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
