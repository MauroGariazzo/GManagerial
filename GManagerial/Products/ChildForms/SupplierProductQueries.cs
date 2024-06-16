using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products.ChildForms
{
    static class SupplierProductQueries
    {
        static public string SELECTSUPPLIERSFORNEWPRODUCT = @"SELECT S.SUPPLIER_NAME, S.SUPPLIER_ID, PS.PRODUCT_ID, PS.PRODUCT_SUPPLIER_ID, PS.SUPPLIER_PRICE
                                                              FROM PRODUCT_SUPPLIER PS JOIN SUPPLIERSTBL S
                                                              ON PS.SUPPLIER_ID = S.SUPPLIER_ID
                                                              WHERE PS.PRODUCT_ID IS NULL";


        static public string SELECTSUPPLIERSFOREXISTINGPRODUCT = @"SELECT PS.PRODUCT_ID, S.SUPPLIER_NAME, PS.PRODUCT_SUPPLIER_ID, PS.SUPPLIER_ID,PS.SUPPLIER_PRICE
                                                                   FROM PRODUCT_SUPPLIER PS
                                                                   JOIN SUPPLIERSTBL S
                                                                   ON S.SUPPLIER_ID = PS.SUPPLIER_ID
                                                                   WHERE PS.PRODUCT_ID = @PRODUCT_ID";

        /*static public string SELECTPRODUCTSSUPPLIER = @"SELECT P.PRODUCT_NAME, S.SUPPLIER_NAME
                                                        FROM PRODUCTSTBL P
                                                        JOIN PRODUCT_SUPPLIER PS
                                                        ON P.PRODUCT_ID = PS.PRODUCT_ID
                                                        JOIN SUPPLIERSTBL S
                                                        ON PS.SUPPLIER_ID = S.SUPPLIER_ID
                                                        WHERE PS.SUPPLIER_ID = @SUPPLIER_ID";*/
    }
}
