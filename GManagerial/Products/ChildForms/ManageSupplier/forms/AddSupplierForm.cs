using GManagerial.DBConnectors;
using GManagerial.Products.ChildForms.AddSupplier.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GManagerial.Products.ChildForms
{
    internal partial class AddSupplierForm : Form
    {
        private Dictionary<int, SupplierProduct> _unselectedSuppliersTemp = new Dictionary<int, SupplierProduct>();
        private Dictionary<int, SupplierProduct> _selectedSuppliersTemp = new Dictionary<int, SupplierProduct>();

        private Dictionary<int, SupplierProduct> _supplierToAdd = new Dictionary<int, SupplierProduct>();


        private IDBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        private UpdateComboBox _updateComboBox;
        public AddSupplierForm(Dictionary<int, SupplierProduct> unselectedSuppliersTemp, Dictionary<int, SupplierProduct> selectedSuppliersTemp, Dictionary<int, SupplierProduct> supplierToAdd, UpdateComboBox updateComboBox)
        {
            InitializeComponent();
            this._unselectedSuppliersTemp = unselectedSuppliersTemp;
            this._selectedSuppliersTemp = selectedSuppliersTemp;
            this._updateComboBox = updateComboBox;
            this._supplierToAdd = supplierToAdd;
        }



        private void ExitBtn_Click(object sender, EventArgs e)
        {
            _updateComboBox();
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(SupplierLB.SelectedItems.Count >= 1)
            {
                SupplierProduct supplierProduct = (SupplierProduct)SupplierLB.SelectedItem;
                _unselectedSuppliersTemp.Remove(supplierProduct.SupplierProps.ID);
                _selectedSuppliersTemp.Add(supplierProduct.SupplierProps.ID, supplierProduct);
                _supplierToAdd.Add(supplierProduct.SupplierProps.ID, supplierProduct);

                MessageBox.Show($"{supplierProduct.SupplierProps.SupplierName} è stato inserito tra i fornitori del prodotto", "Caricamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            OnLoadListBox();
        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {
            OnLoadListBox();
        }

        private void OnLoadListBox()
        {
            SupplierLB.Items.Clear();

            foreach (SupplierProduct supplierProduct in _unselectedSuppliersTemp.Values)
            {
                SupplierLB.Items.Add(supplierProduct);
            }

            SupplierLB.Format += (sender, e) =>
            {
                if (e.ListItem is SupplierProduct supplierProduct)
                {
                    e.Value = supplierProduct.SupplierProps.SupplierName; // Impostare il valore di visualizzazione come il nome del fornitore
                }
            };
        }
    }
}
