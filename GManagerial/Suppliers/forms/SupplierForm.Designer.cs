namespace GManagerial
{
    partial class SupplierForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierForm));
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.stripBtns = new System.Windows.Forms.ToolStrip();
            this.newBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.CopyBtn = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.bar = new System.Windows.Forms.Panel();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.MenuName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SupplierDGV = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProvinceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelephoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnagrPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.ProvinceSigleTB = new System.Windows.Forms.TextBox();
            this.DocsButton = new System.Windows.Forms.Button();
            this.AttachmentsBtn = new System.Windows.Forms.Button();
            this.phoneBtn = new System.Windows.Forms.Button();
            this.mailBtn = new System.Windows.Forms.Button();
            this.whatsappChat = new System.Windows.Forms.PictureBox();
            this.ivaLbl = new System.Windows.Forms.Label();
            this.VatPanelTB = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.RecipientCodePanelTB = new System.Windows.Forms.TextBox();
            this.cod_destin = new System.Windows.Forms.Label();
            this.ZipCodePanelLBL = new System.Windows.Forms.Label();
            this.ZipCodePanelTB = new System.Windows.Forms.TextBox();
            this.AddressPanelLBL = new System.Windows.Forms.Label();
            this.AddressPanelTB = new System.Windows.Forms.TextBox();
            this.pec = new System.Windows.Forms.Label();
            this.PecPanelTB = new System.Windows.Forms.TextBox();
            this.notes = new System.Windows.Forms.Label();
            this.NotesPanelTB = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mail = new System.Windows.Forms.Label();
            this.mobile = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.Label();
            this.MailPanelTB = new System.Windows.Forms.TextBox();
            this.MobilePanelTB = new GManagerial.GraphicElements.IntTextBox();
            this.TelephonePanelTB = new GManagerial.GraphicElements.IntTextBox();
            this.CityPanelCB = new System.Windows.Forms.ComboBox();
            this.CityPanelLBL = new System.Windows.Forms.Label();
            this.ProvincePanelCB = new System.Windows.Forms.ComboBox();
            this.RegionPanelCB = new System.Windows.Forms.ComboBox();
            this.ProvincePanelLBL = new System.Windows.Forms.Label();
            this.IdTaxPanelTB = new System.Windows.Forms.TextBox();
            this.SupplierNamePanelTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectAllRows = new System.Windows.Forms.CheckBox();
            this.SearchFilterPanel = new System.Windows.Forms.Panel();
            this.DeleteFilterSearchBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchFor = new System.Windows.Forms.Label();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.separatorPanel = new System.Windows.Forms.Panel();
            this.CityPanelSearchCB = new System.Windows.Forms.ComboBox();
            this.ProvincePanelSearchCB = new System.Windows.Forms.ComboBox();
            this.RegionPanelSearchCB = new System.Windows.Forms.ComboBox();
            this.CityPanelSearchLbl = new System.Windows.Forms.Label();
            this.ProvincePanelSearchLbl = new System.Windows.Forms.Label();
            this.RegionLbl = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stripBtns.SuspendLayout();
            this.bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDGV)).BeginInit();
            this.AnagrPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.whatsappChat)).BeginInit();
            this.SearchFilterPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
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
            // stripBtns
            // 
            this.stripBtns.AutoSize = false;
            this.stripBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stripBtns.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stripBtns.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stripBtns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.editBtn,
            this.deleteBtn,
            this.CopyBtn});
            this.stripBtns.Location = new System.Drawing.Point(0, 689);
            this.stripBtns.Name = "stripBtns";
            this.stripBtns.Size = new System.Drawing.Size(1584, 49);
            this.stripBtns.TabIndex = 10;
            this.stripBtns.Text = "toolStrip1";
            // 
            // newBtn
            // 
            this.newBtn.Image = ((System.Drawing.Image)(resources.GetObject("newBtn.Image")));
            this.newBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(43, 46);
            this.newBtn.Text = "Crea";
            this.newBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
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
            // CopyBtn
            // 
            this.CopyBtn.Image = ((System.Drawing.Image)(resources.GetObject("CopyBtn.Image")));
            this.CopyBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(52, 46);
            this.CopyBtn.Text = "Copia";
            this.CopyBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
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
            // bar
            // 
            this.bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bar.Controls.Add(this.SearchTB);
            this.bar.Controls.Add(this.SearchBtn);
            this.bar.Controls.Add(this.MenuName);
            this.bar.Controls.Add(this.button1);
            this.bar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bar.Location = new System.Drawing.Point(0, 0);
            this.bar.Margin = new System.Windows.Forms.Padding(5);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1585, 27);
            this.bar.TabIndex = 9;
            // 
            // SearchTB
            // 
            this.SearchTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchTB.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SearchTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTB.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.SearchTB.Location = new System.Drawing.Point(1321, 0);
            this.SearchTB.Margin = new System.Windows.Forms.Padding(4);
            this.SearchTB.Multiline = true;
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(264, 27);
            this.SearchTB.TabIndex = 17;
            this.SearchTB.Text = "Cerca";
            this.SearchTB.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.SearchTB.Enter += new System.EventHandler(this.searchBox_Enter);
            this.SearchTB.Leave += new System.EventHandler(this.searchBox_Leave);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SearchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SearchBtn.Image = ((System.Drawing.Image)(resources.GetObject("SearchBtn.Image")));
            this.SearchBtn.Location = new System.Drawing.Point(1211, 0);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(51, 28);
            this.SearchBtn.TabIndex = 16;
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // MenuName
            // 
            this.MenuName.AutoSize = true;
            this.MenuName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuName.Location = new System.Drawing.Point(5, 1);
            this.MenuName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MenuName.Name = "MenuName";
            this.MenuName.Size = new System.Drawing.Size(94, 27);
            this.MenuName.TabIndex = 0;
            this.MenuName.Text = "Fornitori";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SupplierDGV
            // 
            this.SupplierDGV.AllowUserToAddRows = false;
            this.SupplierDGV.AllowUserToResizeRows = false;
            this.SupplierDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierDGV.ColumnHeadersHeight = 29;
            this.SupplierDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.SupplierNameColumn,
            this.RegionColumn,
            this.ProvinceColumn,
            this.CityColumn,
            this.AddressColumn,
            this.TelephoneColumn});
            this.SupplierDGV.Location = new System.Drawing.Point(0, 28);
            this.SupplierDGV.Margin = new System.Windows.Forms.Padding(4);
            this.SupplierDGV.Name = "SupplierDGV";
            this.SupplierDGV.ReadOnly = true;
            this.SupplierDGV.RowHeadersVisible = false;
            this.SupplierDGV.RowHeadersWidth = 51;
            this.SupplierDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplierDGV.Size = new System.Drawing.Size(1048, 658);
            this.SupplierDGV.TabIndex = 7;
            this.SupplierDGV.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.SupplierDGV_ColumnWidthChanged);
            this.SupplierDGV.SelectionChanged += new System.EventHandler(this.SupplierDGV_SelectionChanged);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            // 
            // SupplierNameColumn
            // 
            this.SupplierNameColumn.HeaderText = "Nome fornitore";
            this.SupplierNameColumn.MinimumWidth = 6;
            this.SupplierNameColumn.Name = "SupplierNameColumn";
            this.SupplierNameColumn.ReadOnly = true;
            // 
            // RegionColumn
            // 
            this.RegionColumn.HeaderText = "Regione";
            this.RegionColumn.MinimumWidth = 6;
            this.RegionColumn.Name = "RegionColumn";
            this.RegionColumn.ReadOnly = true;
            // 
            // ProvinceColumn
            // 
            this.ProvinceColumn.HeaderText = "Provincia";
            this.ProvinceColumn.MinimumWidth = 6;
            this.ProvinceColumn.Name = "ProvinceColumn";
            this.ProvinceColumn.ReadOnly = true;
            // 
            // CityColumn
            // 
            this.CityColumn.HeaderText = "Città";
            this.CityColumn.MinimumWidth = 6;
            this.CityColumn.Name = "CityColumn";
            this.CityColumn.ReadOnly = true;
            // 
            // AddressColumn
            // 
            this.AddressColumn.HeaderText = "Indirizzo";
            this.AddressColumn.MinimumWidth = 6;
            this.AddressColumn.Name = "AddressColumn";
            this.AddressColumn.ReadOnly = true;
            // 
            // TelephoneColumn
            // 
            this.TelephoneColumn.HeaderText = "Telefono";
            this.TelephoneColumn.MinimumWidth = 6;
            this.TelephoneColumn.Name = "TelephoneColumn";
            this.TelephoneColumn.ReadOnly = true;
            // 
            // AnagrPanel
            // 
            this.AnagrPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnagrPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AnagrPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnagrPanel.Controls.Add(this.label7);
            this.AnagrPanel.Controls.Add(this.ProvinceSigleTB);
            this.AnagrPanel.Controls.Add(this.DocsButton);
            this.AnagrPanel.Controls.Add(this.AttachmentsBtn);
            this.AnagrPanel.Controls.Add(this.phoneBtn);
            this.AnagrPanel.Controls.Add(this.mailBtn);
            this.AnagrPanel.Controls.Add(this.whatsappChat);
            this.AnagrPanel.Controls.Add(this.ivaLbl);
            this.AnagrPanel.Controls.Add(this.VatPanelTB);
            this.AnagrPanel.Controls.Add(this.CancelBtn);
            this.AnagrPanel.Controls.Add(this.ConfirmBtn);
            this.AnagrPanel.Controls.Add(this.RecipientCodePanelTB);
            this.AnagrPanel.Controls.Add(this.cod_destin);
            this.AnagrPanel.Controls.Add(this.ZipCodePanelLBL);
            this.AnagrPanel.Controls.Add(this.ZipCodePanelTB);
            this.AnagrPanel.Controls.Add(this.AddressPanelLBL);
            this.AnagrPanel.Controls.Add(this.AddressPanelTB);
            this.AnagrPanel.Controls.Add(this.pec);
            this.AnagrPanel.Controls.Add(this.PecPanelTB);
            this.AnagrPanel.Controls.Add(this.notes);
            this.AnagrPanel.Controls.Add(this.NotesPanelTB);
            this.AnagrPanel.Controls.Add(this.panel3);
            this.AnagrPanel.Controls.Add(this.panel1);
            this.AnagrPanel.Controls.Add(this.mail);
            this.AnagrPanel.Controls.Add(this.mobile);
            this.AnagrPanel.Controls.Add(this.telephone);
            this.AnagrPanel.Controls.Add(this.MailPanelTB);
            this.AnagrPanel.Controls.Add(this.MobilePanelTB);
            this.AnagrPanel.Controls.Add(this.TelephonePanelTB);
            this.AnagrPanel.Controls.Add(this.CityPanelCB);
            this.AnagrPanel.Controls.Add(this.CityPanelLBL);
            this.AnagrPanel.Controls.Add(this.ProvincePanelCB);
            this.AnagrPanel.Controls.Add(this.RegionPanelCB);
            this.AnagrPanel.Controls.Add(this.ProvincePanelLBL);
            this.AnagrPanel.Controls.Add(this.IdTaxPanelTB);
            this.AnagrPanel.Controls.Add(this.SupplierNamePanelTB);
            this.AnagrPanel.Controls.Add(this.label4);
            this.AnagrPanel.Controls.Add(this.label2);
            this.AnagrPanel.Controls.Add(this.label1);
            this.AnagrPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AnagrPanel.Enabled = false;
            this.AnagrPanel.Location = new System.Drawing.Point(1049, 28);
            this.AnagrPanel.Margin = new System.Windows.Forms.Padding(4);
            this.AnagrPanel.Name = "AnagrPanel";
            this.AnagrPanel.Size = new System.Drawing.Size(534, 658);
            this.AnagrPanel.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(336, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "Sigla Provincia";
            // 
            // ProvinceSigleTB
            // 
            this.ProvinceSigleTB.Enabled = false;
            this.ProvinceSigleTB.Location = new System.Drawing.Point(339, 147);
            this.ProvinceSigleTB.Name = "ProvinceSigleTB";
            this.ProvinceSigleTB.Size = new System.Drawing.Size(100, 22);
            this.ProvinceSigleTB.TabIndex = 46;
            // 
            // DocsButton
            // 
            this.DocsButton.Image = ((System.Drawing.Image)(resources.GetObject("DocsButton.Image")));
            this.DocsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DocsButton.Location = new System.Drawing.Point(4, 588);
            this.DocsButton.Margin = new System.Windows.Forms.Padding(4);
            this.DocsButton.Name = "DocsButton";
            this.DocsButton.Size = new System.Drawing.Size(109, 46);
            this.DocsButton.TabIndex = 32;
            this.DocsButton.Text = "Documenti";
            this.DocsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DocsButton.UseVisualStyleBackColor = true;
            this.DocsButton.Visible = false;
            // 
            // AttachmentsBtn
            // 
            this.AttachmentsBtn.FlatAppearance.BorderSize = 0;
            this.AttachmentsBtn.Image = ((System.Drawing.Image)(resources.GetObject("AttachmentsBtn.Image")));
            this.AttachmentsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AttachmentsBtn.Location = new System.Drawing.Point(121, 588);
            this.AttachmentsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AttachmentsBtn.Name = "AttachmentsBtn";
            this.AttachmentsBtn.Size = new System.Drawing.Size(108, 46);
            this.AttachmentsBtn.TabIndex = 33;
            this.AttachmentsBtn.Text = "Allegati";
            this.AttachmentsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AttachmentsBtn.UseVisualStyleBackColor = true;
            this.AttachmentsBtn.Visible = false;
            this.AttachmentsBtn.Click += new System.EventHandler(this.AttachmentsBtn_Click);
            // 
            // phoneBtn
            // 
            this.phoneBtn.FlatAppearance.BorderSize = 0;
            this.phoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.phoneBtn.Image = ((System.Drawing.Image)(resources.GetObject("phoneBtn.Image")));
            this.phoneBtn.Location = new System.Drawing.Point(216, 262);
            this.phoneBtn.Margin = new System.Windows.Forms.Padding(4);
            this.phoneBtn.Name = "phoneBtn";
            this.phoneBtn.Size = new System.Drawing.Size(33, 25);
            this.phoneBtn.TabIndex = 45;
            this.phoneBtn.UseVisualStyleBackColor = true;
            this.phoneBtn.Click += new System.EventHandler(this.phoneBtn_Click);
            // 
            // mailBtn
            // 
            this.mailBtn.FlatAppearance.BorderSize = 0;
            this.mailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mailBtn.Image = ((System.Drawing.Image)(resources.GetObject("mailBtn.Image")));
            this.mailBtn.Location = new System.Drawing.Point(219, 318);
            this.mailBtn.Margin = new System.Windows.Forms.Padding(4);
            this.mailBtn.Name = "mailBtn";
            this.mailBtn.Size = new System.Drawing.Size(28, 25);
            this.mailBtn.TabIndex = 40;
            this.mailBtn.UseVisualStyleBackColor = true;
            this.mailBtn.Click += new System.EventHandler(this.mailBtn_Click);
            // 
            // whatsappChat
            // 
            this.whatsappChat.Image = ((System.Drawing.Image)(resources.GetObject("whatsappChat.Image")));
            this.whatsappChat.Location = new System.Drawing.Point(445, 263);
            this.whatsappChat.Margin = new System.Windows.Forms.Padding(4);
            this.whatsappChat.Name = "whatsappChat";
            this.whatsappChat.Size = new System.Drawing.Size(28, 25);
            this.whatsappChat.TabIndex = 39;
            this.whatsappChat.TabStop = false;
            this.whatsappChat.Click += new System.EventHandler(this.whatsappChat_Click);
            // 
            // ivaLbl
            // 
            this.ivaLbl.AutoSize = true;
            this.ivaLbl.Location = new System.Drawing.Point(7, 68);
            this.ivaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ivaLbl.Name = "ivaLbl";
            this.ivaLbl.Size = new System.Drawing.Size(69, 16);
            this.ivaLbl.TabIndex = 38;
            this.ivaLbl.Text = "Partita IVA";
            // 
            // VatPanelTB
            // 
            this.VatPanelTB.Location = new System.Drawing.Point(7, 89);
            this.VatPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.VatPanelTB.Name = "VatPanelTB";
            this.VatPanelTB.Size = new System.Drawing.Size(205, 22);
            this.VatPanelTB.TabIndex = 37;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CancelBtn.Location = new System.Drawing.Point(100, 564);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(73, 26);
            this.CancelBtn.TabIndex = 15;
            this.CancelBtn.Text = "Annulla";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Visible = false;
            this.CancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.FlatAppearance.BorderSize = 0;
            this.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ConfirmBtn.Location = new System.Drawing.Point(5, 564);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(87, 26);
            this.ConfirmBtn.TabIndex = 14;
            this.ConfirmBtn.Text = "Conferma";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Visible = false;
            this.ConfirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // RecipientCodePanelTB
            // 
            this.RecipientCodePanelTB.Location = new System.Drawing.Point(219, 89);
            this.RecipientCodePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.RecipientCodePanelTB.MaxLength = 7;
            this.RecipientCodePanelTB.Name = "RecipientCodePanelTB";
            this.RecipientCodePanelTB.Size = new System.Drawing.Size(259, 22);
            this.RecipientCodePanelTB.TabIndex = 35;
            // 
            // cod_destin
            // 
            this.cod_destin.AutoSize = true;
            this.cod_destin.Location = new System.Drawing.Point(215, 68);
            this.cod_destin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cod_destin.Name = "cod_destin";
            this.cod_destin.Size = new System.Drawing.Size(107, 16);
            this.cod_destin.TabIndex = 34;
            this.cod_destin.Text = "Cod.Destinatario";
            // 
            // ZipCodePanelLBL
            // 
            this.ZipCodePanelLBL.AutoSize = true;
            this.ZipCodePanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ZipCodePanelLBL.Location = new System.Drawing.Point(168, 175);
            this.ZipCodePanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ZipCodePanelLBL.Name = "ZipCodePanelLBL";
            this.ZipCodePanelLBL.Size = new System.Drawing.Size(32, 16);
            this.ZipCodePanelLBL.TabIndex = 33;
            this.ZipCodePanelLBL.Text = "Cap";
            // 
            // ZipCodePanelTB
            // 
            this.ZipCodePanelTB.Enabled = false;
            this.ZipCodePanelTB.Location = new System.Drawing.Point(171, 194);
            this.ZipCodePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.ZipCodePanelTB.MaxLength = 5;
            this.ZipCodePanelTB.Name = "ZipCodePanelTB";
            this.ZipCodePanelTB.Size = new System.Drawing.Size(41, 22);
            this.ZipCodePanelTB.TabIndex = 32;
            // 
            // AddressPanelLBL
            // 
            this.AddressPanelLBL.AutoSize = true;
            this.AddressPanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.AddressPanelLBL.Location = new System.Drawing.Point(213, 175);
            this.AddressPanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressPanelLBL.Name = "AddressPanelLBL";
            this.AddressPanelLBL.Size = new System.Drawing.Size(55, 16);
            this.AddressPanelLBL.TabIndex = 31;
            this.AddressPanelLBL.Text = "Indirizzo";
            // 
            // AddressPanelTB
            // 
            this.AddressPanelTB.Enabled = false;
            this.AddressPanelTB.Location = new System.Drawing.Point(216, 194);
            this.AddressPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.AddressPanelTB.MaxLength = 30;
            this.AddressPanelTB.Name = "AddressPanelTB";
            this.AddressPanelTB.Size = new System.Drawing.Size(261, 22);
            this.AddressPanelTB.TabIndex = 30;
            // 
            // pec
            // 
            this.pec.AutoSize = true;
            this.pec.Location = new System.Drawing.Point(261, 298);
            this.pec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pec.Name = "pec";
            this.pec.Size = new System.Drawing.Size(31, 16);
            this.pec.TabIndex = 29;
            this.pec.Text = "Pec";
            // 
            // PecPanelTB
            // 
            this.PecPanelTB.Location = new System.Drawing.Point(265, 318);
            this.PecPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.PecPanelTB.MaxLength = 100;
            this.PecPanelTB.Name = "PecPanelTB";
            this.PecPanelTB.Size = new System.Drawing.Size(171, 22);
            this.PecPanelTB.TabIndex = 28;
            // 
            // notes
            // 
            this.notes.AutoSize = true;
            this.notes.Location = new System.Drawing.Point(7, 364);
            this.notes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(36, 16);
            this.notes.TabIndex = 27;
            this.notes.Text = "Note";
            // 
            // NotesPanelTB
            // 
            this.NotesPanelTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotesPanelTB.Location = new System.Drawing.Point(5, 384);
            this.NotesPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.NotesPanelTB.Multiline = true;
            this.NotesPanelTB.Name = "NotesPanelTB";
            this.NotesPanelTB.Size = new System.Drawing.Size(524, 171);
            this.NotesPanelTB.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(5, 352);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 2);
            this.panel3.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(5, 228);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 2);
            this.panel1.TabIndex = 24;
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.Location = new System.Drawing.Point(11, 298);
            this.mail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(41, 16);
            this.mail.TabIndex = 23;
            this.mail.Text = "Email";
            // 
            // mobile
            // 
            this.mobile.AutoSize = true;
            this.mobile.Location = new System.Drawing.Point(261, 242);
            this.mobile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(60, 16);
            this.mobile.TabIndex = 22;
            this.mobile.Text = "Cellulare";
            // 
            // telephone
            // 
            this.telephone.AutoSize = true;
            this.telephone.Location = new System.Drawing.Point(7, 242);
            this.telephone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.telephone.Name = "telephone";
            this.telephone.Size = new System.Drawing.Size(61, 16);
            this.telephone.TabIndex = 21;
            this.telephone.Text = "Telefono";
            // 
            // MailPanelTB
            // 
            this.MailPanelTB.Location = new System.Drawing.Point(12, 318);
            this.MailPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.MailPanelTB.MaxLength = 100;
            this.MailPanelTB.Name = "MailPanelTB";
            this.MailPanelTB.Size = new System.Drawing.Size(201, 22);
            this.MailPanelTB.TabIndex = 20;
            // 
            // MobilePanelTB
            // 
            this.MobilePanelTB.Location = new System.Drawing.Point(267, 263);
            this.MobilePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.MobilePanelTB.MaxLength = 20;
            this.MobilePanelTB.Name = "MobilePanelTB";
            this.MobilePanelTB.Size = new System.Drawing.Size(169, 22);
            this.MobilePanelTB.TabIndex = 19;
            // 
            // TelephonePanelTB
            // 
            this.TelephonePanelTB.Location = new System.Drawing.Point(11, 263);
            this.TelephonePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.TelephonePanelTB.MaxLength = 20;
            this.TelephonePanelTB.Name = "TelephonePanelTB";
            this.TelephonePanelTB.Size = new System.Drawing.Size(203, 22);
            this.TelephonePanelTB.TabIndex = 18;
            // 
            // CityPanelCB
            // 
            this.CityPanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CityPanelCB.Enabled = false;
            this.CityPanelCB.FormattingEnabled = true;
            this.CityPanelCB.Location = new System.Drawing.Point(7, 194);
            this.CityPanelCB.Margin = new System.Windows.Forms.Padding(4);
            this.CityPanelCB.Name = "CityPanelCB";
            this.CityPanelCB.Size = new System.Drawing.Size(159, 24);
            this.CityPanelCB.TabIndex = 13;
            this.CityPanelCB.SelectedIndexChanged += new System.EventHandler(this.CityPanelCB_SelectedIndexChanged);
            // 
            // CityPanelLBL
            // 
            this.CityPanelLBL.AutoSize = true;
            this.CityPanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CityPanelLBL.Location = new System.Drawing.Point(7, 175);
            this.CityPanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CityPanelLBL.Name = "CityPanelLBL";
            this.CityPanelLBL.Size = new System.Drawing.Size(57, 16);
            this.CityPanelLBL.TabIndex = 12;
            this.CityPanelLBL.Text = "Comune";
            // 
            // ProvincePanelCB
            // 
            this.ProvincePanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvincePanelCB.Enabled = false;
            this.ProvincePanelCB.FormattingEnabled = true;
            this.ProvincePanelCB.Location = new System.Drawing.Point(171, 146);
            this.ProvincePanelCB.Margin = new System.Windows.Forms.Padding(4);
            this.ProvincePanelCB.Name = "ProvincePanelCB";
            this.ProvincePanelCB.Size = new System.Drawing.Size(160, 24);
            this.ProvincePanelCB.TabIndex = 11;
            this.ProvincePanelCB.SelectedIndexChanged += new System.EventHandler(this.provBox_SelectedIndexChanged);
            // 
            // RegionPanelCB
            // 
            this.RegionPanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionPanelCB.FormattingEnabled = true;
            this.RegionPanelCB.Location = new System.Drawing.Point(7, 146);
            this.RegionPanelCB.Margin = new System.Windows.Forms.Padding(4);
            this.RegionPanelCB.Name = "RegionPanelCB";
            this.RegionPanelCB.Size = new System.Drawing.Size(159, 24);
            this.RegionPanelCB.TabIndex = 10;
            this.RegionPanelCB.SelectedIndexChanged += new System.EventHandler(this.regionBox_SelectedIndexChanged);
            // 
            // ProvincePanelLBL
            // 
            this.ProvincePanelLBL.AutoSize = true;
            this.ProvincePanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ProvincePanelLBL.Location = new System.Drawing.Point(168, 127);
            this.ProvincePanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProvincePanelLBL.Name = "ProvincePanelLBL";
            this.ProvincePanelLBL.Size = new System.Drawing.Size(63, 16);
            this.ProvincePanelLBL.TabIndex = 9;
            this.ProvincePanelLBL.Text = "Provincia";
            // 
            // IdTaxPanelTB
            // 
            this.IdTaxPanelTB.Location = new System.Drawing.Point(219, 34);
            this.IdTaxPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.IdTaxPanelTB.MaxLength = 18;
            this.IdTaxPanelTB.Name = "IdTaxPanelTB";
            this.IdTaxPanelTB.Size = new System.Drawing.Size(260, 22);
            this.IdTaxPanelTB.TabIndex = 7;
            // 
            // SupplierNamePanelTB
            // 
            this.SupplierNamePanelTB.Location = new System.Drawing.Point(7, 34);
            this.SupplierNamePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.SupplierNamePanelTB.MaxLength = 49;
            this.SupplierNamePanelTB.Name = "SupplierNamePanelTB";
            this.SupplierNamePanelTB.Size = new System.Drawing.Size(205, 22);
            this.SupplierNamePanelTB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Regione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cod.Fiscale";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Denominazione";
            // 
            // SelectAllRows
            // 
            this.SelectAllRows.AutoSize = true;
            this.SelectAllRows.Location = new System.Drawing.Point(47, 36);
            this.SelectAllRows.Margin = new System.Windows.Forms.Padding(4);
            this.SelectAllRows.Name = "SelectAllRows";
            this.SelectAllRows.Size = new System.Drawing.Size(18, 17);
            this.SelectAllRows.TabIndex = 12;
            this.SelectAllRows.UseVisualStyleBackColor = true;
            this.SelectAllRows.CheckedChanged += new System.EventHandler(this.selectAllRows_CheckedChanged);
            // 
            // SearchFilterPanel
            // 
            this.SearchFilterPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SearchFilterPanel.Controls.Add(this.DeleteFilterSearchBtn);
            this.SearchFilterPanel.Controls.Add(this.label3);
            this.SearchFilterPanel.Controls.Add(this.label5);
            this.SearchFilterPanel.Controls.Add(this.label6);
            this.SearchFilterPanel.Controls.Add(this.panel2);
            this.SearchFilterPanel.Controls.Add(this.separatorPanel);
            this.SearchFilterPanel.Controls.Add(this.CityPanelSearchCB);
            this.SearchFilterPanel.Controls.Add(this.ProvincePanelSearchCB);
            this.SearchFilterPanel.Controls.Add(this.RegionPanelSearchCB);
            this.SearchFilterPanel.Controls.Add(this.CityPanelSearchLbl);
            this.SearchFilterPanel.Controls.Add(this.ProvincePanelSearchLbl);
            this.SearchFilterPanel.Controls.Add(this.RegionLbl);
            this.SearchFilterPanel.Location = new System.Drawing.Point(643, 97);
            this.SearchFilterPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SearchFilterPanel.Name = "SearchFilterPanel";
            this.SearchFilterPanel.Size = new System.Drawing.Size(279, 246);
            this.SearchFilterPanel.TabIndex = 13;
            this.SearchFilterPanel.Visible = false;
            // 
            // DeleteFilterSearchBtn
            // 
            this.DeleteFilterSearchBtn.Location = new System.Drawing.Point(193, 209);
            this.DeleteFilterSearchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteFilterSearchBtn.Name = "DeleteFilterSearchBtn";
            this.DeleteFilterSearchBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteFilterSearchBtn.TabIndex = 13;
            this.DeleteFilterSearchBtn.Text = "Cancella";
            this.DeleteFilterSearchBtn.UseVisualStyleBackColor = true;
            this.DeleteFilterSearchBtn.Click += new System.EventHandler(this.DeleteFilterSearchBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "-";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.searchFor);
            this.panel2.Controls.Add(this.pbSearch);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(279, 34);
            this.panel2.TabIndex = 9;
            // 
            // searchFor
            // 
            this.searchFor.AutoSize = true;
            this.searchFor.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchFor.Location = new System.Drawing.Point(4, 11);
            this.searchFor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchFor.Name = "searchFor";
            this.searchFor.Size = new System.Drawing.Size(94, 21);
            this.searchFor.TabIndex = 6;
            this.searchFor.Text = "Cerca per:";
            // 
            // pbSearch
            // 
            this.pbSearch.Image = ((System.Drawing.Image)(resources.GetObject("pbSearch.Image")));
            this.pbSearch.Location = new System.Drawing.Point(95, 6);
            this.pbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(35, 25);
            this.pbSearch.TabIndex = 8;
            this.pbSearch.TabStop = false;
            // 
            // separatorPanel
            // 
            this.separatorPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.separatorPanel.Location = new System.Drawing.Point(8, 37);
            this.separatorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.separatorPanel.Name = "separatorPanel";
            this.separatorPanel.Size = new System.Drawing.Size(267, 1);
            this.separatorPanel.TabIndex = 7;
            // 
            // CityPanelSearchCB
            // 
            this.CityPanelSearchCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CityPanelSearchCB.Enabled = false;
            this.CityPanelSearchCB.FormattingEnabled = true;
            this.CityPanelSearchCB.Location = new System.Drawing.Point(108, 150);
            this.CityPanelSearchCB.Margin = new System.Windows.Forms.Padding(4);
            this.CityPanelSearchCB.Name = "CityPanelSearchCB";
            this.CityPanelSearchCB.Size = new System.Drawing.Size(160, 24);
            this.CityPanelSearchCB.TabIndex = 5;
            this.CityPanelSearchCB.SelectedIndexChanged += new System.EventHandler(this.CityPanelSearchCB_SelectedIndexChanged);
            // 
            // ProvincePanelSearchCB
            // 
            this.ProvincePanelSearchCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvincePanelSearchCB.Enabled = false;
            this.ProvincePanelSearchCB.FormattingEnabled = true;
            this.ProvincePanelSearchCB.Location = new System.Drawing.Point(108, 100);
            this.ProvincePanelSearchCB.Margin = new System.Windows.Forms.Padding(4);
            this.ProvincePanelSearchCB.Name = "ProvincePanelSearchCB";
            this.ProvincePanelSearchCB.Size = new System.Drawing.Size(160, 24);
            this.ProvincePanelSearchCB.TabIndex = 4;
            this.ProvincePanelSearchCB.SelectedIndexChanged += new System.EventHandler(this.provCB_SelectedIndexChanged);
            // 
            // RegionPanelSearchCB
            // 
            this.RegionPanelSearchCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionPanelSearchCB.FormattingEnabled = true;
            this.RegionPanelSearchCB.Location = new System.Drawing.Point(108, 50);
            this.RegionPanelSearchCB.Margin = new System.Windows.Forms.Padding(4);
            this.RegionPanelSearchCB.Name = "RegionPanelSearchCB";
            this.RegionPanelSearchCB.Size = new System.Drawing.Size(160, 24);
            this.RegionPanelSearchCB.TabIndex = 3;
            this.RegionPanelSearchCB.SelectedIndexChanged += new System.EventHandler(this.regionCB_SelectedIndexChanged);
            // 
            // CityPanelSearchLbl
            // 
            this.CityPanelSearchLbl.AutoSize = true;
            this.CityPanelSearchLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CityPanelSearchLbl.Location = new System.Drawing.Point(29, 154);
            this.CityPanelSearchLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CityPanelSearchLbl.Name = "CityPanelSearchLbl";
            this.CityPanelSearchLbl.Size = new System.Drawing.Size(57, 16);
            this.CityPanelSearchLbl.TabIndex = 2;
            this.CityPanelSearchLbl.Text = "Comune";
            // 
            // ProvincePanelSearchLbl
            // 
            this.ProvincePanelSearchLbl.AutoSize = true;
            this.ProvincePanelSearchLbl.Enabled = false;
            this.ProvincePanelSearchLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ProvincePanelSearchLbl.Location = new System.Drawing.Point(29, 103);
            this.ProvincePanelSearchLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProvincePanelSearchLbl.Name = "ProvincePanelSearchLbl";
            this.ProvincePanelSearchLbl.Size = new System.Drawing.Size(63, 16);
            this.ProvincePanelSearchLbl.TabIndex = 1;
            this.ProvincePanelSearchLbl.Text = "Provincia";
            // 
            // RegionLbl
            // 
            this.RegionLbl.AutoSize = true;
            this.RegionLbl.Location = new System.Drawing.Point(29, 54);
            this.RegionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegionLbl.Name = "RegionLbl";
            this.RegionLbl.Size = new System.Drawing.Size(59, 16);
            this.RegionLbl.TabIndex = 0;
            this.RegionLbl.Text = "Regione";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 738);
            this.Controls.Add(this.SearchFilterPanel);
            this.Controls.Add(this.SelectAllRows);
            this.Controls.Add(this.AnagrPanel);
            this.Controls.Add(this.stripBtns);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.SupplierDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SupplierForm";
            this.Text = "SupplierForm";
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            this.stripBtns.ResumeLayout(false);
            this.stripBtns.PerformLayout();
            this.bar.ResumeLayout(false);
            this.bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDGV)).EndInit();
            this.AnagrPanel.ResumeLayout(false);
            this.AnagrPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.whatsappChat)).EndInit();
            this.SearchFilterPanel.ResumeLayout(false);
            this.SearchFilterPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton editBtn;
        private System.Windows.Forms.ToolStrip stripBtns;
        private System.Windows.Forms.ToolStripButton newBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripButton CopyBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Label MenuName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView SupplierDGV;
        public System.Windows.Forms.Panel AnagrPanel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.TextBox RecipientCodePanelTB;
        private System.Windows.Forms.Button AttachmentsBtn;
        private System.Windows.Forms.Button DocsButton;
        private System.Windows.Forms.Label cod_destin;
        private System.Windows.Forms.Label ZipCodePanelLBL;
        private System.Windows.Forms.TextBox ZipCodePanelTB;
        private System.Windows.Forms.Label AddressPanelLBL;
        private System.Windows.Forms.TextBox AddressPanelTB;
        private System.Windows.Forms.Label pec;
        private System.Windows.Forms.TextBox PecPanelTB;
        private System.Windows.Forms.Label notes;
        private System.Windows.Forms.TextBox NotesPanelTB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label mobile;
        private System.Windows.Forms.Label telephone;
        private System.Windows.Forms.TextBox MailPanelTB;
        private System.Windows.Forms.ComboBox CityPanelCB;
        private System.Windows.Forms.Label CityPanelLBL;
        private System.Windows.Forms.ComboBox ProvincePanelCB;
        private System.Windows.Forms.ComboBox RegionPanelCB;
        private System.Windows.Forms.Label ProvincePanelLBL;
        private System.Windows.Forms.TextBox IdTaxPanelTB;
        private System.Windows.Forms.TextBox SupplierNamePanelTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ivaLbl;
        private System.Windows.Forms.TextBox VatPanelTB;
        private System.Windows.Forms.PictureBox whatsappChat;
        private System.Windows.Forms.Button mailBtn;
        private System.Windows.Forms.Button phoneBtn;
        private System.Windows.Forms.CheckBox SelectAllRows;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Panel SearchFilterPanel;
        private System.Windows.Forms.Button DeleteFilterSearchBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label searchFor;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Panel separatorPanel;
        private System.Windows.Forms.ComboBox CityPanelSearchCB;
        private System.Windows.Forms.ComboBox ProvincePanelSearchCB;
        private System.Windows.Forms.ComboBox RegionPanelSearchCB;
        private System.Windows.Forms.Label CityPanelSearchLbl;
        private System.Windows.Forms.Label ProvincePanelSearchLbl;
        private System.Windows.Forms.Label RegionLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvinceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelephoneColumn;
        private GraphicElements.IntTextBox MobilePanelTB;
        private GraphicElements.IntTextBox TelephonePanelTB;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ProvinceSigleTB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}