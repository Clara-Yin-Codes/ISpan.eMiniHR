namespace ISpan.eMiniHR.WinApp.Forms
{
	partial class EmployeeInfo
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
			dgvEmployees = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			isForeignDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
			dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			ageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			isResignedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
			dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
			dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
			dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
			employee_BindingSource = new BindingSource(components);
			lblResignReason = new Label();
			cboReviser = new ComboBox();
			txtResignReason = new TextBox();
			lblReviseDate = new Label();
			txtReviseDate = new TextBox();
			lblReviser = new Label();
			lblMemo = new Label();
			txtMemo = new TextBox();
			picLoading = new PictureBox();
			chkIsResigned = new CheckBox();
			chkIsWelfareMember = new CheckBox();
			cboMgrId = new ComboBox();
			cboDepId = new ComboBox();
			cboShift = new ComboBox();
			cboJobLevel = new ComboBox();
			cboEmployeeType = new ComboBox();
			dateResignDate = new DateTimePicker();
			dateHireDate = new DateTimePicker();
			grBase = new GroupBox();
			btnImgDownload = new Button();
			btnImgDelete = new Button();
			pnlImg = new Panel();
			picEmpImg = new ReaLTaiizor.Controls.HopePictureBox();
			lblTel = new Label();
			txtTel = new TextBox();
			lblEmergencyContact = new Label();
			txtEmergencyContact = new TextBox();
			radioGenderF = new RadioButton();
			radioGenderM = new RadioButton();
			chkIsMarried = new CheckBox();
			chkIsForeign = new CheckBox();
			dateBirthDate = new DateTimePicker();
			txtEmail = new TextBox();
			lblAge = new Label();
			lblEmpNm = new Label();
			txtAge = new TextBox();
			txtEmpNm = new TextBox();
			lblIdNumber = new Label();
			txtAddress_Contact = new TextBox();
			lblAddress_Contact = new Label();
			txtIdNumber = new TextBox();
			txtAddress_Registered = new TextBox();
			lblAddress_Registered = new Label();
			lblGender = new Label();
			lblBirthDate = new Label();
			lblEmail = new Label();
			trackImgZoom = new TrackBar();
			txtEmpId = new TextBox();
			lblEmpId = new Label();
			lblShift = new Label();
			lblMgrId = new Label();
			lblDepId = new Label();
			lblCustomSalary = new Label();
			txtCustomSalary = new TextBox();
			lblEmployeeType = new Label();
			lblResignDate = new Label();
			lblHireDate = new Label();
			lblJobLevel = new Label();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
			((System.ComponentModel.ISupportInitialize)employee_BindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
			grBase.SuspendLayout();
			pnlImg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picEmpImg).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackImgZoom).BeginInit();
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
			splitContainer1.Panel1.Controls.Add(dgvEmployees);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(lblResignReason);
			splitContainer1.Panel2.Controls.Add(cboReviser);
			splitContainer1.Panel2.Controls.Add(txtResignReason);
			splitContainer1.Panel2.Controls.Add(lblReviseDate);
			splitContainer1.Panel2.Controls.Add(txtReviseDate);
			splitContainer1.Panel2.Controls.Add(lblReviser);
			splitContainer1.Panel2.Controls.Add(lblMemo);
			splitContainer1.Panel2.Controls.Add(txtMemo);
			splitContainer1.Panel2.Controls.Add(picLoading);
			splitContainer1.Panel2.Controls.Add(chkIsResigned);
			splitContainer1.Panel2.Controls.Add(chkIsWelfareMember);
			splitContainer1.Panel2.Controls.Add(cboMgrId);
			splitContainer1.Panel2.Controls.Add(cboDepId);
			splitContainer1.Panel2.Controls.Add(cboShift);
			splitContainer1.Panel2.Controls.Add(cboJobLevel);
			splitContainer1.Panel2.Controls.Add(cboEmployeeType);
			splitContainer1.Panel2.Controls.Add(dateResignDate);
			splitContainer1.Panel2.Controls.Add(dateHireDate);
			splitContainer1.Panel2.Controls.Add(grBase);
			splitContainer1.Panel2.Controls.Add(txtEmpId);
			splitContainer1.Panel2.Controls.Add(lblEmpId);
			splitContainer1.Panel2.Controls.Add(lblShift);
			splitContainer1.Panel2.Controls.Add(lblMgrId);
			splitContainer1.Panel2.Controls.Add(lblDepId);
			splitContainer1.Panel2.Controls.Add(lblCustomSalary);
			splitContainer1.Panel2.Controls.Add(txtCustomSalary);
			splitContainer1.Panel2.Controls.Add(lblEmployeeType);
			splitContainer1.Panel2.Controls.Add(lblResignDate);
			splitContainer1.Panel2.Controls.Add(lblHireDate);
			splitContainer1.Panel2.Controls.Add(lblJobLevel);
			splitContainer1.Size = new Size(1043, 652);
			splitContainer1.SplitterDistance = 160;
			splitContainer1.TabIndex = 0;
			// 
			// dgvEmployees
			// 
			dgvEmployees.AllowUserToAddRows = false;
			dgvEmployees.AllowUserToDeleteRows = false;
			dgvEmployees.AutoGenerateColumns = false;
			dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgvEmployees.BackgroundColor = SystemColors.ControlLight;
			dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { Column1, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, isForeignDataGridViewCheckBoxColumn, dataGridViewTextBoxColumn4, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn5, ageDataGridViewTextBoxColumn, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, isResignedDataGridViewCheckBoxColumn, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewCheckBoxColumn2, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16 });
			dgvEmployees.DataSource = employee_BindingSource;
			dgvEmployees.Dock = DockStyle.Fill;
			dgvEmployees.Location = new Point(0, 0);
			dgvEmployees.Name = "dgvEmployees";
			dgvEmployees.ReadOnly = true;
			dgvEmployees.RowHeadersVisible = false;
			dgvEmployees.Size = new Size(160, 652);
			dgvEmployees.TabIndex = 0;
			dgvEmployees.RowPrePaint += dgvEmployees_RowPrePaint;
			dgvEmployees.SelectionChanged += dgvEmployees_SelectionChanged;
			dgvEmployees.Resize += EmployeeInfo_Load;
			// 
			// Column1
			// 
			Column1.HeaderText = "Column1";
			Column1.Name = "Column1";
			Column1.ReadOnly = true;
			Column1.Width = 83;
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewTextBoxColumn1.DataPropertyName = "EmpId";
			dataGridViewTextBoxColumn1.HeaderText = "EmpId";
			dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			dataGridViewTextBoxColumn1.ReadOnly = true;
			dataGridViewTextBoxColumn1.Width = 69;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewTextBoxColumn2.DataPropertyName = "EmpNm";
			dataGridViewTextBoxColumn2.HeaderText = "EmpNm";
			dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			dataGridViewTextBoxColumn2.ReadOnly = true;
			dataGridViewTextBoxColumn2.Width = 79;
			// 
			// dataGridViewTextBoxColumn3
			// 
			dataGridViewTextBoxColumn3.DataPropertyName = "IdNumber";
			dataGridViewTextBoxColumn3.HeaderText = "IdNumber";
			dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			dataGridViewTextBoxColumn3.ReadOnly = true;
			dataGridViewTextBoxColumn3.Width = 90;
			// 
			// isForeignDataGridViewCheckBoxColumn
			// 
			isForeignDataGridViewCheckBoxColumn.DataPropertyName = "IsForeign";
			isForeignDataGridViewCheckBoxColumn.HeaderText = "IsForeign";
			isForeignDataGridViewCheckBoxColumn.Name = "isForeignDataGridViewCheckBoxColumn";
			isForeignDataGridViewCheckBoxColumn.ReadOnly = true;
			isForeignDataGridViewCheckBoxColumn.Width = 64;
			// 
			// dataGridViewTextBoxColumn4
			// 
			dataGridViewTextBoxColumn4.DataPropertyName = "Gender";
			dataGridViewTextBoxColumn4.HeaderText = "Gender";
			dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			dataGridViewTextBoxColumn4.ReadOnly = true;
			dataGridViewTextBoxColumn4.Width = 74;
			// 
			// dataGridViewCheckBoxColumn1
			// 
			dataGridViewCheckBoxColumn1.DataPropertyName = "IsMarried";
			dataGridViewCheckBoxColumn1.HeaderText = "IsMarried";
			dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			dataGridViewCheckBoxColumn1.ReadOnly = true;
			dataGridViewCheckBoxColumn1.Width = 66;
			// 
			// dataGridViewTextBoxColumn5
			// 
			dataGridViewTextBoxColumn5.DataPropertyName = "BirthDate";
			dataGridViewTextBoxColumn5.HeaderText = "BirthDate";
			dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			dataGridViewTextBoxColumn5.ReadOnly = true;
			dataGridViewTextBoxColumn5.Width = 84;
			// 
			// ageDataGridViewTextBoxColumn
			// 
			ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
			ageDataGridViewTextBoxColumn.HeaderText = "Age";
			ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
			ageDataGridViewTextBoxColumn.ReadOnly = true;
			ageDataGridViewTextBoxColumn.Width = 55;
			// 
			// dataGridViewTextBoxColumn6
			// 
			dataGridViewTextBoxColumn6.DataPropertyName = "HireDate";
			dataGridViewTextBoxColumn6.HeaderText = "HireDate";
			dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			dataGridViewTextBoxColumn6.ReadOnly = true;
			dataGridViewTextBoxColumn6.Width = 82;
			// 
			// dataGridViewTextBoxColumn7
			// 
			dataGridViewTextBoxColumn7.DataPropertyName = "ResignDate";
			dataGridViewTextBoxColumn7.HeaderText = "ResignDate";
			dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			dataGridViewTextBoxColumn7.ReadOnly = true;
			dataGridViewTextBoxColumn7.Width = 97;
			// 
			// isResignedDataGridViewCheckBoxColumn
			// 
			isResignedDataGridViewCheckBoxColumn.DataPropertyName = "IsResigned";
			isResignedDataGridViewCheckBoxColumn.HeaderText = "IsResigned";
			isResignedDataGridViewCheckBoxColumn.Name = "isResignedDataGridViewCheckBoxColumn";
			isResignedDataGridViewCheckBoxColumn.ReadOnly = true;
			isResignedDataGridViewCheckBoxColumn.Width = 74;
			// 
			// dataGridViewTextBoxColumn8
			// 
			dataGridViewTextBoxColumn8.DataPropertyName = "JobLevel";
			dataGridViewTextBoxColumn8.HeaderText = "JobLevel";
			dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			dataGridViewTextBoxColumn8.ReadOnly = true;
			dataGridViewTextBoxColumn8.Width = 82;
			// 
			// dataGridViewTextBoxColumn9
			// 
			dataGridViewTextBoxColumn9.DataPropertyName = "CustomSalary";
			dataGridViewTextBoxColumn9.HeaderText = "CustomSalary";
			dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			dataGridViewTextBoxColumn9.ReadOnly = true;
			dataGridViewTextBoxColumn9.Width = 109;
			// 
			// dataGridViewTextBoxColumn10
			// 
			dataGridViewTextBoxColumn10.DataPropertyName = "EmployeeType";
			dataGridViewTextBoxColumn10.HeaderText = "EmployeeType";
			dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			dataGridViewTextBoxColumn10.ReadOnly = true;
			dataGridViewTextBoxColumn10.Width = 117;
			// 
			// dataGridViewCheckBoxColumn2
			// 
			dataGridViewCheckBoxColumn2.DataPropertyName = "IsWelfareMember";
			dataGridViewCheckBoxColumn2.HeaderText = "IsWelfareMember";
			dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
			dataGridViewCheckBoxColumn2.ReadOnly = true;
			dataGridViewCheckBoxColumn2.Width = 114;
			// 
			// dataGridViewTextBoxColumn11
			// 
			dataGridViewTextBoxColumn11.DataPropertyName = "Shift";
			dataGridViewTextBoxColumn11.HeaderText = "Shift";
			dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			dataGridViewTextBoxColumn11.ReadOnly = true;
			dataGridViewTextBoxColumn11.Width = 57;
			// 
			// dataGridViewTextBoxColumn12
			// 
			dataGridViewTextBoxColumn12.DataPropertyName = "DepId";
			dataGridViewTextBoxColumn12.HeaderText = "DepId";
			dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			dataGridViewTextBoxColumn12.ReadOnly = true;
			dataGridViewTextBoxColumn12.Width = 67;
			// 
			// dataGridViewTextBoxColumn13
			// 
			dataGridViewTextBoxColumn13.DataPropertyName = "MgrId";
			dataGridViewTextBoxColumn13.HeaderText = "MgrId";
			dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			dataGridViewTextBoxColumn13.ReadOnly = true;
			dataGridViewTextBoxColumn13.Width = 67;
			// 
			// dataGridViewTextBoxColumn14
			// 
			dataGridViewTextBoxColumn14.DataPropertyName = "Address_Registered";
			dataGridViewTextBoxColumn14.HeaderText = "Address_Registered";
			dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			dataGridViewTextBoxColumn14.ReadOnly = true;
			dataGridViewTextBoxColumn14.Width = 143;
			// 
			// dataGridViewTextBoxColumn15
			// 
			dataGridViewTextBoxColumn15.DataPropertyName = "Address_Contact";
			dataGridViewTextBoxColumn15.HeaderText = "Address_Contact";
			dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			dataGridViewTextBoxColumn15.ReadOnly = true;
			dataGridViewTextBoxColumn15.Width = 126;
			// 
			// dataGridViewTextBoxColumn16
			// 
			dataGridViewTextBoxColumn16.DataPropertyName = "Email";
			dataGridViewTextBoxColumn16.HeaderText = "Email";
			dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			dataGridViewTextBoxColumn16.ReadOnly = true;
			dataGridViewTextBoxColumn16.Width = 63;
			// 
			// employee_BindingSource
			// 
			employee_BindingSource.DataSource = typeof(DataAccess.Models.EmployeeDto);
			// 
			// lblResignReason
			// 
			lblResignReason.AutoSize = true;
			lblResignReason.Font = new Font("Microsoft JhengHei UI", 12F);
			lblResignReason.ForeColor = Color.Blue;
			lblResignReason.Location = new Point(537, 396);
			lblResignReason.Name = "lblResignReason";
			lblResignReason.Size = new Size(73, 20);
			lblResignReason.TabIndex = 98;
			lblResignReason.Text = "離職原因";
			lblResignReason.Visible = false;
			// 
			// cboReviser
			// 
			cboReviser.DataBindings.Add(new Binding("Text", employee_BindingSource, "Reviser", true));
			cboReviser.Enabled = false;
			cboReviser.FormattingEnabled = true;
			cboReviser.Location = new Point(615, 440);
			cboReviser.Name = "cboReviser";
			cboReviser.Size = new Size(183, 23);
			cboReviser.TabIndex = 98;
			// 
			// txtResignReason
			// 
			txtResignReason.DataBindings.Add(new Binding("Text", employee_BindingSource, "ResignReason", true));
			txtResignReason.Location = new Point(616, 395);
			txtResignReason.Name = "txtResignReason";
			txtResignReason.Size = new Size(183, 23);
			txtResignReason.TabIndex = 99;
			txtResignReason.Visible = false;
			// 
			// lblReviseDate
			// 
			lblReviseDate.AutoSize = true;
			lblReviseDate.Font = new Font("Microsoft JhengHei UI", 12F);
			lblReviseDate.ForeColor = Color.SeaGreen;
			lblReviseDate.Location = new Point(541, 475);
			lblReviseDate.Name = "lblReviseDate";
			lblReviseDate.Size = new Size(73, 20);
			lblReviseDate.TabIndex = 96;
			lblReviseDate.Text = "異動日期";
			// 
			// txtReviseDate
			// 
			txtReviseDate.DataBindings.Add(new Binding("Text", employee_BindingSource, "FormatReviseDate", true));
			txtReviseDate.Location = new Point(615, 474);
			txtReviseDate.Name = "txtReviseDate";
			txtReviseDate.ReadOnly = true;
			txtReviseDate.Size = new Size(183, 23);
			txtReviseDate.TabIndex = 97;
			// 
			// lblReviser
			// 
			lblReviser.AutoSize = true;
			lblReviser.Font = new Font("Microsoft JhengHei UI", 12F);
			lblReviser.ForeColor = Color.SeaGreen;
			lblReviser.Location = new Point(541, 439);
			lblReviser.Name = "lblReviser";
			lblReviser.Size = new Size(73, 20);
			lblReviser.TabIndex = 94;
			lblReviser.Text = "異動人員";
			// 
			// lblMemo
			// 
			lblMemo.AutoSize = true;
			lblMemo.Font = new Font("Microsoft JhengHei UI", 12F);
			lblMemo.ForeColor = Color.Black;
			lblMemo.Location = new Point(21, 412);
			lblMemo.Name = "lblMemo";
			lblMemo.Size = new Size(41, 20);
			lblMemo.TabIndex = 95;
			lblMemo.Text = "備註";
			// 
			// txtMemo
			// 
			txtMemo.DataBindings.Add(new Binding("Text", employee_BindingSource, "Memo", true));
			txtMemo.Location = new Point(19, 435);
			txtMemo.Multiline = true;
			txtMemo.Name = "txtMemo";
			txtMemo.Size = new Size(495, 156);
			txtMemo.TabIndex = 94;
			// 
			// picLoading
			// 
			picLoading.Image = Properties.Resources.circle_9360_256;
			picLoading.Location = new Point(689, 517);
			picLoading.Name = "picLoading";
			picLoading.Size = new Size(68, 74);
			picLoading.SizeMode = PictureBoxSizeMode.Zoom;
			picLoading.TabIndex = 93;
			picLoading.TabStop = false;
			picLoading.Visible = false;
			// 
			// chkIsResigned
			// 
			chkIsResigned.AutoSize = true;
			chkIsResigned.DataBindings.Add(new Binding("Checked", employee_BindingSource, "IsResigned", true));
			chkIsResigned.Font = new Font("Microsoft JhengHei UI", 12F);
			chkIsResigned.Location = new Point(538, 361);
			chkIsResigned.Name = "chkIsResigned";
			chkIsResigned.Size = new Size(15, 14);
			chkIsResigned.TabIndex = 91;
			chkIsResigned.UseVisualStyleBackColor = true;
			chkIsResigned.CheckedChanged += chkIsResigned_CheckedChanged;
			// 
			// chkIsWelfareMember
			// 
			chkIsWelfareMember.AutoSize = true;
			chkIsWelfareMember.DataBindings.Add(new Binding("Checked", employee_BindingSource, "IsWelfareMember", true));
			chkIsWelfareMember.Font = new Font("Microsoft JhengHei UI", 12F);
			chkIsWelfareMember.Location = new Point(326, 395);
			chkIsWelfareMember.Name = "chkIsWelfareMember";
			chkIsWelfareMember.Size = new Size(172, 24);
			chkIsWelfareMember.TabIndex = 90;
			chkIsWelfareMember.Text = "是否參加職工福利會";
			chkIsWelfareMember.UseVisualStyleBackColor = true;
			// 
			// cboMgrId
			// 
			cboMgrId.FormattingEnabled = true;
			cboMgrId.Location = new Point(114, 356);
			cboMgrId.Name = "cboMgrId";
			cboMgrId.Size = new Size(168, 23);
			cboMgrId.TabIndex = 89;
			// 
			// cboDepId
			// 
			cboDepId.FormattingEnabled = true;
			cboDepId.Location = new Point(114, 319);
			cboDepId.Name = "cboDepId";
			cboDepId.Size = new Size(168, 23);
			cboDepId.TabIndex = 88;
			// 
			// cboShift
			// 
			cboShift.FormattingEnabled = true;
			cboShift.Location = new Point(114, 280);
			cboShift.Name = "cboShift";
			cboShift.Size = new Size(168, 23);
			cboShift.TabIndex = 87;
			// 
			// cboJobLevel
			// 
			cboJobLevel.FormattingEnabled = true;
			cboJobLevel.Location = new Point(382, 280);
			cboJobLevel.Name = "cboJobLevel";
			cboJobLevel.Size = new Size(132, 23);
			cboJobLevel.TabIndex = 86;
			// 
			// cboEmployeeType
			// 
			cboEmployeeType.FormattingEnabled = true;
			cboEmployeeType.Location = new Point(382, 319);
			cboEmployeeType.Name = "cboEmployeeType";
			cboEmployeeType.Size = new Size(132, 23);
			cboEmployeeType.TabIndex = 85;
			// 
			// dateResignDate
			// 
			dateResignDate.CustomFormat = "";
			dateResignDate.DataBindings.Add(new Binding("Value", employee_BindingSource, "ResignDate", true));
			dateResignDate.Format = DateTimePickerFormat.Custom;
			dateResignDate.Location = new Point(615, 356);
			dateResignDate.Name = "dateResignDate";
			dateResignDate.Size = new Size(183, 23);
			dateResignDate.TabIndex = 65;
			dateResignDate.Value = new DateTime(2025, 7, 16, 0, 0, 0, 0);
			dateResignDate.Visible = false;
			// 
			// dateHireDate
			// 
			dateHireDate.CustomFormat = "";
			dateHireDate.DataBindings.Add(new Binding("Value", employee_BindingSource, "HireDate", true));
			dateHireDate.Format = DateTimePickerFormat.Custom;
			dateHireDate.Location = new Point(615, 319);
			dateHireDate.Name = "dateHireDate";
			dateHireDate.Size = new Size(183, 23);
			dateHireDate.TabIndex = 64;
			dateHireDate.Value = new DateTime(2025, 7, 16, 0, 0, 0, 0);
			// 
			// grBase
			// 
			grBase.Controls.Add(btnImgDownload);
			grBase.Controls.Add(btnImgDelete);
			grBase.Controls.Add(pnlImg);
			grBase.Controls.Add(lblTel);
			grBase.Controls.Add(txtTel);
			grBase.Controls.Add(lblEmergencyContact);
			grBase.Controls.Add(txtEmergencyContact);
			grBase.Controls.Add(radioGenderF);
			grBase.Controls.Add(radioGenderM);
			grBase.Controls.Add(chkIsMarried);
			grBase.Controls.Add(chkIsForeign);
			grBase.Controls.Add(dateBirthDate);
			grBase.Controls.Add(txtEmail);
			grBase.Controls.Add(lblAge);
			grBase.Controls.Add(lblEmpNm);
			grBase.Controls.Add(txtAge);
			grBase.Controls.Add(txtEmpNm);
			grBase.Controls.Add(lblIdNumber);
			grBase.Controls.Add(txtAddress_Contact);
			grBase.Controls.Add(lblAddress_Contact);
			grBase.Controls.Add(txtIdNumber);
			grBase.Controls.Add(txtAddress_Registered);
			grBase.Controls.Add(lblAddress_Registered);
			grBase.Controls.Add(lblGender);
			grBase.Controls.Add(lblBirthDate);
			grBase.Controls.Add(lblEmail);
			grBase.Controls.Add(trackImgZoom);
			grBase.Location = new Point(19, 13);
			grBase.Name = "grBase";
			grBase.Size = new Size(779, 254);
			grBase.TabIndex = 62;
			grBase.TabStop = false;
			grBase.Text = "基本資料";
			// 
			// btnImgDownload
			// 
			btnImgDownload.FlatAppearance.BorderSize = 0;
			btnImgDownload.FlatStyle = FlatStyle.Flat;
			btnImgDownload.Image = Properties.Resources.icon_export;
			btnImgDownload.Location = new Point(714, 91);
			btnImgDownload.Name = "btnImgDownload";
			btnImgDownload.Size = new Size(38, 35);
			btnImgDownload.TabIndex = 102;
			btnImgDownload.UseVisualStyleBackColor = true;
			btnImgDownload.Click += btnImgDownload_Click;
			// 
			// btnImgDelete
			// 
			btnImgDelete.FlatAppearance.BorderSize = 0;
			btnImgDelete.FlatStyle = FlatStyle.Flat;
			btnImgDelete.Image = Properties.Resources.icon_cancel;
			btnImgDelete.Location = new Point(714, 43);
			btnImgDelete.Name = "btnImgDelete";
			btnImgDelete.Size = new Size(35, 35);
			btnImgDelete.TabIndex = 101;
			btnImgDelete.UseVisualStyleBackColor = true;
			btnImgDelete.Click += btnImgDelete_Click;
			// 
			// pnlImg
			// 
			pnlImg.Controls.Add(picEmpImg);
			pnlImg.Location = new Point(596, 16);
			pnlImg.Name = "pnlImg";
			pnlImg.Size = new Size(110, 135);
			pnlImg.TabIndex = 98;
			// 
			// picEmpImg
			// 
			picEmpImg.BackColor = Color.FromArgb(192, 196, 204);
			picEmpImg.Location = new Point(0, -6);
			picEmpImg.Name = "picEmpImg";
			picEmpImg.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			picEmpImg.Size = new Size(112, 151);
			picEmpImg.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			picEmpImg.TabIndex = 64;
			picEmpImg.TabStop = false;
			picEmpImg.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			picEmpImg.DoubleClick += picEmpImg_DoubleClick;
			// 
			// lblTel
			// 
			lblTel.AutoSize = true;
			lblTel.Font = new Font("Microsoft JhengHei UI", 12F);
			lblTel.ForeColor = Color.Blue;
			lblTel.Location = new Point(549, 183);
			lblTel.Name = "lblTel";
			lblTel.Size = new Size(41, 20);
			lblTel.TabIndex = 96;
			lblTel.Text = "電話";
			// 
			// txtTel
			// 
			txtTel.DataBindings.Add(new Binding("Text", employee_BindingSource, "Tel", true));
			txtTel.Location = new Point(596, 181);
			txtTel.Name = "txtTel";
			txtTel.Size = new Size(159, 23);
			txtTel.TabIndex = 97;
			// 
			// lblEmergencyContact
			// 
			lblEmergencyContact.AutoSize = true;
			lblEmergencyContact.Font = new Font("Microsoft JhengHei UI", 12F);
			lblEmergencyContact.ForeColor = Color.Blue;
			lblEmergencyContact.Location = new Point(503, 219);
			lblEmergencyContact.Name = "lblEmergencyContact";
			lblEmergencyContact.Size = new Size(89, 20);
			lblEmergencyContact.TabIndex = 94;
			lblEmergencyContact.Text = "緊急聯絡人";
			// 
			// txtEmergencyContact
			// 
			txtEmergencyContact.DataBindings.Add(new Binding("Text", employee_BindingSource, "EmergencyContact", true));
			txtEmergencyContact.Location = new Point(596, 218);
			txtEmergencyContact.Name = "txtEmergencyContact";
			txtEmergencyContact.Size = new Size(159, 23);
			txtEmergencyContact.TabIndex = 95;
			// 
			// radioGenderF
			// 
			radioGenderF.AutoSize = true;
			radioGenderF.DataBindings.Add(new Binding("Checked", employee_BindingSource, "GenderF", true));
			radioGenderF.Font = new Font("Microsoft JhengHei UI", 12F);
			radioGenderF.Location = new Point(394, 26);
			radioGenderF.Name = "radioGenderF";
			radioGenderF.Size = new Size(43, 24);
			radioGenderF.TabIndex = 93;
			radioGenderF.TabStop = true;
			radioGenderF.Text = "女";
			radioGenderF.UseVisualStyleBackColor = true;
			// 
			// radioGenderM
			// 
			radioGenderM.AutoSize = true;
			radioGenderM.DataBindings.Add(new Binding("Checked", employee_BindingSource, "GenderM", true));
			radioGenderM.Font = new Font("Microsoft JhengHei UI", 12F);
			radioGenderM.Location = new Point(345, 26);
			radioGenderM.Name = "radioGenderM";
			radioGenderM.Size = new Size(43, 24);
			radioGenderM.TabIndex = 92;
			radioGenderM.TabStop = true;
			radioGenderM.Text = "男";
			radioGenderM.UseVisualStyleBackColor = true;
			// 
			// chkIsMarried
			// 
			chkIsMarried.AutoSize = true;
			chkIsMarried.DataBindings.Add(new Binding("Checked", employee_BindingSource, "IsMarried", true));
			chkIsMarried.Font = new Font("Microsoft JhengHei UI", 12F);
			chkIsMarried.Location = new Point(431, 68);
			chkIsMarried.Name = "chkIsMarried";
			chkIsMarried.Size = new Size(60, 24);
			chkIsMarried.TabIndex = 93;
			chkIsMarried.Text = "已婚";
			chkIsMarried.UseVisualStyleBackColor = true;
			// 
			// chkIsForeign
			// 
			chkIsForeign.AutoSize = true;
			chkIsForeign.DataBindings.Add(new Binding("Checked", employee_BindingSource, "IsForeign", true));
			chkIsForeign.Font = new Font("Microsoft JhengHei UI", 12F);
			chkIsForeign.Location = new Point(307, 68);
			chkIsForeign.Name = "chkIsForeign";
			chkIsForeign.Size = new Size(76, 24);
			chkIsForeign.TabIndex = 92;
			chkIsForeign.Text = "外國籍";
			chkIsForeign.UseVisualStyleBackColor = true;
			// 
			// dateBirthDate
			// 
			dateBirthDate.CustomFormat = "";
			dateBirthDate.DataBindings.Add(new Binding("Value", employee_BindingSource, "BirthDate", true));
			dateBirthDate.Format = DateTimePickerFormat.Custom;
			dateBirthDate.Location = new Point(95, 105);
			dateBirthDate.Name = "dateBirthDate";
			dateBirthDate.Size = new Size(168, 23);
			dateBirthDate.TabIndex = 63;
			dateBirthDate.Value = new DateTime(2025, 7, 16, 0, 0, 0, 0);
			// 
			// txtEmail
			// 
			txtEmail.DataBindings.Add(new Binding("Text", employee_BindingSource, "Email", true));
			txtEmail.Location = new Point(95, 144);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new Size(400, 23);
			txtEmail.TabIndex = 45;
			// 
			// lblAge
			// 
			lblAge.AutoSize = true;
			lblAge.Font = new Font("Microsoft JhengHei UI", 12F);
			lblAge.ForeColor = Color.SeaGreen;
			lblAge.Location = new Point(289, 107);
			lblAge.Name = "lblAge";
			lblAge.Size = new Size(41, 20);
			lblAge.TabIndex = 60;
			lblAge.Text = "年齡";
			// 
			// lblEmpNm
			// 
			lblEmpNm.AutoSize = true;
			lblEmpNm.Font = new Font("Microsoft JhengHei UI", 12F);
			lblEmpNm.ForeColor = Color.Blue;
			lblEmpNm.Location = new Point(2, 27);
			lblEmpNm.Name = "lblEmpNm";
			lblEmpNm.Size = new Size(73, 20);
			lblEmpNm.TabIndex = 0;
			lblEmpNm.Text = "員工姓名";
			// 
			// txtAge
			// 
			txtAge.DataBindings.Add(new Binding("Text", employee_BindingSource, "Age", true));
			txtAge.Location = new Point(363, 106);
			txtAge.Name = "txtAge";
			txtAge.ReadOnly = true;
			txtAge.Size = new Size(132, 23);
			txtAge.TabIndex = 61;
			// 
			// txtEmpNm
			// 
			txtEmpNm.DataBindings.Add(new Binding("Text", employee_BindingSource, "EmpNm", true, DataSourceUpdateMode.OnPropertyChanged));
			txtEmpNm.Location = new Point(95, 26);
			txtEmpNm.Name = "txtEmpNm";
			txtEmpNm.Size = new Size(168, 23);
			txtEmpNm.TabIndex = 1;
			// 
			// lblIdNumber
			// 
			lblIdNumber.AutoSize = true;
			lblIdNumber.Font = new Font("Microsoft JhengHei UI", 12F);
			lblIdNumber.ForeColor = Color.Blue;
			lblIdNumber.Location = new Point(2, 69);
			lblIdNumber.Name = "lblIdNumber";
			lblIdNumber.Size = new Size(89, 20);
			lblIdNumber.TabIndex = 2;
			lblIdNumber.Text = "身分證字號";
			// 
			// txtAddress_Contact
			// 
			txtAddress_Contact.DataBindings.Add(new Binding("Text", employee_BindingSource, "Address_Contact", true));
			txtAddress_Contact.Location = new Point(95, 216);
			txtAddress_Contact.Name = "txtAddress_Contact";
			txtAddress_Contact.Size = new Size(400, 23);
			txtAddress_Contact.TabIndex = 43;
			// 
			// lblAddress_Contact
			// 
			lblAddress_Contact.AutoSize = true;
			lblAddress_Contact.Font = new Font("Microsoft JhengHei UI", 12F);
			lblAddress_Contact.ForeColor = Color.Black;
			lblAddress_Contact.Location = new Point(2, 217);
			lblAddress_Contact.Name = "lblAddress_Contact";
			lblAddress_Contact.Size = new Size(73, 20);
			lblAddress_Contact.TabIndex = 42;
			lblAddress_Contact.Text = "通訊地址";
			// 
			// txtIdNumber
			// 
			txtIdNumber.DataBindings.Add(new Binding("Text", employee_BindingSource, "IdNumber", true));
			txtIdNumber.Location = new Point(95, 68);
			txtIdNumber.Name = "txtIdNumber";
			txtIdNumber.Size = new Size(168, 23);
			txtIdNumber.TabIndex = 3;
			// 
			// txtAddress_Registered
			// 
			txtAddress_Registered.DataBindings.Add(new Binding("Text", employee_BindingSource, "Address_Registered", true));
			txtAddress_Registered.Location = new Point(95, 179);
			txtAddress_Registered.Name = "txtAddress_Registered";
			txtAddress_Registered.Size = new Size(400, 23);
			txtAddress_Registered.TabIndex = 41;
			// 
			// lblAddress_Registered
			// 
			lblAddress_Registered.AutoSize = true;
			lblAddress_Registered.Font = new Font("Microsoft JhengHei UI", 12F);
			lblAddress_Registered.ForeColor = Color.Black;
			lblAddress_Registered.Location = new Point(2, 180);
			lblAddress_Registered.Name = "lblAddress_Registered";
			lblAddress_Registered.Size = new Size(73, 20);
			lblAddress_Registered.TabIndex = 39;
			lblAddress_Registered.Text = "戶籍地址";
			// 
			// lblGender
			// 
			lblGender.AutoSize = true;
			lblGender.Font = new Font("Microsoft JhengHei UI", 12F);
			lblGender.ForeColor = Color.Blue;
			lblGender.Location = new Point(289, 27);
			lblGender.Name = "lblGender";
			lblGender.Size = new Size(41, 20);
			lblGender.TabIndex = 6;
			lblGender.Text = "性別";
			// 
			// lblBirthDate
			// 
			lblBirthDate.AutoSize = true;
			lblBirthDate.Font = new Font("Microsoft JhengHei UI", 12F);
			lblBirthDate.ForeColor = Color.Blue;
			lblBirthDate.Location = new Point(2, 107);
			lblBirthDate.Name = "lblBirthDate";
			lblBirthDate.Size = new Size(41, 20);
			lblBirthDate.TabIndex = 8;
			lblBirthDate.Text = "生日";
			// 
			// lblEmail
			// 
			lblEmail.AutoSize = true;
			lblEmail.Font = new Font("Microsoft JhengHei UI", 12F);
			lblEmail.ForeColor = Color.Black;
			lblEmail.Location = new Point(2, 145);
			lblEmail.Name = "lblEmail";
			lblEmail.Size = new Size(73, 20);
			lblEmail.TabIndex = 44;
			lblEmail.Text = "電子郵件";
			// 
			// trackImgZoom
			// 
			trackImgZoom.LargeChange = 20;
			trackImgZoom.Location = new Point(599, 151);
			trackImgZoom.Maximum = 100;
			trackImgZoom.Minimum = 10;
			trackImgZoom.Name = "trackImgZoom";
			trackImgZoom.Size = new Size(104, 45);
			trackImgZoom.SmallChange = 5;
			trackImgZoom.TabIndex = 100;
			trackImgZoom.TickFrequency = 10;
			trackImgZoom.Value = 100;
			trackImgZoom.Scroll += trackImgZoom_Scroll;
			// 
			// txtEmpId
			// 
			txtEmpId.DataBindings.Add(new Binding("Text", employee_BindingSource, "EmpId", true));
			txtEmpId.Location = new Point(615, 280);
			txtEmpId.Name = "txtEmpId";
			txtEmpId.ReadOnly = true;
			txtEmpId.Size = new Size(183, 23);
			txtEmpId.TabIndex = 47;
			// 
			// lblEmpId
			// 
			lblEmpId.AutoSize = true;
			lblEmpId.Font = new Font("Microsoft JhengHei UI", 12F);
			lblEmpId.ForeColor = Color.Red;
			lblEmpId.Location = new Point(537, 281);
			lblEmpId.Name = "lblEmpId";
			lblEmpId.Size = new Size(73, 20);
			lblEmpId.TabIndex = 46;
			lblEmpId.Text = "員工編號";
			// 
			// lblShift
			// 
			lblShift.AutoSize = true;
			lblShift.Font = new Font("Microsoft JhengHei UI", 12F);
			lblShift.ForeColor = Color.Blue;
			lblShift.Location = new Point(21, 281);
			lblShift.Name = "lblShift";
			lblShift.Size = new Size(41, 20);
			lblShift.TabIndex = 30;
			lblShift.Text = "班別";
			// 
			// lblMgrId
			// 
			lblMgrId.AutoSize = true;
			lblMgrId.Font = new Font("Microsoft JhengHei UI", 12F);
			lblMgrId.ForeColor = Color.Black;
			lblMgrId.Location = new Point(21, 357);
			lblMgrId.Name = "lblMgrId";
			lblMgrId.Size = new Size(73, 20);
			lblMgrId.TabIndex = 36;
			lblMgrId.Text = "直屬主管";
			// 
			// lblDepId
			// 
			lblDepId.AutoSize = true;
			lblDepId.Font = new Font("Microsoft JhengHei UI", 12F);
			lblDepId.ForeColor = Color.Blue;
			lblDepId.Location = new Point(21, 320);
			lblDepId.Name = "lblDepId";
			lblDepId.Size = new Size(41, 20);
			lblDepId.TabIndex = 33;
			lblDepId.Text = "部門";
			// 
			// lblCustomSalary
			// 
			lblCustomSalary.AutoSize = true;
			lblCustomSalary.Font = new Font("Microsoft JhengHei UI", 12F);
			lblCustomSalary.ForeColor = Color.Black;
			lblCustomSalary.Location = new Point(308, 357);
			lblCustomSalary.Name = "lblCustomSalary";
			lblCustomSalary.Size = new Size(73, 20);
			lblCustomSalary.TabIndex = 24;
			lblCustomSalary.Text = "員工薪資";
			// 
			// txtCustomSalary
			// 
			txtCustomSalary.DataBindings.Add(new Binding("Text", employee_BindingSource, "CustomSalary", true));
			txtCustomSalary.Location = new Point(382, 356);
			txtCustomSalary.Name = "txtCustomSalary";
			txtCustomSalary.Size = new Size(132, 23);
			txtCustomSalary.TabIndex = 25;
			// 
			// lblEmployeeType
			// 
			lblEmployeeType.AutoSize = true;
			lblEmployeeType.Font = new Font("Microsoft JhengHei UI", 12F);
			lblEmployeeType.ForeColor = Color.Blue;
			lblEmployeeType.Location = new Point(308, 320);
			lblEmployeeType.Name = "lblEmployeeType";
			lblEmployeeType.Size = new Size(73, 20);
			lblEmployeeType.TabIndex = 21;
			lblEmployeeType.Text = "員工類別";
			// 
			// lblResignDate
			// 
			lblResignDate.AutoSize = true;
			lblResignDate.Font = new Font("Microsoft JhengHei UI", 12F);
			lblResignDate.ForeColor = Color.Black;
			lblResignDate.Location = new Point(553, 357);
			lblResignDate.Name = "lblResignDate";
			lblResignDate.Size = new Size(57, 20);
			lblResignDate.TabIndex = 17;
			lblResignDate.Text = "離職日";
			// 
			// lblHireDate
			// 
			lblHireDate.AutoSize = true;
			lblHireDate.Font = new Font("Microsoft JhengHei UI", 12F);
			lblHireDate.ForeColor = Color.Blue;
			lblHireDate.Location = new Point(553, 320);
			lblHireDate.Name = "lblHireDate";
			lblHireDate.Size = new Size(57, 20);
			lblHireDate.TabIndex = 13;
			lblHireDate.Text = "到職日";
			// 
			// lblJobLevel
			// 
			lblJobLevel.AutoSize = true;
			lblJobLevel.Font = new Font("Microsoft JhengHei UI", 12F);
			lblJobLevel.ForeColor = Color.Blue;
			lblJobLevel.Location = new Point(308, 281);
			lblJobLevel.Name = "lblJobLevel";
			lblJobLevel.Size = new Size(41, 20);
			lblJobLevel.TabIndex = 21;
			lblJobLevel.Text = "職等";
			// 
			// EmployeeInfo
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(splitContainer1);
			Name = "EmployeeInfo";
			Size = new Size(1043, 652);
			Resize += EmployeeInfo_Resize;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
			((System.ComponentModel.ISupportInitialize)employee_BindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
			grBase.ResumeLayout(false);
			grBase.PerformLayout();
			pnlImg.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picEmpImg).EndInit();
			((System.ComponentModel.ISupportInitialize)trackImgZoom).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
		private DataGridView dgvEmployees;
		private DataGridViewTextBoxColumn Column1;
		private TextBox txtEmpNm;
		private Label lblGender;
		private TextBox txtIdNumber;
		private Label lblIdNumber;
		private Label lblEmpNm;
		private Label lblBirthDate;
		private Label lblEmployeeType;
		private Label lblHireDate;
		private Label lblShift;
		private Label lblAddress_Registered;
		private Label lblMgrId;
		private Label lblDepId;
		private Label lblCustomSalary;
		private Label lblEmail;
		private Label lblAddress_Contact;
		private TextBox txtEmpId;
		private Label lblEmpId;
		private TextBox txtEmail;
		private TextBox txtAddress_Contact;
		private TextBox txtAddress_Registered;
		private TextBox txtMgrId;
		private TextBox txtShift;
		private TextBox txtCustomSalary;
		private TextBox txtEmployeeType;
		private Label lblAge;
		private TextBox txtAge;
		private GroupBox grBase;
		private TextBox txtJobLevel;
		private Label lblJobLevel;
		private DateTimePicker dateBirthDate;
		private DateTimePicker dateResignDate;
		private DateTimePicker dateHireDate;
		private Label lblResignDate;
		private TextBox txtDepId;
		private ReaLTaiizor.Controls.HopePictureBox picEmpImg;
		private BindingSource employee_BindingSource;
		private ComboBox cboEmployeeType;
		private ComboBox cboMgrId;
		private ComboBox cboDepId;
		private ComboBox cboShift;
		private ComboBox cboJobLevel;
        private DataGridViewTextBoxColumn empIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn empNmDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn isForeignDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isMarriedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn birthDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hireDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn resignDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jobLevelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customSalaryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeTypeDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isWelfareMemberDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn shiftDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn depIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mgrIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressRegisteredDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressContactDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewCheckBoxColumn isForeignDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewCheckBoxColumn isResignedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private CheckBox chkIsResigned;
        private CheckBox chkIsWelfareMember;
        private CheckBox chkIsMarried;
        private CheckBox chkIsForeign;
        private RadioButton radioGenderF;
        private RadioButton radioGenderM;
        private PictureBox picLoading;
        private Label lblMemo;
        private TextBox txtMemo;
        private ComboBox cboReviser;
        private Label lblReviseDate;
        private TextBox txtReviseDate;
        private Label lblReviser;
        private Label lblTel;
        private TextBox txtTel;
        private Label lblEmergencyContact;
        private TextBox txtEmergencyContact;
        private Label lblResignReason;
        private TextBox txtResignReason;
		private Panel pnlImg;
		private TrackBar trackImgZoom;
		private Button btnImgDownload;
		private Button btnImgDelete;
	}
}