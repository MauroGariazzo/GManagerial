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
using System.Drawing.Imaging;
using GManagerial.AttachmentsForm;
using GManagerial.Supplier;
using GManagerial.WareHouse.ChildForms;
using GManagerial.WareHouse;

using GManagerial.IDBConnector;
using GManagerial.Products.ChildForms.CategorySubForm.Models;
using GManagerial.Attachments;
using GManagerial.ObtainID;
using System.Data.SqlTypes;

namespace GManagerial.Products
{
    public delegate void BrandUpdate(); //DICHIARAZIONE DELEGATE
    public delegate void CategoryUpdate();
    internal delegate void SubCategoryUpdate(ICategory category);

    public partial class ProductsForm : Form
    {
        private char _newEditCopy;

        private int categoryID;
        private int subCategoryID;
        private int brandID;
        private int selectedRow;
        private int countFormPricesAccess;

        /////////////////////////////////////////

        private List<System.Windows.Forms.Button> _buttonList;
        private List<System.Windows.Forms.TextBox> _textboxes;
        private List<System.Windows.Forms.ComboBox> _comboboxes;


        private AttachmentForm attachmentForm;
        private bool AttachmentFormExist; //
        private int countAttachmentsAccess; //
        private int countIconForm; //
        private List<int> attachmentsToDeleteIndex;//

        private List<int> idDBRows;  //id del DB
        private List<int> idDGVRows;  //id del datagridview
        private List<object> attachmentRow;  //per copiare gli allegati quando si duplica un prodotto

        private bool PriceFormExist;

        private Product _product;

        private IDBConnector.IDBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");

        private Dictionary<string, IBrand> _brands;
        private Dictionary<string, ICategory> _categories;
        private Dictionary<string, ISubCategory> _subCategories;

        private DAOProduct _daoProduct;
        private DAOBrand _daoBrand;
        private DAOCategory _daoCategory;
        private DAOSubCategory _daoSubCategory;
        private DAOAttachments _daoAttachment;
        private DAOObjectAttachments _daoObjectAttachments;

        private AttachmentForm _attachmentForm;
        private Dictionary<int, Product> _productsDictionary; //dizionario dove ho tutti i prodotti
        private FormLogicGUI _formLogicGUI;
        public ProductsForm()
        {
            InitializeComponent();
  
            this.AttachmentFormExist = false;
            this.attachmentsToDeleteIndex = new List<int>();
            this.idDBRows = new List<int>();
            this.idDGVRows = new List<int>();
            this.attachmentRow = new List<object>();
            this.PriceFormExist = false;
            this.countFormPricesAccess = 0;
            this.countIconForm = 0;

            this._daoProduct = new DAOProduct(this._dbConnector);
            this._daoBrand = new DAOBrand(this._dbConnector); //-> da cancellare
            this._daoCategory = new DAOCategory(this._dbConnector);
            this._daoSubCategory = new DAOSubCategory(this._dbConnector);
            this._daoAttachment = new DAOAttachments(_dbConnector, AttachmentQuery.INSERT_ATTACHMENT, AttachmentQuery.DELETE_ATTACHMENT);

            this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector, AttachmentQuery.SELECT_PRODUCT, AttachmentQuery.INSERT_PRODUCT, AttachmentQuery.DELETE_PRODUCT);

            this._brands = this._daoBrand.GetAllDictionaries();    //-> da cancellare
            this._categories = this._daoCategory.GetAllDictionaries();
            this._subCategories = this._daoSubCategory.GetAllDictionaries();    

            this._formLogicGUI = new FormLogicGUI();
            this._buttonList = new List<System.Windows.Forms.Button>() { confirmBtn, cancelBtn, confirmBtn2, cancelBtn2, barcBtn, priceBtn, AttachmentsBtn, ImageBtn};
            this._textboxes = new List<System.Windows.Forms.TextBox>() {ProductNameTB, serialNumberTB, manfDateTB, descriptionTB, heightTB, widthTB, depthTB, weightTB, energyTB, powerTB, 
                energyConsTB, notesTB};
            this._comboboxes = new List<System.Windows.Forms.ComboBox>() { BrandCB, categoryCB, subCategoryCB};
        }


