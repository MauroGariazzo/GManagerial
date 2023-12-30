using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms
{
    class PPLogic
    {
        static public void InsertPrices(int countFormPricesAccess, ref Boolean PriceFormExist, char nec, int Product_ID)
        {
            countFormPricesAccess = 0;

            if (PriceFormExist)
            {
                foreach (priceProductInf priceInf in ProductPrices.prices) //prices -> membro statico della classe ProductPrices
                {
                    if (nec == 'n' || nec == 'c')
                    {
                        ProductPricesMGM.InsertPrices(ProductsMGM.maxIdProduct(), priceInf.id_supplier,
                            priceInf.ComboBoxName, priceInf.Price, priceInf.tb);
                    }

                    else
                    {
                        ProductPricesMGM.InsertPrices(Product_ID, priceInf.id_supplier, priceInf.ComboBoxName, 
                            priceInf.Price, priceInf.tb);
                    }
                }
            }

            else
            {
                if (nec == 'n' || nec == 'c')
                {
                    ProductPricesMGM.InsertPrices(ProductsMGM.maxIdProduct(), 1, "", null, null);
                }

                else
                {
                    ProductPricesMGM.InsertPrices(ProductsMGM.maxIdProduct(), 1, "", null, null);
                }
            }

            PriceFormExist = false;

        }

        static public void resetAndCleanVars(ref int countFormPricesAccess, ref Boolean PriceFormExist)
        {
            countFormPricesAccess = 0;
            PriceFormExist = false;
        }
    }
}
