namespace ISpan.eMiniHR.WinApp.Interfaces
{
    public interface IPermissionButtonHost
    {
        void SetActivePermissionByTexts(IEnumerable<string> activeTexts);
        void SetButtonEnabledByTexts(IEnumerable<string> texts);
    }
}
