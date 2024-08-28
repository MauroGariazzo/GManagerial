namespace GManagerial.WareHouse.ChildForms
{
    partial class AddSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplier));
            this.SupplierCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectProductLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ExistingSupplierRB = new System.Windows.Forms.RadioButton();
            this.CreateNewSupplierRB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SupplierNamePanelTB = new System.Windows.Forms.TextBox();
            this.ExistingSupplierPanel = new System.Windows.Forms.Panel();
            this.CreateNewSupplierPanel = new System.Windows.Forms.Panel();
            this.pec = new System.Windows.Forms.Label();
            this.PecPanelTB = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.Label();
            this.mobile = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.Label();
            this.MailPanelTB = new System.Windows.Forms.TextBox();
            this.MobilePanelTB = new GManagerial.GraphicElements.IntTextBox();
            this.TelephonePanelTB = new GManagerial.GraphicElements.IntTextBox();
            this.AddressPanelLBL = new System.Windows.Forms.Label();
            this.ZipCodePanelLBL = new System.Windows.Forms.Label();
            this.AddressPanelTB = new System.Windows.Forms.TextBox();
            this.ZipCodePanelTB = new System.Windows.Forms.TextBox();
            this.CityPanelLBL = new System.Windows.Forms.Label();
            this.ProvincePanelLBL = new System.Windows.Forms.Label();
            this.RegionLbl = new System.Windows.Forms.Label();
            this.CityPanelCB = new System.Windows.Forms.ComboBox();
            this.ProvincePanelCB = new System.Windows.Forms.ComboBox();
            this.RegionPanelCB = new System.Windows.Forms.ComboBox();
            this.RecipientCodeLbl = new System.Windows.Forms.Label();
            this.VatPanelTB = new System.Windows.Forms.TextBox();
            this.IdTaxPanelTB = new System.Windows.Forms.TextBox();
            this.RecipientCodePanelTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VatLbl = new System.Windows.Forms.Label();
            this.NameSupplierLbl = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ExistingSupplierPanel.SuspendLayout();
            this.CreateNewSupplierPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SupplierCB
            // 
            this.SupplierCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SupplierCB.FormattingEnabled = true;
            this.SupplierCB.Location = new System.Drawing.Point(13, 12);
            this.SupplierCB.Name = "SupplierCB";
            this.SupplierCB.Size = new System.Drawing.Size(282, 24);
            this.SupplierCB.TabIndex = 0;
            this.SupplierCB.SelectedIndexChanged += new System.EventHandler(this.SupplierCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 100);
            this.panel2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(11, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(407, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seleziona un fornitore dall\'elenco o creane uno nuovo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleziona fornitore";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(491, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 66);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(465, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 67);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 0;
            // 
            // selectProductLbl
            // 
            this.selectProductLbl.Location = new System.Drawing.Point(0, 0);
            this.selectProductLbl.Name = "selectProductLbl";
            this.selectProductLbl.Size = new System.Drawing.Size(100, 23);
            this.selectProductLbl.TabIndex = 0;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(407, 548);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 24;
            this.okBtn.Text = "Ok";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(488, 548);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ExistingSupplierRB
            // 
            this.ExistingSupplierRB.AutoSize = true;
            this.ExistingSupplierRB.Location = new System.Drawing.Point(8, 111);
            this.ExistingSupplierRB.Name = "ExistingSupplierRB";
            this.ExistingSupplierRB.Size = new System.Drawing.Size(160, 20);
            this.ExistingSupplierRB.TabIndex = 26;
            this.ExistingSupplierRB.TabStop = true;
            this.ExistingSupplierRB.Text = "Fornitore già esistente";
            this.ExistingSupplierRB.UseVisualStyleBackColor = true;
            this.ExistingSupplierRB.CheckedChanged += new System.EventHandler(this.ExistingSupplier_CheckedChanged);
            // 
            // CreateNewSupplierRB
            // 
            this.CreateNewSupplierRB.AutoSize = true;
            this.CreateNewSupplierRB.Location = new System.Drawing.Point(8, 216);
            this.CreateNewSupplierRB.Name = "CreateNewSupplierRB";
            this.CreateNewSupplierRB.Size = new System.Drawing.Size(148, 20);
            this.CreateNewSupplierRB.TabIndex = 27;
            this.CreateNewSupplierRB.TabStop = true;
            this.CreateNewSupplierRB.Text = "Crea nuovo fornitore";
            this.CreateNewSupplierRB.UseVisualStyleBackColor = true;
            this.CreateNewSupplierRB.CheckedChanged += new System.EventHandler(this.CreateNewSupplier_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(1, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 2);
            this.panel1.TabIndex = 28;
            // 
            // SupplierNamePanelTB
            // 
            this.SupplierNamePanelTB.Location = new System.Drawing.Point(14, 30);
            this.SupplierNamePanelTB.Name = "SupplierNamePanelTB";
            this.SupplierNamePanelTB.Size = new System.Drawing.Size(261, 22);
            this.SupplierNamePanelTB.TabIndex = 29;
            // 
            // ExistingSupplierPanel
            // 
            this.ExistingSupplierPanel.Controls.Add(this.SupplierCB);
            this.ExistingSupplierPanel.Controls.Add(this.label1);
            this.ExistingSupplierPanel.Location = new System.Drawing.Point(1, 137);
            this.ExistingSupplierPanel.Name = "ExistingSupplierPanel";
            this.ExistingSupplierPanel.Size = new System.Drawing.Size(562, 44);
            this.ExistingSupplierPanel.TabIndex = 30;
            // 
            // CreateNewSupplierPanel
            // 
            this.CreateNewSupplierPanel.Controls.Add(this.pec);
            this.CreateNewSupplierPanel.Controls.Add(this.PecPanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.mail);
            this.CreateNewSupplierPanel.Controls.Add(this.mobile);
            this.CreateNewSupplierPanel.Controls.Add(this.telephone);
            this.CreateNewSupplierPanel.Controls.Add(this.MailPanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.MobilePanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.TelephonePanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.AddressPanelLBL);
            this.CreateNewSupplierPanel.Controls.Add(this.ZipCodePanelLBL);
            this.CreateNewSupplierPanel.Controls.Add(this.AddressPanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.ZipCodePanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.CityPanelLBL);
            this.CreateNewSupplierPanel.Controls.Add(this.ProvincePanelLBL);
            this.CreateNewSupplierPanel.Controls.Add(this.RegionLbl);
            this.CreateNewSupplierPanel.Controls.Add(this.CityPanelCB);
            this.CreateNewSupplierPanel.Controls.Add(this.ProvincePanelCB);
            this.CreateNewSupplierPanel.Controls.Add(this.RegionPanelCB);
            this.CreateNewSupplierPanel.Controls.Add(this.RecipientCodeLbl);
            this.CreateNewSupplierPanel.Controls.Add(this.VatPanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.IdTaxPanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.RecipientCodePanelTB);
            this.CreateNewSupplierPanel.Controls.Add(this.label4);
            this.CreateNewSupplierPanel.Controls.Add(this.VatLbl);
            this.CreateNewSupplierPanel.Controls.Add(this.NameSupplierLbl);
            this.CreateNewSupplierPanel.Controls.Add(this.SupplierNamePanelTB);
            this.CreateNewSupplierPanel.Location = new System.Drawing.Point(1, 242);
            this.CreateNewSupplierPanel.Name = "CreateNewSupplierPanel";
            this.CreateNewSupplierPanel.Size = new System.Drawing.Size(562, 300);
            this.CreateNewSupplierPanel.TabIndex = 31;
            // 
            // pec
            // 
            this.pec.AutoSize = true;
            this.pec.Location = new System.Drawing.Point(276, 238);
            this.pec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pec.Name = "pec";
            this.pec.Size = new System.Drawing.Size(31, 16);
            this.pec.TabIndex = 54;
            this.pec.Text = "Pec";
            // 
            // PecPanelTB
            // 
            this.PecPanelTB.Location = new System.Drawing.Point(280, 258);
            this.PecPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.PecPanelTB.MaxLength = 100;
            this.PecPanelTB.Name = "PecPanelTB";
            this.PecPanelTB.Size = new System.Drawing.Size(261, 22);
            this.PecPanelTB.TabIndex = 53;
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.Location = new System.Drawing.Point(12, 238);
            this.mail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(41, 16);
            this.mail.TabIndex = 52;
            this.mail.Text = "Email";
            // 
            // mobile
            // 
            this.mobile.AutoSize = true;
            this.mobile.Location = new System.Drawing.Point(276, 191);
            this.mobile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mobile.Name = "mobile";
            this.mobile.Size = new System.Drawing.Size(60, 16);
            this.mobile.TabIndex = 51;
            this.mobile.Text = "Cellulare";
            // 
            // telephone
            // 
            this.telephone.AutoSize = true;
            this.telephone.Location = new System.Drawing.Point(11, 191);
            this.telephone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.telephone.Name = "telephone";
            this.telephone.Size = new System.Drawing.Size(61, 16);
            this.telephone.TabIndex = 50;
            this.telephone.Text = "Telefono";
            // 
            // MailPanelTB
            // 
            this.MailPanelTB.Location = new System.Drawing.Point(13, 258);
            this.MailPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.MailPanelTB.MaxLength = 100;
            this.MailPanelTB.Name = "MailPanelTB";
            this.MailPanelTB.Size = new System.Drawing.Size(259, 22);
            this.MailPanelTB.TabIndex = 49;
            // 
            // MobilePanelTB
            // 
            this.MobilePanelTB.Location = new System.Drawing.Point(279, 211);
            this.MobilePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.MobilePanelTB.MaxLength = 20;
            this.MobilePanelTB.Name = "MobilePanelTB";
            this.MobilePanelTB.Size = new System.Drawing.Size(262, 22);
            this.MobilePanelTB.TabIndex = 48;
            // 
            // TelephonePanelTB
            // 
            this.TelephonePanelTB.Location = new System.Drawing.Point(14, 211);
            this.TelephonePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.TelephonePanelTB.MaxLength = 20;
            this.TelephonePanelTB.Name = "TelephonePanelTB";
            this.TelephonePanelTB.Size = new System.Drawing.Size(260, 22);
            this.TelephonePanelTB.TabIndex = 47;
            // 
            // AddressPanelLBL
            // 
            this.AddressPanelLBL.AutoSize = true;
            this.AddressPanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.AddressPanelLBL.Location = new System.Drawing.Point(276, 145);
            this.AddressPanelLBL.Name = "AddressPanelLBL";
            this.AddressPanelLBL.Size = new System.Drawing.Size(55, 16);
            this.AddressPanelLBL.TabIndex = 46;
            this.AddressPanelLBL.Text = "Indirizzo";
            // 
            // ZipCodePanelLBL
            // 
            this.ZipCodePanelLBL.AutoSize = true;
            this.ZipCodePanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ZipCodePanelLBL.Location = new System.Drawing.Point(212, 145);
            this.ZipCodePanelLBL.Name = "ZipCodePanelLBL";
            this.ZipCodePanelLBL.Size = new System.Drawing.Size(34, 16);
            this.ZipCodePanelLBL.TabIndex = 45;
            this.ZipCodePanelLBL.Text = "CAP";
            // 
            // AddressPanelTB
            // 
            this.AddressPanelTB.Enabled = false;
            this.AddressPanelTB.Location = new System.Drawing.Point(279, 166);
            this.AddressPanelTB.Name = "AddressPanelTB";
            this.AddressPanelTB.Size = new System.Drawing.Size(263, 22);
            this.AddressPanelTB.TabIndex = 44;
            // 
            // ZipCodePanelTB
            // 
            this.ZipCodePanelTB.Enabled = false;
            this.ZipCodePanelTB.Location = new System.Drawing.Point(215, 166);
            this.ZipCodePanelTB.Name = "ZipCodePanelTB";
            this.ZipCodePanelTB.Size = new System.Drawing.Size(57, 22);
            this.ZipCodePanelTB.TabIndex = 43;
            // 
            // CityPanelLBL
            // 
            this.CityPanelLBL.AutoSize = true;
            this.CityPanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CityPanelLBL.Location = new System.Drawing.Point(11, 145);
            this.CityPanelLBL.Name = "CityPanelLBL";
            this.CityPanelLBL.Size = new System.Drawing.Size(57, 16);
            this.CityPanelLBL.TabIndex = 42;
            this.CityPanelLBL.Text = "Comune";
            // 
            // ProvincePanelLBL
            // 
            this.ProvincePanelLBL.AutoSize = true;
            this.ProvincePanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ProvincePanelLBL.Location = new System.Drawing.Point(276, 99);
            this.ProvincePanelLBL.Name = "ProvincePanelLBL";
            this.ProvincePanelLBL.Size = new System.Drawing.Size(63, 16);
            this.ProvincePanelLBL.TabIndex = 41;
            this.ProvincePanelLBL.Text = "Provincia";
            // 
            // RegionLbl
            // 
            this.RegionLbl.AutoSize = true;
            this.RegionLbl.Location = new System.Drawing.Point(11, 99);
            this.RegionLbl.Name = "RegionLbl";
            this.RegionLbl.Size = new System.Drawing.Size(59, 16);
            this.RegionLbl.TabIndex = 40;
            this.RegionLbl.Text = "Regione";
            // 
            // CityPanelCB
            // 
            this.CityPanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CityPanelCB.Enabled = false;
            this.CityPanelCB.FormattingEnabled = true;
            this.CityPanelCB.Location = new System.Drawing.Point(14, 164);
            this.CityPanelCB.Name = "CityPanelCB";
            this.CityPanelCB.Size = new System.Drawing.Size(195, 24);
            this.CityPanelCB.TabIndex = 39;
            this.CityPanelCB.SelectedIndexChanged += new System.EventHandler(this.CityPanelCB_SelectedIndexChanged);
            // 
            // ProvincePanelCB
            // 
            this.ProvincePanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvincePanelCB.Enabled = false;
            this.ProvincePanelCB.FormattingEnabled = true;
            this.ProvincePanelCB.Location = new System.Drawing.Point(281, 118);
            this.ProvincePanelCB.Name = "ProvincePanelCB";
            this.ProvincePanelCB.Size = new System.Drawing.Size(261, 24);
            this.ProvincePanelCB.TabIndex = 38;
            this.ProvincePanelCB.SelectedIndexChanged += new System.EventHandler(this.ProvincePanelCB_SelectedIndexChanged);
            // 
            // RegionPanelCB
            // 
            this.RegionPanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionPanelCB.FormattingEnabled = true;
            this.RegionPanelCB.Location = new System.Drawing.Point(14, 118);
            this.RegionPanelCB.Name = "RegionPanelCB";
            this.RegionPanelCB.Size = new System.Drawing.Size(261, 24);
            this.RegionPanelCB.TabIndex = 37;
            this.RegionPanelCB.SelectedIndexChanged += new System.EventHandler(this.RegionPanelCB_SelectedIndexChanged);
            // 
            // RecipientCodeLbl
            // 
            this.RecipientCodeLbl.AutoSize = true;
            this.RecipientCodeLbl.Location = new System.Drawing.Point(276, 55);
            this.RecipientCodeLbl.Name = "RecipientCodeLbl";
            this.RecipientCodeLbl.Size = new System.Drawing.Size(110, 16);
            this.RecipientCodeLbl.TabIndex = 36;
            this.RecipientCodeLbl.Text = "Cod. Destinatario";
            // 
            // VatPanelTB
            // 
            this.VatPanelTB.Location = new System.Drawing.Point(14, 74);
            this.VatPanelTB.Name = "VatPanelTB";
            this.VatPanelTB.Size = new System.Drawing.Size(261, 22);
            this.VatPanelTB.TabIndex = 35;
            // 
            // IdTaxPanelTB
            // 
            this.IdTaxPanelTB.Location = new System.Drawing.Point(281, 30);
            this.IdTaxPanelTB.Name = "IdTaxPanelTB";
            this.IdTaxPanelTB.Size = new System.Drawing.Size(261, 22);
            this.IdTaxPanelTB.TabIndex = 34;
            // 
            // RecipientCodePanelTB
            // 
            this.RecipientCodePanelTB.Location = new System.Drawing.Point(281, 74);
            this.RecipientCodePanelTB.Name = "RecipientCodePanelTB";
            this.RecipientCodePanelTB.Size = new System.Drawing.Size(261, 22);
            this.RecipientCodePanelTB.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Cod.Fiscale";
            // 
            // VatLbl
            // 
            this.VatLbl.AutoSize = true;
            this.VatLbl.Location = new System.Drawing.Point(11, 55);
            this.VatLbl.Name = "VatLbl";
            this.VatLbl.Size = new System.Drawing.Size(52, 16);
            this.VatLbl.TabIndex = 31;
            this.VatLbl.Text = "P. I.V.A.";
            // 
            // NameSupplierLbl
            // 
            this.NameSupplierLbl.AutoSize = true;
            this.NameSupplierLbl.Location = new System.Drawing.Point(11, 11);
            this.NameSupplierLbl.Name = "NameSupplierLbl";
            this.NameSupplierLbl.Size = new System.Drawing.Size(101, 16);
            this.NameSupplierLbl.TabIndex = 30;
            this.NameSupplierLbl.Text = "Denominazione";
            // 
            // AddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 576);
            this.Controls.Add(this.CreateNewSupplierPanel);
            this.Controls.Add(this.ExistingSupplierPanel);
            this.Controls.Add(this.ExistingSupplierRB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CreateNewSupplierRB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddSupplier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSupplier_FormClosing);
            this.Load += new System.EventHandler(this.AddSupplier_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ExistingSupplierPanel.ResumeLayout(false);
            this.ExistingSupplierPanel.PerformLayout();
            this.CreateNewSupplierPanel.ResumeLayout(false);
            this.CreateNewSupplierPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SupplierCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label selectProductLbl;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.RadioButton ExistingSupplierRB;
        private System.Windows.Forms.RadioButton CreateNewSupplierRB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox SupplierNamePanelTB;
        private System.Windows.Forms.Panel ExistingSupplierPanel;
        private System.Windows.Forms.Panel CreateNewSupplierPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label VatLbl;
        private System.Windows.Forms.Label NameSupplierLbl;
        private System.Windows.Forms.TextBox RecipientCodePanelTB;
        private System.Windows.Forms.TextBox VatPanelTB;
        private System.Windows.Forms.TextBox IdTaxPanelTB;
        private System.Windows.Forms.Label RecipientCodeLbl;
        private System.Windows.Forms.ComboBox ProvincePanelCB;
        private System.Windows.Forms.ComboBox RegionPanelCB;
        private System.Windows.Forms.Label CityPanelLBL;
        private System.Windows.Forms.Label ProvincePanelLBL;
        private System.Windows.Forms.Label RegionLbl;
        private System.Windows.Forms.ComboBox CityPanelCB;
        private System.Windows.Forms.TextBox ZipCodePanelTB;
        private System.Windows.Forms.Label AddressPanelLBL;
        private System.Windows.Forms.Label ZipCodePanelLBL;
        private System.Windows.Forms.TextBox AddressPanelTB;
        private System.Windows.Forms.Label pec;
        private System.Windows.Forms.TextBox PecPanelTB;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label mobile;
        private System.Windows.Forms.Label telephone;
        private System.Windows.Forms.TextBox MailPanelTB;
        private GraphicElements.IntTextBox MobilePanelTB;
        private GraphicElements.IntTextBox TelephonePanelTB;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}