using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GManagerial.Products.ChildForms;
using GManagerial.DBConnectors;
using GManagerial.Products.ChildForms.CategorySubForm.Models;
using GManagerial.Attachments;
using GManagerial.Products.ChildForms.AddSupplier.models;
using GManagerial.Products.SellPrices;
using GManagerial.WareHouse.models.Movements;


namespace GManagerial.Products
{
    public delegate void BrandUpdate(); //DICHIARAZIONE DELEGATE
    public delegate void CategoryUpdate();
    internal delegate void SubCategoryUpdate(ICategory category);

    public partial class ProductsForm : Form
    {
        private System.Windows.Forms.Button[] _buttonList;
        private System.Windows.Forms.TextBox[] _textboxes;
        private System.Windows.Forms.ComboBox[] _comboboxes;
        internal IsNewEditCopyDeleteEnum _isNewEditCopyDelete;

        private Product _product;

        private IDBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");

        private Dictionary<string, IBrand> _brands; //->lista
        private Dictionary<string, ICategory> _categories; //->lista
        private Dictionary<string, ISubCategory> _subCategories; //->lista

        private DAOProduct _daoProduct;
        private DAOBrand _daoBrand;
        private DAOCategory _daoCategory;
        private DAOSubCategory _daoSubCategory;
        private DAOAttachments _daoAttachment;
        private DAOObjectAttachments _daoObjectAttachments;
        //private DAOSupplier _daoSupplier;
        private DAODetailsMovement _daoDetailsMovement;
        //private DAOSupplierProduct _daoSupplierProduct;
        private AttachmentForm _attachmentForm;
        private Dictionary<int,Product> _products; //dizionario dove ho tutti i prodotti
        private FormLogicGUI _formLogicGUI;
        private RowLogic.RowLogic _rowLogic;

        private decimal _supplierPrice = 0.0M;
        private decimal _listPrice = 0.0M;
        private int _selectedRow;
        public ProductsForm()
        {
            InitializeComponent();

            InitializeSetAddComponents();

            this._daoSellPrice = new DAOSellPrice(this._dbConnector);
            this._daoProduct = new DAOProduct(this._dbConnector);
            this._daoBrand = new DAOBrand(this._dbConnector); //-> da cancellare
                                                              //this._daoSupplier = new DAOSupplier(this._dbConnector);
            this._daoCategory = new DAOCategory(this._dbConnector);
            this._daoSubCategory = new DAOSubCategory(this._dbConnector);
            this._daoProductSupplier = new DAOSupplierProduct(this._dbConnector);
            this._daoAttachment = new DAOAttachments(_dbConnector, AttachmentQuery.INSERT_ATTACHMENT, AttachmentQuery.DELETE_ATTACHMENT);

            this._daoDetailsMovement = new DAODetailsMovement(_dbConnector);
            this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector, AttachmentQuery.SELECT_PRODUCT, AttachmentQuery.INSERT_PRODUCT, AttachmentQuery.DELETE_PRODUCT);
            //this._daoSupplierProduct = new DAOSupplierProduct(this._dbConnector);

            this._brands = this._daoBrand.GetAllDictionaries();    //-> da cancellare
            this._categories = this._daoCategory.GetAllDictionaries();
            this._subCategories = this._daoSubCategory.GetAllDictionaries();

            this._formLogicGUI = new FormLogicGUI();

            this._buttonList = new System.Windows.Forms.Button[] { ConfirmBtn, CancelBtn, confirmBtn2, cancelBtn2, barcBtn, AttachmentsBtn, ImageBtn };
            this._textboxes = new System.Windows.Forms.TextBox[] {ProductNameTB, serialNumberTB, ManufacturingDateTB, descriptionTB, heightTB, widthTB, depthTB, weightTB, energyTB, powerTB,
                energyConsTB, notesTB, SupplierPriceTB, ListPriceTB1, ListPriceTB2, ListPriceTB3, ListPriceTB4, ListPriceTB5, ListPriceTB6};
            this._comboboxes = new System.Windows.Forms.ComboBox[] { BrandCB, CategoryCB, SubCategoryCB };
            this._rowLogic = new RowLogic.RowLogic(ProductsDGV);
            this.AddSupplier.Click += new System.EventHandler(AddSupplier_Click);
        }