        private void OnUpdateBrand()
        {
            this._brands = this._daoBrand.GetAllDictionaries();
            BrandCB.Items.Clear();  
            foreach (IBrand brand in _brands.Values)
            {
                BrandCB.Items.Add(brand);
            }

            BrandCB.DisplayMember = "Name";
        }

        private void OnUpdateCategory()
        {
            this._categories = this._daoCategory.GetAllDictionaries();
            categoryCB.Items.Clear();
            foreach (ICategory category in _categories.Values)
            {
                categoryCB.Items.Add(category);
            }

            categoryCB.DisplayMember = "CategoryName"; // Imposta il membro da visualizzare
            
        }

        private void OnUpdateSubCategory(ICategory category)
        {
            this._subCategories = this._daoSubCategory.GetAllSubCategoriesFromACategoryDictionaries(category);
            subCategoryCB.Items.Clear(); 
            foreach (ISubCategory subCategory in _subCategories.Values)
            {
                subCategoryCB.Items.Add(subCategory);
            }

            subCategoryCB.DisplayMember = "SubCategoryName";

        }
        private void ProductsForm_Load(object sender, EventArgs e)
        {
            //ProductsMGM.ProductsForm_Load(productsDGV);
            //ProductsMGM.LoadCategories(categoryCB);


            //ProductsMGM.AllBrands(BrandCB);

            /*if (reader["Brand_Name"].ToString() != "" && reader["Brand_Name"].ToString() != null)
            {
                BrandCB.Items.Add(item);
            }*/

            UpdateDataGridView();
            OnUpdateBrand();
            OnUpdateCategory();


            /*if (BrandCB.SelectedItem == null)
            {
                brandID = 1;
            }*/

            //FormLogicGUI.LoadDGV(productsDGV);
        }

        private void UpdateDataGridView()
        {
            productsDGV.Rows.Clear();
            _productsDictionary = _daoProduct.GetAll();
            DataGridViewPopulateFromDictionary(_productsDictionary);
        }


        private void DataGridViewPopulateFromDictionary(Dictionary<int, Product> productsDictionary)
        {
            foreach(var couple in productsDictionary)
            {
                int rowIndex = productsDGV.Rows.Add();
                productsDGV.Rows[rowIndex].Cells[0].Value = couple.Key;
                productsDGV.Rows[rowIndex].Cells[1].Value = couple.Value.ProductName;
                productsDGV.Rows[rowIndex].Cells[2].Value = couple.Value.ResizedImage;

            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            _formLogicGUI.NewEditCopyButton(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList);

            /*this._newEditCopy = 'n';

            ProductsMGM.LoadPowUnityMeasure(powerCB, energy_consCB);
            ProductsMGM.LoadLenUnityMeasure(depthCB, widthCB, heightCB);
            ProductsMGM.LoadWeiUnityMeasure(weightCB);

            FormLogicGUI.NECCC(null, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn, ImageBtn },
                ProductTab);

            searchBtn.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI
            searchBox.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI*/
            this._newEditCopy = 'n';

            _product = new Product();

            _product.Attachments = new Dictionary<int, IAttachment>();
            _product.TempAttachments = new Dictionary<int, IAttachment>();
            _product.AttachmentsToDelete = new Dictionary<int, IAttachment>();
        }


        private void editBtn_Click(object sender, EventArgs e)
        {
            if (idDGVRows.Count == 1 || productsDGV.SelectedRows.Count == 1)
            {
                /*RowLogic.DisableAllCheckBoxes(productsDGV);

                selectedRow = productsDGV.SelectedRows[0].Index;

                this._newEditCopy = 'e';
                FormLogicGUI.NECCC(null, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn },
                    ProductTab);

                searchBtn.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI
                searchBox.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI

                /*BrandCB.Items.Clear();

                ProductsMGM.AllBrands(BrandCB);
                
                ProductsMGM.LoadPowUnityMeasure(powerCB, energy_consCB);
                ProductsMGM.LoadLenUnityMeasure(depthCB, widthCB, heightCB);
                ProductsMGM.LoadWeiUnityMeasure(weightCB);
     

                ProductsMGM.EditProduct(codArticleTB, serialNumberTB, manfDateTB, descriptionTB, energyTB, powerTB, energyConsTB,
             heightTB, widthTB, weightTB, depthTB, notesTB, heightCB, widthCB, weightCB, depthCB, powerCB, energy_consCB,
             productsDGV, ObtainID.ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV, 
             "Product_ID"), BrandCB, categoryCB, subCategoryCB);

                stockLblValue.Text = WareHouseProductMGM.ShowStock(ObtainID.ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV,
             "Product_ID")).ToString();*/

                this._newEditCopy = 'e';

                int id = ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV, "Product_ID"); //ottengo l'id che voglio modificare dal datagridview.

                _product = new Product();
                _product = _productsDictionary[id];

                TransferDataFromDictionariesToControls();

                _product.TempAttachments = new Dictionary<int, IAttachment>();
                _product.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _product.Attachments = _daoObjectAttachments.GetAll(id);

                _formLogicGUI.NewEditCopyButton(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList);

            }

            else if (idDGVRows.Count > 1 || productsDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUIObsolete.SelectElement("prodotto");
            }
        }

