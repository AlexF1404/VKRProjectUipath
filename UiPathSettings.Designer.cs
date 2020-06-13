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
            this.TxtBxURL = new System.Windows.Forms.TextBox();
            this.TxtBxKey = new System.Windows.Forms.TextBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.White;
            this.Save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Location = new System.Drawing.Point(330, 201);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(88, 32);
            this.Save.TabIndex = 0;
            this.Save.Text = "Ок";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // TxtBxURL
            // 
            this.TxtBxURL.Location = new System.Drawing.Point(26, 89);
            this.TxtBxURL.Name = "TxtBxURL";
            this.TxtBxURL.Size = new System.Drawing.Size(392, 22);
            this.TxtBxURL.TabIndex = 2;
            // 
            // TxtBxKey
            // 
            this.TxtBxKey.Location = new System.Drawing.Point(26, 156);
            this.TxtBxKey.Name = "TxtBxKey";
            this.TxtBxKey.Size = new System.Drawing.Size(392, 22);
            this.TxtBxKey.TabIndex = 4;
            // 
            // BtnConnect
            // 
            this.BtnConnect.BackColor = System.Drawing.Color.White;
            this.BtnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnConnect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConnect.Location = new System.Drawing.Point(26, 201);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(288, 32);
            this.BtnConnect.TabIndex = 5;
            this.BtnConnect.Text = "Проверка подключения Orchestrator";
            this.BtnConnect.UseVisualStyleBackColor = false;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(26, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(168, 20);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Orchestrator_Server_URL:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(26, 123);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(92, 20);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Key machine:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 0);
            this.label3.TabIndex = 9;
            this.label3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // UiPathSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 247);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.TxtBxKey);
            this.Controls.Add(this.TxtBxURL);
            this.Controls.Add(this.Save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UiPathSettings";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Настройки UiPath";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UiPathSettings_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox TxtBxURL;
        private System.Windows.Forms.TextBox TxtBxKey;
        private System.Windows.Forms.Button BtnConnect;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel label3;
    }
}