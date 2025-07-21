namespace ISpan.eMiniHR.WinApp.Interfaces
{
    public interface IPageWithPermission
    {
        void OnPermissionAction(string action); // "查詢"、"新增"、"儲存"...
    }
}
