using GManagerial.CustomerMGM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.CustomerForm;
using GManagerial.QuoteDocForms.ChildForms;

namespace GManagerial
{
    public partial class AddNewCustomer : Form
    {

        private AddNewCustomerMGM customerMGM;
        public Boolean isCustomerCreated { get; set; }
        public AddNewCustomer()
        {
            InitializeComponent();
            
            customerMGM = new AddNewCustomerMGM(customerCB);
            isCustomerCreated = false;
        }

        private void AddNewQuote_Load(object sender, EventArgs e)
        {
            customerMGM.GetAllCustomers();
            RPMlogicBox.AddRegionsToComboBox(regionBox);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (denBox.Text != null && denBox.Text != "")
            {
                Customer.registerCustomer('n', denBox, mailBox, idTaxBox, regionBox, provBox, municBox, AddressBox, telBox, pecBox, notesBox, CapBox, birthDateTB,
                    mobileBox, -1);

                FormLogicGUI.DisableAndCleanTextBox(AnagrPanel);

                isCustomerCreated = true;
                this.Close();

            }

            else
            {
                if (ExistCustRD.Checked == true && customerCB.SelectedItem != null)
                {
                    isCustomerCreated = true;
                    this.Close();
                }

                else
                {
                    FormLogicGUI.PrintNotValidNameMessage("contatto");
                }

            }

        }

        private void newCustRD_CheckedChanged(object sender, EventArgs e)
        {
            this.AnagrPanel.Enabled = true;

            this.customerCB.SelectedItem = null;
            this.customerCB.Enabled = false;
        }

        private void ExistCustRD_CheckedChanged(object sender, EventArgs e)
        {
            this.AnagrPanel.Enabled = false;
            this.customerCB.Enabled = true;
        }

        private void regionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RPMlogicBox.RegionBoxSelectIndex(regionBox, provBox, municBox);
        }

        private void provBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RPMlogicBox.ProvBoxSelectIndex(provBox, municBox);
        }

       //-----------------------------------------------------------------------------------------------------------------------//

        private void regionBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }

        private void provBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }

        private void municBox_DropDownClosed(object sender, EventArgs e)
        {
            RPMlogicBox.EnableDisableBox(regionBox, provBox, municBox, provLbl, municipLbl, AddressLbl, CapLbl, AddressBox, CapBox);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            FormLogicGUI.DisableAndCleanTextBox(AnagrPanel);
            this.Close();
        }

         
    }
}


