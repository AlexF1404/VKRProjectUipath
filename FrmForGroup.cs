using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace VKRProjectUipath
{
    public partial class FrmForGroup : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        public FrmForGroup()
        {
            InitializeComponent();
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Columns[0].Frozen = true;
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
            catch (SQLiteException ex)
            {                
                MessageBox.Show("Ошибка соединения с базой данных: " + ex.Message);
            }
            DataTable dTable = new DataTable();
            String sqlQuery;

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                sqlQuery = "SELECT little, big FROM namegroup";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                        dataGridView1.Rows.Add(dTable.Rows[i].ItemArray);
                }
                else
                    MessageBox.Show("Добавьте записи в таблицу или загрузите из файла.");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlrefresh = "DELETE FROM namegroup";
            m_sqlCmd.CommandText = sqlrefresh;
            m_sqlCmd.ExecuteNonQuery();
            string sqlGo= @"INSERT INTO namegroup(little, big) VALUES ";
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++) 
            {
                sqlGo += "( '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' , '" + dataGridView1.Rows[i].Cells[1].Value.ToString()+"' ),";
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
                return;
            }
            Close();
        }   
        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }

        }
        private void FrmForGroup_Closing(object sender, FormClosingEventArgs e)
        {            
            DialogResult result = MessageBox.Show(
            "Закрыть без сохранения?",
            "Все данные будут утеряны!",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.OK)
            {
                e.Cancel = false ;               
            }
            else 
            {
                e.Cancel = true;
            }
        }
    }
}
