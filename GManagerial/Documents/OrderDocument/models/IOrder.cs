using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GManagerial.Products;

namespace GManagerial.Documents.OrderDocument.models
{
    internal interface IOrder
    {
        int Id { get; set; }
        List<OrderProduct> Products { get;set; }
        Supplier Supplier { get; set; }
        DateTime CreationDate { get; set; }
        decimal TotalDocumentAmount { get; set; }
        decimal TaxAmount { get; set; } //non la percentuale ma il costo intero
        decimal TotalDocumentAmountWithTax { get; set; }


    }
}
