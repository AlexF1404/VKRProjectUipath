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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChoosePathFolder = new System.Windows.Forms.Button();
            this.txtPathFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.grBxForExcel = new System.Windows.Forms.GroupBox();
            this.btnOpenAddAndEdit = new System.Windows.Forms.Button();
            this.BtnUipathSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnChoosePath = new System.Windows.Forms.Button();
            this.grBxForExcel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChoosePathFolder
            // 
            this.btnChoosePathFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnChoosePathFolder.Location = new System.Drawing.Point(270, 53);
            this.btnChoosePathFolder.Name = "btnChoosePathFolder";
            this.btnChoosePathFolder.Size = new System.Drawing.Size(118, 27);
            this.btnChoosePathFolder.TabIndex = 0;
            this.btnChoosePathFolder.Text = "Выбрать путь";
            this.btnChoosePathFolder.UseVisualStyleBackColor = true;
            this.btnChoosePathFolder.Click += new System.EventHandler(this.BtnChoosePathFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtPathFolder.Location = new System.Drawing.Point(9, 54);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.ReadOnly = true;
            this.txtPathFolder.Size = new System.Drawing.Size(255, 24);
            this.txtPathFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к директории планов";
            // 
            // BtnExit
            // 
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExit.Location = new System.Drawing.Point(491, 271);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(97, 31);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Ok";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // grBxForExcel
            // 
            this.grBxForExcel.Controls.Add(this.label1);
            this.grBxForExcel.Controls.Add(this.txtPathFolder);
            this.grBxForExcel.Controls.Add(this.btnChoosePathFolder);
            this.grBxForExcel.Location = new System.Drawing.Point(12, 12);
            this.grBxForExcel.Name = "grBxForExcel";
            this.grBxForExcel.Size = new System.Drawing.Size(576, 105);
            this.grBxForExcel.TabIndex = 4;
            this.grBxForExcel.TabStop = false;
            this.grBxForExcel.Text = "Настройки учебных планов";
            // 
            // btnOpenAddAndEdit
            // 
            this.btnOpenAddAndEdit.Location = new System.Drawing.Point(12, 227);
            this.btnOpenAddAndEdit.Name = "btnOpenAddAndEdit";
            this.btnOpenAddAndEdit.Size = new System.Drawing.Size(331, 28);
            this.btnOpenAddAndEdit.TabIndex = 5;
            this.btnOpenAddAndEdit.Text = "Добавить или изменить сокращения групп";
            this.btnOpenAddAndEdit.UseVisualStyleBackColor = true;
            this.btnOpenAddAndEdit.Click += new System.EventHandler(this.BtnOpenAddAndEdit_Click);
            // 
            // BtnUipathSettings
            // 
            this.BtnUipathSettings.Location = new System.Drawing.Point(12, 271);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь к UiPath (по умолчанию C:\\Program Files (x86)\\UiPath\\Studio)";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.textBox1.Location = new System.Drawing.Point(7, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(255, 24);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "C:\\Program Files (x86)\\UiPath\\Studio";
            // 
            // BtnChoosePath
            // 
            this.BtnChoosePath.Location = new System.Drawing.Point(268, 34);
            this.BtnChoosePath.Name = "BtnChoosePath";
            this.BtnChoosePath.Size = new System.Drawing.Size(95, 27);
            this.BtnChoosePath.TabIndex = 1;
            this.BtnChoosePath.Text = "Выбрать";
            this.BtnChoosePath.UseVisualStyleBackColor = true;
            this.BtnChoosePath.Click += new System.EventHandler(this.BtnChoosePath_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 322);
            this.Controls.Add(this.btnOpenAddAndEdit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnUipathSettings);
            this.Controls.Add(this.grBxForExcel);
            this.Controls.Add(this.BtnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.grBxForExcel.ResumeLayout(false);
            this.grBxForExcel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnChoosePathFolder;
        private System.Windows.Forms.TextBox txtPathFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.GroupBox grBxForExcel;
        private System.Windows.Forms.Button btnOpenAddAndEdit;
        private System.Windows.Forms.Button BtnUipathSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnChoosePath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
    }
}