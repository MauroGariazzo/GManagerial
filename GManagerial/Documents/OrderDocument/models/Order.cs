using System;
using System.Collections.Generic;
using GManagerial.Products;

namespace GManagerial.Documents.OrderDocument.models
{
    internal class Order:IOrder
    {
        private int _id;
        private List<OrderProduct> _products;
        private Supplier _supplier;
        private DateTime _creationDate;
        private decimal _totalDocumentAmount;
        private decimal _taxAmount; //non la percentuale ma il costo intero
        private decimal _totalDocumentAmountWithTax;

        public Order()
        {
            _products = new List<OrderProduct>();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<OrderProduct> Products { get { return _products; } set { _products = value; } }

        public Supplier Supplier { get { return _supplier; } set { _supplier = value; } }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public decimal TotalDocumentAmount
        {
            get { return _totalDocumentAmount; }
            set { _totalDocumentAmount = value; }
        }

        public decimal TaxAmount
        {
            get { return _taxAmount; }
            set { _taxAmount = value; }
        }

        public decimal TotalDocumentAmountWithTax
        {
            get { return _totalDocumentAmountWithTax;}
                        set
            {
                _totalDocumentAmountWithTax = value;
            }
        }

    }
}
