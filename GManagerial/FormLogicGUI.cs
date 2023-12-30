using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial
{
    class FormLogicGUI
    {
        static public void NECCC(Panel anagrPanel, Boolean isActive, Boolean isConfirmCancelOrNot, object[]controls, TabControl anagrTP = null)
        {
            EnableDisablePanelORTab(anagrPanel, anagrTP, isActive);

            foreach (Control control in controls)
            {
                if (isConfirmCancelOrNot)
                {
                    if(control.Name == "stripBtns")
                    {
                        control.Enabled = true;
                    }

                    else
                    {
                        control.Visible = false;
                    }
                }

                else
                {
                    if (control.Name == "stripBtns")
                    {
                        control.Enabled = false;
                    }

                    else
                    {
                        control.Visible = true;
                    }
                }
            }
        }


        static private void EnableDisablePanelORTab(Panel anagrPanel, TabControl anagrTP ,Boolean isActive)
        {
            if (anagrPanel != null)
            {
                if (isActive)
                {
                    anagrPanel.Enabled = false;
                }

                else
                {
                    anagrPanel.Enabled = true;
                }
            }

            else
            {
                if (isActive)
                {
                    anagrTP.Enabled = false;
                }

                else
                {
                    anagrTP.Enabled = true;
                }
            }
        }

        static public void EnableDisableBox(ComboBox regionBox, ComboBox provBox, ComboBox municBox, TextBox AddressBox, TextBox CapBox,
            Label provLbl, Label municipLbl, Label AddressLbl, Label CapLbl)
        {
            if (regionBox.SelectedItem == null || (string)regionBox.SelectedItem == "")
            {
                provBox.SelectedItem = null;
                provLbl.ForeColor = Color.Gray;
                provBox.Enabled = false;

                municBox.SelectedItem = null;
                municipLbl.ForeColor = Color.Gray;
                municBox.Enabled = false;

                AddressLbl.ForeColor = Color.Gray;
                AddressBox.Enabled = false;

                CapLbl.ForeColor = Color.Gray;
                CapBox.Enabled = false;
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

                    AddressLbl.ForeColor = Color.Gray;
                    AddressBox.Enabled = false;

                    CapLbl.ForeColor = Color.Gray;
                    CapBox.Enabled = false;
                }

                else
                {
                    municipLbl.ForeColor = Color.Black;
                    municBox.Enabled = true;


                    if (municBox.SelectedItem == null || municBox.SelectedItem == null)
                    {
                        AddressLbl.ForeColor = Color.Gray;
                        AddressBox.Enabled = false;

                        CapLbl.ForeColor = Color.Gray;
                        CapBox.Enabled = false;
                    }

                    else
                    {
                        AddressLbl.ForeColor = Color.Black;
                        AddressBox.Enabled = true;

                        CapLbl.ForeColor = Color.Black;
                        CapBox.Enabled = true;
                    }
                }
            }
        }

        static public void PrintNameMessage()  //DA CANCELLARE
        {//DA CANCELLARE
            MessageBox.Show("Non puoi inserire un fornitore senza nome", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//DA CANCELLARE


        static public void PrintNotValidNameMessage(string valueBox)
        {
            MessageBox.Show("Non puoi inserire un " + valueBox + " senza nome", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        static public Boolean PrintCancelEdit()
        {
            DialogResult result = MessageBox.Show("Sei sicuro di voler annullare il caricamento dei dati?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        static public void PrintDateMessage()
        {
            MessageBox.Show("Inserisci una data corretta", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public void LoadDGV(DataGridView DGV)
        {
           DGV.Columns[0].Width = 60;
        }

        static public void DisableAndCleanTextBox(Panel AnagrPanel)
        {
            foreach (Control control in AnagrPanel.Controls)
            {
                if (control is System.Windows.Forms.TextBox || control is System.Windows.Forms.ComboBox)
                {
                    control.Text = null;
                    if (control.Name == "provBox" || control.Name == "municBox" || control.Name == "CapBox" || control.Name == "AddressBox")
                    {
                        control.Enabled = false;                                                                                            //->customerPanelGUI
                    }
                }

                else if (control is Label)
                {
                    if (control.Name == "provLbl" || control.Name == "municipLbl" || control.Name == "CapLbl" || control.Name == "AddressLbl")
                    {
                        control.ForeColor = Color.Gray;
                    }

                }

            }
        }

        static public void ActDea(Control control, Boolean isActive)
        {            
            if (isActive)
            {
                control.Visible = true;
            }

            else
            {
                control.Visible = false;
            }
        }


        static public void AddQuantity()
        {
            MessageBox.Show("Inserisci una quantità corretta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        static public void SelectElement(string element)
        {
            MessageBox.Show("Seleziona prima un " + element + " o crealo", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        
    }
}
