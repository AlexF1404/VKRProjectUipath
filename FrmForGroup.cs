using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace VKRProjectUipath
{
    public partial class FrmForGroup : MetroForm
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        private DataTable thisDT = new DataTable();
        private DataTable dTable = new DataTable();
        Settings settings;
        bool save = false;

        public FrmForGroup(Settings set)
        {
            InitializeComponent();
            settings = set;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Columns[0].Frozen = true;
            btnSave.Enabled = false;
        }
        private void FrmForGroup_Load(object sender, EventArgs e)
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
            catch (SQLiteException)
            {
                Messege messege = new Messege("Ошибка соединения с базой данных");
                messege.Show();
                return;
            }

            String sqlQuery;
            try
            {
                sqlQuery = "SELECT little, big FROM namegroup";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                thisDT = dTable;
                if (dTable.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(dTable.Rows[i].ItemArray);
                    }
                }
                else
                {

                }


            }
            catch (SQLiteException ex)
            {
                Messege messege = new Messege(ex.Message);
                messege.Show();

            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            save = false;
            SaveInDataBase();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                    {
                        dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    }
                }
                else return;
            }
            catch (InvalidOperationException) { return; }
            btnSave.Enabled = true;
            save = true;

        }
        public void SaveInDataBase()
        {
            string sqlrefresh = "DELETE FROM namegroup";
            m_sqlCmd.CommandText = sqlrefresh;
            m_sqlCmd.ExecuteNonQuery();
            string sqlGo = @"INSERT INTO namegroup(little, big) VALUES ";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sqlGo += "( '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' , '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' ),";

            }
            sqlGo = sqlGo.Remove(sqlGo.Length - 1);
            try
            {
                m_sqlCmd.CommandText = sqlGo;
                m_sqlCmd.ExecuteNonQuery();
                dTable = (DataTable)dataGridView1.DataSource;
                dTable.AcceptChanges();

                thisDT = dTable;
            }
            catch (SQLiteException)
            {
                Messege messege = new Messege("Ваша база пуста. Добавьте записи");
                messege.Show();
                return;
            }
            catch (System.NullReferenceException) { return; }
        }
        private void FrmForGroup_Closing(object sender, FormClosingEventArgs e)
        {
            if (save == true)
            {
                Warning warning = new Warning("Закрыть без сохранения?\nВсе несохраненные данные будут утеряны!");
                warning.ShowDialog();
                DialogResult result = warning.DialogResult;

                if (result == DialogResult.OK)
                {
                    e.Cancel = false;
                    settings.frmForGroup = this;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private void InitializeOpenFileDialog(string Filter, string Title)
        {
            this.openFileDialog1.Filter = Filter;
            this.openFileDialog1.Title = Title;
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
            save = true;
            thisDT = (DataTable)dataGridView1.DataSource;
        }
        private class Group
        {
            [JsonProperty("nameGr")]
            public Dictionary<string, string> nameGr { get; set; }
        }

        private void Bnt_SaveInFile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 1)
            {
                Group savenameGr = new Group();
                string SelectFolder = "";
                Dictionary<string, string> name = new Dictionary<string, string>();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    SelectFolder = folderBrowserDialog1.SelectedPath;
                }
                else { return; }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (name.ContainsKey(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                    {
                        name[dataGridView1.Rows[i].Cells[0].Value.ToString()] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    }
                    else
                    {
                        name.Add(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                }
                savenameGr.nameGr = name;
                string jsonNameGroup = JsonConvert.SerializeObject(savenameGr.nameGr, Formatting.None);

                try
                {
                    using (StreamWriter sw = new StreamWriter(SelectFolder + "\\NameGroup.json", false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("{ nameGr: " + jsonNameGroup + " }");
                    }
                }
                catch (System.UnauthorizedAccessException)
                {
                    Messege messege = new Messege("Попробуйте сохранить в папку без прав администратора");
                    messege.Show();
                }
            }
            else
            {
                Messege messege = new Messege("Таблица пуста");
                messege.Show();
            }

        }

        private void Btn_GivOutFile_Click(object sender, EventArgs e)
        {
            try
            {
                Warning warning = new Warning("Все данные из таблицы будут перезаписаны!");
                warning.ShowDialog();
                DialogResult result = warning.DialogResult;

                if (result == DialogResult.OK)
                {
                    InitializeOpenFileDialog("Json файл (*.json*;|*.json*;", "Выберите файл с сокращениями групп");
                    string SelectFolder = "";
                    string jsonpath = "";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        SelectFolder = openFileDialog1.FileName;
                    }
                    if (SelectFolder != "")
                    {

                        using (StreamReader sw = new StreamReader(SelectFolder))
                        {
                            jsonpath = sw.ReadToEnd();

                        }
                    }

                    Group group = JsonConvert.DeserializeObject<Group>(jsonpath);
                    dataGridView1.Rows.Clear();
                    foreach (KeyValuePair<string, string> entry in group.nameGr)
                    {

                        dataGridView1.Rows.Add(entry.Key, entry.Value);
                    }
                    btnSave.Enabled = true;
                    save = true;
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                Messege messege = new Messege("Данный файл имеет другой формат");
                messege.Show();
            }

        }


    }
}
