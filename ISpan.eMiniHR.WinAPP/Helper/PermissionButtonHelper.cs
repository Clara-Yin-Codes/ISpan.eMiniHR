using ISpan.eMiniHR.WinApp.Interfaces;
using ISpan.eMiniHR.WinApp.Services;

namespace ISpan.eMiniHR.WinApp.Helper
{
    public static class PermissionButtonHelper
    {
        private static string[] _editMode = new[] { "儲存", "取消" }; // 編輯模式按鈕
        /// <summary>
        /// 設定頁面按鈕權限
        /// 向上找父容器是否實作 IPermissionButtonHost
        /// </summary>
        public static void SetPermissions(this Control page, string[]? allButtons)
        {
            var host = page.FindFormOrParent<IPermissionButtonHost>();

            // 高亮所有操作按鈕（例如查詢、新增等）
            if (allButtons != null) host?.SetActivePermissionByTexts(allButtons);

            // 若 enabledButtons 為 null，則不啟用任何按鈕
            if (allButtons != null) {
                var toEnable = allButtons.Except(_editMode).ToArray(); // 排除編輯模式按鈕
                host?.SetButtonEnabledByTexts(toEnable); // 啟用非編輯模式按鈕
            }
            else
            {
                host?.SetButtonEnabledByTexts(_editMode); // 啟用編輯模式按鈕
            }
        }
    }
}
