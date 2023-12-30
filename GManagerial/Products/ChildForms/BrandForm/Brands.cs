using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial.Products.ChildForms
{
    public partial class Brands : Form
    {
        public Brands()
        {
            InitializeComponent();
        }

        private void Brands_Load(object sender, EventArgs e)
        {
            BrandMGM.LoadBrandDB(brandList);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddBrand add = new AddBrand(brandList, 'n');
            add.ShowDialog();   
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            ItemTag selectedItem = (ItemTag)brandList.SelectedItem;

            if (brandList.SelectedItem != null)
            {
                try
                {
                    if (selectedItem != null)
                    {
                        AddBrand add = new AddBrand(brandList, 'e', selectedItem);
                        add.ShowDialog();
                    }
                }

                catch (NullReferenceException)
                {
                    return;
                }
            }
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            ItemTag selectedItem = (ItemTag)brandList.SelectedItem;

            if (brandList.SelectedItem != null)
            {
                try
                {
                    if (selectedItem != null)
                    {
                        DialogResult result = MessageBox.Show("Vuoi cancellare l'elemento selezionato?", "Conferma", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            BrandMGM.DeleteBrandDB(Convert.ToInt32(selectedItem.Tag));
                            brandList.Items.Clear();    
                            BrandMGM.LoadBrandDB(brandList);
                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                catch (NullReferenceException)
                {
                    return;
                }
            }
        }
    }
}
