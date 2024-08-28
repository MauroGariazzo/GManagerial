using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.WareHouse.models.WareHouseProducts
{
    static class WarehouseProductQueries
    {
        static public string LOADPRODUCTS = "UPDATE WAREHOUSEPRODUCT SET STOCK = STOCK + @STOCK WHERE PRODUCT_ID = @PRODUCT_ID AND WAREHOUSE_ID = @WAREHOUSE_ID";
        static public string UNLOADPRODUCTS = "UPDATE WAREHOUSEPRODUCT SET STOCK = STOCK - @STOCK WHERE PRODUCT_ID = @PRODUCT_ID AND WAREHOUSE_ID = @WAREHOUSE_ID";

    }
}
