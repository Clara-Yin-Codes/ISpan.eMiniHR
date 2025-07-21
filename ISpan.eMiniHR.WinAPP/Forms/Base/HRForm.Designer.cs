namespace ISpan.eMiniHR.WinApp.Forms.Base
{
	partial class HRForm
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
			hRLayout = new TableLayoutPanel();
			headerLayout = new TableLayoutPanel();
			lblTitle = new Label();
			contentPanel = new Panel();
			hRLayout.SuspendLayout();
			headerLayout.SuspendLayout();
			SuspendLayout();
			// 
			// hRLayout
			// 
			hRLayout.ColumnCount = 1;
			hRLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
			hRLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			hRLayout.Controls.Add(headerLayout, 0, 0);
			hRLayout.Controls.Add(contentPanel, 0, 1);
			hRLayout.Dock = DockStyle.Fill;
			hRLayout.Location = new Point(0, 0);
			hRLayout.Name = "hRLayout";
			hRLayout.RowCount = 2;
			hRLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
			hRLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			hRLayout.Size = new Size(1169, 671);
			hRLayout.TabIndex = 0;
			// 
			// headerLayout
			// 
			headerLayout.ColumnCount = 2;
			headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
			headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			headerLayout.Controls.Add(lblTitle, 0, 0);
			headerLayout.Dock = DockStyle.Fill;
			headerLayout.Location = new Point(3, 3);
			headerLayout.Name = "headerLayout";
			headerLayout.RowCount = 1;
			headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			headerLayout.Size = new Size(1163, 59);
			headerLayout.TabIndex = 0;
			// 
			// lblTitle
			// 
			lblTitle.Font = new Font("微軟正黑體", 16F, FontStyle.Bold);
			lblTitle.Location = new Point(0, 20);
			lblTitle.Margin = new Padding(0, 20, 80, 0);
			lblTitle.Name = "lblTitle";
			lblTitle.Padding = new Padding(10, 0, 0, 0);
			lblTitle.Size = new Size(220, 28);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "未命名頁面";
			// 
			// contentPanel
			// 
			contentPanel.Dock = DockStyle.Fill;
			contentPanel.Location = new Point(3, 68);
			contentPanel.Name = "contentPanel";
			contentPanel.Size = new Size(1163, 600);
			contentPanel.TabIndex = 1;
			// 
			// HRForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(hRLayout);
			Name = "HRForm";
			Size = new Size(1169, 671);
			Load += HRForm_Load;
			hRLayout.ResumeLayout(false);
			headerLayout.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel hRLayout;
		private TableLayoutPanel headerLayout;
		private Label lblTitle;
		private Panel contentPanel;
	}
}