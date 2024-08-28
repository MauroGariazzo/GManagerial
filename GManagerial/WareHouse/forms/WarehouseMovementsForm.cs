using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GManagerial.DBConnectors;
using GManagerial.WareHouse.LoadMerch;
using GManagerial.WareHouse.models;
using GManagerial.Products;
using GManagerial.WareHouse.models.Movements;
using GManagerial.Attachments;
using GManagerial.RowLogic;
using GManagerial.WareHouse.ChildForms;
using System.Collections;
using GManagerial.EnumUtilities;
using static GManagerial.EnumUtilities.ManageMonths;

namespace GManagerial.WareHouse
{
    public delegate void OnWareHouseLoad();
    public partial class WarehouseMovementsForm : Form
    {
        private DBConnector _dbConnector;
        private DAOWareHouse _daoWareHouse;
        private Dictionary<int, Warehouse> _warehouses;
        private Dictionary<int, DetailsMovement> _detailsMovement;
        private DAODetailsMovement _daoDetailsMovement;
        private DAOMovement _daoMovement;
        private Dictionary<int,Movement> _movements;
        private DAOAttachments _daoAttachment;
        private DAOObjectAttachments _daoObjectAttachments;
        private Movement _movement;
        internal IsNewEditCopyDeleteEnum _isNewEditCopyDelete;
        private int _selectedRow = 0;
        private RowLogic.RowLogic _rowLogic;


        public WarehouseMovementsForm()
        {
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._daoWareHouse = new DAOWareHouse(this._dbConnector);
            this._detailsMovement = new Dictionary<int, DetailsMovement>();
            this._warehouses = new Dictionary<int, Warehouse>();
            this._movements = new Dictionary<int,Movement>();
            this._daoDetailsMovement = new DAODetailsMovement(this._dbConnector);
            this._daoMovement = new DAOMovement(this._dbConnector);
            this._daoAttachment = new DAOAttachments(this._dbConnector, AttachmentQuery.INSERT_ATTACHMENT, AttachmentQuery.DELETE_ATTACHMENT);
            this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector, AttachmentQuery.SELECT_WH_MOVEMENT, AttachmentQuery.INSERT_WH_MOVEMENT, AttachmentQuery.DELETE_WH_MOVEMENT);
            InitializeComponent();
            this._rowLogic = new RowLogic.RowLogic(WareHouseMovementsDGV);
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            LoadWarehouseMovements();
            OnUpdateWareHouses(); //popolare la combobox

            try
            {
                SelectWarehouseCB.SelectedIndex = Properties.Settings.Default.LastSelectedWarehouseId; //ultimo magazzino selezionato
                LoadTreeView();
            }

