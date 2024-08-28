using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GManagerial.Products.ChildForms;
using GManagerial.Products.ChildForms.AddSupplier.models;
using GManagerial.Products.SellPrices;

namespace GManagerial.Products
{
    public delegate void UpdateComboBox();
    public partial class ProductsForm
    {
        private DAOSellPrice _daoSellPrice;
        private Dictionary<int, SupplierProduct> _unselectedSuppliers = new Dictionary<int, SupplierProduct>();
        private Dictionary<int, SupplierProduct> _selectedSuppliers = new Dictionary<int, SupplierProduct>();

        private Dictionary<int, SupplierProduct> _unselectedSuppliersTemp = new Dictionary<int, SupplierProduct>();
        private Dictionary<int, SupplierProduct> _selectedSuppliersTemp = new Dictionary<int, SupplierProduct>();

        private Dictionary<int, SupplierProduct> _supplierToAdd = new Dictionary<int, SupplierProduct>();
        private Dictionary<int, SupplierProduct> _supplierToRemove = new Dictionary<int, SupplierProduct>();

        private Dictionary<int, SupplierProduct> _copyDictionary = new Dictionary<int, SupplierProduct>();

        private Dictionary<string, SellPrice> _productPrices = new Dictionary<string, SellPrice>();

        private DAOSupplierProduct _daoProductSupplier;

        private void LoadSupplierComboBox()
        {
            SupplierCB.Items.Clear();

            foreach (SupplierProduct supplierProduct in _selectedSuppliersTemp.Values)
            {
                if (!SupplierCB.Items.Contains(supplierProduct))
                {
                    SupplierCB.Items.Add(supplierProduct);
                }
            }

            try
            {
                SupplierCB.SelectedIndex = _product.LastSupplierSelected;
            }

            catch (System.ArgumentOutOfRangeException)
            {
                SupplierCB.SelectedIndex = 0;
            }

            SupplierCB.DisplayMember = "CustomDisplay";

            SupplierCB.Format += (sender, e) =>
            {
                if (e.ListItem is SupplierProduct supplierProduct)
                {
                    e.Value = supplierProduct.SupplierProps.SupplierName; // Impostare il valore di visualizzazione come il nome del fornitore
                }
            };
        }


        public void AddSupplier_Click(object sender, EventArgs e)
        {
            int selectedIndex = SupplierCB.SelectedIndex;
            AddSupplierForm addSupplierForm = new AddSupplierForm(_unselectedSuppliersTemp, _selectedSuppliersTemp, _supplierToAdd, LoadSupplierComboBox);
            addSupplierForm.ShowDialog();


            try
            {
                SupplierCB.SelectedIndex = SupplierCB.Items.Count - 1;

                _formLogicGUI.CleanTextBox(new TextBox[] { ListPriceTB1, ListPriceTB2, ListPriceTB3, ListPriceTB4, ListPriceTB5, ListPriceTB6 });
                SellPricesToProductPrices();
                LoadPricesIntoTextBox();
            }

            catch
            {
                SupplierCB.SelectedIndex = 0;
            }

        }

        private void RemoveSupplier_Click(object sender, EventArgs e)
        {
            int selectedIndex = SupplierCB.SelectedIndex;
            RemoveSupplierForm removeSupplierForm = new RemoveSupplierForm(_unselectedSuppliersTemp, _selectedSuppliersTemp, _supplierToRemove, LoadSupplierComboBox);
            removeSupplierForm.ShowDialog();

            try
            {
                SupplierCB.SelectedIndex = selectedIndex;
            }

            catch
            {
                SupplierCB.SelectedIndex = 0;
            }

        }

        private void SupplierCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierProduct supplierProduct = new SupplierProduct();
            supplierProduct = SupplierCB.SelectedItem as SupplierProduct;

            if (supplierProduct is null)
            {
                supplierProduct = new SupplierProduct();
                Supplier supplier = new Supplier();

                supplierProduct.SupplierProps = supplier;
                supplierProduct.SupplierProps.ID = 1;
                supplierProduct.SupplierProps.SupplierName = "-";
                supplierProduct.Id = 1;
            }
            SupplierPriceTB.Text = Convert.ToString(supplierProduct.GetSupplierPrice());

            LoadPricesIntoTextBox();
            SellPricesToProductPrices();
        }

        private void ConfirmBtn3_Click(object sender, EventArgs e)
        {
            ProductTab.SelectedIndex = 0;
            confirmBtn_Click(sender, e);
        }

        private void CancelBtn3_Click(object sender, EventArgs e)
        {
            ProductTab.SelectedIndex = 0;
            cancelBtn_Click(sender, e);
        }

        private void TBPrice_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                try
                {
                    if (!textBox.Name.Equals("SupplierPrice"))
                    {
                        _listPrice = decimal.Parse(textBox.Text);
                    }

                    _supplierPrice = decimal.Parse(SupplierPriceTB.Text);
                    decimal incomePerc = Math.Round((((_listPrice - _supplierPrice) / _supplierPrice) * 100), 2);
                    IncomePercTB.Text = Convert.ToString(incomePerc);
                    IncomeTB.Text = Convert.ToString(_listPrice - _supplierPrice);
                }

