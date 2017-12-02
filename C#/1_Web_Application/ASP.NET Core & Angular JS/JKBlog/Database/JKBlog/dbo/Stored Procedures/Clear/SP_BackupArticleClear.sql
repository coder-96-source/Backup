CREATE PROCEDURE [dbo].[SP_BackupArticleClear]
AS
	DELETE Backup_Article
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > 30
GO
