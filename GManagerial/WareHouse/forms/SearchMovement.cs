using GManagerial.WareHouse.models.Movements;
using GManagerial.DBConnectors;
using GManagerial.WareHouse.models;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Drawing;
using static GManagerial.EnumUtilities.ManageMonths;
using GManagerial.EnumUtilities;

namespace GManagerial.WareHouse
{
    public partial class WarehouseMovementsForm
    {
        private DBConnector _dBConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        /*private Dictionary<string,int> months = new Dictionary<string, int>()
        {
            { "Gennaio",1 },
            { "Febbraio",2 },
            { "Marzo",3 },
            { "Aprile" ,4},
            { "Maggio" ,5},
            { "Giugno",6 },
            { "Luglio" ,7},
            { "Agosto" ,8},
            { "Settembre",9 },
            { "Ottobre" ,10},
            { "Novembre" ,11},
            { "Dicembre" ,12}
        };*/

        private void LoadSearchMovements()
        {
            movementSearchCB.Items.Add("-");
            movementSearchCB.Items.Add("Carico");
            movementSearchCB.Items.Add("Scarico");
        }
        private void LoadSearchPanelYears()
        {
            DAOMovement daoMovement = new DAOMovement(_dBConnector);
            searchByYearCB.Items.Clear();
            searchByYearCB.Items.Add("-");

            if (SelectWarehouseCB.SelectedItem != null)
            {
                Dictionary<int,Movement> movements = daoMovement.GetAll(SelectWarehouseCB.SelectedItem as Warehouse);
                foreach (Movement movement in movements.Values)
                {
                    string year = movement.DateMovement.ToString().Substring(6, 4);
                    
                    if (!searchByYearCB.Items.Contains(year))
                    {
                        searchByYearCB.Items.Add(year);
                    }
                }
            }
        }

        private void LoadSearchPanelMonths()
        {
            searchByMonthCB.Items.Clear();
            searchByMonthCB.Items.Add("-");

            foreach (Months month in Enum.GetValues(typeof(Months)))
            {
                searchByMonthCB.Items.Add(month);
            }

        }

        private void LoadSearchPanelDays(int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            searchByDayCB.Items.Clear();
            searchByDayCB.Items.Add("-");
            for (int i = 1; i<=daysInMonth; i++)
            {
                searchByDayCB.Items.Add(i);
            }
        }

        private void IntervalDateRB_CheckedChanged(object sender, EventArgs e)
        {            
            CleanDateControls();
            DeactivateDateControls();
            ActivateIntervalDateControls();
        }

        private void DateRB_CheckedChanged(object sender, EventArgs e)
        {            
            CleanIntervalDateControls();
            DeactivateIntervalDateControls();
            ActivateDateControls();
        }

        private void CleanDateControls() 
        {
            searchByYearCB.SelectedItem = null;
            searchByMonthCB.SelectedItem = null;
            searchByDayCB.SelectedItem = null;
        }

        private void CleanIntervalDateControls()
        {
            dateStartTB.Text = null;
            dateEndTB.Text = null;
        }
        private void DeactivateDateControls()
        {
            searchByYearCB.Enabled = false;
            searchByMonthCB.Enabled = false;
            searchByDayCB.Enabled = false;
        }

        private void DeactivateIntervalDateControls() 
        {
            dateStartTB.Enabled = false;
            dateEndTB.Enabled = false;
        }

        private void ActivateDateControls()
        {
            searchByYearCB.Enabled = true;
            searchByMonthCB.Enabled = true;
            searchByDayCB.Enabled = true;
        }

        private void ActivateIntervalDateControls()
        {
            dateStartTB.Enabled = true;
            dateEndTB.Enabled = true;
        }

