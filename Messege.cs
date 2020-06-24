using MetroFramework.Forms;
using System;

namespace VKRProjectUipath
{
    public partial class Messege : MetroForm
    {
        public Messege(string Error)
        {
            InitializeComponent();
            textBox1.Text = Error;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
