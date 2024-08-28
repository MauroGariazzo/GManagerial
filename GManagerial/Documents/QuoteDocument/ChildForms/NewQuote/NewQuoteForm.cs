using GManagerial.WareHouse.ChildForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.QuoteDocForms;

namespace GManagerial.QuoteDocForms.ChildForms
{
    public partial class NewQuoteForm : Form
    {
        public NewQuoteForm()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
