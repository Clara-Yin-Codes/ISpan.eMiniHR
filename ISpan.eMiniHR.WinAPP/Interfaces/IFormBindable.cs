namespace ISpan.eMiniHR.WinApp.Interfaces
{
    internal interface IFormBindable
    {
        /// <summary>
        /// 按鈕點擊事件處理
        /// </summary>
        /// <param name="action">動作</param>
        void OnPermissionAction(string action);
        /// <summary>
        /// 編輯狀態預設
        /// </summary>
        void InitEdit();
        /// <summary>
        /// 設定控制項是否唯讀
        /// </summary>
        /// <param name="isReadQnly"></param>
        void SetControlsReadOnly(bool isReadQnly);
        /// <summary>
        /// 儲存資料
        /// </summary>
        /// <param name="action"></param>
        void SaveData(string action);
        /// <summary>
        /// 檢查記錄資料完整性
        /// </summary>
        /// <returns></returns>
        bool CheckData();
    }
}
