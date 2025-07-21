namespace ISpan.eMiniHR.WinApp.Helper
{
    public static class QueryConditionHelper
    {
        public static T? ShowConditionDialog<T>() where T : class, new()
        {
            var form = new QueryConditionForm<T>();
            var result = form.ShowDialog();
            return result == DialogResult.OK ? form.QueryModel : null;
        }
    }
}
