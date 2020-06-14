
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Linq;
using System.Security.Permissions;
using System.Security;
using System.Net;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Fonts;
using MetroFramework.Drawing;



namespace VKRProjectUipath
{
    public partial class MainForm : MetroForm
    {         
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        List<string> pathsExcel = new List<string>();
        List<string> pathsWordPdf = new List<string>();


        Settings settings;
        WordVkrForm vkrform;
        public MainForm()
        {
          


            InitializeComponent();
           
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            btnWordPdf.Enabled = false;
             
            
        }
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (ConnectionAvailable() == true)
            {
                pathsExcel.Clear();
                InitializeOpenFileDialog("Файлы Excel (*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;", "Выберите Excel файлы учебных планов");
                SelectListOfPathsInOpenFileDialog(out pathsExcel);

                if (pathsExcel.Count > 0)
                {
                    try
                    {
                        Task<string> task = CompliteCmdAsync();
                        var awaiter = task.GetAwaiter();
                        awaiter.OnCompleted(() =>
                        {
                            string result = awaiter.GetResult();
                            if (result == "err") { return; }
                            else
                            {
                                try
                                {
                                    if (ConnectionAvailable() == false)
                                    {

                                        Messege messege = new Messege("Возможно отсутствует подключение к Интернету. Для нормальной работы с приложением требуется подключение");
                                        messege.Show();

                                    }
                                    else
                                    {
                                        var jsons = JsonConvert.DeserializeObject<RootObject>(result);
                                        if (jsons != null)
                                        {
                                            AddDBNameOfDirection(jsons.stringNameNapr);
                                        }
                                        else
                                        {
                                            Messege messege = new Messege("Неверный формат Excel-файла или ошибка подключения UiPath");
                                            messege.Show();
                                        }
                                    }

                                }
                                catch (NullReferenceException)
                                {
                                    Messege messege = new Messege("Ошибка соединения с роботом. Возможно отсутствует подключение к Интернету");
                                    messege.Show();
                                }
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
            else
                {
                    Messege messege = new Messege("Ошибка соединения с роботом. Возможно отсутствует подключение к Интернету");
                    messege.Show();
                }
            
        }        
        private void BtnWordPdf_Click(object sender, EventArgs e)
        {
            if (ConnectionAvailable() == true)
            {
                bool session = true;
                if (comboBox1.SelectedIndex == 0)
                {
                    session = false;
                }
                else
                {
                    session = true;
                }

                if ((Properties.Settings.Default.KeyMachine == "") || (Properties.Settings.Default.URLUiPath == ""))
                {
                    Messege messege = new Messege("Укажите URL Uipath и MachineKey в настройках UiPath");
                    messege.Show();
                }
                else
                {
                    InitializeOpenFileDialog("Все документы Word и Pdf (*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf;)|*.docx;*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf;", "Выберите Word/Pdf файлы курсовых работ");
                    SelectListOfPathsInOpenFileDialog(out pathsWordPdf);
                    if (pathsWordPdf.Count > 0)
                    {
                        Dictionary<string, string> keysforGr = GoDBForDictionary();
                        List<string> nameOfPredmets = GetNameOfPredmets();
                        VRKWordPdfSort(keysforGr, nameOfPredmets, session);
                    }
                    else return;
                }
            }
            else
            {
                Messege messege = new Messege("Ошибка соединения с роботом. Возможно отсутствует подключение к Интернету");
                messege.Show();
            }
        }
        private List<string> GetNameOfPredmets() 
        {
            try
            {
                string dbFileNames = "dbForNameGroup";
                string tableName = "namedirect";
                SQLiteConnection m_dbConn = OpenOrCreateDataBase(dbFileNames, tableName);
                DataTable dTable = new DataTable();
                List<string> nameofDirectionToBe = new List<string>();
                string sqlQuery = "SELECT * FROM namedirect";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                m_dbConn.Close();
                if (dTable.Rows.Count >= 0)
                {
                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        nameofDirectionToBe.Add(dTable.Rows[i].Field<string>(1));
                    }
                    return nameofDirectionToBe;
                }
                return nameofDirectionToBe;
            }
            catch (NullReferenceException)
            {                
                Messege messege = new Messege("Ошибка соединения с базой данных");
                messege.Show();                
                return null;
            }

        }
        private SQLiteConnection OpenOrCreateDataBase(string DbName,string TableName)
        {
                SQLiteConnection m_dbConn = new SQLiteConnection();
                SQLiteCommand m_sqlCmd = new SQLiteCommand();
                string dbFileNames = DbName;
                if (!File.Exists(dbFileNames))
                {
                    SQLiteConnection.CreateFile(dbFileNames);                    
                }
                try
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileNames + ";Version=3;");
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS "+TableName+" (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT)";
                    m_sqlCmd.ExecuteNonQuery();
                    return m_dbConn;
                }
                catch (SQLiteException ex)
                {
                    Messege messege = new Messege("Ошибка соединения с базой данных");
                    messege.Show();              
                    return m_dbConn;
                }
           
        }
        private void AddDBNameOfDirection(List<string> addNameOfPredmets)
        {
            try
            {
                if (addNameOfPredmets != null)
                {
                    try
                    {
                        List<string> namePredmetsToBe = GetNameOfPredmets();
                        foreach (string item in addNameOfPredmets)
                        {
                            namePredmetsToBe.Add(item);

                        }
                        var data = new HashSet<string>(namePredmetsToBe, StringComparer.OrdinalIgnoreCase);
                  
                        string dbFileNames = "dbForNameGroup";
                        string tableName = "namedirect";
                        SQLiteConnection m_dbConn = OpenOrCreateDataBase(dbFileNames, tableName);
                        SQLiteCommand m_sqlCmd = new SQLiteCommand();
                        m_sqlCmd.Connection = m_dbConn;
                        string sqlrefresh = "DELETE FROM namedirect";
                        m_sqlCmd.CommandText = sqlrefresh;
                        m_sqlCmd.ExecuteNonQuery();
                        string sqlGo = "INSERT INTO namedirect (name) VALUES ";
                        foreach (string item in data)
                        {
                            sqlGo += "( '" + item + "' ),";
                        }
                        sqlGo = sqlGo.Remove(sqlGo.Length - 1);
                        try
                        {
                            m_sqlCmd.CommandText = sqlGo;
                            m_sqlCmd.ExecuteNonQuery();
                            m_dbConn.Close();
                        }
                        catch (SQLiteException)
                        {
                            Messege messege = new Messege("Ошибка соединения с базой данных");
                            messege.Show();
                            
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Messege messege = new Messege("Ошибка соединения с роботом. Возможно отсутствует подключение к Интернету");
                        messege.Show();
                       
                    }

                    catch (SQLiteException)
                    {
                        Messege messege = new Messege("Ошибка соединения с базой данных");
                        messege.Show();
                    }
                }
            }
            catch (NullReferenceException) 
            {
                Messege messege = new Messege("Ошибка соединения с роботом. Возможно отсутствует подключение к Интернету");
                messege.Show();
            }
        }                      
        public class RootObject
        {          
            public List<string> stringNameNapr { get; set; }
        }
        private void SelectListOfPathsInOpenFileDialog(out List<string> listFiles)
        {
            listFiles = new List<string>();
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    listFiles.Add(file);
                }
               
            }
            else return;
          
        }
        private void InitializeOpenFileDialog(string Filter, string Title) {
            this.openFileDialog1.Filter = Filter;
            this.openFileDialog1.Title = Title;
        }          
        private string VRKExcelAndClearList() {
         
            string cmd = @"UiRobot.exe connect --url "+Properties.Settings.Default.URLUiPath +" --key "+ Properties.Settings.Default.KeyMachine;
            string pathStringExcel = JsonConvert.SerializeObject(pathsExcel, Formatting.None);
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string cmd1 = @"UiRobot.exe execute --process VKRExcel --input " + "\"" + "{" + "\'" + "pathStringExcel" + "\'" + ": " + pathStringExcel.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + "\'" + "pathFolder" + "\'" + ": " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"") + "}\"";
            var proc = new ProcessStartInfo()
             {
                 UseShellExecute = true,
                 WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString(),
                 FileName = "cmd.exe",
                 Arguments = "/c " + cmd,
                 WindowStyle = ProcessWindowStyle.Hidden
             };
            Process.Start(proc);                       
            ProcessStartInfo startInfo = new ProcessStartInfo();                         
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardError = true;
                startInfo.WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString();      
                startInfo.FileName  = "cmd.exe";
                startInfo.Arguments = "/c " + cmd1;
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
                string json = srIncoming.ReadToEnd().ToString();
                Console.WriteLine(json);
                return json;
            }
            catch (System.ComponentModel.Win32Exception)
            {                
                Messege messege = new Messege("Возможно, вы указали неверные данные в путях к UiPath Studio");
                messege.Show();
                return "err";
            }
           
        }
        private static void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
            {
                if (!String.IsNullOrEmpty(outLine.Data));
            }
        async Task<string> CompliteCmdAsync() 
        {
            try
            {
                string ans = await Task.Run(() => VRKExcelAndClearList());               
                return ans;
            }
           catch (System.NullReferenceException) 
            {                   
                Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                messege.Show();
                return "err";
            }
            catch (Exception)
            {
                Messege messege = new Messege("Ошибка ответа, попробуйте еще раз");
                messege.Show();
                return "err";
            }
        }       
        private void VRKWordPdfSort(Dictionary<string,string> keysForGroup,List<string> namePredmetsList,bool session)
        {            
            string cmd = @"UiRobot.exe connect --url "+Properties.Settings.Default.URLUiPath+" --key "+ Properties.Settings.Default.KeyMachine;         
            string dabr = JsonConvert.SerializeObject(keysForGroup, Formatting.None);
            string pF = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string wpF = JsonConvert.SerializeObject(pathsWordPdf, Formatting.None);
            string ses = JsonConvert.SerializeObject(!session,Formatting.Indented);
            string nOfD = JsonConvert.SerializeObject(namePredmetsList, Formatting.None);
        
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString(),
                FileName = "cmd.exe",
                Arguments = "/C " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };
           
