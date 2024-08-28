namespace GManagerial.WareHouse.LoadMerch
{
    partial class UnloadMerchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnloadMerchForm));
            this.UnloadMerchDGV = new System.Windows.Forms.DataGridView();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouse_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WareHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.CausalTB = new System.Windows.Forms.TextBox();
            this.CausalLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UnloadMerchDGV)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnloadMerchDGV
            // 
            this.UnloadMerchDGV.AllowUserToAddRows = false;
            this.UnloadMerchDGV.AllowUserToDeleteRows = false;
            this.UnloadMerchDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UnloadMerchDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UnloadMerchDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnloadMerchDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.product_Name,
            this.Supplier_id,
            this.supplier_name,
            this.warehouse_id,
            this.WareHouse,
            this.quantity});
            this.UnloadMerchDGV.Location = new System.Drawing.Point(3, 105);
            this.UnloadMerchDGV.Margin = new System.Windows.Forms.Padding(4);
            this.UnloadMerchDGV.MultiSelect = false;
            this.UnloadMerchDGV.Name = "UnloadMerchDGV";
            this.UnloadMerchDGV.RowHeadersVisible = false;
            this.UnloadMerchDGV.RowHeadersWidth = 51;
            this.UnloadMerchDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UnloadMerchDGV.Size = new System.Drawing.Size(799, 310);
            this.UnloadMerchDGV.TabIndex = 0;
            this.UnloadMerchDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnloadMerchDGV_CellEndEdit);
            this.UnloadMerchDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.UnloadMerchDGV_EditingControlShowing);
            this.UnloadMerchDGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UnloadMerchDGV_KeyPress);
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
            // Supplier_id
            // 
            this.Supplier_id.HeaderText = "id fornitore";
            this.Supplier_id.MinimumWidth = 6;
            this.Supplier_id.Name = "Supplier_id";
            this.Supplier_id.ReadOnly = true;
            // 
            // supplier_name
            // 
            this.supplier_name.HeaderText = "nome fornitore";
            this.supplier_name.MinimumWidth = 6;
            this.supplier_name.Name = "supplier_name";
            this.supplier_name.ReadOnly = true;
            // 
            // warehouse_id
            // 
            this.warehouse_id.HeaderText = "id magazzino";
            this.warehouse_id.MinimumWidth = 6;
            this.warehouse_id.Name = "warehouse_id";
            this.warehouse_id.ReadOnly = true;
            // 
            // WareHouse
            // 
            this.WareHouse.HeaderText = "magazzino";
            this.WareHouse.MinimumWidth = 6;
            this.WareHouse.Name = "WareHouse";
            this.WareHouse.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "scarico";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 100);
            this.panel2.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(604, 15);
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
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Scarico Magazzino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(16, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Scarico merce nel magazzino";
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 457);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 27);
            this.toolStrip1.TabIndex = 22;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddProduct
            // 
            this.AddProduct.Image = ((System.Drawing.Image)(resources.GetObject("AddProduct.Image")));
            this.AddProduct.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(154, 24);
            this.AddProduct.Text = "Aggiungi prodotto";
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // EditProduct
            // 
            this.EditProduct.Image = ((System.Drawing.Image)(resources.GetObject("EditProduct.Image")));
            this.EditProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditProduct.Name = "EditProduct";
            this.EditProduct.Size = new System.Drawing.Size(156, 24);
            this.EditProduct.Text = "Modifica prodotto";
            this.EditProduct.Click += new System.EventHandler(this.EditProduct_Click);
            // 
            // RemoveProduct
            // 
            this.RemoveProduct.Image = ((System.Drawing.Image)(resources.GetObject("RemoveProduct.Image")));
            this.RemoveProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveProduct.Name = "RemoveProduct";
            this.RemoveProduct.Size = new System.Drawing.Size(151, 24);
            this.RemoveProduct.Text = "Rimuovi prodotto";
            this.RemoveProduct.Click += new System.EventHandler(this.RemoveProduct_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.confirmBtn.Location = new System.Drawing.Point(620, 457);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(87, 23);
            this.confirmBtn.TabIndex = 23;
            this.confirmBtn.Text = "Conferma";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cancelBtn.Location = new System.Drawing.Point(715, 457);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 24;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // CausalTB
            // 
            this.CausalTB.Location = new System.Drawing.Point(83, 422);
            this.CausalTB.Name = "CausalTB";
            this.CausalTB.Size = new System.Drawing.Size(707, 22);
            this.CausalTB.TabIndex = 28;
            // 
            // CausalLbl
            // 
            this.CausalLbl.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CausalLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CausalLbl.Location = new System.Drawing.Point(-2, 419);
            this.CausalLbl.Name = "CausalLbl";
            this.CausalLbl.Size = new System.Drawing.Size(118, 26);
            this.CausalLbl.TabIndex = 27;
            this.CausalLbl.Text = "Causale:";
            // 
            // UnloadMerchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 484);
            this.Controls.Add(this.CausalTB);
            this.Controls.Add(this.CausalLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.UnloadMerchDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UnloadMerchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadMerchForm";
            ((System.ComponentModel.ISupportInitialize)(this.UnloadMerchDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UnloadMerchDGV;
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
        private System.Windows.Forms.TextBox CausalTB;
        private System.Windows.Forms.Label CausalLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouse_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn WareHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
    }
}