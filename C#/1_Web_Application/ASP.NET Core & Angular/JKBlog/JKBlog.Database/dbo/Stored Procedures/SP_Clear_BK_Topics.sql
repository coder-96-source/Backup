CREATE PROCEDURE [dbo].[SP_BK_TopicsClear]
	@gap INT = 30
AS
	DELETE [dbo].[BK_Topics]
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
GO