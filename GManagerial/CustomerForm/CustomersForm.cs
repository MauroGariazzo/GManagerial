using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Net.Mail;
using System.Data.SqlClient;
using GManagerial.CustomerMGM;
using GManagerial.CustomerForm;
using GManagerial.Products.ChildForms;
using GManagerial.Products;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using GManagerial.CustomerForm.ChildForms;
using GManagerial.Supplier;
using GManagerial.AttachmentsForm;
using System.Text.RegularExpressions;
using GManagerial.ObtainID;

namespace GManagerial
{
    public partial class CustomersForm : Form
    {
        private char nec;       //variabile per capire se è un nuovo inserimento, una modifica o una cancellazione di un cliente
        private AttachmentForm attachmentForm;
        private bool AttachmentFormExist;
        private int countAttachmentsAccess;
        private List<int> attachmentsToDeleteIndex;

        private int selectedRow;

        private List<object> attachmentRow;

        private List<int> idDBRows;  //id del DB
        private List<int> idDGVRows;  //id del datagridview
        public CustomersForm()
        {
            InitializeComponent();

            newCust.Image = CustomButton.ResizeIcons(newCust.Image);
            editCust.Image = CustomButton.ResizeIcons(editCust.Image);
            delCust.Image = CustomButton.ResizeIcons(delCust.Image);

            this.nec = '-';
            this.MenuName.Text = "Clienti";
            this.AttachmentFormExist = false;

            this.countAttachmentsAccess = 0;
     
            this.attachmentsToDeleteIndex = new List<int>();

            this.attachmentRow = new List<object>();

            this.idDBRows = new List<int>();
            this.idDGVRows = new List<int>();
        }


        private void CustomersForm_Load(object sender, EventArgs e)
        {
            RPMlogicBox.LoadComboBox(regionBox);
            RPMlogicBox.LoadComboBox(regionCB);
            Customer.Load(CustomersDGV);
            LoadTable();
        }


        private void LoadTable()
        {
            CustomersDGV.Columns[1].HeaderText = "id";
            CustomersDGV.Columns[2].HeaderText = "Denominazione";
            CustomersDGV.Columns[3].HeaderText = "Cod.Fiscale";
            CustomersDGV.Columns[4].HeaderText = "Regione";
            CustomersDGV.Columns[5].HeaderText = "Comune";
            CustomersDGV.Columns[6].HeaderText = "Provincia";
            CustomersDGV.Columns[7].HeaderText = "Indirizzo";
            CustomersDGV.Columns[8].HeaderText = "Telefono";
            CustomersDGV.Columns[9].HeaderText = "Cellulare";
            CustomersDGV.Columns[10].HeaderText = "Email";
            CustomersDGV.Columns[11].HeaderText = "CAP";
        }


        private void newCust_Click(object sender, EventArgs e)
        {
            this.nec = 'n';

            FormLogicGUI.NECCC(AnagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn }
                );
        }


        private void editCust_Click(object sender, EventArgs e)
        {
            if (idDGVRows.Count == 1 || CustomersDGV.SelectedRows.Count == 1)
            {
                RowLogic.DisableAllCheckBoxes(CustomersDGV);

                selectedRow = CustomersDGV.SelectedRows[0].Index;

                this.nec = 'e';
                FormLogicGUI.NECCC(AnagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn }
                    );   

                Customer.editCustomer(denBox, mailBox, idTaxBox, regionBox, provBox, municBox, AddressBox, telBox, pecBox, notesBox, CapBox, birthDateTB, mobileBox,
                    ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer"));

                RPMlogicBox.ActDeaPM(regionBox, provBox, provLbl, municBox, municipLbl, CapBox, AddressBox, CapLbl, AddressLbl); //sblocca le combobox regionbox,provbox,ecc
            }

            else if (idDGVRows.Count > 1 || CustomersDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUI.SelectElement("cliente");
            }
        }


        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (idDGVRows.Count == 1 || CustomersDGV.SelectedRows.Count == 1)
            {
                this.nec = 'c';

                FormLogicGUI.NECCC(AnagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn }
                    );

                selectedRow = CustomersDGV.SelectedRows[0].Index;

