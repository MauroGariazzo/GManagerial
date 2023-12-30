using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    public class priceProductInf
    {
        public float? Price { get; set; }
        public int ComboBoxIndex { get; set; }
        public string ComboBoxName { get; set; }
        public string ComboBoxItem { get; set; }
        public int id_supplier { get; set; }        
        public string tbName { get; set; }  
        public TextBox tb { get; set; }
        public priceProductInf(float? Price, int ComboBoxIndex, string comboBoxName, int id_supplier, string tbName, string ComboBoxItem, TextBox tb)
        {
            this.Price = Price;
            this.ComboBoxIndex = ComboBoxIndex;
            this.ComboBoxName = comboBoxName;
            this.id_supplier = id_supplier; 
            this.tbName = tbName;
            this.ComboBoxItem = ComboBoxItem;
            this.tb = tb;
        }
    }
}
