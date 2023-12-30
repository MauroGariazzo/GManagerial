namespace GManagerial.HomeForm
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.bar = new System.Windows.Forms.Panel();
            this.MenuName = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bar.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bar.Controls.Add(this.searchBtn);
            this.bar.Controls.Add(this.MenuName);
            this.bar.Controls.Add(this.button1);
            this.bar.Controls.Add(this.searchBox);
            this.bar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bar.Location = new System.Drawing.Point(0, 0);
            this.bar.Margin = new System.Windows.Forms.Padding(4);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(1189, 22);
            this.bar.TabIndex = 12;
            // 
            // MenuName
            // 
            this.MenuName.AutoSize = true;
            this.MenuName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MenuName.Location = new System.Drawing.Point(19, 1);
            this.MenuName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MenuName.Name = "MenuName";
            this.MenuName.Size = new System.Drawing.Size(56, 21);
            this.MenuName.TabIndex = 0;
            this.MenuName.Text = "Home";
            // 
            // searchBox
            // 
            this.searchBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchBox.Location = new System.Drawing.Point(988, 0);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(198, 22);
            this.searchBox.TabIndex = 1;
            this.searchBox.Text = "Cerca";
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBtn.BackgroundImage")));
            this.searchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchBtn.Location = new System.Drawing.Point(921, -1);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(38, 23);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(953, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 22);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 522);
            this.ControlBox = false;
            this.Controls.Add(this.bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.bar.ResumeLayout(false);
            this.bar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label MenuName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchBox;
    }
}