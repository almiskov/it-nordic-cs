-- DROP PROCEDURE IF EXISTS [dbo].[CreateChat]

CREATE PROCEDURE dbo.CreateChat(
	@chat AS VARCHAR(15),
	@chatId AS INT OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Chat
	VALUES (@chat)

	SET @chatId = SCOPE_IDENTITY()
END
GO


DECLARE @chatId AS INT
EXECUTE dbo.CreateChat @chat = '1211173', @chatid = @chatId OUTPUT
PRINT 'New chat has id = ' + CAST(@chatId AS VARCHAR(10))

SELECT * FROM dbo.Chat

DELETE dbo.Chat