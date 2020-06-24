using MetroFramework.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKRProjectUipath
{
    public partial class UiPathSettings : MetroForm
    {
        Settings set;
        public UiPathSettings(Settings set)
        {
            InitializeComponent();
            TxtBxURL.Clear();
            TxtBxKey.Clear();
            this.set = set;
            TxtBxURL.Text = Properties.Settings.Default.URLUiPath;
            TxtBxKey.Text = Properties.Settings.Default.KeyMachine;


        }
        private void Save_Click(object sender, EventArgs e)
        {
            set.uipathsettings = this;
            Properties.Settings.Default.URLUiPath = TxtBxURL.Text;
            Properties.Settings.Default.KeyMachine = TxtBxKey.Text;
            Close();
        }
        public string UiPathConnection()
        {

            string cmd = @"UiRobot.exe connect --url " + TxtBxURL.Text + " --key " + TxtBxKey.Text;
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = false,
                WorkingDirectory = Properties.Settings.Default.PathUIPath,
                FileName = "cmd.exe",
                Arguments = "/C" + cmd,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardErrorEncoding = Encoding.GetEncoding(866),
                StandardOutputEncoding = Encoding.GetEncoding(866)
            };

            Process procCommand = new Process();
            procCommand.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
            procCommand.ErrorDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
            procCommand.StartInfo = proc;
            procCommand.Start();
            procCommand.WaitForExit();
            StreamReader srIncoming = procCommand.StandardError;
            string ans = srIncoming.ReadToEnd().ToString();
            string error = srIncoming.ReadToEnd().ToString();
            string code = Convert.ToString(procCommand.ExitCode);
            return ans + error + code;
        }
        private static void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data)) ;
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
        private void BtnConnect_Click(object sender, EventArgs e)
        {

            if ((TxtBxKey.Text == "") || (TxtBxURL.Text == ""))
            {
                Messege messege = new Messege("Заполните все поля");
                messege.Show();
            }
            else
            {
                Task<string> task = CompliteCmdAsync();
                var awaiter = task.GetAwaiter();
                awaiter.OnCompleted(() =>
                {
                    string result = awaiter.GetResult();
                    if (result == "0")
                    {
                        label3.Text = "Успешно";
                        Properties.Settings.Default.URLUiPath = TxtBxURL.Text;
                        Properties.Settings.Default.KeyMachine = TxtBxKey.Text;
                        Properties.Settings.Default.Save();
                        return;
                    }
                    if (result.Contains("По указанному URL-адресу отсутствует Orchestrator. Проверьте ссылку и повторите попытку."))
                    {
                        label3.Text = "Неправильный URL или key machine";
                        return;
                    }
                    if (result.Contains("Orchestrator уже подключен!"))
                    {
                        label3.Text = "Orchestrator уже подключен!";
                        return;
                    }
                    if (result.Contains("-1073741510")) { label3.Text = "Попробуйте еще раз"; return; }
                    if (result.Contains("An error occurred while sending the request.")) { label3.Text = "Ошибка запроса или отсутствует подключение"; return; }
                    else
                    { label3.Text = "Указан неправильный путь к Uipath"; return; }
                });
            }


        }
        async Task<string> CompliteCmdAsync()
        {
            try
            {
                label3.Text = "Загрузка...";
                string ans = await Task.Run(() => UiPathConnection());
                return ans;

            }
            catch (System.NullReferenceException)
            {
                return "err";
            }
            catch (Exception e)
            {
                Messege messege = new Messege(e.ToString());
                messege.Show();
                return "err";
            }
        }

        private void UiPathSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            set.uipathsettings = this;

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void UiPathSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
