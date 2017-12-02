CREATE PROCEDURE [dbo].[SP_BackupTopicClear]
AS
	DELETE Backup_Topic
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > 30
GO
