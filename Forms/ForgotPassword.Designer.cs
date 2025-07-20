namespace eshift_management.Forms
{
    partial class ForgotPasswordForm
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
            this.panelEnterEmail = new System.Windows.Forms.Panel();
            this.labelEmailInstruction = new MaterialSkin.Controls.MaterialLabel();
            this.materialTextBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.buttonContinue = new MaterialSkin.Controls.MaterialButton();
            this.panelVerifyOtp = new System.Windows.Forms.Panel();
            this.labelOtpInstruction = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxOtp = new MaterialSkin.Controls.MaterialTextBox();
            this.buttonVerifyOtp = new MaterialSkin.Controls.MaterialButton();
            this.panelResetPassword = new System.Windows.Forms.Panel();
            this.labelResetInstruction = new MaterialSkin.Controls.MaterialLabel();
            this.materialTextBoxNewPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.materialTextBoxConfirmPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.buttonResetPassword = new MaterialSkin.Controls.MaterialButton();
            this.buttonBackToLogin = new MaterialSkin.Controls.MaterialButton();
            this.panelEnterEmail.SuspendLayout();
            this.panelVerifyOtp.SuspendLayout();
            this.panelResetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEnterEmail
            // 
            this.panelEnterEmail.Controls.Add(this.labelEmailInstruction);
            this.panelEnterEmail.Controls.Add(this.materialTextBoxEmail);
            this.panelEnterEmail.Controls.Add(this.buttonContinue);
            this.panelEnterEmail.Location = new System.Drawing.Point(25, 80);
            this.panelEnterEmail.Name = "panelEnterEmail";
            this.panelEnterEmail.Size = new System.Drawing.Size(350, 200);
            this.panelEnterEmail.TabIndex = 0;
            // 
            // labelEmailInstruction
            // 
            this.labelEmailInstruction.Depth = 0;
            this.labelEmailInstruction.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEmailInstruction.Location = new System.Drawing.Point(15, 15);
            this.labelEmailInstruction.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelEmailInstruction.Name = "labelEmailInstruction";
            this.labelEmailInstruction.Size = new System.Drawing.Size(320, 40);
            this.labelEmailInstruction.TabIndex = 2;
            this.labelEmailInstruction.Text = "Please enter your email address to receive a verification code.";
            // 
            // materialTextBoxEmail
            // 
            this.materialTextBoxEmail.AnimateReadOnly = false;
            this.materialTextBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBoxEmail.Depth = 0;
            this.materialTextBoxEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBoxEmail.Hint = "Your Email Address";
            this.materialTextBoxEmail.LeadingIcon = null;
            this.materialTextBoxEmail.Location = new System.Drawing.Point(15, 70);
            this.materialTextBoxEmail.MaxLength = 50;
            this.materialTextBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBoxEmail.Multiline = false;
            this.materialTextBoxEmail.Name = "materialTextBoxEmail";
            this.materialTextBoxEmail.Size = new System.Drawing.Size(320, 50);
            this.materialTextBoxEmail.TabIndex = 1;
            this.materialTextBoxEmail.Text = "";
            this.materialTextBoxEmail.TrailingIcon = null;
            // 
            // buttonContinue
            // 
            this.buttonContinue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonContinue.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonContinue.Depth = 0;
            this.buttonContinue.HighEmphasis = true;
            this.buttonContinue.Icon = null;
            this.buttonContinue.Location = new System.Drawing.Point(239, 140);
            this.buttonContinue.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonContinue.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonContinue.Size = new System.Drawing.Size(96, 36);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonContinue.UseAccentColor = false;
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // panelVerifyOtp
            // 
            this.panelVerifyOtp.Controls.Add(this.labelOtpInstruction);
            this.panelVerifyOtp.Controls.Add(this.textBoxOtp);
            this.panelVerifyOtp.Controls.Add(this.buttonVerifyOtp);
            this.panelVerifyOtp.Location = new System.Drawing.Point(25, 80);
            this.panelVerifyOtp.Name = "panelVerifyOtp";
            this.panelVerifyOtp.Size = new System.Drawing.Size(350, 200);
            this.panelVerifyOtp.TabIndex = 1;
            //
            // labelOtpInstruction
            //
            this.labelOtpInstruction.Depth = 0;
            this.labelOtpInstruction.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOtpInstruction.Location = new System.Drawing.Point(15, 15);
            this.labelOtpInstruction.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelOtpInstruction.Name = "labelOtpInstruction";
            this.labelOtpInstruction.Size = new System.Drawing.Size(320, 40);
            this.labelOtpInstruction.TabIndex = 2;
            this.labelOtpInstruction.Text = "A verification code has been sent to your email. Please enter it below.";
            // 
            // textBoxOtp
            // 
            this.textBoxOtp.AnimateReadOnly = false;
            this.textBoxOtp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOtp.Depth = 0;
            this.textBoxOtp.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxOtp.Hint = "Enter 6-digit OTP";
            this.textBoxOtp.LeadingIcon = null;
            this.textBoxOtp.Location = new System.Drawing.Point(15, 70);
            this.textBoxOtp.MaxLength = 6;
            this.textBoxOtp.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxOtp.Multiline = false;
            this.textBoxOtp.Name = "textBoxOtp";
            this.textBoxOtp.Size = new System.Drawing.Size(320, 50);
            this.textBoxOtp.TabIndex = 1;
            this.textBoxOtp.Text = "";
            this.textBoxOtp.TrailingIcon = null;
            // 
            // buttonVerifyOtp
            // 
            this.buttonVerifyOtp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonVerifyOtp.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonVerifyOtp.Depth = 0;
            this.buttonVerifyOtp.HighEmphasis = true;
            this.buttonVerifyOtp.Icon = null;
            this.buttonVerifyOtp.Location = new System.Drawing.Point(265, 140);
            this.buttonVerifyOtp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonVerifyOtp.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonVerifyOtp.Name = "buttonVerifyOtp";
            this.buttonVerifyOtp.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonVerifyOtp.Size = new System.Drawing.Size(70, 36);
            this.buttonVerifyOtp.TabIndex = 0;
            this.buttonVerifyOtp.Text = "Verify";
            this.buttonVerifyOtp.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonVerifyOtp.UseAccentColor = false;
            this.buttonVerifyOtp.UseVisualStyleBackColor = true;
            this.buttonVerifyOtp.Click += new System.EventHandler(this.buttonVerifyOtp_Click);
            // 
            // panelResetPassword
            // 
            this.panelResetPassword.Controls.Add(this.labelResetInstruction);
            this.panelResetPassword.Controls.Add(this.materialTextBoxNewPassword);
            this.panelResetPassword.Controls.Add(this.materialTextBoxConfirmPassword);
            this.panelResetPassword.Controls.Add(this.buttonResetPassword);
            this.panelResetPassword.Location = new System.Drawing.Point(25, 80);
            this.panelResetPassword.Name = "panelResetPassword";
            this.panelResetPassword.Size = new System.Drawing.Size(350, 250);
            this.panelResetPassword.TabIndex = 2;
            //
            // labelResetInstruction
            //
            this.labelResetInstruction.Depth = 0;
            this.labelResetInstruction.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelResetInstruction.Location = new System.Drawing.Point(15, 15);
            this.labelResetInstruction.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelResetInstruction.Name = "labelResetInstruction";
            this.labelResetInstruction.Size = new System.Drawing.Size(320, 23);
            this.labelResetInstruction.TabIndex = 3;
            this.labelResetInstruction.Text = "Please enter your new password below.";
            // 
            // materialTextBoxNewPassword
            // 
            this.materialTextBoxNewPassword.AnimateReadOnly = false;
            this.materialTextBoxNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBoxNewPassword.Depth = 0;
            this.materialTextBoxNewPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBoxNewPassword.Hint = "New Password";
            this.materialTextBoxNewPassword.LeadingIcon = null;
            this.materialTextBoxNewPassword.Location = new System.Drawing.Point(15, 50);
            this.materialTextBoxNewPassword.MaxLength = 50;
            this.materialTextBoxNewPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBoxNewPassword.Multiline = false;
            this.materialTextBoxNewPassword.Name = "materialTextBoxNewPassword";
            this.materialTextBoxNewPassword.Password = true;
            this.materialTextBoxNewPassword.Size = new System.Drawing.Size(320, 50);
            this.materialTextBoxNewPassword.TabIndex = 1;
            this.materialTextBoxNewPassword.Text = "";
            this.materialTextBoxNewPassword.TrailingIcon = null;
            // 
            // materialTextBoxConfirmPassword
            // 
            this.materialTextBoxConfirmPassword.AnimateReadOnly = false;
            this.materialTextBoxConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBoxConfirmPassword.Depth = 0;
            this.materialTextBoxConfirmPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBoxConfirmPassword.Hint = "Confirm New Password";
            this.materialTextBoxConfirmPassword.LeadingIcon = null;
            this.materialTextBoxConfirmPassword.Location = new System.Drawing.Point(15, 120);
            this.materialTextBoxConfirmPassword.MaxLength = 50;
            this.materialTextBoxConfirmPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBoxConfirmPassword.Multiline = false;
            this.materialTextBoxConfirmPassword.Name = "materialTextBoxConfirmPassword";
            this.materialTextBoxConfirmPassword.Password = true;
            this.materialTextBoxConfirmPassword.Size = new System.Drawing.Size(320, 50);
            this.materialTextBoxConfirmPassword.TabIndex = 2;
            this.materialTextBoxConfirmPassword.Text = "";
            this.materialTextBoxConfirmPassword.TrailingIcon = null;
            // 
            // buttonResetPassword
            // 
            this.buttonResetPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonResetPassword.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonResetPassword.Depth = 0;
            this.buttonResetPassword.HighEmphasis = true;
            this.buttonResetPassword.Icon = null;
            this.buttonResetPassword.Location = new System.Drawing.Point(190, 190);
            this.buttonResetPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonResetPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonResetPassword.Size = new System.Drawing.Size(145, 36);
            this.buttonResetPassword.TabIndex = 0;
            this.buttonResetPassword.Text = "Reset Password";
            this.buttonResetPassword.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonResetPassword.UseAccentColor = false;
            this.buttonResetPassword.UseVisualStyleBackColor = true;
            this.buttonResetPassword.Click += new System.EventHandler(this.buttonResetPassword_Click);
            // 
            // buttonBackToLogin
            // 
            this.buttonBackToLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBackToLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonBackToLogin.Depth = 0;
            this.buttonBackToLogin.HighEmphasis = false;
            this.buttonBackToLogin.Icon = null;
            this.buttonBackToLogin.Location = new System.Drawing.Point(134, 350);
            this.buttonBackToLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonBackToLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonBackToLogin.Name = "buttonBackToLogin";
            this.buttonBackToLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonBackToLogin.Size = new System.Drawing.Size(132, 36);
            this.buttonBackToLogin.TabIndex = 3;
            this.buttonBackToLogin.Text = "Back to Login";
            this.buttonBackToLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.buttonBackToLogin.UseAccentColor = false;
            this.buttonBackToLogin.UseVisualStyleBackColor = true;
            this.buttonBackToLogin.Click += new System.EventHandler(this.buttonBackToLogin_Click);
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.buttonBackToLogin);
            this.Controls.Add(this.panelResetPassword);
            this.Controls.Add(this.panelVerifyOtp);
            this.Controls.Add(this.panelEnterEmail);
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forgot Password";
            this.panelEnterEmail.ResumeLayout(false);
            this.panelEnterEmail.PerformLayout();
            this.panelVerifyOtp.ResumeLayout(false);
            this.panelVerifyOtp.PerformLayout();
            this.panelResetPassword.ResumeLayout(false);
            this.panelResetPassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelEnterEmail;
        private MaterialSkin.Controls.MaterialButton buttonContinue;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxEmail;
        private MaterialSkin.Controls.MaterialLabel labelEmailInstruction;
        private System.Windows.Forms.Panel panelVerifyOtp;
        private MaterialSkin.Controls.MaterialButton buttonVerifyOtp;
        private MaterialSkin.Controls.MaterialTextBox textBoxOtp;
        private MaterialSkin.Controls.MaterialLabel labelOtpInstruction;
        private System.Windows.Forms.Panel panelResetPassword;
        private MaterialSkin.Controls.MaterialButton buttonResetPassword;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxConfirmPassword;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxNewPassword;
        private MaterialSkin.Controls.MaterialLabel labelResetInstruction;
        private MaterialSkin.Controls.MaterialButton buttonBackToLogin;
    }
}
