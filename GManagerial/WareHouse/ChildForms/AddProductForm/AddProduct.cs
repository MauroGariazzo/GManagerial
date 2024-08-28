using GManagerial.DBConnectors;
using GManagerial.Products;
using GManagerial.Products.ChildForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GManagerial.WareHouse.models;

using GManagerial.WareHouse.models.WareHouseProducts;
using GManagerial.Products.ChildForms.AddSupplier.models;
using System.Drawing;


namespace GManagerial.WareHouse.ChildForms
{
    public delegate void OnFormClosing();
    internal partial class AddProduct : Form
    {
       
        //public int product_id;
        /*evento*/
        internal event EventHandler<WareHouseProduct> PopulateDictionaryRequested;

        private DBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        private DAOProduct _daoProduct;
        private DAOSupplier _daoSupplier;
        private DAOSupplierProduct _daoSupplierProduct;

        private Dictionary<int,Product> _products;
        private Product _product;

        //private Dictionary<int,SupplierProduct> _supplierProducts;
        private WareHouseProduct _wareHouseProduct;
        private Dictionary<int, Supplier> _suppliers;
        private Warehouse selectedWareHouse;
        private Supplier _supplier;
        public AddProduct(Warehouse selectedWareHouse)
        {
            InitializeComponent();
            this.selectedWareHouse = selectedWareHouse;
            //this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._products = new Dictionary<int,Product>();
            this._daoProduct = new DAOProduct(_dbConnector);
            this._product = new Product();
            this._wareHouseProduct = new WareHouseProduct();
            this._daoSupplier = new DAOSupplier(_dbConnector);
            this._supplier = new Supplier();
            this._daoSupplierProduct = new DAOSupplierProduct(_dbConnector);
        }

        public AddProduct(Warehouse selectedWareHouse, Supplier selectedSupplier) : this(selectedWareHouse)
        {
            this._supplier = selectedSupplier;
            this.SupplierCB.Enabled = false;
        }

        public AddProduct()
        {
            InitializeComponent();
            this._daoSupplierProduct = new DAOSupplierProduct(_dbConnector);
            this._supplier = new Supplier();
            this._daoSupplier = new DAOSupplier(_dbConnector);
            this._daoProduct = new DAOProduct(_dbConnector);
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            if (_supplier.ID.Equals(0))
            {        
                _products = _daoProduct.GetAll();
            }

            else
            {
                SupplierCB.Text = _supplier.SupplierName;
                _products = _daoSupplierProduct.GetSupplierProducts(_supplier);
            }

            OnUpdateListBox();
        }
 
        private void LoadSuppliers()
        {
            _suppliers = _daoSupplier.GetAll();
            SupplierCB.Items.Clear();

            foreach (Supplier supplier in _suppliers.Values)
            {
                SupplierCB.Items.Add(supplier);
            }
            SupplierCB.DisplayMember = "SupplierName";
        }
        

        private void OnUpdateListBox()
        {
            productsLB.Items.Clear();
            foreach (Product product in _products.Values)
            {              
                productsLB.Items.Add(product);
                PassProductIdToWarehouseProduct(product.ID);
            }

            productsLB.DisplayMember = "ProductName";
        }

        private void PassProductIdToWarehouseProduct(int product_fk)
        {
            _wareHouseProduct = new WareHouseProduct();
            Product product = new Product();
            _wareHouseProduct.ID = product_fk;
        }

        private void productsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productsLB.SelectedIndex != -1)
            {
                _product = (Product)productsLB.SelectedItem;
                TransferDataFromDictionariesToPanelControls(_product);
            }
        }

        private void TransferDataFromDictionariesToPanelControls(Product product)
        {
            ProductNameTB.Text = product.ProductName;
            serialNumberTB.Text = product.SerialNumber;
            BrandTB.Text = product.BrandP.Name;
            CategoryTB.Text = product.CategoryObj.CategoryName;
            SubCategoryTB.Text = product.SubCategory.SubCategoryName;
            descriptionTB.Text = product.Description;
            heightTB.Text = product.GetHeight.ToString();
            widthTB.Text = product.GetWidth.ToString();
            weightTB.Text = product.GetWeight.ToString();
            depthTB.Text = product.GetDepth.ToString();
            productPB.Image = product.Image;

            ManufacturingDateTB.Text = (product.ManufacturingDate == string.Empty) ? string.Empty : product.ManufacturingDate.Substring(0, 10);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (productsLB.SelectedIndex != -1)
            {
                if (_supplier.ID.Equals(0))
                {
                    //product è il prodotto che viene recuperato dalla lista
                    InsertProductInformations productInformation = new InsertProductInformations(CloseForm, _product, _wareHouseProduct, IsNewEditCopyDeleteEnum.New); //menù movimenti
                    productInformation.PopulateDictionaryRequested += AddProduct_PopulateDictionaryRequested;
                    productInformation.ShowDialog();
                }

                else
                {
                    InsertProductInformations productInformation = new InsertProductInformations(_wareHouseProduct, CloseForm, _product, _supplier, IsNewEditCopyDeleteEnum.New); //menù nuovo ordine
                    productInformation.PopulateDictionaryRequested += AddProduct_PopulateDictionaryRequested;
                    productInformation.ShowDialog();
                }
            }

            else
            {
                //FormLogicGUIObsolete.SelectElement("prodotto");
            }

        }
        private void AddProduct_PopulateDictionaryRequested(object sender, WareHouseProduct data)
        {
            PopulateDictionaryRequested?.Invoke(this, data);
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void qtaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
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

            if (SupplierCB.SelectedItem is null)
            {
                _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), null, null, null, ProductQueries.SEARCHPRODUCTS, null);
            }

            else
            {
                _products = _daoProduct.GetProductsSearch(textToSearch.ToLower(), null, null, null, ProductQueries.SEARCHPRODUCTSWITHSUPPLIER, _supplier);
            }
            OnUpdateListBox();
        }
     
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

        private void SupplierCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            _supplier = SupplierCB.SelectedItem as Supplier;

            if (_supplier.ID != 1)
            {
                _products = _daoSupplierProduct.GetSupplierProducts(_supplier);
                OnUpdateListBox();
            }

            else
            {
                _products = _daoProduct.GetAll();
                OnUpdateListBox();
            }
        }
    }
}
