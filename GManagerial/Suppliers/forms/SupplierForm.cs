using GManagerial.Geo.models;
using GManagerial.DBConnectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GManagerial.Attachments;
using GManagerial.Products;
using GeoAPI.IO;
using GManagerial.Products.ChildForms;


namespace GManagerial
{
    public partial class SupplierForm : Form
    {
        public IsNewEditCopyDeleteEnum _isNewEditCopyDelete;

        private IDBConnector _dbConnector;
        private DAOSupplier _daoSupplier;
        private Dictionary<int, Supplier> _suppliers;

        private List<string> _regions;
        private Dictionary<string, string> _provinces;
        private List<string> _cities;

        private DAOGeo _daoGeo;
        private FormLogicGUI _formLogicGUI;
        private System.Windows.Forms.Button[] _buttonList;
        private System.Windows.Forms.TextBox[] _textboxes;
        private System.Windows.Forms.ComboBox[] _comboboxes;
        private Supplier _supplier;
        private DAOAttachments _daoAttachment;
        private DAOObjectAttachments _daoObjectAttachments;
        private RowLogic.RowLogic _rowLogic;
        private AttachmentForm _attachmentForm;
        private int _selectedRow;

        public SupplierForm()
        {
            InitializeComponent();
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._daoSupplier = new DAOSupplier(_dbConnector);
            this._suppliers = new Dictionary<int, Supplier>();
            this._regions = new List<string>();
            this._daoGeo = new DAOGeo(_dbConnector);
            this._formLogicGUI = new FormLogicGUI();

            this._buttonList = new System.Windows.Forms.Button[] { ConfirmBtn, CancelBtn, AttachmentsBtn, DocsButton };
            this._textboxes = new System.Windows.Forms.TextBox[] {SupplierNamePanelTB, IdTaxPanelTB, VatPanelTB, RecipientCodePanelTB, TelephonePanelTB, MobilePanelTB, MailPanelTB, PecPanelTB, NotesPanelTB,};
            this._comboboxes = new System.Windows.Forms.ComboBox[] { RegionPanelCB, ProvincePanelCB, CityPanelCB };
            this._daoAttachment = new DAOAttachments(_dbConnector,AttachmentQuery.INSERT_ATTACHMENT,AttachmentQuery.DELETE_ATTACHMENT);
            this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector,AttachmentQuery.SELECT_SUPPLIER, AttachmentQuery.INSERT_SUPPLIER, AttachmentQuery.DELETE_SUPPLIER);
            this._rowLogic = new RowLogic.RowLogic(SupplierDGV);
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            LoadRegions();
        }

        private void UpdateDataGridView()
        {
            SupplierDGV.Rows.Clear();
            _suppliers = _daoSupplier.GetAll();
            DataGridViewPopulateFromDictionary();
        }

        private void UpdateDataGridViewFilter()//delegate?
        {
            SupplierDGV.Rows.Clear();
            DataGridViewPopulateFromDictionary();
        }

        private void DataGridViewPopulateFromDictionary()
        {
            foreach (var couple in _suppliers)
            {
                if(couple.Key == 1)
                {
                    continue;
                }
                //riga
                int rowIndex = SupplierDGV.Rows.Add();

                //colonne
                SupplierDGV.Rows[rowIndex].Cells[0].Value = couple.Key;
                SupplierDGV.Rows[rowIndex].Cells[1].Value = couple.Value.SupplierName;
                SupplierDGV.Rows[rowIndex].Cells[2].Value = couple.Value.Region;
                SupplierDGV.Rows[rowIndex].Cells[3].Value = couple.Value.Province;
                SupplierDGV.Rows[rowIndex].Cells[4].Value = couple.Value.City;
                SupplierDGV.Rows[rowIndex].Cells[5].Value = couple.Value.Address;
                SupplierDGV.Rows[rowIndex].Cells[6].Value = couple.Value.Telephone;
            }
        }

