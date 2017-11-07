CREATE PROCEDURE [dbo].[WriteNote]
	@Name		NVARCHAR(25),
	@Email		NVARCHAR(100),
	@Title		NVARCHAR(150),
	@PostIP		NVARCHAR(15),
	@Content	NTEXT,
	@Password	NVARCHAR(20),
	@Encoding	NVARCHAR(10),
	@Homepage	NVARCHAR(100),
	@FileName	NVARCHAR(255),
	@FileSize	INT
AS
	DECLARE	@MaxRef INT
	SELECT @MaxRef = MAX(Ref) FROM Notes

	IF @MaxRef IS NULL
		SET @MaxRef = 1 -- First comparison
	ELSE
		SET @MaxRef = @MaxRef + 1

	INSERT Notes
	(
		Name, Email, Title, PostIP, Content, Password, Encoding,
		Homepage, Ref, FileName, FileSize
	)
	VALUES
	(
		@Name, @Email, @Title, @PostIP, @Content, @Password, @Encoding,
		@Homepage, @MaxRef, @FileName, @FileSize
	)
GO
