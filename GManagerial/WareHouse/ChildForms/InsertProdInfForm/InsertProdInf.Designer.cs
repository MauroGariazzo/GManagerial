namespace GManagerial.WareHouse.ChildForms
{
    partial class InsertProdInf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertProdInf));
            this.SupplierLbl = new System.Windows.Forms.Label();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.stockLbl = new System.Windows.Forms.Label();
            this.stockTB = new System.Windows.Forms.TextBox();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.underStockTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InfoFormLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.umCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.wareHouseCB = new System.Windows.Forms.ComboBox();
            this.Expiration_dateTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SupplierLbl
            // 
            this.SupplierLbl.AutoSize = true;
            this.SupplierLbl.Location = new System.Drawing.Point(9, 91);
            this.SupplierLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SupplierLbl.Name = "SupplierLbl";
            this.SupplierLbl.Size = new System.Drawing.Size(48, 13);
            this.SupplierLbl.TabIndex = 1;
            this.SupplierLbl.Text = "Fornitore";
            // 
            // LoadBtn
            // 
            this.LoadBtn.FlatAppearance.BorderSize = 0;
            this.LoadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoadBtn.Image = ((System.Drawing.Image)(resources.GetObject("LoadBtn.Image")));
            this.LoadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoadBtn.Location = new System.Drawing.Point(13, 206);
            this.LoadBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(56, 28);
            this.LoadBtn.TabIndex = 2;
            this.LoadBtn.Text = "Carica";
            this.LoadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitBtn.Location = new System.Drawing.Point(84, 206);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(48, 28);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Esci";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // stockLbl
            // 
            this.stockLbl.AutoSize = true;
            this.stockLbl.Location = new System.Drawing.Point(111, 91);
            this.stockLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stockLbl.Name = "stockLbl";
            this.stockLbl.Size = new System.Drawing.Size(37, 13);
            this.stockLbl.TabIndex = 4;
            this.stockLbl.Text = "Carica";
            // 
            // stockTB
            // 
            this.stockTB.Location = new System.Drawing.Point(113, 109);
            this.stockTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stockTB.Name = "stockTB";
            this.stockTB.Size = new System.Drawing.Size(93, 20);
            this.stockTB.TabIndex = 5;
            this.stockTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stockTB_KeyPress);
            // 
            // cbSupplier
            // 
            this.cbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(11, 107);
            this.cbSupplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(92, 21);
            this.cbSupplier.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "che minca ci metto qua?";
            // 
            // underStockTB
            // 
            this.underStockTB.Location = new System.Drawing.Point(214, 109);
            this.underStockTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.underStockTB.Name = "underStockTB";
            this.underStockTB.Size = new System.Drawing.Size(114, 20);
            this.underStockTB.TabIndex = 8;
            this.underStockTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.underStockTB_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.InfoFormLbl);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 81);
            this.panel2.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(231, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // InfoFormLbl
            // 
            this.InfoFormLbl.AutoSize = true;
            this.InfoFormLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoFormLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.InfoFormLbl.Location = new System.Drawing.Point(8, 7);
            this.InfoFormLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InfoFormLbl.Name = "InfoFormLbl";
            this.InfoFormLbl.Size = new System.Drawing.Size(151, 20);
            this.InfoFormLbl.TabIndex = 1;
            this.InfoFormLbl.Text = "Carico Magazzino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dati prodotto per carico merce";
            // 
            // umCB
            // 
            this.umCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.umCB.FormattingEnabled = true;
            this.umCB.Location = new System.Drawing.Point(11, 160);
            this.umCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.umCB.Name = "umCB";
            this.umCB.Size = new System.Drawing.Size(92, 21);
            this.umCB.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "UM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 142);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Magazzino";
            // 
            // wareHouseCB
            // 
            this.wareHouseCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wareHouseCB.FormattingEnabled = true;
            this.wareHouseCB.Location = new System.Drawing.Point(113, 159);
            this.wareHouseCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wareHouseCB.Name = "wareHouseCB";
            this.wareHouseCB.Size = new System.Drawing.Size(92, 21);
            this.wareHouseCB.TabIndex = 26;
            // 
            // Expiration_dateTB
            // 
            this.Expiration_dateTB.Location = new System.Drawing.Point(215, 159);
            this.Expiration_dateTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Expiration_dateTB.MaxLength = 10;
            this.Expiration_dateTB.Name = "Expiration_dateTB";
            this.Expiration_dateTB.Size = new System.Drawing.Size(114, 20);
            this.Expiration_dateTB.TabIndex = 27;
            this.Expiration_dateTB.TextChanged += new System.EventHandler(this.Expiration_dateTB_TextChanged);
            this.Expiration_dateTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Expiration_dateTB_KeyDown);
            this.Expiration_dateTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Expiration_dateTB_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 142);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Data Scadenza";
            // 
            // InsertProdInf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 245);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Expiration_dateTB);
            this.Controls.Add(this.wareHouseCB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.umCB);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.underStockTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSupplier);
            this.Controls.Add(this.stockTB);
            this.Controls.Add(this.stockLbl);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.LoadBtn);
            this.Controls.Add(this.SupplierLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InsertProdInf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dati Generali";
            this.Load += new System.EventHandler(this.SelectProductBySupplier_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SupplierLbl;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label stockLbl;
        private System.Windows.Forms.TextBox stockTB;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox underStockTB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label InfoFormLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox umCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox wareHouseCB;
        private System.Windows.Forms.TextBox Expiration_dateTB;
        private System.Windows.Forms.Label label7;
    }
}