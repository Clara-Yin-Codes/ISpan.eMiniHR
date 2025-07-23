using ISpan.eMiniHR.DataAccess.DapperRepositories;
using ISpan.eMiniHR.DataAccess.Models;

namespace ISpan.eMiniHR.WinApp.Helper
{
    /// <summary>
    /// 元件設定共用
    /// </summary>
    public static class ControlHelper
    {
		/// <summary>
		/// 設定清單中的部門名稱
		/// </summary>
		/// <param name="employees"></param>
		/// <param name="source"></param>
		/// 
		public static void TranslateProperty<TDto, TKey>(
			IEnumerable<TDto> employees,
			Func<TDto, TKey> keySelector,                       // 取得外鍵值
			Action<TDto, string> setNameAction,                 // 設定名稱的動作
			IEnumerable<KeyValuePair<TKey, string>> refList,    // 對照表 (如 DepId -> DepName)
			BindingSource source,
			BindingSource setSource)
		{
			// 設定來源 BindingSource
			source.DataSource = refList.ToList();

			// 建立字典供查詢名稱
			var refDict = refList.ToDictionary(x => x.Key, x => x.Value);

			// 為每筆 EmployeeDto 設定對應的名稱
			foreach (var emp in employees)
			{
				var key = keySelector(emp);
                if (key != null)
                {
                    var name = refDict.ContainsKey(key) ? refDict[key] : "(未指定)";
                    setNameAction(emp, name);
                }
			}

			// 更新資料來源
			setSource.DataSource = employees.ToList();
		}
		//public static void TranDeptName(IEnumerable<EmployeeDto> employees, BindingSource source, BindingSource setSource)
		//{
		//    // 取得部門清單並設定到 ComboBox 的 BindingSource
		//    var deptList = DeptsRepository.GetDepts().ToList();

		//    source.DataSource = deptList;

		//    // 轉換成 Dictionary 方便查找 DepName
		//    var depts = deptList.ToDictionary(d => d.DepId, d => d.DepName);

		//    // 將 DepName 設定到每一筆 EmployeeDto
		//    foreach (var emp in employees)
		//    {
		//        emp.DepName = depts.ContainsKey(emp.DepId) ? depts[emp.DepId] : "(未指定)";
		//    }

		//    setSource.DataSource = employees.ToList();
		//}

		/// <summary>
		/// 設定
		/// </summary>
		/// <param name="employees"></param>
		/// <param name="source"></param>
		//public static void TranDeptName(IEnumerable<EmployeeDto> employees, BindingSource source, BindingSource setSource)
		//{
		//	// 取得部門清單並設定到 ComboBox 的 BindingSource
		//	var deptList = DeptsRepository.GetDepts().ToList();

		//	source.DataSource = deptList;

		//	// 轉換成 Dictionary 方便查找 DepName
		//	var depts = deptList.ToDictionary(d => d.DepId, d => d.DepName);

		//	// 將 DepName 設定到每一筆 EmployeeDto
		//	foreach (var emp in employees)
		//	{
		//		emp.DepName = depts.ContainsKey(emp.DepId) ? depts[emp.DepId] : "(未指定)";
		//	}

		//	setSource.DataSource = employees.ToList();
		//}

		/*
         允許 object? 資料來源 + 完整封裝
        將 BindComboBox 包成泛型方法，支援強型別 List<T> 或一般 object。
        */
		public static void BindMultipleComboBoxes(
        BindingSource bindingSource, int type,
        (ComboBox cbo, object dataSource, string display, string value, string bindField)[] items)
        {
            foreach (var (cbo, data, display, value, bindField) in items)
            {
                if (type == 1) BindComboBox(cbo, data, display, value, bindField, bindingSource);
                else if (type == 2)
                {
                    var listType = data.GetType();
                    var listItemType = listType.GetGenericArguments().FirstOrDefault();

                    if (listItemType != null)
                    {
                        var method = typeof(ControlHelper)
                            .GetMethod("BindComboBoxWithPlaceholder")
                            ?.MakeGenericMethod(listItemType);

                        method?.Invoke(null, new object[] {
                            cbo,
                            data,
                            display,
                            value,
                            null,
                            null,
                            bindingSource,
                            bindField
                        });
                    }
                }
            }
        }

        /// <summary>
        /// 安全地綁定 ComboBox，支援雙向資料繫結，資料來源可為 null
        /// </summary>
        public static void BindComboBox(
            ComboBox comboBox,
            object dataSource,
            string displayMember,
            string valueMember,
            string bindingProperty,
            BindingSource bindingSource
        )
        {
            comboBox.DataBindings.Clear();

            if (dataSource == null) { comboBox.DataSource = null; return; }

            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

            comboBox.DataBindings.Add(
                "SelectedValue",
                bindingSource,
                bindingProperty,
                true,
                DataSourceUpdateMode.OnPropertyChanged
            );
        }