            catch 
            {
                MessageBox.Show("Seleziona o crea un magazzino", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadSerarchPanel();
        }

        private void LoadSerarchPanel()
        {
            LoadSearchPanelYears();
            LoadSearchPanelMonths();
            LoadSearchMovements();
        }

        private void LoadWarehouseMovements()
        {
            Warehouse warehouse = SelectWarehouseCB.SelectedItem as Warehouse;

            if (!(warehouse is null))
            {
                _movements = _daoMovement.GetAll(warehouse);
                UpdateDataGridView(_movements);
            }
        }

        private void UpdateDataGridView(Dictionary<int,Movement>movements)
        {
            WareHouseMovementsDGV.Rows.Clear();
            foreach (Movement movement in movements.Values)
            {
                int rowIndex = WareHouseMovementsDGV.Rows.Add();
                WareHouseMovementsDGV.Rows[rowIndex].Cells[0].Value = movement.ID;
                WareHouseMovementsDGV.Rows[rowIndex].Cells[1].Value = movement.MovementType;
                WareHouseMovementsDGV.Rows[rowIndex].Cells[2].Value = movement.Causal;
                WareHouseMovementsDGV.Rows[rowIndex].Cells[3].Value = Convert.ToString(movement.DateMovement);
                //WareHouseMovementsDGV.Rows[rowIndex].Cells[3].Value = Convert.ToString(movement.DateMovement).Substring(0, 10);                    
            }
        }

        private void OnUpdateWareHouses() //popolare la combobox
        {
            _warehouses = _daoWareHouse.GetAll();
            SelectWarehouseCB.Items.Clear();
            foreach (Warehouse wareHouse in _warehouses.Values)
            {
                SelectWarehouseCB.Items.Add(wareHouse);
            }
            SelectWarehouseCB.DisplayMember = "Warehouse_Name";
        }


        private void LoadMerchItem_Click(object sender, EventArgs e)
        {
            if (SelectWarehouseCB.SelectedItem != null)
            {
                Warehouse warehouse = (Warehouse)SelectWarehouseCB.SelectedItem;
                LoadMerchForm loadMerchForm = new LoadMerchForm(warehouse);
                loadMerchForm.PopulateDataGridView += Warehouse_Load;
                loadMerchForm.Owner = this;
                loadMerchForm.Show();
            }

            else
            {
                MessageBox.Show("Seleziona prima un magazzino", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void newBtn_MouseDown(object sender, MouseEventArgs e)
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


        private void selectWarehouseCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastSelectedWarehouseId = SelectWarehouseCB.SelectedIndex;
            Properties.Settings.Default.Save();
            LoadWarehouseMovements();
            LoadTreeView();
        }


        private void deleteItem_Click(object sender, EventArgs e)
        {

        }

        private void CreateWareHouseBtn_Click(object sender, EventArgs e)
        {
            CreateWareHouse newWH = new CreateWareHouse(SelectWarehouseCB);
            newWH.ShowDialog();
            Warehouse_Load(sender, e);
        }

        private void WareHouseDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            selectAllRows.Location = new Point(WareHouseMovementsDGV.Columns[0].Width / 2 - 32, selectAllRows.Location.Y);
        }

        private void selectAllRows_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllRows.Checked)
            {
                WareHouseMovementsDGV.SelectAll();
            }

            else
            {
                WareHouseMovementsDGV.ClearSelection();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (WareHouseMovementsDGV.SelectedRows.Count > 0)
            {
                _movement = new Movement();
                _movement = _movements[Convert.ToInt32(WareHouseMovementsDGV.SelectedRows[0].Cells[0].Value)];

                _movement.TempAttachments = new Dictionary<int, IAttachment>();
                _movement.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _movement.Attachments = _daoObjectAttachments.GetAll(Convert.ToInt32(WareHouseMovementsDGV.SelectedRows[0].Cells[0].Value));

                Attachemnts.Visible = true;
                confirmBtn.Visible = true;
                cancelBtn.Visible = true;
            }
        }

        private void ExpandTreeNode()
        {
            MovementDetailsTV.ExpandAll();
        }

        private void AddMessage()
        {
            /*Label noProductFound = new Label();
            noProductFound.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            noProductFound.AutoSize = true;
            noProductFound.ForeColor = Color.Red;
            noProductFound.Text = " \"Nessun prodotto\":";
            MovementDetailsTV.Controls.Add(noProductFound);
            noProductFound.Location = new System.Drawing.Point(9, 450);

            Label description = new Label();
            description.AutoSize = true;
            description.Text = "Il prodotto cercato è stato eliminato o non è più disponibile.";
            MovementDetailsTV.Controls.Add(description);
            description.Location = new System.Drawing.Point(110, 450);*/
        }

        private void TransferDataFromDictionariesToTreeViewControl()
        {
            if (_detailsMovement.Count > 0)
            {
                foreach (DetailsMovement detailsMovement in _detailsMovement.Values)
                {
                    TreeNode treeNode = new TreeNode();

                    if (detailsMovement.WarehouseproductProps.ID.Equals(0))
                    {
                        treeNode.NodeFont = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
                        treeNode.ForeColor = Color.Red;
                        AddMessage();
                    }

                    else
                    {
                        MovementDetailsTV.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    }

                    treeNode.ImageIndex = 2;
                    treeNode.Text = detailsMovement.WarehouseproductProps.ProductName;
                    MovementDetailsTV.Nodes.Add(treeNode);

                    TreeNode childNode = new TreeNode();

                    if (WareHouseMovementsDGV.SelectedRows[0].Cells[1].Value.ToString() == "Carico")
                    {
                        childNode.ImageIndex = 0;
                        childNode.Text = $"Carico: (+{detailsMovement.Quantity})";
                        treeNode.Nodes.Add(childNode);
                    }

                    else
                    {
                        childNode.ImageIndex = 1;
                        childNode.Text = $"Scarico: (-{detailsMovement.Quantity})";
                        treeNode.Nodes.Add(childNode);
                    }
                }
            }

            else
            {
                TreeNode treeNode = new TreeNode();
                treeNode.ImageIndex = 1;
                treeNode.Text = "(nessun prodotto)";
                MovementDetailsTV.Nodes.Add(treeNode);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (WareHouseMovementsDGV.RowCount > 0 && WareHouseMovementsDGV.SelectedRows.Count > 0)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Delete;
                _selectedRow = WareHouseMovementsDGV.SelectedRows[0].Index;

                CheckUserChoice();
                LoadTreeView();
            }

            if (selectAllRows.Checked)
            {
                selectAllRows.Checked = false;
            }
        }

        private void CheckUserChoice() //controllare se l'utente è sicuro di voler cancellare la riga o le righe selezionate
        {
            if (WareHouseMovementsDGV.SelectedRows.Count > 0)
            {
                DialogResult firstDialog = MessageBox.Show("Attenzione, la cancellazione di uno più movimenti non ripristinerà le giacenze a magazzino.\n\nVuoi proseguire?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (firstDialog == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in WareHouseMovementsDGV.SelectedRows)
                    {
                        _movement = new Movement();
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
            LoadWarehouseMovements();

            if (WareHouseMovementsDGV.Rows.Count > 0)
            {
                WareHouseMovementsDGV.ClearSelection();
                WareHouseMovementsDGV.Rows[row].Selected = true;
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            GetButtonsInvisibile();
            SendAttachmentsToDB();
            DeleteAttachments();
        }


        private void SendAttachmentsToDB()
        {
            // int idMovement = Convert.ToInt32(WareHouseMovementsDGV.Rows[0].Cells[0].Value);
            //_movement = _movements[idMovement];

            foreach (Attachment attachment in _movement.TempAttachments.Values)
            {
                int id_attachment = _daoAttachment.Insert(attachment);
                _daoObjectAttachments.Insert(_movement.ID, id_attachment);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Sei sicuro di voler annullare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog.Equals(DialogResult.Yes))
            {
                GetButtonsInvisibile();
                selectAllRows.Checked = false;
                AttachmentForm.TempID = -1;
            }
        }

        private void DeleteAttachments()
        {
            foreach (Attachment attachment in _movement.AttachmentsToDelete.Values)
            {
                _daoObjectAttachments.Delete(attachment, attachment.ObjectID); //cancella gli allegati dalla tabella product_attachment
                _daoAttachment.Delete(attachment); //cancella gli allegati dalla tabella attachments
            }
        }


        private void GetButtonsInvisibile()
        {
            confirmBtn.Visible = false;
            cancelBtn.Visible = false;
            Attachemnts.Visible = false;
        }
        private void uStockTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void WHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateWareHouse newWH = new CreateWareHouse(SelectWarehouseCB);
            newWH.Owner = this;
            newWH.Show();

            Warehouse_Load(sender, e);
        }

        private void UnloadMerchItem_Click(object sender, EventArgs e)
        {
            if (SelectWarehouseCB.SelectedItem != null)
            {
                Warehouse warehouse = (Warehouse)SelectWarehouseCB.SelectedItem;
                UnloadMerchForm unloadMerchForm = new UnloadMerchForm(warehouse);
                unloadMerchForm.PopulateDataGridView += Warehouse_Load;
                unloadMerchForm.Owner = this;
                unloadMerchForm.Show();
            }

            else
            {
                MessageBox.Show("Seleziona prima un magazzino", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WareHouseMovementsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadTreeView();
        }

        private void LoadTreeView()
        {
            //CheckIfSelectedWarehouseIsNull(); //controllo che ho dovuto aggiungere in base a SelectWarehouseCB che a volte diventa null, ma non ho capito il motivo
            MovementDetailsTV.Nodes.Clear();
            if (WareHouseMovementsDGV.Rows.Count > 0)
            {
                MovementDetailsTV.Nodes.Clear();

                Warehouse warehouse = SelectWarehouseCB.SelectedItem as Warehouse;
                _movement = new Movement();
                _movement.ID = Convert.ToInt32(WareHouseMovementsDGV.SelectedRows[0].Cells[0].Value);

                _detailsMovement = _daoDetailsMovement.GetAll(warehouse, _movement);
                TransferDataFromDictionariesToTreeViewControl();
                ExpandTreeNode();

                TotPieces.Text = Convert.ToString(_detailsMovement.Values.Sum(mov => mov.Quantity));
            }

            else
            {
                TotPieces.Text = "0";
            }
        }

        /*private void CheckIfSelectedWarehouseIsNull()
        {
            if(SelectWarehouseCB.SelectedItem is null)
            {
                SelectWarehouseCB.SelectedIndex = Properties.Settings.Default.LastSelectedWarehouseId;
            }
        }*/
        private void WareHouseMovementsDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (WareHouseMovementsDGV.SelectedRows.Count > 0)
            {
                LoadTreeView();
            }
        }

        private void Attachemnts_Click(object sender, EventArgs e)
        {
            AttachmentForm attachmentForm = new AttachmentForm(_movement, _movement.ID);
            attachmentForm.ShowDialog();
        }

        private void MovementDetailsTV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent is null)
            {
                e.Node.SelectedImageIndex = 2;
            }
        }

        private void MovementDetailsTV_MouseHover(object sender, EventArgs e)
        {
            NoProductToolTip.Active = true;

            Point mousePosition = MovementDetailsTV.PointToClient(Cursor.Position);

            TreeNode nodeUnderMouse = MovementDetailsTV.GetNodeAt(mousePosition);

            if (nodeUnderMouse != null && nodeUnderMouse.Text.Equals("Nessun prodotto"))
            {
                NoProductToolTip.Show("Il prodotto cercato è stato eliminato o non è più disponibile.", MovementDetailsTV, mousePosition);
            }

            else
            {
                NoProductToolTip.Active = false;
            }
        }

        private void WareHouseMovementsDGV_MouseHover(object sender, EventArgs e)
        {
            MovementDetailsTV_MouseHover(sender, e);
        }

        private void AnagrPanel_MouseHover(object sender, EventArgs e)
        {
            MovementDetailsTV_MouseHover(sender, e);
        }

        private void MovementDetailsTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (MovementDetailsTV.SelectedNode != null)
            {
                if (MovementDetailsTV.SelectedNode.Text != "Carico" || MovementDetailsTV.SelectedNode.Text != "Scarico")
                {
                    MovementDetailsTV.SelectedNode.SelectedImageIndex = 2;
                }
            }
        }

        private void dateStartCB_Leave(object sender, EventArgs e)
        {
            if (IsValidDate(dateStartTB.Text))
            {
                if (IsValidDate(dateEndTB.Text))
                {
                    IsStartDateBeforeEndDate(dateStartTB);
                }
            }
        }

        private void dateEndCB_Leave(object sender, EventArgs e)
        {
            if (IsValidDate(dateStartTB.Text) && IsValidDate(dateEndTB.Text))
            {
                IsStartDateBeforeEndDate(dateEndTB);
            }
        }        
    }
}

