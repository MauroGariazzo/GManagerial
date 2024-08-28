using GManagerial.Products;

namespace GManagerial.WareHouse.models.WareHouseProducts
{
    internal class WareHouseProduct : Product,IWareHouseProduct
    {
        private int _id;
        private int _commitment;
        private int _order;
        private int _minimum_stock;
        private int _stock;
        private Supplier _supplier;
        private Warehouse _wareHouse;
        private decimal? _priceSupplier;

        public WareHouseProduct() : base()
        {

        }

        public int Id { get { return _id; } set { _id = value; } }
        public int Commitment { get { return _commitment; } set { _commitment = value; } } //->impegni
        public int Order { get { return _order; } set { _order = value; } }
        public int MinimumStock { get { return _minimum_stock; } set { _minimum_stock = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }

        /*public Product ProductProps
        {
            get { return product; }
            set { product = value; }
        }*/

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

        public void PassProductMembers(Product product)
        {
            this.ID = product.ID;
            this.ProductName = product.ProductName;

            this.Description = product.Description;
            this.SerialNumber = product.SerialNumber;
            this.BrandP = product.BrandP;
            if (product.ManufacturingDate != null)
            {
                this.ManufacturingDate = product.ManufacturingDate;
            }
            this.SetDepth(product.GetDepth.ToString());
            this.CategoryObj = product.CategoryObj;
            this.SubCategory = product.SubCategory;
            this.EnergyClass = product.EnergyClass;
            this.SetPower(product.GetPower.ToString());
            this.SetEnergyConsumption(product.GetEnergyConsumption.ToString());
            this.SetHeight(product.GetHeight.ToString());
            this.SetWeight(product.GetWeight.ToString());
            this.SetWidth(product.GetWidth.ToString());
            this.Image = product.Image;
            this.ResizedImage = product.ResizedImage;
            this.Notes = product.Notes;
            this.Barcode = product.Barcode;
            this.LastSupplierSelected = product.LastSupplierSelected;
        }
    }
}
