CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,         -- 主鍵，自動遞增
    Account VARCHAR(50) NOT NULL UNIQUE,          -- 帳號，唯一
    AccountName VARCHAR(50) NOT NULL,             -- 顯示名稱（如真實姓名）
    PasswordHash VARCHAR(100) NOT NULL,           -- 密碼雜湊
    IsActive BIT NOT NULL DEFAULT 1,              -- 是否啟用，預設為啟用
    Role NVARCHAR(10) NULL,                       -- 使用者身分（admin/client 等）
    CreatedTime DATETIME NOT NULL DEFAULT GETDATE(), -- 建立時間
    LastLoginTime DATETIME NULL                   -- 最後登入時間
);