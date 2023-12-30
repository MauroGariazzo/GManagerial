using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using GManagerial.Products.ChildForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Eventing.Reader;
using GManagerial.CustomerForm.ChildForms;
using System.Drawing.Imaging;
using GManagerial.AttachmentsForm;
using GManagerial.Supplier;
using GManagerial.WareHouse.ChildForms;
using GManagerial.WareHouse;

namespace GManagerial.Products
{
    public partial class ProductsForm : Form
    {
        private char nec;
        private Boolean powerCBLoad;

        private int categoryID;
        private int subCategoryID;
        private int brandID;
        private int selectedRow;
        private int countFormPricesAccess;

        private AttachmentForm attachmentForm;
        private bool AttachmentFormExist;
        private int countAttachmentsAccess;
        private int countIconForm;
        private List<int> attachmentsToDeleteIndex;

        private List<int> idDBRows;  //id del DB
        private List<int> idDGVRows;  //id del datagridview
        private List<object> attachmentRow;  //per copiare gli allegati quando si duplica un prodotto

        private bool PriceFormExist;
        public ProductsForm()
        {
            InitializeComponent();
  
            this.powerCBLoad = false;
            this.AttachmentFormExist = false;
            this.attachmentsToDeleteIndex = new List<int>();
            this.idDBRows = new List<int>();
            this.idDGVRows = new List<int>();
            this.attachmentRow = new List<object>();
            this.PriceFormExist = false;
            this.countFormPricesAccess = 0;
            this.countIconForm = 0;
        }


        private void ProductsForm_Load(object sender, EventArgs e)
        {
            ProductsMGM.ProductsForm_Load(productsDGV);
            ProductsMGM.LoadCategories(categoryCB);

            FormLogicGUI.LoadDGV(productsDGV);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            this.nec = 'n';

            ProductsMGM.LoadPowUnityMeasure(powerCB, energy_consCB);
            ProductsMGM.LoadLenUnityMeasure(depthCB, widthCB, heightCB);
            ProductsMGM.LoadWeiUnityMeasure(weightCB);

            FormLogicGUI.NECCC(null, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn, ImageBtn },
                ProductTab);

            searchBtn.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI
            searchBox.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI
        }


        private void editBtn_Click(object sender, EventArgs e)
        {
            if (idDGVRows.Count == 1 || productsDGV.SelectedRows.Count == 1)
            {
                RowLogic.DisableAllCheckBoxes(productsDGV);

                selectedRow = productsDGV.SelectedRows[0].Index;

                this.nec = 'e';
                FormLogicGUI.NECCC(null, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn },
                    ProductTab);

                searchBtn.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI
                searchBox.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI

                BrandCB.Items.Clear();

                ProductsMGM.AllBrands(BrandCB);
                
                ProductsMGM.LoadPowUnityMeasure(powerCB, energy_consCB);
                ProductsMGM.LoadLenUnityMeasure(depthCB, widthCB, heightCB);
                ProductsMGM.LoadWeiUnityMeasure(weightCB);
     

                ProductsMGM.EditProduct(codArticleTB, snTB, manfDateTB, descriptionTB, energyTB, powerTB, energyConsTB,
             heightTB, widthTB, weightTB, depthTB, notesTB, heightCB, widthCB, weightCB, depthCB, powerCB, energy_consCB,
             productsDGV, ObtainID.ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV, 
             "Product_ID"), BrandCB, categoryCB, subCategoryCB);

