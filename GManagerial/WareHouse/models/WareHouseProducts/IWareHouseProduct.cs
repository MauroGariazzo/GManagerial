using GManagerial.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.WareHouse.models.WareHouseProducts
{
    internal interface IWareHouseProduct
    {
        int Id { get; set; }
       /* Product ProductProps { get; set; }*/
        Supplier SupplierProps { get; set; }
        Warehouse WarehouseProps { get; set; }

        int Commitment { get; set; } //->impegni
        int Order { get; set; }
        int MinimumStock { get; set; }
        int Stock { get; set; }

        decimal? PriceSupplier { get; }
        void SetPriceSupplier(string price);
    }
}
