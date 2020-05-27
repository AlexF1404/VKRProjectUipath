
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

namespace VKRProjectUipath
{
    public partial class MainForm : Form
    {         
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        List<string> pathsExcel = new List<string>();
        List<string> pathsWordPdf = new List<string>();
        List<string> jsonAnswer = new List<string>();
        
      
        public MainForm()
        {
            InitializeComponent();
           
        }
      
        
        private void BtnExcel_Click(object sender, EventArgs e)
        {    
            pathsExcel.Clear();                  
            InitializeOpenFileDialog("Файлы Excel (*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;", "Выберите Excel файлы учебных планов");          
            pathsExcel = selectListOfPathsInOpenFileDialog();
          
            if (pathsExcel.Count > 0)
            {
                Task<string> task = CompliteCmdAsync();
                var awaiter = task.GetAwaiter();
                awaiter.OnCompleted(() =>
                {
                    string result = awaiter.GetResult();
                    Console.WriteLine("222"+ result);
                    var json = JsonConvert.DeserializeObject<RootObject>(result.ToString());
                    
                   /* jsonAnswer = json.stringNameNapr;
                    if (awaiter.IsCompleted)
                    {
                        AddDBNameOfDirection(jsonAnswer);
                    }*/
                }
                );                                             
            }
           
            else return;
        }
        
