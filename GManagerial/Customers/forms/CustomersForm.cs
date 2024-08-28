using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GManagerial.Attachments;
using GManagerial.DBConnectors;
using GManagerial.Geo.models;
using GeoAPI.IO;
using GManagerial.GraphicElements;
using GManagerial.Customers.models;

namespace GManagerial
{
    public partial class CustomersForm : Form
    {
        private System.Windows.Forms.Button[] _buttonList;
        private System.Windows.Forms.TextBox[] _textboxes;
        private System.Windows.Forms.ComboBox[] _comboboxes;
        private List<string> _regions;
        private Dictionary<string, string> _provinces;
        private List<string> _cities;
        private Dictionary<int, Customer> _customers;

        private Customer _customer;
        private IDBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");

        private FormLogicGUI _formLogicGUI;

        private DAOAttachments _daoAttachment;
        private DAOObjectAttachments _daoObjectAttachments;

        private DAOCustomer _daoCustomer;
        private DAOGeo _DAOGeo;

        private RowLogic.RowLogic _rowLogic;
        public IsNewEditCopyDeleteEnum _isNewEditCopyDelete;
        private int _selectedRow;

        public CustomersForm()
        {
            InitializeComponent();

            this._daoCustomer = new DAOCustomer(_dbConnector);
            this._daoAttachment = new DAOAttachments(_dbConnector, AttachmentQuery.INSERT_ATTACHMENT, AttachmentQuery.DELETE_ATTACHMENT);
            this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector, AttachmentQuery.SELECT_CUSTOMER, AttachmentQuery.INSERT_CUSTOMER, AttachmentQuery.DELETE_CUSTOMER);
            this._formLogicGUI = new FormLogicGUI();

            this._buttonList = new System.Windows.Forms.Button[] { confirmBtn, cancelBtn, AttachmentsBtn, DocsButton };
            this._textboxes = new System.Windows.Forms.TextBox[] { CustomerNameTB, IdTaxTB, BirthDateTB, AddressPanelTB, TelephoneTB, MobileTB, EmailTB, PecTB, NotesTB };
            this._comboboxes = new System.Windows.Forms.ComboBox[] { RegionPanelCB, ProvincePanelCB, CityPanelCB };
            this._DAOGeo = new DAOGeo(_dbConnector);
            this._rowLogic = new RowLogic.RowLogic(CustomersDGV);
        }


