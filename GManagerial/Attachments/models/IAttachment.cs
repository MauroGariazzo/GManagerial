using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GManagerial
{
    internal interface IAttachment
    {
        int AttachmentObjID { get; set; }   
        string Extension { get; set; }
        Icon Icon { get; set; }
        string Path { get; set; }
        string FileName { get; set; }
        int ObjectID { get; set; }
        byte[] FileData { get; set; }


    }
}
