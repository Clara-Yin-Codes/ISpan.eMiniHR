using ISpan.eMiniHR.DataAccess.Models;
using ISpan.eMiniHR.WinApp.Properties;
using ISpan.eMiniHR.WinApp.Services;
using System.ComponentModel;

namespace ISpan.eMiniHR.WinApp.Components
{
    public class PermissionToolBar : FlowLayoutPanel
    {
        public IEnumerable<Button> Buttons => this.Controls.OfType<Button>();
        public event EventHandler<Button>? PermissionButtonClicked; // 事件：當按鈕被點擊時觸發
        /// <summary>
        /// 增加權限按鈕到工具列
        /// </summary>
        /// <param name="perm"></param>
        public IEnumerable<Button> LoadPermission(string progSysId)
        {
            Controls.Clear();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                string.IsNullOrEmpty(progSysId) ||
                LoginSession.User == null)
            {
                return Enumerable.Empty<Button>();
            }

            FlowDirection = FlowDirection.LeftToRight;
            WrapContents = false;
            AutoSize = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Margin = new Padding(0);
            Padding = new Padding(10, 0, 0, 0);

            // 取得權限（包含 Admin 預設權限）
            var user = LoginSession.User;
            var perm = user.Permissions.FirstOrDefault(p => p.ProgSysId == progSysId)
                    ?? (user.IsAdmin ? GetAdminFullPermission(progSysId) : null);

            // if (perm == null) Controls.OfType<Button>();
            if (perm == null) return Enumerable.Empty<Button>();

            bool canEdit = perm.Addable==true || perm.Editable == true;

            var items = new (bool condition, string text)[]
            {
                (perm.Queryable==true, "查詢"),
                (perm.Addable==true, "新增"),
                (perm.Editable==true, "編輯"),
                (canEdit, "儲存"),
                (canEdit, "取消"),
                (perm.Deletable==true, "刪除"),
                (perm.Voidable==true, "作廢"),
                (perm.Downloadable==true, "匯出"),
                (perm.Printable==true, "列印"),
                (perm.Testable==true, "測試"),
            };

            foreach (var (condition, text) in items)
            {
                if (condition)
                {
                    var btn = CreatePermissionButton(text);
                    Controls.Add(btn);
                }
            }
            return Controls.OfType<Button>();
        }

        /// <summary>
        /// 管理員預設權限
        /// </summary>
        /// <param name="progSysId"></param>
        /// <returns></returns>
        private ProgramPermissionsDto GetAdminFullPermission(string progSysId) => new ProgramPermissionsDto
            {
                ProgSysId = progSysId,
                Queryable = true,
                Addable = true,
                Editable = true,
                Deletable = true,
                Voidable = true,
                Downloadable = true,
                Printable = true,
                Testable = true
            };

        /// <summary>
        /// 建立權限按鈕
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Button CreatePermissionButton(string text)
        {
            var btn = new Button
            {
                Text = text,
                Tag = text,
                Font = new Font("微軟正黑體", 10),
                TextImageRelation = TextImageRelation.ImageAboveText,
                ImageAlign = ContentAlignment.MiddleCenter,
                TextAlign = ContentAlignment.BottomCenter,
                BackColor = Color.Gray, // 預設底色
                UseVisualStyleBackColor = false, // 設定可自訂背景顏色
                Width = 50,
                Height = 55,
                Image = GetIconByText(text)
            };

            // 點擊時觸發自訂事件，傳回按鈕文字（例如 "查詢"）
            btn.Click += (s, e) =>
            {
                PermissionButtonClicked?.Invoke(this, btn);
            };

            return btn;
        }

        /// <summary>
        /// 按鈕文字對應的圖示
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Image? GetIconByText(string text)
        {
            Image rawImage;
            switch (text)
            {
                case "查詢":
                    rawImage = Resources.icon_search;
                    break;
                case "新增":
                    rawImage = Resources.icon_add;
                    break;
                case "編輯":
                    rawImage = Resources.icon_edit;
                    break;
                case "儲存":
                    rawImage = Resources.icon_save;
                    break;
                case "取消":
                    rawImage = Resources.icon_cancel;
                    break;
                case "刪除":
                    rawImage = Resources.icon_delete;
                    break;
                case "作廢":
                    rawImage = Resources.icon_void;
                    break;
                case "匯出":
                    rawImage = Resources.icon_export;
                    break;
                case "列印":
                    rawImage = Resources.icon_print;
                    break;
                case "測試":
                    rawImage = Resources.icon_test;
                    break;
                default:
                    return null;
            }
            return ResizeImage(rawImage, 24, 24);
        }

        /// <summary>
        /// 設定圖示大小
        /// </summary>
        /// <param name="img"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Image ResizeImage(Image img, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }
    }
}
