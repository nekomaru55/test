namespace Sample.view.form {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRankResult = new System.Windows.Forms.DataGridView();
            this.bkwTask = new System.ComponentModel.BackgroundWorker();
            this.ColumnRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRankResult);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dgvRankResult
            // 
            this.dgvRankResult.AllowUserToAddRows = false;
            this.dgvRankResult.AllowUserToDeleteRows = false;
            this.dgvRankResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvRankResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRankResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnRank,
            this.ColumnTitle,
            this.ColumnLink});
            resources.ApplyResources(this.dgvRankResult, "dgvRankResult");
            this.dgvRankResult.Name = "dgvRankResult";
            this.dgvRankResult.ReadOnly = true;
            this.dgvRankResult.RowHeadersVisible = false;
            this.dgvRankResult.RowTemplate.Height = 27;
            this.dgvRankResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRankResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRankResult_CellClick);
            // 
            // bkwTask
            // 
            this.bkwTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkwTask_DoWork);
            this.bkwTask.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkwTask_RunWorkerCompleted);
            // 
            // ColumnRank
            // 
            resources.ApplyResources(this.ColumnRank, "ColumnRank");
            this.ColumnRank.Name = "ColumnRank";
            this.ColumnRank.ReadOnly = true;
            this.ColumnRank.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnTitle
            // 
            resources.ApplyResources(this.ColumnTitle, "ColumnTitle");
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            // 
            // ColumnLink
            // 
            this.ColumnLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnLink, "ColumnLink");
            this.ColumnLink.Name = "ColumnLink";
            this.ColumnLink.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRankResult;
        private System.ComponentModel.BackgroundWorker bkwTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnLink;
    }
}