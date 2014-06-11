using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthwindSystem.BLL;
using NorthwindSystem.Entities;

namespace DesktopApp
{
    public partial class ViewShippers : Form
    {
        public ViewShippers()
        {
            InitializeComponent();
        }

        private void btnLookupShipper_Click(object sender, EventArgs e)
        {
            try
            {
                // Get data from form
                if (cboShippers.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a shipper before clicking [Lookup]");
                }
                else
                {
                    int shipperId = Convert.ToInt32(cboShippers.SelectedValue);

                    NorthwindManager mgr = new NorthwindManager();
                    Shipper data = mgr.GetShipper(shipperId);

                    // Unpack the data
                    ShipperID.Text = data.ShipperID.ToString();
                    CompanyName.Text = data.CompanyName;
                    Phone.Text = data.Phone;
                }
            }
            catch (Exception ex)
            {
                // TODO: Log exceptoin
                MessageBox.Show(ex.Message);
            }
        }

        private void AddShipper_Click(object sender, EventArgs e)
        {
            try
            {
                Shipper item = new Shipper()
                {
                    CompanyName = CompanyName.Text,
                    Phone = Phone.Text
                };
                var mgr = new NorthwindManager();
                item.ShipperID = mgr.AddShipper(item);
                // Give some feedback to the user...
                // - Update my combo-box
                PopulateShippersComboBox();
                // - My combo-box has the right shipper selected
                cboShippers.SelectedValue = item.ShipperID;
                // - Display the id of the added shipper
                ShipperID.Text = item.ShipperID.ToString();
            }
            catch (Exception ex)
            {
                // TODO: Add logging
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateShipper_Click(object sender, EventArgs e)
        {
            try
            {
                int shipperId;
                if (int.TryParse(ShipperID.Text, out shipperId))
                {
                    // do the update....
                    var info = new Shipper()
                    {
                        ShipperID = shipperId,
                        CompanyName = CompanyName.Text,
                        Phone = Phone.Text
                    };
                    var mgr = new NorthwindManager();
                    mgr.UpdateShipper(info);
                    PopulateShippersComboBox();
                    cboShippers.SelectedValue = info.ShipperID;
                }
                else
                {
                    MessageBox.Show("Please lookup a shipper before trying to update.");
                }
            }
            catch (Exception ex)
            {
                // TODO: Add logging
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteShipper_Click(object sender, EventArgs e)
        {
            try
            {
                int temp;
                if (int.TryParse(ShipperID.Text, out temp))
                {
                    var data = new Shipper() { ShipperID = temp };
                    var mgr = new NorthwindManager();
                    mgr.DeleteShipper(data);
                    // feeback to user
                    PopulateShippersComboBox();
                    // clear the form textboxes
                    ShipperID.Text = "";
                    CompanyName.Text = "";
                    Phone.Text = "";
                }
                else
                {
                    MessageBox.Show("Please lookup a shipper before trying to delete");
                }
            }
            catch (Exception ex)
            {
                // TODO: Add logging
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm_Click(object sender, EventArgs e)
        {

        }

        private void ViewShippers_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox
            try
            {
                PopulateShippersComboBox();
            }
            catch (Exception ex)
            {
                // TODO: Log the exception
                MessageBox.Show("Error: " + ex.Message, "Error Loading Form", MessageBoxButtons.OK);
            }
        }

        private void PopulateShippersComboBox()
        {
            NorthwindManager manager = new NorthwindManager();
            var data = manager.ListShippers();
            // Use a "fake" data item at top of list for the "message"
            data.Insert(0, new Shipper() { ShipperID = -1, CompanyName = "[select a shipper]" });
            cboShippers.DataSource = data;
            cboShippers.DisplayMember = "CompanyName"; // CompanyName is a property of the Shipper class
            cboShippers.ValueMember = "ShipperID"; // ShipperID is the property that represents the Primary Key (uniquely distinguishes each shipper in the database)
            cboShippers.SelectedIndex = 0; // the first item in the combo-box
        }
    }
}
