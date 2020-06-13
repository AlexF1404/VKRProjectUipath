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
        List<string> PathsVkr = new List<string>();
        public WordVkrForm()
        {
            InitializeComponent();
        }
        private void InitializeOpenFileDialog(string Filter, string Title)
        {
            this.openFileDialog1.Filter = Filter;
            this.openFileDialog1.Title = Title;
        }
        //загрузка приказа
        private void btnloadDoc_Click(object sender, EventArgs e)
        {           
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

                            try
                            {
                                var jsons = JsonConvert.DeserializeObject<ListVKRStudent>(result);
                                LoadDataGrid(jsons);    
                            }
                            catch(Newtonsoft.Json.JsonReaderException) { MessageBox.Show("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла","Ошибка"); }
                                                       
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
        //заполнение таблицы по приказу
         public void LoadDataGrid(ListVKRStudent json) 
        
         {
            JsonVkrStudents = JsonConvert.SerializeObject(json);          
            int i = 0;           
            try
            {

                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                if (json != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (VKRStudents rootObject in json.ListVKRStudents)
                    {

                        dataGridView1.Rows.Add(i + 1, rootObject.FIO, (rootObject.Group.Split('&'))[0], rootObject.VKRTheme, rootObject.GetInitialsManager());
                        i++;
                    }
                }
                else { MessageBox.Show("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла", "Ошибка"); }
                File.Delete(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt");               
            }
            catch (Newtonsoft.Json.JsonReaderException) { MessageBox.Show("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла.", "Ошибка"); }
            catch (IOException)
            {
                MessageBox.Show("Возможно был удален файл с данными.", "Ошибка файла");
            }
            catch (NullReferenceException) { MessageBox.Show("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла.", "Ошибка"); }

        }
        public class ListVKRStudent
        {
            public List<VKRStudents> ListVKRStudents { get; set; }
        }
        public class ListError
        { 
            public List<List<string>> listError { get; set; }
        }
        async Task<string> CompliteCmdAsync()
        {
            try
            {
                label1.Text = "Загрузка..";
                string line;
                string ans = await Task.Run(() => VKRListStudent());
                using (StreamReader sr = new StreamReader(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt", Encoding.GetEncoding(866)))
                {
                    line = sr.ReadToEnd();
                }
                label1.Text = "";
                return line;
            }
            catch (System.NullReferenceException)
            {
                label1.Text = "";
                MessageBox.Show("Ошибка ответа, попробуйте еще раз");
                return "err";
            }
            catch (Exception)
            {
                label1.Text = "";
                MessageBox.Show("Ошибка ответа, попробуйте еще раз");
                return "err";
            }
        }
        async Task<string> CompliteSecondTask()
        {
            try
            {
                label1.Text = "Загрузка..";
                string line;
                string ans = await Task.Run(() => VKRCheck());
                using (StreamReader sr = new StreamReader(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt", Encoding.GetEncoding(866)))
                {
                    line = sr.ReadToEnd();
                }
                File.Delete(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt");
                label1.Text = "";
                return line;
            }
            catch (System.NullReferenceException)
            {
                label1.Text = "";
                MessageBox.Show("Ошибка ответа, попробуйте еще раз");
                return "err";
            }
            catch (Exception)
            {
                label1.Text = "";
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
        private void SelectListOfPathsInOpenFileVKR(out List<string> listFiles)
        {
            listFiles = new List<string>();
            DialogResult dr = this.openFileDialog2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (string file in openFileDialog2.FileNames)
                {
                    listFiles.Add(file);
                }
            }
            else return;

        }
        //кнопка проверка ВКР
        private void CheckVkr_Click(object sender, EventArgs e)
        {
            List<string> listPathsVkr = new List<string>();
            if (JsonVkrStudents == null) { MessageBox.Show("Для начала проверки ВКР загрузите приказ", "Ошибка"); return; }
            if ((Properties.Settings.Default.KeyMachine == "") || (Properties.Settings.Default.URLUiPath == ""))
            { MessageBox.Show("Укажите URL Uipath и MachineKey в настройках UiPath", "Настройка Uipath"); }
            else
            {
                InitializeOpenFileDialog("Все документы Word и Pdf (*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.pdf;)|*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.pdf;", "Выберите файл ВКР");
                SelectListOfPathsInOpenFileVKR(out listPathsVkr);
                PathsVkr = listPathsVkr;
                if (listPathsVkr.Count > 0)
                {
                    try
                    {
                        if (JsonVkrStudents != "")
                        {
                            using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.PathStringFolder + "tempJson.doc", false, Encoding.Default))
                            {
                                sw.WriteLine(JsonVkrStudents);
                            }

                            Task<string> task = CompliteSecondTask();
                            var awaiter = task.GetAwaiter();
                            awaiter.OnCompleted(() =>
                            {
                                string result = awaiter.GetResult();
                               
                                try
                                {

                                    var jsons = JsonConvert.DeserializeObject<ListError>(result);
                                    foreach (List<string> item in jsons.listError) 
                                    {
                                        foreach (string error in item) 
                                        {
                                            if (error.Contains("!@"))
                                            {
                                                string[] chars = { "!@" };
                                                string[] namestud = error.Split(chars, StringSplitOptions.RemoveEmptyEntries);
                                                foreach (DataGridViewRow dataRow in dataGridView1.Rows)
                                                {
                                                    if (dataRow.Cells[1].Value.ToString() == namestud[0])
                                                    {
                                                        dataRow.DefaultCellStyle.BackColor = Color.FromArgb(0, 255, 115);
                                                        dataRow.Cells[1].ToolTipText="";
                                                        break;
                                                    }
                                                }
                                            }
                                            else 
                                            {
                                                string[] chars = { "ВКР(" };
                                                if (error.Contains("ВКР(")) 
                                                {
                                                    string[] namestud = error.Split(chars,StringSplitOptions.RemoveEmptyEntries);
                                                    namestud = namestud[0].Split(')');
                                                   
                                                    foreach (DataGridViewRow dataRow in dataGridView1.Rows)
                                                    {
                                                        if (dataRow.Cells[1].Value.ToString() == namestud[0])
                                                        {
                                                            dataRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 124, 129);
                                                            dataRow.Cells[1].ToolTipText = error.Replace("ВКР(" + namestud[0] + "):","");
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            
                                        }
                                    }
                                    
                                }
                                catch (Newtonsoft.Json.JsonReaderException) { MessageBox.Show("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла", "Ошибка"); }
                            }
                            );
                        }
                        else { MessageBox.Show("Для начала работы загрузите приказ","Ошибка"); }


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
                return json;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Возможно, вы указали неверные данные в путях к UiPath Studio");
                return "err";
            }

        }
        private string VKRCheck()
        {            
            string cmd = @"UiRobot.exe connect --url " + Properties.Settings.Default.URLUiPath + " --key " + Properties.Settings.Default.KeyMachine;
            string pathStringWord = Newtonsoft.Json.JsonConvert.SerializeObject(PathsVkr, Formatting.None);
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string cmd1 = @"UiRobot.exe execute --process CheckVKRs --input " + "\"" + "{" + "\'" + "ListPaths" + "\'" + ": " + pathStringWord.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + "\'" + "pF" + "\'" + ": " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"") + "}\"";
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
            startInfo.Arguments = "/C " + cmd1 + @">" + Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt";
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
                string json = srIncoming.ReadToEnd();
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
