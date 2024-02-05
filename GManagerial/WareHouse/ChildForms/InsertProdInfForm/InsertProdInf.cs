using System;
using System.Collections;
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
    public partial class InsertProdInf : Form
    {
        private int product_id;
        static public Dictionary<string, object> prodInf = new Dictionary<string, object>();
        static public Boolean isOK;
        private string codArticleTB;
        private char nec;
        private string supplier_item;
        private string wareHouse_item;
        private int qtaTB;
        public InsertProdInf(int product_id, string codArticleTb)  //costruttore per new
        {
            this.product_id = product_id;
            isOK = false;
            this.codArticleTB = codArticleTb;
            
            InitializeComponent();
        }

        public InsertProdInf(int product_id, char nec, string supplier_item, string wareHouse_item, int qtaTB) //costruzione per edit
        {
            this.product_id = product_id;
            isOK = false;
            this.nec = nec;
            this.supplier_item = supplier_item;
            this.wareHouse_item = wareHouse_item;
            this.qtaTB = qtaTB;
            InitializeComponent();
        }


        private void SelectProductBySupplier_Load(object sender, EventArgs e)
        {
            InsertProdInfForm.InsertProdInfMGM.LoadProductListSuppliers(product_id, cbSupplier);
            InsertProdInfForm.InsertProdInfMGM.LoadUM(umCB);
            WarehouseMGM.LoadWareHouseNamesForComboBox(wareHouseCB);

            if (this.nec != 'e')
            {      
                umCB.SelectedIndex = umCB.Items.Count - 1;

                if (this.cbSupplier.Items.Count > 0)
                {
                    this.cbSupplier.SelectedIndex = 0;
                }
            }

            else
            {
                LoadEditProductInTB();
            }
        }

        private void LoadEditProductInTB()
        {
            cbSupplier.Text = supplier_item;
            wareHouseCB.Text = wareHouse_item;
            stockTB.Text = qtaTB.ToString();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            isOK = false;   
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if(wareHouseCB.SelectedIndex != -1)
            {
                if (Expiration_dateTB.BackColor != System.Drawing.Color.Red)
                {
                    if (stockTB.Text != "" && stockTB.Text != null)
                    {
                        int stock;

                        if(int.TryParse(stockTB.Text, out stock))
                        {
                            if (stock != 0)
                            {
                                InsertDataIntoDictionary(stock);
                            }

                            else
                            {
                                FormLogicGUIObsolete.AddQuantity();
                            }
                        }

                        else
                        {
                            FormLogicGUIObsolete.AddQuantity();
                        }

                    }

                    else
                    {
                        FormLogicGUIObsolete.AddQuantity();
                    }
                }


                else
                {
                    FormLogicGUIObsolete.PrintDateMessage();
                }
            }

            else
            {
                FormLogicGUIObsolete.SelectElement("magazzino");
            }
        }


        private void InsertDataIntoDictionary(int stock)
        {
            ItemTag selected = (ItemTag)cbSupplier.SelectedItem;
            int supplierID = (int)selected.Tag;

            selected = (ItemTag)wareHouseCB.SelectedItem;
            int wareHouseID = (int)selected.Tag;    

            prodInf = new Dictionary<string, object>();
            prodInf.Add("product_id", product_id);  //id del prodotto
            prodInf.Add("product_name", codArticleTB);  //nome prodotto              
            prodInf.Add("company_name", Supplier.SupplierMGM.ObtainCompanyName(supplierID));
            prodInf.Add("supplier_id", supplierID);
            prodInf.Add("quantity", stock);
            prodInf.Add("um", umCB.SelectedItem);
            prodInf.Add("wareHouse", wareHouseCB.SelectedItem);
            prodInf.Add("wareHouse_id", wareHouseID);


            isOK = true;
            this.Close();
        }


        private void stockTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void underStockTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void Expiration_dateTB_TextChanged(object sender, EventArgs e)
        {
            DateManipulate.IsValiDate(sender, Expiration_dateTB);
        }

        private void Expiration_dateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateManipulate.manfDateTB_KeyPress(sender, e, Expiration_dateTB);
        }

        private void Expiration_dateTB_KeyDown(object sender, KeyEventArgs e)
        {
            DateManipulate.manfDateTB_KeyDown(sender, e, Expiration_dateTB);
        }
    }
}
