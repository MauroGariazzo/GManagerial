namespace GManagerial.QuoteDocForms.ChildForms
{
    partial class ProductInformationsForQuoteDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInformationsForQuoteDocument));
            this.LoadBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.QtaLbl = new System.Windows.Forms.Label();
            this.QtaTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InfoFormLbl = new System.Windows.Forms.Label();
            this.InfoInputType = new System.Windows.Forms.Label();
            this.PriceLbl = new System.Windows.Forms.Label();
            this.priceListSell = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadBtn
            // 
            this.LoadBtn.FlatAppearance.BorderSize = 0;
            this.LoadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoadBtn.Image = ((System.Drawing.Image)(resources.GetObject("LoadBtn.Image")));
            this.LoadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoadBtn.Location = new System.Drawing.Point(11, 182);
            this.LoadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(75, 34);
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
            this.ExitBtn.Location = new System.Drawing.Point(106, 182);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(64, 34);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Esci";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // QtaLbl
            // 
            this.QtaLbl.AutoSize = true;
            this.QtaLbl.Location = new System.Drawing.Point(12, 117);
            this.QtaLbl.Name = "QtaLbl";
            this.QtaLbl.Size = new System.Drawing.Size(31, 16);
            this.QtaLbl.TabIndex = 4;
            this.QtaLbl.Text = "Q.ta";
            // 
            // QtaTB
            // 
            this.QtaTB.Location = new System.Drawing.Point(13, 135);
            this.QtaTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QtaTB.Multiline = true;
            this.QtaTB.Name = "QtaTB";
            this.QtaTB.Size = new System.Drawing.Size(168, 24);
            this.QtaTB.TabIndex = 5;
            this.QtaTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stockTB_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.InfoFormLbl);
            this.panel2.Controls.Add(this.InfoInputType);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 100);
            this.panel2.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(260, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // InfoFormLbl
            // 
            this.InfoFormLbl.AutoSize = true;
            this.InfoFormLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoFormLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.InfoFormLbl.Location = new System.Drawing.Point(11, 9);
            this.InfoFormLbl.Name = "InfoFormLbl";
            this.InfoFormLbl.Size = new System.Drawing.Size(133, 25);
            this.InfoFormLbl.TabIndex = 1;
            this.InfoFormLbl.Text = "Info prodotto";
            // 
            // InfoInputType
            // 
            this.InfoInputType.AutoSize = true;
            this.InfoInputType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoInputType.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.InfoInputType.Location = new System.Drawing.Point(16, 47);
            this.InfoInputType.Name = "InfoInputType";
            this.InfoInputType.Size = new System.Drawing.Size(94, 18);
            this.InfoInputType.TabIndex = 0;
            this.InfoInputType.Text = "Dati prodotto";
            // 
            // PriceLbl
            // 
            this.PriceLbl.AutoSize = true;
            this.PriceLbl.Location = new System.Drawing.Point(184, 117);
            this.PriceLbl.Name = "PriceLbl";
            this.PriceLbl.Size = new System.Drawing.Size(48, 16);
            this.PriceLbl.TabIndex = 27;
            this.PriceLbl.Text = "Prezzo";
            // 
            // priceListSell
            // 
            this.priceListSell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priceListSell.FormattingEnabled = true;
            this.priceListSell.Location = new System.Drawing.Point(187, 135);
            this.priceListSell.Name = "priceListSell";
            this.priceListSell.Size = new System.Drawing.Size(184, 24);
            this.priceListSell.TabIndex = 28;
            // 
            // ProductInformationsForQuoteDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 299);
            this.ControlBox = false;
            this.Controls.Add(this.priceListSell);
            this.Controls.Add(this.PriceLbl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.QtaTB);
            this.Controls.Add(this.QtaLbl);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.LoadBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProductInformationsForQuoteDocument";
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
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label QtaLbl;
        private System.Windows.Forms.TextBox QtaTB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label InfoFormLbl;
        private System.Windows.Forms.Label InfoInputType;
        private System.Windows.Forms.Label PriceLbl;
        private DecimalTextBox _price;

        private void InitializeSetAddComponents()
        {
            InitializeMyComponent();
            AddMyControls();
            SetCompononentsValues();
        }

        private void AddMyControls()
        {
            this.Controls.Add(_price);
        }

        private void InitializeMyComponent()
        {
            this._price = new DecimalTextBox(10000000);
        }

        private void SetCompononentsValues()
        {
            this._price.Location = new System.Drawing.Point(139, 159);
            this._price.Margin = new System.Windows.Forms.Padding(4);
            this._price.Name = "PriceProduct";
            this._price.Size = new System.Drawing.Size(119, 22);
            this._price.TabIndex = 72;
            this._price.ShortcutsEnabled = false;
            this._price.Enabled = false;
        }

        private System.Windows.Forms.ComboBox priceListSell;
    }
}