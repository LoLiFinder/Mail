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
    public partial class MainForm : Form
    {

        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mail.accdb";
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(int values)
        {
            InitializeComponent();
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection oleDb = new OleDbConnection(connectionString);
            oleDb.Open();
            OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO services (name_services,price) VALUES ('{0}', '{1}')",textBox1.Text,maskedTextBox1.Text),oleDb);
            command.ExecuteNonQuery();
            MessageBox.Show("Услуга добавлена!");
            textBox1.Clear();
            maskedTextBox1.Clear();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ServicesForm servicesForm = new ServicesForm();
            servicesForm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SetServicesForm form = new SetServicesForm();
            form.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ReportSerices report = new ReportSerices();
            report.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            LogFomr log = new LogFomr();
            log.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ListUser list = new ListUser();
            list.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm();
            addUser.Show();
        }
    }
}
