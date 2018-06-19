CREATE TABLE [dbo].[Comment]
(
	[CommentId] INT NOT NULL PRIMARY KEY,
	[ArticleId] INT,
	[Content] NVARCHAR(MAX) NOT NULL,
	[CommentPassword] NVARCHAR(128) NOT NULL,
	[PostTime] DATETIME NOT NULL,
);
GO

CREATE INDEX CIndex
ON Comment (ArticleId)
GO

ALTER TABLE Comment
ADD CONSTRAINT FK_Article_Comment_CAS
FOREIGN KEY (ArticleId) REFERENCES Article(ArticleId) ON DELETE CASCADE
GO
