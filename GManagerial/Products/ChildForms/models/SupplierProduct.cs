using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms.AddSupplier.models
{
    internal class SupplierProduct : ISupplierProduct
    {
        private int _id;
        //private int _product_id;
        private Product _product;
        private Supplier _supplier;
        //private int _supplier_id;
        private string _supplier_name;
        private decimal? _supplier_price;

        public SupplierProduct()
        {

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Product ProductProps
        {
            get { return _product; }
            set { _product = value; }
        }

        public Supplier SupplierProps
        {
            get { return _supplier; }
            set { _supplier = value; }
        }


        public void SetSupplierPrice(string price)
        {
            decimal value = 0.0M;
            if (decimal.TryParse(price, out value))
            {
                _supplier_price = value;
            }

            else
            {
                _supplier_price = null;
            }
        }

        public decimal? GetSupplierPrice()
        {
            return _supplier_price;
        }
    }
}
