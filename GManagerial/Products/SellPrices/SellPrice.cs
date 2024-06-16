using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products
{
    internal class SellPrice:ISellPrice
    {
        private int _id;
        private int _productId;
        private int _supplierId;
        private decimal _price;
        private string _listPrice;
        //private int _productPricesFK;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /*public int ProductPricesFK
        {
            get { return _productPricesFK; }
            set { _productPricesFK = value; }
        }*/

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public int SupplierId
        {
            get { return _supplierId; }
            set { _supplierId = value; }
        }

        public decimal GetPrice()
        {
            return _price;
        }

        public bool SetPrice(string price)
        {
            decimal result;
            if(decimal.TryParse(price, out result) || string.IsNullOrWhiteSpace(price))
            {
                _price = result;
                return true;
            }

            else
            {
                MessageBox.Show("Errore nella conversione", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public string ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }
    }
}
