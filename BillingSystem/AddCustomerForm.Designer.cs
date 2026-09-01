namespace BillingSystem
{
    partial class AddCustomerForm
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
            btnBaack.Location = new Point(286, 376);
            btnBaack.Name = "btnBaack";
            btnBaack.Size = new Size(83, 27);
            btnBaack.TabIndex = 27;
            btnBaack.Text = "Back";
            btnBaack.TextAlign = HorizontalAlignment.Center;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(169, 374);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 26;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(205, 146);
            txtAddress.Name = "txtAddress";
            txtAddress.PasswordChar = '*';
            txtAddress.Size = new Size(164, 27);
            txtAddress.TabIndex = 18;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(48, 153);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(69, 20);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "Address :";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(205, 106);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(164, 27);
            txtFullName.TabIndex = 16;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(48, 113);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(83, 20);
            lblFullName.TabIndex = 15;
            lblFullName.Text = "Full Name :";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(90, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(195, 28);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "Add New Customer";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(48, 374);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(48, 194);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(121, 20);
            lblContact.TabIndex = 19;
            lblContact.Text = "Contact Number:";
            // 
            // lbContact
            // 
            lbContact.Location = new Point(205, 187);
            lbContact.Name = "lbContact";
            lbContact.Size = new Size(164, 27);
            lbContact.TabIndex = 22;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(205, 232);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(164, 27);
            txtEmail.TabIndex = 23;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(48, 233);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 20);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "Email :";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(48, 275);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(109, 20);
            lblBalance.TabIndex = 21;
            lblBalance.Text = "Initial Balance :";
            // 
            // txtBalance
            // 
            txtBalance.Location = new Point(205, 275);
            txtBalance.Name = "txtBalance";
            txtBalance.Size = new Size(164, 27);
            txtBalance.TabIndex = 24;
            txtBalance.TextAlign = HorizontalAlignment.Center;
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 435);
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
            Name = "AddCustomerForm";
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