        private void OnUpdateBrand()
        {
            this._brands = this._daoBrand.GetAllDictionaries();
            BrandCB.Items.Clear();
            foreach (IBrand brand in _brands.Values)
            {
                BrandCB.Items.Add(brand);
                BrandSearchCB.Items.Add(brand);
            }

            BrandCB.DisplayMember = "Name";
            BrandSearchCB.DisplayMember = "Name";
        }

        private void OnUpdateCategory()
        {
            this._categories = this._daoCategory.GetAllDictionaries();
            CategoryCB.Items.Clear();
            CategorySearchCB.Items.Clear();

            foreach (ICategory category in _categories.Values)
            {
                CategoryCB.Items.Add(category);
                CategorySearchCB.Items.Add(category);
            }

            CategoryCB.DisplayMember = "CategoryName"; // Imposta il membro da visualizzare
            CategorySearchCB.DisplayMember = "CategoryName";
        }

        private void OnUpdateSubCategory(ICategory category)
        {
            this._subCategories = this._daoSubCategory.GetAllSubCategoriesFromACategoryDictionaries(category);
            SubCategoryCB.Items.Clear();
            SubCategorySearchCB.Items.Clear();

            foreach (ISubCategory subCategory in _subCategories.Values)
            {
                SubCategoryCB.Items.Add(subCategory);
                SubCategorySearchCB.Items.Add(subCategory);
            }

            SubCategoryCB.DisplayMember = "SubCategoryName";
            SubCategorySearchCB.DisplayMember = "SubCategoryName";
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            OnUpdateBrand();
            OnUpdateCategory();
        }

        private void UpdateDataGridView()
        {
            ProductsDGV.Rows.Clear();
            _products = _daoProduct.GetAll();
            DataGridViewPopulateFromDictionary();
        }

        private void UpdateDataGridViewFilter()//delegate?
        {
            ProductsDGV.Rows.Clear();
            DataGridViewPopulateFromDictionary();
        }

        private void DataGridViewPopulateFromDictionary()
        {
            foreach (Product product in _products.Values)
            {
                int rowIndex = ProductsDGV.Rows.Add();
                ProductsDGV.Rows[rowIndex].Cells[0].Value = product.ID;
                ProductsDGV.Rows[rowIndex].Cells[1].Value = product.ProductName;
                ProductsDGV.Rows[rowIndex].Cells[2].Value = product.ResizedImage;
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.New;
            _formLogicGUI.NewEditCopyButtonEnable(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList, stripBtns, ProductsDGV);

            if (ProductsDGV.SelectedRows.Count > 0)
            {
                _selectedRow = ProductsDGV.SelectedRows[0].Index;
            }

            _product = new Product();
            _product.BrandP = new Brand();
            _product.CategoryObj = new Category();
            _product.SubCategory = new SubCategory();


            _product.Attachments = new Dictionary<int, IAttachment>();
            _product.TempAttachments = new Dictionary<int, IAttachment>();
            _product.AttachmentsToDelete = new Dictionary<int, IAttachment>();

            _selectedSuppliers = _daoProductSupplier.GetSelectedSuppliers(_product, SupplierProductQueries.SELECTSUPPLIERSFORNEWPRODUCT);
            _selectedSuppliersTemp = new Dictionary<int, SupplierProduct>(_selectedSuppliers);
            LoadSupplierComboBox();

            _unselectedSuppliers = _daoProductSupplier.GetUnselectedProducts(_product);
            _unselectedSuppliersTemp = new Dictionary<int, SupplierProduct>(_unselectedSuppliers);

            SupplierCB.SelectedIndex = 0; //-> da spostare
        }


        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ProductsDGV.SelectedRows.Count == 1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Edit;
                _selectedRow = ProductsDGV.SelectedRows[0].Index;

                int id = (int)ProductsDGV.SelectedRows[0].Cells[0].Value;
                _product = new Product();
                _product = _products[id];


                _product.TempAttachments = new Dictionary<int, IAttachment>();
                _product.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _product.Attachments = _daoObjectAttachments.GetAll(id);

                _unselectedSuppliers = _daoProductSupplier.GetUnselectedProducts(_product);
                _unselectedSuppliersTemp = new Dictionary<int, SupplierProduct>(_unselectedSuppliers);

                _selectedSuppliers = _daoProductSupplier.GetSelectedSuppliers(_product, SupplierProductQueries.SELECTSUPPLIERSFOREXISTINGPRODUCT);
                _selectedSuppliersTemp = new Dictionary<int, SupplierProduct>(_selectedSuppliers);

                _productPrices = _daoSellPrice.GetAll(_product);

                LoadSupplierComboBox();//lista di tutti i fornitori

                TransferDataFromDictionariesToPanelControls();
                _formLogicGUI.NewEditCopyButtonEnable(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList, stripBtns, ProductsDGV);
            }

