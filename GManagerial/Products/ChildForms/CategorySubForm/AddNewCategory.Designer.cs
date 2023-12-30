namespace GManagerial.Products.ChildForms
{
    partial class AddNewCategory
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
            this.categoryTB = new System.Windows.Forms.TextBox();
            this.AddCategoryOrSub = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryTB
            // 
            this.categoryTB.Location = new System.Drawing.Point(12, 29);
            this.categoryTB.Name = "categoryTB";
            this.categoryTB.Size = new System.Drawing.Size(320, 20);
            this.categoryTB.TabIndex = 0;
            // 
            // AddCategoryOrSub
            // 
            this.AddCategoryOrSub.AutoSize = true;
            this.AddCategoryOrSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCategoryOrSub.ForeColor = System.Drawing.SystemColors.Highlight;
            this.AddCategoryOrSub.Location = new System.Drawing.Point(12, 13);
            this.AddCategoryOrSub.Name = "AddCategoryOrSub";
            this.AddCategoryOrSub.Size = new System.Drawing.Size(35, 13);
            this.AddCategoryOrSub.TabIndex = 1;
            this.AddCategoryOrSub.Text = "label1";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(171, 55);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(257, 55);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AddNewCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 91);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.AddCategoryOrSub);
            this.Controls.Add(this.categoryTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNewCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddNewCategory";
            this.Load += new System.EventHandler(this.AddNewCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox categoryTB;
        private System.Windows.Forms.Label AddCategoryOrSub;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}