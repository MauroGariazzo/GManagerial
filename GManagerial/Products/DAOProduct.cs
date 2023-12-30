using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Products
{
    internal class DAOProduct:IDAOProduct
    {
        public void Insert(IProduct product)
        {

        }

        public List<IProduct> GetAll()
        {
            List<IProduct> ip= new List<IProduct>();
            return ip;    
        }
        public void Update(IProduct product)
        {

        }
    }
}
