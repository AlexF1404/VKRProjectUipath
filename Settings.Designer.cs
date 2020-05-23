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
            this.button1 = new System.Windows.Forms.Button();
            this.grBxForExcel = new System.Windows.Forms.GroupBox();
            this.btnOpenAddAndEdit = new System.Windows.Forms.Button();
            this.grBxForExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChoosePathFolder
            // 
            this.btnChoosePathFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChoosePathFolder.Location = new System.Drawing.Point(309, 61);
            this.btnChoosePathFolder.Name = "btnChoosePathFolder";
            this.btnChoosePathFolder.Size = new System.Drawing.Size(112, 22);
            this.btnChoosePathFolder.TabIndex = 0;
            this.btnChoosePathFolder.Text = "Выбрать путь";
            this.btnChoosePathFolder.UseVisualStyleBackColor = true;
            this.btnChoosePathFolder.Click += new System.EventHandler(this.btnChoosePathFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Location = new System.Drawing.Point(37, 61);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.ReadOnly = true;
            this.txtPathFolder.Size = new System.Drawing.Size(255, 22);
            this.txtPathFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к директории планов";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(498, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grBxForExcel
            // 
            this.grBxForExcel.Controls.Add(this.label1);
            this.grBxForExcel.Controls.Add(this.txtPathFolder);
            this.grBxForExcel.Controls.Add(this.btnChoosePathFolder);
            this.grBxForExcel.Location = new System.Drawing.Point(19, 14);
            this.grBxForExcel.Name = "grBxForExcel";
            this.grBxForExcel.Size = new System.Drawing.Size(577, 111);
            this.grBxForExcel.TabIndex = 4;
            this.grBxForExcel.TabStop = false;
            this.grBxForExcel.Text = "Настройки учебных планов";
            // 
            // btnOpenAddAndEdit
            // 
            this.btnOpenAddAndEdit.Location = new System.Drawing.Point(19, 183);
            this.btnOpenAddAndEdit.Name = "btnOpenAddAndEdit";
            this.btnOpenAddAndEdit.Size = new System.Drawing.Size(331, 28);
            this.btnOpenAddAndEdit.TabIndex = 5;
            this.btnOpenAddAndEdit.Text = "Добавить или изменить сокращения групп";
            this.btnOpenAddAndEdit.UseVisualStyleBackColor = true;
            this.btnOpenAddAndEdit.Click += new System.EventHandler(this.btnOpenAddAndEdit_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 421);
            this.Controls.Add(this.btnOpenAddAndEdit);
            this.Controls.Add(this.grBxForExcel);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grBxForExcel;
        private System.Windows.Forms.Button btnOpenAddAndEdit;
    }
}