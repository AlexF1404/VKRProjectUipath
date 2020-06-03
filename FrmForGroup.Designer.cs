namespace VKRProjectUipath
{
    partial class FrmForGroup
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Clmlittle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmGrBig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bnt_SaveInFile = new System.Windows.Forms.Button();
            this.btn_GivOutFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clmlittle,
            this.ClmGrBig});
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(13, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(750, 376);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            // 
            // Clmlittle
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clmlittle.DefaultCellStyle = dataGridViewCellStyle1;
            this.Clmlittle.Frozen = true;
            this.Clmlittle.HeaderText = "Сокращение группы";
            this.Clmlittle.MinimumWidth = 6;
            this.Clmlittle.Name = "Clmlittle";
            this.Clmlittle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Clmlittle.Width = 125;
            // 
            // ClmGrBig
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClmGrBig.DefaultCellStyle = dataGridViewCellStyle2;
            this.ClmGrBig.Frozen = true;
            this.ClmGrBig.HeaderText = "Полное название группы";
            this.ClmGrBig.MinimumWidth = 6;
            this.ClmGrBig.Name = "ClmGrBig";
            this.ClmGrBig.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClmGrBig.Width = 650;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(659, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(547, 412);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(87, 29);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Удалить строку";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Пример:          ит                         Информационные системы и технологии  " +
    "     ";
            // 
            // bnt_SaveInFile
            // 
            this.bnt_SaveInFile.Location = new System.Drawing.Point(12, 412);
            this.bnt_SaveInFile.Name = "bnt_SaveInFile";
            this.bnt_SaveInFile.Size = new System.Drawing.Size(143, 29);
            this.bnt_SaveInFile.TabIndex = 5;
            this.bnt_SaveInFile.Text = "Сохранить в файл";
            this.bnt_SaveInFile.UseVisualStyleBackColor = true;
            this.bnt_SaveInFile.Click += new System.EventHandler(this.Bnt_SaveInFile_Click);
            // 
            // btn_GivOutFile
            // 
            this.btn_GivOutFile.Location = new System.Drawing.Point(161, 412);
            this.btn_GivOutFile.Name = "btn_GivOutFile";
            this.btn_GivOutFile.Size = new System.Drawing.Size(190, 29);
            this.btn_GivOutFile.TabIndex = 6;
            this.btn_GivOutFile.Text = "Загрузить из файла";
            this.btn_GivOutFile.UseVisualStyleBackColor = true;
            this.btn_GivOutFile.Click += new System.EventHandler(this.Btn_GivOutFile_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Алексей\\Desktop";
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataSource = typeof(VKRProjectUipath.Settings);
            // 
            // FrmForGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(772, 448);
            this.Controls.Add(this.btn_GivOutFile);
            this.Controls.Add(this.bnt_SaveInFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmForGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление и изменение сокращений групп";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmForGroup_Closing);
            this.Load += new System.EventHandler(this.FrmForGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clmlittle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmGrBig;
        private System.Windows.Forms.Button bnt_SaveInFile;
        private System.Windows.Forms.Button btn_GivOutFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}