        private void btnWordPdf_Click(object sender, EventArgs e)
        {
            InitializeOpenFileDialog("Все документы Word и Pdf (*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf;)|*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf;", "Выберите Word/Pdf файлы курсовых работ");
            pathsWordPdf = selectListOfPathsInOpenFileDialog();
            Dictionary<string, string> keysforGr = GoDBForDictionary();
            foreach (KeyValuePair<string, string> keys in keysforGr)
            {
                Console.WriteLine(keys.Key);
                Console.WriteLine(keys.Value);
            }
            List<string> nameOfPredmets = GetNameOfPredmets();
            VRKWordPdfSort(keysforGr,nameOfPredmets);
        }
        private List<string> GetNameOfPredmets() 
        {
            string dbFileNames = "dbForNameGroup";
            string tableName = "namedirect";
            SQLiteConnection m_dbConn = OpenOrCreateDataBase(dbFileNames,tableName);
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
                    Console.WriteLine("LOL "+ dTable.Rows[i].Field<string>(1));
                }
                return nameofDirectionToBe;
            }
            return nameofDirectionToBe;

        }
        private SQLiteConnection OpenOrCreateDataBase(string DbName,string TableName)
        {
            SQLiteConnection m_dbConn = new SQLiteConnection();
            SQLiteCommand m_sqlCmd = new SQLiteCommand();
            string dbFileNames = DbName;
            if (!File.Exists(dbFileNames))
            {
                SQLiteConnection.CreateFile(dbFileNames);
                Console.WriteLine("БЫЛ СОЗДАН");
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
                MessageBox.Show("");
                return m_dbConn;
            }
           
        }
        private void AddDBNameOfDirection(List<string> addNameOfPredmets)
        {
            if (addNameOfPredmets != null)
            {

                List<string> namePredmetsToBe = GetNameOfPredmets();


                foreach (string item in addNameOfPredmets)
                {
                    if (!namePredmetsToBe.Contains(item))
                    {
                        namePredmetsToBe.Add(item);
                    }
                }

                try
                {
                    string dbFileNames = "dbForNameGroup";
                    string tableName = "namedirect";
                    SQLiteConnection m_dbConn = OpenOrCreateDataBase(dbFileNames, tableName);
                    SQLiteCommand m_sqlCmd = new SQLiteCommand();

                    m_sqlCmd.Connection = m_dbConn;
                    string sqlrefresh = "DELETE FROM namedirect";
                    m_sqlCmd.CommandText = sqlrefresh;
                    m_sqlCmd.ExecuteNonQuery();


                    string sqlGo = "INSERT INTO namedirect (name) VALUES ";
                    foreach (string item in namePredmetsToBe)
                    {
                        sqlGo += "( '" + item + "' ),";
                        Console.WriteLine("KYK" + item);
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
                        MessageBox.Show("Ваша база пуста. Добавьте записи.");

                    }
                }

                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);

                }
            }
        }
        
        
        public class RootObject
        {           
            public List<string> stringNameNapr { get; set; }
        }
        private List<string> selectListOfPathsInOpenFileDialog(){
            List<string> listFiles = new List<string>();
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {

                foreach (string file in openFileDialog1.FileNames)
                {
                    listFiles.Add(file);
                }
                return listFiles;
            }
            return listFiles;
        }
        private void InitializeOpenFileDialog(string Filter, string Title) {
            this.openFileDialog1.Filter = Filter;
            this.openFileDialog1.Title = Title;
        }          
        private string VRKExcelAndClearList() {
         
          string cmd = @"UiRobot.exe connect --url https://cloud.uipath.com/alexcompany/AlexCompanyDefault --key 51595987-ee0a-426e-9cae-bd63f34311be";
            string pathStringExcel = JsonConvert.SerializeObject(pathsExcel, Formatting.None);
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string cmd1 = @"UiRobot.exe execute --process VKRExcel --input " + "\"" + "{" + "\'" + "pathStringExcel" + "\'" + ": " + pathStringExcel.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + "\'" + "pathFolder" + "\'" + ": " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"") + "}\"";
            var proc = new ProcessStartInfo()
             {
                 UseShellExecute = true,
                 WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                 FileName = @"C:\Windows\System32\cmd.exe",
                 Arguments = "/c " + cmd,
                 WindowStyle = ProcessWindowStyle.Hidden
             };
            Process.Start(proc);                       
            ProcessStartInfo startInfo = new ProcessStartInfo();                         
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardError = true;
                startInfo.WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio";
                startInfo.FileName  = @"C:\Windows\System32\cmd.exe";
                startInfo.Arguments = "/c " + cmd1;
                startInfo.CreateNoWindow = true;              
                startInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            Process procCommand = new Process();
               procCommand.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
               procCommand.ErrorDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
               procCommand.StartInfo = startInfo;
               procCommand.Start();
               procCommand.WaitForExit();           
            StreamReader srIncoming = procCommand.StandardOutput;
            Console.WriteLine("wwww+   "+srIncoming.ReadToEnd().ToString());
            return srIncoming.ReadToEnd();
        }
        private void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
            {
                if (!String.IsNullOrEmpty(outLine.Data));
            }
        Task<string> CompliteCmdAsync() 
        {
            return Task.Run(() => VRKExcelAndClearList());
        }
       
        private void VRKWordPdfSort(Dictionary<string,string> keysForGroup,List<string> namePredmetsList)
        {            
            string cmd = @"UiRobot.exe connect --url https://cloud.uipath.com/alexcompany/AlexCompanyDefault --key 51595987-ee0a-426e-9cae-bd63f34311be";
            string dictionaryabrv = JsonConvert.SerializeObject(keysForGroup, Formatting.None);
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string PathStringFileWordPdf = JsonConvert.SerializeObject(pathsWordPdf, Formatting.None);
            string NameOfDisciplinString = JsonConvert.SerializeObject(namePredmetsList, Formatting.None);
            Console.WriteLine("1 " + NameOfDisciplinString.Replace("\"", "'").Replace("\\x22", "\\\""));
            Console.WriteLine("2" + dictionaryabrv.Replace("\"", "'").Replace("\\x22", "\\\""));
            Console.WriteLine("3 " + PathStringFileWordPdf.Replace("\"", "'").Replace("\\x22", "\\\""));
            Console.WriteLine("4 " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\""));
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(proc);
                       string cmd1 = @"UiRobot.exe execute --process VKRWord --input " + "\"" + "{" +
                "\'" + "dictionaryabrv" + "\'" + ": " + dictionaryabrv.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + 
                "\'" + "pathFolder" + "\'" + ": " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"")+ ", " + 
                "\'" + "wordpathsFiles" + "\'" + ": " + PathStringFileWordPdf.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " 
                + "\'" + "nameOfDisciplin" + "\'" + ": " + NameOfDisciplinString.Replace("\"", "'").Replace("\\x22", "\\\"") 
                + "}\"";                    
            var proc1 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd1,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(proc1);           
        }
        private void mainMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void settingsItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
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
                MessageBox.Show("Для начала создайте сокращения для групп в разделе 'Настройки'");
                return keys;
            }
            DataTable dTable = new DataTable();
            String sqlQuery;

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Попробуйте еще раз");
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
                        keys.Add(dTable.Rows[i].ItemArray[0].ToString(), dTable.Rows[i].ItemArray[1].ToString());
                    }
                    return keys;
                }
                else
                {
                    MessageBox.Show("Добавьте записи в таблицу или загрузите их из файла.");
                    return keys;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                return keys;
            }
        }
      
    }
}
