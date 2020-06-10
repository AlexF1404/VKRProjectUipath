namespace VKRProjectUipath
{
    partial class WordVkrForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnloadDoc = new System.Windows.Forms.Button();
            this.CheckVkr = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VkrTheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vkrmanager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIO,
            this.Group,
            this.VkrTheme,
            this.Vkrmanager});
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1104, 531);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnloadDoc
            // 
            this.btnloadDoc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnloadDoc.Location = new System.Drawing.Point(16, 20);
            this.btnloadDoc.Name = "btnloadDoc";
            this.btnloadDoc.Size = new System.Drawing.Size(250, 28);
            this.btnloadDoc.TabIndex = 1;
            this.btnloadDoc.Text = "Загрузить список из приказа";
            this.btnloadDoc.UseVisualStyleBackColor = true;
            this.btnloadDoc.Click += new System.EventHandler(this.btnloadDoc_Click);
            // 
            // CheckVkr
            // 
            this.CheckVkr.Location = new System.Drawing.Point(293, 20);
            this.CheckVkr.Name = "CheckVkr";
            this.CheckVkr.Size = new System.Drawing.Size(289, 28);
            this.CheckVkr.TabIndex = 2;
            this.CheckVkr.Text = "Проверка ВКР на соответствие приказу\r\n";
            this.CheckVkr.UseVisualStyleBackColor = true;
            this.CheckVkr.Click += new System.EventHandler(this.CheckVkr_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FIO
            // 
            this.FIO.Frozen = true;
            this.FIO.HeaderText = "Ф.И.О.";
            this.FIO.MinimumWidth = 6;
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Width = 125;
            // 
            // Group
            // 
            this.Group.Frozen = true;
            this.Group.HeaderText = "Учебная группа";
            this.Group.MinimumWidth = 6;
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            this.Group.Width = 125;
            // 
            // VkrTheme
            // 
            this.VkrTheme.Frozen = true;
            this.VkrTheme.HeaderText = "Тема";
            this.VkrTheme.MinimumWidth = 6;
            this.VkrTheme.Name = "VkrTheme";
            this.VkrTheme.ReadOnly = true;
            this.VkrTheme.Width = 125;
            // 
            // Vkrmanager
            // 
            this.Vkrmanager.Frozen = true;
            this.Vkrmanager.HeaderText = "Руководитель";
            this.Vkrmanager.MinimumWidth = 6;
            this.Vkrmanager.Name = "Vkrmanager";
            this.Vkrmanager.ReadOnly = true;
            this.Vkrmanager.Width = 125;
            // 
            // WordVkrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 610);
            this.Controls.Add(this.CheckVkr);
            this.Controls.Add(this.btnloadDoc);
            this.Controls.Add(this.dataGridView1);
            this.Name = "WordVkrForm";
            this.Text = "Работа с ВКР";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnloadDoc;
        private System.Windows.Forms.Button CheckVkr;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn VkrTheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vkrmanager;
    }
}