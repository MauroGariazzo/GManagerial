using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GManagerial.Products.ChildForms;
using GManagerial.WareHouse.ChildForms;
using GManagerial.WareHouse.ChildForms.LoadMerchForm;
using GManagerial.WareHouse.LoadMerchForm;

namespace GManagerial.WareHouse
{
    public partial class Warehouse : Form
    {
        private ItemTag selectedWareHouse;
        private int selectedWareHouseID;
        private int selectedRow;
        private List<int> idDGVRows;
        private List<int> idDBRows;
        public Warehouse()
        {
            this.selectedWareHouse = new ItemTag();
            this.selectedWareHouseID = 0;   
            this.selectedRow = 0;
            this.idDGVRows = new List<int>();
            InitializeComponent();
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            WarehouseMGM.LoadWareHouseNamesForComboBox(selectWarehouseCB);
            WareHouseProductMGM.LoadWareHouse(selectedWareHouseID, WareHouseDGV);
            ProductsMGM.AllBrands(BrandCB);
            ProductsMGM.LoadCategories(categoryCB);

            try
            {
                selectWarehouseCB.SelectedIndex = Properties.Settings.Default.LastSelectedWarehouseId; //ultimo magazzino selezionato
                selectedWareHouse = (ItemTag)selectWarehouseCB.SelectedItem;
                selectedWareHouseID = (int)selectedWareHouse.Tag;   
            }

            catch (System.ArgumentOutOfRangeException)
            {
                selectedWareHouseID = -1;
            }
            LoadTable();
        }

        private void LoadTable()
        {
            WareHouseDGV.Columns[1].HeaderText = "Id prodotto";
            WareHouseDGV.Columns[2].HeaderText = "Nome Prodotto";
            WareHouseDGV.Columns[3].HeaderText = "Id Fornitore";
            WareHouseDGV.Columns[4].HeaderText = "Fornitore";
            WareHouseDGV.Columns[5].HeaderText = "Giacenza";
            WareHouseDGV.Columns[6].HeaderText = "Minimo di scorta";

            WareHouseDGV.Columns[0].Width = 80;
            WareHouseDGV.Columns[1].Width = 100; 
            WareHouseDGV.Columns[2].Width = 150; 
            WareHouseDGV.Columns[3].Width = 100; 
            WareHouseDGV.Columns[4].Width = 120; 
            WareHouseDGV.Columns[5].Width = 80; 
           // WareHouseDGV.Columns[6].Width = 50;
        }

        private void LoadMerchItem_Click(object sender, EventArgs e)
        {
            if (checkWHselected())
            {
                LoadMerchForm.LoadMerchForm lmf = new LoadMerchForm.LoadMerchForm("LoadWH", selectedWareHouseID);
                lmf.ShowDialog();
                WareHouseProductMGM.LoadWareHouse(selectedWareHouseID, WareHouseDGV);
            }

            else
            {
                FormLogicGUIObsolete.SelectElement("magazzino");
            }
        }

