CREATE PROCEDURE [dbo].[SP_BK_ArticlesClear]
	@gap INT = 30
AS
	DELETE [dbo].[BK_Articles]
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
GO