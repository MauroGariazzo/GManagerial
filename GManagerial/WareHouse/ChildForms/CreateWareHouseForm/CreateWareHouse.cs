using GManagerial.Attachments;
using GManagerial.Geo.models;
using GManagerial.DBConnectors;
using GManagerial.WareHouse.models;
using Nager.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GManagerial.WareHouse.models.Movements;
using GManagerial.WareHouse.models.WareHouseProducts;

namespace GManagerial.WareHouse
{

    public partial class CreateWareHouse : Form
    {
        private int indexSelected;
        private ComboBox selectWarehouseCB;
        private Warehouse _warehouse;
        private FormLogicGUI _formLogicGUI;

        private System.Windows.Forms.Button[] _buttonList;
        private System.Windows.Forms.TextBox[] _textboxes;
        private System.Windows.Forms.ComboBox[] _comboboxes;

        private List<string> _regions;
        private Dictionary<string, string> _provinces;
        private List<string> _cities;

        internal IsNewEditCopyDeleteEnum _isNewEditCopyDelete;
        private DBConnector _dbConnector;
        private DAOGeo _DAOGeo;
        private DAOWareHouse _daoWareHouse;

        private DAODetailsMovement _daoDetailsMovement;
        private DAOMovement _daoMovement;
        private DAOWarehouseProduct _daoWarehouseProduct;

        private Dictionary<int, Warehouse> _warehouses;

        public CreateWareHouse(ComboBox selectWarehouseCB)
        {
            InitializeComponent();
            this._buttonList = new System.Windows.Forms.Button[] { ConfirmBtn, CancelBtn };
            this._textboxes = new System.Windows.Forms.TextBox[] { WareHouseNameTB, AddressTB, ZipCodeTB, DescriptionTB };
            this._comboboxes = new System.Windows.Forms.ComboBox[] { RegionComboBox, ProvinceComboBox, CityComboBox };
            this._formLogicGUI = new FormLogicGUI();

            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._DAOGeo = new DAOGeo(_dbConnector);
            this._daoWareHouse = new DAOWareHouse(_dbConnector);
            this._daoDetailsMovement = new DAODetailsMovement(_dbConnector);
            this._daoMovement = new DAOMovement(_dbConnector);
            this._daoWarehouseProduct = new DAOWarehouseProduct(_dbConnector);
            this.selectWarehouseCB = selectWarehouseCB;
        }

        private void CreateWareHouse_Load(object sender, EventArgs e)
        {
            LoadRegions();
            LoadListBox();
        }

        private void LoadListBox()
        {
            wareHouseLB.Items.Clear();
            _warehouses = _daoWareHouse.GetAll();

            foreach(Warehouse wareHouse in _warehouses.Values)
            {
                wareHouseLB.Items.Add(wareHouse);
            }
            wareHouseLB.DisplayMember = "Warehouse_Name";
        }


        private void LoadRegions()
        {
            _regions = _DAOGeo.GetRegions();
            foreach (string region in _regions)
            {
                RegionComboBox.Items.Add(region);
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (DataPanelValidate())
            {
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanelTP, null, _comboboxes, _textboxes, _buttonList, stripBtns, null);

                if (_isNewEditCopyDelete == IsNewEditCopyDeleteEnum.New || _isNewEditCopyDelete == IsNewEditCopyDeleteEnum.Copy) // if (_newEditCopyDelete == 'n' || _newEditCopyDelete == 'c')
                {
                    _daoWareHouse.Insert(_warehouse); //nuovo inserimento recupero l'id direttamente dalla query
                }

                else
                {
                    _daoWareHouse.Update(_warehouse); //l'id ce l'ho già, perché sto cercando di modificare un prodotto già esistente           
                }
                LoadListBox();
            }
        }

