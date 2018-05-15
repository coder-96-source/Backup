CREATE TABLE [dbo].[Users]
(
	[UserId] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[PermissionId] INT FOREIGN KEY REFERENCES [dbo].[Permissions](PermissionId),
	[Name] NVARCHAR(20) NOT NULL,
	[Password] NVARCHAR(255) NOT NULL,
	[Birthdate] DATETIME2 NULL,
	[Picture] VARBINARY(MAX) NULL,
	[PictureMimeType] VARCHAR(50) NULL
)
GO