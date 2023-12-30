namespace GManagerial
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.Customers = new System.Windows.Forms.ToolStripButton();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.Docs = new System.Windows.Forms.ToolStripButton();
            this.Warehouse = new System.Windows.Forms.ToolStripButton();
            this.productsBtn = new System.Windows.Forms.ToolStripButton();
            this.SuppliersBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.docsMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.preventiviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fattureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.productsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catAndSubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrandItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.WHsitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.docsMS.SuspendLayout();
            this.productCMS.SuspendLayout();
            this.whCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Home,
            this.Customers,
            this.Exit,
            this.Docs,
            this.Warehouse,
            this.productsBtn,
            this.SuppliersBtn,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1664, 70);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Home
            // 
            this.Home.AutoSize = false;
            this.Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Home.Image = ((System.Drawing.Image)(resources.GetObject("Home.Image")));
            this.Home.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Home.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(60, 65);
            this.Home.Text = "Home";
            this.Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Home.ToolTipText = "Home";
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Customers
            // 
            this.Customers.AutoSize = false;
            this.Customers.Image = ((System.Drawing.Image)(resources.GetObject("Customers.Image")));
            this.Customers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Customers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Customers.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Customers.Name = "Customers";
            this.Customers.Size = new System.Drawing.Size(60, 65);
            this.Customers.Text = "Clienti";
            this.Customers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Customers.Click += new System.EventHandler(this.Customers_Click);
            // 
            // Exit
            // 
            this.Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Exit.AutoSize = false;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(60, 65);
            this.Exit.Text = "Esci";
            this.Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Docs
            // 
            this.Docs.AutoSize = false;
            this.Docs.Image = ((System.Drawing.Image)(resources.GetObject("Docs.Image")));
            this.Docs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Docs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Docs.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Docs.Name = "Docs";
            this.Docs.Size = new System.Drawing.Size(70, 65);
            this.Docs.Text = "Documenti";
            this.Docs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Docs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Docs_MouseDown);
            // 
            // Warehouse
            // 
            this.Warehouse.AutoSize = false;
            this.Warehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Warehouse.Image = ((System.Drawing.Image)(resources.GetObject("Warehouse.Image")));
            this.Warehouse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Warehouse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Warehouse.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Warehouse.Name = "Warehouse";
            this.Warehouse.Size = new System.Drawing.Size(60, 65);
            this.Warehouse.Text = "Magazzino";
            this.Warehouse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Warehouse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Warehouse_MouseDown);
            // 
            // productsBtn
            // 
            this.productsBtn.Image = ((System.Drawing.Image)(resources.GetObject("productsBtn.Image")));
            this.productsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.productsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.productsBtn.Name = "productsBtn";
            this.productsBtn.Size = new System.Drawing.Size(54, 67);
            this.productsBtn.Text = "Prodotti";
            this.productsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.productsBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.productsBtn_MouseDown);
            // 
            // SuppliersBtn
            // 
            this.SuppliersBtn.Image = ((System.Drawing.Image)(resources.GetObject("SuppliersBtn.Image")));
            this.SuppliersBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SuppliersBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SuppliersBtn.Name = "SuppliersBtn";
            this.SuppliersBtn.Size = new System.Drawing.Size(56, 67);
            this.SuppliersBtn.Text = "Fornitori";
            this.SuppliersBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SuppliersBtn.Click += new System.EventHandler(this.SuppliersBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 70);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // panelDesktop
            // 
            this.panelDesktop.AutoSize = true;
            this.panelDesktop.BackColor = System.Drawing.SystemColors.Window;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.ForeColor = System.Drawing.Color.Black;
            this.panelDesktop.Location = new System.Drawing.Point(0, 70);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1664, 893);
            this.panelDesktop.TabIndex = 2;
            // 
            // docsMS
            // 
            this.docsMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.docsMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preventiviToolStripMenuItem,
            this.fattureToolStripMenuItem,
            this.dDTToolStripMenuItem});
            this.docsMS.Name = "docsMS";
            this.docsMS.Size = new System.Drawing.Size(131, 82);
            // 
            // preventiviToolStripMenuItem
            // 
            this.preventiviToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("preventiviToolStripMenuItem.Image")));
            this.preventiviToolStripMenuItem.Name = "preventiviToolStripMenuItem";
            this.preventiviToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.preventiviToolStripMenuItem.Text = "Preventivi";
            this.preventiviToolStripMenuItem.Click += new System.EventHandler(this.preventiviToolStripMenuItem_Click);
            // 
            // fattureToolStripMenuItem
            // 
            this.fattureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fattureToolStripMenuItem.Image")));
            this.fattureToolStripMenuItem.Name = "fattureToolStripMenuItem";
            this.fattureToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.fattureToolStripMenuItem.Text = "Fatture";
            // 
            // dDTToolStripMenuItem
            // 
            this.dDTToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dDTToolStripMenuItem.Image")));
            this.dDTToolStripMenuItem.Name = "dDTToolStripMenuItem";
            this.dDTToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.dDTToolStripMenuItem.Text = "D.D.T.";
            // 
            // productCMS
            // 
            this.productCMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.productCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsItem,
            this.catAndSubItem,
            this.BrandItem});
            this.productCMS.Name = "productCMS";
            this.productCMS.Size = new System.Drawing.Size(208, 70);
            // 
            // productsItem
            // 
            this.productsItem.Name = "productsItem";
            this.productsItem.Size = new System.Drawing.Size(207, 22);
            this.productsItem.Text = "Prodotti";
            this.productsItem.Click += new System.EventHandler(this.productsItem_Click);
            // 
            // catAndSubItem
            // 
            this.catAndSubItem.Name = "catAndSubItem";
            this.catAndSubItem.Size = new System.Drawing.Size(207, 22);
            this.catAndSubItem.Text = "Categorie/Sottocategorie";
            this.catAndSubItem.Click += new System.EventHandler(this.categorieSottocategorieToolStripMenuItem_Click);
            // 
            // BrandItem
            // 
            this.BrandItem.Name = "BrandItem";
            this.BrandItem.Size = new System.Drawing.Size(207, 22);
            this.BrandItem.Text = "Marche";
            this.BrandItem.Click += new System.EventHandler(this.BrandItem_Click);
            // 
            // whCMS
            // 
            this.whCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WHsitItem,
            this.movimentiToolStripMenuItem});
            this.whCMS.Name = "whCMS";
            this.whCMS.Size = new System.Drawing.Size(181, 70);
            // 
            // WHsitItem
            // 
            this.WHsitItem.Name = "WHsitItem";
            this.WHsitItem.Size = new System.Drawing.Size(180, 22);
            this.WHsitItem.Text = "Situazione";
            this.WHsitItem.Click += new System.EventHandler(this.WHsitItem_Click);
            // 
            // movimentiToolStripMenuItem
            // 
            this.movimentiToolStripMenuItem.Name = "movimentiToolStripMenuItem";
            this.movimentiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.movimentiToolStripMenuItem.Text = "Movimenti";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 963);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gmanagerial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.docsMS.ResumeLayout(false);
            this.productCMS.ResumeLayout(false);
            this.whCMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripButton Exit;
        private System.Windows.Forms.ToolStripButton Docs;
        private System.Windows.Forms.ToolStripButton Customers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Warehouse;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.ContextMenuStrip docsMS;
        private System.Windows.Forms.ToolStripMenuItem preventiviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fattureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDTToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton productsBtn;
        private System.Windows.Forms.ToolStripButton SuppliersBtn;
        private System.Windows.Forms.ContextMenuStrip productCMS;
        private System.Windows.Forms.ToolStripMenuItem productsItem;
        private System.Windows.Forms.ToolStripMenuItem catAndSubItem;
        private System.Windows.Forms.ToolStripMenuItem BrandItem;
        private System.Windows.Forms.ContextMenuStrip whCMS;
        private System.Windows.Forms.ToolStripMenuItem WHsitItem;
        private System.Windows.Forms.ToolStripMenuItem movimentiToolStripMenuItem;
    }
}