            else if (ProductsDGV.SelectedRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                _formLogicGUI.SelectElement("prodotto");
                return;
            }
            //SupplierCB.SelectedIndex = 0;

        }

        private void TransferDataFromDictionariesToPanelControls()
        {
            ProductNameTB.Text = _product.ProductName;
            serialNumberTB.Text = _product.SerialNumber;
            BrandCB.Text = _product.BrandP.Name;

            CategoryCB.Text = _product.CategoryObj.CategoryName;
            SubCategoryCB.Text = _product.SubCategory.SubCategoryName;
            descriptionTB.Text = _product.Description;
            notesTB.Text = _product.Notes;

            heightTB.Text = _product.GetHeight.ToString();
            widthTB.Text = _product.GetWidth.ToString();
            weightTB.Text = _product.GetWeight.ToString();
            depthTB.Text = _product.GetDepth.ToString();
            energyTB.Text = _product.EnergyClass;

            energyConsTB.Text = _product.GetEnergyConsumption.ToString();
            powerTB.Text = _product.GetPower.ToString();

            ManufacturingDateTB.Text = (_product.ManufacturingDate == string.Empty) ? string.Empty : _product.ManufacturingDate.Substring(0, 10);
        }
        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (ProductsDGV.SelectedRows.Count == 1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Copy;
                _selectedRow = ProductsDGV.SelectedRows[0].Index;

                _product = new Product();

                int id = (int)ProductsDGV.SelectedRows[0].Cells[0].Value;
                _product = _products[id];

                _product.TempAttachments = new Dictionary<int, IAttachment>();
                _product.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _product.Attachments = _daoObjectAttachments.GetAll(id);

                _formLogicGUI = new FormLogicGUI();
                TransferDataFromDictionariesToPanelControls();

                _productPrices = _daoSellPrice.GetAll(_product);

                CopyAllSuppliersWithPricesToNewProduct();
                _unselectedSuppliers = _daoProductSupplier.GetUnselectedProducts(_product);
                _unselectedSuppliersTemp = new Dictionary<int, SupplierProduct>(_unselectedSuppliers);

                _formLogicGUI.NewEditCopyButtonEnable(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList, stripBtns, ProductsDGV);
                SupplierCB.SelectedIndex = 0;
            }
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (ProductsDGV.RowCount > 0 && ProductsDGV.SelectedRows.Count > 0)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Delete;
                _selectedRow = ProductsDGV.SelectedRows[0].Index;

                CheckUserChoice();
            }


            if (selectAllRows.Checked)
            {
                CheckUserChoice();
                selectAllRows.Checked = false;
            }
        }

        private void CheckUserChoice() //controllare se l'utente è sicuro di voler cancellare la riga o le righe selezionate
        {
            if (ProductsDGV.SelectedRows.Count > 0)
            {
                DialogResult firstDialog = MessageBox.Show("Attenzione, la cancellazione di un prodotto porterà anche all'eliminazione dei vari movimenti a magazzino, prezzi, ecc.\n\nVuoi proseguire?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (firstDialog == DialogResult.Yes)
                {
                    DialogResult dialogResult = MessageBox.Show("Sei sicuro di voler cancellare l'elemento selezionato?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in ProductsDGV.SelectedRows)
                        {
                            _product = new Product();
                            int id_product = (int)row.Cells[0].Value;
                            _product = _products[id_product];

                            _product.AttachmentsToDelete = _daoObjectAttachments.GetAll(id_product); //tutti gli allegati
                                                                                                     //DELETE MOVEMENTS
                                                                                                     //_daoDetailsMovement.Delete(_product);
                            _daoDetailsMovement.Update(_product);
                            _daoProduct.Delete(_product, ProductQueries.DELETEWAREHOUSEPRODUCT);
                            _daoProduct.Delete(_product, ProductQueries.DELETEPRODUCTSUPPLIER);
                            _daoProduct.Delete(_product, ProductQueries.DELETEPRODUCTPRICES);

                            DeleteAttachments();
                            DeleteProduct(id_product);

                            _rowLogic.RowToSelectInDataGridView(_isNewEditCopyDelete, _selectedRow);
                            SelectedRows(_isNewEditCopyDelete);
                        }
                    }
                }
            }


            else
            {
                //MessageBox.Show("Seleziona prima una riga da cancellare", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning); FORMLOGICGUI
            }
        }

        private void SelectedRows(IsNewEditCopyDeleteEnum command) //per cancellazione
        {
            int row = _rowLogic.RowToSelectInDataGridView(command, _selectedRow);
            UpdateDataGridView();

            if (ProductsDGV.Rows.Count > 0)
            {
                ProductsDGV.ClearSelection();
                ProductsDGV.Rows[row].Selected = true;
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
            _product = _products[id_product];
            _daoProduct.Delete(_product, ProductQueries.DELETEPRODUCT);
            _products.Remove(_product.ID);
        }


        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (DataPanelValidate())
            {
                int id_product; //id per recuperare l'ultima riga inserita

                if (_isNewEditCopyDelete == IsNewEditCopyDeleteEnum.New || _isNewEditCopyDelete == IsNewEditCopyDeleteEnum.Copy)  //if (_newEditCopyDelete == 'n' || _newEditCopyDelete == 'c')
                {
                    id_product = _daoProduct.Insert(_product); //nuovo inserimento recupero l'id direttamente dalla query
                    if (!id_product.Equals(0))
                    {
                        SupplierRegister(id_product, _isNewEditCopyDelete); //fornitori abbinati al prodotto
                        InsertPricesIntoDB(id_product);
                    }

                    else
                    {
                        MessageBox.Show("Esiste già un prodotto con questo nome", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                else
                {
                    _daoProduct.Update(_product); //l'id ce l'ho già, perché sto cercando di modificare un prodotto già esistente
                    id_product = _product.ID;
                    SupplierRegister(id_product, IsNewEditCopyDeleteEnum.Edit);
                    InsertPricesIntoDB(id_product);
                }


                foreach (Attachment attachment in _product.TempAttachments.Values)
                {
                    int id_attachment = _daoAttachment.Insert(attachment);
                    _daoObjectAttachments.Insert(id_product, id_attachment);
                }

                AttachmentForm.TempID = -1; //risetto la variabile TempID che mi serviva per gli allegati temporanei

                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList, stripBtns, ProductsDGV);
                CancelSearchBtn_Click(sender, e);//azzera tutti i filtri di ricerca
                UpdateDataGridView(); //aggiorna datagridview
                DeletePrices();
                DictionaryClean();
                SelectedRows(_isNewEditCopyDelete); //seleziona la riga corretta, per evitare che se si sposti da solo nel primo elemento del datagridview da solo
            }
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (_formLogicGUI.PrintCancelEdit())
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Cancel;
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanelTP, ProductTab, _comboboxes, _textboxes, _buttonList, stripBtns, ProductsDGV);
                DictionaryClean();
                CancelSearchBtn_Click(sender, e);//azzera tutti i filtri di ricerca
                SelectedRows(_isNewEditCopyDelete);
            }
            selectAllRows.Checked = false;
            AttachmentForm.TempID = -1;
        }

        private void AttachmentsBtn_Click(object sender, EventArgs e)
        {
            _attachmentForm = new AttachmentForm(_product, _product.ID);
            _attachmentForm.ShowDialog();
        }

        private void ImageBtn_Click(object sender, EventArgs e)
        {
            ImageForm imageForm = new ImageForm(_product);
            imageForm.ShowDialog();
        }


        private void categoryBtn_Click(object sender, EventArgs e) //*
        {
            Category tempCategoryForStringAttribute = CategoryCB.SelectedItem as Category;
            SubCategory tempSubCategoryForStringAttribute = SubCategoryCB.SelectedItem as SubCategory;

            CategoriesForm categories = new CategoriesForm();
            categories.SetCategoryCallBack(this.OnUpdateCategory);
            categories.SetSubCategoryCallBack(this.OnUpdateSubCategory);
            categories.ShowDialog();

            if (tempCategoryForStringAttribute != null)
            {
                CategoryCB.Text = tempCategoryForStringAttribute.CategoryName;
            }

            if (tempSubCategoryForStringAttribute != null)
            {
                SubCategoryCB.Text = tempSubCategoryForStringAttribute.SubCategoryName;
            }
        }


        private void subCategoryBtn_Click(object sender, EventArgs e) //*
        {
            Category tempCategoryForStringAttribute = CategoryCB.SelectedItem as Category;
            SubCategory tempSubCategoryForStringAttribute = SubCategoryCB.SelectedItem as SubCategory;

            CategoriesForm categories = new CategoriesForm();
            categories.SetCategoryCallBack(this.OnUpdateCategory);
            categories.SetSubCategoryCallBack(this.OnUpdateSubCategory);
            categories.ShowDialog();

            if (tempCategoryForStringAttribute != null)
            {
                CategoryCB.Text = tempCategoryForStringAttribute.CategoryName;
            }

            if (tempSubCategoryForStringAttribute != null)
            {
                SubCategoryCB.Text = tempSubCategoryForStringAttribute.SubCategoryName;
            }
        }

        private void CategoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryCB.SelectedItem != null && CategoryCB.Text != "-")
            {
                _product.CategoryObj = CategoryCB.SelectedItem as Category;
                SubCategoryCB.Enabled = true;
                subCategoryBtn.Enabled = true;
                subCategoryLbl.ForeColor = Color.Black;

                if (_product.CategoryObj != null)
                {
                    OnUpdateSubCategory(_product.CategoryObj);
                }
            }

            else
            {
                CategoryCB.SelectedItem = null;
                SubCategoryCB.Enabled = false;
                subCategoryBtn.Enabled = false;
                SubCategoryCB.Items.Clear();
            }
        }


        private void categoryCB_DropDownClosed(object sender, EventArgs e) //*
        {
            if (CategoryCB.SelectedItem == null)
            {
                SubCategoryCB.Enabled = false;
                subCategoryBtn.Enabled = false;
                subCategoryLbl.ForeColor = Color.Gray;
                SubCategoryCB.Text = null;
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
        private void SubCategoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubCategoryCB.SelectedIndex != 0 && SubCategoryCB.SelectedIndex != -1)
            {
                _product.SubCategory = (SubCategory)SubCategoryCB.SelectedItem;
            }

            else
            {
                SubCategoryCB.SelectedItem = null;
            }
        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (SearchFilterPanel.Visible.Equals(true))
            {
                SearchFilterPanel.Visible = false;
                SearchFilterPanel.Enabled = false;
                AlertComboBoxSearchValues();
            }

            else
            {
                SearchFilterPanel.Visible = true;
                SearchFilterPanel.Enabled = true;
            }
        }


        private void AlertComboBoxSearchValues()
        {
            foreach (Control control in SearchFilterPanel.Controls)
            {
                if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox comboBox = control as System.Windows.Forms.ComboBox;
                    if (!(comboBox.SelectedItem is null))
                    {
                        //AllertImage.Visible = true;
                        SearchBtn.Image = Properties.Resources.exclamation;
                        return;
                    }
                }
            }

            //AllertImage.Visible = false;
            SearchBtn.Image = Properties.Resources.hamburger;
        }       

        private void selectAllRows_CheckedChanged(object sender, EventArgs e) //ROWLOGIC
        {            
            if (selectAllRows.Checked)
            {
                ProductsDGV.SelectAll();
            }

            else
            {
                ProductsDGV.ClearSelection();
            }                 
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
            cancelBtn_Click(sender, e);
        }


        private void uStockTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        /*-------------------------------------------------------------------------------------------------------------------------*/

        private void BrandCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BrandCB.SelectedItem != null)
            {
                _product.BrandP = BrandCB.SelectedItem as Brand;
            }

            if (BrandCB.Text == "-" && BrandCB.SelectedIndex == 0)
            {
                BrandCB.SelectedItem = null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------//

        public bool DataPanelValidate()
        {
            try
            {
                _product.ProductName = ProductNameTB.Text;
                _product.Description = descriptionTB.Text;
                _product.SerialNumber = serialNumberTB.Text;
                _product.BrandP = (BrandCB.SelectedItem == null) ? new Brand() : BrandCB.SelectedItem as Brand;
                _product.CategoryObj = (CategoryCB.SelectedItem == null) ? new Category() : CategoryCB.SelectedItem as Category;
                _product.SubCategory = (SubCategoryCB.SelectedItem == null) ? new SubCategory() : SubCategoryCB.SelectedItem as SubCategory;
                _product.ManufacturingDate = ManufacturingDateTB.Text;
                _product.SetHeight(heightTB.Text);
                _product.SetWidth(widthTB.Text);
                _product.SetPower(powerTB.Text);
                _product.SetWeight(weightTB.Text);
                _product.SetEnergyConsumption(energyConsTB.Text);
                _product.SetDepth(depthTB.Text);
                _product.Notes = notesTB.Text;
                _product.LastSupplierSelected = SupplierCB.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


    private void searchBox_TextChanged(object sender, EventArgs e)
    {
        if (!SearchTB.Text.Equals("Cerca") && SearchTB.Font.FontFamily.Name != "Times New Roman")
        {
            SearchProduct();
        }
     }


//--------------------------------------------------------PANELSEARCH----------------------------------------------------------------------------//


    private void catCB_DropDownClosed(object sender, EventArgs e)
    {
        if (!SearchTB.Text.Equals("Cerca") && SearchTB.Font.FontFamily.Name != "Times New Roman")
        {
            SearchProduct();
        }
    }


    private void SearchProduct()
    {
        string textToSearch;

        if (SearchTB.Text.Equals("Cerca") && SearchTB.Font.FontFamily.Name.Equals("Times New Roman"))
        {
            textToSearch = string.Empty;
        }

        else
        {
            textToSearch = SearchTB.Text;
        }

        if (CategorySearchCB.SelectedItem is null && SubCategorySearchCB.SelectedItem is null && BrandSearchCB.SelectedItem is null)
        {
            _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), CategorySearchCB.Text, SubCategorySearchCB.Text, BrandSearchCB.Text, ProductQueries.SEARCHPRODUCTS, null);
        }

        else if (!(CategorySearchCB.SelectedItem is null) && SubCategorySearchCB.SelectedItem is null && BrandSearchCB.SelectedItem is null)
        {
            _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), CategorySearchCB.Text, SubCategorySearchCB.Text, BrandSearchCB.Text, ProductQueries.SEARCHCATEGORIZEDPRODUCTS, null);
        }

        else if (!(CategorySearchCB.SelectedItem is null) && !(SubCategorySearchCB.SelectedItem is null) && BrandSearchCB.SelectedItem is null)
        {
            _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), CategorySearchCB.Text, SubCategorySearchCB.Text, BrandSearchCB.Text, ProductQueries.SEARCHCATEGORIZEDANDSUBPRODUCTS, null);
        }

        else if (!(CategorySearchCB.SelectedItem is null) && SubCategorySearchCB.SelectedItem is null && !(BrandSearchCB.SelectedItem is null))
        {
            _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), CategorySearchCB.Text, SubCategorySearchCB.Text, BrandSearchCB.Text, ProductQueries.SEARCHCATEGORIZEDBRANDIZEDPRODUCTS, null);
        }

        else if (CategorySearchCB.SelectedItem is null && SubCategorySearchCB.SelectedItem is null && !(BrandSearchCB.SelectedItem is null))
        {
            _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), CategorySearchCB.Text, SubCategorySearchCB.Text, BrandSearchCB.Text, ProductQueries.SEARCHBRANDIZEDPRODUCTS, null);
        }

        else if (!(CategorySearchCB.SelectedItem is null && SubCategorySearchCB.SelectedItem is null && !(BrandSearchCB.SelectedItem is null)))
        {
            _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), CategorySearchCB.Text, SubCategorySearchCB.Text, BrandSearchCB.Text, ProductQueries.SEARCHCATEGORIZEDANDSUBBRANDIZEDPRODUCTS, null);
        }
            UpdateDataGridViewFilter();
     }

