--Permission for users
CREATE TABLE [dbo].[Permission] 
(
	[UserId] INT FOREIGN KEY REFERENCES [User](UserId),
    [PermissionType]  VARCHAR(50)
)
GO
