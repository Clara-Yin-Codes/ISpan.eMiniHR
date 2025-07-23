CREATE TABLE Users (
    UserId varchar(50) PRIMARY KEY,         -- �D��A�۰ʻ��W
    Account VARCHAR(50) NOT NULL UNIQUE,          -- �b���A�ߤ@
    AccountName VARCHAR(50) NOT NULL,             -- ��ܦW�١]�p�u��m�W�^
    PasswordHash varbinary(32) NOT NULL,           -- �K�X����
    IsActive BIT NOT NULL DEFAULT 1,              -- �O�_�ҥΡA�w�]���ҥ�
    SysRole NVARCHAR(10) NULL,                       -- �ϥΪ̨����]admin/client ���^
    CreateDate DATETIME NOT NULL DEFAULT GETDATE(), -- �إ߮ɶ�
    LastLoginTime DATETIME NULL                   -- �̫�n�J�ɶ�
);

SELECT UserId, Account, AccountName,
                        PasswordHash, IsActive, SysRole,
                        CreateDate, LastLoginTime
                        FROM Users