CREATE PROCEDURE [dbo].[SP_BackupArticleClear]
AS
	DECLARE @gap INT

	SET @gap = 30 -- 1 month

	DELETE Backup_Article
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
GO
