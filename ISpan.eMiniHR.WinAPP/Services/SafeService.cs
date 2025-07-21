namespace ISpan.eMiniHR.WinApp.Services
{
	public class SafeService
	{
		public static void SafeBeginInvoke(Control control, Action action)
		{
			if (control == null || control.IsDisposed || !control.IsHandleCreated) return;

			if (control.InvokeRequired)
			{
				try
				{
					control.BeginInvoke(action);
				}
				catch (InvalidOperationException)
				{
					// 控制項已被釋放，略過
				}
			}
			else
			{
				action?.Invoke();
			}
		}
	}
}
