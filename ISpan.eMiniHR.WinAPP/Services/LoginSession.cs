using ISpan.eMiniHR.DataAccess.EfRepositories;
using ISpan.eMiniHR.DataAccess.Models;

namespace ISpan.eMiniHR.WinApp.Services
{
    public static class LoginSession
    {
        /// <summary>
        /// 目前登入的使用者資訊
        /// </summary>
        public static LoginUserInfoDto? User { get; private set; }

        /// <summary>
        /// 登入狀態
        /// </summary>
        public static bool IsLoggedIn => User != null;

        /// <summary>
        /// 設定目前登入的使用者資訊
        /// </summary>
        /// <param name="user"></param>
        public static void SetLoginUser(LoginUserInfoDto user)
        {
            User = user;

            // 儲存最後登入時間到 Users 系統成員
            if (string.IsNullOrWhiteSpace(User.UserId) == false) {
                UserEfRepository.UpdateLastLoginTime(User.UserId, User.LoginTime);
            }
        }

        /// <summary>
        /// 使用者可用的功能選單清單（含權限）
        /// </summary>
        public static List<ProgramsConfigDto> MenuItems { get; private set; } = new List<ProgramsConfigDto>();

        /// <summary>
        /// 設定目前可用清單
        /// </summary>
        /// <param name="menuItems"></param>
        public static void SetMenuItems(List<ProgramsConfigDto> menuItems)
        {
            MenuItems = menuItems;
        }

        /// <summary>
        /// 登出目前使用者
        /// </summary>
        public static void Logout()
        {
            MenuItems = null;
            User = null;
        }
    }
}