        private void searchByMonthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchByDayCB.SelectedItem = null;
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex.Equals(0))
            {
                comboBox.SelectedItem = null;
            }
            SearchMovement();
        }

        private void searchByDayCB_DropDown(object sender, EventArgs e)
        {
            if (searchByYearCB.SelectedItem != null && searchByMonthCB.SelectedItem != null)
            {
                try
                {
                    int year = int.Parse(searchByYearCB.SelectedItem.ToString());
                    //int month = months[searchByMonthCB.SelectedItem.ToString()];
                    Months monthEnum = (Months)Enum.Parse(typeof(Months), searchByMonthCB.SelectedItem.ToString());
                    int month = (int)monthEnum;
                    LoadSearchPanelDays(year, month);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            SearchMovement();
        }

        private void searchByYearCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex.Equals(0))
            {
                comboBox.SelectedItem = null;
            }
            SearchMovement();
        }

        private void searchByDayCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex.Equals(0))
            {
                comboBox.SelectedItem = null;
            }
            SearchMovement();
        }

        private void SearchTB_Enter(object sender, EventArgs e)
        {
            if (SearchTB.Text.Equals("Cerca"))
            {
                SetTextForSearchBox();
            }
        }

        private void SetTextForSearchBox()
        {
            SearchTB.Text = string.Empty;
            SearchTB.ForeColor = Color.Black;
            SearchTB.Font = new Font("Arial", 12);
        }

        private void SearchTB_Leave(object sender, EventArgs e)
        {
            if (SearchTB.Text.Equals(string.Empty))
            {
                ResetStandardTextForSearchBox();
            }
        }

        private void ResetStandardTextForSearchBox()
        {
            SearchTB.Text = "Cerca";
            SearchTB.ForeColor = System.Drawing.SystemColors.ScrollBar;
            SearchTB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void SearchTB_TextChanged(object sender, EventArgs e)
        {
            if (!SearchTB.Text.Equals("Cerca") && SearchTB.Font.FontFamily.Name != "Times New Roman")
            {
                SearchMovement();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (SearchFilterPanel.Visible.Equals(true))
            {
                SearchFilterPanel.Visible = false;
                SearchFilterPanel.Enabled = false;
                AlertComboBoxSearchValues();
            }

            else
            {
                SearchFilterPanel.Visible = true;
                SearchFilterPanel.Enabled = true;
            }
        }

        private void AlertComboBoxSearchValues()
        {
            foreach (Control control in SearchFilterPanel.Controls)
            {
                if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox comboBox = control as System.Windows.Forms.ComboBox;
                    if (!(comboBox.SelectedItem is null))
                    {
                        //AllertImage.Visible = true;
                        SearchBtn.Image = Properties.Resources.exclamation;
                        return;
                    }
                }
            }

            //AllertImage.Visible = false;
            SearchBtn.Image = Properties.Resources.hamburger;
        }

        private void movementSearchCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex.Equals(0))
            {
                comboBox.SelectedItem = null;
            }
            SearchMovement();
        }



        private string ObtainMonthInStringNumber()
        {
            string month = string.Empty;
            if (!(searchByMonthCB.Text is null) && !(searchByMonthCB.Text.Equals(string.Empty)))
            {
                month = ManageMonths.GetNumberMonth(searchByMonthCB.Text).ToString();
            }
            return month;
        }

        private void SearchMovement()
        {
            string textToSearch;
            Dictionary<int, Movement> movements = new Dictionary<int, Movement>();
            string month = ObtainMonthInStringNumber();

            if (SearchTB.Text.Equals("Cerca") && SearchTB.Font.FontFamily.Name.Equals("Times New Roman"))
            {
                textToSearch = string.Empty;
            }

            else
            {
                textToSearch = SearchTB.Text;
            }

            if (DateRB.Checked)
            {
                string query = MovementQueries.GetSpecificDateQuery(movementSearchCB.Text, searchByYearCB.Text, month, searchByDayCB.Text, textToSearch);
                movements = _daoMovement.GetMovementsSearch(query, movementSearchCB.Text, searchByYearCB.Text, month, searchByDayCB.Text, textToSearch);
            }
            else
            {
                if (IsValidDate(dateStartTB.Text) && IsValidDate(dateEndTB.Text))
                {
                    string query = MovementQueries.GetIntervalDateQuery(movementSearchCB.Text, dateStartTB.Text, dateEndTB.Text, textToSearch);
                    movements = _daoMovement.GetMovementsSearch(query, movementSearchCB.Text, dateStartTB.Text, dateEndTB.Text, textToSearch);
                }
            }
            UpdateDataGridView(movements);
        }

        private void DeleteFilterSearchBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in SearchFilterPanel.Controls)
            {
                if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)control;
                    comboBox.SelectedItem = null;
                }
                else if(control is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)control;
                    textBox.Text = null;
                }
            }
            //AllertImage.Visible = false;
            SearchBtn.Image = Properties.Resources.hamburger;
            SearchFilterPanel.Visible = false;
            SearchFilterPanel.Enabled = false;
            ResetStandardTextForSearchBox();
        }

        private void IsStartDateBeforeEndDate(TextBox textBoxDate)
        {
            DateTime dateStart;
            DateTime dateEnd;

            dateStart = DateTime.Parse(dateStartTB.Text);
            dateEnd = DateTime.Parse(dateEndTB.Text);

            if (dateEnd < dateStart)
            {
                if (dateToolTip != null)
                {
                    dateToolTip.Hide(textBoxDate);
                }
                dateToolTip.InitialDelay = 500;
                dateToolTip.AutoPopDelay = 5000;
                dateToolTip.ReshowDelay = 500;
                dateToolTip.ShowAlways = true;
                dateToolTip.Show("La data di fine non può essere precedente alla data di inizio.", textBoxDate, 0, -20, 5000);
            }
        }

        private bool IsValidDate(string stringDate)
        {            
            return DateTime.TryParse(stringDate, out _);            
        }
    }
}
