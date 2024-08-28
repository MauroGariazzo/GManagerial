using GManagerial.DBConnectors;
using GManagerial.WareHouse.models.WareHouseProducts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GManagerial.WareHouse.models;
using GManagerial.WareHouse.models.Movements;
using GManagerial.WareHouse.ChildForms;
using GManagerial.Documents.OrderDocument.models;

namespace GManagerial.WareHouse
{
    public delegate void UpdateDataGridViewDelegate();
    public partial class WarehouseStocks : Form
    {
        private DBConnector _dbConnector;
        private DAOWarehouseProduct _daoWareHouseProduct;
        private DAOWareHouse _daoWarehouse;
        private Dictionary<int, WareHouseProduct> _wareHouseProducts = new Dictionary<int, WareHouseProduct>();
        private Dictionary<int, Warehouse> _warehouses = new Dictionary<int, Warehouse>();
        internal IsNewEditCopyDeleteEnum _isNewEditCopyDelete;
        private int _selectedRow = 0;
        private RowLogic.RowLogic _rowLogic;

        public WarehouseStocks()
        {
            InitializeComponent();
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._daoWareHouseProduct = new DAOWarehouseProduct(_dbConnector);
            this._daoWarehouse = new DAOWareHouse(_dbConnector);
            this._rowLogic = new RowLogic.RowLogic(WareHouseStockDGV);
        }

        private void WarehouseStocks_Load(object sender, EventArgs e)
        {
            LoadWareHouses();
            UpdateDataGridView();
        }

        private void LoadWareHouses()
        {
            SelectWarehouseCB.Items.Clear();
            _warehouses = _daoWarehouse.GetAll();

            foreach (Warehouse warehouse in _warehouses.Values)
            {
                SelectWarehouseCB.Items.Add(warehouse);
            }

            SelectWarehouseCB.DisplayMember = "Warehouse_Name";

            try
            {
                //SelectWarehouseCB.SelectedIndex = 0;
                SelectWarehouseCB.SelectedIndex = Properties.Settings.Default.LastSelectedWarehouseId;
            }

            catch
            {
                MessageBox.Show("Seleziona o crea un magazzino", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateDataGridView()
        {
            if (SelectWarehouseCB.SelectedItem != null)
            {
                _wareHouseProducts = _daoWareHouseProduct.GetAll(SelectWarehouseCB.SelectedItem as Warehouse);
                WareHouseStockDGV.Rows.Clear();

                foreach (WareHouseProduct wareHouseProduct in _wareHouseProducts.Values)
                {
                    int rowIndex = WareHouseStockDGV.Rows.Add();
                    WareHouseStockDGV.Rows[rowIndex].Cells[0].Value = wareHouseProduct.Id;
                    WareHouseStockDGV.Rows[rowIndex].Cells[1].Value = wareHouseProduct.ProductName;
                    WareHouseStockDGV.Rows[rowIndex].Cells[2].Value = wareHouseProduct.Description;
                    WareHouseStockDGV.Rows[rowIndex].Cells[3].Value = wareHouseProduct.Stock;
                    WareHouseStockDGV.Rows[rowIndex].Cells[6].Value = wareHouseProduct.ResizedImage;
                }
            }
        }

        private void SelectWarehouseCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();

            Warehouse warehouse = new Warehouse();
            warehouse = SelectWarehouseCB.SelectedItem as Warehouse;
            AddSupplier addSupplier = new AddSupplier(order, warehouse, UpdateDataGridView);
            addSupplier.Owner = this;
            addSupplier.Show();
            //UpdateDataGridView();
        }

        private void NewBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToolStripButton button = sender as ToolStripButton;
                if (button != null && button.Owner is ToolStrip toolStrip && toolStrip.Parent is Control parentControl)
                {
                    Point buttonLocationOnScreen = button.Owner.PointToScreen(button.Bounds.Location);    //ottiene le coordinate del pulsante button rispetto allo schermo
                    Point buttonLocationOnParentControl = parentControl.PointToClient(buttonLocationOnScreen);  //ottiene le coordinate del pulsante button rispetto al contenitore(form)

                    buttonLocationOnParentControl.Y += button.Height;
                    newBtnCMS.Show(parentControl, buttonLocationOnParentControl, ToolStripDropDownDirection.BelowRight);
                }
            }
        }

        private void selectAllRows_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllRows.Checked)
            {
                WareHouseStockDGV.SelectAll();
            }

            else
            {
                WareHouseStockDGV.ClearSelection();
            }
        }

        /*DA RIVERIFICARE PERCHé SE SI CANCELLA UN PRODOTTO DAL MAGAZZINO CI POSSONO ESSERE MOVIMENTI CON QUEL PRODOTTO ABBINATO O DOCUMENTI*/
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (WareHouseStockDGV.RowCount > 0 && WareHouseStockDGV.SelectedRows.Count > 0)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Delete;
                _selectedRow = WareHouseStockDGV.SelectedRows[0].Index;

                CheckUserChoice();
            }

            if (selectAllRows.Checked)
            {
                selectAllRows.Checked = false;
            }
        }

        private void CheckUserChoice() //controllare se l'utente è sicuro di voler cancellare la riga o le righe selezionate
        {
            if (WareHouseStockDGV.SelectedRows.Count > 0)
            {
                DialogResult firstDialog = MessageBox.Show("Sei sicuro di voler cancellare questo prodotto da magazzino", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (firstDialog == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in WareHouseStockDGV.SelectedRows)
                    {
                        WareHouseProduct wareHouseProduct = new WareHouseProduct();
                        int idWarehouseProduct = (int)row.Cells[0].Value;
                        wareHouseProduct = _wareHouseProducts[idWarehouseProduct];   

                        try
                        {
                            int rowSelectID = Convert.ToInt32(WareHouseStockDGV.SelectedRows[0].Cells[0].Value);
                            Warehouse wareHouse = SelectWarehouseCB.SelectedItem as Warehouse;
                            _daoWareHouseProduct.Delete(wareHouse, wareHouseProduct);
                            //_daoMovement.Delete(rowSelectID);

                            _rowLogic.RowToSelectInDataGridView(_isNewEditCopyDelete, _selectedRow);
                            SelectedRows(_isNewEditCopyDelete);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Seleziona prima una riga da cancellare", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);// FORMLOGICGUI
            }
        }

        private void SelectedRows(IsNewEditCopyDeleteEnum command) //per cancellazione
        {
            int row = _rowLogic.RowToSelectInDataGridView(command, _selectedRow);
            UpdateDataGridView();

            if (WareHouseStockDGV.Rows.Count > 0)
            {
                WareHouseStockDGV.ClearSelection();
                WareHouseStockDGV.Rows[row].Selected = true;
            }
        }

        private void CreateWareHouseBtn_Click(object sender, EventArgs e)
        {
            //CreateWareHouseBtn_Click(sender, e);
            CreateWareHouse newWH = new CreateWareHouse(SelectWarehouseCB);
            newWH.ShowDialog();
            WarehouseStocks_Load(sender, e);
        }
    }
}
