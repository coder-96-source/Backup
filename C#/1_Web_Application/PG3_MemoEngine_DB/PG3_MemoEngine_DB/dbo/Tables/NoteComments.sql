CREATE TABLE [dbo].[NoteComments]
(
	[Id] INT Identity(1, 1) NOT NULL PRIMARY KEY, 
    [BoardName] NVARCHAR(50) NULL, 
    [BoardID] NCHAR(10) NOT NULL, 
    [Name] NVARCHAR(25) NULL, 
    [Opinion] NVARCHAR(4000) NULL, 
    [PostDate] SMALLDATETIME NULL DEFAULT GetDate(), 
    [Password] NVARCHAR(20) NOT NULL
)
GO
