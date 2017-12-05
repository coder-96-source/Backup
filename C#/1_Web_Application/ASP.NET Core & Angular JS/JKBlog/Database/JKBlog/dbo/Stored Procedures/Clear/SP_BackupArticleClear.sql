CREATE PROCEDURE [dbo].[SP_BackupArticleClear]
	@gap INT = 30
AS
	DELETE Backup_Article
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
GO
