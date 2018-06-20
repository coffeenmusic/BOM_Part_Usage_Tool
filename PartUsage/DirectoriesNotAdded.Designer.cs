namespace PartUsage
{
    partial class DirectoriesNotAdded
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
            this.lbNotAdded = new System.Windows.Forms.ListBox();
            this.btnCloseDirNotAdded = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNotAdded
            // 
            this.lbNotAdded.FormattingEnabled = true;
            this.lbNotAdded.Location = new System.Drawing.Point(12, 12);
            this.lbNotAdded.Name = "lbNotAdded";
            this.lbNotAdded.Size = new System.Drawing.Size(600, 212);
            this.lbNotAdded.TabIndex = 0;
            // 
            // btnCloseDirNotAdded
            // 
            this.btnCloseDirNotAdded.Location = new System.Drawing.Point(537, 230);
            this.btnCloseDirNotAdded.Name = "btnCloseDirNotAdded";
            this.btnCloseDirNotAdded.Size = new System.Drawing.Size(75, 23);
            this.btnCloseDirNotAdded.TabIndex = 1;
            this.btnCloseDirNotAdded.Text = "Close";
            this.btnCloseDirNotAdded.UseVisualStyleBackColor = true;
            this.btnCloseDirNotAdded.Click += new System.EventHandler(this.btnCloseDirNotAdded_Click);
            // 
            // DirectoriesNotAdded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 262);
            this.Controls.Add(this.btnCloseDirNotAdded);
            this.Controls.Add(this.lbNotAdded);
            this.Name = "DirectoriesNotAdded";
            this.Text = "DirectoriesNotAdded";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbNotAdded;
        private System.Windows.Forms.Button btnCloseDirNotAdded;
    }
}