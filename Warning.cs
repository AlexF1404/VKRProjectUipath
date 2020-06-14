using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Fonts;
using MetroFramework.Drawing;


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
