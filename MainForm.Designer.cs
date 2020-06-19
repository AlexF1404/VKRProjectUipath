namespace VKRProjectUipath
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.WorkVKRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnWordPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnExcel);
            this.groupBox1.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание директорий (папок):";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackColor = System.Drawing.Color.White;
            this.BtnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcel.Location = new System.Drawing.Point(12, 41);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(188, 36);
            this.BtnExcel.TabIndex = 2;
            this.BtnExcel.Text = "Выбор планов";
            this.BtnExcel.UseVisualStyleBackColor = false;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorkVKRToolStripMenuItem,
            this.settingsItem});
            this.menuStrip2.Location = new System.Drawing.Point(21, 60);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(728, 26);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // WorkVKRToolStripMenuItem
            // 
            this.WorkVKRToolStripMenuItem.Name = "WorkVKRToolStripMenuItem";
            this.WorkVKRToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.WorkVKRToolStripMenuItem.Text = "Работа с ВКР";
            this.WorkVKRToolStripMenuItem.Click += new System.EventHandler(this.WorkVKRToolStripMenuItem_Click);
            // 
            // settingsItem
            // 
            this.settingsItem.Name = "settingsItem";
            this.settingsItem.Size = new System.Drawing.Size(84, 22);
            this.settingsItem.Text = "Настройки";
            this.settingsItem.Click += new System.EventHandler(this.SettingsItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWordPdf);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(6, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 158);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сортировка курсовых работ и проектов";
            // 
            // btnWordPdf
            // 
            this.btnWordPdf.BackColor = System.Drawing.Color.White;
            this.btnWordPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWordPdf.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnWordPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWordPdf.Location = new System.Drawing.Point(9, 98);
            this.btnWordPdf.Name = "btnWordPdf";
            this.btnWordPdf.Size = new System.Drawing.Size(235, 36);
            this.btnWordPdf.TabIndex = 7;
            this.btnWordPdf.Text = "Выбор Word/PDF файлов курсовых";
            this.btnWordPdf.UseVisualStyleBackColor = false;
            this.btnWordPdf.Click += new System.EventHandler(this.BtnWordPdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выберите вид сессии (обязательно):";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 24;
            this.comboBox1.Items.AddRange(new object[] {
            "Летняя сессия",
            "Зимняя сессия"});
            this.comboBox1.Location = new System.Drawing.Point(10, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 30);
            this.comboBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Font = new System.Drawing.Font("Akrobat Bold", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(9, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(749, 300);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Работа с Excel-планами и Курсовыми";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Akrobat Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(442, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(770, 413);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 413);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(21, 60, 21, 20);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "VKRs and CourseWorks Automation";
            this.groupBox1.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem settingsItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem WorkVKRToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.Button btnWordPdf;
        private System.Windows.Forms.Label label2;
    }
}

