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
    public partial class ListUser : Form
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mail.accdb";
        public ListUser()
        {
            InitializeComponent();
        }

        private void ListUser_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM users;",connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].HeaderText = "Ид пользователя";
            dataGridView1.Columns[1].HeaderText = "Логин";
            dataGridView1.Columns[2].HeaderText = "Пароль";
            dataGridView1.Columns[3].HeaderText = "Уровень доступа";
        }
    }
}
