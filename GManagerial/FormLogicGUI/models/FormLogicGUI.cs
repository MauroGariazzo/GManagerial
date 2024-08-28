using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GManagerial
{
    internal class FormLogicGUI
    {
        public FormLogicGUI() 
        {

        }   


        public void ConfirmAndCancelButtonLogic(Panel panel, TabControl tabs, System.Windows.Forms.ComboBox[] comboBoxes, System.Windows.Forms.TextBox[] textBoxes, 
            System.Windows.Forms.Button[] buttonList, ToolStrip stripBtns, DataGridView dataGridView)
        {
            EnableDataGridView(dataGridView);
            CleanTextBox(textBoxes);
            CleanComboBox(comboBoxes);
            DisablePanel(panel);
            DisableTab(tabs);
            GetInvisibleButtons(buttonList);
            EnableStripButtons(stripBtns);
        }

        public void NewEditCopyButtonEnable(Panel panel, TabControl tabs, System.Windows.Forms.ComboBox[] comboBoxes, System.Windows.Forms.TextBox[] textBoxes,
            System.Windows.Forms.Button[] buttonList, ToolStrip stripBtns, DataGridView dataGridView)
        {
            DisableDataGridView(dataGridView);
            EnablePanel(panel);
            EnableTab(tabs);
            GetVisibleButtons(buttonList);
            DisableStripButtons(stripBtns);
        }

        private void EnableDataGridView(DataGridView dataGridView) 
        {
            if (dataGridView != null)
            {
                dataGridView.Enabled = true;
            }
        }

        private void DisableDataGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.Enabled = false;
            }
        }

        private void DisableStripButtons(ToolStrip stripBtns)
        {
            stripBtns.Enabled = false;
        }

        private void EnableStripButtons(ToolStrip stripBtns)
        {
            stripBtns.Enabled = true;
        }

        public void EnableComboBox(System.Windows.Forms.ComboBox[] comboBoxes)
        {
            foreach (System.Windows.Forms.ComboBox comboBox in comboBoxes)
            {
                comboBox.Enabled = true;
            }
        }

        public void DisableComboBox(System.Windows.Forms.ComboBox[] comboBoxes)
        {
            foreach(System.Windows.Forms.ComboBox comboBox in comboBoxes)
            {
                comboBox.Enabled = false;
            }
        }

        public void EnableLabel(System.Windows.Forms.Label[] labels)
        {
            foreach (System.Windows.Forms.Label label in labels)
            {
                label.ForeColor = System.Drawing.Color.Black;
            }
        }
        public void DisableLabel(System.Windows.Forms.Label[] labels) 
        {
            foreach (System.Windows.Forms.Label label in labels)
            {
                label.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void EnablePanel(Panel panel)
        {
            if(panel != null) { 
                panel.Enabled = true;
            }
        }

        private void DisablePanel(Panel panel)
        {
            panel.Enabled = false;
        }

        public void EnableTextBox(System.Windows.Forms.TextBox[] textBoxes)
        {
            foreach (System.Windows.Forms.TextBox textBox in textBoxes)
            {
                textBox.Enabled = true;
            }
        }

        public void DisableTextBox(System.Windows.Forms.TextBox[] textBoxes)
        {
            foreach(System.Windows.Forms.TextBox textBox in textBoxes)
            {
                textBox.Enabled = false;
            }
        }

        public void CleanTextBox(System.Windows.Forms.TextBox[] textBoxes)
        {
            foreach(System.Windows.Forms.TextBox textbox in textBoxes)
            {
                textbox.Text = string.Empty;
            }
        }

        public void CleanComboBox(System.Windows.Forms.ComboBox[] comboBoxes)
        {
            foreach (System.Windows.Forms.ComboBox comboBox in comboBoxes)
            {
                comboBox.SelectedItem = null;
            }
        }

        private void EnableTab(TabControl tabControl)
        {
            if (tabControl != null)
            {
                tabControl.Enabled = true;
            }
        }

        private void DisableTab(TabControl tabControl)
        {
            if (tabControl != null)
            { 
                tabControl.Enabled = false;
            }
        }

        private void GetVisibleButtons(System.Windows.Forms.Button[] buttons)
        {
            if(buttons != null) { 
                foreach(System.Windows.Forms.Button button in buttons)
                {
                    button.Visible = true;
                }
            }
        }

        private void GetInvisibleButtons(System.Windows.Forms.Button[] buttons)
        {
            foreach (System.Windows.Forms.Button button in buttons)
            {
                button.Visible = false;
            }
        }


        public void SelectElement(string element)
        {
            MessageBox.Show("Seleziona prima un " + element + " o crealo", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public Boolean PrintCancelEdit()
        {
            DialogResult result = MessageBox.Show("Sei sicuro di voler annullare il caricamento dei dati?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        public void PrintDateMessage()
        {
            MessageBox.Show("Inserisci una data corretta", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MultipleElementsSelected()
        {
            MessageBox.Show("Non posso modificare più di un elemento alla volta", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
