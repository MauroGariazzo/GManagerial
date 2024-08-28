using System;
using GManagerial.Products;

namespace GManagerial.Documents.OrderDocument.models
{
    internal class OrderProduct: Product, IOrderProduct
    {
        private int _id;
        private int _quantity;
        private decimal _netPrice;
        private decimal _discount;
        private string _tax;
        private decimal _amount;
        public OrderProduct() 
        {
            
        }

        public int IdOrderProduct { get { return _id; }  }  
        public int Quantity { get { return _quantity;} 
            set
            {
                if (value > 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("la quantità deve essere maggiore di zero.");
                }
            }
        }

        public decimal Price
        {
            get { return _netPrice; }
            set
            { 
                _netPrice = value;                
            }
        }

        public decimal Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public string Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set {
                if (value > 0)
                {
                    _amount = value;
                }

                else
                {
                    throw new ArgumentOutOfRangeException("il prezzo deve essere maggiore di zero.");
                }
            }
        }

    }
}
