using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    class RPMlogicBox
    {

        static public void LoadComboBox(ComboBox regionBox)
        {
            regionBox.Items.Clear();
            regionBox.Items.AddRange(GeoClass.GetRegions().Select(region => region.TrimEnd()).ToArray());
        }

        static public void AddRegionsToComboBox(ComboBox regionBox)   //RPMlogicBox  regions,provinces,municipies logic
        {
            regionBox.Items.Clear();
            regionBox.Items.AddRange(GeoClass.GetRegions().Select(region => region.TrimEnd()).ToArray());
        }


        static public void RegionBoxSelectIndex(ComboBox regionBox, ComboBox provBox, ComboBox municBox)  //RPMlogicBox  regions,provinces,municipies logic
        {
            string selectedRegion = regionBox.SelectedItem as string;
            if (selectedRegion != null || selectedRegion != "")
            {
                provBox.Items.Clear();
                municBox.Items.Clear();
                provBox.Items.AddRange(GeoClass.GetProv(selectedRegion).Select(province => province.TrimEnd()).ToArray());
            }
        }


        static public void ProvBoxSelectIndex(ComboBox provBox, ComboBox municBox)    //RPMlogicBox  regions,provinces,municipies logic
        {
            string selectedProvince = provBox.SelectedItem as string;
            if (selectedProvince != null || selectedProvince != "")
            {
                municBox.Items.Clear();
                municBox.Items.AddRange(GeoClass.GetAllMunicipies(selectedProvince).Select(municipality => municipality.TrimEnd()).ToArray());
            }
        }


        static public void EnableDisableBox(ComboBox regionBox, ComboBox provBox, ComboBox municBox, Label provLbl, Label municipLbl, Label AddressLbl, Label CapLbl,
            TextBox AddressBox, TextBox CapBox)
        {
            if (regionBox.SelectedItem == null || (string)regionBox.SelectedItem == "")
            {
                provBox.SelectedItem = null;
                provLbl.ForeColor = Color.Gray;
                provBox.Enabled = false;

                municBox.SelectedItem = null;
                municipLbl.ForeColor = Color.Gray;
                municBox.Enabled = false;

                if (AddressLbl != null)
                {
                    AddressLbl.ForeColor = Color.Gray;
                    AddressBox.Enabled = false;

                    CapLbl.ForeColor = Color.Gray;
                    CapBox.Enabled = false;
                }
            }

            else
            {
                provLbl.ForeColor = Color.Black;
                provBox.Enabled = true;


                if (provBox.SelectedItem == null || (string)provBox.SelectedItem == "")
                {
                    municBox.SelectedItem = null;
                    municipLbl.ForeColor = Color.Gray;
                    municBox.Enabled = false;

                    if (AddressLbl != null)
                    {
                        AddressLbl.ForeColor = Color.Gray;
                        AddressBox.Enabled = false;

                        CapLbl.ForeColor = Color.Gray;
                        CapBox.Enabled = false;
                    }
                }

                else
                {
                    if (municipLbl != null)
                    {
                        municipLbl.ForeColor = Color.Black;
                        municBox.Enabled = true;
                    }

                    if (municBox.SelectedItem == null || municBox.SelectedItem == null)
                    {
                        if (AddressLbl != null)
                        {
                            AddressLbl.ForeColor = Color.Gray;
                            AddressBox.Enabled = false;

                            CapLbl.ForeColor = Color.Gray;
                            CapBox.Enabled = false;
                        }
                    }

                    else
                    {
                        if (AddressLbl != null)
                        {
                            AddressLbl.ForeColor = Color.Black;
                            AddressBox.Enabled = true;

                            CapLbl.ForeColor = Color.Black;
                            CapBox.Enabled = true;
                        }
                    }
                }
            }
        }

        static public void editSupplier(ComboBox regionBox, ComboBox provBox, Label provLbl, ComboBox municBox, Label municipLbl, TextBox CapBox, TextBox AddressBox,
            Label CapLbl, Label AddressLbl)
        {
            if (regionBox.SelectedItem != null && regionBox.SelectedItem.ToString() != "")
            {
                provBox.Enabled = true;
                provLbl.ForeColor = Color.Black;
            }


            if (provBox.SelectedItem != null && provBox.SelectedItem.ToString() != "")
            {
                provBox.Enabled = true;
                provLbl.ForeColor = Color.Black;

                municBox.Enabled = true;
                municipLbl.ForeColor = Color.Black;
            }


            if (municBox.SelectedItem != null && municBox.SelectedItem.ToString() != "")
            {
                municBox.Enabled = true;
                CapBox.Enabled = true;
                AddressBox.Enabled = true;

                municipLbl.ForeColor = Color.Black;
                CapLbl.ForeColor = Color.Black;
                AddressLbl.ForeColor = Color.Black;
            }


        }


        static public void ActDeaPM(ComboBox regionBox, ComboBox provBox, Label provLbl, ComboBox municBox, Label municipLbl, TextBox CapBox, TextBox AddressBox,
        Label CapLbl, Label AddressLbl)  //active/deactivate province or municipe box
        {
            if (regionBox.SelectedItem != null && regionBox.SelectedItem.ToString() != "")
            {
                provBox.Enabled = true;
                provLbl.ForeColor = Color.Black;
            }


            if (provBox.SelectedItem != null && provBox.SelectedItem.ToString() != "")
            {
                provBox.Enabled = true;
                provLbl.ForeColor = Color.Black;

                municBox.Enabled = true;
                municipLbl.ForeColor = Color.Black;
            }


            if (municBox.SelectedItem != null && municBox.SelectedItem.ToString() != "")
            {
                municBox.Enabled = true;
                CapBox.Enabled = true;
                AddressBox.Enabled = true;

                municipLbl.ForeColor = Color.Black;
                CapLbl.ForeColor = Color.Black;
                AddressLbl.ForeColor = Color.Black;
            }
        }
    }
}
