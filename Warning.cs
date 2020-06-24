using MetroFramework.Forms;
using System;
using System.Windows.Forms;


namespace VKRProjectUipath
{
    public partial class Warning : MetroForm
    {
        DialogResult dialog;
        public Warning(string Error)
        {
            InitializeComponent();
            textBox1.Text = Error;
        }
        public DialogResult Warnings()
        {
            return dialog;
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            dialog = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            dialog = DialogResult.Cancel;
            Close();
        }
    }
}