        /// <summary>
        /// 綁定 ComboBox，並在最前面插入「請選擇」提示項目
        /// </summary>
        public static void BindComboBoxWithPlaceholder<T>(
            ComboBox comboBox,
            List<T> list,
            string displayMember,
            string valueMember,
            object placeholderValue,
            string placeholderText,
            BindingSource bindingSource,
            string bindingProperty
        ) where T : new()
        {
            if (list == null) return;

            var placeholder = new T();

            var valueProp = typeof(T).GetProperty(valueMember);
            var textProp = typeof(T).GetProperty(displayMember);

            if (valueProp != null && textProp != null)
            {
                valueProp.SetValue(placeholder, placeholderValue);
                textProp.SetValue(placeholder, placeholderText);

                list.Insert(0, placeholder);
            }

            BindComboBox(comboBox, list, displayMember, valueMember, bindingProperty, bindingSource);
        }

        /// <summary>
        /// 設定 DataGridView 的可編輯狀態
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="isReadOnly"></param>
        public static void SetGridViewEnable(DataGridView gridView, bool isReadOnly) {
            //gridView.ReadOnly = isReadOnly;         // 鎖定內容不可編輯
            gridView.Enabled = isReadOnly;          // 保留滾動功能
            gridView.AllowUserToOrderColumns = !isReadOnly;
            gridView.AllowUserToResizeColumns = !isReadOnly;
            gridView.AllowUserToResizeRows = !isReadOnly;
        }

        /// <summary>
        /// 設定 DataGridView 的寬度
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="isReadOnly"></param>
        public static void SetGridViewColumnSize(DataGridView gridView)
        {
            int columnCount = gridView.ColumnCount;
            int width = gridView.Width - 60;
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                column.Width = width / columnCount;
            }
        }

        /// <summary>
        /// 快速設定 DataGridView 欄位與綁定資料來源
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="columns">欄位設定</param>
        /// <param name="dataSource">資料來源</param>
        /// <param name="allowMultiSelect">是否支援多選</param>
        public static void SetGridView(
            DataGridView dgv,
            List<(string Property, string Header)>? columns,
            object dataSource,
            bool allowMultiSelect = false
        )
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // 設定欄位資料
            if (columns != null) {
                foreach (var (property, header) in columns)
                {
                    dgv.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = property,
                        HeaderText = header
                    });
                }
            }

            // 設定清單樣式
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 選取整列
            dgv.MultiSelect = allowMultiSelect; // 是否允許多選
            dgv.DataSource = dataSource; // 綁定資料來源
            dgv.ReadOnly = true; // 設定為唯讀
            dgv.RowHeadersVisible = false; // 隱藏行標題
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // 自動調整欄位標題高度
            dgv.AllowUserToAddRows = false; // 禁止新增行
            dgv.AllowUserToDeleteRows = false; // 禁止刪除行
            dgv.AutoGenerateColumns = false; // 禁止自動生成欄位
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 自動調整欄位寬度
            dgv.BackgroundColor = SystemColors.ControlLight; // 設定背景色
        }

        /// <summary>
        /// 快速設定 Details 欄位與綁定資料來源
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="columns">欄位設定</param>
        /// <param name="dataSource">資料來源</param>
        /// <param name="allowMultiSelect">是否支援多選</param>
        public static void SetGridViewDetails(
            DataGridView dgv,
            List<(string Property, string Header, bool check)>? columns,
            object dataSource,
            bool allowMultiSelect = false
        )
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // 設定欄位資料
            if (columns != null)
            {
                foreach (var (property, header, check) in columns)
                {
                    if (check==true)
                    {
                        dgv.Columns.Add(new DataGridViewCheckBoxColumn
                        {
                            DataPropertyName = property,
                            HeaderText = header
                        });
                    }
                    else 
                    {
                        dgv.Columns.Add(new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = property,
                            HeaderText = header,
                            ReadOnly = true // 唯讀
                        });
                    }
                }
            }

            // 設定清單樣式
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 選取整列
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;    // 被選取背景色（淡一點）
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;           // 被選取文字色

            dgv.MultiSelect = allowMultiSelect; // 是否允許多選
            dgv.DataSource = dataSource; // 綁定資料來源
            //dgv.ReadOnly = true; // 設定為唯讀
            dgv.RowHeadersVisible = false; // 隱藏行標題
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // 自動調整欄位標題高度
            dgv.AllowUserToAddRows = false; // 禁止新增行
            dgv.AllowUserToDeleteRows = false; // 禁止刪除行
            dgv.AutoGenerateColumns = false; // 禁止自動生成欄位
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 自動調整欄位寬度
            dgv.BackgroundColor = SystemColors.ControlLight; // 設定背景色
        }
    }
}
