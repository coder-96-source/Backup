CREATE PROCEDURE [dbo].[SP_BK_AnnouncementsClear]
	@gap INT = 30
AS
	DELETE [dbo].[BK_Announcements]
	WHERE DATEDIFF(dd, ModifyDate, GETDATE()) > @gap
GO