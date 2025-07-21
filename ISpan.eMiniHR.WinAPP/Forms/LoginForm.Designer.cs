namespace ISpan.eMiniHR.WinApp.Forms
{
    partial class LoginForm
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
			hopeForm1 = new ReaLTaiizor.Forms.HopeForm();
			labelEdit1 = new ReaLTaiizor.Controls.LabelEdit();
			txtAccunt = new TextBox();
			txtPassword = new TextBox();
			labelEdit2 = new ReaLTaiizor.Controls.LabelEdit();
			loginBtn = new ReaLTaiizor.Controls.HopeButton();
			picEyeToggle = new PictureBox();
			testBtn = new ReaLTaiizor.Controls.HopeButton();
			((System.ComponentModel.ISupportInitialize)picEyeToggle).BeginInit();
			SuspendLayout();
			// 
			// hopeForm1
			// 
			hopeForm1.ControlBoxColorH = Color.FromArgb(228, 231, 237);
			hopeForm1.ControlBoxColorHC = Color.FromArgb(245, 108, 108);
			hopeForm1.ControlBoxColorN = Color.White;
			hopeForm1.Dock = DockStyle.Top;
			hopeForm1.Font = new Font("Segoe UI", 12F);
			hopeForm1.ForeColor = Color.FromArgb(242, 246, 252);
			hopeForm1.Image = null;
			hopeForm1.Location = new Point(0, 0);
			hopeForm1.Margin = new Padding(2);
			hopeForm1.Name = "hopeForm1";
			hopeForm1.Size = new Size(320, 40);
			hopeForm1.TabIndex = 0;
			hopeForm1.Text = "eMiniHR";
			hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
			// 
			// labelEdit1
			// 
			labelEdit1.AutoSize = true;
			labelEdit1.BackColor = Color.Transparent;
			labelEdit1.Font = new Font("微軟正黑體", 12F, FontStyle.Bold);
			labelEdit1.ForeColor = Color.FromArgb(116, 125, 132);
			labelEdit1.Location = new Point(36, 202);
			labelEdit1.Margin = new Padding(2, 0, 2, 0);
			labelEdit1.Name = "labelEdit1";
			labelEdit1.Size = new Size(50, 21);
			labelEdit1.TabIndex = 3;
			labelEdit1.Text = "工號: ";
			labelEdit1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// txtAccunt
			// 
			txtAccunt.Location = new Point(90, 202);
			txtAccunt.Margin = new Padding(2);
			txtAccunt.MaxLength = 20;
			txtAccunt.Name = "txtAccunt";
			txtAccunt.Size = new Size(161, 23);
			txtAccunt.TabIndex = 4;
			txtAccunt.KeyDown += txtAccunt_KeyDown;
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(90, 258);
			txtPassword.Margin = new Padding(2);
			txtPassword.MaxLength = 20;
			txtPassword.Name = "txtPassword";
			txtPassword.Size = new Size(161, 23);
			txtPassword.TabIndex = 6;
			txtPassword.KeyDown += txtPassword_KeyDown;
			// 
			// labelEdit2
			// 
			labelEdit2.AutoSize = true;
			labelEdit2.BackColor = Color.Transparent;
			labelEdit2.Font = new Font("微軟正黑體", 12F, FontStyle.Bold);
			labelEdit2.ForeColor = Color.FromArgb(116, 125, 132);
			labelEdit2.Location = new Point(36, 258);
			labelEdit2.Margin = new Padding(2, 0, 2, 0);
			labelEdit2.Name = "labelEdit2";
			labelEdit2.Size = new Size(50, 21);
			labelEdit2.TabIndex = 5;
			labelEdit2.Text = "密碼: ";
			labelEdit2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// loginBtn
			// 
			loginBtn.BorderColor = Color.FromArgb(220, 223, 230);
			loginBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
			loginBtn.Cursor = Cursors.Hand;
			loginBtn.DangerColor = Color.FromArgb(245, 108, 108);
			loginBtn.DefaultColor = Color.FromArgb(255, 255, 255);
			loginBtn.Font = new Font("Segoe UI", 12F);
			loginBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
			loginBtn.InfoColor = Color.FromArgb(144, 147, 153);
			loginBtn.Location = new Point(195, 323);
			loginBtn.Margin = new Padding(2);
			loginBtn.Name = "loginBtn";
			loginBtn.PrimaryColor = Color.FromArgb(64, 158, 255);
			loginBtn.Size = new Size(93, 33);
			loginBtn.SuccessColor = Color.FromArgb(103, 194, 58);
			loginBtn.TabIndex = 7;
			loginBtn.Text = "登入";
			loginBtn.TextColor = Color.White;
			loginBtn.WarningColor = Color.FromArgb(230, 162, 60);
			loginBtn.Click += loginBtn_Click;
			// 
			// picEyeToggle
			// 
			picEyeToggle.Location = new Point(254, 253);
			picEyeToggle.Name = "picEyeToggle";
			picEyeToggle.Size = new Size(34, 37);
			picEyeToggle.TabIndex = 8;
			picEyeToggle.TabStop = false;
			// 
			// testBtn
			// 
			testBtn.BorderColor = Color.FromArgb(220, 223, 230);
			testBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
			testBtn.Cursor = Cursors.Hand;
			testBtn.DangerColor = Color.FromArgb(245, 108, 108);
			testBtn.DefaultColor = Color.FromArgb(255, 255, 255);
			testBtn.Font = new Font("Segoe UI", 12F);
			testBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
			testBtn.InfoColor = Color.FromArgb(144, 147, 153);
			testBtn.Location = new Point(68, 323);
			testBtn.Margin = new Padding(2);
			testBtn.Name = "testBtn";
			testBtn.PrimaryColor = SystemColors.ControlDark;
			testBtn.Size = new Size(93, 33);
			testBtn.SuccessColor = Color.FromArgb(103, 194, 58);
			testBtn.TabIndex = 9;
			testBtn.Text = "測試";
			testBtn.TextColor = Color.White;
			testBtn.WarningColor = Color.FromArgb(230, 162, 60);
			testBtn.Click += testBtn_Click;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(320, 378);
			Controls.Add(testBtn);
			Controls.Add(picEyeToggle);
			Controls.Add(loginBtn);
			Controls.Add(txtPassword);
			Controls.Add(labelEdit2);
			Controls.Add(txtAccunt);
			Controls.Add(labelEdit1);
			Controls.Add(hopeForm1);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(2);
			MaximumSize = new Size(1493, 840);
			MinimumSize = new Size(190, 40);
			Name = "LoginForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "LoginForm";
			FormClosing += LoginForm_FormClosing;
			Load += LoginForm_Load;
			((System.ComponentModel.ISupportInitialize)picEyeToggle).EndInit();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private ReaLTaiizor.Controls.LabelEdit labelEdit1;
        private System.Windows.Forms.TextBox txtAccunt;
        private System.Windows.Forms.TextBox txtPassword;
        private ReaLTaiizor.Controls.LabelEdit labelEdit2;
        private ReaLTaiizor.Controls.HopeButton loginBtn;
        private System.Windows.Forms.PictureBox picEyeToggle;
        private ReaLTaiizor.Controls.HopeButton testBtn;
    }
}