        private void TransferDataFromDictionariesToControls()
        {
            ProductNameTB.Text = _product.ProductName;
            serialNumberTB.Text = _product.SerialNumber;
            BrandCB.Text = _product.BrandP.Name;
            categoryCB.Text = _product.CategoryObj.CategoryName;
            subCategoryCB.Text = _product.SubCategory.SubCategoryName;
            descriptionTB.Text = _product.Description;
            notesTB.Text = _product.Notes;
            heightTB.Text = _product.Height.ToString();
            widthTB.Text = _product.Width.ToString();
            weightTB.Text = _product.Weight.ToString();
            depthTB.Text = _product.Depth.ToString();
            energyTB.Text = _product.EnergyClass;
            energyConsTB.Text = _product.EnergyConsumption.ToString();
            powerTB.Text = _product.Power.ToString();

            if (_product.ManufacturingDate != null)
            {
                manfDateTB.Text = _product.ManufacturingDate.ToString().Substring(0, 10);
            }
        }
        private void CopyBtn_Click(object sender, EventArgs e)
        {
            /*if (idDGVRows.Count == 1 || productsDGV.SelectedRows.Count == 1)
            {
                this._newEditCopy = 'c';

                FormLogicGUI.NECCC(null, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn },
                    ProductTab);

                searchBtn.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI
                searchBox.Enabled = false;   //---> DA SPOSTARE SU FORMLOGICGUI

                selectedRow = productsDGV.SelectedRows[0].Index;

                BrandCB.Items.Clear();

                ProductsMGM.AllBrands(BrandCB);
               /* ProductsMGM.EditProduct(ProductNameTB, serialNumberTB, manfDateTB, descriptionTB, energyTB, powerTB, energyConsTB,
             heightTB, widthTB, weightTB, depthTB, notesTB, heightCB, widthCB, weightCB, depthCB, powerCB, energy_consCB, productsDGV, ObtainIdProduct(selectedRow), BrandCB,
            categoryCB, subCategoryCB);

                //attachmentRow = AttachmentClass.LoadProdAttFromDB(ObtainIdProduct(selectedRow));
            }

            else if (idDGVRows.Count > 1 || productsDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso copiare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUI.SelectElement("prodotto");
            }*/

            if (idDGVRows.Count == 1 || productsDGV.SelectedRows.Count == 1)
            {
                _newEditCopy = 'c';

                _product = new Product();

                int id = ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV, "Product_ID"); //ottengo l'id che voglio modificare dal datagridview.
                
                _product = _productsDictionary[id];

                _formLogicGUI = new FormLogicGUI();

                _product.TempAttachments = new Dictionary<int, IAttachment>();
                _product.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _product.Attachments = _daoObjectAttachments.GetAll(id);

                TransferDataFromDictionariesToControls();
                _formLogicGUI.NewEditCopyButton(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList);

            }
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            /*if (productsDGV.RowCount > 0)
            {
                if (idDGVRows.Count == 0) { RowLogic.HowManyRows(productsDGV, idDGVRows, ref selectedRow, idDBRows); }
                //quante righe sono state selezionate NON SFRUTTANDO LE CHECKBOX?
                //RowLogic.moveIDfromDGVToDBList(idDBRows, idDGVRows, productsDGV, "Product_ID");
                

                try
                {

                    if (productsDGV.CurrentCell.RowIndex != -1 && ObtainIdProduct(productsDGV.SelectedRows[0].Index) != -1)
                    {

                        DialogResult decimalResult = MessageBox.Show("Sei sicuro di voler cancellare la riga selezionata?", "Conferma cancellazione",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (decimalResult == DialogResult.Yes)
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
            }*/

