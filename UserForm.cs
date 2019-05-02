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
    public partial class UserForm : Form
    {
        private static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mail.accdb";
        private string loginUser;
        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(string loginUser)
        {
            InitializeComponent();
            this.loginUser = loginUser;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mailDataSet.services". При необходимости она может быть перемещена или удалена.
            this.servicesTableAdapter.Fill(this.mailDataSet.services);
            LoadComboBoxData();
        }


        private void LoadComboBoxData()
        {
            MailDB mail = new MailDB();
            List<Services> list = mail.LoadListService();
            
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Завершить работу?", "Выход.", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {

                e.Cancel = true;

            }
            else {
                var db = new MailDB();
                db.logautUser(loginUser);
                this.Owner.Show();
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text) && !String.IsNullOrEmpty(maskedTextBox3.Text))
            {
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbCommand comand = new OleDbCommand(String.Format("SELECT id FROM users WHERE login='{0}';", loginUser), connection);
                OleDbDataReader reader = comand.ExecuteReader();
                reader.Read();
                int id_user = (int) reader[0];
                reader.Close();
                OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO rservices (id_services,FIO,adres," +
                    "[index],rFio,radres,rindex,col,id_users) VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})",
                    comboBox1.SelectedValue,textBox1.Text,textBox2.Text,maskedTextBox1.Text,textBox3.Text,textBox4.Text,maskedTextBox2.Text,maskedTextBox3.Text,id_user),connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Услуга оформлена");
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            } else MessageBox.Show("Заполните обязательные поля");
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int total = 0;
            float cash = 200;
            float change = 0.00f;

            

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); 

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Почта РБ", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            string top = "Наименование услуги".PadRight(30) + "Цена";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight;
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; 

            float totalprice = 0.00f;


            
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            OleDbCommand comand = new OleDbCommand(String.Format("SELECT * FROM services WHERE id={0}", comboBox1.SelectedValue), connection);
            OleDbDataReader reader = comand.ExecuteReader();
            reader.Read();
            string productLine = reader[1].ToString();
            totalprice += (float) Convert.ToDouble(reader[3]);
            graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)fontHeight + 5;

            change = (cash - totalprice);

          

            offset = offset + 20; 

            graphic.DrawString("Общая цена ".PadRight(30) + String.Format("{0:c}", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; 
            
            offset = offset + 15;
            
            offset = offset + 30; 
            graphic.DrawString("     Спасибо за вашу покупку,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("       возвращайтесь ещё", font, new SolidBrush(Color.Black), startX, startY + offset);
        }
    }
}
