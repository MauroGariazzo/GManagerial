namespace GManagerial
{
    partial class AddNewCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewCustomer));
            this.existedCustomerRD = new System.Windows.Forms.RadioButton();
            this.newCustomerRD = new System.Windows.Forms.RadioButton();
            this.customerCB = new System.Windows.Forms.ComboBox();
            this.AnagrPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.personalsInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contacts = new System.Windows.Forms.Label();
            this.birthDatePanelTB = new System.Windows.Forms.TextBox();
            this.birthDateLbl = new System.Windows.Forms.Label();
            this.ZipCodePanelLBL = new System.Windows.Forms.Label();
            this.ZipCodePanelTB = new System.Windows.Forms.TextBox();
            this.AddressPanelLBL = new System.Windows.Forms.Label();
            this.AddressPanelTB = new System.Windows.Forms.TextBox();
            this.pec = new System.Windows.Forms.Label();
            this.PecPanelTB = new System.Windows.Forms.TextBox();
            this.notes = new System.Windows.Forms.Label();
            this.notesPanelTB = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.Label();
            this.mobile = new System.Windows.Forms.Label();
            this.telephone = new System.Windows.Forms.Label();
            this.MailPanelTB = new System.Windows.Forms.TextBox();
            this.MobilePanelTB = new System.Windows.Forms.TextBox();
            this.TelephonePanelTB = new System.Windows.Forms.TextBox();
            this.CityPanelCB = new System.Windows.Forms.ComboBox();
            this.CityPanelLBL = new System.Windows.Forms.Label();
            this.ProvincePanelCB = new System.Windows.Forms.ComboBox();
            this.RegionPanelCB = new System.Windows.Forms.ComboBox();
            this.ProvincePanelLBL = new System.Windows.Forms.Label();
            this.IdTaxPanelTB = new System.Windows.Forms.TextBox();
            this.CustomerNamePanelTB = new System.Windows.Forms.TextBox();
            this.RegionPanelLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.AnagrPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // existedCustomerRD
            // 
            this.existedCustomerRD.AutoSize = true;
            this.existedCustomerRD.Checked = true;
            this.existedCustomerRD.Location = new System.Drawing.Point(8, 102);
            this.existedCustomerRD.Margin = new System.Windows.Forms.Padding(4);
            this.existedCustomerRD.Name = "existedCustomerRD";
            this.existedCustomerRD.Size = new System.Drawing.Size(127, 20);
            this.existedCustomerRD.TabIndex = 0;
            this.existedCustomerRD.TabStop = true;
            this.existedCustomerRD.Text = "Cliente Esistente";
            this.existedCustomerRD.UseVisualStyleBackColor = true;
            this.existedCustomerRD.CheckedChanged += new System.EventHandler(this.existedCustomerRD_CheckedChanged);
            // 
            // newCustomerRD
            // 
            this.newCustomerRD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.newCustomerRD.AutoSize = true;
            this.newCustomerRD.Location = new System.Drawing.Point(7, 180);
            this.newCustomerRD.Margin = new System.Windows.Forms.Padding(4);
            this.newCustomerRD.Name = "newCustomerRD";
            this.newCustomerRD.Size = new System.Drawing.Size(112, 20);
            this.newCustomerRD.TabIndex = 2;
            this.newCustomerRD.Text = "Nuovo Cliente";
            this.newCustomerRD.UseVisualStyleBackColor = true;
            this.newCustomerRD.CheckedChanged += new System.EventHandler(this.newCustomerRD_CheckedChanged);
            // 
            // customerCB
            // 
            this.customerCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.customerCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerCB.FormattingEnabled = true;
            this.customerCB.Location = new System.Drawing.Point(11, 130);
            this.customerCB.Margin = new System.Windows.Forms.Padding(4);
            this.customerCB.Name = "customerCB";
            this.customerCB.Size = new System.Drawing.Size(510, 24);
            this.customerCB.TabIndex = 3;
            // 
            // AnagrPanel
            // 
            this.AnagrPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AnagrPanel.Controls.Add(this.panel1);
            this.AnagrPanel.Controls.Add(this.flowLayoutPanel2);
            this.AnagrPanel.Controls.Add(this.flowLayoutPanel1);
            this.AnagrPanel.Controls.Add(this.birthDatePanelTB);
            this.AnagrPanel.Controls.Add(this.birthDateLbl);
            this.AnagrPanel.Controls.Add(this.ZipCodePanelLBL);
            this.AnagrPanel.Controls.Add(this.ZipCodePanelTB);
            this.AnagrPanel.Controls.Add(this.AddressPanelLBL);
            this.AnagrPanel.Controls.Add(this.AddressPanelTB);
            this.AnagrPanel.Controls.Add(this.pec);
            this.AnagrPanel.Controls.Add(this.PecPanelTB);
            this.AnagrPanel.Controls.Add(this.notes);
            this.AnagrPanel.Controls.Add(this.notesPanelTB);
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
            this.AnagrPanel.Controls.Add(this.CustomerNamePanelTB);
            this.AnagrPanel.Controls.Add(this.RegionPanelLBL);
            this.AnagrPanel.Controls.Add(this.label2);
            this.AnagrPanel.Controls.Add(this.label1);
            this.AnagrPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AnagrPanel.Enabled = false;
            this.AnagrPanel.Location = new System.Drawing.Point(1, 208);
            this.AnagrPanel.Margin = new System.Windows.Forms.Padding(4);
            this.AnagrPanel.Name = "AnagrPanel";
            this.AnagrPanel.Size = new System.Drawing.Size(531, 601);
            this.AnagrPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Location = new System.Drawing.Point(11, 190);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 2);
            this.panel1.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.personalsInfo);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(11, 11);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(207, 31);
            this.flowLayoutPanel2.TabIndex = 37;
            // 
            // personalsInfo
            // 
            this.personalsInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.personalsInfo.AutoSize = true;
            this.personalsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalsInfo.Location = new System.Drawing.Point(4, 0);
            this.personalsInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.personalsInfo.Name = "personalsInfo";
            this.personalsInfo.Size = new System.Drawing.Size(142, 25);
            this.personalsInfo.TabIndex = 0;
            this.personalsInfo.Text = "Info personali";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.contacts);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 199);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(152, 23);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // contacts
            // 
            this.contacts.AutoSize = true;
            this.contacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contacts.Location = new System.Drawing.Point(4, 0);
            this.contacts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contacts.Name = "contacts";
            this.contacts.Size = new System.Drawing.Size(87, 25);
            this.contacts.TabIndex = 1;
            this.contacts.Text = "Contatti";
            // 
            // birthDatePanelTB
            // 
            this.birthDatePanelTB.Location = new System.Drawing.Point(371, 64);
            this.birthDatePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.birthDatePanelTB.MaxLength = 7;
            this.birthDatePanelTB.Name = "birthDatePanelTB";
            this.birthDatePanelTB.Size = new System.Drawing.Size(149, 22);
            this.birthDatePanelTB.TabIndex = 35;
            // 
            // birthDateLbl
            // 
            this.birthDateLbl.AutoSize = true;
            this.birthDateLbl.Location = new System.Drawing.Point(368, 46);
            this.birthDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.birthDateLbl.Name = "birthDateLbl";
            this.birthDateLbl.Size = new System.Drawing.Size(96, 16);
            this.birthDateLbl.TabIndex = 34;
            this.birthDateLbl.Text = "Data di nascita";
            // 
            // ZipCodePanelLBL
            // 
            this.ZipCodePanelLBL.AutoSize = true;
            this.ZipCodePanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ZipCodePanelLBL.Location = new System.Drawing.Point(172, 138);
            this.ZipCodePanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ZipCodePanelLBL.Name = "ZipCodePanelLBL";
            this.ZipCodePanelLBL.Size = new System.Drawing.Size(32, 16);
            this.ZipCodePanelLBL.TabIndex = 33;
            this.ZipCodePanelLBL.Text = "Cap";
            // 
            // ZipCodePanelTB
            // 
            this.ZipCodePanelTB.Enabled = false;
            this.ZipCodePanelTB.Location = new System.Drawing.Point(175, 160);
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
            this.AddressPanelLBL.Location = new System.Drawing.Point(217, 138);
            this.AddressPanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressPanelLBL.Name = "AddressPanelLBL";
            this.AddressPanelLBL.Size = new System.Drawing.Size(55, 16);
            this.AddressPanelLBL.TabIndex = 31;
            this.AddressPanelLBL.Text = "Indirizzo";
            // 
            // AddressPanelTB
            // 
            this.AddressPanelTB.Enabled = false;
            this.AddressPanelTB.Location = new System.Drawing.Point(220, 160);
            this.AddressPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.AddressPanelTB.MaxLength = 30;
            this.AddressPanelTB.Name = "AddressPanelTB";
            this.AddressPanelTB.Size = new System.Drawing.Size(297, 22);
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
            this.PecPanelTB.Size = new System.Drawing.Size(252, 22);
            this.PecPanelTB.TabIndex = 28;
            // 
            // notes
            // 
            this.notes.AutoSize = true;
            this.notes.Location = new System.Drawing.Point(13, 345);
            this.notes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(36, 16);
            this.notes.TabIndex = 27;
            this.notes.Text = "Note";
            // 
            // notesPanelTB
            // 
            this.notesPanelTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.notesPanelTB.Location = new System.Drawing.Point(11, 374);
            this.notesPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.notesPanelTB.Multiline = true;
            this.notesPanelTB.Name = "notesPanelTB";
            this.notesPanelTB.Size = new System.Drawing.Size(506, 226);
            this.notesPanelTB.TabIndex = 26;
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
            this.mobile.Location = new System.Drawing.Point(172, 242);
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
            this.MailPanelTB.Size = new System.Drawing.Size(245, 22);
            this.MailPanelTB.TabIndex = 20;
            // 
            // MobilePanelTB
            // 
            this.MobilePanelTB.Location = new System.Drawing.Point(177, 263);
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
            this.TelephonePanelTB.Size = new System.Drawing.Size(159, 22);
            this.TelephonePanelTB.TabIndex = 18;
            // 
            // CityPanelCB
            // 
            this.CityPanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CityPanelCB.Enabled = false;
            this.CityPanelCB.FormattingEnabled = true;
            this.CityPanelCB.Location = new System.Drawing.Point(11, 158);
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
            this.CityPanelLBL.Location = new System.Drawing.Point(7, 138);
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
            this.ProvincePanelCB.Location = new System.Drawing.Point(175, 110);
            this.ProvincePanelCB.Margin = new System.Windows.Forms.Padding(4);
            this.ProvincePanelCB.Name = "ProvincePanelCB";
            this.ProvincePanelCB.Size = new System.Drawing.Size(160, 24);
            this.ProvincePanelCB.TabIndex = 11;
            this.ProvincePanelCB.SelectedIndexChanged += new System.EventHandler(this.ProvincePanelCB_SelectedIndexChanged);
            // 
            // RegionPanelCB
            // 
            this.RegionPanelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionPanelCB.FormattingEnabled = true;
            this.RegionPanelCB.Location = new System.Drawing.Point(11, 110);
            this.RegionPanelCB.Margin = new System.Windows.Forms.Padding(4);
            this.RegionPanelCB.Name = "RegionPanelCB";
            this.RegionPanelCB.Size = new System.Drawing.Size(159, 24);
            this.RegionPanelCB.TabIndex = 10;
            this.RegionPanelCB.SelectedIndexChanged += new System.EventHandler(this.RegionPanelCB_SelectedIndexChanged);
            // 
            // ProvincePanelLBL
            // 
            this.ProvincePanelLBL.AutoSize = true;
            this.ProvincePanelLBL.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ProvincePanelLBL.Location = new System.Drawing.Point(172, 90);
            this.ProvincePanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProvincePanelLBL.Name = "ProvincePanelLBL";
            this.ProvincePanelLBL.Size = new System.Drawing.Size(63, 16);
            this.ProvincePanelLBL.TabIndex = 9;
            this.ProvincePanelLBL.Text = "Provincia";
            // 
            // IdTaxPanelTB
            // 
            this.IdTaxPanelTB.Location = new System.Drawing.Point(175, 64);
            this.IdTaxPanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.IdTaxPanelTB.MaxLength = 18;
            this.IdTaxPanelTB.Name = "IdTaxPanelTB";
            this.IdTaxPanelTB.Size = new System.Drawing.Size(195, 22);
            this.IdTaxPanelTB.TabIndex = 7;
            // 
            // CustomerNamePanelTB
            // 
            this.CustomerNamePanelTB.Location = new System.Drawing.Point(11, 64);
            this.CustomerNamePanelTB.Margin = new System.Windows.Forms.Padding(4);
            this.CustomerNamePanelTB.MaxLength = 49;
            this.CustomerNamePanelTB.Name = "CustomerNamePanelTB";
            this.CustomerNamePanelTB.Size = new System.Drawing.Size(161, 22);
            this.CustomerNamePanelTB.TabIndex = 6;
            // 
            // RegionPanelLBL
            // 
            this.RegionPanelLBL.AutoSize = true;
            this.RegionPanelLBL.Location = new System.Drawing.Point(11, 90);
            this.RegionPanelLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegionPanelLBL.Name = "RegionPanelLBL";
            this.RegionPanelLBL.Size = new System.Drawing.Size(59, 16);
            this.RegionPanelLBL.TabIndex = 5;
            this.RegionPanelLBL.Text = "Regione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cod.Fiscale";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Denominazione";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 95);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(417, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(11, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Selezione cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Inserisci il cliente dall\'archivio o creane uno nuovo";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(362, 818);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(443, 818);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AddNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 853);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.AnagrPanel);
            this.Controls.Add(this.customerCB);
            this.Controls.Add(this.newCustomerRD);
            this.Controls.Add(this.existedCustomerRD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddNewQuote_Load);
            this.AnagrPanel.ResumeLayout(false);
            this.AnagrPanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton existedCustomerRD;
        private System.Windows.Forms.RadioButton newCustomerRD;
        private System.Windows.Forms.ComboBox customerCB;
        public System.Windows.Forms.Panel AnagrPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label personalsInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label contacts;
        private System.Windows.Forms.TextBox birthDatePanelTB;
        private System.Windows.Forms.Label birthDateLbl;
        private System.Windows.Forms.Label ZipCodePanelLBL;
        private System.Windows.Forms.TextBox ZipCodePanelTB;
        private System.Windows.Forms.Label AddressPanelLBL;
        private System.Windows.Forms.TextBox AddressPanelTB;
        private System.Windows.Forms.Label pec;
        private System.Windows.Forms.TextBox PecPanelTB;
        private System.Windows.Forms.Label notes;
        private System.Windows.Forms.TextBox notesPanelTB;
        private System.Windows.Forms.Label mail;
        private System.Windows.Forms.Label mobile;
        private System.Windows.Forms.Label telephone;
        private System.Windows.Forms.TextBox MailPanelTB;
        private System.Windows.Forms.TextBox MobilePanelTB;
        private System.Windows.Forms.TextBox TelephonePanelTB;
        private System.Windows.Forms.ComboBox CityPanelCB;
        private System.Windows.Forms.Label CityPanelLBL;
        private System.Windows.Forms.ComboBox ProvincePanelCB;
        private System.Windows.Forms.ComboBox RegionPanelCB;
        private System.Windows.Forms.Label ProvincePanelLBL;
        private System.Windows.Forms.TextBox IdTaxPanelTB;
        private System.Windows.Forms.TextBox CustomerNamePanelTB;
        private System.Windows.Forms.Label RegionPanelLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}