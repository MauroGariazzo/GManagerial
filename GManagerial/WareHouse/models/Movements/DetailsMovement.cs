using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GManagerial.Products;
using GManagerial.WareHouse.models.WareHouseProducts;

namespace GManagerial.WareHouse.models.Movements
{
    internal class DetailsMovement:IDetailsMovement
    {
        private int _id;
        private Movement _movement;
        private WareHouseProduct _warehouseproduct;
        private Supplier _supplier;
        private Warehouse _warehouse;
        private string _movementType;
        private int _quantity;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Supplier SupplierProps
        {
            get { return _supplier; }
            set { _supplier = value; }
        }

        public Warehouse WarehouseProps
        {
            get { return _warehouse; }
                        set
            {
                _warehouse = value;
            }
        }

        public Movement MovementProps
        {
            get { return _movement; }
                        set
            {
                _movement = value;
            }
        }

        public string MovementType
        {
            get { return _movementType; }
            set { _movementType = value; }
        }
       
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public WareHouseProduct WarehouseproductProps
        {
            get { return _warehouseproduct; }
            set { _warehouseproduct = value; }
        }

    }
}
