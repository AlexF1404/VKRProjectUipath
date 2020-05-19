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
            this.SuspendLayout();
            // 
            // btnChoosePathFolder
            // 
            this.btnChoosePathFolder.Location = new System.Drawing.Point(334, 72);
            this.btnChoosePathFolder.Name = "btnChoosePathFolder";
            this.btnChoosePathFolder.Size = new System.Drawing.Size(112, 29);
            this.btnChoosePathFolder.TabIndex = 0;
            this.btnChoosePathFolder.Text = "Выбрать путь";
            this.btnChoosePathFolder.UseVisualStyleBackColor = true;
            this.btnChoosePathFolder.Click += new System.EventHandler(this.btnChoosePathFolder_Click);
            // 
            // txtPathFolder
            // 
            this.txtPathFolder.Location = new System.Drawing.Point(56, 75);
            this.txtPathFolder.Name = "txtPathFolder";
            this.txtPathFolder.ReadOnly = true;
            this.txtPathFolder.Size = new System.Drawing.Size(255, 22);
            this.txtPathFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к директории планов";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPathFolder);
            this.Controls.Add(this.btnChoosePathFolder);
            this.Name = "Settings";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnChoosePathFolder;
        private System.Windows.Forms.TextBox txtPathFolder;
        private System.Windows.Forms.Label label1;
    }
}