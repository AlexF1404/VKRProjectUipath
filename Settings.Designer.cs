namespace VKRProjectUipath
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnExit = new System.Windows.Forms.Button();
            this.grBxForExcel = new System.Windows.Forms.GroupBox();
            this.btnChoosePathFolder = new System.Windows.Forms.Button();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtPathFolder = new MetroFramework.Controls.MetroTextBox();
            this.btnOpenAddAndEdit = new System.Windows.Forms.Button();
            this.BtnUipathSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnChoosePath = new System.Windows.Forms.Button();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.grBxForExcel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.BtnExit.Location = new System.Drawing.Point(490, 299);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(97, 31);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Ок";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // grBxForExcel
            // 
            this.grBxForExcel.Controls.Add(this.btnChoosePathFolder);
            this.grBxForExcel.Controls.Add(this.metroLabel1);
            this.grBxForExcel.Controls.Add(this.txtPathFolder);
            this.grBxForExcel.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.grBxForExcel.Location = new System.Drawing.Point(11, 63);
            this.grBxForExcel.Name = "grBxForExcel";
            this.grBxForExcel.Size = new System.Drawing.Size(576, 105);
            this.grBxForExcel.TabIndex = 4;
            this.grBxForExcel.TabStop = false;
            this.grBxForExcel.Text = "Настройки учебных планов";
            // 
            // btnChoosePathFolder
            // 
            this.btnChoosePathFolder.BackColor = System.Drawing.Color.White;
            this.btnChoosePathFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoosePathFolder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChoosePathFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoosePathFolder.Font = new System.Drawing.Font("Akrobat Bold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoosePathFolder.Location = new System.Drawing.Point(268, 53);
            this.btnChoosePathFolder.Name = "btnChoosePathFolder";
            this.btnChoosePathFolder.Size = new System.Drawing.Size(101, 31);
            this.btnChoosePathFolder.TabIndex = 10;
            this.btnChoosePathFolder.Text = "Выбрать путь";
            this.btnChoosePathFolder.UseVisualStyleBackColor = false;
            this.btnChoosePathFolder.Click += new System.EventHandler(this.BtnChoosePathFolder_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(7, 30);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(181, 20);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Путь к директории планов";
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPathFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPathFolder.Location = new System.Drawing.Point(9, 53);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.ReadOnly = true;
            this.txtPathFolder.Size = new System.Drawing.Size(253, 31);
            this.txtPathFolder.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPathFolder.TabIndex = 7;
            this.txtPathFolder.UseStyleColors = true;
            // 
            // btnOpenAddAndEdit
            // 
            this.btnOpenAddAndEdit.BackColor = System.Drawing.Color.White;
            this.btnOpenAddAndEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenAddAndEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOpenAddAndEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAddAndEdit.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenAddAndEdit.Location = new System.Drawing.Point(11, 265);
            this.btnOpenAddAndEdit.Name = "btnOpenAddAndEdit";
            this.btnOpenAddAndEdit.Size = new System.Drawing.Size(331, 28);
            this.btnOpenAddAndEdit.TabIndex = 5;
            this.btnOpenAddAndEdit.Text = "Добавить или изменить сокращения групп";
            this.btnOpenAddAndEdit.UseVisualStyleBackColor = false;
            this.btnOpenAddAndEdit.Click += new System.EventHandler(this.BtnOpenAddAndEdit_Click);
            // 
            // BtnUipathSettings
            // 
            this.BtnUipathSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUipathSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnUipathSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUipathSettings.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.BtnUipathSettings.Location = new System.Drawing.Point(11, 299);
            this.BtnUipathSettings.Name = "BtnUipathSettings";
            this.BtnUipathSettings.Size = new System.Drawing.Size(174, 31);
            this.BtnUipathSettings.TabIndex = 5;
            this.BtnUipathSettings.Text = "Подключение UiPath";
            this.BtnUipathSettings.UseVisualStyleBackColor = true;
            this.BtnUipathSettings.Click += new System.EventHandler(this.BtnUipathSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnChoosePath);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(11, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь к UiPath (по умолчанию C:\\Program Files (x86)\\UiPath\\Studio)";
            // 
            // BtnChoosePath
            // 
            this.BtnChoosePath.BackColor = System.Drawing.Color.White;
            this.BtnChoosePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnChoosePath.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnChoosePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChoosePath.Font = new System.Drawing.Font("Akrobat Bold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChoosePath.Location = new System.Drawing.Point(268, 37);
            this.BtnChoosePath.Name = "BtnChoosePath";
            this.BtnChoosePath.Size = new System.Drawing.Size(101, 31);
            this.BtnChoosePath.TabIndex = 12;
            this.BtnChoosePath.Text = "Выбрать путь";
            this.BtnChoosePath.UseVisualStyleBackColor = false;
            this.BtnChoosePath.Click += new System.EventHandler(this.BtnChoosePath_Click);
            // 
            // textBox1
            // 
            this.textBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(9, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(253, 31);
            this.textBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "C:\\Program Files (x86)\\UiPath\\Studio";
            this.textBox1.UseStyleColors = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 342);
            this.Controls.Add(this.btnOpenAddAndEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnUipathSettings);
            this.Controls.Add(this.grBxForExcel);
            this.Controls.Add(this.BtnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.grBxForExcel.ResumeLayout(false);
            this.grBxForExcel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.GroupBox grBxForExcel;
        private System.Windows.Forms.Button btnOpenAddAndEdit;
        private System.Windows.Forms.Button BtnUipathSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private MetroFramework.Controls.MetroTextBox txtPathFolder;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private System.Windows.Forms.Button btnChoosePathFolder;
        private System.Windows.Forms.Button BtnChoosePath;
    }
}