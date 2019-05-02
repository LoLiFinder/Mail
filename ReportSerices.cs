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
    public partial class ReportSerices : Form
    {
        public ReportSerices()
        {
            InitializeComponent();
        }

        private void ReportSerices_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mailDataSet.FinalRes". При необходимости она может быть перемещена или удалена.
            this.FinalResTableAdapter.Fill(this.mailDataSet.FinalRes);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
