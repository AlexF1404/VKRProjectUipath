using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKRStudents = VKRStudent.VKRStudent;

namespace VKRProjectUipath
{
    public partial class WordVkrForm : Form
    {
        public string VKRPath="";
        public string JsonVkrStudents = "";
        public WordVkrForm()
        {
            InitializeComponent();
        }
        private void InitializeOpenFileDialog(string Filter, string Title)
        {
            this.openFileDialog1.Filter = Filter;
            this.openFileDialog1.Title = Title;
        }
        private void btnloadDoc_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Add("123", "asd", "sad", "erc");
            if ((Properties.Settings.Default.KeyMachine == "") || (Properties.Settings.Default.URLUiPath == ""))
            { MessageBox.Show("Укажите URL Uipath и MachineKey в настройках UiPath", "Настройка Uipath"); }
            else
            {
                InitializeOpenFileDialog("Все документы Word и Pdf (*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.pdf;)|*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.pdf;", "Выберите файл приказа");
                SelectListOfPathsInOpenFileDialog();
                if (VKRPath!="")
                {
                    try
                    {
                        Task<string> task = CompliteCmdAsync();
                        var awaiter = task.GetAwaiter();
                        awaiter.OnCompleted(() =>
                        {
                            string result = awaiter.GetResult();
                           
                            Console.WriteLine(result+"123123");
                            var jsons = JsonConvert.DeserializeObject<ListVKRStudent>(result);                               
                                LoadDataGrid(jsons);                           
                        }
                        );

                    }
                    catch (System.NullReferenceException)
                    {
                        MessageBox.Show("Ошибка ответа, попробуйте еще раз");
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка ответа, попробуйте еще раз");
                        return;
                    }

                }
                else return;
            }
        }
         public void LoadDataGrid(ListVKRStudent json) 
        
         {
            int i = 0;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (VKRStudents rootObject in json.ListVKRStudents) 
            {
               
                dataGridView1.Rows.Add(i+1,rootObject.FIO,rootObject.Group,rootObject.VKRTheme,rootObject.VKRManager);
                i++;
            }
            File.Delete(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt");
         }
        public class ListVKRStudent
        {
            public List<VKRStudents> ListVKRStudents { get; set; }
        }
       
        async Task<string> CompliteCmdAsync()
        {
            try
            { 
                string line;
                string ans = await Task.Run(() => VKRListStudent());
                using (StreamReader sr = new StreamReader(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt", Encoding.GetEncoding(866)))
                {

                    line = sr.ReadToEnd();
                }
                return line;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Ошибка ответа, попробуйте еще раз");
                return "err";
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ответа, попробуйте еще раз");
                return "err";
            }
        }
        private void SelectListOfPathsInOpenFileDialog()
        {
            
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                VKRPath = openFileDialog1.FileName;
            }
            else return;

        }
        private void CheckVkr_Click(object sender, EventArgs e)
        {

        }
        private static void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data));
        }
        private string VKRListStudent()
        {
            string json = "";

            string cmd = @"UiRobot.exe connect --url " + Properties.Settings.Default.URLUiPath + " --key " + Properties.Settings.Default.KeyMachine;
            string pathStringWord = Newtonsoft.Json.JsonConvert.SerializeObject(VKRPath, Formatting.None);
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string cmd1 = @"UiRobot.exe execute --process AutoPr --input " + "\"" + "{" + "\'" + "WordFile" + "\'" + ": " + pathStringWord.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + "\'" + "Ph" + "\'" + ": " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"") + "}\"";
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                FileName = "cmd.exe",
                Arguments = "/C " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(proc);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardError = true;
            startInfo.WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + cmd1+ @">"+ Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt";
            startInfo.CreateNoWindow = true;
            startInfo.StandardOutputEncoding = Encoding.GetEncoding(850);            
            try
            {
                Process procCommand = new Process();
                procCommand.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
                procCommand.ErrorDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
                procCommand.StartInfo = startInfo;
                procCommand.Start();
                procCommand.WaitForExit();
                StreamReader srIncoming = procCommand.StandardOutput;               
                Console.WriteLine(json);
                return json;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Возможно, вы указали неверные данные в путях к UiPath Studio");
                return "err";
            }

        }

       
    }
}
