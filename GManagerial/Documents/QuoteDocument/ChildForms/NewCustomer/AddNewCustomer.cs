using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GManagerial.DBConnectors;
using GManagerial.Geo.models;
using GManagerial.QuoteDocForms.ChildForms;
using GManagerial.QuoteDocForms.models;
using GManagerial.WareHouse.models.WareHouseProducts;

namespace GManagerial
{    
    public partial class AddNewCustomer : Form
    {
        internal event EventHandler<QuoteDocument> PopulateDictionaryRequested;

        private DBConnector _dbConnector;
        private Customer _customer;
        private Dictionary<int, Customer> _customers;
        private DAOCustomer _daoCustomer;
        private DAOGeo _daoGeo;
        private List<string> _regions;
        private Dictionary<string, string> _provinces;
        private List<string> _cities;
        private FormLogicGUI _formLogicGUI;
        public AddNewCustomer()
        {
            InitializeComponent();
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._customer = new Customer();
            this._customers = new Dictionary<int, Customer>();
            this._daoCustomer = new DAOCustomer(this._dbConnector);
            this._daoGeo = new DAOGeo(this._dbConnector);
            this._regions = new List<string>();
            this._provinces = new Dictionary<string, string>();
            this._formLogicGUI = new FormLogicGUI();
        }

        private void LoadCustomers()
        {
            _customers = _daoCustomer.GetAll();

            foreach (Customer customer in _customers.Values)
            {
                customerCB.Items.Add(customer);
            }
            customerCB.DisplayMember = "Name";
        }

        private void LoadRegions()
        {
            _regions = _daoGeo.GetRegions();
            foreach (string region in _regions)
            {
                RegionPanelCB.Items.Add(region);
            }
        }

        private void AddNewQuote_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadRegions();
        }
       

        private void newCustomerRD_CheckedChanged(object sender, EventArgs e)
        {
            AnagrPanel.Enabled = true;
            customerCB.Enabled = false;
        }

        private void existedCustomerRD_CheckedChanged(object sender, EventArgs e)
        {
            AnagrPanel.Enabled = false;
            customerCB.Enabled = true;
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
            //ProvincePanelSearchCB.Items.Clear(); da completare
            _provinces = _daoGeo.GetProvinces(region);
            foreach (KeyValuePair<string, string> couple in _provinces)
            {
                ProvincePanelCB.Items.Add(couple.Key);
                //ProvincePanelSearchCB.Items.Add(couple.Key);
                //ProvinceSigleTB.Text = couple.Value;
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
            //CityPanelSearchCB.Items.Clear();

            _cities = _daoGeo.GetCities(province);

            foreach (string city in _cities)
            {
                CityPanelCB.Items.Add(city);
                //CityPanelSearchCB.Items.Add(city);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (newCustomerRD.Checked)
            {
                if (DataPanelValidate())
                {
                    _customer.ID = _daoCustomer.Insert(_customer);                    
                }
            }

            else
            {
                if (!(customerCB.SelectedItem is null))
                {
                    _customer = customerCB.SelectedItem as Customer;
                    NewQuoteForm addNewQuote = new NewQuoteForm();
                    addNewQuote.Show();
                }

                else
                {
                    MessageBox.Show("Seleziona una voce", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool DataPanelValidate()
        {
            if (_customer is null)
            {
                _customer = new Customer();
            }

            try
            {
                _customer.Name = CustomerNamePanelTB.Text;
                _customer.BirthDate = birthDatePanelTB.Text;
                _customer.IdTax = IdTaxPanelTB.Text;
                _customer.Email = MailPanelTB.Text;
                _customer.Region = RegionPanelCB.Text;
                _customer.Province = ProvincePanelCB.Text;
                _customer.City = CityPanelCB.Text;
                _customer.Pec = PecPanelTB.Text;
                _customer.Telephone = TelephonePanelTB.Text;
                _customer.Mobile = MobilePanelTB.Text;
                _customer.Address = AddressPanelTB.Text;
                _customer.ZipCode = ZipCodePanelTB.Text;
                _customer.Notes = notesPanelTB.Text;
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
            this.Close();
        }
    }
}