                stockLblValue.Text = WareHouseProductMGM.ShowStock(ObtainID.ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV,
             "Product_ID")).ToString();
                
            }


            else if (idDGVRows.Count > 1 || productsDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUI.SelectElement("prodotto");
            }
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (idDGVRows.Count == 1 || productsDGV.SelectedRows.Count == 1)
            {
                this.nec = 'c';

                FormLogicGUI.NECCC(null, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn },
                    ProductTab);

                searchBtn.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI
                searchBox.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI

                selectedRow = productsDGV.SelectedRows[0].Index;

                BrandCB.Items.Clear();

                ProductsMGM.AllBrands(BrandCB);
                ProductsMGM.EditProduct(codArticleTB, snTB, manfDateTB, descriptionTB, energyTB, powerTB, energyConsTB,
             heightTB, widthTB, weightTB, depthTB, notesTB, heightCB, widthCB, weightCB, depthCB, powerCB, energy_consCB, productsDGV, ObtainIdProduct(selectedRow), BrandCB,
            categoryCB, subCategoryCB);

                attachmentRow = AttachmentClass.LoadProdAttFromDB(ObtainIdProduct(selectedRow));
            }

            else if (idDGVRows.Count > 1 || productsDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso copiare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUI.SelectElement("prodotto");
            }
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (productsDGV.RowCount > 0)
            {
                if (idDGVRows.Count == 0) { RowLogic.HowManyRows(productsDGV, idDGVRows, ref selectedRow, idDBRows); }
                //quante righe sono state selezionate NON SFRUTTANDO LE CHECKBOX?
                //RowLogic.moveIDfromDGVToDBList(idDBRows, idDGVRows, productsDGV, "Product_ID");
                

                try
                {

                    if (productsDGV.CurrentCell.RowIndex != -1 && ObtainIdProduct(productsDGV.SelectedRows[0].Index) != -1)
                    {

                        DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare la riga selezionata?", "Conferma cancellazione",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            if (idDBRows.Count > 0)
                            {
                                idDBRows.ForEach(productID => ProductPricesMGM.DeletePrices(productID));
                                idDBRows.ForEach(productID => ProductsMGM.deleteProduct(productID));
                            }

                            else
                            {
                                ProductPricesMGM.DeletePrices(ObtainID.ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV, "Product_ID"));
                                ProductsMGM.deleteProduct(ObtainIdProduct(productsDGV.SelectedRows[0].Index));
                            }
                            ProductsForm_Load(sender, e);
                            RowLogic.DeselectAllCheckBox(idDGVRows, productsDGV, true, selectedRow);

                        }
                    }

                    idDBRows.Clear();
                    selectAllRows.Checked = false;
                    RowLogic.DisableAllCheckBoxes(productsDGV);
                }

                catch(System.ArgumentOutOfRangeException)
                {
                    FormLogicGUI.SelectElement("prodotto");
                }
            }

            else
            {
                FormLogicGUI.SelectElement("prodotto");
            }
        }

        
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product();

            try
            {
                newProduct.ProductName = codArticleTB.Text;
            }

            catch(ArgumentException ex) 
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (FormLogicGUI.PrintCancelEdit())
            {
                FormLogicGUI.NECCC(null, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn }, ProductTab
                    );

                FormLogicGUI.DisableAndCleanTextBox(AnagrPanelTP);

                AFCommonLogic.resetAndCleanVars(ref AttachmentFormExist, ref countAttachmentsAccess, attachmentsToDeleteIndex);
                PPLogic.resetAndCleanVars(ref countFormPricesAccess, ref PriceFormExist);

                IFCommonLogic.resetAndClean(ref countIconForm);

                RowLogic.RowSelected(selectedRow, productsDGV);
                RowLogic.DeselectAllCheckBox(idDGVRows, productsDGV);

                searchBtn.Enabled = true;   //---> DA SPOSTARE SU FORMLOGICGUI
                searchBox.Enabled = true;   //---> DA SPOSTARE SU FORMLOGICGUI
            }

            idDBRows.Clear();   // --> ?????????
            selectAllRows.Checked = false;
        }

        private void attachmentsBtn_Click(object sender, EventArgs e)
        {
            this.countAttachmentsAccess += 1;

            if (this.nec == 'n')
            {
                attachmentForm = new AttachmentForm(-1, countAttachmentsAccess, 'p');
            }

            else
            {
                attachmentForm = new AttachmentForm(ObtainIdProduct(selectedRow), countAttachmentsAccess, 'p');
            }

            AttachmentFormExist = true;
            attachmentForm.ShowDialog();
        }


        private void priceBtn_Click(object sender, EventArgs e)
        {
            PriceFormExist = true;
            ProductPrices pp;
            countFormPricesAccess += 1;

            if (this.nec == 'n')
            {
                pp = new ProductPrices(nec, 0, countFormPricesAccess);
            }

            else
            {
                pp = new ProductPrices(nec, ObtainIdProduct(selectedRow), countFormPricesAccess);
            }

            pp.ShowDialog();
        }


        private void ImageBtn_Click(object sender, EventArgs e)
        {
            countIconForm += 1;
            ImageForm imageForm;

            if (this.nec == 'n' || this.nec == 'c')
            {
                imageForm = new ImageForm(countIconForm, -1);
            }

            else
            {
                imageForm = new ImageForm(countIconForm, ObtainIdProduct(selectedRow));
            }

            imageForm.ShowDialog();
        }


        private void categoryBtn_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.ShowDialog();
        }


        private void subCategoryBtn_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.ShowDialog();
        }


        private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryCB.SelectedItem != null)
            {
                subCategoryCB.Enabled = true;
                subCategoryBtn.Enabled = true;
                subCategoryLbl.ForeColor = Color.Black;
            }

            ProductsMGM.LoadSubCategories(categoryID, subCategoryCB);
            ItemTag selectedCategory = (ItemTag)categoryCB.SelectedItem;

            if (selectedCategory != null)
            {
                categoryID = (int)selectedCategory.Tag;
            }
        }


        private void categoryCB_Click(object sender, EventArgs e)
        {
            categoryCB.Items.Clear();
            ProductsMGM.LoadCategories(categoryCB);
        }

        private void categoryCB_DropDownClosed(object sender, EventArgs e)
        {
            if (categoryCB.SelectedItem == null)
            {
                subCategoryCB.Enabled = false;
                subCategoryBtn.Enabled = false;
                subCategoryLbl.ForeColor = Color.Gray;
                subCategoryCB.Text = null;
            }
        }

        private void subCategoryCB_Click(object sender, EventArgs e)
        {
            subCategoryCB.Items.Clear();
            ProductsMGM.LoadSubCategories(categoryID, subCategoryCB);
        }

        private void BrandBtn_Click(object sender, EventArgs e)
        {
            Brands brands = new Brands();
            brands.ShowDialog();
        }

        private void BrandTB_Click(object sender, EventArgs e)
        {
            BrandCB.Items.Clear();
            ProductsMGM.AllBrands(BrandCB);

            if (BrandCB.SelectedItem == null)
            {
                brandID = 1;
            }
        }

        private void subCategoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemTag ScatSelectedItem = (ItemTag)subCategoryCB.SelectedItem;

            if (ScatSelectedItem != null) { subCategoryID = (int)ScatSelectedItem.Tag; }

        }

        private void BrandTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemTag BrandSelectedItem = (ItemTag)BrandCB.SelectedItem;
            if (BrandSelectedItem != null) { brandID = (int)BrandSelectedItem.Tag; }
        }


        private int ObtainIdProduct(int selectedRowIndex)
        {
            return ObtainID.ObtainIDelements.ObtainIdElement(selectedRowIndex, productsDGV, "Product_ID");
        }

        
        //-------------------------------------------------------------------------------------------------------------------------------------------//

        private void energyConsTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e,'.');

            if (e.KeyChar == '.' && energyConsTB.Text.Contains("."))  //controllo per impedire all'utente di inserire più di un punto
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }

        private void checkNumPress(KeyPressEventArgs e, char character)  //isdigit
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != character && e.KeyChar != (char)Keys.Back) //se non è un numero, un punto o il backspace
            {
                e.Handled = true;  //  controllo per impedire all'utente di inserire caratteri diversi dai numeri
            }
        }

        private void powerTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            checkDotsInput(sender, e);
        }

        private void heightTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e, '.');

            if (e.KeyChar == '.' && heightTB.Text.Contains("."))
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }

        private void checkDotsInput(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (textBox.Text.Length == 4 && !textBox.Text.Contains('.') && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                textBox.Text += '.';
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void widthTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e, '.');

            if (e.KeyChar == '.' && widthTB.Text.Contains("."))
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }


        private void depthTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e, '.');

            if (e.KeyChar == '.' && depthTB.Text.Contains("."))
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }

        private void weightTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e,'.');

            if (e.KeyChar == '.' && weightTB.Text.Contains("."))
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }

        private void unityMisureReset(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;

            if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == "-")
            {
                comboBox.SelectedItem = null;
            }
        }

        private void heightCB_SelectedValueChanged(object sender, EventArgs e)
        {
            unityMisureReset(sender, e);
        }
        private void widthCB_SelectedValueChanged(object sender, EventArgs e)
        {
            unityMisureReset(sender, e);
        }

        private void depthCB_SelectedValueChanged(object sender, EventArgs e)
        {
            unityMisureReset(sender, e);
        }

        private void weightCB_SelectedValueChanged(object sender, EventArgs e)
        {
            unityMisureReset(sender, e);
        }

        private void powerCB_SelectedValueChanged(object sender, EventArgs e)
        {
            unityMisureReset(sender, e);
        }

        private void energy_consCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            unityMisureReset(sender, e);
        }
