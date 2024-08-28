using GManagerial.DBConnectors;
using GManagerial.Products.ChildForms;
using GManagerial.Products.ChildForms.AddSupplier.models;
using GManagerial.WareHouse.models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GManagerial.Products;
using GManagerial.WareHouse.models.WareHouseProducts;

namespace GManagerial.WareHouse.ChildForms
{
    internal partial class InsertProductInformations : Form
    {
        private IsNewEditCopyDeleteEnum _isNewEditDelete;
        private Dictionary<int, Warehouse> _warehouses = new Dictionary<int, Warehouse>();
        private DBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        //private DAOWareHouse _daoWareHouse;
        private DAOSupplierProduct _daoSupplierProduct;
        private OnFormClosing _onFormClosing;
        private Product _product;
        private Supplier _supplier;

        private Dictionary<Product, int> _products = new Dictionary<Product, int>();
        private WareHouseProduct _warehouseProduct;

        /*evento*/
        internal event EventHandler<WareHouseProduct> PopulateDictionaryRequested;

        internal InsertProductInformations(OnFormClosing onFormClosing, Product product, WareHouseProduct warehouseProduct, IsNewEditCopyDeleteEnum isNewEditDelete)
        {
            InitializeComponent();
            InitializeSetAddComponents();
            this._onFormClosing = onFormClosing;
            //this._daoWareHouse = new DAOWareHouse(_dbConnector);
            this._daoSupplierProduct = new DAOSupplierProduct(this._dbConnector);
            this._product = product;
            this._warehouseProduct = warehouseProduct;
            this._isNewEditDelete = isNewEditDelete;
            this._product = product;
        }

        public InsertProductInformations(WareHouseProduct wareHouseProduct, IsNewEditCopyDeleteEnum isNewEditDelete) //costruzione per edit
        {
            InitializeComponent();
            InitializeSetAddComponents();
            this._warehouseProduct = wareHouseProduct;
            this._isNewEditDelete = isNewEditDelete;
            this._daoSupplierProduct = new DAOSupplierProduct(this._dbConnector);
            //this._product = wareHouseProduct.ProductProps;
            this._product = wareHouseProduct;
        }

        public InsertProductInformations(WareHouseProduct wareHouseProduct, OnFormClosing onFormClosing, Product product, Supplier supplier, IsNewEditCopyDeleteEnum isNewEditDelete) : this(onFormClosing, product, wareHouseProduct, isNewEditDelete)
        {
            SupplierCB.Enabled = false;
            this._supplier = supplier;
        }

        private void SelectProductBySupplier_Load(object sender, EventArgs e)
        {
            OnLoadSuppliers();

            if (this._isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.New) && this._supplier is null)
            {
                if (this.SupplierCB.Items.Count > 0)
                {
                    this.SupplierCB.SelectedIndex = 0;
                }
            }

            else if (!(_supplier is null))
            {
                SupplierCB.Text = this._supplier.SupplierName;
            }

            else
            {
                LoadWareHouseProductDataInControls(); //tutti i fornitori del prodotto
            }
        }

        private void LoadWareHouseProductDataInControls()
        {
            SupplierCB.Text = _warehouseProduct.SupplierProps.SupplierName;
            QtaTB.Text = Convert.ToString(_warehouseProduct.Stock);
        }

        private void OnLoadSuppliers()
        {
            Dictionary<int, SupplierProduct> selectedSuppliers = _daoSupplierProduct.GetSelectedSuppliers(_product, SupplierProductQueries.SELECTSUPPLIERSFOREXISTINGPRODUCT);
            SupplierCB.Items.Clear();

            foreach (SupplierProduct supplier in selectedSuppliers.Values)
            {
                SupplierCB.Items.Add(supplier);
            }

            SupplierCB.Format += (sender, e) =>
            {
                if (e.ListItem is SupplierProduct supplierProduct)
                {
                    e.Value = supplierProduct.SupplierProps.SupplierName; // Impostare il valore di visualizzazione come il nome del fornitore
                }
            };
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddWareHouseProductToDictionary()
        {
            SupplierProduct selectedSupplier = SupplierCB.SelectedItem as SupplierProduct;
            Supplier supplier = new Supplier() { ID = selectedSupplier.SupplierProps.ID, SupplierName = SupplierCB.Text };
            _warehouseProduct.SupplierProps = supplier;
            _warehouseProduct.SetPriceSupplier(_price.Text);

            if (_isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.New))
            {
                //_warehouseProduct.ProductProps = _product;                
                _warehouseProduct.PassProductMembers(_product);
            }

            _warehouseProduct.Stock = Convert.ToInt32(QtaTB.Text);
        }

        

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!QtaTB.Text.Equals(string.Empty) && !QtaIsEqualToZero())
            {
                AddWareHouseProductToDictionary();
                PopulateDictionaryRequested?.Invoke(this, _warehouseProduct);
                if (_isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.New))
                {
                    _onFormClosing();
                }
                this.Close();
            }

            else
            {
                MessageBox.Show("Non puoi inserire una quantità uguale o inferiore a \"zero\"", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool QtaIsEqualToZero()
        {
            int result;
            if (int.TryParse(QtaTB.Text, out result))
            {
                if (result.Equals(0))
                {
                    return true;
                }
            }
            return false;
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

        }

        private void Expiration_dateTB_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Expiration_dateTB_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SupplierCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierProduct supplierProduct = SupplierCB.SelectedItem as SupplierProduct;
            this._price.Text = Convert.ToString(supplierProduct.GetSupplierPrice());
        }



        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
