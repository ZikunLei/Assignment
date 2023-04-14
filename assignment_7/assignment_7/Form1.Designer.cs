namespace assignment_7
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.startBtn = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.startBtn);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 0;
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.URL});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvResult.Location = new System.Drawing.Point(0, 106);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 33;
            this.dgvResult.Size = new System.Drawing.Size(800, 344);
            this.dgvResult.TabIndex = 1;
            this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(355, 39);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(100, 31);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(34, 39);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(259, 31);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.TextChanged += new System.EventHandler(this.urlText_TextChanged);
            // 
            // Index
            // 
            this.Index.HeaderText = "序号";
            this.Index.Name = "Index";
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(575, 44);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 21);
            this.lblInfo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "爬虫";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.Label lblInfo;
    }
}