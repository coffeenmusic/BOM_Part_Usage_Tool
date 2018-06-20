namespace PartUsage
{
    partial class BOM_Directories
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
            this.lbDirectories = new System.Windows.Forms.ListBox();
            this.btnCloseBOMDir = new System.Windows.Forms.Button();
            this.chkShowFullPath = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbDirectories
            // 
            this.lbDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDirectories.FormattingEnabled = true;
            this.lbDirectories.Location = new System.Drawing.Point(12, 12);
            this.lbDirectories.Name = "lbDirectories";
            this.lbDirectories.Size = new System.Drawing.Size(745, 394);
            this.lbDirectories.TabIndex = 5;
            // 
            // btnCloseBOMDir
            // 
            this.btnCloseBOMDir.Location = new System.Drawing.Point(682, 419);
            this.btnCloseBOMDir.Name = "btnCloseBOMDir";
            this.btnCloseBOMDir.Size = new System.Drawing.Size(75, 23);
            this.btnCloseBOMDir.TabIndex = 6;
            this.btnCloseBOMDir.Text = "Close";
            this.btnCloseBOMDir.UseVisualStyleBackColor = true;
            this.btnCloseBOMDir.Click += new System.EventHandler(this.btnCloseBOMDir_Click);
            // 
            // chkShowFullPath
            // 
            this.chkShowFullPath.AutoSize = true;
            this.chkShowFullPath.Location = new System.Drawing.Point(12, 412);
            this.chkShowFullPath.Name = "chkShowFullPath";
            this.chkShowFullPath.Size = new System.Drawing.Size(97, 17);
            this.chkShowFullPath.TabIndex = 7;
            this.chkShowFullPath.Text = "Show Full Path";
            this.chkShowFullPath.UseVisualStyleBackColor = true;
            this.chkShowFullPath.CheckedChanged += new System.EventHandler(this.chkShowFullPath_CheckedChanged);
            // 
            // BOM_Directories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 454);
            this.Controls.Add(this.chkShowFullPath);
            this.Controls.Add(this.btnCloseBOMDir);
            this.Controls.Add(this.lbDirectories);
            this.Name = "BOM_Directories";
            this.Text = "BOM_Directories";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDirectories;
        private System.Windows.Forms.Button btnCloseBOMDir;
        private System.Windows.Forms.CheckBox chkShowFullPath;
    }
}