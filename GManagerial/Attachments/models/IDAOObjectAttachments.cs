using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Attachments
{
    internal interface IDAOObjectAttachemnts
    {
        void Insert(int fk_product, int fk_attachment);
        Dictionary<int, IAttachment> GetAll(int fk);
        void Delete(IAttachment attachment, int fk);
    }
}
