namespace GManagerial.WareHouse.LoadMerchForm
{
    partial class LoadMerchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadMerchForm));
            this.LoadMerchDGV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddProduct = new System.Windows.Forms.ToolStripButton();
            this.EditProduct = new System.Windows.Forms.ToolStripButton();
            this.RemoveProduct = new System.Windows.Forms.ToolStripButton();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LoadMerchDGV)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadMerchDGV
            // 
            this.LoadMerchDGV.AllowUserToAddRows = false;
            this.LoadMerchDGV.AllowUserToDeleteRows = false;
            this.LoadMerchDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LoadMerchDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadMerchDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoadMerchDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.product_Name,
            this.company_name,
            this.WareHouse,
            this.quantity});
            this.LoadMerchDGV.Location = new System.Drawing.Point(2, 85);
            this.LoadMerchDGV.MultiSelect = false;
            this.LoadMerchDGV.Name = "LoadMerchDGV";
            this.LoadMerchDGV.RowHeadersVisible = false;
            this.LoadMerchDGV.RowHeadersWidth = 51;
            this.LoadMerchDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LoadMerchDGV.Size = new System.Drawing.Size(537, 275);
            this.LoadMerchDGV.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(2, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 81);
            this.panel2.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(453, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Carico Magazzino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Carico merce nel magazzino";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProduct,
            this.EditProduct,
            this.RemoveProduct});
            this.toolStrip1.Location = new System.Drawing.Point(0, 366);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(544, 27);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddProduct
            // 
            this.AddProduct.Image = ((System.Drawing.Image)(resources.GetObject("AddProduct.Image")));
            this.AddProduct.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(126, 24);
            this.AddProduct.Text = "Aggiungi prodotto";
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // EditProduct
            // 
            this.EditProduct.Image = ((System.Drawing.Image)(resources.GetObject("EditProduct.Image")));
            this.EditProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditProduct.Name = "EditProduct";
            this.EditProduct.Size = new System.Drawing.Size(128, 24);
            this.EditProduct.Text = "Modifica prodotto";
            this.EditProduct.Click += new System.EventHandler(this.EditProduct_Click);
            // 
            // RemoveProduct
            // 
            this.RemoveProduct.Image = ((System.Drawing.Image)(resources.GetObject("RemoveProduct.Image")));
            this.RemoveProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveProduct.Name = "RemoveProduct";
            this.RemoveProduct.Size = new System.Drawing.Size(125, 24);
            this.RemoveProduct.Text = "Rimuovi prodotto";
            // 
            // confirmBtn
            // 
            this.confirmBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.confirmBtn.Location = new System.Drawing.Point(398, 371);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(2);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(65, 19);
            this.confirmBtn.TabIndex = 23;
            this.confirmBtn.Text = "Conferma";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cancelBtn.Location = new System.Drawing.Point(467, 371);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(56, 19);
            this.cancelBtn.TabIndex = 24;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // product_id
            // 
            this.product_id.HeaderText = "id prodotto";
            this.product_id.MinimumWidth = 6;
            this.product_id.Name = "product_id";
            this.product_id.ReadOnly = true;
            // 
            // product_Name
            // 
            this.product_Name.HeaderText = "nome prodotto";
            this.product_Name.MinimumWidth = 6;
            this.product_Name.Name = "product_Name";
            this.product_Name.ReadOnly = true;
            // 
            // company_name
            // 
            this.company_name.HeaderText = "nome fornitore";
            this.company_name.MinimumWidth = 6;
            this.company_name.Name = "company_name";
            this.company_name.ReadOnly = true;
            // 
            // WareHouse
            // 
            this.WareHouse.HeaderText = "magazzino";
            this.WareHouse.Name = "WareHouse";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "carico";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // LoadMerchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 393);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LoadMerchDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoadMerchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadMerchForm";
            this.Load += new System.EventHandler(this.LoadMerchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadMerchDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView LoadMerchDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddProduct;
        private System.Windows.Forms.ToolStripButton EditProduct;
        private System.Windows.Forms.ToolStripButton RemoveProduct;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn WareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
    }
}