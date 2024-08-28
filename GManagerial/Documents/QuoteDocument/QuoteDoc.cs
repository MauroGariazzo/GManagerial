using GManagerial.QuoteDocForms.ChildForms;
using GManagerial.WareHouse.ChildForms;
using GManagerial.WareHouse.models.WareHouseProducts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.QuoteDocForms.models;

namespace GManagerial
{
    public partial class QuoteDoc : Form
    {
        public QuoteDoc()
        {
            InitializeComponent();           
        }

        private void QuoteDoc_Load(object sender, EventArgs e)
        {
                              
        }


        private void LoadTable()
        {
            QuoteDgv.Columns[0].HeaderText = "n°";
            QuoteDgv.Columns[1].HeaderText = "Cliente";
            QuoteDgv.Columns[2].HeaderText = "Data";
            QuoteDgv.Columns[3].HeaderText = "Stato";
            QuoteDgv.Columns[4].HeaderText = "Totale";
            QuoteDgv.Columns[5].HeaderText = "Acconto";
        }

        private void newDoc_Click(object sender, EventArgs e)
        {
            AddNewCustomer addNewCustomer = new AddNewCustomer();
            addNewCustomer.PopulateDictionaryRequested += SecondForm_PopulateDictionaryRequested;
            addNewCustomer.ShowDialog();
        }

        private void SecondForm_PopulateDictionaryRequested(object sender, QuoteDocument document)
        {
            /*if (!_warehouseproducts.Keys.Contains(warehouseproduct.ProductProps.ID))
            {
                _warehouseproducts.Add((warehouseproduct.ProductProps.ID), warehouseproduct);
                int rowIndex = OrderDataGridView.Rows.Add();
                OrderDataGridView.Rows[rowIndex].Cells[0].Value = warehouseproduct.ProductProps.ID;
                OrderDataGridView.Rows[rowIndex].Cells[1].Value = warehouseproduct.ProductProps.ProductName;
                OrderDataGridView.Rows[rowIndex].Cells[2].Value = warehouseproduct.ProductProps.Description;
                OrderDataGridView.Rows[rowIndex].Cells[3].Value = warehouseproduct.Stock;
                OrderDataGridView.Rows[rowIndex].Cells[4].Value = warehouseproduct.PriceSupplier;

                DataGridViewComboBoxCell comboBoxCell = OrderDataGridView.Rows[rowIndex].Cells[6] as DataGridViewComboBoxCell;
                decimal amount = Math.Round(CalculateAmount(rowIndex), 2);

                comboBoxCell.Value = comboBoxCell.Items[2];
                _vatValues.Add(rowIndex, Convert.ToString(comboBoxCell.Items[2]));

                OrderDataGridView.Rows[rowIndex].Cells[7].Value = $"{amount.ToString("N2")}€";
                CalculateVat();

                this._totalNet += amount;
                TotalNetValue.Text = $"{Convert.ToString(this._totalNet)}€";
                TotalRecalculate();
            }

            else
            {
                int quantity = Convert.ToInt32(OrderDataGridView.SelectedRows[0].Cells[3].Value);
                quantity += warehouseproduct.Stock;
                OrderDataGridView.SelectedRows[0].Cells[3].Value = quantity;
            }*/
        }
    }
    
}
