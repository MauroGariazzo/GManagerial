namespace GManagerial.Documents.OrderDocument.ChildForms
{
    partial class AddWareHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWareHouse));
            this.warehouseCB = new System.Windows.Forms.ComboBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InfoFormLbl = new System.Windows.Forms.Label();
            this.InfoInputType = new System.Windows.Forms.Label();
            this.WarehouseLbl = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // warehouseCB
            // 
            this.warehouseCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCB.FormattingEnabled = true;
            this.warehouseCB.Location = new System.Drawing.Point(12, 130);
            this.warehouseCB.Name = "warehouseCB";
            this.warehouseCB.Size = new System.Drawing.Size(360, 24);
            this.warehouseCB.TabIndex = 0;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(216, 169);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(297, 169);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.InfoFormLbl);
            this.panel2.Controls.Add(this.InfoInputType);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 100);
            this.panel2.TabIndex = 23;
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
            this.InfoFormLbl.Size = new System.Drawing.Size(219, 25);
            this.InfoFormLbl.TabIndex = 1;
            this.InfoFormLbl.Text = "Selezione Magazzino";
            // 
            // InfoInputType
            // 
            this.InfoInputType.AutoSize = true;
            this.InfoInputType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoInputType.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.InfoInputType.Location = new System.Drawing.Point(16, 47);
            this.InfoInputType.Name = "InfoInputType";
            this.InfoInputType.Size = new System.Drawing.Size(160, 18);
            this.InfoInputType.TabIndex = 0;
            this.InfoInputType.Text = "Seleziona il magazzino";
            // 
            // WarehouseLbl
            // 
            this.WarehouseLbl.AutoSize = true;
            this.WarehouseLbl.Location = new System.Drawing.Point(12, 111);
            this.WarehouseLbl.Name = "WarehouseLbl";
            this.WarehouseLbl.Size = new System.Drawing.Size(72, 16);
            this.WarehouseLbl.TabIndex = 24;
            this.WarehouseLbl.Text = "Magazzino";
            // 
            // AddWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 205);
            this.ControlBox = false;
            this.Controls.Add(this.WarehouseLbl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.warehouseCB);
            this.Name = "AddWareHouse";
            this.Text = "AddWareHouse";
            this.Load += new System.EventHandler(this.AddWareHouse_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox warehouseCB;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label InfoFormLbl;
        private System.Windows.Forms.Label InfoInputType;
        private System.Windows.Forms.Label WarehouseLbl;
    }
}