        private void LoadRegions()
        {
            _regions = _daoGeo.GetRegions();
            foreach (string region in _regions)
            {
                RegionPanelCB.Items.Add(region);
                RegionPanelSearchCB.Items.Add(region);
            }
        }
        private void newBtn_Click(object sender, EventArgs e)
        {
            _formLogicGUI.NewEditCopyButtonEnable(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, SupplierDGV);

            _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.New;


            if(SupplierDGV.SelectedRows.Count > 0)
            {
                _selectedRow = SupplierDGV.SelectedRows[0].Index;
            }
            
            _supplier = new Supplier();

            _supplier.Attachments = new Dictionary<int, IAttachment>();
            _supplier.TempAttachments = new Dictionary<int, IAttachment>();
            _supplier.AttachmentsToDelete = new Dictionary<int, IAttachment>();
        }


        private void editBtn_Click(object sender, EventArgs e)
        {
            if (SupplierDGV.SelectedRows.Count == 1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Edit;
                _selectedRow = SupplierDGV.SelectedRows[0].Index;

                int id = (int)SupplierDGV.SelectedRows[0].Cells[0].Value;

                _supplier = new Supplier();
                _supplier = _suppliers[id];

                _supplier.TempAttachments = new Dictionary<int, IAttachment>();
                _supplier.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _supplier.Attachments = _daoObjectAttachments.GetAll(id);

                TransferDataFromDictionariesToPanelControls();
                _formLogicGUI.NewEditCopyButtonEnable(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, SupplierDGV);
            }

            else if (SupplierDGV.SelectedRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                _formLogicGUI.SelectElement("fornitore");
            }
        }

        private void TransferDataFromDictionariesToPanelControls()
        {
            SupplierNamePanelTB.Text = _supplier.SupplierName;
            IdTaxPanelTB.Text = _supplier.IdTax;
            VatPanelTB.Text = _supplier.Vat;
            RecipientCodePanelTB.Text = _supplier.RecipientCode;
            RegionPanelCB.Text = _supplier.Region;
            ProvincePanelCB.Text = _supplier.Province;
            ProvinceSigleTB.Text = _supplier.ProvinceSigle;
            CityPanelCB.Text = _supplier.City;
            ZipCodePanelTB.Text = _supplier.ZipCode;
            AddressPanelTB.Text = _supplier.Address;
            TelephonePanelTB.Text = _supplier.Telephone;
            MobilePanelTB.Text = _supplier.Mobile;
            MailPanelTB.Text = _supplier.Email;
            PecPanelTB.Text = _supplier.Pec;
            NotesPanelTB.Text = _supplier.Notes;
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (SupplierDGV.SelectedRows.Count == 1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Copy;
                _selectedRow = SupplierDGV.SelectedRows[0].Index;

                _supplier = new Supplier();
                int id = (int)SupplierDGV.SelectedRows[0].Cells[0].Value;
                _supplier = _suppliers[id];

                _supplier.TempAttachments = new Dictionary<int, IAttachment>();
                _supplier.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _supplier.Attachments = _daoObjectAttachments.GetAll(id);

                _formLogicGUI = new FormLogicGUI();
                TransferDataFromDictionariesToPanelControls();
                _formLogicGUI.NewEditCopyButtonEnable(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, SupplierDGV);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (SupplierDGV.RowCount > 0 && SupplierDGV.SelectedRows.Count > 0)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Delete;

                _selectedRow = SupplierDGV.SelectedRows[0].Index;
                CheckUserChoice();
            }

            if (SelectAllRows.Checked)
            {
                SelectAllRows.Checked = false;
            }
        }

