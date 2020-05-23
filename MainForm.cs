
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

namespace VKRProjectUipath
{

    public partial class MainForm : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        List<string> pathsExcel = new List<string>();
        List<string> pathsWordPdf = new List<string>();
        List<string> nameofDirection = new List<string>();
        string outnameOfDirection = String.Empty;
        public MainForm()
        {
            InitializeComponent();
        }
        
        public class nameList
        {
            public List<string> name { get; set; }
        }
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            InitializeOpenFileDialog("Файлы Excel (*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;)|*.xl*;*.xlsx;*.xlsm;*.xlsb;*.xlam;*.xltx;*.xltm;*.xls;*.xla;*.xlt;*.xlm;*.xlw;", "Выберите Excel файлы учебных планов");
            pathsExcel = GoList(pathsExcel);
            VRKExcelAndClearList();
    
        }
        private List<string> GoList(List<string> paths){
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {

                foreach (String file in openFileDialog1.FileNames)
                {
                    paths.Add(file);
                }
                return paths;
            }
            return paths;
        }
        private void InitializeOpenFileDialog(string Filter, string Title) {
            this.openFileDialog1.Filter = Filter;
            this.openFileDialog1.Title = Title;
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
        
        private async Task VRKExcelAndClearList() {
         
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
                UseShellExecute = false,
                WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/k " + cmd1,
                RedirectStandardOutput = true,
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                StandardOutputEncoding = Encoding.GetEncoding(866)   
            };
            
           Process procCommand = Process.Start(proc1);
            
            //string outs;
            Task<string> outq = procCommand.StandardOutput.ReadToEndAsync();
            outq.Wait();
            Console.WriteLine(outq.Result);
            btnExcel.Text = outq.Result.ToString();
            string outs = Convert.ToString(outq.Result);
          Console.WriteLine(outs.ToString().Replace("\"", "'").Remove(0, 18).Replace("}", ""));
           //outq = outq.ToString().Remove(0, 18).Replace("}", "").Replace(@"\", "");
            //перевод в кириллицу
            nameofDirection = JsonConvert.DeserializeObject<List<string>>(outs.ToString());
            foreach (string item in nameofDirection)
            {
                Console.WriteLine(item);
            }
            pathsExcel.Clear();

        }
        private async Task TaskAsyncForNameofDirections(string outs) 
        {
            nameofDirection = JsonConvert.DeserializeObject<List<string>>(outs);
            foreach (string item in nameofDirection)
            {
                Console.WriteLine(item);
            }           
            pathsExcel.Clear();
        }
        private void VRKWordPdfSort(Dictionary<string,string> pathsWord)
        {
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
            string pathStringWord = JsonConvert.SerializeObject(pathsWord, Formatting.None);
            string pathFolder = JsonConvert.SerializeObject(Properties.Settings.Default.PathStringFolder, Formatting.None);
            string PathStringFileWordPdf = JsonConvert.SerializeObject(pathsWordPdf, Formatting.None);
           //переделать строку и библиотеку WordGo!!!
            string cmd1 = @"UiRobot.exe execute --process VKRExcel --input " + "\"" + "{" + "\'" + "dictionaty" + "\'" + ": " + pathStringWord.Replace("\"", "'").Replace("\\x22", "\\\"") + ", " + "\'" + "pathFolder" + "\'" + ": " + pathFolder.Replace("\"", "'").Replace("\\x22", "\\\"") + "}\"";
            var proc1 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Program Files (x86)\UiPath\Studio",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/k " + cmd1,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(proc1).ToString();
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
        private Dictionary<string,string> GoDB(Dictionary<string,string> keys)
        {
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
                string[] vs;
                sqlQuery = "SELECT little, big FROM namegroup";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    keys.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        keys.Add(dTable.Rows[i].ItemArray[0].ToString(), dTable.Rows[i].ItemArray[1].ToString());
                    }
                    return keys;
                }
                else
                {
                    MessageBox.Show("Добавьте записи в таблицу или загрузите из файла.");
                    return keys;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                return keys;
            }
        }
        private void btnWordPdf_Click(object sender, EventArgs e)
        {
            InitializeOpenFileDialog("Все документы Word и Pdf (*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf;)|*.doc;*.docm;*.dotx;*.dotm;*.doc;*.dot;*.htm;*.html;*.rtf;*.mht;*.mhtml;*.xml;*.odt;*.pdf;", "Выберите Word/Pdf файлы курсовых работ");
            pathsWordPdf = GoList(pathsWordPdf);
            Dictionary<string, string> keysforGr = new Dictionary<string, string>();
            keysforGr = GoDB(keysforGr);
            VRKWordPdfSort(keysforGr);
        }
    }
}
