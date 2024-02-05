using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products
{
    internal interface IDAOProduct
    {
        int Insert(IProduct product);
        Dictionary<int, Product> GetAll();
        void Update(IProduct product); 
        void Delete(IProduct product);  
        
    }
}
