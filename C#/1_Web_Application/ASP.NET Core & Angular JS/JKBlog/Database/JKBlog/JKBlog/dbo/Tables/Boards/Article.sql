CREATE TABLE [dbo].[Article]
(
	[ArticleId] INT NOT NULL PRIMARY KEY,
	[TopicId] INT FOREIGN KEY REFERENCES Topic(TopicId),
	[Title] NVARCHAR(100) NOT NULL,
	[Content] NVARCHAR(MAX) NOT NULL,
	[PostTime] DATETIME NOT NULL,
	[ShowFlag] bit NOT NULL,
);
GO

CREATE INDEX AIndex
ON Article (TopicId)
GO