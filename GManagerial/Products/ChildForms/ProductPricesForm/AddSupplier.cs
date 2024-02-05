using GManagerial.AttachmentsForm;
using GManagerial.Supplier;
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

namespace GManagerial.Products.ChildForms.ProductPricesForm
{
    public partial class AddSupplier : Form
    {
        public event EventHandler FormClosedEvent;
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (companyTB.Text != "")
                {
                    SupplierMGM.registerSupplier('n', companyTB, idTaxBox, regionBox, municBox, provBox, AddressBox, telBox, mobileBox, mailBox, CapBox,
                     pecBox, notesBox, ivaTB, coDestBox, -1);

                    FormLogicGUIObsolete.NECCC(AnagrPanel, true, true, new object[] { confirmBtn, cancelBtn });
                    this.Close();
                }

                else
                {
                    FormLogicGUIObsolete.PrintNotValidNameMessage("fornitore");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (FormLogicGUIObsolete.PrintCancelEdit())
            {
                this.Close();
            }
        }

        private void regionBox_DropDownClosed(object sender, EventArgs e)
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

        private void provBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
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

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            RPMlogicBox.LoadComboBox(regionBox);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
