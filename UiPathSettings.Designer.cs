namespace VKRProjectUipath
{
    partial class UiPathSettings
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
            this.Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBxURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBxKey = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(353, 163);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(88, 32);
            this.Save.TabIndex = 0;
            this.Save.Text = "Ок";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Orchestrator_Server_URL:";
            // 
            // TxtBxURL
            // 
            this.TxtBxURL.Location = new System.Drawing.Point(15, 38);
            this.TxtBxURL.Name = "TxtBxURL";
            this.TxtBxURL.Size = new System.Drawing.Size(392, 22);
            this.TxtBxURL.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key machine:";
            // 
            // TxtBxKey
            // 
            this.TxtBxKey.Location = new System.Drawing.Point(15, 105);
            this.TxtBxKey.Name = "TxtBxKey";
            this.TxtBxKey.Size = new System.Drawing.Size(392, 22);
            this.TxtBxKey.TabIndex = 4;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(12, 163);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(288, 32);
            this.BtnConnect.TabIndex = 5;
            this.BtnConnect.Text = "Проверка подключения Orchestrator";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 6;
            // 
            // UiPathSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 207);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.TxtBxKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBxURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UiPathSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки UiPath";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBxURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBxKey;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label label3;
    }
}