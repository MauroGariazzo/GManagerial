using GManagerial.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.WareHouse.models.WareHouseProducts
{
    internal class WareHouseProduct:IWareHouseProduct
    {
        private int _id;
        private int _commitment;
        private int _order;
        private int _minimum_stock;
        private int _stock;
        private Product _product;
        private Supplier _supplier;
        private Warehouse _wareHouse;
        private decimal? _priceSupplier;

        public int Id { get { return _id; } set { _id = value; } }
        public int Commitment { get { return _commitment; } set { _commitment = value; } } //->impegni
        public int Order { get { return _order; } set { _order = value; } }
        public int MinimumStock { get {return _minimum_stock; } set { _minimum_stock = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }

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
        public Warehouse WarehouseProps
        {
            get { return _wareHouse; }
            set { _wareHouse = value; }
        }

        public decimal? PriceSupplier
        {
            get { return _priceSupplier; }
        }

        public void SetPriceSupplier(string price)
        {
            decimal value = 0.0M;
            if (decimal.TryParse(price, out value))
            {
                _priceSupplier = value;
            }

            else
            {
                _priceSupplier = null;
            }
        }
    }
}
