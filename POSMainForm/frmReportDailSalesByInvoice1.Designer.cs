namespace POSMainForm
{
    partial class frmReportDailSalesByInvoice1
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
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_daily_duration = new POSMainForm.report_daily_duration();
            this.transact_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.btnload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.transactionsTableAdapter = new POSMainForm.report_daily_durationTableAdapters.transactionsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_daily_duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transact_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "transactions";
            this.transactionsBindingSource.DataSource = this.report_daily_duration;
            // 
            // report_daily_duration
            // 
            this.report_daily_duration.DataSetName = "report_daily_duration";
            this.report_daily_duration.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transact_ResultBindingSource
            // 
        //    this.transact_ResultBindingSource.DataSource = typeof(POSMainForm.transact_Result);
            // 
            // reportV
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.transactionsBindingSource;
            this.reportV.LocalReport.DataSources.Add(reportDataSource1);
            this.reportV.LocalReport.ReportEmbeddedResource = "POSMainForm.dynamic report.rdlc";
            this.reportV.Location = new System.Drawing.Point(0, 66);
            this.reportV.Name = "reportV";
            this.reportV.Size = new System.Drawing.Size(1037, 447);
            this.reportV.TabIndex = 0;
            this.reportV.Load += new System.EventHandler(this.reportV_Load);
            // 
            // fromdate
            // 
            this.fromdate.Location = new System.Drawing.Point(137, 22);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(200, 22);
            this.fromdate.TabIndex = 1;
            // 
            // todate
            // 
            this.todate.Location = new System.Drawing.Point(417, 21);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(200, 22);
            this.todate.TabIndex = 2;
            // 
            // btnload
            // 
            this.btnload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnload.Location = new System.Drawing.Point(693, 21);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(71, 39);
            this.btnload.TabIndex = 3;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "TO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "FROM";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportDailSalesByInvoice1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 525);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.todate);
            this.Controls.Add(this.fromdate);
            this.Controls.Add(this.reportV);
            this.Name = "frmReportDailSalesByInvoice1";
            this.Text = "frmReportDailSalesByInvoice1";
            this.Load += new System.EventHandler(this.frmReportDailSalesByInvoice1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_daily_duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transact_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportV;
        private System.Windows.Forms.BindingSource transact_ResultBindingSource;
        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private report_daily_duration report_daily_duration;
        private report_daily_durationTableAdapters.transactionsTableAdapter transactionsTableAdapter;
    }
}