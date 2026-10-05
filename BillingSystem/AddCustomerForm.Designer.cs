namespace BillingSystem
{
    partial class AddCustomerFormRei
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
            btnBaack = new Button();
            btnClear = new Button();
            txtAddress = new TextBox();
            lblPassword = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblTitle = new Label();
            btnSave = new Button();
            lblContact = new Label();
            txtContact = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblBalance = new Label();
            txtBalance = new TextBox();
            SuspendLayout();
            // 
            // btnBaack
            // 
            btnBaack.Location = new Point(251, 282);
            btnBaack.Margin = new Padding(3, 2, 3, 2);
            btnBaack.Name = "btnBaack";
            btnBaack.Size = new Size(72, 19);
            btnBaack.TabIndex = 27;
            btnBaack.Text = "Back";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(148, 281);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(83, 22);
            btnClear.TabIndex = 26;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(179, 109);
            txtAddress.Margin = new Padding(3, 2, 3, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.PasswordChar = '*';
            txtAddress.Size = new Size(144, 23);
            txtAddress.TabIndex = 18;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(42, 115);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(55, 15);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "Address :";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(179, 79);
            txtFullName.Margin = new Padding(3, 2, 3, 2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(144, 23);
            txtFullName.TabIndex = 16;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(42, 85);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(67, 15);
            lblFullName.TabIndex = 15;
            lblFullName.Text = "Full Name :";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(78, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 21);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "Add New Customer";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(42, 281);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(83, 22);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(42, 145);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(99, 15);
            lblContact.TabIndex = 19;
            lblContact.Text = "Contact Number:";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(179, 140);
            txtContact.Margin = new Padding(3, 2, 3, 2);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(144, 23);
            txtContact.TabIndex = 22;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(179, 174);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(144, 23);
            txtEmail.TabIndex = 23;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(42, 175);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 15);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "Email :";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(42, 206);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(86, 15);
            lblBalance.TabIndex = 21;
            lblBalance.Text = "Initial Balance :";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(179, 206);
            txtBalance.Margin = new Padding(3, 2, 3, 2);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(144, 23);
            txtBalance.TabIndex = 24;
            txtBalance.TextAlign = HorizontalAlignment.Center;
            // 
            // AddCustomerFormRei
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 326);
            Controls.Add(btnBaack);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(txtBalance);
            Controls.Add(txtEmail);
            Controls.Add(txtContact);
            Controls.Add(lblBalance);
            Controls.Add(lblEmail);
            Controls.Add(lblContact);
            Controls.Add(txtAddress);
            Controls.Add(lblPassword);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddCustomerFormRei";
            Text = "AddCustomerForm";
            Load += AddCustomerFormRei_Load;
            ImeModeChanged += AddCustomerFormRei_ImeModeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBaack;
        private Button btnClear;
        private TextBox txtAddress;
        private Label lblPassword;
        private TextBox txtFullName;
        private Label lblFullName;
        private Label lblTitle;
        private Button btnSave;
        private Label lblContact;
        private TextBox txtContact;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblBalance;
        private TextBox txtBalance;
    }
}