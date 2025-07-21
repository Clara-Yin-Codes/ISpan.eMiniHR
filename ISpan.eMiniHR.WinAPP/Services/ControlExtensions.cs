namespace ISpan.eMiniHR.WinApp.Services
{
    /// <summary>
    /// 提供 Control 的擴充方法
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// 向上尋找某型別的父容器（例如 HRForm 或 IPageHost）
        /// </summary>
        public static T? FindFormOrParent<T>(this Control control) where T : class
        {
            Control? parent = control;
            while (parent != null)
            {
                if (parent is T matched)
                    return matched;

                parent = parent.Parent;
            }
            return null;
        }
    }
}
