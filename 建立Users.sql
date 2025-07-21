CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,         -- �D��A�۰ʻ��W
    Account VARCHAR(50) NOT NULL UNIQUE,          -- �b���A�ߤ@
    AccountName VARCHAR(50) NOT NULL,             -- ��ܦW�١]�p�u��m�W�^
    PasswordHash VARCHAR(100) NOT NULL,           -- �K�X����
    IsActive BIT NOT NULL DEFAULT 1,              -- �O�_�ҥΡA�w�]���ҥ�
    Role NVARCHAR(10) NULL,                       -- �ϥΪ̨����]admin/client ���^
    CreatedTime DATETIME NOT NULL DEFAULT GETDATE(), -- �إ߮ɶ�
    LastLoginTime DATETIME NULL                   -- �̫�n�J�ɶ�
);