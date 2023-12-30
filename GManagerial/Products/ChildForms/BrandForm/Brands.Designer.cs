namespace GManagerial.Products.ChildForms
{
    partial class Brands
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Brands));
            this.brandList = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // brandList
            // 
            this.brandList.FormattingEnabled = true;
            this.brandList.Location = new System.Drawing.Point(12, 12);
            this.brandList.Name = "brandList";
            this.brandList.Size = new System.Drawing.Size(317, 394);
            this.brandList.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addBtn.Location = new System.Drawing.Point(330, 12);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(58, 40);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Aggiungi";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.editBtn.FlatAppearance.BorderSize = 0;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.editBtn.Location = new System.Drawing.Point(330, 58);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(58, 40);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Modifica";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteBtn.Location = new System.Drawing.Point(330, 104);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(58, 40);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Cancella";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitBtn.Location = new System.Drawing.Point(330, 353);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(58, 53);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Esci";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Brands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 415);
            this.ControlBox = false;
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.brandList);
            this.Name = "Brands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Brands";
            this.Load += new System.EventHandler(this.Brands_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox brandList;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}