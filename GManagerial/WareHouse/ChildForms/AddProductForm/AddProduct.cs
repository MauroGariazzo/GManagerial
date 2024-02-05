using GManagerial.Products.ChildForms;
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
    public partial class AddProduct : Form
    {
        public int product_id;
        private int supplier_id;
        private int categoryID;
        public ItemTag item;
        public bool isOK;

        private int selectedWareHouseID;

        public AddProduct(int selectedWareHouseID)
        {
            InitializeComponent();
            this.item = new ItemTag();
            this.selectedWareHouseID = selectedWareHouseID;
            this.isOK = false;
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
           AddProductMGM.ProductsForm_Load(productsLB);
        }

        private void productsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productsLB.SelectedIndex != -1)
            {
                ItemTag selectedProduct = (ItemTag)productsLB.SelectedItem;
                product_id = (int)selectedProduct.Tag;

                if (selectedProduct.Tag2 != null)
                {
                    supplier_id = (int)selectedProduct.Tag2;

                }
                

                AddProductMGM.LoadProductAnagraphic(codArticleTB, snTB, brandTB, manfDateTB, categoryTB, subCategoryTB,
                    descriptionTB, heightTB, depthTB, widthTB, weightTB, heightUM, depthUM, widthUM, weightUM, productPB,
                    product_id);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            /*if (productsLB.SelectedIndex != -1)
            {
                 AddSupplier addS = new AddSupplier(product_id);
                 addS.ShowDialog();

                 if(addS.item.Text != null)
                 {
                     item = addS.item;
                     this.isOK = true;   
                     this.Close();
                 }

                 else
                 {
                     FormLogicGUI.SelectElement("fornitore");
                 }

             }

             else
             {
                 FormLogicGUI.SelectElement("prodotto");
             }*/

            if (productsLB.SelectedIndex != -1)
            {

                InsertProdInf pi = new InsertProdInf(product_id, codArticleTB.Text);
                pi.ShowDialog();

                if (InsertProdInf.isOK)
                { this.Close(); }
                //
            }

            else
            {
                FormLogicGUIObsolete.SelectElement("prodotto");
            }

        }

        private void qtaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchLogic.searchBox_KeyDown(e, searchBox);
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Enter(searchBox);
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Leave(searchBox);
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchLogic.searchBox_KeyPress(sender, e);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "catCB", catCB },
            { "subCatCB", subCatCB }, { "brandCBsearch", brandCBsearch }};
            SearchLogic.FormSorting(searchBox, 'p', productsLB, comboBoxDictionary);
        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "catCB", catCB },
            { "subCatCB", subCatCB }, { "brandCBsearch", brandCBsearch }};

            SearchLogic.searchBtn_Click(searchPanel, searchBox, 'p', productsLB, comboBoxDictionary, searchBtn);
        }

        private void searchbtn2_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "catCB", catCB },
            { "subCatCB", subCatCB }, { "brandCBsearch", brandCBsearch }};
            SearchLogic.FormSorting(searchBox, 'p', productsLB, comboBoxDictionary);
        }

        private void resetCB_Click(object sender, EventArgs e)
        {
            SearchLogic.resetCB_Click(searchPanel);
        }

        private void catCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (catCB.SelectedItem != null && catCB.SelectedItem.ToString() != "")
            {
                subCatCB.Enabled = true;
                subCat.ForeColor = Color.Black;
            }

            ItemTag selectedCategory = (ItemTag)catCB.SelectedItem;

            if (selectedCategory != null)
            {
                categoryID = (int)selectedCategory.Tag;
            }
        }

        private void catCB_Click(object sender, EventArgs e)
        {
            catCB.Items.Clear();
            ProductsMGM.LoadCategories(catCB);
        }

        private void catCB_DropDownClosed(object sender, EventArgs e)
        {
            if (catCB.SelectedItem == null)
            {
                subCatCB.Enabled = false;
                subCat.ForeColor = Color.Gray;
                subCatCB.Text = null;
            }
            subCatCB.Items.Clear();
        }

        private void subCatCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ItemTag ScatSelectedItem = (ItemTag)subCatCB.SelectedItem;
            //if (ScatSelectedItem != null) { subCategoryID = (int)ScatSelectedItem.Tag; }
        }

        private void subCatCB_Click(object sender, EventArgs e)
        {
            subCatCB.Items.Clear();
            ProductsMGM.LoadSubCategories(categoryID, subCatCB);
        }

        private void brandCBsearch_Click(object sender, EventArgs e)
        {
            brandCBsearch.Items.Clear();
            ProductsMGM.AllBrands(brandCBsearch);

            //if (brandCBsearch.SelectedItem == null)
            //{
                //brandID = 1;
            //}
        }

        private void brandCBsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ItemTag BrandSelectedItem = (ItemTag)brandCBsearch.SelectedItem;
            //if (BrandSelectedItem != null) { brandID = (int)BrandSelectedItem.Tag; }
        }

    }
}
