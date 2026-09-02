namespace BillingSystem
{
    partial class CUSTOMERLISTATUN
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
            lblTitle = new Label();
            dvgCustomers = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            ContactNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Balance = new DataGridViewTextBoxColumn();
            button1 = new Button();
            btnDelete = new Button();
            btnLogout = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dvgCustomers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(41, 24);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Customer List ";
            lblTitle.Click += label1_Click;
            // 
            // dvgCustomers
            // 
            dvgCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvgCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Address, ContactNumber, Email, Balance });
            dvgCustomers.Location = new Point(8, 90);
            dvgCustomers.Margin = new Padding(4, 4, 4, 4);
            dvgCustomers.Name = "dvgCustomers";
            dvgCustomers.ReadOnly = true;
            dvgCustomers.RowHeadersWidth = 51;
            dvgCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgCustomers.Size = new Size(955, 378);
            dvgCustomers.TabIndex = 1;
            dvgCustomers.CellContentClick += dvgCustomers_CellContentClick;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "ID";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.ReadOnly = true;
            // 
            // FullName
            // 
            FullName.HeaderText = "Full Name";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            // 
            // Address
            // 
            Address.HeaderText = "Address";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // ContactNumber
            // 
            ContactNumber.HeaderText = "Contact No.";
            ContactNumber.MinimumWidth = 6;
            ContactNumber.Name = "ContactNumber";
            ContactNumber.ReadOnly = true;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Balance
            // 
            Balance.HeaderText = "Balance";
            Balance.MinimumWidth = 6;
            Balance.Name = "Balance";
            Balance.ReadOnly = true;
            // 
            // button1
            // 
            button1.Location = new Point(206, 500);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(151, 36);
            button1.TabIndex = 2;
            button1.Text = "Add Customer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(404, 500);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(569, 500);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(118, 36);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Delete";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(365, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(248, 38);
            label1.TabIndex = 5;
            label1.Text = "Search : __________";
            label1.Click += label1_Click_1;
            // 
            // CUSTOMERLISTATUN
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 566);
            Controls.Add(label1);
            Controls.Add(btnLogout);
            Controls.Add(btnDelete);
            Controls.Add(button1);
            Controls.Add(dvgCustomers);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 4, 4, 4);
            Name = "CUSTOMERLISTATUN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing System - Customer List";
            Load += CustomerListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dvgCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dvgCustomers;
        private Button button1;
        private Button btnDelete;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn ContactNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Balance;
        private Button btnLogout;
        private Label label1;
    }
}