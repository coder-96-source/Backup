--Permission for users
CREATE TABLE [dbo].[Permission] 
(
	[UserId] INT FOREIGN KEY REFERENCES [User](UserId),
    [NoAccess] BIT DEFAULT(0),
    [Write]	BIT DEFAULT(1),			
    [Admin] BIT DEFAULT(0)				-- Permission for all tasks
--    [Comment]	BIT Default(1)			-- not needed, will use DISQUS Package instead
)
GO
