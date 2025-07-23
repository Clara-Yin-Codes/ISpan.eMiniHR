using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

public class QueryConditionForm<T> : Form where T : class, new()
{
    public T QueryModel { get; private set; } = new();

    private readonly TableLayoutPanel _layout = new() {
        Dock = DockStyle.Top, // 不使用 Fill，才能保留空間觸發捲軸
        ColumnCount = 2,
        RowCount = 0,
        AutoSize = true,
        Padding = new Padding(10),
    };
    private readonly Button _btnOk = new() { Text = "確定", DialogResult = DialogResult.OK };
    private readonly Button _btnCancel = new() { Text = "取消", DialogResult = DialogResult.Cancel };

	public class FieldDisplayInfo
	{
		public string Label { get; set; } = "";
		public string ControlType { get; set; } = "Text"; // Text, Combo, Check
		public object? DataSource { get; set; } = null;   // ComboBox 專用
		public string? DisplayMember { get; set; } = null;
		public string? ValueMember { get; set; } = null;
		public object? DefaultValue { get; set; } // 預設值
	}

	public QueryConditionForm()
    {
        Text = "查詢條件";
        Size = new Size(300, 400);
        StartPosition = FormStartPosition.CenterParent;
        Load += QueryConditionForm_Load;
    }

    private void QueryConditionForm_Load(object sender, EventArgs e)
    {
        var pnl = new Panel()
        {
            AutoScroll = true,
            Dock = DockStyle.Fill
        };
        Controls.Add(pnl);

        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
        pnl.Controls.Add(_layout);

        int row = 0;
        var type = typeof(T);

		// 取得 DisplayNames 資訊
		var fieldDict = type.GetField("DisplayNames", BindingFlags.Static | BindingFlags.Public)
			?.GetValue(null) as Dictionary<string, FieldDisplayInfo> ?? new();

		foreach (var prop in type.GetProperties().Where(p => p.CanRead && p.CanWrite))
		{
			var fieldInfo = fieldDict.GetValueOrDefault(prop.Name) ?? new FieldDisplayInfo { Label = prop.Name };

			_layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			_layout.Controls.Add(new Label
			{
				Text = fieldInfo.Label,
				Anchor = AnchorStyles.Left,
				AutoSize = true
			}, 0, row);

			Control inputCtrl;

			switch (fieldInfo.ControlType)
			{
				case "Combo":
					var originalList = (fieldInfo.DataSource as IEnumerable<object>)?.Cast<object>().ToList() ?? new();

					// 建立一個空白項目（和原始類型一致）
					object? emptyItem = null;

					if (!string.IsNullOrEmpty(fieldInfo.ValueMember) && !string.IsNullOrEmpty(fieldInfo.DisplayMember))
					{
						var itemType = originalList.FirstOrDefault()?.GetType();
						if (itemType != null)
						{
							emptyItem = Activator.CreateInstance(itemType);
							itemType.GetProperty(fieldInfo.ValueMember!)?.SetValue(emptyItem, "");
							itemType.GetProperty(fieldInfo.DisplayMember!)?.SetValue(emptyItem, ""); // 或 "請選擇..."
						}
					}

					// 插入空白選項
					var newList = originalList.ToList();
					if (emptyItem != null)
						newList.Insert(0, emptyItem);

					var cbo = new ComboBox
					{
						DropDownStyle = ComboBoxStyle.DropDownList,
						Width = 200,
						Tag = prop,
						DisplayMember = fieldInfo.DisplayMember,
						ValueMember = fieldInfo.ValueMember,
						DataSource = newList
					};

					// 預設選第一筆（空白）
					cbo.HandleCreated += (s, e) =>
					{
						if (cbo.Items.Count > 0)
							cbo.SelectedIndex = 0;
					};

					// 預設值（SelectedValue）
					if (fieldInfo.DefaultValue != null)
						cbo.SelectedValue = fieldInfo.DefaultValue;

					inputCtrl = cbo;

					//var cbo = new ComboBox
					//{
					//	DropDownStyle = ComboBoxStyle.DropDownList,
					//	Width = 200,
					//	Tag = prop,
					//	DisplayMember = fieldInfo.DisplayMember,
					//	ValueMember = fieldInfo.ValueMember,
					//	DataSource = fieldInfo.DataSource
					//};
					//inputCtrl = cbo;
					break;

				case "Check":
					var chk = new CheckBox
					{
						Width = 200,
						Tag = prop,
						Checked = fieldInfo.DefaultValue as bool? ?? false // 預設值
					};
					inputCtrl = chk;
					break;

				default: // Text
					var txt = new TextBox
					{
						Width = 200,
						Tag = prop
					};

					if (fieldInfo.DefaultValue != null)
						txt.Text = fieldInfo.DefaultValue.ToString(); // 預設值

					inputCtrl = txt;
					break;
			}

			inputCtrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			_layout.Controls.Add(inputCtrl, 1, row);
			row++;
		}

		var buttonPanel = new FlowLayoutPanel
		{
			FlowDirection = FlowDirection.RightToLeft,
			Dock = DockStyle.Bottom,
			Height = 50,
			Padding = new Padding(5)
		};
		buttonPanel.Controls.Add(_btnOk);
		buttonPanel.Controls.Add(_btnCancel);
		Controls.Add(buttonPanel);

		_btnOk.Click += BtnOk_Click;
	}

	private void BtnOk_Click(object? sender, EventArgs e)
    {
		foreach (Control ctrl in _layout.Controls)
		{
			if (ctrl.Tag is not PropertyInfo prop) continue;

			object? value = null;

			switch (ctrl)
			{
				case TextBox txt:
					if (!string.IsNullOrWhiteSpace(txt.Text))
					{
						value = Convert.ChangeType(txt.Text.Trim(), Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
					}
					break;

				case ComboBox cbo:
					value = cbo.SelectedValue;
					break;

				case CheckBox chk:
					value = chk.Checked;
					break;
			}

			if (value != null)
			{
				prop.SetValue(QueryModel, value);
			}
		}
	}
}
