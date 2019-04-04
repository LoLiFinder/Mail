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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
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
            
            Owner = null;
        }
    }
}