        private void newBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToolStripButton button = sender as ToolStripButton;
                if (button != null && button.Owner is ToolStrip toolStrip && toolStrip.Parent is Control parentControl)
                {
                    Point buttonLocationOnScreen = button.Owner.PointToScreen(button.Bounds.Location);    //ottiene le coordinate del pulsante button rispetto allo schermo
                    Point buttonLocationOnParentControl = parentControl.PointToClient(buttonLocationOnScreen);  //ottiene le coordinate del pulsante button rispetto al contenitore(form)


                    buttonLocationOnParentControl.Y += button.Height;
                    newBtnCMS.Show(parentControl, buttonLocationOnParentControl, ToolStripDropDownDirection.BelowRight);
                }
            }
        }

        
        private void selectWarehouseCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastSelectedWarehouseId = selectWarehouseCB.SelectedIndex;
            Properties.Settings.Default.Save();

            selectedWareHouse = (ItemTag)selectWarehouseCB.SelectedItem;
            selectedWareHouseID = (int)selectedWareHouse.Tag;

            WareHouseProductMGM.LoadWareHouse(selectedWareHouseID, WareHouseDGV);
        }


        private bool checkWHselected()
        {
            if (selectWarehouseCB.SelectedIndex != -1 && selectWarehouseCB.Items.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void deleteItem_Click(object sender, EventArgs e)
        {

        }

        private void whBtn_Click(object sender, EventArgs e)
        {
            CreateWareHouse newWH = new CreateWareHouse(selectWarehouseCB);
            newWH.ShowDialog();

            Warehouse_Load(sender, e);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {

        }

        private void WareHouseDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            selectAllRows.Location = new Point(WareHouseDGV.Columns[0].Width / 2 - 32, selectAllRows.Location.Y);
        }

        private void selectAllRows_CheckedChanged(object sender, EventArgs e)
        {
            RowLogic.selectAllRows_CheckedChanged(selectAllRows, WareHouseDGV, idDGVRows, idDBRows, "");
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            FormLogicGUIObsolete.NECCC(AnagrPanel, false, false, new object[] { stripBtns, confirmBtn, cancelBtn, barcBtn, ImageBtn });

            ProductsMGM.EditProduct(codArticleTB, snTB, manfDateTB, descriptionTB, null, null, null,
             null, null, null, null, null, null, null, null, null, null, null, null, 
             ObtainID.ObtainIDelements.ObtainIdElement(WareHouseDGV.SelectedRows[0].Index, WareHouseDGV, "Product_ID"),
             BrandCB, categoryCB, subCategoryCB); //dati generali del prodotto

            InsertSupplierWareHouseStockIntoTB();
            InsertUnderStockIntoTB();
        }

        private void InsertSupplierWareHouseStockIntoTB()
        {
            try
            {
                DataGridViewRow selectedRow = WareHouseDGV.SelectedRows[0];
                supplierTB.Text = selectedRow.Cells[4].Value.ToString();
                wareHouseTB.Text = selectWarehouseCB.SelectedItem.ToString();
                stockTB.Text = selectedRow.Cells[5].Value.ToString();
            }

            catch 
            {
                return;
            }   
        }

        private void InsertUnderStockIntoTB()
        {
            int product_id = ObtainID.ObtainIDelements.ObtainIdElement(WareHouseDGV.SelectedRows[0].Index, WareHouseDGV, "Product_ID");
            int supplier_id = ObtainID.ObtainIDelements.ObtainIdElement(WareHouseDGV.SelectedRows[0].Index, WareHouseDGV, "Supplier_ID");

            uStockTB.Text = WareHouse.WareHouseProductMGM.ShowUnderStockProduct(product_id, supplier_id, selectedWareHouseID).ToString();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            RowLogic.DisableAllCheckBoxes(WareHouseDGV);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            FormLogicGUIObsolete.NECCC(AnagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, barcBtn, ImageBtn });
            InsertMinStockToDB();
            FormLogicGUIObsolete.DisableAndCleanTextBox(AnagrPanel);

           
            WareHouseProductMGM.LoadWareHouse(selectedWareHouseID, WareHouseDGV);
        }

       

        private void InsertMinStockToDB()
        {
            int product_id = ObtainID.ObtainIDelements.ObtainIdElement(WareHouseDGV.SelectedRows[0].Index, WareHouseDGV, "Product_ID");
            int supplier_id = ObtainID.ObtainIDelements.ObtainIdElement(WareHouseDGV.SelectedRows[0].Index, WareHouseDGV, "Supplier_ID");

            int result;
            if (int.TryParse(uStockTB.Text, out result))
            {
                WareHouseProductMGM.InsertUnderStockIntoProduct(product_id, supplier_id, selectedWareHouseID, result);
            }

            else
            {
                WareHouseProductMGM.InsertUnderStockIntoProduct(product_id, supplier_id, selectedWareHouseID, 0);
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (FormLogicGUIObsolete.PrintCancelEdit())
            {
                FormLogicGUIObsolete.NECCC(AnagrPanel, true, true, new object[] { stripBtns, confirmBtn, cancelBtn, barcBtn, ImageBtn });
                FormLogicGUIObsolete.DisableAndCleanTextBox(AnagrPanel);
            }
        }

        private void uStockTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsDigitInput.OnlyNums_KeyPress(sender, e);
        }

        private void lMerchBtn_Click(object sender, EventArgs e)
        {
            ChildForms.InsertProdInf insertProdInf = new ChildForms.InsertProdInf(ObtainID.ObtainIDelements.ObtainIdElement
                (WareHouseDGV.SelectedRows[0].Index, WareHouseDGV, "Product_ID"), codArticleTB.Text);
            insertProdInf.ShowDialog();

            if (InsertProdInf.isOK)
            {
                InsertDataToDB();
                WareHouseProductMGM.LoadWareHouse(selectedWareHouseID, WareHouseDGV);
                DataGridViewRow selectedRow = WareHouseDGV.SelectedRows[0];
                stockTB.Text = selectedRow.Cells[5].Value.ToString();
            }
        }

        private void InsertDataToDB()
        {
            int idProduct = (int)InsertProdInf.prodInf["product_id"];
            int idSupplier = (int)InsertProdInf.prodInf["supplier_id"];
            int quantity = (int)InsertProdInf.prodInf["quantity"];
           // string productName = InsertProdInf.prodInf["product_name"].ToString();
           // string supplierName = InsertProdInf.prodInf["company_name"].ToString();
            string um = InsertProdInf.prodInf["um"].ToString();
            int selectedWareHouseID = (int)InsertProdInf.prodInf["wareHouse_id"];

            //
            WareHouseProductMGM.LoadMerchInWareHouseDB(idProduct, idSupplier, quantity, selectedWareHouseID, um,
                'e');
            

            

        }

        private void WHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whBtn_Click(sender, e);
        }
    }
}

