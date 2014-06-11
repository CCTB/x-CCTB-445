namespace DesktopApp
{
    partial class ViewShippers
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboShippers = new System.Windows.Forms.ComboBox();
            this.btnLookupShipper = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShipperID = new System.Windows.Forms.Label();
            this.CompanyName = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddShipper = new System.Windows.Forms.Button();
            this.UpdateShipper = new System.Windows.Forms.Button();
            this.DeleteShipper = new System.Windows.Forms.Button();
            this.ClearForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shippers";
            // 
            // cboShippers
            // 
            this.cboShippers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShippers.FormattingEnabled = true;
            this.cboShippers.Location = new System.Drawing.Point(65, 13);
            this.cboShippers.Name = "cboShippers";
            this.cboShippers.Size = new System.Drawing.Size(121, 21);
            this.cboShippers.TabIndex = 1;
            // 
            // btnLookupShipper
            // 
            this.btnLookupShipper.Location = new System.Drawing.Point(192, 13);
            this.btnLookupShipper.Name = "btnLookupShipper";
            this.btnLookupShipper.Size = new System.Drawing.Size(110, 23);
            this.btnLookupShipper.TabIndex = 2;
            this.btnLookupShipper.Text = "Lookup Shipper";
            this.btnLookupShipper.UseVisualStyleBackColor = true;
            this.btnLookupShipper.Click += new System.EventHandler(this.btnLookupShipper_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shipper ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Company Name";
            // 
            // ShipperID
            // 
            this.ShipperID.AutoSize = true;
            this.ShipperID.Location = new System.Drawing.Point(97, 58);
            this.ShipperID.Name = "ShipperID";
            this.ShipperID.Size = new System.Drawing.Size(58, 13);
            this.ShipperID.TabIndex = 5;
            this.ShipperID.Text = "-shipper-id-";
            // 
            // CompanyName
            // 
            this.CompanyName.Location = new System.Drawing.Point(100, 78);
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new System.Drawing.Size(100, 20);
            this.CompanyName.TabIndex = 6;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(100, 104);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(100, 20);
            this.Phone.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phone";
            // 
            // AddShipper
            // 
            this.AddShipper.Location = new System.Drawing.Point(10, 140);
            this.AddShipper.Name = "AddShipper";
            this.AddShipper.Size = new System.Drawing.Size(75, 23);
            this.AddShipper.TabIndex = 9;
            this.AddShipper.Text = "Add";
            this.AddShipper.UseVisualStyleBackColor = true;
            this.AddShipper.Click += new System.EventHandler(this.AddShipper_Click);
            // 
            // UpdateShipper
            // 
            this.UpdateShipper.Location = new System.Drawing.Point(91, 140);
            this.UpdateShipper.Name = "UpdateShipper";
            this.UpdateShipper.Size = new System.Drawing.Size(75, 23);
            this.UpdateShipper.TabIndex = 10;
            this.UpdateShipper.Text = "Update";
            this.UpdateShipper.UseVisualStyleBackColor = true;
            this.UpdateShipper.Click += new System.EventHandler(this.UpdateShipper_Click);
            // 
            // DeleteShipper
            // 
            this.DeleteShipper.Location = new System.Drawing.Point(172, 139);
            this.DeleteShipper.Name = "DeleteShipper";
            this.DeleteShipper.Size = new System.Drawing.Size(75, 23);
            this.DeleteShipper.TabIndex = 11;
            this.DeleteShipper.Text = "Delete";
            this.DeleteShipper.UseVisualStyleBackColor = true;
            this.DeleteShipper.Click += new System.EventHandler(this.DeleteShipper_Click);
            // 
            // ClearForm
            // 
            this.ClearForm.Location = new System.Drawing.Point(253, 139);
            this.ClearForm.Name = "ClearForm";
            this.ClearForm.Size = new System.Drawing.Size(75, 23);
            this.ClearForm.TabIndex = 12;
            this.ClearForm.Text = "Clear";
            this.ClearForm.UseVisualStyleBackColor = true;
            this.ClearForm.Click += new System.EventHandler(this.ClearForm_Click);
            // 
            // ViewShippers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 189);
            this.Controls.Add(this.ClearForm);
            this.Controls.Add(this.DeleteShipper);
            this.Controls.Add(this.UpdateShipper);
            this.Controls.Add(this.AddShipper);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.CompanyName);
            this.Controls.Add(this.ShipperID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLookupShipper);
            this.Controls.Add(this.cboShippers);
            this.Controls.Add(this.label1);
            this.Name = "ViewShippers";
            this.Text = "View/Edit Shippers";
            this.Load += new System.EventHandler(this.ViewShippers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboShippers;
        private System.Windows.Forms.Button btnLookupShipper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ShipperID;
        private System.Windows.Forms.TextBox CompanyName;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddShipper;
        private System.Windows.Forms.Button UpdateShipper;
        private System.Windows.Forms.Button DeleteShipper;
        private System.Windows.Forms.Button ClearForm;
    }
}