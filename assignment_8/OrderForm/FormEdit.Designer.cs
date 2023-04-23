namespace OrderForm
{
    partial class FormEdit
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TextO = new System.Windows.Forms.TextBox();
            this.CombC = new System.Windows.Forms.ComboBox();
            this.SaveBnt = new System.Windows.Forms.Button();
            this.DeleteBnt = new System.Windows.Forms.Button();
            this.ChangeBnt = new System.Windows.Forms.Button();
            this.AddBnt = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.5F));
            this.tableLayoutPanel1.Controls.Add(this.TextO, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.CombC, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.85714F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(800, 299);
            this.dataGridView1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.AddBnt);
            this.flowLayoutPanel1.Controls.Add(this.ChangeBnt);
            this.flowLayoutPanel1.Controls.Add(this.DeleteBnt);
            this.flowLayoutPanel1.Controls.Add(this.SaveBnt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 381);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 69);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // TextO
            // 
            this.TextO.Location = new System.Drawing.Point(191, 35);
            this.TextO.Name = "TextO";
            this.TextO.Size = new System.Drawing.Size(175, 31);
            this.TextO.TabIndex = 2;
            // 
            // CombC
            // 
            this.CombC.FormattingEnabled = true;
            this.CombC.Location = new System.Drawing.Point(191, 3);
            this.CombC.Name = "CombC";
            this.CombC.Size = new System.Drawing.Size(175, 29);
            this.CombC.TabIndex = 3;
            // 
            // SaveBnt
            // 
            this.SaveBnt.Location = new System.Drawing.Point(388, 3);
            this.SaveBnt.Name = "SaveBnt";
            this.SaveBnt.Size = new System.Drawing.Size(142, 41);
            this.SaveBnt.TabIndex = 4;
            this.SaveBnt.Text = "保存订单";
            this.SaveBnt.UseVisualStyleBackColor = true;
            // 
            // DeleteBnt
            // 
            this.DeleteBnt.Location = new System.Drawing.Point(258, 3);
            this.DeleteBnt.Name = "DeleteBnt";
            this.DeleteBnt.Size = new System.Drawing.Size(124, 41);
            this.DeleteBnt.TabIndex = 5;
            this.DeleteBnt.Text = "删除明细";
            this.DeleteBnt.UseVisualStyleBackColor = true;
            // 
            // ChangeBnt
            // 
            this.ChangeBnt.Location = new System.Drawing.Point(133, 3);
            this.ChangeBnt.Name = "ChangeBnt";
            this.ChangeBnt.Size = new System.Drawing.Size(119, 41);
            this.ChangeBnt.TabIndex = 6;
            this.ChangeBnt.Text = "修改明细";
            this.ChangeBnt.UseVisualStyleBackColor = true;
            // 
            // AddBnt
            // 
            this.AddBnt.Location = new System.Drawing.Point(3, 3);
            this.AddBnt.Name = "AddBnt";
            this.AddBnt.Size = new System.Drawing.Size(124, 41);
            this.AddBnt.TabIndex = 7;
            this.AddBnt.Text = "添加明细";
            this.AddBnt.UseVisualStyleBackColor = true;
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormEdit";
            this.Text = "FormEdit";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TextO;
        private System.Windows.Forms.ComboBox CombC;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddBnt;
        private System.Windows.Forms.Button ChangeBnt;
        private System.Windows.Forms.Button DeleteBnt;
        private System.Windows.Forms.Button SaveBnt;
    }
}