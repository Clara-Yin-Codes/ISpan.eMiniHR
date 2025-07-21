using ISpan.eMiniHR.DataAccess.Helpers;
using ISpan.eMiniHR.DataAccess.Models;
using ISpan.eMiniHR.WinApp.Services;
using QuestPDF.Fluent;
using System.Diagnostics;

namespace ISpan.eMiniHR.WinApp.Helper
{
    public class FormActionHandler<T>
    {
        // 執行項
        private readonly BindingSource _bindingSource;
        private readonly Func<T> _getCurrent;
        private readonly Func<T> _createNewFunc;
        private string[] _initEdit;
        private readonly Action<bool> _setControlsReadOnly;
        private readonly Action _refreshBinding;
        private readonly Func<string, int> _deleteFunc;
        private readonly Func<T, int> _addFunc;
        private readonly Func<T, int> _updateFunc;
        private readonly Func<bool> _validateFunc;
        private string _currentAction;
        private readonly Action _refreshData;
        private readonly object? _queryViewModel;
        private readonly Action? _exportPDF;

        public FormActionHandler(
            BindingSource bindingSource,
            Func<T> getCurrent,
            Func<T> createNewFunc,
            string[] initEdit,
            Action<bool> setControlsReadOnly,
            Action refreshBinding,
            Func<string, int> deleteFunc,
            Func<T, int> addFunc,
            Func<T, int> updateFunc,
            Func<bool> validateFunc,
            string currentAction,
            Action refreshData,
            object? queryViewModel,
            Action? exportPDF
            )
        {
            _bindingSource = bindingSource;
            _getCurrent = getCurrent;
            _createNewFunc = createNewFunc;
            _setControlsReadOnly = setControlsReadOnly;
            _refreshBinding = refreshBinding;
            _deleteFunc = deleteFunc;
            _addFunc = addFunc;
            _updateFunc = updateFunc;
            _validateFunc = validateFunc;
            _currentAction = currentAction;
            _refreshData = refreshData;
            _queryViewModel = queryViewModel;
            _initEdit = initEdit;
            _exportPDF = exportPDF;
        }

        public string OnAction(string action)
        {
            var cur = _getCurrent();

            switch (action)
            {
                case "查詢":
                    //_setControlsReadOnly(true);
                    if (_queryViewModel == null) _currentAction = action;

                    var vmType = _queryViewModel.GetType(); // 取得 ViewModel 實際型別
                    var formType = typeof(QueryConditionForm<>).MakeGenericType(vmType);
                    var formInstance = (Form)Activator.CreateInstance(formType)!;

                    if (formInstance.ShowDialog() == DialogResult.OK)
                    {
                        // 取得查詢條件物件的屬性 QueryModel
                        var queryModelProp = formType.GetProperty("QueryModel");
                        var queryModel = queryModelProp?.GetValue(formInstance);
                        // 根據 queryModel 進行查詢
                    }
                    break;

                case "新增":
                    var newItem = _createNewFunc();
                    _bindingSource.Add(newItem);
                    _bindingSource.MoveLast();
                    _setControlsReadOnly(false);
                    _currentAction = action;
                    break;

                case "編輯":
                    var editItem = _createNewFunc();

                    var props = typeof(EmployeeDto)
                        .GetProperties()
                        .Where(p => p.CanWrite);

                    PropertyCopier.CopyNonDefaultValues(editItem, cur, _initEdit);

                    _refreshBinding();
                    _setControlsReadOnly(false);
                    _currentAction = action;
                    break;

                case "取消":
                    Cancel(_currentAction, _bindingSource);

                    _refreshData(); // 重新查詢整份清單（從資料庫）
                    _refreshBinding(); // 重新綁定（如果有 BindingSource 的話）
                    _setControlsReadOnly(true); // 回復為唯讀狀態
                    _currentAction = "查詢";
                    break;

                case "刪除":
                    var id = typeof(T).GetProperty("EmpId")?.GetValue(cur)?.ToString();
                    ConfirmAndDelete(id, _deleteFunc, _bindingSource, "資料", _refreshBinding);
                    break;

                case "儲存":
                    if (_validateFunc())
                    {
                        _setControlsReadOnly(true);

                        int result = _currentAction == "新增"
                            ? _addFunc(cur)
                            : _updateFunc(cur);

                        if (result > 0)
                        {
                            MessageBox.Show("儲存成功");
                            _refreshData(); // 重新查詢整份清單（從資料庫）
                            _refreshBinding();
                            _currentAction = "查詢";
                        }
                    }
                    break;
                case "匯出":
                    _exportPDF();
                    break;
            }
            return _currentAction;
        }

        private string GetPropValue(object obj, string propName)
        {
            var prop = obj.GetType().GetProperty(propName);
            return prop?.GetValue(obj)?.ToString() ?? "未知";
        }

        public static void Cancel(
            string currentAction, BindingSource bindingSource)
        {
            if (currentAction == "新增")
            {
                var current = bindingSource.Current;
                if (current != null)
                {
                    bindingSource.Remove(current);
                }
            }
            else if (currentAction == "編輯")
            {
                bindingSource.CancelEdit();
            }
        }

        /// <summary>
        /// 通用刪除邏輯
        /// </summary>
        /// <param name="key">主鍵值（如 EmpId）</param>
        /// <param name="deleteFunc">資料刪除方法，回傳受影響筆數</param>
        /// <param name="bindingSource">畫面上的資料繫結來源</param>
        /// <param name="entityName">資料名稱顯示用（如「員工」）</param>
        /// <param name="onRefresh">成功後要額外做的事，例如重新繫結畫面</param>
        public static void ConfirmAndDelete(
            string key,
            Func<string, int> deleteFunc,
            BindingSource bindingSource,
            string entityName = "資料",
            Action? onRefresh = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show($"請先選擇要刪除的{entityName}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"確定要刪除這筆{entityName}嗎？", "刪除確認",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                int rowsAffected = deleteFunc(key);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("刪除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindingSource.RemoveCurrent();
                    onRefresh?.Invoke();
                }
                else
                {
                    MessageBox.Show($"刪除失敗，找不到{entityName}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleErrorMsg(ex); // 可替換為你自訂的錯誤處理
            }
        }

        // 儲存邏輯 (委派)
        public delegate bool ValidateFunc();
        public delegate void SetReadOnlyFunc(bool isReadOnly);
        public delegate void RefreshFunc();
        public delegate object? GetCurrentFunc();
        public delegate int AddOrUpdateFunc(object data);
        public delegate void ShowLoadingFunc(bool isVisible);

        public static void Save(
            string action,
            ValidateFunc checkData,
            SetReadOnlyFunc setReadOnly,
            GetCurrentFunc getCurrent,
            AddOrUpdateFunc addFunc,
            AddOrUpdateFunc updateFunc,
            RefreshFunc refresh,
            ShowLoadingFunc setLoading = null!
)
        {
            if (!checkData()) return;

            setLoading?.Invoke(true);
            setReadOnly(true);

            try
            {
                int result = 0;
                var current = getCurrent();

                if (action == "新增")
                {
                    result = addFunc(current!);
                }
                else if (action == "編輯")
                {
                    result = updateFunc(current!);
                }

                if (result > 0)
                {
                    MessageBox.Show("儲存成功");
                }

                refresh();          // 查詢更新資料來源
                setReadOnly(true);  // 重設唯讀狀態
            }
            catch (Exception ex)
            {
                setReadOnly(false);
                ErrorHandler.HandleErrorMsg(ex);
            }
            finally
            {
                setLoading?.Invoke(false);
            }
        }
    }
}