        private void CheckUserChoice() //controllare se l'utente è sicuro di voler cancellare la riga o le righe selezionate
        {
            if (SupplierDGV.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Sei sicuro di voler cancellare l'elemento selezionato?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in SupplierDGV.SelectedRows)
                    {
                        _supplier = new Supplier();
                        int id_supplier = (int)row.Cells[0].Value;
                        _supplier = _suppliers[id_supplier];

                        _supplier.AttachmentsToDelete = _daoObjectAttachments.GetAll(id_supplier); //tutti gli allegati
                        DeleteAttachments();
                        _daoSupplier.Delete(_supplier, SupplierQueries.DELETEPRODUCTSUPPLIER);
                        _daoSupplier.Delete(_supplier, SupplierQueries.DELETESUPPLIERPRICES);
                        DeleteSupplier(id_supplier);

                        _rowLogic.RowToSelectInDataGridView(_isNewEditCopyDelete, _selectedRow);
                        SelectedRows(_isNewEditCopyDelete);
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

            if (SupplierDGV.Rows.Count > 0)
            {
                SupplierDGV.ClearSelection();
                SupplierDGV.Rows[row].Selected = true;
            }
        }


        private void DeleteAttachments()
        {
            foreach (Attachment attachment in _supplier.AttachmentsToDelete.Values)
            {
                _daoObjectAttachments.Delete(attachment, attachment.ObjectID); //cancella gli allegati dalla tabella product_attachment
                _daoAttachment.Delete(attachment); //cancella gli allegati dalla tabella attachments
            }
        }

        private void DeleteSupplier(int id_supplier)
        {
            _supplier = _suppliers[id_supplier];
            _daoSupplier.Delete(_supplier, SupplierQueries.DELETEPRODUCTSUPPLIER);
            _daoSupplier.Delete(_supplier, SupplierQueries.DELETESUPPLIER);
            _suppliers.Remove(id_supplier);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (DataPanelValidate())
            {
                int id_supplier; //id per recuperare l'ultima riga inserita

                if (_isNewEditCopyDelete == IsNewEditCopyDeleteEnum.New || _isNewEditCopyDelete == IsNewEditCopyDeleteEnum.Copy) // _newEditCopyDelete == 'n' || _newEditCopyDelete == 'c'
                {
                    id_supplier = _daoSupplier.Insert(_supplier); //nuovo inserimento recupero l'id direttamente dalla query
                    if(id_supplier.Equals(0))
                    {
                        MessageBox.Show("Esiste già un fornitore con questo nome", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                else
                {
                    _daoSupplier.Update(_supplier); //l'id ce l'ho già, perché sto cercando di modificare un prodotto già esistente
                    id_supplier = _supplier.ID;
                }


                foreach (Attachment attachment in _supplier.TempAttachments.Values)
                {
                    int id_attachment = _daoAttachment.Insert(attachment);
                    _daoObjectAttachments.Insert(id_supplier, id_attachment);
                }

                AttachmentForm.TempID = -1; //risetto la variabile TempID che mi serviva per gli allegati temporanei
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, SupplierDGV);

                UpdateDataGridView();
                DeleteFilterSearchBtn_Click(sender, e);//azzera tutti i filtri di ricerca
                SelectedRows(_isNewEditCopyDelete);
            }
        }

        public bool DataPanelValidate()
        {
            try
            {
                _supplier.SupplierName = SupplierNamePanelTB.Text;
                _supplier.IdTax = IdTaxPanelTB.Text;
                _supplier.Vat = VatPanelTB.Text;
                _supplier.Email = MailPanelTB.Text;
                _supplier.Region = RegionPanelCB.Text;
                _supplier.Province = ProvincePanelCB.Text;
                _supplier.ProvinceSigle = ProvinceSigleTB.Text;
                _supplier.City = CityPanelCB.Text;
                _supplier.Pec = PecPanelTB.Text;
                _supplier.Telephone = TelephonePanelTB.Text;
                _supplier.Mobile = MobilePanelTB.Text;
                _supplier.Address = AddressPanelTB.Text;
                _supplier.RecipientCode = RecipientCodePanelTB.Text;
                _supplier.ZipCode = ZipCodePanelTB.Text;
                _supplier.Notes = NotesPanelTB.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (_formLogicGUI.PrintCancelEdit())
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Cancel;
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, SupplierDGV);
                DeleteFilterSearchBtn_Click(sender, e);//azzera tutti i filtri di ricerca
                SelectedRows(_isNewEditCopyDelete);
            }

            SelectAllRows.Checked = false;
            AttachmentForm.TempID = -1;
        }


        private void whatsappChat_Click(object sender, EventArgs e)
        {
            WMCLink.whatsappChat_Click(MobilePanelTB);
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            WMCLink.mailBtn_Click(MailPanelTB);
        }

        private void phoneBtn_Click(object sender, EventArgs e)
        {
            WMCLink.phoneBtn_Click(TelephonePanelTB);
        }

        private void LoadProvinces(string region)
        {
            ProvincePanelCB.Items.Clear();
            ProvincePanelSearchCB.Items.Clear();
            _provinces = _daoGeo.GetProvinces(region);
            foreach(KeyValuePair< string,string> couple in _provinces)
            {
                ProvincePanelCB.Items.Add(couple.Key);
                ProvincePanelSearchCB.Items.Add(couple.Key);
                //ProvinceSigleTB.Text = couple.Value;
            }
        }

        private void regionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RegionPanelCB.SelectedItem != null && RegionPanelCB.Text != string.Empty)
            {
                _formLogicGUI.EnableComboBox(new[] { ProvincePanelCB });
                _formLogicGUI.EnableLabel(new[] { ProvincePanelLBL });

                _formLogicGUI.CleanComboBox(new[] { CityPanelCB });
                _formLogicGUI.DisableComboBox(new[] { CityPanelCB });
                _formLogicGUI.DisableLabel(new[] { CityPanelLBL, AddressPanelLBL, ZipCodePanelLBL });

                _formLogicGUI.CleanTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableTextBox(new[] { AddressPanelTB, ZipCodePanelTB });


                string region = RegionPanelCB.Text;
                LoadProvinces(region);

            }

            else
            {
                _formLogicGUI.CleanComboBox(new[] { ProvincePanelCB, CityPanelCB });
                _formLogicGUI.CleanTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableComboBox(new[] { ProvincePanelCB, CityPanelCB });
                _formLogicGUI.DisableLabel(new[] { ProvincePanelLBL, CityPanelLBL, AddressPanelLBL, ZipCodePanelLBL });
                _formLogicGUI.DisableTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
            }
        }

        private void provBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvincePanelCB.SelectedItem != null && ProvincePanelCB.Text != string.Empty)
            {
                _formLogicGUI.EnableComboBox(new[] { CityPanelCB });
                _formLogicGUI.EnableLabel(new[] { CityPanelLBL });

                string province = ProvincePanelCB.Text;
                ProvinceSigleTB.Text = _provinces[province];
                LoadCities(province);
            }

