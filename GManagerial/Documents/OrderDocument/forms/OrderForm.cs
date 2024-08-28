using GManagerial.DBConnectors;
using GManagerial.Documents.OrderDocument.models;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using GManagerial.WareHouse.ChildForms;
using GManagerial.Documents.OrderDocument.ChildForms;
using GManagerial.WareHouse.models;

namespace GManagerial.Documents.OrderDocument.forms
{
    public partial class OrderForm : Form
    {
        internal IsNewEditCopyDeleteEnum _isNewEditCopyDelete;

        private DBConnector _dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
        public OrderForm()
        {
            InitializeComponent();

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            DAOOrder daoOrder = new DAOOrder(_dbConnector);
            List<Order>orders = daoOrder.GetAll();
            LoadOrdersInDatagridview(orders);
        }

        private void LoadOrdersInDatagridview(List<Order> orders)
        {
            foreach(Order order in orders)
            {
                int rowIndex = OrderDataGridView.Rows.Add();
                OrderDataGridView.Rows[rowIndex].Cells[0].Value = order.Id;
                OrderDataGridView.Rows[rowIndex].Cells[1].Value = order.Supplier.SupplierName;
                OrderDataGridView.Rows[rowIndex].Cells[2].Value = order.CreationDate;
                OrderDataGridView.Rows[rowIndex].Cells[3].Value = order.TotalDocumentAmount;
            }
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            _isNewEditCopyDelete = IsNewEditCopyDeleteEnum.New;
            Order order = new Order();
            AddWareHouse addWareHouse = new AddWareHouse();
            Warehouse warehouse = new Warehouse();

            if (addWareHouse.ShowDialog() == DialogResult.OK)
            {
                warehouse = addWareHouse.GetResultObject();
            }

            if (warehouse != null && order != null)
            {
                AddSupplier addSupplier = new AddSupplier(order, warehouse, UpdateDataGridView);
            }

        }

        private void UpdateDataGridView()
        {
            /*if (SelectWarehouseCB.SelectedItem != null)
            {
                _wareHouseProducts = _daoWareHouseProduct.GetAll(SelectWarehouseCB.SelectedItem as Warehouse);
                WareHouseStockDGV.Rows.Clear();

                foreach (WareHouseProduct wareHouseProduct in _wareHouseProducts.Values)
                {
                    int rowIndex = WareHouseStockDGV.Rows.Add();
                    WareHouseStockDGV.Rows[rowIndex].Cells[0].Value = wareHouseProduct.Id;
                    WareHouseStockDGV.Rows[rowIndex].Cells[1].Value = wareHouseProduct.ProductName;
                    WareHouseStockDGV.Rows[rowIndex].Cells[2].Value = wareHouseProduct.Description;
                    WareHouseStockDGV.Rows[rowIndex].Cells[3].Value = wareHouseProduct.Stock;
                    WareHouseStockDGV.Rows[rowIndex].Cells[6].Value = wareHouseProduct.ResizedImage;
                }
            }*/
        }
    }
}
