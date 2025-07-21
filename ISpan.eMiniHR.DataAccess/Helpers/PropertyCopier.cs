namespace ISpan.eMiniHR.DataAccess.Helpers
{
    public static class PropertyCopier
    {
        public static void CopyNonDefaultValues<T>(T source, T target, string[]? exclude = null)
        {
            var props = typeof(T).GetProperties().Where(p => p.CanWrite);
            foreach (var prop in props)
            {
                if (exclude != null && !exclude.Contains(prop.Name)) continue;

                var value = prop.GetValue(source);
                var defaultValue = prop.PropertyType.IsValueType ? Activator.CreateInstance(prop.PropertyType) : null;

                if (value != null && !Equals(value, defaultValue))
                {
                    prop.SetValue(target, value);
                }
            }
        }
    }

}
