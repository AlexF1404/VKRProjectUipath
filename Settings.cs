
using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace VKRProjectUipath
{
    public partial class Settings : MetroForm
    {
        public FrmForGroup frmForGroup;
        public UiPathSettings uipathsettings;
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
            if ((Application.OpenForms.OfType<FrmForGroup>().Count() != 1))
            {
                frmForGroup = new FrmForGroup(this);
                frmForGroup.Show();
            }
            else
            {
                if (frmForGroup != null)
                {
                    frmForGroup.Focus();
                }
            }
        }

        private void BtnUipathSettings_Click(object sender, EventArgs e)
        {

            if ((Application.OpenForms.OfType<UiPathSettings>().Count() != 1))
            {
                uipathsettings = new UiPathSettings(this);
                uipathsettings.Show();
            }
            else
            {
                if (uipathsettings != null)
                {
                    uipathsettings.Focus();
                }
            }
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

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
