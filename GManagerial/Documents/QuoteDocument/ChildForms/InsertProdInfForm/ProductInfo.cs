using GManagerial.DBConnectors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GManagerial.Products;
using GManagerial.WareHouse.models.WareHouseProducts;
using GManagerial.Products.SellPrices;

namespace GManagerial.QuoteDocForms.ChildForms
{
    internal partial class ProductInformationsForQuoteDocument : Form
    {
        private IsNewEditCopyDeleteEnum _isNewEditDelete;       
        private DBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        private Product _product;      
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();
        private DAOSellPrice _daoSellPrice;
        private Dictionary<string, SellPrice> _sellPrice;
        private OnFormClosing _onFormClosing;

        /*evento*/
        internal event EventHandler<WareHouseProduct> PopulateDictionaryRequested;

        internal ProductInformationsForQuoteDocument(Product product, IsNewEditCopyDeleteEnum isNewEditDelete, OnFormClosing onFormClosing)
        {
            InitializeComponent();
            InitializeSetAddComponents();
            this._product = product;
            this._daoSellPrice = new DAOSellPrice(_dbConnector);
            this._isNewEditDelete = isNewEditDelete;
            this._product = product;
            this._sellPrice = new Dictionary<string, SellPrice>();
            this._onFormClosing = onFormClosing;
        }

        

        private void SelectProductBySupplier_Load(object sender, EventArgs e)
        {
            LoadProductPrices();
        }

        private void LoadProductPrices()
        {
            _sellPrice = _daoSellPrice.GetAll(_product);
            priceListSell.Items.Clear();

            foreach (SellPrice price in _sellPrice.Values) 
            {
                priceListSell.Items.Add(price);
            }
            priceListSell.DisplayMember = "GetPrice";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!QtaTB.Text.Equals(string.Empty) && !QtaIsEqualToZero())
            {
                //PopulateDictionaryRequested?.Invoke(this, ); DA COMPLETARE
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

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
