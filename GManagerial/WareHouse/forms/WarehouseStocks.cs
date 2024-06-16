using GManagerial.DBConnectors;
using GManagerial.WareHouse.models.WareHouseProducts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GManagerial.WareHouse.models;
using GManagerial.WareHouse.models.Movements;
using GManagerial.WareHouse.ChildForms;


namespace GManagerial.WareHouse
{
    public partial class WarehouseStocks : Form
    {
        private DBConnector _dbConnector;
        private DAOWarehouseProduct _daoWareHouseProduct;
        private DAOWareHouse _daoWarehouse;
        private Dictionary<int,WareHouseProduct> _wareHouseProducts = new Dictionary<int,WareHouseProduct>();
        private Dictionary<int, Warehouse> _warehouses = new Dictionary<int, Warehouse>();
        internal IsNewEditCopyDeleteEnum _isNewEditCopyDelete;
        private int _selectedRow = 0;

        public WarehouseStocks()
        {
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._daoWareHouseProduct = new DAOWarehouseProduct(_dbConnector);
            this._daoWarehouse = new DAOWareHouse(_dbConnector);            
            InitializeComponent();
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

            foreach(Warehouse warehouse in _warehouses.Values)
            {
                SelectWarehouseCB.Items.Add(warehouse);
            }

            SelectWarehouseCB.DisplayMember = "Warehouse_Name";

            try
            {
                SelectWarehouseCB.SelectedIndex = 0;
            }

            catch
            {
                MessageBox.Show("Seleziona o crea un magazzino","Attenzione",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateDataGridView()
        {
            _wareHouseProducts = _daoWareHouseProduct.GetAll(SelectWarehouseCB.SelectedItem as Warehouse);
            WareHouseStockDGV.Rows.Clear();

            foreach(WareHouseProduct wareHouseProduct in _wareHouseProducts.Values)
            {
                int rowIndex = WareHouseStockDGV.Rows.Add();
                WareHouseStockDGV.Rows[rowIndex].Cells[0].Value = wareHouseProduct.Id;
                WareHouseStockDGV.Rows[rowIndex].Cells[1].Value = wareHouseProduct.ProductProps.ProductName;
                WareHouseStockDGV.Rows[rowIndex].Cells[2].Value = wareHouseProduct.ProductProps.Description;
                WareHouseStockDGV.Rows[rowIndex].Cells[3].Value = wareHouseProduct.Stock;
                WareHouseStockDGV.Rows[rowIndex].Cells[6].Value = wareHouseProduct.ProductProps.ResizedImage;
            }
        }

        private void SelectWarehouseCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void NewOrder_Click(object sender, EventArgs e)
        {
            Warehouse warehouse= new Warehouse();
            warehouse = SelectWarehouseCB.SelectedItem as Warehouse;
            AddSupplier addSupplier = new AddSupplier(warehouse);            
            addSupplier.ShowDialog();
            UpdateDataGridView();
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
                DialogResult firstDialog = MessageBox.Show("Attenzione, la cancellazione di uno più movimenti non ripristinerà le giacenze a magazzino.\n\nVuoi proseguire?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (firstDialog == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in WareHouseStockDGV.SelectedRows)
                    {
                        WareHouseProduct wareHouseProduct = new WareHouseProduct();
                        int idWarehouseProduct = (int)row.Cells[0].Value;
                        wareHouseProduct = _wareHouseProducts[idWarehouseProduct];
                        /*_movement = new Movement();
                        int id_movement = (int)row.Cells[0].Value;
                        _movement = _movements[id_movement];

                        _movement.AttachmentsToDelete = _daoObjectAttachments.GetAll(id_movement); //tutti gli allegati
                                                                                                   //DELETE MOVEMENTS
                                                                                                   //_daoDetailsMovement.Delete(_product);

                        try
                        {
                            int rowSelectID = Convert.ToInt32(WareHouseMovementsDGV.SelectedRows[0].Cells[0].Value);
                            DeleteAttachments();
                            _daoDetailsMovement.Delete(rowSelectID);
                            _daoMovement.Delete(rowSelectID);

                            _rowLogic.RowToSelectInDataGridView(_isNewEditCopyDelete, _selectedRow);
                            SelectedRows(_isNewEditCopyDelete);
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }*/
                    }
                }
            }

            else
            {
                MessageBox.Show("Seleziona prima una riga da cancellare", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);// FORMLOGICGUI
            }
        }
    }
}