            if (productsDGV.RowCount > 0)
            {
                CheckUserChoice();
            }
        }

        private void CheckUserChoice() //controllare se l'utente è sicuro di voler cancellare la riga o le righe selezionate
        {
            if (productsDGV.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Sei sicuro di voler cancellare l'elemento selezionato?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in productsDGV.SelectedRows)
                    {
                        _product = new Product();
                        int id_product = ObtainIDelements.ObtainIdElement(productsDGV.SelectedRows[0].Index, productsDGV, "Product_ID"); //ottengo l'id che voglio modificare dal datagridview.
                        _product = _productsDictionary[id_product];

                        _product.AttachmentsToDelete = _daoObjectAttachments.GetAll(id_product); //tutti gli allegati
                        DeleteAttachments();
                        DeleteProduct(id_product);
                    }
                }
            }


            else
            {
                MessageBox.Show("Seleziona prima una riga da cancellare", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void DeleteAttachments()
        {
            foreach (Attachment attachment in _product.AttachmentsToDelete.Values)
            {
                _daoObjectAttachments.Delete(attachment, attachment.ObjectID); //cancella gli allegati dalla tabella product_attachment
                _daoAttachment.Delete(attachment); //cancella gli allegati dalla tabella attachments
            }
        }

        private void DeleteProduct(int id_product)
        {
            _product = _productsDictionary[id_product];
            _daoProduct.Delete(_product);
            _productsDictionary.Remove(id_product);
            UpdateDataGridView();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (ProductNameTB.Text != "")
            {
                int id_product; //id per recuperare l'ultima riga inserita

                if (SetProductFields())
                { //settare tutti i fields di prodotto prima di registrarlo nel db

                    if (_newEditCopy == 'n' || _newEditCopy == 'c')
                    {
                        id_product = _daoProduct.Insert(_product);
                    }

                    else
                    {
                        _daoProduct.Update(_product);
                        id_product = _product.ID;
                    }


                    foreach (Attachment attachment in _product.TempAttachments.Values)
                    {
                        int id_attachment = _daoAttachment.Insert(attachment);
                        _daoObjectAttachments.Insert(id_product, id_attachment);
                    }


                    AttachmentForm.TempID = -1; //risetto la variabile TempID che mi serviva per gli allegati temporanei
                    _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList);

                    UpdateDataGridView();
                }
            }

            else
            {
                MessageBox.Show("Inserisci il nome del prodotto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool SetProductFields() //*
        {
          
                if (BrandCB.SelectedItem == null)
                {
                    _product.BrandP = new Brand(); //->spostarlo nei controlli new, edit e copy
                    _product.BrandP.ID = 1;
                }

                if (categoryCB.SelectedItem == null)
                {
                    _product.CategoryObj = new Category(); //->spostarlo nei controlli new, edit e copy
                    _product.CategoryObj.ID = 1;
                }

                if (subCategoryCB.SelectedItem == null)
                {
                    _product.SubCategory = new SubCategory(); //->spostarlo nei controlli new, edit e copy
                    _product.SubCategory.ID = 1;
                }

                _product.Description = descriptionTB.Text;
                _product.EnergyClass = energyTB.Text;
                _product.SerialNumber = serialNumberTB.Text;
                _product.Notes = notesTB.Text;

                decimal decimalResult;

                if (decimal.TryParse(energyConsTB.Text, out decimalResult))
                {
                    _product.EnergyConsumption = decimalResult;
                }

                if (decimal.TryParse(heightTB.Text, out decimalResult))
                {
                    _product.Height = decimalResult;
                }

                if (decimal.TryParse(widthTB.Text, out decimalResult))
                {
                    _product.Width = decimalResult;
                }

                if (decimal.TryParse(weightTB.Text, out decimalResult))
                {
                    _product.Weight = decimalResult;
                }

                if (decimal.TryParse(depthTB.Text, out decimalResult))
                {
                    _product.Depth = decimalResult;
                }

                int intResult;

                if (int.TryParse(powerTB.Text, out intResult))
                {
                    _product.Power = intResult;
                }

                DateTime dateTime;
                if(DateTime.TryParse(manfDateTB.Text, out dateTime))
                {
                    _product.ManufacturingDate = dateTime;
                }

            return true;

            //per l'immagine non posso mettre valori null
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (FormLogicGUIObsolete.PrintCancelEdit())
            {
                //_product.ResizedImage = null;
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList);
                

                /*AttachmentForm.TempID = -1;

                FormLogicGUI.NECCC(null, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, priceBtn, barcBtn, AttachmentsBtn, ImageBtn }, ProductTab
                    );

                FormLogicGUI.DisableAndCleanTextBox(AnagrPanelTP);

                AFCommonLogic.resetAndCleanVars(ref AttachmentFormExist, ref countAttachmentsAccess, attachmentsToDeleteIndex);
                PPLogic.resetAndCleanVars(ref countFormPricesAccess, ref PriceFormExist);

                IFCommonLogic.resetAndClean(ref countIconForm);

                RowLogic.RowSelected(selectedRow, productsDGV);
                RowLogic.DeselectAllCheckBox(idDGVRows, productsDGV);

                searchBtn.Enabled = true;   //---> DA SPOSTARE SU FORMLOGICGUI
                searchBox.Enabled = true;   //---> DA SPOSTARE SU FORMLOGICGUI*/
            }

            idDBRows.Clear();   // --> ?????????
            selectAllRows.Checked = false;
        }

        private void attachmentsBtn_Click(object sender, EventArgs e)
        {
            _attachmentForm = new AttachmentForm(_product, _product.ID);
            _attachmentForm.ShowDialog();
        }


        private void priceBtn_Click(object sender, EventArgs e)
        {
            PriceFormExist = true;
            ProductPrices pp;
            countFormPricesAccess += 1;

            if (this._newEditCopy == 'n')
            {
                pp = new ProductPrices(_newEditCopy, 0, countFormPricesAccess);
            }

            else
            {
                pp = new ProductPrices(_newEditCopy, ObtainIdProduct(selectedRow), countFormPricesAccess);
            }

            pp.ShowDialog();
        }


        private void ImageBtn_Click(object sender, EventArgs e)
        {
            ImageForm imageForm = new ImageForm(_product);
            imageForm.ShowDialog();
        }


        private void categoryBtn_Click(object sender, EventArgs e) //*
        {        
            Category tempCategoryForStringAttribute = categoryCB.SelectedItem as Category;
            SubCategory tempSubCategoryForStringAttribute = subCategoryCB.SelectedItem as SubCategory;

            CategoriesForm categories = new CategoriesForm();
            categories.SetCategoryCallBack(this.OnUpdateCategory);
            categories.SetSubCategoryCallBack(this.OnUpdateSubCategory);
            categories.ShowDialog();

            categoryCB.Text = tempCategoryForStringAttribute.CategoryName;
            subCategoryCB.Text = tempSubCategoryForStringAttribute.SubCategoryName;
        }


        private void subCategoryBtn_Click(object sender, EventArgs e) //*
        {
            Category tempCategoryForStringAttribute = categoryCB.SelectedItem as Category;
            SubCategory tempSubCategoryForStringAttribute = subCategoryCB.SelectedItem as SubCategory;

            CategoriesForm categories = new CategoriesForm();
            categories.SetCategoryCallBack(this.OnUpdateCategory);
            categories.SetSubCategoryCallBack(this.OnUpdateSubCategory);
            categories.ShowDialog();

            categoryCB.Text = tempCategoryForStringAttribute.CategoryName;
            subCategoryCB.Text = tempSubCategoryForStringAttribute.SubCategoryName;
        }


        private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryCB.SelectedItem != null && categoryCB.Text != "-")
            {
                _product.CategoryObj = categoryCB.SelectedItem as Category;
                subCategoryCB.Enabled = true;
                subCategoryBtn.Enabled = true;
                subCategoryLbl.ForeColor = Color.Black;

                if (_product.CategoryObj != null)
                {
                    OnUpdateSubCategory(_product.CategoryObj);
                }
            }

            else
            {
                categoryCB.SelectedItem = null; 
                subCategoryCB.Enabled = false;
                subCategoryBtn.Enabled = false;
                subCategoryLbl.ForeColor = Color.Gray;
                subCategoryCB.Items.Clear();
            }

        }


        private void categoryCB_DropDownClosed(object sender, EventArgs e) //*
        {
            if (categoryCB.SelectedItem == null) 
            {
                subCategoryCB.Enabled = false;
                subCategoryBtn.Enabled = false;
                subCategoryLbl.ForeColor = Color.Gray;
                subCategoryCB.Text = null;
            }
        }

        private void BrandBtn_Click(object sender, EventArgs e)
        {
            int selectedBrandIndex = BrandCB.SelectedIndex;
            BrandForm brandForm = new BrandForm();
            brandForm.SetCallBack(this.OnUpdateBrand); //passo al metodo SetCallBack il metodo OnUpdateBrand, SETCALLBACK ACCETTA UN ARGOMENTO DI TIPO BRANDUPDATE CHE è UN DELEGATE
            brandForm.ShowDialog();

            BrandCB.SelectedIndex = selectedBrandIndex;
        }

        private void subCategoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            _product.SubCategory = (SubCategory)subCategoryCB.SelectedItem;

            if (_product.SubCategory != null)
            {
                if (_product.SubCategory.CategoryId == 1)
                {
                    subCategoryCB.Text = "-";
                    return;
                }
            }
        }


        private int ObtainIdProduct(int selectedRowIndex)
        {
            return ObtainID.ObtainIDelements.ObtainIdElement(selectedRowIndex, productsDGV, "Product_ID");
        }

        
        //-------------------------------------------------------------------------------------------------------------------------------------------//

        private void energyConsTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e,',');

            if (e.KeyChar == ',' && energyConsTB.Text.Contains(","))  //controllo per impedire all'utente di inserire più di un punto
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
            checkNumPress(e, ',');

            if (e.KeyChar == ',' && heightTB.Text.Contains(","))
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }

        private void checkDotsInput(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            if (textBox.Text.Length == 4 && !textBox.Text.Contains(',') && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
            {
                textBox.Text += ',';
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void widthTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e, ',');

            if (e.KeyChar == ',' && widthTB.Text.Contains(","))
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }


        private void depthTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e, ',');

            if (e.KeyChar == ',' && depthTB.Text.Contains(","))
            {
                e.Handled = true;
            }

            checkDotsInput(sender, e);
        }

        private void weightTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkNumPress(e,',');

            if (e.KeyChar == ',' && weightTB.Text.Contains(","))
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
            //catCB.Items.Clear();
            //ProductsMGM.LoadCategories(catCB);
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
            //selectAllRows.Location = new Point(productsDGV.Columns[0].Width / 2 - 5, selectAllRows.Location.Y);
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
            if (this._newEditCopy == 'n' || this._newEditCopy == 'c')
            {
                MessageBox.Show("Registra il prodotto prima di effettuare dei movimenti");
                return;
            }


            else
            {
                selectedRow = productsDGV.SelectedRows[0].Index;
                WareHouse.ChildForms.InsertProdInf insertProdInf = new WareHouse.ChildForms.InsertProdInf(ObtainIdProduct(selectedRow), ProductNameTB.Text);
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

        private void codArticleTB_Leave(object sender, EventArgs e)
        {
            _product.ProductName = ProductNameTB.Text;
        }

        private void serialNumberTB_Leave(object sender, EventArgs e)
        {
            _product.SerialNumber = serialNumberTB.Text;
        }

        private void BrandCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(BrandCB.SelectedItem != null)
            {
                _product.BrandP = BrandCB.SelectedItem as Brand;

            }

            if (BrandCB.Text == "-" && BrandCB.SelectedIndex == 0)
            {
                BrandCB.SelectedItem = null;
            }
        }
    }
    
}




