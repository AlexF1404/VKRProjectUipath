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
using Microsoft.Office.Interop.Word;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Fonts;
using MetroFramework.Drawing;

namespace VKRProjectUipath
{
    public partial class WordVkrForm : MetroForm
    {
        public string VKRPath="";
        public string JsonVkrStudents = "";
        List<string> PathsVkr = new List<string>();
        Dictionary<int, string> pathsWordIndex = new Dictionary<int, string>();
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
            {
               
                Messege messege = new Messege("Укажите URL Uipath и MachineKey в настройках UiPath");
                messege.Show();
            }
            else
            {
                VKRPath = "";
                InitializeOpenFileDialog("Все документы Word(*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;)|*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;", "Выберите файл приказа");
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
                                if (jsons.ListVKRStudents.Count == 0)
                                {
                                    {

                                        Messege messege = new Messege("Загружен неверный формат файла. Ошибка также может возникать, если файл открыт");
                                        messege.Show();
                                    }
                                    return;
                                }
                                else
                                {
                                    LoadDataGrid(jsons);
                                }
                            }
                            catch (System.NullReferenceException) 
                            {
                                Messege messege = new Messege("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла");
                                messege.Show();
                            }
                            catch (Newtonsoft.Json.JsonReaderException)
                            {
                                Messege messege = new Messege("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла");
                                messege.Show();
                            }
                                                       
                        }
                        );

                    }
                    catch (System.NullReferenceException)
                    {
                        Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                        messege.Show();
                        return;
                    }
                    catch (Exception)
                    {
                        Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                        messege.Show();
                        
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
                else 
                { 
                  
                    Messege messege = new Messege("Неверный формат файла или же в пути к UiPath допущена ошибка");
                    messege.Show();
                }
                File.Delete(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt");               
            }
            catch (Newtonsoft.Json.JsonReaderException) 
            { 
               
                Messege messege = new Messege("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла");
                messege.Show();
            }
            catch (IOException)
            {
                
                Messege messege = new Messege("Возможно был удален файл с данными");
                messege.Show();
            }
            catch (NullReferenceException) 
            {
                Messege messege = new Messege("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла");
                messege.Show();
            }

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
                string ans = await System.Threading.Tasks.Task.Run(() => VKRListStudent());
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
                Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                messege.Show();
                return "err";
            }
            catch (Exception)
            {
                label1.Text = "";
                Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                messege.Show();              
                return "err";
            }
        }
        async Task<string> CompliteSecondTask()
        {
            try
            {
                label1.Text = "Загрузка..";
                string line="";
                string ans = await System.Threading.Tasks.Task.Run(() => VKRCheck());
                if (ans == "err")
                {                   
                    Messege messege = new Messege("Возможно, вы указали неверные данные в путях к UiPath Studio. Ошибка также может возникать, если был загружен неверный формат файла.");
                    messege.Show();
                    return line;
                }
                else
                {
                    using (StreamReader sr = new StreamReader(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt", Encoding.GetEncoding(866)))
                    {
                        line = sr.ReadToEnd();
                    }
                }
                File.Delete(Properties.Settings.Default.PathStringFolder + "JsonVKRStudents.txt");
                label1.Text = "";
                return line;
            }
            catch (System.NullReferenceException)
            {
                label1.Text = "";              
                Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                messege.Show();
              
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
            if (JsonVkrStudents == "") 
            {
                Messege messege = new Messege("Для начала проверки ВКР загрузите приказ");
                messege.Show();                
                return; 
            }
            if ((Properties.Settings.Default.KeyMachine == "") || (Properties.Settings.Default.URLUiPath == ""))
            { 
               
                Messege messege = new Messege("Укажите URL Uipath и MachineKey в настройках UiPath");
                messege.Show();
                return;

            }
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
                                    pathsWordIndex.Clear();
                                    foreach (List<string> item in jsons.listError) 
                                    {
                                        string FullError="";
                                        string[] mass= { };
                                        string names = "";
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
                                                break;
                                            }
                                            else 
                                            {                                                                                                   
                                                if (error.Contains("ВКР("))
                                                {                                                          
                                                    string[] chars = { "ВКР(" };
                                                    string[] namestud = error.Split(chars, StringSplitOptions.RemoveEmptyEntries);
                                                    namestud = namestud[0].Split(')');
                                                    names = namestud[0];
                                                    string st = error.Replace("ВКР(" + namestud[0] + "):", "");
                                                    string[] s = { "**" };
                                                     mass = st.Split(s, StringSplitOptions.None);
                                                    FullError = FullError + mass[1] + "\n";                                                                                                   
                                                }   
                                            
                                            }
                                            
                                        }
                                            foreach (DataGridViewRow dataRow in dataGridView1.Rows)
                                            {
                                                if (dataRow.Cells[1].Value.ToString() == names)
                                                {

                                                    dataRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 124, 129);
                                                    dataRow.Cells[1].ToolTipText = FullError;                                                    
                                                    pathsWordIndex.Add(dataRow.Index, mass[0]);
                                                    break;
                                                }
                                            }
                                    }
                                    
                                }
                                catch (Newtonsoft.Json.JsonReaderException) 
                                {
                                    Messege messege = new Messege("Ошибка ответа робота. Возможно нет подключения к Интернету. Также ошибка может возникать, если загружен неверный формат файла");
                                    messege.Show();                                    
                                }
                            }
                            );
                        }
                        else {
                            Messege messege = new Messege("Для начала проверки ВКР загрузите приказ");
                            messege.Show();
                            return;
                        }


                    }
                    catch (System.NullReferenceException)
                    {
                        Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                        messege.Show();                     
                        return;
                    }
                    catch (Exception)
                    {
                        Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                        messege.Show();                   
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
                WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString(),
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
            startInfo.WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString();
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
                Messege messege = new Messege("Возможно, вы указали неверные данные в путях к UiPath Studio. Ошибка также может возникать, если был загружен неверный формат файла");
                messege.Show();                
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
                WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString(),
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
            startInfo.WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString();
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
                Messege messege = new Messege("Возможно, вы указали неверные данные в путях к UiPath Studio");
                messege.Show();               
                return "err";
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            string path="";
            try
            {
                index = e.RowIndex;
                path = pathsWordIndex[index];
            }
            catch (Exception) { return; }
            try
            {                
                System.Diagnostics.Process.Start(path.Trim());
            }
            catch (Exception) { return; }
        }

      

    }
}
