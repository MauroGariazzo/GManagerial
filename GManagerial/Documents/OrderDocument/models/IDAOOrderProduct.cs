using GManagerial.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Documents.OrderDocument.models
{
    internal interface IDAOOrderProduct
    {
        int Insert(OrderProduct product);
        void Update(OrderProduct product);
        void Delete(OrderProduct product);
        Dictionary<int,OrderProduct> GetAll();
    }
}
