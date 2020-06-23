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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmForGroup));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.bnt_SaveInFile = new System.Windows.Forms.Button();
            this.btn_GivOutFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Clmlittle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmGrBig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clmlittle,
            this.ClmGrBig});
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(15, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(750, 376);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(664, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.White;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDel.Location = new System.Drawing.Point(550, 492);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(87, 29);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Удалить строку";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // bnt_SaveInFile
            // 
            this.bnt_SaveInFile.BackColor = System.Drawing.Color.White;
            this.bnt_SaveInFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnt_SaveInFile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bnt_SaveInFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnt_SaveInFile.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.bnt_SaveInFile.Location = new System.Drawing.Point(15, 492);
            this.bnt_SaveInFile.Name = "bnt_SaveInFile";
            this.bnt_SaveInFile.Size = new System.Drawing.Size(143, 29);
            this.bnt_SaveInFile.TabIndex = 5;
            this.bnt_SaveInFile.Text = "Сохранить в файл";
            this.bnt_SaveInFile.UseVisualStyleBackColor = false;
            this.bnt_SaveInFile.Click += new System.EventHandler(this.Bnt_SaveInFile_Click);
            // 
            // btn_GivOutFile
            // 
            this.btn_GivOutFile.BackColor = System.Drawing.Color.White;
            this.btn_GivOutFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GivOutFile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_GivOutFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GivOutFile.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.btn_GivOutFile.Location = new System.Drawing.Point(175, 492);
            this.btn_GivOutFile.Name = "btn_GivOutFile";
            this.btn_GivOutFile.Size = new System.Drawing.Size(190, 29);
            this.btn_GivOutFile.TabIndex = 6;
            this.btn_GivOutFile.Text = "Загрузить из файла";
            this.btn_GivOutFile.UseVisualStyleBackColor = false;
            this.btn_GivOutFile.Click += new System.EventHandler(this.Btn_GivOutFile_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Алексей\\Desktop";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(15, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(489, 40);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Пример:                       \r\n          ИТ                               Информ" +
    "ационные системы и технологии       ";
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataSource = typeof(VKRProjectUipath.Settings);
            // 
            // Clmlittle
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Clmlittle.DefaultCellStyle = dataGridViewCellStyle2;
            this.Clmlittle.Frozen = true;
            this.Clmlittle.HeaderText = "Сокращение группы";
            this.Clmlittle.MinimumWidth = 6;
            this.Clmlittle.Name = "Clmlittle";
            this.Clmlittle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Clmlittle.Width = 125;
            // 
            // ClmGrBig
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.ClmGrBig.DefaultCellStyle = dataGridViewCellStyle3;
            this.ClmGrBig.Frozen = true;
            this.ClmGrBig.HeaderText = "Полное название группы";
            this.ClmGrBig.MinimumWidth = 6;
            this.ClmGrBig.Name = "ClmGrBig";
            this.ClmGrBig.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClmGrBig.Width = 650;
            // 
            // FrmForGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(775, 530);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btn_GivOutFile);
            this.Controls.Add(this.bnt_SaveInFile);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmForGroup";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
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
        private System.Windows.Forms.Button bnt_SaveInFile;
        private System.Windows.Forms.Button btn_GivOutFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clmlittle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmGrBig;
    }
}