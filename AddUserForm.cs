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
    public partial class AddUserForm : Form
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mail.accdb";
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                int index = comboBox1.SelectedIndex + 1;
                OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO users (login,pass,level_access) VALUES ('{0}','{1}',{2})",textBox1.Text,textBox2.Text,index), connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Пользователь успешно добавлен!");
               
            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}
