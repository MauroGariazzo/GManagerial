using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.Geo.models;
using GManagerial.DBConnectors;
using GManagerial.WareHouse.models;
using GManagerial.WareHouse.ChildForms.NewOrder;
using System.Collections.Generic;
using System;
using GManagerial.Documents.OrderDocument.models;

namespace GManagerial.WareHouse.ChildForms
{    
    public delegate void OnClosing(object sender, FormClosingEventArgs e);
    public delegate void CloseForm();
    internal partial class AddSupplier : Form
    {
        private FormLogicGUI _formLogicGUI;
        private List<string> _regions;
        private Dictionary<string, string> _provinces;
        private List<string> _cities;
        private DAOGeo _daoGeo;
        private IDBConnector _dbConnector;
        private DAOSupplier _daoSupplier;
        private Dictionary<int, Supplier> _suppliers;
        private Supplier _supplier;
        private Warehouse _warehouse;
        private UpdateDataGridViewDelegate _updateDataGridViewDelegate;
        public AddSupplier(Order order, Warehouse selectedWarehouse, UpdateDataGridViewDelegate updateDataGridViewDelegate)
        {
            InitializeComponent();
            _formLogicGUI = new FormLogicGUI();
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._daoGeo = new DAOGeo(_dbConnector);
            this._daoSupplier = new DAOSupplier(_dbConnector);
            this._supplier = new Supplier();
            this._warehouse = selectedWarehouse;
            this._updateDataGridViewDelegate = updateDataGridViewDelegate;
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {

            ExistingSupplierRB.Checked = true;
            DisableAllNewSupplierControls();

            LoadSuppliers();
            LoadRegions();
        }

        /*private void CleanComboBoxAndTextBox()
        {
            _formLogicGUI.CleanComboBox(new ComboBox[] { SupplierCB, RegionPanelCB, ProvincePanelCB, CityPanelCB });
            _formLogicGUI.CleanTextBox(new TextBox[] { SupplierNamePanelTB, IdTaxPanelTB, VatPanelTB, RecipientCodePanelTB, ZipCodePanelTB, AddressPanelTB, TelephonePanelTB, MobilePanelTB, MailPanelTB, PecPanelTB });
        }*/

        private void LoadSuppliers()
        {
            _suppliers = _daoSupplier.GetAll();

            foreach (Supplier supplier in _suppliers.Values)
            {
                SupplierCB.Items.Add(supplier);
            }
            SupplierCB.DisplayMember = "SupplierName";
        }

        private void LoadRegions()
        {
            _regions = _daoGeo.GetRegions();
            foreach (string region in _regions)
            {
                RegionPanelCB.Items.Add(region);
            }
        }
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (CreateNewSupplierRB.Checked)
            {
                if (DataPanelValidate())
                {
                    _supplier.ID = _daoSupplier.Insert(_supplier);
                    GManagerial.WareHouse.ChildForms.NewOrder.NewOrderForm newOrder = new NewOrderForm(_supplier, _warehouse, AddSupplier_FormClosing, Close);
                    newOrder.ShowDialog();                    
                }
            }

            else
            {
                if (!(SupplierCB.SelectedItem is null))
                {
                    _supplier = SupplierCB.SelectedItem as Supplier;
                    NewOrderForm newOrder = new NewOrderForm(_supplier, _warehouse, AddSupplier_FormClosing, Close);
                    newOrder.ShowDialog();                    
                }

                else
                {
                    MessageBox.Show("Seleziona una voce", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool DataPanelValidate()
        {
            if (_supplier is null)
            {
                _supplier = new Supplier();
            }

            try
            {
                _supplier.SupplierName = SupplierNamePanelTB.Text;
                _supplier.IdTax = IdTaxPanelTB.Text;
                _supplier.Vat = VatPanelTB.Text;
                _supplier.Email = MailPanelTB.Text;
                _supplier.Region = RegionPanelCB.Text;
                _supplier.Province = ProvincePanelCB.Text;
                _supplier.City = CityPanelCB.Text;
                _supplier.Pec = PecPanelTB.Text;
                _supplier.Telephone = TelephonePanelTB.Text;
                _supplier.Mobile = MobilePanelTB.Text;
                _supplier.Address = AddressPanelTB.Text;
                _supplier.RecipientCode = RecipientCodePanelTB.Text;
                _supplier.ZipCode = ZipCodePanelTB.Text;
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
            Close();
        }



        private void ExistingSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (ExistingSupplierRB.Checked)
            {
                DisableAllNewSupplierControls();
            }
        }

        private void CreateNewSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateNewSupplierRB.Checked)
            {
                DisableAllExistingSupplierControls();
            }
        }

        private void DisableAllExistingSupplierControls()
        {
            foreach (Control control in CreateNewSupplierPanel.Controls)
            {
                control.Enabled = true;
            }

            foreach (Control control in ExistingSupplierPanel.Controls)
            {
                if (control is ComboBox)
                {
                    ComboBox contr = control as ComboBox;
                    contr.SelectedItem = null;
                }

                control.Enabled = false;
            }
        }

        private void DisableAllNewSupplierControls()
        {
            foreach (Control control in ExistingSupplierPanel.Controls)
            {
                control.Enabled = true;
            }

            foreach (Control control in CreateNewSupplierPanel.Controls)
            {
                if (control is TextBox || control is ComboBox)
                {
                    control.Text = string.Empty;
                }

                control.Enabled = false;
            }
        }


        private void RegionPanelCB_SelectedIndexChanged(object sender, EventArgs e)
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

        private void LoadProvinces(string region)
        {
            ProvincePanelCB.Items.Clear();
            _provinces = _daoGeo.GetProvinces(region);

            foreach (KeyValuePair<string, string> couple in _provinces)
            {
                ProvincePanelCB.Items.Add(couple.Key);
            }
        }

        private void ProvincePanelCB_SelectedIndexChanged(object sender, EventArgs e)
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
        private void LoadCities(string province)
        {
            CityPanelCB.Items.Clear();
            _cities = _daoGeo.GetCities(province);

            foreach (string city in _cities)
            {
                CityPanelCB.Items.Add(city);
            }
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

        private void SupplierCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            _supplier = SupplierCB.SelectedItem as Supplier;
        }

        private void AddSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            _updateDataGridViewDelegate();            
        }
    }
}