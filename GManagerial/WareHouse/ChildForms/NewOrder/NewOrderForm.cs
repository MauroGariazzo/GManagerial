using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GManagerial.Attachments;
using GManagerial.DBConnectors;
using GManagerial.Products;
using GManagerial.WareHouse.models;
using GManagerial.WareHouse.models.Movements;
using GManagerial.WareHouse.models.WareHouseProducts;
using Microsoft.Extensions.Primitives;


namespace GManagerial.WareHouse.ChildForms.NewOrder
{
    internal partial class NewOrderForm : Form
    {
        private int _currentRowIndex = 0;
        private OrderDocument _orderDocument;
        private Warehouse _selectedWareHouse;
        private Supplier _supplier;
        private Dictionary<int, WareHouseProduct> _warehouseproducts;
        private Dictionary<int, string> _vatValues;
        private decimal _totalNet;
        private Movement _tempMovement;
        private DAOMovement _daoMovement;
        private DBConnector _dbConnector;
        private DAODetailsMovement _daoDetailsMovement;
        private DAOWarehouseProduct _daoWareHouseProduct;
        private DAOAttachments _daoAttachment;
        private DAOObjectAttachments _daoObjectAttachments;
        public NewOrderForm(Supplier supplier, Warehouse warehouse)
        {            
            InitializeComponent();
            this._dbConnector = new DBConnector("Data Source=DESKTOP-TH1C0HD;Initial Catalog=Gmanagerial;Integrated Security=True");
            this._selectedWareHouse = warehouse;
            this._supplier = supplier;
            this._warehouseproducts = new Dictionary<int, WareHouseProduct>();
            this._vatValues = new Dictionary<int, string>();
            this._totalNet = 0.00m;
            this._tempMovement = new Movement() { WareHouseFK = _selectedWareHouse.ID, MovementType = "Carico" };
            this._daoMovement = new DAOMovement(_dbConnector);
            this._daoDetailsMovement = new DAODetailsMovement(_dbConnector);
            this._daoWareHouseProduct = new DAOWarehouseProduct(_dbConnector);
            this._orderDocument = new OrderDocument(_currentRowIndex, _supplier, OrderDataGridView, TotalNetValue, TotalOrderLbl, VatValueLbl);
            this._daoAttachment = new DAOAttachments(_dbConnector, AttachmentQuery.INSERT_ATTACHMENT, string.Empty); //delete attachment non servirebbe nemmeno in quanto non
            //dobbiamo avere la possibilità di cancellare gli allegati da questo form
            this._daoObjectAttachments = new DAOObjectAttachments(_dbConnector, string.Empty, AttachmentQuery.INSERT_WH_MOVEMENT,string.Empty);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(_selectedWareHouse, _supplier);
            addProduct.PopulateDictionaryRequested += SecondForm_PopulateDictionaryRequested;
            addProduct.ShowDialog();
        }

        private void SecondForm_PopulateDictionaryRequested(object sender, WareHouseProduct warehouseproduct)
        {
            if (!_warehouseproducts.Keys.Contains(warehouseproduct.ProductProps.ID))
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
            }
        }

        private void NetTotalRecalculate()
        {
            _totalNet = 0.00m;

            foreach (DataGridViewRow row in OrderDataGridView.Rows)
            {
                string netPriceProduct = Convert.ToString(row.Cells[7].Value);
                netPriceProduct = netPriceProduct.Substring(0, netPriceProduct.LastIndexOf("€"));
                _totalNet += Convert.ToDecimal(netPriceProduct);
            }
            TotalNetValue.Text = $"{_totalNet.ToString()}€";
        }

