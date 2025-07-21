using ISpan.eMiniHR.WinApp.Forms;
using QuestPDF.Infrastructure;
namespace ISpan.eMiniHR.WinApp
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            QuestPDF.Settings.License = LicenseType.Community; // PDF授權設定
            Application.Run(new LoginForm());
        }
    }
}
