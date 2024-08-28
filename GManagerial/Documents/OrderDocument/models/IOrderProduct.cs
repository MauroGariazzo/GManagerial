using GManagerial.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GManagerial.Documents.OrderDocument.models
{
    internal interface IOrderProduct
    {
        int IdOrderProduct { get; }      
        int Quantity { get; set; }
        decimal Price { get; set; }
        decimal Discount { get; set; }
        string Tax { get; set; }
        decimal Amount { get; set; }

    }
}
