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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordVkrForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VkrTheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vkrmanager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnloadDoc = new System.Windows.Forms.Button();
            this.CheckVkr = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.FIO,
            this.Group,
            this.VkrTheme,
            this.Vkrmanager});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(6, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Akrobat ExtraBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(986, 567);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // number
            // 
            this.number.Frozen = true;
            this.number.HeaderText = "№";
            this.number.MinimumWidth = 30;
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 30;
            // 
            // FIO
            // 
            this.FIO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FIO.Frozen = true;
            this.FIO.HeaderText = "Ф.И.О.";
            this.FIO.MinimumWidth = 226;
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            this.FIO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FIO.Width = 226;
            // 
            // Group
            // 
            this.Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Group.Frozen = true;
            this.Group.HeaderText = "Учебная группа";
            this.Group.MinimumWidth = 113;
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            this.Group.Width = 126;
            // 
            // VkrTheme
            // 
            this.VkrTheme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VkrTheme.Frozen = true;
            this.VkrTheme.HeaderText = "Тема";
            this.VkrTheme.MinimumWidth = 435;
            this.VkrTheme.Name = "VkrTheme";
            this.VkrTheme.ReadOnly = true;
            this.VkrTheme.Width = 435;
            // 
            // Vkrmanager
            // 
            this.Vkrmanager.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Vkrmanager.Frozen = true;
            this.Vkrmanager.HeaderText = "Руководитель";
            this.Vkrmanager.MinimumWidth = 179;
            this.Vkrmanager.Name = "Vkrmanager";
            this.Vkrmanager.ReadOnly = true;
            this.Vkrmanager.Width = 179;
            // 
            // btnloadDoc
            // 
            this.btnloadDoc.BackColor = System.Drawing.Color.White;
            this.btnloadDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnloadDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnloadDoc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnloadDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadDoc.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.btnloadDoc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnloadDoc.Location = new System.Drawing.Point(6, 63);
            this.btnloadDoc.Name = "btnloadDoc";
            this.btnloadDoc.Size = new System.Drawing.Size(250, 28);
            this.btnloadDoc.TabIndex = 1;
            this.btnloadDoc.Text = "Загрузить список из приказа";
            this.btnloadDoc.UseVisualStyleBackColor = false;
            this.btnloadDoc.Click += new System.EventHandler(this.btnloadDoc_Click);
            // 
            // CheckVkr
            // 
            this.CheckVkr.BackColor = System.Drawing.Color.White;
            this.CheckVkr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckVkr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CheckVkr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckVkr.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.CheckVkr.Location = new System.Drawing.Point(742, 62);
            this.CheckVkr.Name = "CheckVkr";
            this.CheckVkr.Size = new System.Drawing.Size(250, 28);
            this.CheckVkr.TabIndex = 2;
            this.CheckVkr.Text = "Проверка ВКР";
            this.CheckVkr.UseVisualStyleBackColor = false;
            this.CheckVkr.Click += new System.EventHandler(this.CheckVkr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Akrobat ExtraBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 46);
            this.label1.TabIndex = 3;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Multiselect = true;
            // 
            // WordVkrForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(998, 674);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckVkr);
            this.Controls.Add(this.btnloadDoc);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WordVkrForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Работа с ВКР";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnloadDoc;
        private System.Windows.Forms.Button CheckVkr;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn VkrTheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vkrmanager;
    }
}