using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailDB Db = new MailDB();
            switch (Db.authUser(textBox1.Text, textBox2.Text))
            {
                    case User.NoUser: 
                
                    MessageBox.Show("Ошибка доступа.");
                    break;

                case User.Admin:
                    MainForm mainForm = new MainForm();
                    mainForm.Owner = this;
                    mainForm.Show();
                    break;

                case User.Operator:
                    break;

                case User.User:
                    UserForm userForm = new UserForm();
                    userForm.Owner = this;
                    this.Hide();
                    userForm.Show();
                    break;
            }

        }
        
    }
}