            Process.Start(proc);
             string cmd1 = @"UiRobot.exe execute --process VKRWord --input " + "\"" + "{" +"\'" + "dabr" + "\'" + ": " + dabr.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " +"\'" + "pF" + "\'" + ": " + pF.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " +"\'" + "wpF" + "\'" + ": " + wpF.Replace("\"", "'").Replace("\\x22", "\\\"") + ", "+ "\'" + "nOfD" + "\'" + ": " + nOfD.Replace("\"", "'").Replace("\\x22", "\\\"") + ", "+ "\'" + "ses" + "\'" + ": " + ses.Replace("\"", "'").Replace("\\x22", "\\\"")+ "}\"";                             
            var proc1 = new ProcessStartInfo()
            {
                UseShellExecute = true,                
                WorkingDirectory = Properties.Settings.Default.PathUIPath.ToString(),
                FileName = "cmd.exe",
                Arguments = "/C " + cmd1,
                WindowStyle = ProcessWindowStyle.Hidden
            };           
            Process.Start(proc1);           
        }     
        private Dictionary<string,string> GoDBForDictionary()
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
            catch (SQLiteException ex)
            {
                Messege messege = new Messege("Для начала создайте сокращения для групп в разделе 'Настройки'");
                messege.Show();                              
                return keys;
            }
            DataTable dTable = new DataTable();
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
            catch (SQLiteException ex)
            {
                Messege messege = new Messege("Произошла ошибка");
                messege.Show();               
                return keys;
            }
        }
        private void MainMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void SettingsItem_Click(object sender, EventArgs e)
        {
           
           if ((Application.OpenForms.OfType<Settings>().Count() != 1))
           {
              settings = new Settings();
              settings.Show();                 
           }
           else
           {
               settings.Focus();
           }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnWordPdf.Enabled = true;
        }

        private void BtnVKRPr_Click(object sender, EventArgs e)
        {
           
        }
        public bool ConnectionAvailable()
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com");  
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {                    
                    rspFP.Close();
                    return true;
                }
                else
                {
                   
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {                
                return false;
            }
        }

        private void WorkVKRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<WordVkrForm>().Count() != 1))
            {
                vkrform = new WordVkrForm();
                vkrform.Show();
            }
            else
            {
                vkrform.Focus();
            }
        }
    }

}
