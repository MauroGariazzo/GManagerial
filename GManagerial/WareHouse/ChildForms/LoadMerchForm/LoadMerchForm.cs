using GManagerial.WareHouse.ChildForms;
using GManagerial.WareHouse.ChildForms.LoadMerchForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.WareHouse.LoadMerchForm
{
    public partial class LoadMerchForm : Form
    {
        List<Dictionary<string,object>> products;  
        int selectedWareHouseID;
        public LoadMerchForm(string form, int selectedWareHouseID)
        {
            InitializeComponent();
            this.selectedWareHouseID = selectedWareHouseID;
            this.products = new List<Dictionary<string, object>>();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            ChildForms.AddProduct addProduct = new ChildForms.AddProduct(this.selectedWareHouseID);
            addProduct.ShowDialog();
            CheckIfFormIsClosed('a');
        }

        private void AddInfoProductInDGV()
        {
            int rowIndex = LoadMerchDGV.Rows.Add();

            LoadMerchDGV.Rows[rowIndex].Cells["product_id"].Value = ChildForms.InsertProdInf.prodInf["product_id"];
            LoadMerchDGV.Rows[rowIndex].Cells["product_name"].Value = ChildForms.InsertProdInf.prodInf["product_name"];
            LoadMerchDGV.Rows[rowIndex].Cells["company_name"].Value = ChildForms.InsertProdInf.prodInf["company_name"];
            LoadMerchDGV.Rows[rowIndex].Cells["wareHouse"].Value = ChildForms.InsertProdInf.prodInf["wareHouse"];
            LoadMerchDGV.Rows[rowIndex].Cells["quantity"].Value = ChildForms.InsertProdInf.prodInf["quantity"];

        }

        private bool checkIfProductIsAlreadyInserted(char addOrEdit) //controllare se il prodotto è gia stato inserito e già presente nel datagridview
        {
            int i = 0;
            foreach (var pairs in products)
            {
                //try
                i++;
                if ((int)pairs["product_id"] == (int)ChildForms.InsertProdInf.prodInf["product_id"])
                {
                    if (pairs["company_name"].ToString() == ChildForms.InsertProdInf.prodInf["company_name"].ToString())
                    {
                        if (pairs["wareHouse"].ToString() == ChildForms.InsertProdInf.prodInf["wareHouse"].ToString())
                        {
                            int quantityExisting = (int)pairs["quantity"];
                            int quantityToAdd = (int)ChildForms.InsertProdInf.prodInf["quantity"];
                            if (addOrEdit == 'a')
                            {
                                pairs["quantity"] = quantityExisting + quantityToAdd;
                                UpdateRow(i - 1, quantityExisting + quantityToAdd);
                            }

                            else
                            {
                                pairs["quantity"] = quantityToAdd;
                                UpdateRow(i - 1, quantityToAdd);
                            }

                            return true;
                        }
                    }
                }
            }
            return false;   
        }            


        private void UpdateRow(int i, int newQuantity)
        {
            LoadMerchDGV.Rows[i].Cells["quantity"].Value = newQuantity;
        }

        private void LoadMerchForm_Load(object sender, EventArgs e)
        {
            FormLogicGUIObsolete.LoadDGV(LoadMerchDGV);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            InsertProductsInWareHouseDB();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int row = LoadMerchDGV.SelectedRows[0].Index;

                if (row != -1)
                {
                    TakeProdInfoFromDGVandSentToForm(row);
                    CheckIfFormIsClosed('e');
                }

                else
                {
                    FormLogicGUIObsolete.SelectElement("prodotto");
                }
            }

            catch(System.ArgumentOutOfRangeException)
            {
                FormLogicGUIObsolete.SelectElement("prodotto");
            }
        }


        private void TakeProdInfoFromDGVandSentToForm(int row)
        {
            DataGridViewCell productCell = LoadMerchDGV.Rows[row].Cells[1];
            DataGridViewCell supplierName = LoadMerchDGV.Rows[row].Cells[2];
            DataGridViewCell wareHouseName = LoadMerchDGV.Rows[row].Cells[3];
            DataGridViewCell loadMerchCell = LoadMerchDGV.Rows[row].Cells[4];

            InsertProdInf ProdInf = new InsertProdInf(ObtainID.ObtainIDelements.ObtainIdElement
                        (LoadMerchDGV.SelectedRows[0].Index, LoadMerchDGV, "Product_ID"),
                       'e', supplierName.Value.ToString(), wareHouseName.Value.ToString(), (int)loadMerchCell.Value);

            ProdInf.ShowDialog();
        }

        private void CheckIfFormIsClosed(char isAddOrEdit)
        {
            if (ChildForms.InsertProdInf.prodInf != null && InsertProdInf.isOK)
            {
                if (!checkIfProductIsAlreadyInserted(isAddOrEdit))
                {
                    AddInfoProductInDGV();
                    products.Add(ChildForms.InsertProdInf.prodInf);
                }

            }

            ChildForms.InsertProdInf.prodInf = new Dictionary<string, object> { };
        }


        private void InsertProductsInWareHouseDB()
        {
            foreach(var pairs in products)
            {
                try
                {
                    int idProduct = (int)pairs["product_id"];
                    int idSupplier = (int)pairs["supplier_id"];
                    int quantity = (int)pairs["quantity"];
                    string productName = pairs["product_name"].ToString();
                    string supplierName = pairs["company_name"].ToString();
                    string um = pairs["um"].ToString();
                    int idWareHouse = (int)pairs["wareHouse_id"];

                    //se il prodotto è già presente in magazzino
                    if (WareHouseProductMGM.checkIfProductExist(idProduct, idSupplier, idWareHouse)) 
                    {
                        
                        WareHouseProductMGM.LoadMerchInWareHouseDB(idProduct, idSupplier, quantity, idWareHouse, um, 'e');
                    }

                    else
                    {
                        //deve eseguire la query per un nuovo inserimento 
                        WareHouseProductMGM.LoadMerchInWareHouseDB(idProduct, idSupplier, quantity, idWareHouse, um, 'n');
                    }

                }

                catch (Exception)
                {
                    return;
                }

            }

            this.products = new List<Dictionary<string,object>>();    
        }
    }
}
