using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products
{
    internal interface IDAOProduct
    {
        void Insert(IProduct product);
        List<IProduct> GetAll();
        void Update(IProduct product);  
        
    }
}
