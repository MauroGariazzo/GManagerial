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
            this.ExistCustRD = new System.Windows.Forms.RadioButton();
            this.newCustRD = new System.Windows.Forms.RadioButton();
            this.customerCB = new System.Windows.Forms.ComboBox();
            this.AnagrPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.personalsInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contacts = new System.Windows.Forms.Label();
            this.birthDateTB = new System.Windows.Forms.TextBox();
            this.birthDateLbl = new System.Windows.Forms.Label();
            this.CapLbl = new System.Windows.Forms.Label();
            this.CapBox = new System.Windows.Forms.TextBox();
            this.AddressLbl = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.pec = new System.Windows.Forms.Label();
            this.pecBox = new System.Windows.Forms.TextBox();
            this.notes = new System.Windows.Forms.Label();
            this.notesBox = new System.Windows.Forms.TextBox();
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
            this.denBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AnagrPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExistCustRD
            // 
            this.ExistCustRD.AutoSize = true;
            this.ExistCustRD.Checked = true;
            this.ExistCustRD.Location = new System.Drawing.Point(8, 102);
            this.ExistCustRD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExistCustRD.Name = "ExistCustRD";
            this.ExistCustRD.Size = new System.Drawing.Size(127, 20);
            this.ExistCustRD.TabIndex = 0;
            this.ExistCustRD.TabStop = true;
            this.ExistCustRD.Text = "Cliente Esistente";
            this.ExistCustRD.UseVisualStyleBackColor = true;
            this.ExistCustRD.CheckedChanged += new System.EventHandler(this.ExistCustRD_CheckedChanged);
            // 
            // newCustRD
            // 
            this.newCustRD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newCustRD.AutoSize = true;
            this.newCustRD.Location = new System.Drawing.Point(7, 180);
            this.newCustRD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newCustRD.Name = "newCustRD";
            this.newCustRD.Size = new System.Drawing.Size(112, 20);
            this.newCustRD.TabIndex = 2;
            this.newCustRD.Text = "Nuovo Cliente";
            this.newCustRD.UseVisualStyleBackColor = true;
            this.newCustRD.CheckedChanged += new System.EventHandler(this.newCustRD_CheckedChanged);
            // 
            // customerCB
            // 
            this.customerCB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerCB.FormattingEnabled = true;
            this.customerCB.Location = new System.Drawing.Point(5, 130);
            this.customerCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.customerCB.Name = "customerCB";
            this.customerCB.Size = new System.Drawing.Size(636, 24);
            this.customerCB.TabIndex = 3;
            // 
            // AnagrPanel
            // 
            this.AnagrPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnagrPanel.Controls.Add(this.panel1);
            this.AnagrPanel.Controls.Add(this.flowLayoutPanel2);
            this.AnagrPanel.Controls.Add(this.flowLayoutPanel1);
            this.AnagrPanel.Controls.Add(this.birthDateTB);
            this.AnagrPanel.Controls.Add(this.birthDateLbl);
            this.AnagrPanel.Controls.Add(this.CapLbl);
            this.AnagrPanel.Controls.Add(this.CapBox);
            this.AnagrPanel.Controls.Add(this.AddressLbl);
            this.AnagrPanel.Controls.Add(this.AddressBox);
            this.AnagrPanel.Controls.Add(this.pec);
            this.AnagrPanel.Controls.Add(this.pecBox);
            this.AnagrPanel.Controls.Add(this.notes);
            this.AnagrPanel.Controls.Add(this.notesBox);
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
            this.AnagrPanel.Controls.Add(this.denBox);
            this.AnagrPanel.Controls.Add(this.label4);
            this.AnagrPanel.Controls.Add(this.label2);
            this.AnagrPanel.Controls.Add(this.label1);
            this.AnagrPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AnagrPanel.Enabled = false;
            this.AnagrPanel.Location = new System.Drawing.Point(1, 208);
            this.AnagrPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AnagrPanel.Name = "AnagrPanel";
            this.AnagrPanel.Size = new System.Drawing.Size(661, 601);
            this.AnagrPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Location = new System.Drawing.Point(11, 190);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 2);
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
            // birthDateTB
            // 
            this.birthDateTB.Location = new System.Drawing.Point(371, 64);
            this.birthDateTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.birthDateTB.MaxLength = 7;
            this.birthDateTB.Name = "birthDateTB";
            this.birthDateTB.Size = new System.Drawing.Size(143, 22);
            this.birthDateTB.TabIndex = 35;
            // 
            // birthDateLbl
            // 
            this.birthDateLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.birthDateLbl.AutoSize = true;
            this.birthDateLbl.Location = new System.Drawing.Point(368, 46);
            this.birthDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.birthDateLbl.Name = "birthDateLbl";
            this.birthDateLbl.Size = new System.Drawing.Size(96, 16);
            this.birthDateLbl.TabIndex = 34;
            this.birthDateLbl.Text = "Data di nascita";
            // 
            // CapLbl
            // 
            this.CapLbl.AutoSize = true;
            this.CapLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CapLbl.Location = new System.Drawing.Point(172, 138);
            this.CapLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CapLbl.Name = "CapLbl";
            this.CapLbl.Size = new System.Drawing.Size(32, 16);
            this.CapLbl.TabIndex = 33;
            this.CapLbl.Text = "Cap";
            // 
            // CapBox
            // 
            this.CapBox.Enabled = false;
            this.CapBox.Location = new System.Drawing.Point(175, 160);
            this.CapBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CapBox.MaxLength = 5;
            this.CapBox.Name = "CapBox";
            this.CapBox.Size = new System.Drawing.Size(41, 22);
            this.CapBox.TabIndex = 32;
            // 
            // AddressLbl
            // 
            this.AddressLbl.AutoSize = true;
            this.AddressLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.AddressLbl.Location = new System.Drawing.Point(217, 138);
            this.AddressLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddressLbl.Name = "AddressLbl";
            this.AddressLbl.Size = new System.Drawing.Size(55, 16);
            this.AddressLbl.TabIndex = 31;
            this.AddressLbl.Text = "Indirizzo";
            // 
            // AddressBox
            // 
            this.AddressBox.Enabled = false;
            this.AddressBox.Location = new System.Drawing.Point(220, 160);
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
            this.pecBox.Size = new System.Drawing.Size(225, 22);
            this.pecBox.TabIndex = 28;
            // 
            // notes
            // 
            this.notes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notes.AutoSize = true;
            this.notes.Location = new System.Drawing.Point(13, 345);
            this.notes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(36, 16);
            this.notes.TabIndex = 27;
            this.notes.Text = "Note";
            // 
            // notesBox
            // 
            this.notesBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notesBox.Location = new System.Drawing.Point(11, 374);
            this.notesBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.notesBox.Multiline = true;
            this.notesBox.Name = "notesBox";
            this.notesBox.Size = new System.Drawing.Size(641, 226);
            this.notesBox.TabIndex = 26;
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
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(12, 318);
            this.mailBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mailBox.MaxLength = 100;
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(245, 22);
            this.mailBox.TabIndex = 20;
            // 
            // mobileBox
            // 
            this.mobileBox.Location = new System.Drawing.Point(177, 263);
            this.mobileBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mobileBox.MaxLength = 20;
            this.mobileBox.Name = "mobileBox";
            this.mobileBox.Size = new System.Drawing.Size(169, 22);
            this.mobileBox.TabIndex = 19;
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(11, 263);
            this.telBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.telBox.MaxLength = 20;
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(159, 22);
            this.telBox.TabIndex = 18;
            // 
            // municBox
            // 
            this.municBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.municBox.Enabled = false;
            this.municBox.FormattingEnabled = true;
            this.municBox.Location = new System.Drawing.Point(11, 158);
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
            this.municipLbl.Location = new System.Drawing.Point(7, 138);
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
            this.provBox.Location = new System.Drawing.Point(175, 110);
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
            this.regionBox.Location = new System.Drawing.Point(11, 110);
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
            this.provLbl.Location = new System.Drawing.Point(172, 90);
            this.provLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.provLbl.Name = "provLbl";
            this.provLbl.Size = new System.Drawing.Size(63, 16);
            this.provLbl.TabIndex = 9;
            this.provLbl.Text = "Provincia";
            // 
            // idTaxBox
            // 
            this.idTaxBox.Location = new System.Drawing.Point(175, 64);
            this.idTaxBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.idTaxBox.MaxLength = 18;
            this.idTaxBox.Name = "idTaxBox";
            this.idTaxBox.Size = new System.Drawing.Size(195, 22);
            this.idTaxBox.TabIndex = 7;
            // 
            // denBox
            // 
            this.denBox.Location = new System.Drawing.Point(11, 64);
            this.denBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.denBox.MaxLength = 49;
            this.denBox.Name = "denBox";
            this.denBox.Size = new System.Drawing.Size(161, 22);
            this.denBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Regione";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cancelBtn.Location = new System.Drawing.Point(124, 816);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(83, 26);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmBtn.FlatAppearance.BorderSize = 0;
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.confirmBtn.Location = new System.Drawing.Point(8, 816);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(91, 26);
            this.confirmBtn.TabIndex = 14;
            this.confirmBtn.Text = "Conferma";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(547, 9);
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(16, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(383, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Inserisci il cliente dall\'archivio o creane uno nuovo";
            // 
            // AddNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 853);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.AnagrPanel);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.customerCB);
            this.Controls.Add(this.newCustRD);
            this.Controls.Add(this.ExistCustRD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

        private System.Windows.Forms.RadioButton ExistCustRD;
        private System.Windows.Forms.RadioButton newCustRD;
        private System.Windows.Forms.ComboBox customerCB;
        public System.Windows.Forms.Panel AnagrPanel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label personalsInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label contacts;
        private System.Windows.Forms.TextBox birthDateTB;
        private System.Windows.Forms.Label birthDateLbl;
        private System.Windows.Forms.Label CapLbl;
        private System.Windows.Forms.TextBox CapBox;
        private System.Windows.Forms.Label AddressLbl;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label pec;
        private System.Windows.Forms.TextBox pecBox;
        private System.Windows.Forms.Label notes;
        private System.Windows.Forms.TextBox notesBox;
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
        private System.Windows.Forms.TextBox denBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}