CREATE TABLE [dbo].[Article]
(
	[ArticleId] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[TopicId] INT FOREIGN KEY REFERENCES Topic(TopicId),
	[Title] NVARCHAR(100) NOT NULL,
	[Content] NVARCHAR(MAX) NOT NULL,
	[ContentDisplay] NVARCHAR(50) NOT NULL,
	[Category] NVARCHAR(10) DEFAULT('Free') NULL, -- Category, inside of topic
	[PostDate] DATETIME DEFAULT GETDATE(),
	[ModifyDate] DATETIME NULL,
	[ReadCount] INT DEFAULT 0,
    [CommentCount] INT DEFAULT 0,
	[ShowFlag] BIT NOT NULL
);
GO

CREATE INDEX AIndex
ON Article (TopicId)
GO

--Shorten Content to ContentDisplay
CREATE TRIGGER trg_ShortenContent ON Article
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @shortenContent NVARCHAR(MAX)
	
	SELECT @shortenContent = INSERTED.Content
	FROM INSERTED

	UPDATE Article SET ContentDisplay = SUBSTRING(@shortenContent, 0, 49) 
END
GO

--Backup
CREATE TRIGGER trg_backupArticle ON Article
INSTEAD OF DELETE
AS
BEGIN
	INSERT INTO Backup_Article 
	SELECT * 
	FROM DELETED
END
GO