                Customer.editCustomer(denBox, mailBox, idTaxBox, regionBox, provBox, municBox, AddressBox, telBox, pecBox, notesBox, CapBox, birthDateTB, mobileBox,
                    ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer"));

                RPMlogicBox.ActDeaPM(regionBox, provBox, provLbl, municBox, municipLbl, CapBox, AddressBox, CapLbl, AddressLbl);

                attachmentRow = AttachmentClass.LoadCustAttFromDB(ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer"));
            }

            else if (idDGVRows.Count == 1 || CustomersDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUI.SelectElement("cliente");
            }
        }


        private void delBtn_Click(object sender, EventArgs e)
        {
            if (CustomersDGV.RowCount > 0)
            {
                if(idDGVRows.Count == 0) { RowLogic.HowManyRows(CustomersDGV, idDGVRows, ref selectedRow, idDBRows); }
                  //quante righe sono state selezionate NON SFRUTTANDO LE CHECKBOX?
                //moveIDfromDGVToDBList();

                if (CustomersDGV.CurrentCell.RowIndex != -1 && ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer") != -1)
                {

                    DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare la riga selezionata?", "Conferma cancellazione",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        if (idDBRows.Count > 0)
                        {
                            idDBRows.ForEach(custID => Customer.deleteCustomer(custID));  
                        }

                        else
                        {
                            Customer.deleteCustomer(ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer"));
                        }

                        CustomersForm_Load(sender, e);
                        RowLogic.DeselectAllCheckBox(idDGVRows, CustomersDGV, true, selectedRow);
                        
                    }
                }
            }
            else
            {
                FormLogicGUI.SelectElement("cliente");
            }

            idDBRows.Clear();
            selectAllRows.Checked = false;
            RowLogic.DisableAllCheckBoxes(CustomersDGV);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (denBox.Text != null && denBox.Text != "")
                {  
                    Customer.registerCustomer(nec, denBox, mailBox, idTaxBox, regionBox, provBox, municBox, AddressBox, telBox, pecBox, notesBox, CapBox, birthDateTB,
                        mobileBox, ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer"));

                    
                    FormLogicGUI.NECCC(AnagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn });
                    FormLogicGUI.DisableAndCleanTextBox(AnagrPanel);
                    CustomersForm_Load(sender, e);
                }

                else
                {
                    FormLogicGUI.PrintNotValidNameMessage("cliente");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            AFCommonLogic.checkAttachments(AttachmentFormExist, ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer"), nec, attachmentRow, 'c');
            AFCommonLogic.resetAndCleanVars(ref AttachmentFormExist, ref countAttachmentsAccess, attachmentsToDeleteIndex);


            if (this.nec == 'c' || this.nec == 'n')
            {
                RowLogic.RowSelected(selectedRow, CustomersDGV, 'c');
            }

            else
            {
                RowLogic.RowSelected(selectedRow, CustomersDGV);
            }

            RowLogic.DeselectAllCheckBox(idDGVRows, CustomersDGV);
            idDBRows.Clear();
            selectAllRows.Checked = false;
        }


        private void cancelBtn_Click(object sender, EventArgs e)  //ANNULLARE LE MODIFICHE
        {
            if (FormLogicGUI.PrintCancelEdit())
            {
                FormLogicGUI.NECCC(AnagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn });

                FormLogicGUI.DisableAndCleanTextBox(AnagrPanel);

                AFCommonLogic.resetAndCleanVars(ref AttachmentFormExist, ref countAttachmentsAccess, attachmentsToDeleteIndex);

                RowLogic.RowSelected(selectedRow, CustomersDGV);
                RowLogic.DeselectAllCheckBox(idDGVRows, CustomersDGV);
            }

            idDBRows.Clear();
            selectAllRows.Checked = false;
        }


        private void regionBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }


        private void provBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }


        private void AttachmentsBtn_Click(object sender, EventArgs e)
        {
            this.countAttachmentsAccess += 1;

            if (this.nec == 'n')
            {
                attachmentForm = new AttachmentForm(-1, countAttachmentsAccess, 'c');

            }

            else
            {
                attachmentForm = new AttachmentForm(ObtainIDelements.ObtainIdElement(CustomersDGV.SelectedRows[0].Index, CustomersDGV, "id_customer"), countAttachmentsAccess, 'c');
            }

            AttachmentFormExist = true;
            attachmentForm.ShowDialog();

        }

