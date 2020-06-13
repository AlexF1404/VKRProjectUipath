
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
            textBox1.Text = Properties.Settings.Default.PathUIPath;
            Properties.Settings.Default.Save();
        }

        private void BtnChoosePathFolder_Click(object sender, EventArgs e)
        {
           
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPathFolder.Text = folderBrowserDialog1.SelectedPath + @"\";              
                Properties.Settings.Default.PathStringFolder = txtPathFolder.Text;
                Properties.Settings.Default.Save();               
            }
        }
       
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOpenAddAndEdit_Click(object sender, EventArgs e)
        {
            FrmForGroup frmForGroup = new FrmForGroup();
            frmForGroup.Show();
        }

        private void BtnUipathSettings_Click(object sender, EventArgs e)
        {
            UiPathSettings settings = new UiPathSettings();
            settings.Show();
        }

        private void BtnChoosePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog2.SelectedPath;            
                Properties.Settings.Default.PathUIPath = textBox1.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
