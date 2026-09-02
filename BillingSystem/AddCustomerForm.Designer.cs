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
            btnBaack = new TextBox();
            btnClear = new Button();
            txtAddress = new TextBox();
            lblPassword = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblTitle = new Label();
            btnSave = new Button();
            lblContact = new Label();
            lbContact = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblBalance = new Label();
            txtBalance = new TextBox();
            SuspendLayout();
            // 
            // btnBaack
            // 
            btnBaack.Location = new Point(358, 470);
            btnBaack.Margin = new Padding(4, 4, 4, 4);
            btnBaack.Name = "btnBaack";
            btnBaack.Size = new Size(103, 31);
            btnBaack.TabIndex = 27;
            btnBaack.Text = "Back";
            btnBaack.TextAlign = HorizontalAlignment.Center;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(211, 468);
            btnClear.Margin = new Padding(4, 4, 4, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(118, 36);
            btnClear.TabIndex = 26;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(256, 182);
            txtAddress.Margin = new Padding(4, 4, 4, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.PasswordChar = '*';
            txtAddress.Size = new Size(204, 31);
            txtAddress.TabIndex = 18;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(60, 191);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 25);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "Address :";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(256, 132);
            txtFullName.Margin = new Padding(4, 4, 4, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(204, 31);
            txtFullName.TabIndex = 16;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(60, 141);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(100, 25);
            lblFullName.TabIndex = 15;
            lblFullName.Text = "Full Name :";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(112, 40);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(236, 32);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "Add New Customer";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(60, 468);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(118, 36);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(60, 242);
            lblContact.Margin = new Padding(4, 0, 4, 0);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(147, 25);
            lblContact.TabIndex = 19;
            lblContact.Text = "Contact Number:";
            // 
            // lbContact
            // 
            lbContact.Location = new Point(256, 234);
            lbContact.Margin = new Padding(4, 4, 4, 4);
            lbContact.Name = "lbContact";
            lbContact.Size = new Size(204, 31);
            lbContact.TabIndex = 22;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(256, 290);
            txtEmail.Margin = new Padding(4, 4, 4, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(204, 31);
            txtEmail.TabIndex = 23;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(60, 291);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 25);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "Email :";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(60, 344);
            lblBalance.Margin = new Padding(4, 0, 4, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(127, 25);
            lblBalance.TabIndex = 21;
            lblBalance.Text = "Initial Balance :";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(256, 344);
            txtBalance.Margin = new Padding(4, 4, 4, 4);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(204, 31);
            txtBalance.TabIndex = 24;
            txtBalance.TextAlign = HorizontalAlignment.Center;
            // 
            // AddCustomerFormRei
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 544);
            Controls.Add(btnBaack);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(txtBalance);
            Controls.Add(txtEmail);
            Controls.Add(lbContact);
            Controls.Add(lblBalance);
            Controls.Add(lblEmail);
            Controls.Add(lblContact);
            Controls.Add(txtAddress);
            Controls.Add(lblPassword);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 4, 4, 4);
            Name = "AddCustomerFormRei";
            Text = "AddCustomerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox btnBaack;
        private Button btnClear;
        private TextBox txtAddress;
        private Label lblPassword;
        private TextBox txtFullName;
        private Label lblFullName;
        private Label lblTitle;
        private Button btnSave;
        private Label lblContact;
        private TextBox lbContact;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblBalance;
        private TextBox txtBalance;
    }
}