        public bool DataPanelValidate()
        {
            try
            {
                _warehouse.Warehouse_Name = WareHouseNameTB.Text;
                _warehouse.Region = RegionComboBox.Text;
                _warehouse.Province = ProvinceComboBox.Text;
                _warehouse.City = CityComboBox.Text;
                _warehouse.ZipCode = ZipCodeTB.Text;
                _warehouse.Address = AddressTB.Text;
                _warehouse.Description = DescriptionTB.Text;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.New;

            _warehouse = new Warehouse();
            _formLogicGUI.NewEditCopyButtonEnable(AnagrPanelTP, null, _comboboxes, _textboxes, _buttonList, stripBtns, null);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (wareHouseLB.SelectedIndex != -1)
            {
                _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.Edit;
                _formLogicGUI.NewEditCopyButtonEnable(AnagrPanelTP, null, _comboboxes, _textboxes, _buttonList, stripBtns, null);
                Warehouse warehouseSelected = (Warehouse)wareHouseLB.SelectedItem;
                _warehouse = _warehouses[warehouseSelected.ID];

                TransferDataFromDictionariesToPanelControls();    
            }

            else
            {
                    //
            }
        }

        private void TransferDataFromDictionariesToPanelControls()
        {
            WareHouseNameTB.Text = _warehouse.Warehouse_Name;
            RegionComboBox.Text = _warehouse.Region;
            ProvinceComboBox.Text = _warehouse.Province;
            CityComboBox.Text = _warehouse.City;
            AddressTB.Text = _warehouse.Address;
            ZipCodeTB.Text = _warehouse.ZipCode;
            DescriptionTB.Text = _warehouse.Description;
        }

        private int ObtainIDWarehouse()
        {
            try
            {
                ItemTag item = (ItemTag)selectWarehouseCB.Items[indexSelected];
                return (int)item.Tag;
            }

            catch(System.ArgumentOutOfRangeException)
            {
                return 0;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (wareHouseLB.Items.Count > 0)
            {
                if (wareHouseLB.SelectedIndex != -1)
                {
                    DialogResult result = MessageBox.Show("Sei sicuro di voler cancellare la riga selezionata?", "Conferma cancellazione",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _daoMovement.DeleteAllMovements((Warehouse)wareHouseLB.SelectedItem);
                        _daoWarehouseProduct.DeleteAllWarehouseProducts((Warehouse)wareHouseLB.SelectedItem);
                        _daoDetailsMovement.DeleteAllWarehouseDetailsMovement((Warehouse)wareHouseLB.SelectedItem);

                        _daoWareHouse.Delete((Warehouse)wareHouseLB.SelectedItem);
                        LoadListBox();
                    }
                }

                else
                {
                    //FormLogicGUIObsolete.SelectElement("magazzino");
                }
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (_formLogicGUI.PrintCancelEdit())
            {
                _formLogicGUI.ConfirmAndCancelButtonLogic(AnagrPanelTP, null, _comboboxes, _textboxes, _buttonList, stripBtns, null);
            }
        }

        private void wareHouseLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexSelected = wareHouseLB.SelectedIndex;
        }

        static public bool IsFormOpen(string formName)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == formName)
                {
                    return true;
                }
            }
            return false;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
   
            this.Close();
        }

        private void LoadProvinces(string region)
        {
            ProvinceComboBox.Items.Clear();
            _provinces = _DAOGeo.GetProvinces(region);
            foreach (KeyValuePair<string, string> couple in _provinces)
            {
                ProvinceComboBox.Items.Add(couple.Key);
            }
        }

        private void RegionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RegionComboBox.SelectedItem != null && RegionComboBox.Text != string.Empty)
            {
                _formLogicGUI.EnableComboBox(new[] { ProvinceComboBox });
                _formLogicGUI.EnableLabel(new[] { ProvinceLbl });

                _formLogicGUI.CleanComboBox(new[] { CityComboBox });
                _formLogicGUI.DisableComboBox(new[] { CityComboBox });
                _formLogicGUI.DisableLabel(new[] { CityLbl, AddressLbl, ZipCodeLbl });

                _formLogicGUI.CleanTextBox(new[] { AddressTB, ZipCodeTB });
                _formLogicGUI.DisableTextBox(new[] { AddressTB, ZipCodeTB });

                string region = RegionComboBox.Text;
                LoadProvinces(region);
            }

            else
            {
                _formLogicGUI.CleanComboBox(new[] { ProvinceComboBox, CityComboBox });
                _formLogicGUI.CleanTextBox(new[] { AddressTB, ZipCodeTB });
                _formLogicGUI.DisableComboBox(new[] { ProvinceComboBox, CityComboBox });
                _formLogicGUI.DisableLabel(new[] { ProvinceLbl, CityLbl, AddressLbl, ZipCodeLbl });
                _formLogicGUI.DisableTextBox(new[] { AddressTB, ZipCodeTB });
            }
        }

        private void ProvinceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProvinceComboBox.SelectedItem != null && ProvinceComboBox.Text != string.Empty)
            {
                _formLogicGUI.EnableComboBox(new[] { CityComboBox });
                _formLogicGUI.EnableLabel(new[] { CityLbl });

                string province = ProvinceComboBox.Text;
                LoadCities(province);
            }

            else
            {
                _formLogicGUI.CleanComboBox(new[] { CityComboBox });
                _formLogicGUI.CleanTextBox(new[] { AddressTB, ZipCodeTB });
                _formLogicGUI.DisableComboBox(new[] { CityComboBox });
                _formLogicGUI.DisableTextBox(new[] { AddressTB, ZipCodeTB });
                _formLogicGUI.DisableLabel(new[] { AddressLbl, CityLbl, ZipCodeLbl });
            }
        }

        private void LoadCities(string province)
        {
            CityComboBox.Items.Clear();
            _cities = _DAOGeo.GetCities(province);

            foreach (string city in _cities)
            {
                CityComboBox.Items.Add(city);
            }
        }

        private void CityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CityComboBox.SelectedItem != null && CityComboBox.Text != string.Empty)
            {
                _formLogicGUI.EnableTextBox(new[] { AddressTB, ZipCodeTB });
                _formLogicGUI.EnableLabel(new[] { AddressLbl, ZipCodeLbl });
            }

            else
            {
                _formLogicGUI.CleanTextBox(new[] { AddressTB, ZipCodeTB });
                _formLogicGUI.DisableTextBox(new[] { AddressTB, ZipCodeTB });
                _formLogicGUI.DisableLabel(new[] { AddressLbl, ZipCodeLbl });
            }
        }

        private void ZipCodeTB_TextChanged(object sender, EventArgs e)
        {
            //ZipCodeTB.Text = string.Empty;
        }
    }
}