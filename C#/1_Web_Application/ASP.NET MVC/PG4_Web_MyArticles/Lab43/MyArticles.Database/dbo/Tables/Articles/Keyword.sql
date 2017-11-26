CREATE TABLE [dbo].[Keyword]
(
	[KeywordId] INT NOT NULL PRIMARY KEY,
	[ArticleId] INT,
	[Content] NVARCHAR(100),
)
GO

CREATE INDEX KIndex
ON Keyword (ArticleID)
GO

ALTER TABLE Keyword
ADD CONSTRAINT FK_Article_Keyword_CAS
FOREIGN KEY (ArticleId) REFERENCES Article(ArticleId) ON DELETE CASCADE
GO