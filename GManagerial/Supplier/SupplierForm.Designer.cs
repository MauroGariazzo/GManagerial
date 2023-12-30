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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bar = new System.Windows.Forms.Panel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.MenuName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.SupplierDGV = new System.Windows.Forms.DataGridView();
            this.AnagrPanel = new System.Windows.Forms.Panel();
            this.phoneBtn = new System.Windows.Forms.Button();
            this.mailBtn = new System.Windows.Forms.Button();
            this.whatsappChat = new System.Windows.Forms.PictureBox();
            this.ivaLbl = new System.Windows.Forms.Label();
            this.ivaTB = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.coDestBox = new System.Windows.Forms.TextBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.AttachmentsBtn = new System.Windows.Forms.Button();
            this.DocsButton = new System.Windows.Forms.Button();
            this.cod_destin = new System.Windows.Forms.Label();
            this.CapLbl = new System.Windows.Forms.Label();
            this.CapBox = new System.Windows.Forms.TextBox();
            this.AddressLbl = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.pec = new System.Windows.Forms.Label();
            this.pecBox = new System.Windows.Forms.TextBox();
            this.notes = new System.Windows.Forms.Label();
            this.notesBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mail = new System.Windows.Forms.Label();
            this.mobile = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.mobileBox = new System.Windows.Forms.TextBox();
            this.telBox = new System.Windows.Forms.TextBox();
            this.municBox = new System.Windows.Forms.ComboBox();
            this.municipLbl = new System.Windows.Forms.Label();
            this.provBox = new System.Windows.Forms.ComboBox();
            this.regionBox = new System.Windows.Forms.ComboBox();
            this.provLbl = new System.Windows.Forms.Label();
            this.idTaxBox = new System.Windows.Forms.TextBox();
            this.companyTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectAllRows = new System.Windows.Forms.CheckBox();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchbtn2 = new System.Windows.Forms.Button();
            this.resetCB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchFor = new System.Windows.Forms.Label();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.separatorPanel = new System.Windows.Forms.Panel();
            this.cityCB = new System.Windows.Forms.ComboBox();
            this.provCB = new System.Windows.Forms.ComboBox();
            this.regionCB = new System.Windows.Forms.ComboBox();
            this.cityLbl = new System.Windows.Forms.Label();
            this.provinceLbl = new System.Windows.Forms.Label();
            this.RegionLbl = new System.Windows.Forms.Label();
            this.stripBtns.SuspendLayout();
            this.bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDGV)).BeginInit();
            this.AnagrPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.whatsappChat)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
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
            // searchBox
            // 
            this.searchBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchBox.Location = new System.Drawing.Point(1320, 0);
            this.searchBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(264, 27);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Cerca";
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_KeyPress);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
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
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.bar.Controls.Add(this.searchBtn);
            this.bar.Controls.Add(this.MenuName);
            this.bar.Controls.Add(this.button1);
            this.bar.Controls.Add(this.searchBox);
            this.bar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bar.Location = new System.Drawing.Point(0, 0);
            this.bar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1585, 27);
            this.bar.TabIndex = 9;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBtn.BackgroundImage")));
            this.searchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchBtn.Location = new System.Drawing.Point(1211, 0);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(51, 28);
            this.searchBtn.TabIndex = 16;
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
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
            this.SupplierDGV.Location = new System.Drawing.Point(0, 28);
            this.SupplierDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SupplierDGV.Name = "SupplierDGV";
            this.SupplierDGV.ReadOnly = true;
            this.SupplierDGV.RowHeadersVisible = false;
            this.SupplierDGV.RowHeadersWidth = 51;
            this.SupplierDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplierDGV.Size = new System.Drawing.Size(1048, 658);
            this.SupplierDGV.TabIndex = 7;
            this.SupplierDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDGV_CellClick);
            this.SupplierDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDGV_CellContentClick);
            this.SupplierDGV.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.SupplierDGV_ColumnWidthChanged);
            // 
            // AnagrPanel
            // 
            this.AnagrPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnagrPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AnagrPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnagrPanel.Controls.Add(this.phoneBtn);
            this.AnagrPanel.Controls.Add(this.mailBtn);
            this.AnagrPanel.Controls.Add(this.whatsappChat);
            this.AnagrPanel.Controls.Add(this.ivaLbl);
            this.AnagrPanel.Controls.Add(this.ivaTB);
            this.AnagrPanel.Controls.Add(this.cancelBtn);
            this.AnagrPanel.Controls.Add(this.confirmBtn);
            this.AnagrPanel.Controls.Add(this.coDestBox);
            this.AnagrPanel.Controls.Add(this.BottomPanel);
            this.AnagrPanel.Controls.Add(this.cod_destin);
            this.AnagrPanel.Controls.Add(this.CapLbl);
            this.AnagrPanel.Controls.Add(this.CapBox);
            this.AnagrPanel.Controls.Add(this.AddressLbl);
            this.AnagrPanel.Controls.Add(this.AddressBox);
            this.AnagrPanel.Controls.Add(this.pec);
            this.AnagrPanel.Controls.Add(this.pecBox);
            this.AnagrPanel.Controls.Add(this.notes);
            this.AnagrPanel.Controls.Add(this.notesBox);
            this.AnagrPanel.Controls.Add(this.panel3);
            this.AnagrPanel.Controls.Add(this.panel1);
            this.AnagrPanel.Controls.Add(this.mail);
            this.AnagrPanel.Controls.Add(this.mobile);
            this.AnagrPanel.Controls.Add(this.telephone);
            this.AnagrPanel.Controls.Add(this.mailBox);
            this.AnagrPanel.Controls.Add(this.mobileBox);
            this.AnagrPanel.Controls.Add(this.telBox);
            this.AnagrPanel.Controls.Add(this.municBox);
            this.AnagrPanel.Controls.Add(this.municipLbl);
            this.AnagrPanel.Controls.Add(this.provBox);
            this.AnagrPanel.Controls.Add(this.regionBox);
            this.AnagrPanel.Controls.Add(this.provLbl);
            this.AnagrPanel.Controls.Add(this.idTaxBox);
            this.AnagrPanel.Controls.Add(this.companyTB);
            this.AnagrPanel.Controls.Add(this.label4);
            this.AnagrPanel.Controls.Add(this.label2);
            this.AnagrPanel.Controls.Add(this.label1);
            this.AnagrPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AnagrPanel.Enabled = false;
            this.AnagrPanel.Location = new System.Drawing.Point(1049, 28);
            this.AnagrPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AnagrPanel.Name = "AnagrPanel";
            this.AnagrPanel.Size = new System.Drawing.Size(534, 658);
            this.AnagrPanel.TabIndex = 11;
            // 
            // phoneBtn
            // 
            this.phoneBtn.FlatAppearance.BorderSize = 0;
            this.phoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.phoneBtn.Image = ((System.Drawing.Image)(resources.GetObject("phoneBtn.Image")));
            this.phoneBtn.Location = new System.Drawing.Point(216, 262);
            this.phoneBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.mailBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.whatsappChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // ivaTB
            // 
            this.ivaTB.Location = new System.Drawing.Point(7, 89);
            this.ivaTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ivaTB.Name = "ivaTB";
            this.ivaTB.Size = new System.Drawing.Size(205, 22);
            this.ivaTB.TabIndex = 37;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cancelBtn.Location = new System.Drawing.Point(100, 564);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(73, 26);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmBtn.FlatAppearance.BorderSize = 0;
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.confirmBtn.Location = new System.Drawing.Point(5, 564);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(87, 26);
            this.confirmBtn.TabIndex = 14;
            this.confirmBtn.Text = "Conferma";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Visible = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // coDestBox
            // 
            this.coDestBox.Location = new System.Drawing.Point(219, 89);
            this.coDestBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.coDestBox.MaxLength = 7;
            this.coDestBox.Name = "coDestBox";
            this.coDestBox.Size = new System.Drawing.Size(259, 22);
            this.coDestBox.TabIndex = 35;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BottomPanel.Controls.Add(this.AttachmentsBtn);
            this.BottomPanel.Controls.Add(this.DocsButton);
            this.BottomPanel.Location = new System.Drawing.Point(3, 590);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(252, 63);
            this.BottomPanel.TabIndex = 1;
            this.BottomPanel.Visible = false;
            // 
            // AttachmentsBtn
            // 
            this.AttachmentsBtn.FlatAppearance.BorderSize = 0;
            this.AttachmentsBtn.Image = ((System.Drawing.Image)(resources.GetObject("AttachmentsBtn.Image")));
            this.AttachmentsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AttachmentsBtn.Location = new System.Drawing.Point(124, 7);
            this.AttachmentsBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AttachmentsBtn.Name = "AttachmentsBtn";
            this.AttachmentsBtn.Size = new System.Drawing.Size(108, 46);
            this.AttachmentsBtn.TabIndex = 33;
            this.AttachmentsBtn.Text = "Allegati";
            this.AttachmentsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AttachmentsBtn.UseVisualStyleBackColor = true;
            this.AttachmentsBtn.Visible = false;
            this.AttachmentsBtn.Click += new System.EventHandler(this.AttachmentsBtn_Click);
            // 
            // DocsButton
            // 
            this.DocsButton.Image = ((System.Drawing.Image)(resources.GetObject("DocsButton.Image")));
            this.DocsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DocsButton.Location = new System.Drawing.Point(7, 7);
            this.DocsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DocsButton.Name = "DocsButton";
            this.DocsButton.Size = new System.Drawing.Size(109, 46);
            this.DocsButton.TabIndex = 32;
            this.DocsButton.Text = "Documenti";
            this.DocsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DocsButton.UseVisualStyleBackColor = true;
            this.DocsButton.Visible = false;
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
            // CapLbl
            // 
            this.CapLbl.AutoSize = true;
            this.CapLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CapLbl.Location = new System.Drawing.Point(168, 175);
            this.CapLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CapLbl.Name = "CapLbl";
            this.CapLbl.Size = new System.Drawing.Size(32, 16);
            this.CapLbl.TabIndex = 33;
            this.CapLbl.Text = "Cap";
            // 
            // CapBox
            // 
            this.CapBox.Enabled = false;
            this.CapBox.Location = new System.Drawing.Point(171, 194);
            this.CapBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CapBox.MaxLength = 5;
            this.CapBox.Name = "CapBox";
            this.CapBox.Size = new System.Drawing.Size(41, 22);
            this.CapBox.TabIndex = 32;
            this.CapBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CapBox_KeyPress);
            // 
            // AddressLbl
            // 
            this.AddressLbl.AutoSize = true;
            this.AddressLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.AddressLbl.Location = new System.Drawing.Point(213, 175);
            this.AddressLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressLbl.Name = "AddressLbl";
            this.AddressLbl.Size = new System.Drawing.Size(55, 16);
            this.AddressLbl.TabIndex = 31;
            this.AddressLbl.Text = "Indirizzo";
            // 
            // AddressBox
            // 
            this.AddressBox.Enabled = false;
            this.AddressBox.Location = new System.Drawing.Point(216, 194);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddressBox.MaxLength = 30;
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(261, 22);
            this.AddressBox.TabIndex = 30;
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
            // pecBox
            // 
            this.pecBox.Location = new System.Drawing.Point(265, 318);
            this.pecBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pecBox.MaxLength = 100;
            this.pecBox.Name = "pecBox";
            this.pecBox.Size = new System.Drawing.Size(171, 22);
            this.pecBox.TabIndex = 28;
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
            // notesBox
            // 
            this.notesBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notesBox.Location = new System.Drawing.Point(5, 384);
            this.notesBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(524, 171);
            this.notesBox.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(5, 352);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 2);
            this.panel3.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(5, 228);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(12, 318);
            this.mailBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mailBox.MaxLength = 100;
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(201, 22);
            this.mailBox.TabIndex = 20;
            // 
            // mobileBox
            // 
            this.mobileBox.Location = new System.Drawing.Point(267, 263);
            this.mobileBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mobileBox.MaxLength = 20;
            this.mobileBox.Name = "mobileBox";
            this.mobileBox.Size = new System.Drawing.Size(169, 22);
            this.mobileBox.TabIndex = 19;
            this.mobileBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mobileBox_KeyPress);
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(11, 263);
            this.telBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.telBox.MaxLength = 20;
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(203, 22);
            this.telBox.TabIndex = 18;
            this.telBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telBox_KeyPress);
            // 
            // municBox
            // 
            this.municBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.municBox.Enabled = false;
            this.municBox.FormattingEnabled = true;
            this.municBox.Location = new System.Drawing.Point(7, 194);
            this.municBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.municBox.Name = "municBox";
            this.municBox.Size = new System.Drawing.Size(159, 24);
            this.municBox.TabIndex = 13;
            this.municBox.DropDownClosed += new System.EventHandler(this.municBox_DropDownClosed);
            // 
            // municipLbl
            // 
            this.municipLbl.AutoSize = true;
            this.municipLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.municipLbl.Location = new System.Drawing.Point(7, 175);
            this.municipLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.municipLbl.Name = "municipLbl";
            this.municipLbl.Size = new System.Drawing.Size(57, 16);
            this.municipLbl.TabIndex = 12;
            this.municipLbl.Text = "Comune";
            // 
            // provBox
            // 
            this.provBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provBox.Enabled = false;
            this.provBox.FormattingEnabled = true;
            this.provBox.Location = new System.Drawing.Point(171, 146);
            this.provBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.provBox.Name = "provBox";
            this.provBox.Size = new System.Drawing.Size(160, 24);
            this.provBox.TabIndex = 11;
            this.provBox.SelectedIndexChanged += new System.EventHandler(this.provBox_SelectedIndexChanged);
            this.provBox.DropDownClosed += new System.EventHandler(this.provBox_DropDownClosed);
            // 
            // regionBox
            // 
            this.regionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionBox.FormattingEnabled = true;
            this.regionBox.Location = new System.Drawing.Point(7, 146);
            this.regionBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.regionBox.Name = "regionBox";
            this.regionBox.Size = new System.Drawing.Size(159, 24);
            this.regionBox.TabIndex = 10;
            this.regionBox.SelectedIndexChanged += new System.EventHandler(this.regionBox_SelectedIndexChanged);
            this.regionBox.DropDownClosed += new System.EventHandler(this.regionBox_DropDownClosed);
            // 
            // provLbl
            // 
            this.provLbl.AutoSize = true;
            this.provLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.provLbl.Location = new System.Drawing.Point(168, 127);
            this.provLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.provLbl.Name = "provLbl";
            this.provLbl.Size = new System.Drawing.Size(63, 16);
            this.provLbl.TabIndex = 9;
            this.provLbl.Text = "Provincia";
            // 
            // idTaxBox
            // 
            this.idTaxBox.Location = new System.Drawing.Point(219, 34);
            this.idTaxBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.idTaxBox.MaxLength = 18;
            this.idTaxBox.Name = "idTaxBox";
            this.idTaxBox.Size = new System.Drawing.Size(260, 22);
            this.idTaxBox.TabIndex = 7;
            // 
            // companyTB
            // 
            this.companyTB.Location = new System.Drawing.Point(7, 34);
            this.companyTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.companyTB.MaxLength = 49;
            this.companyTB.Name = "companyTB";
            this.companyTB.Size = new System.Drawing.Size(205, 22);
            this.companyTB.TabIndex = 6;
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
            // selectAllRows
            // 
            this.selectAllRows.AutoSize = true;
            this.selectAllRows.Location = new System.Drawing.Point(87, 39);
            this.selectAllRows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectAllRows.Name = "selectAllRows";
            this.selectAllRows.Size = new System.Drawing.Size(18, 17);
            this.selectAllRows.TabIndex = 12;
            this.selectAllRows.UseVisualStyleBackColor = true;
            this.selectAllRows.CheckedChanged += new System.EventHandler(this.selectAllRows_CheckedChanged);
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.searchPanel.Controls.Add(this.searchbtn2);
            this.searchPanel.Controls.Add(this.resetCB);
            this.searchPanel.Controls.Add(this.label3);
            this.searchPanel.Controls.Add(this.label5);
            this.searchPanel.Controls.Add(this.label6);
            this.searchPanel.Controls.Add(this.panel2);
            this.searchPanel.Controls.Add(this.separatorPanel);
            this.searchPanel.Controls.Add(this.cityCB);
            this.searchPanel.Controls.Add(this.provCB);
            this.searchPanel.Controls.Add(this.regionCB);
            this.searchPanel.Controls.Add(this.cityLbl);
            this.searchPanel.Controls.Add(this.provinceLbl);
            this.searchPanel.Controls.Add(this.RegionLbl);
            this.searchPanel.Location = new System.Drawing.Point(909, 28);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(279, 268);
            this.searchPanel.TabIndex = 13;
            this.searchPanel.Visible = false;
            // 
            // searchbtn2
            // 
            this.searchbtn2.Location = new System.Drawing.Point(19, 209);
            this.searchbtn2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchbtn2.Name = "searchbtn2";
            this.searchbtn2.Size = new System.Drawing.Size(75, 23);
            this.searchbtn2.TabIndex = 14;
            this.searchbtn2.Text = "Cerca";
            this.searchbtn2.UseVisualStyleBackColor = true;
            this.searchbtn2.Click += new System.EventHandler(this.searchbtn2_Click);
            // 
            // resetCB
            // 
            this.resetCB.Location = new System.Drawing.Point(193, 209);
            this.resetCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetCB.Name = "resetCB";
            this.resetCB.Size = new System.Drawing.Size(75, 23);
            this.resetCB.TabIndex = 13;
            this.resetCB.Text = "Cancella";
            this.resetCB.UseVisualStyleBackColor = true;
            this.resetCB.Click += new System.EventHandler(this.resetCB_Click);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.pbSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(35, 25);
            this.pbSearch.TabIndex = 8;
            this.pbSearch.TabStop = false;
            // 
            // separatorPanel
            // 
            this.separatorPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.separatorPanel.Location = new System.Drawing.Point(8, 37);
            this.separatorPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.separatorPanel.Name = "separatorPanel";
            this.separatorPanel.Size = new System.Drawing.Size(267, 1);
            this.separatorPanel.TabIndex = 7;
            // 
            // cityCB
            // 
            this.cityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityCB.Enabled = false;
            this.cityCB.FormattingEnabled = true;
            this.cityCB.Location = new System.Drawing.Point(108, 150);
            this.cityCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cityCB.Name = "cityCB";
            this.cityCB.Size = new System.Drawing.Size(160, 24);
            this.cityCB.TabIndex = 5;
            this.cityCB.DropDownClosed += new System.EventHandler(this.cityCB_DropDownClosed);
            // 
            // provCB
            // 
            this.provCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provCB.Enabled = false;
            this.provCB.FormattingEnabled = true;
            this.provCB.Location = new System.Drawing.Point(108, 100);
            this.provCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.provCB.Name = "provCB";
            this.provCB.Size = new System.Drawing.Size(160, 24);
            this.provCB.TabIndex = 4;
            this.provCB.SelectedIndexChanged += new System.EventHandler(this.provCB_SelectedIndexChanged);
            this.provCB.DropDownClosed += new System.EventHandler(this.provCB_DropDownClosed);
            // 
            // regionCB
            // 
            this.regionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionCB.FormattingEnabled = true;
            this.regionCB.Location = new System.Drawing.Point(108, 50);
            this.regionCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.regionCB.Name = "regionCB";
            this.regionCB.Size = new System.Drawing.Size(160, 24);
            this.regionCB.TabIndex = 3;
            this.regionCB.SelectedIndexChanged += new System.EventHandler(this.regionCB_SelectedIndexChanged);
            this.regionCB.DropDownClosed += new System.EventHandler(this.regionCB_DropDownClosed);
            // 
            // cityLbl
            // 
            this.cityLbl.AutoSize = true;
            this.cityLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.cityLbl.Location = new System.Drawing.Point(29, 154);
            this.cityLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cityLbl.Name = "cityLbl";
            this.cityLbl.Size = new System.Drawing.Size(57, 16);
            this.cityLbl.TabIndex = 2;
            this.cityLbl.Text = "Comune";
            // 
            // provinceLbl
            // 
            this.provinceLbl.AutoSize = true;
            this.provinceLbl.Enabled = false;
            this.provinceLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.provinceLbl.Location = new System.Drawing.Point(29, 103);
            this.provinceLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.provinceLbl.Name = "provinceLbl";
            this.provinceLbl.Size = new System.Drawing.Size(63, 16);
            this.provinceLbl.TabIndex = 1;
            this.provinceLbl.Text = "Provincia";
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
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 738);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.selectAllRows);
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
            this.BottomPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
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
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Label MenuName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView SupplierDGV;
        public System.Windows.Forms.Panel AnagrPanel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.TextBox coDestBox;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button AttachmentsBtn;
        private System.Windows.Forms.Button DocsButton;
        private System.Windows.Forms.Label cod_destin;
        private System.Windows.Forms.Label CapLbl;
        private System.Windows.Forms.TextBox CapBox;
        private System.Windows.Forms.Label AddressLbl;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label pec;
        private System.Windows.Forms.TextBox pecBox;
        private System.Windows.Forms.Label notes;
        private System.Windows.Forms.TextBox notesBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label mobile;
        private System.Windows.Forms.Label telephone;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.TextBox mobileBox;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.ComboBox municBox;
        private System.Windows.Forms.Label municipLbl;
        private System.Windows.Forms.ComboBox provBox;
        private System.Windows.Forms.ComboBox regionBox;
        private System.Windows.Forms.Label provLbl;
        private System.Windows.Forms.TextBox idTaxBox;
        private System.Windows.Forms.TextBox companyTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ivaLbl;
        private System.Windows.Forms.TextBox ivaTB;
        private System.Windows.Forms.PictureBox whatsappChat;
        private System.Windows.Forms.Button mailBtn;
        private System.Windows.Forms.Button phoneBtn;
        private System.Windows.Forms.CheckBox selectAllRows;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button searchbtn2;
        private System.Windows.Forms.Button resetCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label searchFor;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Panel separatorPanel;
        private System.Windows.Forms.ComboBox cityCB;
        private System.Windows.Forms.ComboBox provCB;
        private System.Windows.Forms.ComboBox regionCB;
        private System.Windows.Forms.Label cityLbl;
        private System.Windows.Forms.Label provinceLbl;
        private System.Windows.Forms.Label RegionLbl;
    }
}