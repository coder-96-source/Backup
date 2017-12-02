﻿CREATE TABLE [dbo].[Topic]
(
	[TopicId] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(20) NOT NULL,
	[Description] NVarChar(200) Null,
	[Picture] VARBINARY(MAX),
	[PictureMimeType] VARCHAR(50),
	[PostDate] DATETIME DEFAULT GETDATE(),
	[ModifyDate] DATETIME Null,
	[ShowFlag] BIT NOT NULL
);
GO

CREATE TRIGGER trg_backupTopic ON Topic
INSTEAD OF DELETE
AS
BEGIN
	INSERT INTO Backup_Topic 
	SELECT * 
	FROM DELETED
END
GO