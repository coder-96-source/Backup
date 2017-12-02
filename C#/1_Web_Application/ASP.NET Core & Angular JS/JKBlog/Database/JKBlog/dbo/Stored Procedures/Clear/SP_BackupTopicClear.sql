CREATE PROCEDURE [dbo].[SP_BackupTopicClear]
AS
	DECLARE @gap INT

	SET @gap = 30 -- 1 month

	DELETE Backup_Topic
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
GO
