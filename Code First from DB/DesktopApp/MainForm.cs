using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Close the program/form
        }

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Open a form as a dialog box
            ViewRegions frm = new ViewRegions();

            frm.ShowDialog(); // Execution of this method will PAUSE here until the dialog box (ViewRegions) is closed
            // resume after the dialog box is closed

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set the application's startup date/time in the status bar
            StartTimeStatus.Text = "App started on " + DateTime.Now.ToString();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shippersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewShippers theForm = new ViewShippers();
            theForm.MdiParent = this; // Tell the form that I (MainForm) am the parent
            theForm.WindowState = FormWindowState.Maximized;
            theForm.Show(); // we do NOT pause here as we show the form...
            MessageBox.Show("Here's the ViewShipper's form!");
        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void errorLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutThisAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: 1) Open the AboutApp form as a dialog window.
            AboutApp theForm = new AboutApp();
            theForm.Text = "Glad you asked!";
            theForm.ShowDialog(); // we pause in this method until the AboutApp form is closed.

            MessageBox.Show("Thanks for asking!");
        }
    }
}
