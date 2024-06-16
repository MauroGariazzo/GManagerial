using GManagerial.WareHouse.ChildForms;
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
using GManagerial.WareHouse.models;
using System.Collections;
using GManagerial.Products;
using GManagerial.WareHouse.models.WareHouseProducts;
using GManagerial.WareHouse.models.Movements;
using GManagerial.DBConnectors;

namespace GManagerial.WareHouse.LoadMerch
{
    public partial class LoadMerchForm : Form
    {
        internal event EventHandler PopulateDataGridView; //evento
        private Warehouse _selectedWareHouse;
        private IsNewEditCopyDeleteEnum _isNewEditDelete;
        private Dictionary<(int,int),WareHouseProduct> _warehouseproducts;
        private DBConnector _dbConnector;
        private DAOMovement _daoMovement;
        private DAODetailsMovement _daoDetailsMovement;
        private DAOWarehouseProduct _daoWareHouseProduct;
        private Movement _tempMovement;
        public LoadMerchForm(Warehouse selectedWareHouse)
        {
            InitializeComponent();
            this._selectedWareHouse = selectedWareHouse;
            this._warehouseproducts = new Dictionary<(int, int), WareHouseProduct>();
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._daoMovement = new DAOMovement(_dbConnector);
            this._daoDetailsMovement = new DAODetailsMovement(_dbConnector);
            this._daoWareHouseProduct = new DAOWarehouseProduct(_dbConnector);
            this._tempMovement = new Movement() { WareHouseFK = _selectedWareHouse.ID, MovementType = "Carico"};
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            _isNewEditDelete = IsNewEditCopyDeleteEnum.New;
            ChildForms.AddProduct addProduct = new ChildForms.AddProduct(this._selectedWareHouse);
            addProduct.PopulateDictionaryRequested += SecondForm_PopulateDictionaryRequested;
            addProduct.ShowDialog();
        }

        private void SecondForm_PopulateDictionaryRequested(object sender, WareHouseProduct warehouseproduct)
        {
            if(!_warehouseproducts.Keys.Contains((warehouseproduct.ProductProps.ID, warehouseproduct.SupplierProps.ID)) && _isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.New))
            {
                _warehouseproducts.Add((warehouseproduct.ProductProps.ID, warehouseproduct.SupplierProps.ID), warehouseproduct);
                int rowIndex = LoadMerchDGV.Rows.Add();
                LoadMerchDGV.Rows[rowIndex].Cells[0].Value = warehouseproduct.ProductProps.ID;
                LoadMerchDGV.Rows[rowIndex].Cells[1].Value = warehouseproduct.ProductProps.ProductName;
                LoadMerchDGV.Rows[rowIndex].Cells[2].Value = warehouseproduct.SupplierProps.ID;
                LoadMerchDGV.Rows[rowIndex].Cells[3].Value = warehouseproduct.SupplierProps.SupplierName;
                LoadMerchDGV.Rows[rowIndex].Cells[4].Value = _selectedWareHouse.ID;
                LoadMerchDGV.Rows[rowIndex].Cells[5].Value = _selectedWareHouse.Warehouse_Name;
                LoadMerchDGV.Rows[rowIndex].Cells[6].Value = warehouseproduct.Stock;
            }

            else
            
                if (_warehouseproducts.Keys.Contains((warehouseproduct.ProductProps.ID, warehouseproduct.SupplierProps.ID)) && _isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.New))
                {
                    SearchOccurrencyIds(warehouseproduct, _isNewEditDelete);
                }
            

