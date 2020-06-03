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
            this.grBxForExcel.SuspendLayout();
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
            this.BtnExit.Location = new System.Drawing.Point(498, 378);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(97, 31);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "Ok";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // grBxForExcel
            // 
            this.grBxForExcel.Controls.Add(this.btnOpenAddAndEdit);
            this.grBxForExcel.Controls.Add(this.label1);
            this.grBxForExcel.Controls.Add(this.txtPathFolder);
            this.grBxForExcel.Controls.Add(this.btnChoosePathFolder);
            this.grBxForExcel.Location = new System.Drawing.Point(19, 14);
            this.grBxForExcel.Name = "grBxForExcel";
            this.grBxForExcel.Size = new System.Drawing.Size(576, 153);
            this.grBxForExcel.TabIndex = 4;
            this.grBxForExcel.TabStop = false;
            this.grBxForExcel.Text = "Настройки учебных планов";
            // 
            // btnOpenAddAndEdit
            // 
            this.btnOpenAddAndEdit.Location = new System.Drawing.Point(9, 101);
            this.btnOpenAddAndEdit.Name = "btnOpenAddAndEdit";
            this.btnOpenAddAndEdit.Size = new System.Drawing.Size(331, 28);
            this.btnOpenAddAndEdit.TabIndex = 5;
            this.btnOpenAddAndEdit.Text = "Добавить или изменить сокращения групп";
            this.btnOpenAddAndEdit.UseVisualStyleBackColor = true;
            this.btnOpenAddAndEdit.Click += new System.EventHandler(this.BtnOpenAddAndEdit_Click);
            // 
            // BtnUipathSettings
            // 
            this.BtnUipathSettings.Location = new System.Drawing.Point(12, 378);
            this.BtnUipathSettings.Name = "BtnUipathSettings";
            this.BtnUipathSettings.Size = new System.Drawing.Size(150, 31);
            this.BtnUipathSettings.TabIndex = 5;
            this.BtnUipathSettings.Text = "Настройки UiPath";
            this.BtnUipathSettings.UseVisualStyleBackColor = true;
            this.BtnUipathSettings.Click += new System.EventHandler(this.BtnUipathSettings_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 421);
            this.Controls.Add(this.BtnUipathSettings);
            this.Controls.Add(this.grBxForExcel);
            this.Controls.Add(this.BtnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.grBxForExcel.ResumeLayout(false);
            this.grBxForExcel.PerformLayout();
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
    }
}