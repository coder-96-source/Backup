Create Table Logs
(
	[Id]				INT IDENTITY(1, 1) Primary Key Not Null,
	[Note]				NVARCHAR(Max) Null,
	[Message]			NVARCHAR(Max) Null,
	[TimeStamp]			DATETIMEOFFSET(7) Not Null,
)
Go