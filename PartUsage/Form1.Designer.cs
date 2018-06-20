namespace PartUsage
{
    partial class Form1
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dgvPartUsage = new System.Windows.Forms.DataGridView();
            this.txtSearchParts = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewDirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOMDirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceDriveLetterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerSearchDirectories = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerAddParts = new System.ComponentModel.BackgroundWorker();
            this.directoriesNotAddedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartUsage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPartUsage
            // 
            this.dgvPartUsage.AllowUserToAddRows = false;
            this.dgvPartUsage.AllowUserToDeleteRows = false;
            this.dgvPartUsage.AllowUserToResizeRows = false;
            this.dgvPartUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartUsage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPartUsage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartUsage.Location = new System.Drawing.Point(12, 53);
            this.dgvPartUsage.MultiSelect = false;
            this.dgvPartUsage.Name = "dgvPartUsage";
            this.dgvPartUsage.ReadOnly = true;
            this.dgvPartUsage.RowHeadersVisible = false;
            this.dgvPartUsage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartUsage.Size = new System.Drawing.Size(911, 428);
            this.dgvPartUsage.TabIndex = 7;
            this.dgvPartUsage.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPartUsage_CellMouseDoubleClick);
            // 
            // txtSearchParts
            // 
            this.txtSearchParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchParts.Location = new System.Drawing.Point(12, 27);
            this.txtSearchParts.Name = "txtSearchParts";
            this.txtSearchParts.Size = new System.Drawing.Size(911, 20);
            this.txtSearchParts.TabIndex = 8;
            this.txtSearchParts.TextChanged += new System.EventHandler(this.txtSearchParts_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(935, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDatabaseToolStripMenuItem,
            this.addNewDirectoriesToolStripMenuItem,
            this.addNewPartsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearDatabaseToolStripMenuItem
            // 
            this.clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
            this.clearDatabaseToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.clearDatabaseToolStripMenuItem.Text = "Clear Database";
            this.clearDatabaseToolStripMenuItem.Click += new System.EventHandler(this.clearDatabaseToolStripMenuItem_Click);
            // 
            // addNewDirectoriesToolStripMenuItem
            // 
            this.addNewDirectoriesToolStripMenuItem.Name = "addNewDirectoriesToolStripMenuItem";
            this.addNewDirectoriesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addNewDirectoriesToolStripMenuItem.Text = "Add New Directories";
            this.addNewDirectoriesToolStripMenuItem.Click += new System.EventHandler(this.addNewDirectoriesToolStripMenuItem_Click);
            // 
            // addNewPartsToolStripMenuItem
            // 
            this.addNewPartsToolStripMenuItem.Name = "addNewPartsToolStripMenuItem";
            this.addNewPartsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addNewPartsToolStripMenuItem.Text = "Add New Parts";
            this.addNewPartsToolStripMenuItem.Click += new System.EventHandler(this.addNewPartsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOMDirectoriesToolStripMenuItem,
            this.directoriesNotAddedToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // bOMDirectoriesToolStripMenuItem
            // 
            this.bOMDirectoriesToolStripMenuItem.Name = "bOMDirectoriesToolStripMenuItem";
            this.bOMDirectoriesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.bOMDirectoriesToolStripMenuItem.Text = "BOM Directories";
            this.bOMDirectoriesToolStripMenuItem.Click += new System.EventHandler(this.bOMDirectoriesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceDriveLetterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // replaceDriveLetterToolStripMenuItem
            // 
            this.replaceDriveLetterToolStripMenuItem.Name = "replaceDriveLetterToolStripMenuItem";
            this.replaceDriveLetterToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.replaceDriveLetterToolStripMenuItem.Text = "Replace Drive Letter";
            this.replaceDriveLetterToolStripMenuItem.Click += new System.EventHandler(this.replaceDriveLetterToolStripMenuItem_Click);
            // 
            // pbMain
            // 
            this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMain.Location = new System.Drawing.Point(12, 487);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(911, 23);
            this.pbMain.TabIndex = 12;
            // 
            // backgroundWorkerSearchDirectories
            // 
            this.backgroundWorkerSearchDirectories.WorkerReportsProgress = true;
            this.backgroundWorkerSearchDirectories.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSearchDirectories_DoWork);
            this.backgroundWorkerSearchDirectories.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSearchDirectories_ProgressChanged);
            this.backgroundWorkerSearchDirectories.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearchDirectories_RunWorkerCompleted);
            // 
            // backgroundWorkerAddParts
            // 
            this.backgroundWorkerAddParts.WorkerReportsProgress = true;
            this.backgroundWorkerAddParts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAddParts_DoWork);
            this.backgroundWorkerAddParts.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerAddParts_ProgressChanged);
            this.backgroundWorkerAddParts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAddParts_RunWorkerCompleted);
            // 
            // directoriesNotAddedToolStripMenuItem
            // 
            this.directoriesNotAddedToolStripMenuItem.Name = "directoriesNotAddedToolStripMenuItem";
            this.directoriesNotAddedToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.directoriesNotAddedToolStripMenuItem.Text = "Directories Not Added";
            this.directoriesNotAddedToolStripMenuItem.Click += new System.EventHandler(this.directoriesNotAddedToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 522);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.txtSearchParts);
            this.Controls.Add(this.dgvPartUsage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Part Usage Parser";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartUsage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dgvPartUsage;
        private System.Windows.Forms.TextBox txtSearchParts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceDriveLetterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bOMDirectoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewDirectoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPartsToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pbMain;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearchDirectories;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddParts;
        private System.Windows.Forms.ToolStripMenuItem directoriesNotAddedToolStripMenuItem;
    }
}

