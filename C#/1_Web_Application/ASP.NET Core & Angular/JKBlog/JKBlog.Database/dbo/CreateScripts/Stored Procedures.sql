--CREATE PROCEDURE [dbo].[SP_BK_TopicsClear]
--	@gap INT = 30
--AS
--	DELETE [dbo].[BK_Topics]
--	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
--GO

--CREATE PROCEDURE [dbo].[SP_BK_ArticlesClear]
--	@gap INT = 30
--AS
--	DELETE [dbo].[BK_Articles]
--	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
--GO

--CREATE PROCEDURE [dbo].[SP_BK_AnnouncementsClear]
--	@gap INT = 30
--AS
--	DELETE [dbo].[BK_Announcements]
--	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
--GO