using GManagerial.DBConnectors;
using GManagerial.WareHouse.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.Documents.OrderDocument.ChildForms
{
    public partial class AddWareHouse : Form
    {
        private DBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");

        public AddWareHouse()
        {
            InitializeComponent();
        }

        private void AddWareHouse_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            DAOWareHouse daoWarehouse = new DAOWareHouse(_dbConnector);
            Dictionary<int, Warehouse> warehouses = daoWarehouse.GetAll();
            warehouseCB.Items.Clear();

            foreach(Warehouse warehouse in warehouses.Values)
            {
                warehouseCB.Items.Add(warehouse);
            }
            warehouseCB.DisplayMember = "Warehouse_Name";
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if(warehouseCB.SelectedItem != null) { 
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else { 
                MessageBox.Show("Seleziona un magazzino", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Warehouse GetResultObject()
        {
            return warehouseCB.SelectedItem as Warehouse;
        }
    }
}