//-------------------------------------------------ENDPANELSEARCH---------------------------------------------------------------------------//       
    
    private void SearchTB_Enter(object sender, EventArgs e)
    {
        if (SearchTB.Text.Equals("Cerca"))
        {
            SetTextForSearchBox();
        }
    }

    private void SearchTB_Leave(object sender, EventArgs e)
    {
        if (SearchTB.Text.Equals(string.Empty))
        {
            ResetStandardTextForSearchBox();
        }
    }
    private void ResetStandardTextForSearchBox()
    {
        SearchTB.Text = "Cerca";
        SearchTB.ForeColor = System.Drawing.SystemColors.ScrollBar;
        SearchTB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    }

    private void SetTextForSearchBox()
    {
        SearchTB.Text = string.Empty;
        SearchTB.ForeColor = Color.Black;
        SearchTB.Font = new Font("Arial", 12);
    }

    private void ProductsDGV_SelectionChanged(object sender, EventArgs e)
    {       
        if (!ProductsDGV.Enabled)
        {
            ProductsDGV.CurrentCell = null;
        }
    }

    private void CancelSearchBtn_Click(object sender, EventArgs e)
    {
        foreach (Control control in SearchFilterPanel.Controls)
        {
            if (control is System.Windows.Forms.ComboBox)
            {
                System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)control;
                comboBox.SelectedItem = null;
            }
        }
        //AllertImage.Visible = false;
        SearchBtn.Image = Properties.Resources.hamburger;
        SearchFilterPanel.Visible = false;
        SearchFilterPanel.Enabled = false;
        ResetStandardTextForSearchBox();
    }


    private void CategorySearchCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CategorySearchCB.SelectedItem != null && CategorySearchCB.Text != "-")
        {
            SubCategorySearchCB.Enabled = true;
            SubCategorySearchLbl.ForeColor = Color.Black;
            if (CategorySearchCB.SelectedItem != null)
            {
               OnUpdateSubCategory(CategorySearchCB.SelectedItem as Category);
            }
        }

        else
        {
            CategorySearchCB.SelectedItem = null;
            SubCategorySearchCB.Enabled = false;
            SubCategorySearchLbl.ForeColor = Color.Gray;
            SubCategorySearchCB.Items.Clear();
        }
        SearchProduct();
    }


    private void SubCategorySearchCB_SelectedIndexChanged(object sender, EventArgs e)
    {   
        if (SubCategorySearchCB.Text == "-")
        {            
            SubCategorySearchCB.SelectedItem = null;
        }

        else
        {             
            SearchProduct();
        }
    }

    private void SearchButton_Click(object sender, EventArgs e)
    {
        /* _products = _daoProduct.GetProductsSearch(SearchTB.Text.ToLower(), CategorySearchCB.Text, SubCategorySearchCB.Text, BrandSearchCB.Text, );
        UpdateDataGridViewFilter();

        if (decimal.TryParse(energyConsTB.Text, out energyConsumption))
        {
         _product.Weight = energyConsumption;
        }
        SearchFilterPanel.Visible = false;*/
    }


    private void BrandSearchCB_SelectedIndexChanged(object sender, EventArgs e)
    {
            if (BrandSearchCB.Text.Equals("-"))
            {
                BrandSearchCB.SelectedItem = null;
            }
            SearchProduct();
    }
    }
}




        



