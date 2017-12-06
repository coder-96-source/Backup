CREATE PROCEDURE [dbo].[SP_BackupTopicClear]
	@gap INT = 30
AS
	DELETE Backup_Topic
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
GO
