namespace GManagerial.WareHouse
{
    partial class WarehouseStocks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseStocks));
            this.newBtnCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBtns = new System.Windows.Forms.ToolStrip();
            this.NewBtn = new System.Windows.Forms.ToolStripButton();
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.MenuName = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.LoadUnloadIcons = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.WareHouseStockDGV = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.bar = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CreateWareHouseBtn = new System.Windows.Forms.Button();
            this.SelectWarehouseCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.selectAllRows = new System.Windows.Forms.CheckBox();
            this.newBtnCMS.SuspendLayout();
            this.stripBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseStockDGV)).BeginInit();
            this.bar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // newBtnCMS
            // 
            this.newBtnCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.newBtnCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewOrder});
            this.newBtnCMS.Name = "newBtnCMS";
            this.newBtnCMS.Size = new System.Drawing.Size(172, 28);
            // 
            // NewOrder
            // 
            this.NewOrder.Name = "NewOrder";
            this.NewOrder.Size = new System.Drawing.Size(171, 24);
            this.NewOrder.Text = "Nuovo Ordine";
            this.NewOrder.Click += new System.EventHandler(this.NewOrder_Click);
            // 
            // stripBtns
            // 
            this.stripBtns.AutoSize = false;
            this.stripBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stripBtns.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stripBtns.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stripBtns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewBtn,
            this.editBtn,
            this.deleteBtn});
            this.stripBtns.Location = new System.Drawing.Point(0, 641);
            this.stripBtns.Name = "stripBtns";
            this.stripBtns.Size = new System.Drawing.Size(1531, 49);
            this.stripBtns.TabIndex = 17;
            this.stripBtns.Text = "toolStrip1";
            // 
            // NewBtn
            // 
            this.NewBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewBtn.Image")));
            this.NewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(43, 46);
            this.NewBtn.Text = "Crea";
            this.NewBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewBtn_MouseDown);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(72, 46);
            this.editBtn.Text = "Modifica";
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(62, 46);
            this.deleteBtn.Text = "Elimina";
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // MenuName
            // 
            this.MenuName.AutoSize = true;
            this.MenuName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuName.Location = new System.Drawing.Point(25, 1);
            this.MenuName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MenuName.Name = "MenuName";
            this.MenuName.Size = new System.Drawing.Size(117, 27);
            this.MenuName.TabIndex = 0;
            this.MenuName.Text = "Magazzino";
            // 
            // searchBox
            // 
            this.searchBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchBox.Location = new System.Drawing.Point(1385, 0);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(264, 27);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Cerca";
            // 
            // LoadUnloadIcons
            // 
            this.LoadUnloadIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LoadUnloadIcons.ImageStream")));
            this.LoadUnloadIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.LoadUnloadIcons.Images.SetKeyName(0, "plus.png");
            this.LoadUnloadIcons.Images.SetKeyName(1, "delete.png");
            this.LoadUnloadIcons.Images.SetKeyName(2, "6518772_household_housework_laundry_machine_washing_icon.png");
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // WareHouseStockDGV
            // 
            this.WareHouseStockDGV.AllowUserToAddRows = false;
            this.WareHouseStockDGV.AllowUserToDeleteRows = false;
            this.WareHouseStockDGV.AllowUserToResizeRows = false;
            this.WareHouseStockDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WareHouseStockDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WareHouseStockDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.WareHouseStockDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WareHouseStockDGV.ColumnHeadersHeight = 29;
            this.WareHouseStockDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.ProductName,
            this.Description,
            this.Stock,
            this.Orders,
            this.Supplier,
            this.Image});
            this.WareHouseStockDGV.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WareHouseStockDGV.Location = new System.Drawing.Point(0, 28);
            this.WareHouseStockDGV.Margin = new System.Windows.Forms.Padding(4);
            this.WareHouseStockDGV.Name = "WareHouseStockDGV";
            this.WareHouseStockDGV.ReadOnly = true;
            this.WareHouseStockDGV.RowHeadersVisible = false;
            this.WareHouseStockDGV.RowHeadersWidth = 51;
            this.WareHouseStockDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WareHouseStockDGV.Size = new System.Drawing.Size(1531, 610);
            this.WareHouseStockDGV.TabIndex = 14;
            // 
            // IdColumn
            // 
            this.IdColumn.FillWeight = 32.14372F;
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.MinimumWidth = 6;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.FillWeight = 94.82397F;
            this.ProductName.HeaderText = "nome prodotto";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.FillWeight = 94.82397F;
            this.Description.HeaderText = "Descrizione";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.FillWeight = 94.82397F;
            this.Stock.HeaderText = "Giacenza";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Orders
            // 
            this.Orders.FillWeight = 94.82397F;
            this.Orders.HeaderText = "Ordinati";
            this.Orders.MinimumWidth = 6;
            this.Orders.Name = "Orders";
            this.Orders.ReadOnly = true;
            // 
            // Supplier
            // 
            this.Supplier.FillWeight = 94.82397F;
            this.Supplier.HeaderText = "Fornitore";
            this.Supplier.MinimumWidth = 6;
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.FillWeight = 94.82397F;
            this.Image.HeaderText = "Immagine";
            this.Image.MinimumWidth = 6;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            // 
            // bar
            // 
            this.bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bar.Controls.Add(this.MenuName);
            this.bar.Controls.Add(this.button1);
            this.bar.Controls.Add(this.searchBox);
            this.bar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bar.Location = new System.Drawing.Point(-94, -26);
            this.bar.Margin = new System.Windows.Forms.Padding(5);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1720, 27);
            this.bar.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1339, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 27);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.CreateWareHouseBtn);
            this.panel2.Controls.Add(this.SelectWarehouseCB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1585, 27);
            this.panel2.TabIndex = 19;
            // 
            // CreateWareHouseBtn
            // 
            this.CreateWareHouseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateWareHouseBtn.Image")));
            this.CreateWareHouseBtn.Location = new System.Drawing.Point(997, -1);
            this.CreateWareHouseBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateWareHouseBtn.Name = "CreateWareHouseBtn";
            this.CreateWareHouseBtn.Size = new System.Drawing.Size(51, 31);
            this.CreateWareHouseBtn.TabIndex = 5;
            this.CreateWareHouseBtn.UseVisualStyleBackColor = true;
            this.CreateWareHouseBtn.Click += new System.EventHandler(this.CreateWareHouseBtn_Click);
            // 
            // SelectWarehouseCB
            // 
            this.SelectWarehouseCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectWarehouseCB.FormattingEnabled = true;
            this.SelectWarehouseCB.Location = new System.Drawing.Point(1052, 0);
            this.SelectWarehouseCB.Margin = new System.Windows.Forms.Padding(4);
            this.SelectWarehouseCB.Name = "SelectWarehouseCB";
            this.SelectWarehouseCB.Size = new System.Drawing.Size(160, 35);
            this.SelectWarehouseCB.TabIndex = 4;
            this.SelectWarehouseCB.SelectedIndexChanged += new System.EventHandler(this.SelectWarehouseCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(0, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Magazzino";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1271, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 27);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Location = new System.Drawing.Point(1317, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Cerca";
            // 
            // selectAllRows
            // 
            this.selectAllRows.AutoSize = true;
            this.selectAllRows.Location = new System.Drawing.Point(30, 36);
            this.selectAllRows.Margin = new System.Windows.Forms.Padding(4);
            this.selectAllRows.Name = "selectAllRows";
            this.selectAllRows.Size = new System.Drawing.Size(18, 17);
            this.selectAllRows.TabIndex = 20;
            this.selectAllRows.UseVisualStyleBackColor = true;
            this.selectAllRows.CheckedChanged += new System.EventHandler(this.selectAllRows_CheckedChanged);
            // 
            // WarehouseStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 690);
            this.ControlBox = false;
            this.Controls.Add(this.selectAllRows);
            this.Controls.Add(this.WareHouseStockDGV);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.stripBtns);
            this.Controls.Add(this.bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WarehouseStocks";
            this.Text = " ";
            this.Load += new System.EventHandler(this.WarehouseStocks_Load);
            this.newBtnCMS.ResumeLayout(false);
            this.stripBtns.ResumeLayout(false);
            this.stripBtns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseStockDGV)).EndInit();
            this.bar.ResumeLayout(false);
            this.bar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem NewOrder;
        private System.Windows.Forms.ContextMenuStrip newBtnCMS;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripButton editBtn;
        private System.Windows.Forms.ToolStripButton NewBtn;
        private System.Windows.Forms.ToolStrip stripBtns;
        //private System.Windows.Forms.Button CreateWareHouseBtn;
        //private System.Windows.Forms.ComboBox SelectWarehouseCB;
        private System.Windows.Forms.Label MenuName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ImageList LoadUnloadIcons;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView WareHouseStockDGV;
        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.Button CreateWareHouseBtn;
        private System.Windows.Forms.ComboBox SelectWarehouseCB;
        private System.Windows.Forms.CheckBox selectAllRows;
    }
}