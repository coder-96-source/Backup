CREATE TABLE [dbo].[Notes]
(
	[Id] INT Identity(1, 1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(25) NOT NULL, 
    [Email] NVARCHAR(100) NULL, 
    [Title] NVARCHAR(150) NOT NULL, 
    [PostDate] DATETIME NOT NULL DEFAULT GetData(), 
    [PostIP] NVARCHAR(15) NULL, 
    [Content] NTEXT NOT NULL, 
    [Password] NVARCHAR(20) NULL, 
    [ReadCount] INT NOT NULL DEFAULT 0, 
    [Encoding] NVARCHAR(10) NOT NULL,										--Encoding(HTML/TEXT)			
    [Homepage] NVARCHAR(100) NULL, 
    [ModifyDate] DATETIME NULL, 
    [ModifyIP] NVARCHAR(15) NULL, 
    [FileName] NVARCHAR(255) NULL, 
    [FileSize] INT NOT NULL DEFAULT 0, 
    [DownCount] INT NOT NULL DEFAULT 0, 
    [Ref] INT NOT NULL,														--Reference of parent article
    [Step] INT NOT NULL DEFAULT 0,											--Depth level of answer
    [RefOrder] INT NOT NULL DEFAULT 0,										--Number of answer
    [AnswerNum] INT NOT NULL DEFAULT 0,										--Answer counts
    [ParentNum] INT NOT NULL DEFAULT 0,										--Parent article number
    [CommentCount] INT NOT NULL DEFAULT 0, 
    [Category] NVARCHAR(10) NULL,
)
GO
