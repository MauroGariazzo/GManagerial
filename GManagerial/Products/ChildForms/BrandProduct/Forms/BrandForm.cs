using GManagerial.DBConnectors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace GManagerial.Products.ChildForms
{
    public partial class BrandForm : Form
    {
        private IDBConnector _dbConnector;
        private DAOBrand _daoBrand;
        private Dictionary<string, IBrand> _brands;
        private Brand _brand;
        private BrandInfoForm _add;

        private BrandUpdate _callBack;
        public BrandForm()
        {
            InitializeComponent();
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True"); 
            this._daoBrand = new DAOBrand(this._dbConnector);    
            this._brand = new Brand();
        }

        public void SetCallBack(BrandUpdate callBack)
        {
            _callBack = callBack;
        }

        private void Brands_Load(object sender, EventArgs e)
        {
            this._brands = _daoBrand.GetAllDictionaries();
            this.brandList.Items.Clear();

            foreach (Brand brand in _brands.Values)
            {
                if(brand.ID != 1)
                {
                    brandList.Items.Add(brand);
                }
            }

            brandList.DisplayMember = "Name";    
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            _add = new BrandInfoForm();
            _add.Nec = 'n';
            _add.ShowDialog();
            Brands_Load(sender, e);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (brandList.SelectedItem != null)
            {
                _brand = brandList.SelectedItem as Brand;
                _add = new BrandInfoForm(_brand);
                _add.Nec = 'e';
                _add.ShowDialog();

                Brands_Load(sender, e);
            }

            else
            {
                MessageBox.Show("seleziona prima un elemento");
            }
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (brandList.SelectedItem != null)
            {
                _brand = brandList.SelectedItem as Brand;
                DialogResult result = MessageBox.Show("Vuoi cancellare l'elemento selezionato?", "Conferma", MessageBoxButtons.YesNo);

                if (result.Equals(DialogResult.Yes))
                {
                    _daoBrand.Delete(_brand);
                    Brands_Load(sender, e);
                }

            }

            else
            {
                MessageBox.Show("seleziona prima un elemento");
            }
        }

        private void BrandForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_callBack != null)
            {
                _callBack(); //richiamo il delegate che contiene:                                   /*private void OnUpdateBrand()
            }
                                                                                               //{
        }                                                                                      //   this.brands = this.daoBrand.GetAllDictionaries();
    }                                                                                          //   BrandCB.Items.Clear();
}                                                                                              //   foreach (IBrand brand in brands.Values)
                                                                                               //   {
                                                                                               //       BrandCB.Items.Add(brand.Name);
                                                                                               //   }
                                                                                               // }







/*ItemTag selectedItem = (ItemTag)brandList.SelectedItem;

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
            if (brandList.SelectedItem != null)
            {
                IBrand brand = (IBrand)brandList.SelectedItem;  

                if(product.BrandP.ID == brand.ID)
                {
                    //product.BrandP.ID = null;
                }

                daoBrand.Delete(brand); 
            }*/