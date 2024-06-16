using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products
{
    internal interface ISellPrice
    {
        int Id
        {
            get;
            set;
        }

        int ProductId
        {
            get;
            set;
        }

        int SupplierId
        {
            get;
            set;
        }

        decimal GetPrice();

        bool SetPrice(string price);
        
    }
}