            else
            {
                if(_isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.Edit))
                {
                    SearchOccurrencyIds(warehouseproduct, _isNewEditDelete);
                }
            }

        }

        private void SearchOccurrencyIds(WareHouseProduct warehouseproduct, IsNewEditCopyDeleteEnum isNewEditDelete)
        {
            foreach (DataGridViewRow row in LoadMerchDGV.Rows) //??
            {
                if (isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.New))
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == warehouseproduct.ProductProps.ID &&
                        Convert.ToInt32(row.Cells[2].Value) == warehouseproduct.SupplierProps.ID)
                    {
                        int stock = Convert.ToInt32(row.Cells[6].Value);
                        stock += warehouseproduct.Stock;
                        row.Cells[6].Value = Convert.ToString(stock);
                        _warehouseproducts[(warehouseproduct.ProductProps.ID, warehouseproduct.SupplierProps.ID)].Stock = stock;
                    }
                }
            }

                
                
            if (isNewEditDelete.Equals(IsNewEditCopyDeleteEnum.Edit))
            {                
                _warehouseproducts.Remove((Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[0].Value), Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[2].Value)));

                if (!_warehouseproducts.Keys.Contains((warehouseproduct.ProductProps.ID, warehouseproduct.SupplierProps.ID)))
                {
                    _warehouseproducts.Add((warehouseproduct.ProductProps.ID, warehouseproduct.SupplierProps.ID), warehouseproduct);

                    LoadMerchDGV.SelectedRows[0].Cells[2].Value = warehouseproduct.SupplierProps.ID;
                    LoadMerchDGV.SelectedRows[0].Cells[3].Value = warehouseproduct.SupplierProps.SupplierName;

                    LoadMerchDGV.SelectedRows[0].Cells[5].Value = _selectedWareHouse.Warehouse_Name;
                    LoadMerchDGV.SelectedRows[0].Cells[6].Value = warehouseproduct.Stock;
                }

                else
                {
                    _warehouseproducts[(warehouseproduct.ProductProps.ID, warehouseproduct.SupplierProps.ID)].Stock += warehouseproduct.Stock;

                    LoadMerchDGV.Rows.Clear();
                    foreach(WareHouseProduct warehouseProduct in _warehouseproducts.Values)
                    {
                        int rowIndex = LoadMerchDGV.Rows.Add();
                        LoadMerchDGV.Rows[rowIndex].Cells[0].Value = warehouseProduct.ProductProps.ID;
                        LoadMerchDGV.Rows[rowIndex].Cells[1].Value = warehouseProduct.ProductProps.ProductName;
                        LoadMerchDGV.Rows[rowIndex].Cells[2].Value = warehouseProduct.SupplierProps.ID;
                        LoadMerchDGV.Rows[rowIndex].Cells[3].Value = warehouseProduct.SupplierProps.SupplierName;
                        LoadMerchDGV.Rows[rowIndex].Cells[6].Value = warehouseProduct.Stock;
                    }
                }
            }
               
         }
        
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if(LoadMerchDGV.Rows.Count > 0)
            {
                int movement_id = InsertMovementInWareHouseDB(); //id del movimento appena creato che mi servirà per inserire questo id in ciascun prodotto movimentato
                InsertDetailMovementAndProductsInWareHouseDB(movement_id);
                MessageBox.Show("Carico effettuato", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateDataGridView?.Invoke(this, e);
                this.Close();
            }

            else
            {
                MessageBox.Show("Inserisci prima dei prodotti da caricare","Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private int InsertMovementInWareHouseDB()
        {
            _tempMovement.DateMovement = DateTime.Now;
            _tempMovement.Causal = CausalTB.Text;
            _tempMovement.WareHouseFK = _selectedWareHouse.ID;
            return _daoMovement.Insert(_tempMovement);
        }

        private void InsertDetailMovementAndProductsInWareHouseDB(int movement_id) //inserisco i dettagli del movimento e i prodotti al magazzino
        {
            foreach (WareHouseProduct wareHouseProduct in _warehouseproducts.Values)
            {
                wareHouseProduct.WarehouseProps = new Warehouse() { ID = _selectedWareHouse.ID };
                _daoDetailsMovement.Insert(wareHouseProduct,movement_id);

                if (_daoWareHouseProduct.IsTheProductAlreadyInserted(wareHouseProduct).Equals(false))
                {
                    _daoWareHouseProduct.Insert(wareHouseProduct);
                }
                else
                {
                    _daoWareHouseProduct.Update(wareHouseProduct, WarehouseProductQueries.LOADPRODUCTS);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditProduct_Click(object sender, EventArgs e)
        {
            if(LoadMerchDGV.SelectedRows.Count > 0)
            {
                _isNewEditDelete = IsNewEditCopyDeleteEnum.Edit;
                DataGridViewRow row = LoadMerchDGV.SelectedRows[0];
                WareHouseProduct wareHouseProduct = _warehouseproducts[(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[2].Value))];//prodotto
                InsertProductInformations insertProductInformations = new InsertProductInformations(wareHouseProduct, _isNewEditDelete);
                insertProductInformations.PopulateDictionaryRequested += SecondForm_PopulateDictionaryRequested;
                insertProductInformations.Show();
            }
        }

        private void RemoveProduct_Click(object sender, EventArgs e)
        {
            _isNewEditDelete = IsNewEditCopyDeleteEnum.Delete;
            if (LoadMerchDGV.SelectedRows.Count.Equals(1))
            {
                DialogResult dialogResult = MessageBox.Show("Sei sicuro di voler cancellare l'elemento selezionato?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult.Equals(DialogResult.Yes))
                {
                    _warehouseproducts.Remove((Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[0].Value), Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[2].Value)));
                    LoadMerchDGV.Rows.Remove(LoadMerchDGV.SelectedRows[0]);
                }
            }
        }

        

        private void LoadMerchDGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LoadMerchDGV.SelectedRows[0].Index != -1)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void LoadMerchDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(LoadMerchDGV_KeyPress);
        }

        private void LoadMerchDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int cellValue = Convert.ToInt32(LoadMerchDGV.Rows[row].Cells[6].Value);
            WareHouseProduct warehouseProduct = _warehouseproducts[(Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[0].Value), Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[2].Value))];

            if (cellValue != warehouseProduct.Stock)
            {
                if (cellValue > 0)
                {
                    _warehouseproducts[(Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[0].Value), Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[2].Value))].Stock = cellValue;
                }

                else
                {
                    MessageBox.Show("Non puoi inserire una quantità uguale o inferiore a \"zero\"", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadMerchDGV.Rows[row].Cells[6].Value = _warehouseproducts[(Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[0].Value), Convert.ToInt32(LoadMerchDGV.SelectedRows[0].Cells[2].Value))].Stock;
                }
            }
        }
    }
}
