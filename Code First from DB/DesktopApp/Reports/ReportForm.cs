using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthWindSystem.Entities.POCOS;

namespace DesktopApp.Reports
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerOrderSummary> list = new NorthwindManager().GetCustomerOrderSummaries();

                reportViewer1.LocalReport.DataSources.Clear(); //clear report

                // NOTE: reportViewer1.LocalReport.ReportEmbeddedResource = "<application namespace>.[optional <folder>].<filename.rdlc>"
                // Source: http://social.msdn.microsoft.com/Forums/en-US/5b6cd9bf-baf0-4726-8507-5e732c48dd10/the-report-definition-for-report-xxx-has-not-been-specified?forum=vsreportcontrols

                reportViewer1.LocalReport.ReportEmbeddedResource = "DesktopApp.Reports.Report1.rdlc"; // "Student_ReportViewer.StudentReport.rdlc"; // bind reportviewer with .rdlc

                Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", list); //("NorthwindSystemEntitiesPOCOs", list); //("StudentDS", list); // set the datasource
                reportViewer1.LocalReport.DataSources.Add(dataset);
                dataset.Value = list;

                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }
    }
}
