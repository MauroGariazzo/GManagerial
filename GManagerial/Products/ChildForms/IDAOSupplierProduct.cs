using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products.ChildForms.AddSupplier.models
{
    internal interface IDAOSupplierProduct
    {
        Dictionary<int, SupplierProduct> GetSelectedSuppliers(Product product_, string query);
        void Insert(SupplierProduct supplierProduct, int id_product);
        void Delete(SupplierProduct supplierProduct, int id_product);
        void Update(SupplierProduct supplierProduct);
        Dictionary<int, SupplierProduct> GetUnselectedProducts(Product product);


    }
}
