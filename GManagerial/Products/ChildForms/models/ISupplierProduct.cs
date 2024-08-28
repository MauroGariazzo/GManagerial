using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms.AddSupplier.models
{
    internal interface ISupplierProduct
    {
        int Id
        {
            get;
            set;
        }

        Product ProductProps
        {
            get;
            set;
        }

        Supplier SupplierProps
        {
            get;
            set;
        }
        /*int Product_id
        {
            get;
            set;
        }

        int Supplier_id
        {
            get;
            set;
        }*/

        void SetSupplierPrice(string price);
        decimal? GetSupplierPrice();

        /*string SupplierName
        {
            get;
            set;
        }*/

    }
}
