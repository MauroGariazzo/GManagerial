using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GManagerial.WareHouse.ChildForms.NewOrder
{
    internal class OrderDocument
    {
        private int _currentRowIndex;
        private Supplier _supplier;
        private DataGridView _dataGridView;
        private Label _totalNetValue;
        private Label _totalOrderLbl;
        private Label _vatValueLbl;

        public OrderDocument(int currentRowIndex, Supplier supplier, DataGridView dataGridView, Label totalNetValue, Label totalOrderLbl, Label vatValueLbl)
        {
            this._currentRowIndex = currentRowIndex;
            this._supplier = supplier;
            this._dataGridView = dataGridView;
            this._totalNetValue= totalNetValue;
            this._totalOrderLbl = totalOrderLbl;
            this._vatValueLbl = vatValueLbl;
        }
        public void PrintPageHandler(object sender, PrintPageEventArgs e)
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

            if (_currentRowIndex > 0)
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
            graphics.DrawString("Con la presente chiedo la fornitura dei seguenti prodotti:", font, Brushes.Black, 20, 220);
        }
        private void UploadLogo(Graphics graphics, int logoWidth, int logoHeight, float x, float y)
        {
            System.Drawing.Image logo = System.Drawing.Image.FromFile(@"C:\Users\mauro\Documents\vsc_projects\GManagerial\GManagerial\images\red.jpg");
            graphics.DrawImage(logo, x * 2, y, logoWidth, logoHeight);
        }

        private void DrawRectangle(PrintPageEventArgs e, Graphics graphics, int logoHeight, int margin, int width, int height, float x)
        {
            graphics.DrawRectangle(Pens.Black, margin, (margin + x + 60) + logoHeight, width, height - logoHeight - 60);
        }

        private void DrawHeadersLine(Graphics graphics, int margin, int logoHeight, PrintPageEventArgs e, float x, float y)
        {
            graphics.DrawLine(Pens.Black, margin, y + logoHeight + (y * 2) + margin + 60, e.PageBounds.Width - margin, y + logoHeight + (y * 2) + margin + 60); //riga orizzontale per inserire i nomi delle colonne
        }

        private int DrawProductsInDocument(Graphics graphics, float[] columnWidths, float startX, int logoHeight, int rowIndex)
        {
            Font font = new Font("Arial", 10);

            float currentY = logoHeight + 50 + 60;

            for (int row = rowIndex; row < _dataGridView.Rows.Count; row++)
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
                    if (!(_dataGridView.Rows[row].Cells[j].Value is null))
                    {
                        SizeF sizeF = graphics.MeasureString(_dataGridView.Rows[row].Cells[j].Value.ToString(), font, (int)columnAreas[j].Width);
                        columnAreas[j].Height = sizeF.Height;
                        maxHeight = Math.Max(maxHeight, sizeF.Height);

                        if (j.Equals(4))
                        {
                            graphics.DrawString($"{_dataGridView.Rows[row].Cells[j].Value.ToString()} €", font, Brushes.Black, columnAreas[j]);
                        }

                        else
                        {
                            if (currentY > 1169 - 90 && row < _dataGridView.Rows.Count)
                            {
                                //row++;
                                return row++;
                            }

                            else
                            {
                                graphics.DrawString(_dataGridView.Rows[row].Cells[j].Value.ToString(), font, Brushes.Black, columnAreas[j]);
                            }
                        }
                    }
                }

                if (currentY > 1169 - 90 && row < _dataGridView.Rows.Count)
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

            graphics.DrawString($"Totale parziale:{new string(' ', 19)} {_totalNetValue.Text.Substring(0, _totalNetValue.Text.Length - 1)} €", font, Brushes.Black, 520, height - 35);
            graphics.DrawString($"I.V.A.:{new string(' ', 34)}{_vatValueLbl.Text.Substring(0, _vatValueLbl.Text.Length - 1)} €", font, Brushes.Black, 520, height - 15);
            graphics.DrawString($"Totale + I.V.A.:{new string(' ', 20)}{_totalOrderLbl.Text.Substring(0, _totalOrderLbl.Text.Length - 1)} €", font, Brushes.Black, 520, height + 5);
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

                if (!(isLastPage))
                {
                    graphics.FillRectangle(headerBrush, currentX, margin + logoHeight + x + 0.5f + 60, width - currentX + (x * 2) - 1.5f, 19f);
                    graphics.DrawString(columnHeader, font, Brushes.Black, currentX, logoHeight + 30 + 60);
                    graphics.DrawLine(Pens.Black, currentX, margin + logoHeight + y + 60, currentX, height + 29.4f);

                    currentX += columnWidths[index] * 2;
                }

                else if (index.Equals(4))
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
    }
}
