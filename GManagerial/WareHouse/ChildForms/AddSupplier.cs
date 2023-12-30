using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.WareHouse.ChildForms
{
    public partial class AddSupplier : Form
    {
        private int product_id;
        public ItemTag item;
        public AddSupplier(int product_id)
        {
            this.product_id = product_id;
            this.item = new ItemTag();
            InitializeComponent();
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            InsertProdInfForm.InsertProdInfMGM.LoadProductListSuppliers(product_id, cbSupplier);
            cbSupplier.SelectedIndex = 0;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
           item = (ItemTag)cbSupplier.SelectedItem;
           item.Text = cbSupplier.Text;
           item.Tag = cbSupplier.Tag;
          
           this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}