        private void municBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }

        private void DocsButton_Click(object sender, EventArgs e)
        {
            DocsMS.Show(DocsButton, 0, DocsButton.Height);  // -> GUI
        }


        static public string ObtainNameFile(string file)
        {
            int lastBackSlash = file.LastIndexOf("\\");
            string fileName = file.Substring(lastBackSlash + 1, file.Length - lastBackSlash - 1);

            return fileName;
        }


        private void CapBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.CapBox_KeyPress(sender,e);
        }


        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchLogic.searchBox_KeyDown(e, searchBox);
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Leave(searchBox);
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Enter(searchBox);
        }

        private void regionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRegion = regionBox.SelectedItem as string;
            if (selectedRegion != null || selectedRegion != "")
            {
                provBox.Items.Clear();
                municBox.Items.Clear();

                if (municBox.Enabled)
                {
                    municBox.Enabled = false;
                }

                provBox.Items.AddRange(GeoClass.GetProv(selectedRegion).Select(province => province.TrimEnd()).ToArray());
            }
        }

        private void provBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProvince = provBox.SelectedItem as string;
            if (selectedProvince != null || selectedProvince != "")
            {
                municBox.Items.Clear();
                municBox.Items.AddRange(GeoClass.GetAllMunicipies(selectedProvince).Select(municipality => municipality.TrimEnd()).ToArray());
            }
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchLogic.searchBox_KeyPress(sender, e);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "region", regionCB },
            { "prov", provCB }, { "city", cityCB }};
            SearchLogic.FormSorting(searchBox, 'c', CustomersDGV, comboBoxDictionary);
        }

        

        private void CustomersDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RowLogic.CellContentClick(idDBRows, idDGVRows, CustomersDGV, sender, e, "id_customer");
        }
      
        private void CustomersDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowLogic.DGV_CellClick(sender, e);
        }

        private void telBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void mobileBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }
     
        private void whatsappBtn_Click(object sender, EventArgs e)
        {
            string mobilePhone = mobileBox.Text;

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
            string mailAddress = mailBox.Text;

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
            string phoneNumber = telBox.Text; 

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

        private void birthDateTB_TextChanged(object sender, EventArgs e)
        {
            DateManipulate.IsValiDate(sender, birthDateTB);
        }

        private void birthDateTB_KeyDown(object sender, KeyEventArgs e)
        {
            DateManipulate.manfDateTB_KeyDown(sender, e, birthDateTB);
        }

        private void birthDateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateManipulate.manfDateTB_KeyPress(sender, e, birthDateTB);
        }

        private void selectAllRows_CheckedChanged(object sender, EventArgs e)
        {
            RowLogic.selectAllRows_CheckedChanged(selectAllRows, CustomersDGV, idDGVRows, idDBRows, "id_customer");
        }

        private void CustomersDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            selectAllRows.Location = new Point(CustomersDGV.Columns[0].Width / 2 - 5, selectAllRows.Location.Y);
        }

        private void regionCB_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionCB, provCB, cityCB, provLbl, cityLbl, null, null, null, null);
        }

        private void regionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRegion = regionCB.SelectedItem as string;
            if (selectedRegion != null || selectedRegion != "")
            {
                provCB.Items.Clear();
                cityCB.Items.Clear();

                if (cityCB.Enabled)
                {
                    cityCB.Enabled = false;
                }

                provCB.Items.AddRange(GeoClass.GetProv(selectedRegion).Select(province => province.TrimEnd()).ToArray());
            }
        }

        private void provCB_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionCB, provCB, cityCB, provLbl, cityLbl, null, null, null, null);
        }

        private void provCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProvince = provCB.SelectedItem as string;
            if (selectedProvince != null || selectedProvince != "")
            {
                cityCB.Items.Clear();
                cityCB.Items.AddRange(GeoClass.GetAllMunicipies(selectedProvince).Select(municipality => municipality.TrimEnd()).ToArray());
            }
        }

        private void cityCB_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionCB, provCB, cityCB, provLbl, cityLbl, null, null, null, null);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "region", regionCB },
            { "prov", provCB }, { "city", cityCB }};

            SearchLogic.searchBtn_Click(searchPanel, searchBox, 'c', CustomersDGV, comboBoxDictionary, searchBtn);
        }

        private void searchbtn2_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "region", regionCB },
            { "prov", provCB }, { "city", cityCB }};
            SearchLogic.FormSorting(searchBox, 'c', CustomersDGV, comboBoxDictionary);
        }

        private void resetCB_Click(object sender, EventArgs e)
        {
            SearchLogic.resetCB_Click(searchPanel);
        }
    }

}