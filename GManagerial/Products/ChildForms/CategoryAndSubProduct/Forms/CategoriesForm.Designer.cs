namespace GManagerial.Products.ChildForms
{
    partial class CategoriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriesForm));
            this.nedTS = new System.Windows.Forms.ToolStrip();
            this.newBtn = new System.Windows.Forms.ToolStripButton();
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.catTV = new System.Windows.Forms.TreeView();
            this.newBtnMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subcategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitBtn = new System.Windows.Forms.Button();
            this.nedTS.SuspendLayout();
            this.newBtnMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // nedTS
            // 
            this.nedTS.Dock = System.Windows.Forms.DockStyle.None;
            this.nedTS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.nedTS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.nedTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.editBtn,
            this.deleteBtn});
            this.nedTS.Location = new System.Drawing.Point(9, 530);
            this.nedTS.Name = "nedTS";
            this.nedTS.Size = new System.Drawing.Size(194, 47);
            this.nedTS.TabIndex = 3;
            this.nedTS.Text = "toolStrip1";
            // 
            // newBtn
            // 
            this.newBtn.Image = ((System.Drawing.Image)(resources.GetObject("newBtn.Image")));
            this.newBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(57, 44);
            this.newBtn.Text = "Nuovo";
            this.newBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newBtn_MouseDown);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(72, 44);
            this.editBtn.Text = "Modifica";
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.editBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.editBtn_MouseDown);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(62, 44);
            this.deleteBtn.Text = "Elimina";
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.deleteBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deleteBtn_MouseDown);
            // 
            // catTV
            // 
            this.catTV.Location = new System.Drawing.Point(4, 1);
            this.catTV.Margin = new System.Windows.Forms.Padding(4);
            this.catTV.Name = "catTV";
            this.catTV.ShowNodeToolTips = true;
            this.catTV.Size = new System.Drawing.Size(685, 525);
            this.catTV.TabIndex = 2;
            // 
            // newBtnMS
            // 
            this.newBtnMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.newBtnMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriaToolStripMenuItem,
            this.subcategoryToolStripMenuItem});
            this.newBtnMS.Name = "newBtnMS";
            this.newBtnMS.Size = new System.Drawing.Size(211, 80);
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.categoriaToolStripMenuItem.Text = "Categoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // subcategoryToolStripMenuItem
            // 
            this.subcategoryToolStripMenuItem.Name = "subcategoryToolStripMenuItem";
            this.subcategoryToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.subcategoryToolStripMenuItem.Text = "Sottocategoria di";
            this.subcategoryToolStripMenuItem.Click += new System.EventHandler(this.sottocategoriaToolStripMenuItem_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.Location = new System.Drawing.Point(616, 530);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 52);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 625);
            this.ControlBox = false;
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.nedTS);
            this.Controls.Add(this.catTV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CategoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Categories";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CategoriesForm_FormClosed);
            this.Load += new System.EventHandler(this.Categories_Load);
            this.nedTS.ResumeLayout(false);
            this.nedTS.PerformLayout();
            this.newBtnMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip nedTS;
        private System.Windows.Forms.ToolStripButton newBtn;
        private System.Windows.Forms.ToolStripButton editBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.TreeView catTV;
        private System.Windows.Forms.ContextMenuStrip newBtnMS;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subcategoryToolStripMenuItem;
        private System.Windows.Forms.Button exitBtn;
    }
}