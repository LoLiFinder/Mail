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
    public partial class SetServicesForm : Form
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mail.accdb";
        public SetServicesForm()
        {
            InitializeComponent();
        }

        private void SetServicesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT rservices.id, services.name_services, services.price, rservices.FIO, rservices.adres, rservices.nowdate, rservices.index, rservices.rFio, rservices.radres, rservices.rindex, rservices.col, users.login FROM users INNER JOIN(services INNER JOIN rservices ON services.id = rservices.id_services) ON users.id = rservices.id_users;", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Название услуги";
            dataGridView1.Columns[2].HeaderText = "Цена";
            dataGridView1.Columns[3].HeaderText = "ФИО";
            dataGridView1.Columns[4].HeaderText = "Адрес отправителя";
            dataGridView1.Columns[5].HeaderText = "Дата оформления";
            dataGridView1.Columns[6].HeaderText = "Индекс";
            dataGridView1.Columns[7].HeaderText = "ФИО получателя";
            dataGridView1.Columns[8].HeaderText = "Адрес получателя";
            dataGridView1.Columns[9].HeaderText = "Индекс получателя";
            dataGridView1.Columns[10].HeaderText = "Количество";
            dataGridView1.Columns[11].HeaderText = "Оператор";
            connection.Close();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT rservices.id, services.name_services, services.price, rservices.FIO, rservices.adres, rservices.nowdate, rservices.index, rservices.rFio, rservices.radres, rservices.rindex, rservices.col, users.login FROM users INNER JOIN(services INNER JOIN rservices ON services.id = rservices.id_services) ON users.id = rservices.id_users WHERE name_services LIKE \"%"+textBox1.Text + "%\"", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Название услуги";
                dataGridView1.Columns[2].HeaderText = "Цена";
                dataGridView1.Columns[3].HeaderText = "ФИО";
                dataGridView1.Columns[4].HeaderText = "Адрес отправителя";
                dataGridView1.Columns[5].HeaderText = "Дата оформления";
                dataGridView1.Columns[6].HeaderText = "Индекс";
                dataGridView1.Columns[7].HeaderText = "ФИО получателя";
                dataGridView1.Columns[8].HeaderText = "Адрес получателя";
                dataGridView1.Columns[9].HeaderText = "Индекс получателя";
                dataGridView1.Columns[10].HeaderText = "Количество";
                dataGridView1.Columns[11].HeaderText = "Оператор";
                connection.Close();
            }
            else LoadData();
        }
    }
}
