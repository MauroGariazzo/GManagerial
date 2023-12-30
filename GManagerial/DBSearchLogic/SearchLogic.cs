using GManagerial.Products.ChildForms;
using NGeo.GeoNames;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial
{
    class SearchLogic
    {
        static public void searchBox_Enter(System.Windows.Forms.TextBox searchBox)
        {
            if (searchBox.Font.Name == "Times New Roman")
            {
                searchBox.Text = "";
            }

            searchBox.ForeColor = Color.Black;
            searchBox.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Regular);
        }

        static public void searchBox_Leave(System.Windows.Forms.TextBox searchBox)
        {
            if (searchBox.Font.Name != "Microsoft YaHei UI" || searchBox.Text == "")
            {
                //searchBox.Text = "Cerca";
                searchBox.ForeColor = SystemColors.ScrollBar;
                searchBox.Font = new Font("Times New Roman", 16, FontStyle.Italic);
            }
        }

        static public void searchBox_KeyDown(KeyEventArgs e, System.Windows.Forms.TextBox searchBox)
        {
            if (searchBox.Text.Length == 1 && e.KeyCode == Keys.Back)
            {
                searchBox.Text = "";
            }
        }

        static public void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }

        }


        //DATAGRIDVIEW
        static public void FormSorting(System.Windows.Forms.TextBox searchBox, char nameForm, DataGridView dgv, Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary)
        {
            if (nameForm == 'p')
            {
                if (checkConditionTB(searchBox))
                {
                    TextBoxSearch.SearchProduct("", dgv, comboBoxDictionary["catCB"], comboBoxDictionary["subCatCB"], comboBoxDictionary["brandCBsearch"]);
                }

                else
                {
                    TextBoxSearch.SearchProduct(searchBox.Text, dgv, comboBoxDictionary["catCB"], comboBoxDictionary["subCatCB"], comboBoxDictionary["brandCBsearch"]);
                }
            }
            
            else if (nameForm == 'c')
            {
                if (checkConditionTB(searchBox))
                {
                    TextBoxSearch.SearchCustomer("", dgv, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }

                else
                {
                    TextBoxSearch.SearchCustomer(searchBox.Text, dgv, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }
            }

            else if(nameForm == 's')
            {
                if (checkConditionTB(searchBox))
                {
                    TextBoxSearch.SearchSupplier("", dgv, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }

                else
                {
                    TextBoxSearch.SearchSupplier(searchBox.Text, dgv, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }
            }
        }

        //LISTBOX
        static public void FormSorting(System.Windows.Forms.TextBox searchBox, char nameForm, ListBox lb, Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary)
        {
            if (nameForm == 'p')
            {
                if (checkConditionTB(searchBox))
                {
                    TextBoxSearch.SearchProduct("", lb, comboBoxDictionary["catCB"], comboBoxDictionary["subCatCB"], comboBoxDictionary["brandCBsearch"]);
                }

                else
                {
                    TextBoxSearch.SearchProduct(searchBox.Text, lb, comboBoxDictionary["catCB"], comboBoxDictionary["subCatCB"], comboBoxDictionary["brandCBsearch"]);
                }
            }

            else if (nameForm == 'c')
            {
                if (checkConditionTB(searchBox))
                {
                    TextBoxSearch.SearchCustomer("", lb, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }

                else
                {
                    TextBoxSearch.SearchCustomer(searchBox.Text, lb, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }
            }

            else if (nameForm == 's')
            {
                if (checkConditionTB(searchBox))
                {
                    TextBoxSearch.SearchSupplier("", lb, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }

                else
                {
                    TextBoxSearch.SearchSupplier(searchBox.Text, lb, comboBoxDictionary["region"], comboBoxDictionary["prov"], comboBoxDictionary["city"]);
                }
            }
        }


        static private Boolean checkConditionTB(System.Windows.Forms.TextBox searchBox)
        {
            if (searchBox.ForeColor == SystemColors.ScrollBar && searchBox.Font.Name == "Times New Roman" && searchBox.Text == "Cerca")
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        static public void searchBtn_Click(Panel searchPanel, System.Windows.Forms.TextBox searchBox, char nameForm, DataGridView DGV, Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary, 
            System.Windows.Forms.Button searchBtn)
        {
            if (searchPanel.Visible == true)
            {
                searchPanel.Visible = false;
                checkCBSearchPanel(searchPanel, searchBtn);
                FormSorting(searchBox, nameForm, DGV, comboBoxDictionary);
            }

            else
            {
                searchPanel.Visible = true;
                checkCBSearchPanel(searchPanel, searchBtn);
            }
        }

        static public void searchBtn_Click(Panel searchPanel, System.Windows.Forms.TextBox searchBox, char nameForm, 
            ListBox lb, Dictionary<string, System.Windows.Forms.ComboBox> comboBoxDictionary, System.Windows.Forms.Button searchBtn)
        {
            if (searchPanel.Visible == true)
            {
                searchPanel.Visible = false;
                checkCBSearchPanel(searchPanel, searchBtn);
                FormSorting(searchBox, nameForm, lb, comboBoxDictionary);
            }

            else
            {
                searchPanel.Visible = true;
                checkCBSearchPanel(searchPanel, searchBtn);
            }
        }
        static private void checkCBSearchPanel(Panel searchPanel, System.Windows.Forms.Button searchBtn)
        {
            foreach (Control control in searchPanel.Controls)
            {
                if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)control;
                    if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() != "")
                    {
                        searchBtn.Image = Properties.Resources.exclamation;
                        searchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        return;
                    }
                }
            }
            searchBtn.Image = null;

        }

        static public void resetCB_Click(Panel searchPanel)
        {
            foreach (Control control in searchPanel.Controls)
            {
                if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)control;
                    comboBox.SelectedItem = null;
                }
            }
        }
    }
}
