
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace VKRProjectUipath
{

    public partial class MainForm : Form
    {        
        List<string> pathsExcel = new List<string>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            InitializeOpenFileDialog();
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {

                foreach (String file in openFileDialog1.FileNames)
                {
                    pathsExcel.Add(file);
                }
            }
            VRKExcelAndClearList();
        }
        private void InitializeOpenFileDialog() {
            this.openFileDialog1.Filter = "Файлы Excel (*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;";
            this.openFileDialog1.Title = "Выберите Excel файлы учебных планов";
        }
        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    pathsExcel.Add(file);
                    Console.WriteLine(file);
                }
            }
        }
        private void VRKExcelAndClearList() {
            string cmd = @"UiRobot.exe connect --url https://cloud.uipath.com/alexcompany/AlexCompanyDefault --key 51595987-ee0a-426e-9cae-bd63f34311be";
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/k " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(proc);
            string pathStringExcel = JsonConvert.SerializeObject(pathsExcel, Formatting.None);
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);          
            string cmd1 = @"UiRobot.exe execute --process VKRExcel --input "+"\""+"{"+"\'"+"pathStringExcel"+"\'"+": " + pathStringExcel.Replace("\"","'").Replace("\\x22", "\\\"") + ", " + "\'" + "pathFolder" + "\'" + ": " +  pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"") + "}\"";           
            var proc1 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/k " + cmd1,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(proc1);
            pathsExcel.Clear();
        }

        private void mainMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void settingsItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}
