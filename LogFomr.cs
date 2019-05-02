using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Mail
{
    public partial class LogFomr : Form
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mail.accdb";
        public LogFomr()
        {
            InitializeComponent();
        }

        private void LogFomr_Load(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection(connectionString);
            connect.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT logOP.id, logOP.actionOP, logOP.nowdate, users.login FROM users INNER JOIN logOP ON users.id = logOP.id_users;",connect);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "Ид операции";
            dataGridView1.Columns[1].HeaderText = "Дейтвие";
            dataGridView1.Columns[2].HeaderText = "Время";
            dataGridView1.Columns[3].HeaderText = "Пользователь";

        }
    }
}
