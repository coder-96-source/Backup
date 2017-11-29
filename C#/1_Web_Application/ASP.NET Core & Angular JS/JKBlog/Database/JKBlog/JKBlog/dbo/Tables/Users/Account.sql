CREATE TABLE [dbo].[Account]
(
	[AccountId] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	[AccountPassword] NVARCHAR(128) NOT NULL,
)
GO
