
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKRProjectUipath
{
    public partial class Settings : Form
    {
        
        public Settings()
        {           
            InitializeComponent();
            txtPathFolder.Text = Properties.Settings.Default.PathStringFolder;
            Properties.Settings.Default.Save();
        }

        private void btnChoosePathFolder_Click(object sender, EventArgs e)
        {
           
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPathFolder.Text = folderBrowserDialog1.SelectedPath + @"\";              
                Properties.Settings.Default.PathStringFolder = txtPathFolder.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Путь сохранен", "Путь к директориям", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        
    }
}
