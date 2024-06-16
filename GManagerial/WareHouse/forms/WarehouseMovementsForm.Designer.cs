namespace GManagerial.WareHouse
{
    partial class WarehouseMovementsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseMovementsForm));
            this.selectAllRows = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.AnagrPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TotPieces = new System.Windows.Forms.Label();
            this.TotPiecesLbl = new System.Windows.Forms.Label();
            this.MovementDetailsTV = new System.Windows.Forms.TreeView();
            this.LoadUnloadIcons = new System.Windows.Forms.ImageList(this.components);
            this.Attachemnts = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.WareHouseMovementsDGV = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Causal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar = new System.Windows.Forms.Panel();
            this.CreateWareHouseBtn = new System.Windows.Forms.Button();
            this.SelectWarehouseCB = new System.Windows.Forms.ComboBox();
            this.MenuName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.stripBtns = new System.Windows.Forms.ToolStrip();
            this.NewBtn = new System.Windows.Forms.ToolStripButton();
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.newBtnCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoadMerchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnloadMerchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoProductToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.AnagrPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseMovementsDGV)).BeginInit();
            this.bar.SuspendLayout();
            this.stripBtns.SuspendLayout();
            this.newBtnCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectAllRows
            // 
            this.selectAllRows.AutoSize = true;
            this.selectAllRows.Location = new System.Drawing.Point(39, 39);
            this.selectAllRows.Margin = new System.Windows.Forms.Padding(4);
            this.selectAllRows.Name = "selectAllRows";
            this.selectAllRows.Size = new System.Drawing.Size(18, 17);
            this.selectAllRows.TabIndex = 13;
            this.selectAllRows.UseVisualStyleBackColor = true;
            this.selectAllRows.CheckedChanged += new System.EventHandler(this.selectAllRows_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AnagrPanel
            // 
            this.AnagrPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnagrPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AnagrPanel.Controls.Add(this.panel1);
            this.AnagrPanel.Controls.Add(this.MovementDetailsTV);
            this.AnagrPanel.Controls.Add(this.Attachemnts);
            this.AnagrPanel.Controls.Add(this.cancelBtn);
            this.AnagrPanel.Controls.Add(this.confirmBtn);
            this.AnagrPanel.Location = new System.Drawing.Point(1021, 28);
            this.AnagrPanel.Margin = new System.Windows.Forms.Padding(4);
            this.AnagrPanel.Name = "AnagrPanel";
            this.AnagrPanel.Size = new System.Drawing.Size(535, 610);
            this.AnagrPanel.TabIndex = 10;
            this.AnagrPanel.MouseHover += new System.EventHandler(this.AnagrPanel_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.TotPieces);
            this.panel1.Controls.Add(this.TotPiecesLbl);
            this.panel1.Location = new System.Drawing.Point(6, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 24);
            this.panel1.TabIndex = 49;
            // 
            // TotPieces
            // 
            this.TotPieces.AutoSize = true;
            this.TotPieces.Location = new System.Drawing.Point(391, 2);
            this.TotPieces.Name = "TotPieces";
            this.TotPieces.Size = new System.Drawing.Size(0, 16);
            this.TotPieces.TabIndex = 1;
            // 
            // TotPiecesLbl
            // 
            this.TotPiecesLbl.AutoSize = true;
            this.TotPiecesLbl.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotPiecesLbl.Location = new System.Drawing.Point(280, 5);
            this.TotPiecesLbl.Name = "TotPiecesLbl";
            this.TotPiecesLbl.Size = new System.Drawing.Size(111, 13);
            this.TotPiecesLbl.TabIndex = 0;
            this.TotPiecesLbl.Text = "Totale pezzi:";
            // 
            // MovementDetailsTV
            // 
            this.MovementDetailsTV.ImageKey = "6518772_household_housework_laundry_machine_washing_icon.png";
            this.MovementDetailsTV.ImageList = this.LoadUnloadIcons;
            this.MovementDetailsTV.Location = new System.Drawing.Point(6, 11);
            this.MovementDetailsTV.Name = "MovementDetailsTV";
            this.MovementDetailsTV.SelectedImageIndex = 0;
            this.MovementDetailsTV.Size = new System.Drawing.Size(492, 481);
            this.MovementDetailsTV.TabIndex = 48;
            this.MovementDetailsTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MovementDetailsTV_AfterSelect);
            this.MovementDetailsTV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MovementDetailsTV_NodeMouseClick);
            this.MovementDetailsTV.MouseHover += new System.EventHandler(this.MovementDetailsTV_MouseHover);
            // 
            // LoadUnloadIcons
            // 
            this.LoadUnloadIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LoadUnloadIcons.ImageStream")));
            this.LoadUnloadIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.LoadUnloadIcons.Images.SetKeyName(0, "plus.png");
            this.LoadUnloadIcons.Images.SetKeyName(1, "delete.png");
            this.LoadUnloadIcons.Images.SetKeyName(2, "6518772_household_housework_laundry_machine_washing_icon.png");
            // 
            // Attachemnts
            // 
            this.Attachemnts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Attachemnts.Image = ((System.Drawing.Image)(resources.GetObject("Attachemnts.Image")));
            this.Attachemnts.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Attachemnts.Location = new System.Drawing.Point(160, 552);
            this.Attachemnts.Margin = new System.Windows.Forms.Padding(4);
            this.Attachemnts.Name = "Attachemnts";
            this.Attachemnts.Size = new System.Drawing.Size(73, 54);
            this.Attachemnts.TabIndex = 47;
            this.Attachemnts.Text = "Allegati";
            this.Attachemnts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Attachemnts.UseVisualStyleBackColor = true;
            this.Attachemnts.Visible = false;
            this.Attachemnts.Click += new System.EventHandler(this.Attachemnts_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cancelBtn.Location = new System.Drawing.Point(83, 567);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(69, 28);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.confirmBtn.FlatAppearance.BorderSize = 0;
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.confirmBtn.Location = new System.Drawing.Point(0, 567);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(4);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(83, 28);
            this.confirmBtn.TabIndex = 6;
            this.confirmBtn.Text = "Conferma";
            this.confirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Visible = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // WareHouseMovementsDGV
            // 
            this.WareHouseMovementsDGV.AllowUserToAddRows = false;
            this.WareHouseMovementsDGV.AllowUserToDeleteRows = false;
            this.WareHouseMovementsDGV.AllowUserToResizeRows = false;
            this.WareHouseMovementsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WareHouseMovementsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WareHouseMovementsDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.WareHouseMovementsDGV.ColumnHeadersHeight = 29;
            this.WareHouseMovementsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.MovementType,
            this.Causal,
            this.Date});
            this.WareHouseMovementsDGV.Location = new System.Drawing.Point(0, 28);
            this.WareHouseMovementsDGV.Margin = new System.Windows.Forms.Padding(4);
            this.WareHouseMovementsDGV.Name = "WareHouseMovementsDGV";
            this.WareHouseMovementsDGV.ReadOnly = true;
            this.WareHouseMovementsDGV.RowHeadersVisible = false;
            this.WareHouseMovementsDGV.RowHeadersWidth = 51;
            this.WareHouseMovementsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WareHouseMovementsDGV.Size = new System.Drawing.Size(1020, 610);
            this.WareHouseMovementsDGV.TabIndex = 9;
            this.WareHouseMovementsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WareHouseMovementsDGV_CellClick);         
            this.WareHouseMovementsDGV.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.WareHouseDGV_ColumnWidthChanged);
            this.WareHouseMovementsDGV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.WareHouseMovementsDGV_RowEnter);
            this.WareHouseMovementsDGV.MouseHover += new System.EventHandler(this.WareHouseMovementsDGV_MouseHover);
            // 
            // IdColumn
            // 
            this.IdColumn.FillWeight = 1.087581F;
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.MinimumWidth = 6;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            // 
            // MovementType
            // 
            this.MovementType.FillWeight = 2.033777F;
            this.MovementType.HeaderText = "Tipo movimento";
            this.MovementType.MinimumWidth = 6;
            this.MovementType.Name = "MovementType";
            this.MovementType.ReadOnly = true;
            // 
            // Causal
            // 
            this.Causal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Causal.HeaderText = "Causale";
            this.Causal.MinimumWidth = 6;
            this.Causal.Name = "Causal";
            this.Causal.ReadOnly = true;
            this.Causal.Width = 86;
            // 
            // Date
            // 
            this.Date.FillWeight = 10.03553F;
            this.Date.HeaderText = "Data Movimento";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // bar
            // 
            this.bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bar.Controls.Add(this.CreateWareHouseBtn);
            this.bar.Controls.Add(this.SelectWarehouseCB);
            this.bar.Controls.Add(this.MenuName);
            this.bar.Controls.Add(this.button1);
            this.bar.Controls.Add(this.searchBox);
            this.bar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bar.Location = new System.Drawing.Point(-27, 0);
            this.bar.Margin = new System.Windows.Forms.Padding(5);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1585, 27);
            this.bar.TabIndex = 11;
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
            this.SelectWarehouseCB.SelectedIndexChanged += new System.EventHandler(this.selectWarehouseCB_SelectedIndexChanged);
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
            this.button1.Location = new System.Drawing.Point(1271, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 27);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchBox.Location = new System.Drawing.Point(1317, 0);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(264, 27);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Cerca";
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
            this.stripBtns.TabIndex = 12;
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
            this.NewBtn.Click += new System.EventHandler(this.newBtn_Click);
            this.NewBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newBtn_MouseDown);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(72, 46);
            this.editBtn.Text = "Modifica";
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
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
            // newBtnCMS
            // 
            this.newBtnCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.newBtnCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadMerchItem,
            this.UnloadMerchItem,
            this.WHToolStripMenuItem});
            this.newBtnCMS.Name = "newBtnCMS";
            this.newBtnCMS.Size = new System.Drawing.Size(156, 82);
            // 
            // LoadMerchItem
            // 
            this.LoadMerchItem.Image = global::GManagerial.Properties.Resources.plus;
            this.LoadMerchItem.Name = "LoadMerchItem";
            this.LoadMerchItem.Size = new System.Drawing.Size(155, 26);
            this.LoadMerchItem.Text = "Carico";
            this.LoadMerchItem.Click += new System.EventHandler(this.LoadMerchItem_Click);
            // 
            // UnloadMerchItem
            // 
            this.UnloadMerchItem.Image = ((System.Drawing.Image)(resources.GetObject("UnloadMerchItem.Image")));
            this.UnloadMerchItem.Name = "UnloadMerchItem";
            this.UnloadMerchItem.Size = new System.Drawing.Size(155, 26);
            this.UnloadMerchItem.Text = "Scarico";
            this.UnloadMerchItem.Click += new System.EventHandler(this.UnloadMerchItem_Click);
            // 
            // WHToolStripMenuItem
            // 
            this.WHToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("WHToolStripMenuItem.Image")));
            this.WHToolStripMenuItem.Name = "WHToolStripMenuItem";
            this.WHToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.WHToolStripMenuItem.Text = "Magazzino";
            this.WHToolStripMenuItem.Click += new System.EventHandler(this.WHToolStripMenuItem_Click);
            // 
            // WarehouseMovementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 690);
            this.Controls.Add(this.selectAllRows);
            this.Controls.Add(this.AnagrPanel);
            this.Controls.Add(this.WareHouseMovementsDGV);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.stripBtns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WarehouseMovementsForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Warehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.AnagrPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseMovementsDGV)).EndInit();
            this.bar.ResumeLayout(false);
            this.bar.PerformLayout();
            this.stripBtns.ResumeLayout(false);
            this.stripBtns.PerformLayout();
            this.newBtnCMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Attachemnts;
        private System.Windows.Forms.CheckBox selectAllRows;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel AnagrPanel;
        private System.Windows.Forms.DataGridView WareHouseMovementsDGV;
        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Label MenuName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ToolStrip stripBtns;
        private System.Windows.Forms.ToolStripButton NewBtn;
        private System.Windows.Forms.ToolStripButton editBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.ContextMenuStrip newBtnCMS;
        private System.Windows.Forms.ToolStripMenuItem UnloadMerchItem;
        private System.Windows.Forms.ComboBox SelectWarehouseCB;
        private System.Windows.Forms.ToolStripMenuItem LoadMerchItem;
        private System.Windows.Forms.Button CreateWareHouseBtn;
        private System.Windows.Forms.ToolStripMenuItem WHToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Causal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.TreeView MovementDetailsTV;
        private System.Windows.Forms.ImageList LoadUnloadIcons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TotPieces;
        private System.Windows.Forms.Label TotPiecesLbl;
        private System.Windows.Forms.ToolTip NoProductToolTip;
    }
}