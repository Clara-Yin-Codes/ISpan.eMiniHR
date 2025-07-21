namespace ISpan.eMiniHR.WinApp.Forms
{
    partial class MainForm
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
			panelSidebar = new Panel();
			tabControlMain = new TabControl();
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
			hopeForm1.Name = "hopeForm1";
			hopeForm1.Size = new Size(913, 40);
			hopeForm1.TabIndex = 1;
			hopeForm1.Text = "eMiniHR";
			hopeForm1.ThemeColor = Color.FromArgb(92, 173, 255);
			// 
			// panelSidebar
			// 
			panelSidebar.AutoScroll = true;
			panelSidebar.Dock = DockStyle.Left;
			panelSidebar.Location = new Point(0, 40);
			panelSidebar.Name = "panelSidebar";
			panelSidebar.Size = new Size(127, 449);
			panelSidebar.TabIndex = 2;
			// 
			// tabControlMain
			// 
			tabControlMain.Dock = DockStyle.Fill;
			tabControlMain.Location = new Point(127, 40);
			tabControlMain.Name = "tabControlMain";
			tabControlMain.SelectedIndex = 0;
			tabControlMain.Size = new Size(786, 449);
			tabControlMain.SizeMode = TabSizeMode.FillToRight;
			tabControlMain.TabIndex = 4;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(913, 489);
			Controls.Add(tabControlMain);
			Controls.Add(panelSidebar);
			Controls.Add(hopeForm1);
			FormBorderStyle = FormBorderStyle.None;
			MaximumSize = new Size(1493, 840);
			MinimumSize = new Size(190, 40);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "h";
			FormClosing += MainForm_FormClosing;
			Load += MainForm_Load;
			ResumeLayout(false);

		}

		#endregion
		private ReaLTaiizor.Forms.HopeForm hopeForm1;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.TabControl tabControlMain;
	}
}