using GManagerial.Products;
using GManagerial.WareHouse.models.WareHouseProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.WareHouse.models.Movements
{
    internal interface IDetailsMovement
    {
        int ID
        {
            get;
            set;
        }

        /*Product ProductProps
        {
            get; 
            set;
        }*/

        Supplier SupplierProps
        {
            get;
            set;
        }

        Warehouse WarehouseProps
        {
            get;
            set;
        }

        Movement MovementProps
        {
            get;
            set;
        }

        string MovementType
        {
            get;
            set;
        }

        int Quantity
        {
            get; set;
        }

        WareHouseProduct WarehouseproductProps
        {
            get; set;
        }

    }
}
