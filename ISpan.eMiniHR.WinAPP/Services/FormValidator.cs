namespace ISpan.eMiniHR.WinApp.Services
{
    public class FormValidator
    {
        private readonly List<(Func<bool> Condition, string Message)> _rules = new();

        public FormValidator(params (Func<bool> Condition, string Message)[] rules)
        {
            _rules.AddRange(rules);
        }

        public void AddRule(Func<bool> condition, string message)
        {
            _rules.Add((condition, message));
        }

        public bool Validate()
        {
            foreach (var (condition, message) in _rules)
            {
                if (condition())
                {
                    MessageBox.Show(message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}