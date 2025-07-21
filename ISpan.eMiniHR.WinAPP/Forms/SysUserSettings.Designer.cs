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
            picLoading = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)users_bindingSource).BeginInit();
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
            dgvUsers.RowPrePaint += dataGridView1_RowPrePaint;
            dgvUsers.Resize += dataGridView1_Resize;
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
    }
}