                catch (Exception)
                {
                    IncomePercTB.Text = "0";
                    IncomeTB.Text = "0";
                }
            }
        }

        private void SupplierRegister(int id_product, IsNewEditCopyDeleteEnum isNewEditCopyDeleteEnum)
        {
            if (isNewEditCopyDeleteEnum == IsNewEditCopyDeleteEnum.New)
            {
                SupplierProduct supplierProduct = SupplierCB.Items[0] as SupplierProduct;
                if (supplierProduct is null) //assegna la linetta
                {
                    supplierProduct = new SupplierProduct();
                    Supplier supplier = new Supplier();

                    supplierProduct.SetSupplierPrice(SupplierPriceTB.Text);
                    supplierProduct.SupplierProps = supplier;
                    supplierProduct.SupplierProps.ID = 1;
                    supplierProduct.SupplierProps.SupplierName = "-";
                }
                _daoProductSupplier.Insert(supplierProduct, id_product);
            }

            if (isNewEditCopyDeleteEnum == IsNewEditCopyDeleteEnum.Copy)
            {
                foreach (SupplierProduct supplierProductItem in _copyDictionary.Values)
                {
                    _daoProductSupplier.Insert(supplierProductItem, id_product);
                }
            }

            foreach (SupplierProduct supplierProductItem in _supplierToAdd.Values)
            {
                supplierProductItem.ProductProps = new Product() { ID = _product.ID, ProductName = _product.ProductName };
                _daoProductSupplier.Insert(supplierProductItem, id_product);
            }


            foreach (SupplierProduct supplierProduct in SupplierCB.Items)
            {
                supplierProduct.ProductProps = new Product() { ID = _product.ID, ProductName = _product.ProductName };
                _daoProductSupplier.Update(supplierProduct);
            }

            foreach (SupplierProduct supplierProduct in _supplierToRemove.Values)
            {
                _daoProductSupplier.Delete(supplierProduct, id_product);
                _daoSellPrice.Delete(id_product, supplierProduct.SupplierProps.ID);//cancellare tutti i prezzi di vendita del prodotto con quel fornitore abbinato
            }

        }

        private void DictionaryClean()
        {
            _selectedSuppliersTemp.Clear();
            _unselectedSuppliersTemp.Clear();
            _supplierToAdd.Clear();
            _supplierToRemove.Clear();
            _productPrices.Clear();
        }

        private void SupplierPrice_Leave(object sender, EventArgs e)
        {
            SupplierProduct supplierProduct = SupplierCB.SelectedItem as SupplierProduct;
            if (supplierProduct is null)
            {
                supplierProduct = SupplierCB.Items[0] as SupplierProduct;
            }

            supplierProduct.SetSupplierPrice(SupplierPriceTB.Text);
        }

        private void CopyAllSuppliersWithPricesToNewProduct()
        {
            _copyDictionary = _daoProductSupplier.GetSelectedSuppliers(_product, SupplierProductQueries.SELECTSUPPLIERSFOREXISTINGPRODUCT);
            SupplierCB.Items.Clear();

            foreach (SupplierProduct supplierProduct in _copyDictionary.Values)
            {
                SupplierCB.Items.Add(supplierProduct);
                _selectedSuppliersTemp.Add(supplierProduct.SupplierProps.ID, supplierProduct);
            }
            SupplierCB.DisplayMember = "SupplierName";
        }

        private void ListPrice_Leave(object sender, EventArgs e)
        {
            SellPricesToProductPrices();
        }

        private void SellPricesToProductPrices() //metodo per caricare il dizionario da inviare al db (non quando fa il cambio del fornitore)
        {
            SupplierProduct supplierProduct = SupplierCB.SelectedItem as SupplierProduct;

            foreach (Control control in PricesTab.Controls)
            {
                if (control.GetType() == typeof(DecimalTextBox) && control.Name != "SupplierPrice")
                {
                    DecimalTextBox priceTextBox = (DecimalTextBox)control;
                    SellPrice sellPrice = new SellPrice();
                    sellPrice.SupplierId = supplierProduct.SupplierProps.ID;

                    if (sellPrice.SetPrice(priceTextBox.Text))
                    {
                        sellPrice.ListPrice = priceTextBox.Name;

                        if (!_productPrices.ContainsKey(sellPrice.ListPrice))
                        {
                            _productPrices.Add(sellPrice.ListPrice, sellPrice);
                        }

                        else
                        {
                            SellPrice tempSellPrice = _productPrices[sellPrice.ListPrice];
                            sellPrice.Id = tempSellPrice.Id;
                            _productPrices[sellPrice.ListPrice] = sellPrice;
                        }
                    }
                }
            }

        }

        private void InsertPricesIntoDB(int id_product)
        {
            foreach (SellPrice obj in _productPrices.Values)
            {
                obj.ProductId = id_product;
                if (_isNewEditCopyDelete == IsNewEditCopyDeleteEnum.New || _isNewEditCopyDelete == IsNewEditCopyDeleteEnum.Copy || obj.Id.Equals(0))
                {
                    _daoSellPrice.Insert(obj);
                }

                else
                {
                    _daoSellPrice.Update(obj);
                }
            }
        }

        private void LoadPricesIntoTextBox()
        {
            SupplierProduct supplier = SupplierCB.SelectedItem as SupplierProduct;

            int id_supplier = supplier.SupplierProps.ID;

            foreach (SellPrice price in _productPrices.Values)
            {
                if (price.SupplierId.Equals(id_supplier))
                {
                    DecimalTextBox decimalTextBox = DecimalTextBoxSearch(price.ListPrice);
                    decimalTextBox.Text = Convert.ToString(price.GetPrice);
                }
            }
        }

        private DecimalTextBox DecimalTextBoxSearch(string textBoxName)
        {
            foreach (Control control in PricesTab.Controls)
            {
                if (control is DecimalTextBox)
                {
                    if (control.Name.Equals(textBoxName))
                    {
                        DecimalTextBox decimalTextBox = control as DecimalTextBox;
                        return decimalTextBox;
                    }
                }
            }
            return null;
        }

        private void DeletePrices()
        {

        }
    }
}
