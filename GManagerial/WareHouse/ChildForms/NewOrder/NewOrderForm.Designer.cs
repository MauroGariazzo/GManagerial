namespace GManagerial.WareHouse.ChildForms.NewOrder
{
    partial class NewOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrderForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStripButtons = new System.Windows.Forms.ToolStrip();
            this.AddProduct = new System.Windows.Forms.ToolStripButton();
            this.DeleteProduct = new System.Windows.Forms.ToolStripButton();
            this.Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadMerchandise = new System.Windows.Forms.ToolStripButton();
            this.printPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveDocument = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CausalTB = new System.Windows.Forms.TextBox();
            this.CausalLbl = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SelectedSupplier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalOrderLbl = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.VatValueLbl = new System.Windows.Forms.Label();
            this.VatLbl = new System.Windows.Forms.Label();
            this.TotalNetValue = new System.Windows.Forms.Label();
            this.ClearTotal = new System.Windows.Forms.Label();
            this.OrderDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.ToolStripButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStripButtons
            // 
            this.ToolStripButtons.AutoSize = false;
            this.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripButtons.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStripButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProduct,
            this.DeleteProduct,
            this.Close,
            this.toolStripSeparator1,
            this.PrintBtn,
            this.toolStripSeparator2,
            this.LoadMerchandise,
            this.printPreview,
            this.toolStripSeparator3,
            this.saveDocument});
            this.ToolStripButtons.Location = new System.Drawing.Point(0, 663);
            this.ToolStripButtons.Name = "ToolStripButtons";
            this.ToolStripButtons.Size = new System.Drawing.Size(1187, 50);
            this.ToolStripButtons.TabIndex = 2;
            this.ToolStripButtons.Text = "toolStrip1";
            // 
            // AddProduct
            // 
            this.AddProduct.Image = ((System.Drawing.Image)(resources.GetObject("AddProduct.Image")));
            this.AddProduct.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(158, 47);
            this.AddProduct.Text = "Aggiungi prodotto";
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Image = ((System.Drawing.Image)(resources.GetObject("DeleteProduct.Image")));
            this.DeleteProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(146, 47);
            this.DeleteProduct.Text = "Elimina prodotto";
            this.DeleteProduct.Click += new System.EventHandler(this.DeleteProduct_Click);
            // 
            // Close
            // 
            this.Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(70, 47);
            this.Close.Text = "Esci";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // PrintBtn
            // 
            this.PrintBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PrintBtn.Image = ((System.Drawing.Image)(resources.GetObject("PrintBtn.Image")));
            this.PrintBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PrintBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(96, 47);
            this.PrintBtn.Text = "Stampa";
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // LoadMerchandise
            // 
            this.LoadMerchandise.Image = ((System.Drawing.Image)(resources.GetObject("LoadMerchandise.Image")));
            this.LoadMerchandise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadMerchandise.Name = "LoadMerchandise";
            this.LoadMerchandise.Size = new System.Drawing.Size(118, 47);
            this.LoadMerchandise.Text = "Arrivo merce";
            this.LoadMerchandise.Click += new System.EventHandler(this.LoadMerchandise_Click);
            // 
            // printPreview
            // 
            this.printPreview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.printPreview.Image = ((System.Drawing.Image)(resources.GetObject("printPreview.Image")));
            this.printPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreview.Name = "printPreview";
            this.printPreview.Size = new System.Drawing.Size(103, 47);
            this.printPreview.Text = "Anteprima";
            this.printPreview.Click += new System.EventHandler(this.printPreview_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 50);
            // 
            // saveDocument
            // 
            this.saveDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveDocument.Image = ((System.Drawing.Image)(resources.GetObject("saveDocument.Image")));
            this.saveDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Size = new System.Drawing.Size(148, 47);
            this.saveDocument.Text = "Salva documento";
            this.saveDocument.Click += new System.EventHandler(this.saveDocument_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.CausalTB);
            this.panel1.Controls.Add(this.CausalLbl);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.SelectedSupplier);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TotalOrderLbl);
            this.panel1.Controls.Add(this.Total);
            this.panel1.Controls.Add(this.VatValueLbl);
            this.panel1.Controls.Add(this.VatLbl);
            this.panel1.Controls.Add(this.TotalNetValue);
            this.panel1.Controls.Add(this.ClearTotal);
            this.panel1.Location = new System.Drawing.Point(3, 542);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 118);
            this.panel1.TabIndex = 3;
            // 
            // CausalTB
            // 
            this.CausalTB.Location = new System.Drawing.Point(88, 46);
            this.CausalTB.Name = "CausalTB";
            this.CausalTB.Size = new System.Drawing.Size(245, 22);
            this.CausalTB.TabIndex = 12;
            // 
            // CausalLbl
            // 
            this.CausalLbl.AutoSize = true;
            this.CausalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CausalLbl.Location = new System.Drawing.Point(9, 49);
            this.CausalLbl.Name = "CausalLbl";
            this.CausalLbl.Size = new System.Drawing.Size(68, 16);
            this.CausalLbl.TabIndex = 11;
            this.CausalLbl.Text = "Causale:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(148, 80);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(185, 20);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Stampa nome fornitore";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(9, 80);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 20);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Stampa costi";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SelectedSupplier
            // 
            this.SelectedSupplier.Enabled = false;
            this.SelectedSupplier.Location = new System.Drawing.Point(88, 15);
            this.SelectedSupplier.Name = "SelectedSupplier";
            this.SelectedSupplier.Size = new System.Drawing.Size(245, 22);
            this.SelectedSupplier.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fornitore:";
            // 
            // TotalOrderLbl
            // 
            this.TotalOrderLbl.AutoSize = true;
            this.TotalOrderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalOrderLbl.Location = new System.Drawing.Point(1055, 84);
            this.TotalOrderLbl.Name = "TotalOrderLbl";
            this.TotalOrderLbl.Size = new System.Drawing.Size(11, 16);
            this.TotalOrderLbl.TabIndex = 5;
            this.TotalOrderLbl.Text = ".";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.Location = new System.Drawing.Point(959, 84);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(56, 16);
            this.Total.TabIndex = 4;
            this.Total.Text = "Totale:";
            // 
            // VatValueLbl
            // 
            this.VatValueLbl.AutoSize = true;
            this.VatValueLbl.Font = new System.Drawing.Font("Yu Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VatValueLbl.Location = new System.Drawing.Point(1055, 51);
            this.VatValueLbl.Name = "VatValueLbl";
            this.VatValueLbl.Size = new System.Drawing.Size(12, 17);
            this.VatValueLbl.TabIndex = 3;
            this.VatValueLbl.Text = ".";
            // 
            // VatLbl
            // 
            this.VatLbl.AutoSize = true;
            this.VatLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VatLbl.Location = new System.Drawing.Point(961, 51);
            this.VatLbl.Name = "VatLbl";
            this.VatLbl.Size = new System.Drawing.Size(43, 16);
            this.VatLbl.TabIndex = 2;
            this.VatLbl.Text = "I.V.A. :";
            // 
            // TotalNetValue
            // 
            this.TotalNetValue.AutoSize = true;
            this.TotalNetValue.Font = new System.Drawing.Font("Yu Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalNetValue.Location = new System.Drawing.Point(1055, 18);
            this.TotalNetValue.Name = "TotalNetValue";
            this.TotalNetValue.Size = new System.Drawing.Size(12, 17);
            this.TotalNetValue.TabIndex = 1;
            this.TotalNetValue.Text = ".";
            // 
            // ClearTotal
            // 
            this.ClearTotal.AutoSize = true;
            this.ClearTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearTotal.Location = new System.Drawing.Point(959, 18);
            this.ClearTotal.Name = "ClearTotal";
            this.ClearTotal.Size = new System.Drawing.Size(68, 16);
            this.ClearTotal.TabIndex = 0;
            this.ClearTotal.Text = "Tot. Netto:";
            // 
            // OrderDataGridView
            // 
            this.OrderDataGridView.AllowUserToAddRows = false;
            this.OrderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrderDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.OrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.ProductNameColumn,
            this.DescriptionColumn,
            this.QuantityColumn,
            this.PriceColumn,
            this.DiscountColumn,
            this.VatColumn,
            this.AmountColumn});
            this.OrderDataGridView.Location = new System.Drawing.Point(3, -1);
            this.OrderDataGridView.Name = "OrderDataGridView";
            this.OrderDataGridView.RowHeadersVisible = false;
            this.OrderDataGridView.RowHeadersWidth = 51;
            this.OrderDataGridView.RowTemplate.Height = 24;
            this.OrderDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrderDataGridView.Size = new System.Drawing.Size(1179, 537);
            this.OrderDataGridView.TabIndex = 4;
            this.OrderDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderDataGridView_CellEndEdit);
            this.OrderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OrderDataGridView_CellFormatting);
            this.OrderDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.OrderDataGridView_EditingControlShowing);
            this.OrderDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderDataGridView_KeyPress);
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.MinimumWidth = 6;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // ProductNameColumn
            // 
            this.ProductNameColumn.HeaderText = "Nome Prodotto";
            this.ProductNameColumn.MinimumWidth = 6;
            this.ProductNameColumn.Name = "ProductNameColumn";
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.HeaderText = "Descrizione";
            this.DescriptionColumn.MinimumWidth = 6;
            this.DescriptionColumn.Name = "DescriptionColumn";
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.HeaderText = "Quantità";
            this.QuantityColumn.MinimumWidth = 6;
            this.QuantityColumn.Name = "QuantityColumn";
            // 
            // PriceColumn
            // 
            this.PriceColumn.HeaderText = "Prezzo netto";
            this.PriceColumn.MinimumWidth = 6;
            this.PriceColumn.Name = "PriceColumn";
            // 
            // DiscountColumn
            // 
            this.DiscountColumn.HeaderText = "Sconto";
            this.DiscountColumn.MinimumWidth = 6;
            this.DiscountColumn.Name = "DiscountColumn";
            // 
            // VatColumn
            // 
            this.VatColumn.HeaderText = "I.V.A.";
            this.VatColumn.Items.AddRange(new object[] {
            "4%",
            "10%",
            "22%",
            "0%"});
            this.VatColumn.MinimumWidth = 6;
            this.VatColumn.Name = "VatColumn";
            this.VatColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VatColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AmountColumn
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AmountColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.AmountColumn.HeaderText = "Importo";
            this.AmountColumn.MinimumWidth = 6;
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.ReadOnly = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 713);
            this.Controls.Add(this.OrderDataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStripButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewOrderForm";
            this.Text = "NewOrderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewOrderForm_FormClosing);
            this.Load += new System.EventHandler(this.NewOrderForm_Load);
            this.ToolStripButtons.ResumeLayout(false);
            this.ToolStripButtons.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip ToolStripButtons;
        private System.Windows.Forms.ToolStripButton AddProduct;
        private System.Windows.Forms.ToolStripButton Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton DeleteProduct;
        private System.Windows.Forms.Label TotalNetValue;
        private System.Windows.Forms.Label ClearTotal;
        private System.Windows.Forms.Label VatLbl;
        private System.Windows.Forms.Label TotalOrderLbl;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Label VatValueLbl;
        private System.Windows.Forms.ToolStripButton PrintBtn;
        private System.Windows.Forms.TextBox SelectedSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView OrderDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn VatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolStripButton LoadMerchandise;
        private System.Windows.Forms.TextBox CausalTB;
        private System.Windows.Forms.Label CausalLbl;
        private System.Windows.Forms.ToolStripButton printPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton saveDocument;
    }
}