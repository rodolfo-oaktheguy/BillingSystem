namespace BillingSystem
{
    partial class frmChangePassword
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCurrent = new Label();
            lblNew = new Label();
            lblRetype = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtRetypePassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(98, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(166, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Change Password";
            //
            // lblCurrent
            //
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(25, 63);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(104, 15);
            lblCurrent.TabIndex = 1;
            lblCurrent.Text = "Current Password:";
            //
            // lblNew
            //
            lblNew.AutoSize = true;
            lblNew.Location = new Point(25, 103);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(84, 15);
            lblNew.TabIndex = 3;
            lblNew.Text = "New Password:";
            //
            // lblRetype
            //
            lblRetype.AutoSize = true;
            lblRetype.Location = new Point(25, 143);
            lblRetype.Name = "lblRetype";
            lblRetype.Size = new Size(96, 15);
            lblRetype.TabIndex = 5;
            lblRetype.Text = "Retype Password:";
            //
            // txtCurrentPassword
            //
            txtCurrentPassword.Location = new Point(155, 60);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '*';
            txtCurrentPassword.Size = new Size(185, 23);
            txtCurrentPassword.TabIndex = 2;
            //
            // txtNewPassword
            //
            txtNewPassword.Location = new Point(155, 100);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(185, 23);
            txtNewPassword.TabIndex = 4;
            //
            // txtRetypePassword
            //
            txtRetypePassword.Location = new Point(155, 140);
            txtRetypePassword.Name = "txtRetypePassword";
            txtRetypePassword.PasswordChar = '*';
            txtRetypePassword.Size = new Size(185, 23);
            txtRetypePassword.TabIndex = 6;
            //
            // btnSave
            //
            btnSave.Location = new Point(70, 190);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 28);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save Password";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            //
            // btnCancel
            //
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(195, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 28);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            //
            // frmChangePassword
            //
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(365, 240);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtRetypePassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblRetype);
            Controls.Add(lblNew);
            Controls.Add(lblCurrent);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrent;
        private Label lblNew;
        private Label lblRetype;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtRetypePassword;
        private Button btnSave;
        private Button btnCancel;
    }
}
