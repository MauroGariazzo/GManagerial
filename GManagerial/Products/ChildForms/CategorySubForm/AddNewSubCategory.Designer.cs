﻿namespace GManagerial.Products.ChildForms
{
    partial class AddNewSubCategory
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.AddSubCategory = new System.Windows.Forms.Label();
            this.subCcategoryTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(257, 55);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Annulla";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(171, 55);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // AddSubCategory
            // 
            this.AddSubCategory.AutoSize = true;
            this.AddSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSubCategory.ForeColor = System.Drawing.SystemColors.Highlight;
            this.AddSubCategory.Location = new System.Drawing.Point(12, 13);
            this.AddSubCategory.Name = "AddSubCategory";
            this.AddSubCategory.Size = new System.Drawing.Size(118, 13);
            this.AddSubCategory.TabIndex = 5;
            this.AddSubCategory.Text = "Aggiungi sottocategoria";
            // 
            // subCcategoryTB
            // 
            this.subCcategoryTB.Location = new System.Drawing.Point(12, 29);
            this.subCcategoryTB.Name = "subCcategoryTB";
            this.subCcategoryTB.Size = new System.Drawing.Size(320, 20);
            this.subCcategoryTB.TabIndex = 4;
            // 
            // AddNewSubCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 91);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.AddSubCategory);
            this.Controls.Add(this.subCcategoryTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddNewSubCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sottocategoria";
            this.Load += new System.EventHandler(this.AddNewSubCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label AddSubCategory;
        private System.Windows.Forms.TextBox subCcategoryTB;
    }
}