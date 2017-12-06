CREATE TABLE [dbo].[UserLogs]
(
	[UserLogId] INT NOT NULL PRIMARY KEY Identity(1, 1),
	[UserId] INT FOREIGN KEY REFERENCES [User](UserId),
	[FailedPasswordAttemptCount] INT DEFAULT(0)
)
Go
