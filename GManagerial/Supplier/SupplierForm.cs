using GManagerial.AttachmentsForm;
using GManagerial.CustomerForm;
using GManagerial.CustomerForm.ChildForms;
using GManagerial.CustomerMGM;
using GManagerial.ObtainID;
using GManagerial.Products;
using GManagerial.Products.ChildForms;
using GManagerial.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace GManagerial
{
    public partial class SupplierForm : Form
    {

        private char nec;
        private int selectedRow;
        private Boolean AttachmentFormExist;
        private int countAttachmentsAccess;
        private List<int> attachmentsToDeleteIndex;
        private List<object> attachmentRow;
        private List<int> idDBRows = new List<int>();
        private List<int> idDGVRows = new List<int>();

        public SupplierForm()
        {

            this.attachmentsToDeleteIndex = new List<int>();
            this.attachmentRow = new List<object>();
            this.idDBRows = new List<int>();
            this.idDGVRows = new List<int>();
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            RPMlogicBox.LoadComboBox(regionBox);
            RPMlogicBox.LoadComboBox(regionCB);
            SupplierMGM.LoadSuppliers(SupplierDGV);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            this.nec = 'n';

            FormLogicGUI.NECCC(AnagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn }
                );
        }


        private void editBtn_Click(object sender, EventArgs e)
        {
            if (idDGVRows.Count == 1 || SupplierDGV.SelectedRows.Count == 1)
            {
                RowLogic.DisableAllCheckBoxes(SupplierDGV);

                selectedRow = SupplierDGV.SelectedRows[0].Index;

                this.nec = 'e';
                FormLogicGUI.NECCC(AnagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton,
            AttachmentsBtn });

                SupplierMGM.editSupplier(companyTB, mailBox, idTaxBox, regionBox, provBox, municBox, AddressBox, telBox, pecBox, notesBox, CapBox,
                    mobileBox, coDestBox, ivaTB, ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID"));

                RPMlogicBox.ActDeaPM(regionBox, provBox, provLbl, municBox, municipLbl, CapBox, AddressBox, CapLbl, AddressLbl);
            }

            else if (idDGVRows.Count > 1 || SupplierDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUI.SelectElement("fornitore");
            }
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (idDGVRows.Count == 1 || SupplierDGV.SelectedRows.Count == 1)
            {
                this.nec = 'c';

                FormLogicGUI.NECCC(AnagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn }
                );

                selectedRow = SupplierDGV.SelectedRows[0].Index;

                SupplierMGM.editSupplier(companyTB, mailBox, idTaxBox, regionBox, provBox, municBox, AddressBox, telBox, pecBox, notesBox, CapBox,
            mobileBox, coDestBox, ivaTB, ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID"));

                RPMlogicBox.ActDeaPM(regionBox, provBox, provLbl, municBox, municipLbl, CapBox, AddressBox, CapLbl, AddressLbl);

                attachmentRow = AttachmentClass.LoadCustAttFromDB(ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID"));
            }

            else if (idDGVRows.Count == 1 || SupplierDGV.SelectedRows.Count > 1 || idDBRows.Count > 1)
            {
                MessageBox.Show("Non posso modificare più di un elemento alla volta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                FormLogicGUI.SelectElement("fornitore");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (SupplierDGV.RowCount > 0)
            {
                if (idDGVRows.Count == 0) { RowLogic.HowManyRows(SupplierDGV, idDGVRows, ref selectedRow, idDBRows); }
                //moveIDfromDGVToDBList();

                if (SupplierDGV.CurrentCell.RowIndex != -1 && ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID") != -1)
                {
                    DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare la riga selezionata?", "Conferma cancellazione",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        if (idDBRows.Count > 0)
                        {
                            idDBRows.ForEach(supplID => SupplierMGM.deleteSupplier(supplID));
                        }

                        else
                        {
                            SupplierMGM.deleteSupplier(ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID"));
                        }

                        SupplierForm_Load(sender, e);
                        RowLogic.DeselectAllCheckBox(idDGVRows, SupplierDGV, true, selectedRow);
                    }
                }
            }

            else
            {
                FormLogicGUI.SelectElement("fornitore");
            }

            idDBRows.Clear();
            selectAllRows.Checked = false;
            RowLogic.DisableAllCheckBoxes(SupplierDGV);

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (companyTB.Text != "")
                {
                    if(this.nec != 'n' && this.nec != 'c')
                    {
                        SupplierMGM.registerSupplier(nec, companyTB, idTaxBox, regionBox, municBox, provBox, AddressBox, telBox, mobileBox, mailBox, CapBox,
                         pecBox, notesBox, ivaTB, coDestBox, ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID"));
                    }

                    else
                    {
                        SupplierMGM.registerSupplier(nec, companyTB, idTaxBox, regionBox, municBox, provBox, AddressBox, telBox, mobileBox, mailBox, CapBox,
                         pecBox, notesBox, ivaTB, coDestBox, 0);
                    }

                    FormLogicGUI.NECCC(AnagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn });
                    FormLogicGUI.DisableAndCleanTextBox(AnagrPanel);
                    SupplierForm_Load(sender, e);
                }

                else
                {
                    FormLogicGUI.PrintNotValidNameMessage("fornitore");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            AFCommonLogic.checkAttachments(AttachmentFormExist, ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID"), nec, attachmentRow, 'c');
            AFCommonLogic.resetAndCleanVars(ref AttachmentFormExist, ref countAttachmentsAccess, attachmentsToDeleteIndex);


            if (this.nec == 'c' || this.nec == 'n')
            {
                RowLogic.RowSelected(selectedRow, SupplierDGV, 'c');
            }

            else
            {
                RowLogic.RowSelected(selectedRow, SupplierDGV);
            }

            RowLogic.DeselectAllCheckBox(idDGVRows, SupplierDGV);
            idDBRows.Clear();
            selectAllRows.Checked = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (FormLogicGUI.PrintCancelEdit())
            {
                FormLogicGUI.NECCC(AnagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, BottomPanel, DocsButton, AttachmentsBtn
                });

                FormLogicGUI.DisableAndCleanTextBox(AnagrPanel);

                AFCommonLogic.resetAndCleanVars(ref AttachmentFormExist, ref countAttachmentsAccess, attachmentsToDeleteIndex);

                RowLogic.RowSelected(selectedRow, SupplierDGV);
                RowLogic.DeselectAllCheckBox(idDGVRows, SupplierDGV);
            }

            idDBRows.Clear();
            selectAllRows.Checked = false;
        }


        private void whatsappChat_Click(object sender, EventArgs e)
        {
            WMCLink.whatsappChat_Click(mobileBox);
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            WMCLink.mailBtn_Click(mailBox);
        }

        private void phoneBtn_Click(object sender, EventArgs e)
        {
            WMCLink.phoneBtn_Click(telBox);
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

        private void municBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }


        private void SupplierDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RowLogic.CellContentClick(idDBRows, idDGVRows, SupplierDGV, sender, e, "Supplier_ID");
        }

        private void SupplierDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowLogic.DGV_CellClick(sender, e);
        }

        private void AttachmentsBtn_Click(object sender, EventArgs e)
        {
            AttachmentForm attachmentForm;
            this.countAttachmentsAccess += 1;

            if (this.nec == 'n')
            {
                attachmentForm = new AttachmentForm(-1, countAttachmentsAccess, 'p');
            }

            else
            {
                attachmentForm = new AttachmentForm(ObtainIDelements.ObtainIdElement(SupplierDGV.SelectedRows[0].Index, SupplierDGV, "Supplier_ID"),  countAttachmentsAccess, 'p');
            }

            AttachmentFormExist = true;
            attachmentForm.ShowDialog();
        }


        private void regionBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }

        private void provBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }

        private void telBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void CapBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.CapBox_KeyPress(sender, e);
        }

        private void mobileBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void selectAllRows_CheckedChanged(object sender, EventArgs e)
        {
            RowLogic.selectAllRows_CheckedChanged(selectAllRows, SupplierDGV, idDGVRows, idDBRows, "Supplier_ID");
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Enter(searchBox);
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchLogic.searchBox_KeyDown(e, searchBox);
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchLogic.searchBox_KeyPress(sender, e);
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            SearchLogic.searchBox_Leave(searchBox);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "region", regionCB },
            { "prov", provCB }, { "city", cityCB }};
            SearchLogic.FormSorting(searchBox, 's', SupplierDGV, comboBoxDictionary);
        }

        
        private void SupplierDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            selectAllRows.Location = new Point(SupplierDGV.Columns[0].Width / 2 - 5, selectAllRows.Location.Y);
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

        private void resetCB_Click(object sender, EventArgs e)
        {
            SearchLogic.resetCB_Click(searchPanel);
        }

        private void searchbtn2_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "region", regionCB },
            { "prov", provCB }, { "city", cityCB }};
            SearchLogic.FormSorting(searchBox, 's', SupplierDGV, comboBoxDictionary);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary = new Dictionary<string, System.Windows.Forms.ComboBox> { { "region", regionCB },
            { "prov", provCB }, { "city", cityCB }};

            SearchLogic.searchBtn_Click(searchPanel, searchBox, 's', SupplierDGV, comboBoxDictionary, searchBtn);
        }
    }
}

