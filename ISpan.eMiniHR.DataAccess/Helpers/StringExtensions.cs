namespace ISpan.eMiniHR.DataAccess.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// 轉換字串為 null，如果字串為空或只包含空白字元則返回 null，否則返回去除前後空白的字串。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string? NullIfEmpty(this string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }
}
