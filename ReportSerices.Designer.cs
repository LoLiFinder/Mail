namespace Mail
{
    partial class ReportSerices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FinalResBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mailDataSet = new Mail.mailDataSet();
            this.FinalResTableAdapter = new Mail.mailDataSetTableAdapters.FinalResTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FinalResBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FinalResBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mail.ReportSamp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 426);
            this.reportViewer1.TabIndex = 0;
            // 
            // FinalResBindingSource
            // 
            this.FinalResBindingSource.DataMember = "FinalRes";
            this.FinalResBindingSource.DataSource = this.mailDataSet;
            // 
            // mailDataSet
            // 
            this.mailDataSet.DataSetName = "mailDataSet";
            this.mailDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FinalResTableAdapter
            // 
            this.FinalResTableAdapter.ClearBeforeFill = true;
            // 
            // ReportSerices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportSerices";
            this.Text = "Отчет об оформленых услугах";
            this.Load += new System.EventHandler(this.ReportSerices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FinalResBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FinalResBindingSource;
        private mailDataSet mailDataSet;
        private mailDataSetTableAdapters.FinalResTableAdapter FinalResTableAdapter;
    }
}