        private void CustomersForm_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            LoadRegions();
        }

        private void UpdateDataGridView()//delegate?
        {
            CustomersDGV.Rows.Clear();
            _customers = _daoCustomer.GetAll();
            DataGridViewPopulateFromDictionary();
        }

        private void UpdateDataGridViewFilter()//delegate?
        {
            CustomersDGV.Rows.Clear();
            DataGridViewPopulateFromDictionary();
        }

        private void DataGridViewPopulateFromDictionary()
        {
            foreach (var couple in _customers)
            {
                //riga
                int rowIndex = CustomersDGV.Rows.Add();

                //colonne
                CustomersDGV.Rows[rowIndex].Cells[0].Value = couple.Key;
                CustomersDGV.Rows[rowIndex].Cells[1].Value = couple.Value.Name;
                CustomersDGV.Rows[rowIndex].Cells[2].Value = couple.Value.Region;
                CustomersDGV.Rows[rowIndex].Cells[3].Value = couple.Value.Province;
                CustomersDGV.Rows[rowIndex].Cells[4].Value = couple.Value.City;
                CustomersDGV.Rows[rowIndex].Cells[5].Value = couple.Value.Address;
                CustomersDGV.Rows[rowIndex].Cells[6].Value = couple.Value.Telephone;
            }
        }

        private void LoadRegions()
        {
            _regions = _DAOGeo.GetRegions();
            foreach (string region in _regions)
            {
                RegionPanelCB.Items.Add(region);
                RegionPanelSearchCB.Items.Add(region);
            }
        }

        private void LoadProvinces(string region)
        {
            ProvincePanelCB.Items.Clear();
            ProvincePanelSearchCB.Items.Clear();
            _provinces = _DAOGeo.GetProvinces(region);
            foreach (KeyValuePair<string, string> couple in _provinces)
            {
                ProvincePanelCB.Items.Add(couple.Key);
                ProvincePanelSearchCB.Items.Add(couple.Key);
                //ProvinceSigleTB.Text = couple.Value;
            }
        }

        private void LoadCities(string province)
        {
            CityPanelCB.Items.Clear();
            CityPanelSearchCB.Items.Clear();

            _cities = _DAOGeo.GetCities(province);

            foreach (string city in _cities)
            {
                CityPanelCB.Items.Add(city);
                CityPanelSearchCB.Items.Add(city);
            }
        }


        private void newCust_Click(object sender, EventArgs e)
        {
            _formLogicGUI.NewEditCopyButtonEnable(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, CustomersDGV);

            _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.New;

            if (CustomersDGV.SelectedRows.Count > 0)
            {
                _selectedRow = CustomersDGV.SelectedRows[0].Index;
            }

            _customer = new Customer();

            _customer.Attachments = new Dictionary<int, IAttachment>();
            _customer.TempAttachments = new Dictionary<int, IAttachment>();
            _customer.AttachmentsToDelete = new Dictionary<int, IAttachment>();
        }


        private void editCust_Click(object sender, EventArgs e)
        {
            if (CustomersDGV.SelectedRows.Count == 1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Edit;
                _selectedRow = CustomersDGV.SelectedRows[0].Index;

                int id = (int)CustomersDGV.SelectedRows[0].Cells[0].Value;

                _customer = new Customer();
                _customer = _customers[id];

                _customer.TempAttachments = new Dictionary<int, IAttachment>();
                _customer.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _customer.Attachments = _daoObjectAttachments.GetAll(id);

                TransferDataFromDictionariesToPanelControls();
                _formLogicGUI.NewEditCopyButtonEnable(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, CustomersDGV);
            }

            else if (CustomersDGV.SelectedRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                _formLogicGUI.SelectElement("cliente");
            }
        }

        private void TransferDataFromDictionariesToPanelControls()
        {
            CustomerNameTB.Text = _customer.Name;
            IdTaxTB.Text = _customer.IdTax;
            if (_customer.BirthDate != string.Empty) { BirthDateTB.Text = _customer.BirthDate.Substring(0, 10); }
            else { BirthDateTB.Text = string.Empty; }
            RegionPanelCB.Text = _customer.Region;
            ProvincePanelCB.Text = _customer.Province;
            CityPanelCB.Text = _customer.City;
            ZipCodePanelTB.Text = _customer.ZipCode;
            AddressPanelTB.Text = _customer.Address;
            TelephoneTB.Text = _customer.Telephone;
            MobileTB.Text = _customer.Mobile;
            EmailTB.Text = _customer.Email;
            PecTB.Text = _customer.Pec;
            NotesTB.Text = _customer.Notes;
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (CustomersDGV.SelectedRows.Count == 1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Copy;
                _selectedRow = CustomersDGV.SelectedRows[0].Index;

                _customer = new Customer();
                int id = (int)CustomersDGV.SelectedRows[0].Cells[0].Value;
                _customer = _customers[id];

                _customer.TempAttachments = new Dictionary<int, IAttachment>();
                _customer.AttachmentsToDelete = new Dictionary<int, IAttachment>();
                _customer.Attachments = _daoObjectAttachments.GetAll(id);

                _formLogicGUI = new FormLogicGUI();
                TransferDataFromDictionariesToPanelControls();
                _formLogicGUI.NewEditCopyButtonEnable(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, CustomersDGV);
            }
        }


        private void delBtn_Click(object sender, EventArgs e)
        {
            if (CustomersDGV.RowCount > 0 && CustomersDGV.SelectedRows.Count >= 1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Delete;
                _selectedRow = CustomersDGV.SelectedRows[0].Index;
                CheckUserChoice();
            }

            if (selectAllRows.Checked)
            {
                selectAllRows.Checked = false;
            }
        }

        private void CheckUserChoice() //controllare se l'utente è sicuro di voler cancellare la riga o le righe selezionate
        {
            if (CustomersDGV.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Sei sicuro di voler cancellare l'elemento selezionato?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in CustomersDGV.SelectedRows)
                    {
                        _customer = new Customer();
                        int id_customer = (int)row.Cells[0].Value;
                        _customer = _customers[id_customer];

                        _customer.AttachmentsToDelete = _daoObjectAttachments.GetAll(id_customer); //tutti gli allegati
                        DeleteAttachments();
                        DeleteCustomer(id_customer);

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

            if (CustomersDGV.Rows.Count > 0)
            {
                CustomersDGV.ClearSelection();
                CustomersDGV.Rows[row].Selected = true;
            }
        }

        private void DeleteAttachments()
        {
            foreach (Attachment attachment in _customer.AttachmentsToDelete.Values)
            {
                _daoObjectAttachments.Delete(attachment, attachment.ObjectID); //cancella gli allegati dalla tabella product_attachment
                _daoAttachment.Delete(attachment); //cancella gli allegati dalla tabella attachments
            }
        }

        private void DeleteCustomer(int id_customer)
        {
            _customer = _customers[id_customer];
            _daoCustomer.Delete(_customer);
            _customers.Remove(id_customer);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (DataPanelValidate())
            {
                int id_customer; //id per recuperare l'ultima riga inserita

                if (_isNewEditCopyDelete == IsNewEditCopyDeleteEnum.New || _isNewEditCopyDelete == IsNewEditCopyDeleteEnum.Copy) // if (_newEditCopyDelete == 'n' || _newEditCopyDelete == 'c')
                {
                    id_customer = _daoCustomer.Insert(_customer); //nuovo inserimento recupero l'id direttamente dalla query
                }

                else
                {
                    _daoCustomer.Update(_customer); //l'id ce l'ho già, perché sto cercando di modificare un prodotto già esistente
                    id_customer = _customer.ID;
                }

                foreach (Attachment attachment in _customer.TempAttachments.Values)
                {
                    int id_attachment = _daoAttachment.Insert(attachment);
                    _daoObjectAttachments.Insert(id_customer, id_attachment);
                }

                AttachmentForm.TempID = -1; //risetto la variabile TempID che mi serviva per gli allegati temporanei
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, CustomersDGV);

                UpdateDataGridView();
                DeleteFilterSearchBtn_Click(sender, e);//azzera tutti i filtri di ricerca
                SelectedRows(_isNewEditCopyDelete);
            }

            else
            {
                MessageBox.Show("Inserisci il nome del cliente", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);//formlogicgui
            }
        }

        public bool DataPanelValidate()
        {
            try
            {
                _customer.Name = CustomerNameTB.Text;
                _customer.IdTax = IdTaxTB.Text;
                _customer.Region = RegionPanelCB.Text;
                _customer.Province = ProvincePanelCB.Text;
                _customer.City = CityPanelCB.Text;
                _customer.ZipCode = ZipCodePanelTB.Text;
                _customer.Address = AddressPanelTB.Text;
                _customer.Telephone = TelephoneTB.Text;
                _customer.Mobile = MobileTB.Text;
                _customer.Email = EmailTB.Text;
                _customer.Pec = PecTB.Text;
                _customer.Notes = NotesTB.Text;
                _customer.BirthDate = BirthDateTB.Text;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void cancelBtn_Click(object sender, EventArgs e)  //ANNULLARE LE MODIFICHE
        {
            if (_formLogicGUI.PrintCancelEdit())
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Cancel;
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanel, null, _comboboxes, _textboxes, _buttonList, stripBtns, CustomersDGV);
                DeleteFilterSearchBtn_Click(sender, e);//azzera tutti i filtri di ricerca
                SelectedRows(_isNewEditCopyDelete);
            }

            selectAllRows.Checked = false;
            AttachmentForm.TempID = -1;
        }


        private void AttachmentsBtn_Click(object sender, EventArgs e)
        {
            AttachmentForm attachmentForm = new AttachmentForm(_customer, _customer.ID);
            attachmentForm.ShowDialog();
        }


        private void DocsButton_Click(object sender, EventArgs e)
        {
            DocsMS.Show(DocsButton, 0, DocsButton.Height);  // -> GUI
        }

        private void CapBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //IsDigitInput.CapBox_KeyPress(sender,e);
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
        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (SearchTB.Text.Equals(string.Empty))
            {
                ResetStandardTextForSearchBox();
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (SearchTB.Text.Equals("Cerca"))
            {
                SetTextForSearchBox();
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
                LoadCities(province);
            }

            else
            {
                _formLogicGUI.CleanComboBox(new[] { CityPanelCB });
                _formLogicGUI.CleanTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableComboBox(new[] { CityPanelCB });
                _formLogicGUI.DisableTextBox(new[] { AddressPanelTB, ZipCodePanelTB });
                _formLogicGUI.DisableLabel(new[] { AddressPanelLBL, CityPanelLBL, ZipCodePanelLBL });
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (!SearchTB.Text.Equals("Cerca") && SearchTB.Font.FontFamily.Name != "Times New Roman")
            {
                SearchCustomer();
            }
        }

        private void SearchCustomer()
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
                _customers = _daoCustomer.GetCutstomersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, CustomerQueries.SEARCHCUSTOMER);
            }

            else if (!(RegionPanelSearchCB.SelectedItem is null) && ProvincePanelSearchCB.SelectedItem is null && CityPanelSearchCB.SelectedItem is null)
            {
                _customers = _daoCustomer.GetCutstomersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, CustomerQueries.SEARCHCUSTOMERWITHREGION);

            }

            else if (!(RegionPanelSearchCB.SelectedItem is null && ProvincePanelSearchCB.SelectedItem is null) && CityPanelSearchCB.SelectedItem is null)
            {
                _customers = _daoCustomer.GetCutstomersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, CustomerQueries.SEARCHCUSTOMERWITHREGIONANDPROVINCE);
            }

            else if (!(RegionPanelSearchCB.SelectedItem is null && ProvincePanelSearchCB.SelectedItem is null && CityPanelSearchCB.SelectedItem is null))
            {
                _customers = _daoCustomer.GetCutstomersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, CustomerQueries.SEARCHCUSTOMERWITHREGIONPROVINCEANDCITY);
            }

            /*else if (!(RegionPanelSearchCB.SelectedItem is null) && ProvincePanelSearchCB.SelectedItem is null && !(CityPanelSearchCB.SelectedItem is null))
            {
                _customers = _daoCustomer.GetCutstomersSearch(textToSearch.ToLower(), RegionPanelSearchCB.Text, ProvincePanelSearchCB.Text, CityPanelSearchCB.Text, CustomerQueries.SEARCHCUSTOMERWITHREGIONANDCITY);
            }*/

            UpdateDataGridViewFilter();
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
                        searchBtn.Image = Properties.Resources.exclamation;
                        return;
                    }
                }
            }
            searchBtn.Image = Properties.Resources.hamburger;

            //AllertImage.Visible = false;

        }

        private void whatsappBtn_Click(object sender, EventArgs e)
        {
            string mobilePhone = MobileTB.Text;

            if (!string.IsNullOrWhiteSpace(mobilePhone))
            {
                mobilePhone = mobilePhone.Replace("+", "").Replace(" ", "").Trim();
                string urlWhatsAppWeb = $"https://web.whatsapp.com/send?phone={mobilePhone}";
                System.Diagnostics.Process.Start(urlWhatsAppWeb);
            }
            else
            {
                MessageBox.Show("Inserisci un numero di telefono valido.", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            string mailAddress = EmailTB.Text;

            if (!string.IsNullOrWhiteSpace(mailAddress))
            {
                string urlEmail = $"mailto:{mailAddress}";

                System.Diagnostics.Process.Start(urlEmail);
            }
            else
            {
                MessageBox.Show("Inserisci un indirizzo email valido.", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void phoneBtn_Click(object sender, EventArgs e)
        {
            string phoneNumber = TelephoneTB.Text;

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

                string phoneUrl = $"tel:{phoneNumber}";

                System.Diagnostics.Process.Start(phoneUrl);
            }
            else
            {
                MessageBox.Show("Inserisci un numero di telefono valido.", "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CustomersDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

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
            SearchCustomer();
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
            SearchCustomer();
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

        private void searchbtn2_Click(object sender, EventArgs e)
        {
            /*Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "region", regionCB },
            { "prov", provCB }, { "city", cityCB }};
            SearchLogic.FormSorting(searchBox, 'c', CustomersDGV, comboBoxDictionary);*/
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
            searchBtn.Image = Properties.Resources.hamburger;
            SearchFilterPanel.Visible = false;
            SearchFilterPanel.Enabled = false;

            ResetStandardTextForSearchBox();

            UpdateDataGridView();
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

        private void selectAllRows_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllRows.Checked)
            {
                CustomersDGV.SelectAll();
            }

            else
            {
                CustomersDGV.ClearSelection();
            }
        }

        private void CustomersDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (!CustomersDGV.Enabled)
            {
                CustomersDGV.CurrentCell = null;
            }
        }

        private void CityPanelSearchCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }
    }

}