        private decimal CalculateAmount(int row)
        {
            string stringNetPrice = Convert.ToString(OrderDataGridView.Rows[row].Cells[4].Value);
            decimal decimalNetPrice = FromStringToDecimalValue(stringNetPrice);

            string stringDiscountPercentual = Convert.ToString(OrderDataGridView.Rows[row].Cells[5].Value);
            decimal decimalDiscountPercentual = TransformPercentualStringInDecimal(stringDiscountPercentual);

            decimal valueDiscountPrice = (decimalDiscountPercentual / 100) * decimalNetPrice;
            decimal amount = decimalNetPrice - valueDiscountPrice;

            amount *= Convert.ToInt32(OrderDataGridView.Rows[row].Cells[3].Value);

            return amount;
        }
        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            SelectedSupplier.Text = _supplier.SupplierName;
        }

        private void OrderDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OrderDataGridView.SelectedRows[0].Index != -1 && (OrderDataGridView.CurrentCell.ColumnIndex == 3 || OrderDataGridView.CurrentCell.ColumnIndex == 6))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }

            else if (OrderDataGridView.SelectedRows[0].Index != -1 && (OrderDataGridView.CurrentCell.ColumnIndex == 4 || OrderDataGridView.CurrentCell.ColumnIndex == 5))
            {
                if (!(OrderDataGridView.EditingControl is null))
                {
                    string value = (OrderDataGridView.EditingControl as DataGridViewTextBoxEditingControl).Text;

                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && !e.KeyChar.Equals(','))
                    {
                        e.Handled = true;
                    }

                    if ((e.KeyChar.Equals(',') && value.Contains(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void OrderDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(OrderDataGridView_KeyPress);

            if (OrderDataGridView.CurrentCell is DataGridViewComboBoxCell)
            {
                System.Windows.Forms.ComboBox comboBox = e.Control as System.Windows.Forms.ComboBox;
                if (comboBox != null)
                {
                    comboBox.SelectedIndexChanged += VATColumnCB_SelectedIndexChanged;
                }
            }

        }

        private void VATColumnCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox comboBox = sender as System.Windows.Forms.ComboBox;
            if (!_vatValues.ContainsKey(Convert.ToInt32(OrderDataGridView.SelectedRows[0].Index)))
            {
                _vatValues.Add(OrderDataGridView.SelectedRows[0].Index, Convert.ToString(comboBox.SelectedItem));
            }

            else
            {
                _vatValues[Convert.ToInt32(OrderDataGridView.SelectedRows[0].Index)] = Convert.ToString(comboBox.SelectedItem);
            }
            CalculateVat();
            TotalRecalculate();
        }


        private void CalculateVat()
        {
            decimal totalVat = 0.0M;

            foreach (KeyValuePair<int, string> couple in _vatValues)
            {
                decimal vat = TransformPercentualStringInDecimal(couple.Value);

                int idRow = Convert.ToInt32(OrderDataGridView.Rows[couple.Key].Cells[0].Value);

                string amountDataGridView = OrderDataGridView.Rows[couple.Key].Cells[7].Value.ToString();

                if (!amountDataGridView.Contains("€"))
                {
                    MessageBox.Show("Errore nel calcolo dell'iva");
                    return;
                }

                decimal amount = FromStringToDecimalValue(amountDataGridView.Substring(0, amountDataGridView.LastIndexOf("€")));
                totalVat += (vat / 100) * amount;
            }
            totalVat = Math.Round(totalVat, 2);

            VatValueLbl.Text = $"{totalVat.ToString()}€";
        }
        private decimal FromStringToDecimalValue(string value)
        {
            decimal decimalValue = 0.0M;
            if (decimal.TryParse(value, out decimalValue))
            {
                return decimalValue;
            }
            return decimalValue;
        }

        private decimal TransformPercentualStringInDecimal(string percentual)
        {
            decimal decimalPercentual = 0.0M;

            if (percentual.Contains("%"))
            {
                percentual = percentual.Substring(0, percentual.LastIndexOf("%"));
            }

            if (Decimal.TryParse(percentual, out decimalPercentual))
            {
                return decimalPercentual;
            }

            return 0.0M;
        }

        private void OrderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                string cellValue = Convert.ToString(OrderDataGridView.CurrentCell.Value);
                WareHouseProduct warehouseProduct = _warehouseproducts[(int)OrderDataGridView.Rows[row].Cells[0].Value];

                if (OrderDataGridView.CurrentCell.ColumnIndex == 3) //quantità
                {
                    ValidateQuantity(cellValue, row, warehouseProduct);
                }

                else if (OrderDataGridView.CurrentCell.ColumnIndex == 4) //prezzo netto
                {
                    ValidatePrice(cellValue, row);
                }


                else if (OrderDataGridView.CurrentCell.ColumnIndex == 5) //sconto
                {
                    ValidateDiscount(row);
                }

                CalculateVat();
                TotalRecalculate();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ValidateQuantity(string cellValue, int row, WareHouseProduct warehouseProduct)
        {
            if (Convert.ToInt32(cellValue) != warehouseProduct.Stock && Convert.ToInt32(cellValue) > 0)
            {
                _warehouseproducts[(int)OrderDataGridView.Rows[row].Cells[0].Value].Stock = Convert.ToInt32(OrderDataGridView.SelectedRows[0].Cells[3].Value);
                decimal amount = Math.Round(CalculateAmount(row), 2); //cambiando la quantità deve ricalcolare anche l'importo
                OrderDataGridView.Rows[row].Cells[7].Value = $"{amount.ToString("N2")}€"; //aggiorno la cella dell'importo
                NetTotalRecalculate(); //ricalcola il netto
            }

            else if (Convert.ToInt32(cellValue).Equals(0) || cellValue.Equals(string.Empty)) //se stai inserendo zero o lasci la cella vuota
            {
                MessageBox.Show("Non puoi inserire una quantità uguale o inferiore a \"zero\"", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OrderDataGridView.Rows[row].Cells[3].Value = _warehouseproducts[(int)OrderDataGridView.Rows[row].Cells[0].Value].Stock;
            }
        }

        private void ValidateDiscount(int row)
        {
            if (!(OrderDataGridView.CurrentCell.Value is null))
            {
                OrderDataGridView.CurrentCell.Value = Convert.ToString(OrderDataGridView.CurrentCell.Value);
                decimal amount = Math.Round(CalculateAmount(row), 2);
                OrderDataGridView.Rows[row].Cells[7].Value = $"{amount.ToString("N2")}€";
                NetTotalRecalculate(); //ricalcola il netto
            }

            else
            {

                decimal amount = Math.Round(CalculateAmount(row), 2);
                OrderDataGridView.Rows[row].Cells[7].Value = $"{amount.ToString("N2")}€";
                NetTotalRecalculate(); //ricalcola il netto
            }
        }

        private void ValidatePrice(string cellValue, int row)
        {
            decimal result;
            if (decimal.TryParse(cellValue, out result))
            {
                if (!(result.Equals(0)) && !(cellValue is null) && !(string.IsNullOrWhiteSpace(cellValue)))
                {
                    decimal price = FromStringToDecimalValue(Convert.ToString(OrderDataGridView.SelectedRows[0].Cells[4].Value));
                    _warehouseproducts[(int)OrderDataGridView.Rows[row].Cells[0].Value].SetPriceSupplier(price.ToString("N2"));
                    decimal amount = Math.Round(CalculateAmount(row), 2);
                    OrderDataGridView.Rows[row].Cells[7].Value = $"{amount.ToString("N2")}€"; //aggiorno la cella dell'importo
                    NetTotalRecalculate(); //ricalcola il netto
                }
            }

                /*else
                {
                    MessageBox.Show("Non puoi inserire un prezzo uguale o inferiore a \"zero\"", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    OrderDataGridView.Rows[row].Cells[4].Value = _warehouseproducts[(int)OrderDataGridView.Rows[row].Cells[0].Value].PriceSupplier;
                }

            }

            else
            {
                //MessageBox.Show("Non puoi inserire una quantità uguale o inferiore a \"zero\"", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OrderDataGridView.Rows[row].Cells[4].Value = _warehouseproducts[(int)OrderDataGridView.Rows[row].Cells[0].Value].PriceSupplier;
            }*/
        }

        private void TotalRecalculate()
        {
            try
            {
                decimal totNet = Convert.ToDecimal(TotalNetValue.Text.Substring(0, TotalNetValue.Text.LastIndexOf("€")));
                decimal vat = Convert.ToDecimal(VatValueLbl.Text.Substring(0, VatValueLbl.Text.LastIndexOf("€")));

                TotalOrderLbl.Text = $"{Convert.ToString(totNet + vat)}€";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == OrderDataGridView.Columns["PriceColumn"].Index && e.RowIndex >= 0)
                {
                    string stringValue = Convert.ToString(OrderDataGridView.Rows[e.RowIndex].Cells["PriceColumn"].Value);
                    decimal value = Convert.ToDecimal(OrderDataGridView.Rows[e.RowIndex].Cells["PriceColumn"].Value);

                    if (!OrderDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode && !value.Equals(","))
                    {
                        if (!stringValue.Contains(','))
                        {
                            if(e.Value is null)
                            {
                                e.Value = 0;
                            }

                            e.Value = $"{e.Value},00 €";
                        }

                        else
                        {
                            e.Value = $"{value} €";
                        }

                        AddDecimal(stringValue, value, e);
                    }

                    else if (!value.Equals(","))
                    {
                        e.Value = value.ToString();
                    }

                    else
                    {
                        e.Value = _warehouseproducts[Convert.ToInt32(OrderDataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value)].PriceSupplier.ToString();
                    }

                    e.FormattingApplied = true;
                }


                else if (e.ColumnIndex == OrderDataGridView.Columns["DiscountColumn"].Index && e.RowIndex >= 0)
                {
                    decimal value = Convert.ToDecimal(OrderDataGridView.Rows[e.RowIndex].Cells["DiscountColumn"].Value);

                    if (!OrderDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)//&& !(value is null))
                    {
                        if (value.Equals(0))
                        {
                            e.Value = string.Empty;
                            return;
                        }

                        e.Value = $"{value.ToString("N2")}%";
                    }

                    else if (!(value.Equals(0)))
                    {
                        e.Value = value.ToString();
                    }

                    else
                    {
                        e.Value = string.Empty;
                    }

                    e.FormattingApplied = true;
                }
            }

            catch
            {
                e.Value = string.Empty;
            }
        }


        private void AddDecimal(string stringValue, decimal value, DataGridViewCellFormattingEventArgs e)
        {
            if (!stringValue.Contains(","))
            {
                value *= 1.00m;
                value = Math.Round(value,2);
                OrderDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
            }

            else
            {
                value = Math.Round(value, 2);
                OrderDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowSomePages = true;
            printDialog.ShowHelp = true;

            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            printDocument.PrintPage += new PrintPageEventHandler(_orderDocument.PrintPageHandler);
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
       
        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            if (OrderDataGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Vuoi cancellare la riga selezionata?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result.Equals(DialogResult.Yes))
                {
                    _warehouseproducts.Remove(Convert.ToInt32(OrderDataGridView.SelectedRows[0].Cells[0].Value));
                    _vatValues.Remove(Convert.ToInt32(OrderDataGridView.SelectedRows[0].Index));
                    OrderDataGridView.Rows.Remove(OrderDataGridView.SelectedRows[0]);
                    //cancellare i dati anche dai dizionari
                }
            }
        }

        private void LoadMerchandise_Click(object sender, EventArgs e)
        {
            if (OrderDataGridView.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Proseguendo verranno aggiornate le giacenze. \n Vuoi andare avanti?", "Informazione", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result.Equals(DialogResult.Yes))
                {
                    int movement_id = InsertMovementInWareHouseDB(); //id del movimento appena creato che mi servirà per inserire questo id in ciascun prodotto movimentato
                    InsertDetailMovementAndProductsInWareHouseDB(movement_id);
                    MessageBox.Show("Carico effettuato", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GenerateTempPrint();
                    // Chiama il metodo per salvare l'ordine del documento
                    SaveDocumentOrder(ref movement_id);

                    LoadMerchandise.Enabled = false;
                    //this.Close();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        private void GenerateTempPrint() //METODO PER POTER SALVARE IL DOCUMENTO GENERATO DELL'ORDINE
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            printDocument.PrintPage += new PrintPageEventHandler(_orderDocument.PrintPageHandler);

            // Imposta la stampante PDF come stampante predefinita
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            string tempPdfPath = Path.Combine(Path.GetTempPath(), "tempfile.pdf");
            printDocument.PrinterSettings.PrintToFile = true; //stampa su file
            printDocument.PrinterSettings.PrintFileName = tempPdfPath; //gli passo il percorso con il nome del file
            
            printDocument.Print(); // Stampa il documento
            
            Thread.Sleep(1000); // aspetta un secondo per assicurarsi che il file sia stato creato

            // controlla se il file PDF esiste e lo apre
            if (File.Exists(tempPdfPath))
            {
                Process.Start(new ProcessStartInfo(tempPdfPath) { UseShellExecute = true });
                /*Process.Start: Questo metodo avvia un nuovo processo. È comunemente usato per eseguire applicazioni o aprire file con le applicazioni associate.

                new ProcessStartInfo(tempPdfPath): Questo crea un nuovo oggetto ProcessStartInfo specificando il percorso del file PDF (tempPdfPath) come argomento. 
                ProcessStartInfo è una classe che contiene informazioni utilizzate per avviare un processo.

                UseShellExecute = true: Questa proprietà indica che il processo deve essere avviato utilizzando la shell di sistema. Quando UseShellExecute è impostato su true, il sistema operativo 
                utilizza la shell di Windows per determinare come aprire il file. Questo è necessario per aprire il file PDF con l'applicazione predefinita associata ai file PDF
                (come Adobe Acrobat Reader, Microsoft Edge, ecc.). Senza questa proprietà impostata su true, il comando non funzionerebbe correttamente per aprire un file con l'applicazione
                predefinita.*/                                  
            }
        }


        private void SaveDocumentOrder(ref int movement_id)
        {
            DialogResult dialog = MessageBox.Show("Vuoi salvare il documento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dialog.Equals(DialogResult.Yes))
            {
                //salva il documento
                //DA COMPLETARE---------------------------------------------------
                Attachment attachment = new Attachment();
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "tempfile.pdf");

                attachment.AttachmentObjID = movement_id;
                attachment.Path = tempPdfPath;
                attachment.FileName = Path.GetFileName(tempPdfPath);
                attachment.Icon = Icon.ExtractAssociatedIcon(tempPdfPath);
                attachment.Extension = Path.GetExtension(tempPdfPath).ToLower();
                attachment.FileData = File.ReadAllBytes(tempPdfPath);

                int id_attachment = _daoAttachment.Insert(attachment);
                _daoObjectAttachments.Insert(movement_id, id_attachment);
            }
        }

        private int InsertMovementInWareHouseDB()
        {
            _tempMovement.DateMovement = DateTime.Now;
            _tempMovement.Causal = CausalTB.Text;
            _tempMovement.WareHouseFK = _selectedWareHouse.ID;
            return _daoMovement.Insert(_tempMovement);
        }

        private void InsertDetailMovementAndProductsInWareHouseDB(int movement_id) //inserisco i dettagli del movimento e i prodotti al magazzino
        {
            foreach (WareHouseProduct wareHouseProduct in _warehouseproducts.Values)
            {
                wareHouseProduct.WarehouseProps = new Warehouse() { ID = _selectedWareHouse.ID };
                _daoDetailsMovement.Insert(wareHouseProduct, movement_id);

                if (_daoWareHouseProduct.IsTheProductAlreadyInserted(wareHouseProduct).Equals(false))
                {
                    _daoWareHouseProduct.Insert(wareHouseProduct);
                }
                else
                {
                    _daoWareHouseProduct.Update(wareHouseProduct, WarehouseProductQueries.LOADPRODUCTS);
                }
            }
        }
    }
        
}
