using NorthwindSystem.BLL;
using NorthWindSystem.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.Reports
{
    public partial class ProductSalesForm : Form
    {
        public ProductSalesForm()
        {
            InitializeComponent();
        }

        private void ProductSalesForm_Load(object sender, EventArgs e)
        {
            List<ProductSaleSummary> list = new NorthwindManager().GetProductSaleSummaries();

            reportViewer1.LocalReport.DataSources.Clear(); //clear report

            // NOTE: reportViewer1.LocalReport.ReportEmbeddedResource = 
            //               "<application namespace>.[optional <folder>].<filename.rdlc>"

            reportViewer1.LocalReport.ReportEmbeddedResource = "DesktopApp.Reports.ProductSalesReport.rdlc"; // "Student_ReportViewer.StudentReport.rdlc"; // bind reportviewer with .rdlc

            Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("ProductSalesDataSet", list);  // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset);
            dataset.Value = list;

            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
