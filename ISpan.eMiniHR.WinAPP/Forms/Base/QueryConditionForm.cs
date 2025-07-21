using System.Reflection;

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

    public QueryConditionForm()
    {
        Text = "查詢條件";
        Size = new Size(300, 300);
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

        var displayNameDict = type.GetField("DisplayNames", BindingFlags.Static | BindingFlags.Public)
            ?.GetValue(null) as Dictionary<string, string> ?? new Dictionary<string, string>();
        // 取得屬性，並長出對應的 Label 和 TextBox
        foreach (var prop in type.GetProperties().Where(p => p.CanRead && p.CanWrite))
        {
            string displayName = displayNameDict.GetValueOrDefault(prop.Name) ?? prop.Name;

            _layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _layout.Controls.Add(new Label 
            { 
                Text = displayName, 
                Anchor = AnchorStyles.Left, 
                AutoSize = true 
            }, 0, row);

            var textbox = new TextBox 
            { 
                Name = $"txt{prop.Name}", 
                Anchor = AnchorStyles.Left | AnchorStyles.Right, 
                Width = 200,
                Tag = prop
            };

            _layout.Controls.Add(textbox, 1, row);

            row++;
        }

        // 按鈕區塊
        var buttonPanel = new FlowLayoutPanel { 
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
        foreach (var ctrl in _layout.Controls.OfType<TextBox>())
        {
            if (ctrl.Tag is PropertyInfo prop)
            {
                var value = ctrl.Text?.Trim();
                if (!string.IsNullOrEmpty(value))
                {
                    object? converted = Convert.ChangeType(value, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    prop.SetValue(QueryModel, converted);
                }
            }
        }
    }
}
