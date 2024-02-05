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

namespace GManagerial.WareHouse
{
    public partial class CreateWareHouse : Form
    {
        private char nec;
        private int indexSelected;
        private ComboBox selectWarehouseCB;

        public CreateWareHouse(ComboBox selectWarehouseCB)
        {
            InitializeComponent();
            this.selectWarehouseCB = selectWarehouseCB;
        }

        private void regionBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }

        private void provBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
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

        private void CapBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.CapBox_KeyPress(sender, e);
        }

        private void CreateWareHouse_Load(object sender, EventArgs e)
        {
            RPMlogicBox.LoadComboBox(regionBox);  //caricamento regioni nella combobox delle regioni
            WarehouseMGM.PhysicalWareHouse_Load(wareHouseLB);  //caricamento magazzini nella listbox
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if(WHname != null && WHname.Text != "")
            {
                FormLogicGUIObsolete.NECCC(anagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn });       

                WarehouseMGM.CreateWareHouseQuery(WHname, regionBox, provBox, municBox, AddressBox, CapBox, nec, ObtainIDWarehouse());
                FormLogicGUIObsolete.DisableAndCleanTextBox(anagrPanel);
                WarehouseMGM.PhysicalWareHouse_Load(wareHouseLB);
                WarehouseMGM.LoadWareHouseNamesForComboBox(selectWarehouseCB);

                Properties.Settings.Default.LastSelectedWarehouseId = selectWarehouseCB.Items.Count; 
                selectWarehouseCB.SelectedIndex = Properties.Settings.Default.LastSelectedWarehouseId-1; //ultimo magazzino selezionato                                                                                                      //

                wareHouseLB.SelectedIndex = indexSelected;
            }

            else
            {
                FormLogicGUIObsolete.PrintNotValidNameMessage("magazzino");
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            nec = 'n';
            FormLogicGUIObsolete.NECCC(anagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn });
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (selectWarehouseCB.Items.Count > 0)
            {
                if (wareHouseLB.SelectedIndex != -1)
                {
                    nec = 'e';
                    FormLogicGUIObsolete.NECCC(anagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn });
                    WarehouseMGM.EditWareHouse(WHname, regionBox, provBox, municBox, AddressBox, CapBox, ObtainIDWarehouse());
                    RPMlogicBox.ActDeaPM(regionBox, provBox, provLbl, municBox, municipLbl, CapBox, AddressBox, CapLbl, AddressLbl);
                }

                else
                {
                    FormLogicGUIObsolete.SelectElement("prodotto");
                }
            }
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
                        WarehouseMGM.DeleteWareHouse(ObtainIDWarehouse());
                        WarehouseMGM.PhysicalWareHouse_Load(wareHouseLB);
                        WarehouseMGM.LoadWareHouseNamesForComboBox(selectWarehouseCB);
                    }
                }

                else
                {
                    FormLogicGUIObsolete.SelectElement("magazzino");
                }
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (FormLogicGUIObsolete.PrintCancelEdit())
            {
                FormLogicGUIObsolete.NECCC(anagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn });
                FormLogicGUIObsolete.DisableAndCleanTextBox(anagrPanel);
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

    }
}