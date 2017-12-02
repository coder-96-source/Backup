CREATE TABLE [dbo].[Tag]
(
	[TagId] INT NOT NULL PRIMARY KEY,
	[ArticleId] INT,
	[Content] NVARCHAR(100)
)
GO

CREATE INDEX TIndex
ON Tag (ArticleId)
GO

ALTER TABLE Tag
ADD CONSTRAINT FK_Article_Keyword_CAS
FOREIGN KEY (ArticleId) REFERENCES Article(ArticleId) ON DELETE CASCADE
GO

--Trigger
--backup on delete