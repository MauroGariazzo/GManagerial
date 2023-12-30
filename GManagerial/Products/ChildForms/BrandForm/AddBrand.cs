using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Products.ChildForms
{
    public partial class AddBrand : Form
    {
        ListBox brandList;
        char nec;
        ItemTag selectedItem;
        public AddBrand(ListBox brandList, char nec)
        {
            this.brandList = brandList; 
            this.nec = nec;                 //NEW
            InitializeComponent();
        }

        public AddBrand(ListBox brandList, char nec, ItemTag selectedItem) 
        {
            this.brandList = brandList;
            this.nec = nec;
            this.selectedItem = selectedItem;    //EDIT
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (brandTB.Text != "" && brandTB.Text != null) 
            {
                if (this.nec == 'n') 
                {
                    BrandMGM.IsNewOrEdit(nec, brandTB, 0);  
                }

                else
                {
                    BrandMGM.IsNewOrEdit(nec, brandTB, Convert.ToInt32(selectedItem.Tag));
                }

            }

            else
            {
                MessageBox.Show("Non puoi lasciare il campo vuoto", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            brandList.Items.Clear();
            BrandMGM.LoadBrandDB(brandList);
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBrand_Load(object sender, EventArgs e)
        {
            if (this.nec == 'e')
            {
                brandTB.Text = selectedItem.Text;
            }
        }
    }
}
