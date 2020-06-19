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
using System.Data.SQLite;

namespace VKRProjectUipath
{
    public partial class WordVkrForm : MetroForm
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        public string VKRPath = "";
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
                if (VKRPath != "")
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
                    pathsWordIndex.Clear();
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
        public class Answ 
        {
            public List<string> Ans { get; set; }
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
                string line = "";
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
        async Task<string> CompliteVKRGo(List<string> VKRList, Dictionary<string, string> keys)
        {
            try
            {
                label1.Text = "Загрузка..";
                string line = "";
                string ans = await System.Threading.Tasks.Task.Run(() => VKRGo(VKRList,keys));
                if (ans == "err")
                {
                    Messege messege = new Messege("Возможно, вы указали неверные данные в путях к UiPath Studio. Ошибка также может возникать, если был загружен неверный формат файла.");
                    messege.Show();
                    label1.Text = "";
                    
                    return line;
                }
                else 
                {
                    label1.Text = "";
                    return ans;
                }

                
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
        private Dictionary<string, string> GoDBForDictionary()
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();
            dbFileName = "dbForNameGroup";
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
                m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS namegroup (id INTEGER PRIMARY KEY AUTOINCREMENT, little TEXT, big TEXT)";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {
                Messege messege = new Messege("Для начала создайте сокращения для групп в разделе 'Настройки'");
                messege.Show();
                return keys;
            }
            System.Data.DataTable dTable = new System.Data.DataTable();
            String sqlQuery;

            if (m_dbConn.State != ConnectionState.Open)
            {
                Messege messege = new Messege("Попробуйте еще раз");
                messege.Show();
                return keys;
            }

            try
            {

                sqlQuery = "SELECT little, big FROM namegroup";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        keys.Add(dTable.Rows[i].ItemArray[0].ToString().ToLower(), dTable.Rows[i].ItemArray[1].ToString().ToLower());
                    }
                    return keys;
                }
                else
                {
                    Messege messege = new Messege("Добавьте записи в таблицу или загрузите их из файла");
                    messege.Show();
                    return keys;
                }
            }
            catch (SQLiteException)
            {
                Messege messege = new Messege("Произошла ошибка");
                messege.Show();
                return keys;
            }
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
                                                             
                                foreach (List<string> item in jsons.listError)
                                {
                                    string FullError = "";
                                    string[] mass = { };
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
                                                    dataRow.Cells[1].ToolTipText = "";
                                                        if (pathsWordIndex.ContainsKey(dataRow.Index))
                                                        {
                                                            pathsWordIndex[dataRow.Index] = namestud[1] + "!@" + namestud[2];
                                                        }
                                                        else
                                                        {
                                                            pathsWordIndex.Add(dataRow.Index, namestud[1] + "!@" + namestud[2]);
                                                        }
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
                                                else
                                                {
                                                    Messege messege = new Messege(error);
                                                    messege.Show();
                                                }

                                            }
                                            
                                        }
                                        foreach (DataGridViewRow dataRow in dataGridView1.Rows)
                                        {
                                            if (dataRow.Cells[1].Value.ToString() == names)
                                            {

                                                dataRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 124, 129);
                                                dataRow.Cells[1].ToolTipText = FullError;
                                                if (pathsWordIndex.ContainsKey(dataRow.Index))
                                                {
                                                    pathsWordIndex[dataRow.Index] = mass[0];
                                                }
                                                else
                                                {
                                                    pathsWordIndex.Add(dataRow.Index, mass[0]);
                                                }
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
            if (!String.IsNullOrEmpty(outLine.Data)) ;
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
        private string VKRGo(List<string> listPath, Dictionary<string, string> keys)
        {
            string cmd = @"UiRobot.exe connect --url " + Properties.Settings.Default.URLUiPath + " --key " + Properties.Settings.Default.KeyMachine;
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string pathStringWord = Newtonsoft.Json.JsonConvert.SerializeObject(listPath, Formatting.None);
            string keysjson = Newtonsoft.Json.JsonConvert.SerializeObject(keys, Formatting.None);
            string cmd1 = @"UiRobot.exe execute --process VKRGo --input " + "\"" + "{" + "\'" + "ListPaths" + "\'" + ": " + pathStringWord.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + "\'" + "listD" + "\'" + ": " + keysjson.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + "\'" + "pF" + "\'" + ": " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"") + "}\"";
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
            startInfo.Arguments = "/C " + cmd1;
            startInfo.CreateNoWindow = true;
            startInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
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
            string path = "";
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
            catch (Exception)
            {
                return;
            }
        }

        private void VKRGo_Click(object sender, EventArgs e)
        {
            List<string> niceStudent = new List<string>();

            foreach (DataGridViewRow dataRow in dataGridView1.Rows)
            {
                if (dataRow.DefaultCellStyle.BackColor == Color.FromArgb(0, 255, 115))
                {
                    niceStudent.Add(pathsWordIndex[dataRow.Index]);
                }
            }
            if (niceStudent.Count == 0)
            {
                Messege messege = new Messege("В списке пока нет правильных ВКР");
                messege.Show();
                return;
            }
            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys = GoDBForDictionary();
            try
            {

                Task<string> task = CompliteVKRGo(niceStudent,keys);
                var awaiter = task.GetAwaiter();
                awaiter.OnCompleted(() =>
                {
                    string result = awaiter.GetResult();
                    var jsons = JsonConvert.DeserializeObject<Answ>(result);                    
                    string[] chars = { "!@" };
                    if (jsons.Ans.Count > 0) {
                        foreach (string item in jsons.Ans)
                        {
                            if (item != "")
                            {
                                Messege messege = new Messege(item.Split(chars,StringSplitOptions.None)[0]+". "+ (item.Split(chars, StringSplitOptions.None)[1]));
                                messege.Show();
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                   
                });
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
    }
}
