using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GManagerial.Products.ChildForms.ProductPricesForm;

namespace GManagerial.Products.ChildForms
{
    public partial class ProductPrices : Form
    {
        static public List<priceProductInf> prices { get; set; }
        private char nec;
        private int product_id;
        private int countFormAccess;
        public ProductPrices(char nec, int product_id, int countFormAccess)
        {
            InitializeComponent();
            this.nec = nec;
            this.product_id = product_id;
            this.countFormAccess = countFormAccess;
        }


        private void ProductPrices_Load(object sender, EventArgs e)
        {
            LoadSuppliers();

            if (this.nec == 'n' && countFormAccess == 1)
            {
                LoadEmptySupplier();
            }

            else if (this.nec == 'e' && countFormAccess == 1 || this.nec == 'c' && countFormAccess == 1)
            {
                LoadPricesAndSelectedSupplier();
            }

            else
            {
                LoadFormFromTempData();
            }

        }


        private void LoadFormFromTempData()
        {
            foreach (priceProductInf price in prices)
            {
                string TBName = price.tbName; //nome della textbox
                string CBName = price.ComboBoxName;

                Control TBToModify = Controls.Find(TBName, true).FirstOrDefault();
                Control CBToModify = Controls.Find(CBName, true).FirstOrDefault();

                if (TBToModify != null && TBToModify is System.Windows.Forms.TextBox textBox)
                {
                    if (price.Price.HasValue)
                    {
                        float rPrice = price.Price.Value;
                        textBox.Text = rPrice.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    textBox.Text = textBox.Text.Replace(".", ",");
                }

                if (CBToModify != null && CBToModify is System.Windows.Forms.ComboBox cb)
                {
                    string item = price.ComboBoxItem.ToString();

                    foreach (ItemTag itemTag in cb.Items)
                    {
                        if (itemTag.Text == item)
                        {
                            cb.SelectedItem = itemTag;
                        }
                    }
                }

            }
        }


        public void LoadSuppliers()
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    GroupBox gb = (GroupBox)control;
                    foreach (Control contr in gb.Controls)
                    {
                        if (contr is System.Windows.Forms.ComboBox)
                        {
                            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)contr;
                            ProductPricesMGM.LoadListSuppliers(cb);
                        }
                    }

                }
            }
        }

        private void LoadPricesAndSelectedSupplier()
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    GroupBox gb = (GroupBox)control;

                    System.Windows.Forms.TextBox tbPrice = groupBox.Controls.OfType<System.Windows.Forms.TextBox>().FirstOrDefault();
                    System.Windows.Forms.ComboBox cbSuppl = groupBox.Controls.OfType<System.Windows.Forms.ComboBox>().FirstOrDefault();

                    ProductPricesMGM.LoadPricesAndSelectedSupplier(tbPrice, cbSuppl, product_id);
                }
            }
        }

        public void LoadEmptySupplier()
        {
            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)control;

                    if (cb.SelectedItem == null)
                    {
                        cb.SelectedIndex = 0;
                    }
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductPrices_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
        }

        private void saveData()
        {
            float? price;
            ItemTag selectedItem = new ItemTag();
            System.Windows.Forms.ComboBox cbSuppl = new System.Windows.Forms.ComboBox();
            prices = new List<priceProductInf>();

            foreach (Control control in this.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    System.Windows.Forms.TextBox tbPrice = groupBox.Controls.OfType<System.Windows.Forms.TextBox>().FirstOrDefault();
                    cbSuppl = groupBox.Controls.OfType<System.Windows.Forms.ComboBox>().FirstOrDefault();

                    if (tbPrice != null && cbSuppl != null)
                    {
                        if (float.TryParse(tbPrice.Text, out float priceFloat))
                        {
                            price = priceFloat;
                        }

                        else
                        {
                            price = null;
                        }


                        selectedItem = (ItemTag)cbSuppl.SelectedItem;

                        priceProductInf priceinf = new priceProductInf(price, cbSuppl.SelectedIndex, cbSuppl.Name,
                            Convert.ToInt32(selectedItem.Tag), tbPrice.Name, cbSuppl.SelectedItem.ToString(), tbPrice);

                        prices.Add(priceinf);
                    }

                }
            }
        }


        private void priceTB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.priceTB_KeyPress(sender, e, priceTB1);
        }

        private void priceTB2_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.priceTB_KeyPress(sender, e, priceTB2);
        }

        private void priceTB3_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.priceTB_KeyPress(sender, e, priceTB3);
        }

        private void priceTB4_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.priceTB_KeyPress(sender, e, priceTB4);
        }

        private void AddSuppliersBtn_Click(object sender, EventArgs e)
        {
            AddSupplier aNs = new AddSupplier();
            aNs.FormClosedEvent += (s, args) => LoadSuppliers();
            aNs.ShowDialog();
            
        }
    }
}
