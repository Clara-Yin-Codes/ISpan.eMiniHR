namespace ISpan.eMiniHR.WinApp.Forms
{
	partial class SysUserSettings
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            dgvUsers = new DataGridView();
            userIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            accountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            accountNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            passwordHashDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sysRoleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastLoginTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            users_bindingSource = new BindingSource(components);
            splitContainer2 = new SplitContainer();
            radioActiveN = new RadioButton();
            radioActiveY = new RadioButton();
            lblCuse = new Label();
            label3 = new Label();
            txtLastLoginTime = new TextBox();
            lblReviseDate = new Label();
            txtCreateDate = new TextBox();
            txtUserId = new TextBox();
            lblEmpId = new Label();
            cboSysRole = new ComboBox();
            lblSysRole = new Label();
            lblPasswordHash = new Label();
            txtPasswordHash = new TextBox();
            lblAccountName = new Label();
            txtAccountName = new TextBox();
            lblAccount = new Label();
            txtAccount = new TextBox();
            dgvProgramPermissions = new DataGridView();
            programPermissions_bindingSource = new BindingSource(components);
            picLoading = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)users_bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProgramPermissions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)programPermissions_bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvUsers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2.Controls.Add(picLoading);
            splitContainer1.Size = new Size(1043, 652);
            splitContainer1.SplitterDistance = 262;
            splitContainer1.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.BackgroundColor = SystemColors.ControlLight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { userIdDataGridViewTextBoxColumn, accountDataGridViewTextBoxColumn, accountNameDataGridViewTextBoxColumn, passwordHashDataGridViewTextBoxColumn, sysRoleDataGridViewTextBoxColumn, createDateDataGridViewTextBoxColumn, lastLoginTimeDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn });
            dgvUsers.DataSource = users_bindingSource;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.Size = new Size(262, 652);
            dgvUsers.TabIndex = 0;
            dgvUsers.RowPrePaint += dgvUsers_RowPrePaint;
            dgvUsers.Resize += dgvUsers_Resize;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            userIdDataGridViewTextBoxColumn.HeaderText = "UserId";
            userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            userIdDataGridViewTextBoxColumn.ReadOnly = true;
            userIdDataGridViewTextBoxColumn.Width = 68;
            // 
            // accountDataGridViewTextBoxColumn
            // 
            accountDataGridViewTextBoxColumn.DataPropertyName = "Account";
            accountDataGridViewTextBoxColumn.HeaderText = "Account";
            accountDataGridViewTextBoxColumn.Name = "accountDataGridViewTextBoxColumn";
            accountDataGridViewTextBoxColumn.ReadOnly = true;
            accountDataGridViewTextBoxColumn.Width = 78;
            // 
            // accountNameDataGridViewTextBoxColumn
            // 
            accountNameDataGridViewTextBoxColumn.DataPropertyName = "AccountName";
            accountNameDataGridViewTextBoxColumn.HeaderText = "AccountName";
            accountNameDataGridViewTextBoxColumn.Name = "accountNameDataGridViewTextBoxColumn";
            accountNameDataGridViewTextBoxColumn.ReadOnly = true;
            accountNameDataGridViewTextBoxColumn.Width = 113;
            // 
            // passwordHashDataGridViewTextBoxColumn
            // 
            passwordHashDataGridViewTextBoxColumn.DataPropertyName = "PasswordHash";
            passwordHashDataGridViewTextBoxColumn.HeaderText = "PasswordHash";
            passwordHashDataGridViewTextBoxColumn.Name = "passwordHashDataGridViewTextBoxColumn";
            passwordHashDataGridViewTextBoxColumn.ReadOnly = true;
            passwordHashDataGridViewTextBoxColumn.Width = 113;
            // 
            // sysRoleDataGridViewTextBoxColumn
            // 
            sysRoleDataGridViewTextBoxColumn.DataPropertyName = "SysRole";
            sysRoleDataGridViewTextBoxColumn.HeaderText = "SysRole";
            sysRoleDataGridViewTextBoxColumn.Name = "sysRoleDataGridViewTextBoxColumn";
            sysRoleDataGridViewTextBoxColumn.ReadOnly = true;
            sysRoleDataGridViewTextBoxColumn.Width = 76;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            createDateDataGridViewTextBoxColumn.HeaderText = "CreateDate";
            createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            createDateDataGridViewTextBoxColumn.ReadOnly = true;
            createDateDataGridViewTextBoxColumn.Width = 96;
            // 
            // lastLoginTimeDataGridViewTextBoxColumn
            // 
            lastLoginTimeDataGridViewTextBoxColumn.DataPropertyName = "LastLoginTime";
            lastLoginTimeDataGridViewTextBoxColumn.HeaderText = "LastLoginTime";
            lastLoginTimeDataGridViewTextBoxColumn.Name = "lastLoginTimeDataGridViewTextBoxColumn";
            lastLoginTimeDataGridViewTextBoxColumn.ReadOnly = true;
            lastLoginTimeDataGridViewTextBoxColumn.Width = 114;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            isActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            isActiveDataGridViewCheckBoxColumn.Width = 55;
            // 
            // users_bindingSource
            // 
            users_bindingSource.DataSource = typeof(DataAccess.Models.UsersDto);
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(radioActiveN);
            splitContainer2.Panel1.Controls.Add(radioActiveY);
            splitContainer2.Panel1.Controls.Add(lblCuse);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(txtLastLoginTime);
            splitContainer2.Panel1.Controls.Add(lblReviseDate);
            splitContainer2.Panel1.Controls.Add(txtCreateDate);
            splitContainer2.Panel1.Controls.Add(txtUserId);
            splitContainer2.Panel1.Controls.Add(lblEmpId);
            splitContainer2.Panel1.Controls.Add(cboSysRole);
            splitContainer2.Panel1.Controls.Add(lblSysRole);
            splitContainer2.Panel1.Controls.Add(lblPasswordHash);
            splitContainer2.Panel1.Controls.Add(txtPasswordHash);
            splitContainer2.Panel1.Controls.Add(lblAccountName);
            splitContainer2.Panel1.Controls.Add(txtAccountName);
            splitContainer2.Panel1.Controls.Add(lblAccount);
            splitContainer2.Panel1.Controls.Add(txtAccount);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dgvProgramPermissions);
            splitContainer2.Size = new Size(777, 652);
            splitContainer2.SplitterDistance = 125;
            splitContainer2.TabIndex = 111;
            // 
            // radioActiveN
            // 
            radioActiveN.AutoSize = true;
            radioActiveN.DataBindings.Add(new Binding("Checked", users_bindingSource, "ActiveN", true));
            radioActiveN.Font = new Font("Microsoft JhengHei UI", 12F);
            radioActiveN.Location = new Point(415, 49);
            radioActiveN.Name = "radioActiveN";
            radioActiveN.Size = new Size(59, 24);
            radioActiveN.TabIndex = 126;
            radioActiveN.TabStop = true;
            radioActiveN.Text = "失效";
            radioActiveN.UseVisualStyleBackColor = true;
            // 
            // radioActiveY
            // 
            radioActiveY.AutoSize = true;
            radioActiveY.DataBindings.Add(new Binding("Checked", users_bindingSource, "ActiveY", true));
            radioActiveY.Font = new Font("Microsoft JhengHei UI", 12F);
            radioActiveY.Location = new Point(349, 49);
            radioActiveY.Name = "radioActiveY";
            radioActiveY.Size = new Size(59, 24);
            radioActiveY.TabIndex = 125;
            radioActiveY.TabStop = true;
            radioActiveY.Text = "有效";
            radioActiveY.UseVisualStyleBackColor = true;
            // 
            // lblCuse
            // 
            lblCuse.AutoSize = true;
            lblCuse.Font = new Font("Microsoft JhengHei UI", 12F);
            lblCuse.ForeColor = Color.Blue;
            lblCuse.Location = new Point(263, 51);
            lblCuse.Name = "lblCuse";
            lblCuse.Size = new Size(41, 20);
            lblCuse.TabIndex = 124;
            lblCuse.Text = "啟用";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12F);
            label3.ForeColor = Color.SeaGreen;
            label3.Location = new Point(500, 51);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 122;
            label3.Text = "最後登入時間";
            // 
            // txtLastLoginTime
            // 
            txtLastLoginTime.DataBindings.Add(new Binding("Text", users_bindingSource, "FormatLastLoginTime", true));
            txtLastLoginTime.Location = new Point(610, 50);
            txtLastLoginTime.Name = "txtLastLoginTime";
            txtLastLoginTime.ReadOnly = true;
            txtLastLoginTime.Size = new Size(154, 23);
            txtLastLoginTime.TabIndex = 123;
            // 
            // lblReviseDate
            // 
            lblReviseDate.AutoSize = true;
            lblReviseDate.Font = new Font("Microsoft JhengHei UI", 12F);
            lblReviseDate.ForeColor = Color.SeaGreen;
            lblReviseDate.Location = new Point(500, 87);
            lblReviseDate.Name = "lblReviseDate";
            lblReviseDate.Size = new Size(73, 20);
            lblReviseDate.TabIndex = 120;
            lblReviseDate.Text = "建檔日期";
            // 
            // txtCreateDate
            // 
            txtCreateDate.DataBindings.Add(new Binding("Text", users_bindingSource, "FormatCreateDate", true));
            txtCreateDate.Location = new Point(610, 86);
            txtCreateDate.Name = "txtCreateDate";
            txtCreateDate.ReadOnly = true;
            txtCreateDate.Size = new Size(154, 23);
            txtCreateDate.TabIndex = 121;
            // 
            // txtUserId
            // 
            txtUserId.DataBindings.Add(new Binding("Text", users_bindingSource, "UserId", true));
            txtUserId.Location = new Point(610, 12);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(154, 23);
            txtUserId.TabIndex = 119;
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Font = new Font("Microsoft JhengHei UI", 12F);
            lblEmpId.ForeColor = Color.Red;
            lblEmpId.Location = new Point(500, 13);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(105, 20);
            lblEmpId.TabIndex = 118;
            lblEmpId.Text = "系統人員編號";
            // 
            // cboSysRole
            // 
            cboSysRole.DataBindings.Add(new Binding("Text", users_bindingSource, "SysRole", true));
            cboSysRole.Enabled = false;
            cboSysRole.FormattingEnabled = true;
            cboSysRole.Location = new Point(342, 12);
            cboSysRole.Name = "cboSysRole";
            cboSysRole.Size = new Size(132, 23);
            cboSysRole.TabIndex = 111;
            // 
            // lblSysRole
            // 
            lblSysRole.AutoSize = true;
            lblSysRole.Font = new Font("Microsoft JhengHei UI", 12F);
            lblSysRole.ForeColor = Color.SeaGreen;
            lblSysRole.Location = new Point(263, 13);
            lblSysRole.Name = "lblSysRole";
            lblSysRole.Size = new Size(73, 20);
            lblSysRole.TabIndex = 110;
            lblSysRole.Text = "登入身份";
            // 
            // lblPasswordHash
            // 
            lblPasswordHash.AutoSize = true;
            lblPasswordHash.Font = new Font("Microsoft JhengHei UI", 12F);
            lblPasswordHash.ForeColor = Color.Blue;
            lblPasswordHash.Location = new Point(13, 87);
            lblPasswordHash.Name = "lblPasswordHash";
            lblPasswordHash.Size = new Size(41, 20);
            lblPasswordHash.TabIndex = 116;
            lblPasswordHash.Text = "密碼";
            // 
            // txtPasswordHash
            // 
            txtPasswordHash.DataBindings.Add(new Binding("Text", users_bindingSource, "PasswordHashSet", true));
            txtPasswordHash.Location = new Point(92, 86);
            txtPasswordHash.Name = "txtPasswordHash";
            txtPasswordHash.Size = new Size(152, 23);
            txtPasswordHash.TabIndex = 117;
            txtPasswordHash.UseSystemPasswordChar = true;
            // 
            // lblAccountName
            // 
            lblAccountName.AutoSize = true;
            lblAccountName.Font = new Font("Microsoft JhengHei UI", 12F);
            lblAccountName.ForeColor = Color.Blue;
            lblAccountName.Location = new Point(13, 51);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(73, 20);
            lblAccountName.TabIndex = 114;
            lblAccountName.Text = "帳號名稱";
            // 
            // txtAccountName
            // 
            txtAccountName.DataBindings.Add(new Binding("Text", users_bindingSource, "AccountName", true));
            txtAccountName.Location = new Point(92, 50);
            txtAccountName.Name = "txtAccountName";
            txtAccountName.Size = new Size(152, 23);
            txtAccountName.TabIndex = 115;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Font = new Font("Microsoft JhengHei UI", 12F);
            lblAccount.ForeColor = Color.Blue;
            lblAccount.Location = new Point(13, 13);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(41, 20);
            lblAccount.TabIndex = 112;
            lblAccount.Text = "帳號";
            // 
            // txtAccount
            // 
            txtAccount.DataBindings.Add(new Binding("Text", users_bindingSource, "Account", true));
            txtAccount.Location = new Point(92, 12);
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(152, 23);
            txtAccount.TabIndex = 113;
            // 
            // dgvProgramPermissions
            // 
            dgvProgramPermissions.AutoGenerateColumns = false;
            dgvProgramPermissions.BackgroundColor = SystemColors.ControlLight;
            dgvProgramPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProgramPermissions.DataSource = programPermissions_bindingSource;
            dgvProgramPermissions.Dock = DockStyle.Fill;
            dgvProgramPermissions.Location = new Point(0, 0);
            dgvProgramPermissions.Name = "dgvProgramPermissions";
            dgvProgramPermissions.Size = new Size(777, 523);
            dgvProgramPermissions.TabIndex = 111;
            // 
            // picLoading
            // 
            picLoading.Image = Properties.Resources.circle_9360_256;
            picLoading.Location = new Point(628, 515);
            picLoading.Name = "picLoading";
            picLoading.Size = new Size(68, 74);
            picLoading.SizeMode = PictureBoxSizeMode.Zoom;
            picLoading.TabIndex = 94;
            picLoading.TabStop = false;
            picLoading.Visible = false;
            // 
            // SysUserSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "SysUserSettings";
            Size = new Size(1043, 652);
            Load += SysUserSettings_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)users_bindingSource).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProgramPermissions).EndInit();
            ((System.ComponentModel.ISupportInitialize)programPermissions_bindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvUsers;
        private BindingSource users_bindingSource;
        private DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn accountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn accountNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordHashDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sysRoleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastLoginTimeDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private PictureBox picLoading;
        private SplitContainer splitContainer2;
        private RadioButton radioActiveN;
        private RadioButton radioActiveY;
        private Label lblCuse;
        private Label label3;
        private TextBox txtLastLoginTime;
        private Label lblReviseDate;
        private TextBox txtCreateDate;
        private TextBox txtUserId;
        private Label lblEmpId;
        private ComboBox cboSysRole;
        private Label lblSysRole;
        private Label lblPasswordHash;
        private TextBox txtPasswordHash;
        private Label lblAccountName;
        private TextBox txtAccountName;
        private Label lblAccount;
        private TextBox txtAccount;
        private DataGridView dgvProgramPermissions;
        private BindingSource programPermissions_bindingSource;
    }
}