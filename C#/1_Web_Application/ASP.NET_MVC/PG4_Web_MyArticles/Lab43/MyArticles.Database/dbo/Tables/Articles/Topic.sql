CREATE TABLE [dbo].[Topic]
(
	[TopicId] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	[Picture] VARBINARY(MAX),
	[PictureMimeType] VARCHAR(50),
);
GO


