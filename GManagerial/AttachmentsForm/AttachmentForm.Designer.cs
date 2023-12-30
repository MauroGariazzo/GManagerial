namespace GManagerial
{
    partial class AttachmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttachmentForm));
            this.attachmentsPnl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.fileListView = new System.Windows.Forms.ListView();
            this.FileUpload = new System.Windows.Forms.Button();
            this.FileDelete = new System.Windows.Forms.Button();
            this.FileOpen = new System.Windows.Forms.Button();
            this.attachmentsPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // attachmentsPnl
            // 
            this.attachmentsPnl.AllowDrop = true;
            this.attachmentsPnl.Controls.Add(this.pictureBox1);
            this.attachmentsPnl.Controls.Add(this.label);
            this.attachmentsPnl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.attachmentsPnl.Location = new System.Drawing.Point(264, 329);
            this.attachmentsPnl.Margin = new System.Windows.Forms.Padding(4);
            this.attachmentsPnl.Name = "attachmentsPnl";
            this.attachmentsPnl.Size = new System.Drawing.Size(532, 71);
            this.attachmentsPnl.TabIndex = 0;
            this.attachmentsPnl.DragDrop += new System.Windows.Forms.DragEventHandler(this.attachmentsPnl_DragDrop);
            this.attachmentsPnl.DragEnter += new System.Windows.Forms.DragEventHandler(this.attachmentsPnl_DragEnter);
            this.attachmentsPnl.DragOver += new System.Windows.Forms.DragEventHandler(this.attachmentsPnl_DragOver);
            this.attachmentsPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.attachmentsPnl_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(123, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 38);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(163, 30);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(178, 16);
            this.label.TabIndex = 0;
            this.label.Text = "Trascina qui i file da caricare";
            // 
            // fileListView
            // 
            this.fileListView.AllowDrop = true;
            this.fileListView.HideSelection = false;
            this.fileListView.Location = new System.Drawing.Point(4, 4);
            this.fileListView.Margin = new System.Windows.Forms.Padding(4);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(1059, 281);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            // 
            // FileUpload
            // 
            this.FileUpload.Location = new System.Drawing.Point(863, 329);
            this.FileUpload.Name = "FileUpload";
            this.FileUpload.Size = new System.Drawing.Size(75, 23);
            this.FileUpload.TabIndex = 1;
            this.FileUpload.Text = "Carica";
            this.FileUpload.UseVisualStyleBackColor = true;
            this.FileUpload.Click += new System.EventHandler(this.FileUpload_Click);
            // 
            // FileDelete
            // 
            this.FileDelete.Location = new System.Drawing.Point(863, 377);
            this.FileDelete.Name = "FileDelete";
            this.FileDelete.Size = new System.Drawing.Size(75, 23);
            this.FileDelete.TabIndex = 2;
            this.FileDelete.Text = "Elimina";
            this.FileDelete.UseVisualStyleBackColor = true;
            this.FileDelete.Click += new System.EventHandler(this.FileDelete_Click);
            // 
            // FileOpen
            // 
            this.FileOpen.Location = new System.Drawing.Point(53, 352);
            this.FileOpen.Name = "FileOpen";
            this.FileOpen.Size = new System.Drawing.Size(90, 36);
            this.FileOpen.TabIndex = 3;
            this.FileOpen.Text = "Anteprima";
            this.FileOpen.UseVisualStyleBackColor = true;
            this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
            // 
            // AttachmentForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.FileOpen);
            this.Controls.Add(this.FileDelete);
            this.Controls.Add(this.FileUpload);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.attachmentsPnl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttachmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Allegati";
            this.Load += new System.EventHandler(this.AttachmentForm_Load);
            this.attachmentsPnl.ResumeLayout(false);
            this.attachmentsPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel attachmentsPnl;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button FileUpload;
        private System.Windows.Forms.Button FileDelete;
        private System.Windows.Forms.Button FileOpen;
        public System.Windows.Forms.ListView fileListView;
    }
}