            else
            {
                _formLogicGUI.CleanComboBox(new[] { CityPanelCB });
                _formLogicGUI.CleanTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableComboBox(new[] { CityPanelCB });
                _formLogicGUI.DisableTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableLabel(new[] { AddressPanelLBL, CityPanelLBL, ZipCodePanelLBL });
                ProvinceSigleTB.Text = string.Empty;
            }
        }

        private void LoadCities(string province)
        {
            CityPanelCB.Items.Clear();
            CityPanelSearchCB.Items.Clear();

            _cities = _daoGeo.GetCities(province);

            foreach (string city in _cities)
            {
                CityPanelCB.Items.Add(city);
                CityPanelSearchCB.Items.Add(city);
            }
        }

        private void AttachmentsBtn_Click(object sender, EventArgs e)
        {
            _attachmentForm = new AttachmentForm((Supplier)_supplier, _supplier.ID);
            _attachmentForm.ShowDialog();
        }

        private void selectAllRows_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllRows.Checked)
            {
                SupplierDGV.SelectAll();
            }

            else
            {
                SupplierDGV.ClearSelection();
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (SearchTB.Text.Equals("Cerca"))
            {
                SetTextForSearchBox();

            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (SearchTB.Text.Equals(string.Empty))
            {
                ResetStandardTextForSearchBox();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (!SearchTB.Text.Equals("Cerca") && SearchTB.Font.FontFamily.Name != "Times New Roman")
            {
                SearchSupplier();
            }
        }

        private void SearchSupplier()
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

            if (RegionPanelSearchCB.SelectedItem is null && ProvincePanelSearchCB.SelectedItem is null && CityPanelSearchCB.SelectedItem is null)
            {
                _suppliers = _daoSupplier.GetSuppliersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, SupplierQueries.SEARCHSUPPLIER);
            }

            else if (!(RegionPanelSearchCB.SelectedItem is null) && ProvincePanelSearchCB.SelectedItem is null && CityPanelSearchCB.SelectedItem is null)
            {
                _suppliers = _daoSupplier.GetSuppliersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, SupplierQueries.SEARCHSUPPLIERWITHREGION);

            }

            else if (!(RegionPanelSearchCB.SelectedItem is null && ProvincePanelSearchCB.SelectedItem is null) && CityPanelSearchCB.SelectedItem is null)
            {
                _suppliers = _daoSupplier.GetSuppliersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, SupplierQueries.SEARCHSUPPLIERWITHREGIONANDPROVINCE);
            }

            else if (!(RegionPanelSearchCB.SelectedItem is null && ProvincePanelSearchCB.SelectedItem is null && CityPanelSearchCB.SelectedItem is null))
            {
                _suppliers = _daoSupplier.GetSuppliersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, SupplierQueries.SEARCHSUPPLIERWITHREGIONPROVINCEANDCITY);
            }

            /*else if (!(RegionPanelSearchCB.SelectedItem is null) && ProvincePanelSearchCB.SelectedItem is null && !(CityPanelSearchCB.SelectedItem is null))
            {
                _suppliers = _daoSupplier.GetSuppliersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, SupplierQueries.SEARCHSUPPLIERWITHREGIONANDCITY);
            }*/

            UpdateDataGridViewFilter();
        }
        private void SupplierDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SelectAllRows.Location = new Point(SupplierDGV.Columns[0].Width / 2 - 5, SelectAllRows.Location.Y);
        }

        private void regionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RegionPanelSearchCB.SelectedItem != null && RegionPanelSearchCB.Text != string.Empty)
            {
                _formLogicGUI.EnableComboBox(new[] { ProvincePanelSearchCB });
                _formLogicGUI.EnableLabel(new[] { ProvincePanelSearchLbl });

                _formLogicGUI.CleanComboBox(new[] { CityPanelSearchCB });
                _formLogicGUI.DisableComboBox(new[] { CityPanelSearchCB });
                _formLogicGUI.DisableLabel(new[] { CityPanelSearchLbl });

                string region = RegionPanelSearchCB.Text;
                LoadProvinces(region);
            }

            else
            {
                RegionPanelSearchCB.SelectedItem = null;
                _formLogicGUI.CleanComboBox(new[] { ProvincePanelSearchCB, CityPanelSearchCB });
                _formLogicGUI.DisableComboBox(new[] { ProvincePanelSearchCB, CityPanelSearchCB });
                _formLogicGUI.DisableLabel(new[] { ProvincePanelSearchLbl, CityPanelSearchLbl });
            }
            SearchSupplier();
        }


        private void provCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvincePanelSearchCB.SelectedItem != null && ProvincePanelSearchCB.Text != string.Empty)
            {
                _formLogicGUI.EnableComboBox(new[] { CityPanelSearchCB });
                _formLogicGUI.EnableLabel(new[] { CityPanelSearchLbl });

                string province = ProvincePanelSearchCB.Text;
                CityPanelSearchCB.Items.Clear();
                LoadCities(province);
            }

            else
            {
                ProvincePanelSearchCB.SelectedItem = null;
                _formLogicGUI.CleanComboBox(new[] { CityPanelSearchCB });
                _formLogicGUI.DisableComboBox(new[] { CityPanelSearchCB });
            }
            SearchSupplier();
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
                if (control is ComboBox)
                {
                    ComboBox comboBox = control as ComboBox;
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

        private void CityPanelCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CityPanelCB.SelectedItem != null && CityPanelCB.Text != string.Empty)
            {
                _formLogicGUI.EnableTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.EnableLabel(new[] { AddressPanelLBL, ZipCodePanelLBL });
            }

            else
            {
                _formLogicGUI.CleanTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableLabel(new[] { AddressPanelLBL, ZipCodePanelLBL });
            }
        }

        private void SupplierDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (!SupplierDGV.Enabled)
            {
                SupplierDGV.CurrentCell = null;
            }
        }

        private void DeleteFilterSearchBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in SearchFilterPanel.Controls)
            {
                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.SelectedItem = null;
                }
            }

            //AllertImage.Visible = false;
            SearchBtn.Image = Properties.Resources.hamburger;
            SearchFilterPanel.Visible = false;
            SearchFilterPanel.Enabled = false;

            ResetStandardTextForSearchBox();

            UpdateDataGridView();
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

        private void CityPanelSearchCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSupplier();
        }
    }
}

