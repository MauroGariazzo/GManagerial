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
using GManagerial.DBConnectors;
using GManagerial.WareHouse.models;
using GManagerial.WareHouse.models.Movements;
using GManagerial.WareHouse.models.WareHouseProducts;
using Microsoft.Extensions.Primitives;


namespace GManagerial.WareHouse.ChildForms.NewOrder
{
    internal partial class NewOrderForm : Form
    {
        private int _currentRowIndex = 0;
        //internal event EventHandler PopulateDataGridView;
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

        public NewOrderForm(Supplier supplier, Warehouse warehouse)
        {
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
            InitializeComponent();
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

            printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }


        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            float x = 10;
            float y = 10;

            int logoWidth = 200;
            int logoHeight = 150;

            int marginMm = 5;
            int margin = (int)(marginMm * (100 / 25.4));  // Conversione da mm a unità del sistema

            int width = e.PageBounds.Width - 2 * margin; //789
            int height = (e.PageBounds.Height - 2 * margin); //1131

            float[] columnWidths = new float[] { 15, 60, 150, 15, 50, 25, 20, 70 };
            string[] columnHeaders = new string[] { "Id", "Nome Prodotto", "Descrizione", "Qta", "Prezzo netto", "Sconto", "Iva", "Importo" };

            if (_currentRowIndex.Equals(0))
            {
                UploadLogo(graphics, logoWidth, logoHeight, x, y);  //carica il logo
                DrawSupplierHeader(graphics); //intestazione
                DrawRectangle(e, graphics, logoHeight, margin, width, height, x); //disegna il rettangolo principale
                DrawHeadersLine(graphics, margin, logoHeight, e, x, y); //disegna la linea orizzontale dove verrà creato lo spazio per i nomi delle colonne
                _currentRowIndex = DrawProductsInDocument(graphics, columnWidths, 20, logoHeight, _currentRowIndex);

                if (_currentRowIndex.Equals(0))
                {
                    DrawHeadersColumnsNames(graphics, logoHeight, margin, height, x, y, width, columnWidths, columnHeaders, true);
                }

                else
                {
                    DrawHeadersColumnsNames(graphics, logoHeight, margin, height, x, y, width, columnWidths, columnHeaders, false);
                }
            }

            else
            {
                DrawRectangle(e, graphics, 0, margin, width, height, x); //disegna il rettangolo principale
                DrawHeadersLine(graphics, margin, 0, e, x, y); //disegna la linea orizzontale dove verrà creato lo spazio per i nomi delle colonne
                _currentRowIndex = DrawProductsInDocument(graphics, columnWidths, 20, 0, _currentRowIndex);

                if (_currentRowIndex.Equals(0))
                {
                    DrawHeadersColumnsNames(graphics, 0, margin, height, x, y, width, columnWidths, columnHeaders, true);
                }

                else
                {
                    DrawHeadersColumnsNames(graphics, 0, margin, height, x, y, width, columnWidths, columnHeaders, false);
                }

            }

            if(_currentRowIndex > 0)
            {
                e.HasMorePages = true;
            }

            else
            {
                DrawTotalDocumentLine(graphics, margin, e, height, x, columnWidths, width); //linea orizzontale per il totale
                e.HasMorePages = false;
            }
        }
        

        private void DrawSupplierHeader(Graphics graphics)
        {
            Font font = new Font("Arial", 9, FontStyle.Italic);
            graphics.DrawRectangle(Pens.Black, 520, 80, 288, 85);
            try
            {
                graphics.DrawString($"Spett.le {_supplier.SupplierName}, \n {_supplier.City}({_supplier.ProvinceSigle.Trim()}),\n{_supplier.Address} - {_supplier.ZipCode}", font, Brushes.Black, 520, 80);
            }

            catch
            {
                graphics.DrawString($"Spett.le {_supplier.SupplierName}, \n {_supplier.City}({_supplier.ProvinceSigle}),\n {_supplier.ZipCode} - {_supplier.Address}", font, Brushes.Black, 520, 80);
            }

            font = new Font("Arial", 8, FontStyle.Italic);
            graphics.DrawString("Con la presente chiedo la fornitura dei seguenti prodotti:", font, Brushes.Black, 20,220);
        }
        private void UploadLogo(Graphics graphics, int logoWidth, int logoHeight, float x, float y)
        {
            System.Drawing.Image logo = System.Drawing.Image.FromFile(@"C:\Users\mauro\Documents\vsc_projects\GManagerial\GManagerial\images\red.jpg");
            graphics.DrawImage(logo, x * 2, y, logoWidth, logoHeight);
        }

        private void DrawRectangle(PrintPageEventArgs e, Graphics graphics, int logoHeight, int margin, int width, int height, float x)
        {
            graphics.DrawRectangle(Pens.Black, margin, (margin + x + 60) + logoHeight, width, height - logoHeight-60);
        }

        private void DrawHeadersLine(Graphics graphics, int margin, int logoHeight, PrintPageEventArgs e, float x, float y)
        {
            graphics.DrawLine(Pens.Black, margin, y + logoHeight + (y * 2) + margin + 60, e.PageBounds.Width - margin, y + logoHeight + (y * 2) + margin + 60); //riga orizzontale per inserire i nomi delle colonne
        }