/*-------------------------------------------------------------------------------------------------------------------------*/
        private void manfDateTB_TextChanged(object sender, EventArgs e)
        {
            DateManipulate.IsValiDate(sender, manfDateTB);
        }


        private void manfDateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateManipulate.manfDateTB_KeyPress(sender, e, manfDateTB);
        }

        
        private void manfDateTB_KeyDown(object sender, KeyEventArgs e)
        {
            DateManipulate.manfDateTB_KeyDown(sender, e, manfDateTB);
        }

        //-----------------------------------------------------------------------------------------------------------//
        private void searchBox_Enter(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Enter(searchBox);
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Leave(searchBox);
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchLogic.searchBox_KeyDown(e, searchBox);
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchLogic.searchBox_KeyPress(sender, e);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "catCB", catCB },
            { "subCatCB", subCatCB }, { "brandCBsearch", brandCBsearch }};
            SearchLogic.FormSorting(searchBox, 'p', productsDGV, comboBoxDictionary);
        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "catCB", catCB },
            { "subCatCB", subCatCB }, { "brandCBsearch", brandCBsearch }};

            SearchLogic.searchBtn_Click(searchPanel, searchBox, 'p', productsDGV, comboBoxDictionary, searchBtn);
        }

        private void searchbtn2_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "catCB", catCB },
            { "subCatCB", subCatCB }, { "brandCBsearch", brandCBsearch }};
            SearchLogic.FormSorting(searchBox, 'p', productsDGV, comboBoxDictionary);
        }

        private void resetCB_Click(object sender, EventArgs e)
        {
            SearchLogic.resetCB_Click(searchPanel);
        }

        //--------------------------------------------------------PANELSEARCH----------------------------------------------------------------------------//
        private void catCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (catCB.SelectedItem != null && catCB.SelectedItem.ToString() != "")
            {
                subCatCB.SelectedItem = null;
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
            ItemTag ScatSelectedItem = (ItemTag)subCatCB.SelectedItem;
            if (ScatSelectedItem != null) { subCategoryID = (int)ScatSelectedItem.Tag; }
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

            if (brandCBsearch.SelectedItem == null)
            {
                brandID = 1;
            }
        }

        private void brandCBsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemTag BrandSelectedItem = (ItemTag)brandCBsearch.SelectedItem;
            if (BrandSelectedItem != null) { brandID = (int)BrandSelectedItem.Tag; }
        }

        //-------------------------------------------------ENDPANELSEARCH---------------------------------------------------------------------------//

        private void productsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e) //onclick di una cella che è una checkbox -> //rowlogic
        {
            RowLogic.CellContentClick(idDBRows, idDGVRows, productsDGV, sender, e, "Product_ID");
        }

        private void productsDGV_CellClick(object sender, DataGridViewCellEventArgs e)  //onclick di una cella che NON sia una checkbox
        {
            RowLogic.DGV_CellClick(sender, e);
        }

        private void selectAllRows_CheckedChanged(object sender, EventArgs e) //ROWLOGIC
        { 
            RowLogic.selectAllRows_CheckedChanged(selectAllRows, productsDGV, idDGVRows, idDBRows, "Product_ID");
        }

        private void productsDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            selectAllRows.Location = new Point(productsDGV.Columns[0].Width / 2 - 5, selectAllRows.Location.Y);
        }

        private void productsDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (productsDGV.Columns[e.ColumnIndex].Name == "image")
                {  
                    System.Drawing.Image image = e.Value as System.Drawing.Image;

                    if (image != null)
                    {
                        productsDGV.Rows[e.RowIndex].Height = image.Height;
                        productsDGV.Columns[e.ColumnIndex].Width = image.Width;
                    }
                }
            }  
        }

        private void lMerchBtn_Click(object sender, EventArgs e)
        {
            if (this.nec == 'n' || this.nec == 'c')
            {
                MessageBox.Show("Registra il prodotto prima di effettuare dei movimenti");
                return;
            }


            else
            {
                selectedRow = productsDGV.SelectedRows[0].Index;
                WareHouse.ChildForms.InsertProdInf insertProdInf = new WareHouse.ChildForms.InsertProdInf(ObtainIdProduct(selectedRow), codArticleTB.Text);
                insertProdInf.ShowDialog(); 
            }

            if (InsertProdInf.isOK)
            {
                InsertDataToDB();
                stockLblValue.Text = WareHouseProductMGM.ShowStock(ObtainID.ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV,
             "Product_ID")).ToString();
            }
        }

        private void InsertDataToDB()
        {
            int idProduct = (int)InsertProdInf.prodInf["product_id"];
            int idSupplier = (int)InsertProdInf.prodInf["supplier_id"];
            int quantity = (int)InsertProdInf.prodInf["quantity"];
            string productName = InsertProdInf.prodInf["product_name"].ToString();
            string supplierName = InsertProdInf.prodInf["company_name"].ToString();
            string um = InsertProdInf.prodInf["um"].ToString();
            int selectedWareHouseID = (int)InsertProdInf.prodInf["wareHouse_id"];

            int uStock;
            if (WareHouseProductMGM.checkIfProductExist(idProduct, idSupplier, selectedWareHouseID))
            {
                WareHouseProductMGM.LoadMerchInWareHouseDB(idProduct, idSupplier, quantity, selectedWareHouseID, um,
                'e');
            }

            else
            {
                WareHouseProductMGM.LoadMerchInWareHouseDB(idProduct, idSupplier, quantity, selectedWareHouseID, um,
                'n');
            }           

        }

        private void WHprodMovements_Click(object sender, EventArgs e)
        {

        }

        private void ProductTab_MouseClick(object sender, MouseEventArgs e)
        {
            this.confirmBtn2.Visible = true;
            this.cancelBtn2.Visible = true;
        }

        private void confirmBtn2_Click(object sender, EventArgs e)
        {
            ProductTab.SelectedIndex = 0;   
            confirmBtn_Click(sender, e);
        }

        private void cancelBtn2_Click(object sender, EventArgs e)
        {
            ProductTab.SelectedIndex = 0;
            cancelBtn_Click(sender ,e);
        }

        private void uStockTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void undStockBtn_Click(object sender, EventArgs e)
        {

        }
    }
    
}