        private int DrawProductsInDocument(Graphics graphics, float[] columnWidths, float startX, int logoHeight, int rowIndex)
        {
            Font font = new Font("Arial", 10);

            float currentY = logoHeight + 50 + 60;

            for(int row = rowIndex; row < OrderDataGridView.Rows.Count; row++)
            {
                float currentX = startX;
                float maxHeight = 0; // L'altezza massima per questa riga di prodotti

                RectangleF[] columnAreas = new RectangleF[columnWidths.Length];

                for (int i = 0; i < columnWidths.Length; i++)
                {
                    columnAreas[i] = new RectangleF(currentX, currentY, columnWidths[i] * 2, font.Height);
                    currentX += columnWidths[i] * 2;
                }


                for (int j = 0; j < columnWidths.Length; j++)
                {
                    if (!(OrderDataGridView.Rows[row].Cells[j].Value is null))
                    {
                        SizeF sizeF = graphics.MeasureString(OrderDataGridView.Rows[row].Cells[j].Value.ToString(), font, (int)columnAreas[j].Width);
                        columnAreas[j].Height = sizeF.Height;
                        maxHeight = Math.Max(maxHeight, sizeF.Height);

                        if (j.Equals(4))
                        {
                            graphics.DrawString($"{OrderDataGridView.Rows[row].Cells[j].Value.ToString()} €", font, Brushes.Black, columnAreas[j]);
                        }

                        else
                        {
                            if (currentY > 1169 - 90 && row < OrderDataGridView.Rows.Count)
                            {
                                //row++;
                                return row++;
                            }

                            else
                            {
                                graphics.DrawString(OrderDataGridView.Rows[row].Cells[j].Value.ToString(), font, Brushes.Black, columnAreas[j]);
                            }
                        }
                    }
                }

                if(currentY > 1169 - 90 && row < OrderDataGridView.Rows.Count)
                {
                    //row++;
                    return row++;
                }

                currentY += maxHeight + 15; // Aggiungi spazio tra le righe
            }
            return 0;
        }


        private void DrawTotalDocumentLine(Graphics graphics, int margin, PrintPageEventArgs e, int height, float x, float[] columnWidths, float width)
        {
            Font font = new Font("Arial", 10, FontStyle.Italic);

            Brush headerBrush = new SolidBrush(Color.LightGray);
            graphics.FillRectangle(headerBrush, width - 289f, height - 40, width - 481.5f, 68.3f);
            graphics.DrawLine(Pens.Black, margin, height - 40, e.PageBounds.Width - (x * 2) + 0.3f, height - 40); //linea orizzontale per il totale

            graphics.DrawString($"Totale parziale:{new string(' ', 19)} {TotalNetValue.Text.Substring(0, TotalNetValue.Text.Length-1)} €", font, Brushes.Black, 520, height - 35);
            graphics.DrawString($"I.V.A.:{new string(' ', 34)}{VatValueLbl.Text.Substring(0, VatValueLbl.Text.Length - 1)} €", font, Brushes.Black, 520, height - 15);
            graphics.DrawString($"Totale + I.V.A.:{new string(' ', 20)}{TotalOrderLbl.Text.Substring(0, TotalOrderLbl.Text.Length - 1)} €", font, Brushes.Black, 520, height + 5);
        }

        //
        private void DrawHeadersColumnsNames(Graphics graphics, int logoHeight, int margin, int height, float x, float y, int width, float[] columnWidths, string[] columnHeaders, bool isLastPage)
        {
            Font font = new Font("Arial", 7);

            float currentX = 19;
            int index = 0;
            foreach (string columnHeader in columnHeaders)
            {
                Brush headerBrush = new SolidBrush(Color.LightGray);

                if(!(isLastPage))
                {
                    graphics.FillRectangle(headerBrush, currentX, margin + logoHeight + x + 0.5f + 60, width - currentX + (x * 2) - 1.5f, 19f);
                    graphics.DrawString(columnHeader, font, Brushes.Black, currentX, logoHeight + 30 + 60);
                    graphics.DrawLine(Pens.Black, currentX, margin + logoHeight + y + 60, currentX, height + 29.4f);

                    currentX += columnWidths[index] * 2;
                }

                else if(index.Equals(4))
                {
                    graphics.FillRectangle(headerBrush, currentX, margin + logoHeight + x + 0.5f + 60, width - currentX + (x * 2) - 1.5f, 19f); //
                    graphics.DrawString(columnHeader, font, Brushes.Black, currentX, logoHeight + 30 + 60);
                    graphics.DrawLine(Pens.Black, currentX, margin + logoHeight + y + 60, currentX, height + 29.4f);

                    currentX += columnWidths[index] * 2;
                }

                else
                {
                    graphics.FillRectangle(headerBrush, currentX, margin + logoHeight + x + 0.5f + 60, width - currentX + (x * 2) - 1.5f, 19f); //
                    graphics.DrawString(columnHeader, font, Brushes.Black, currentX, logoHeight + 30 + 60);
                    graphics.DrawLine(Pens.Black, currentX, margin + logoHeight + y + 60, currentX, height - 40); //+30

                    currentX += columnWidths[index] * 2;
                }

                index++;
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
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
                    LoadMerchandise.Enabled = false;
                    this.Close();
                }
            }
        }       

        private void GenerateTempPrint() //METODO PER POTER SALVARE IL DOCUMENTO GENERATO DELL'ORDINE
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);

            // Imposta la stampante PDF come stampante predefinita
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            
            string tempPdfPath = Path.Combine(Path.GetTempPath(), "tempfile.pdf");
            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = tempPdfPath;

            printDocument.Print();

            MemoryStream stream = new MemoryStream();

            if (File.Exists(tempPdfPath))
            {
                byte[] pdfContent = File.ReadAllBytes(tempPdfPath);
                stream.Write(pdfContent, 0, pdfContent.Length);
                Thread.Sleep(1000);
                Process.Start(tempPdfPath);

                SaveDocumentOrder();
            }
        }

        private void SaveDocumentOrder()
        {
            DialogResult dialog = MessageBox.Show("Vuoi salvare il documento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dialog.Equals(DialogResult.Yes))
            {
                //salva il documento
                //DA COMPLETARE---------------------------------------------------
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
