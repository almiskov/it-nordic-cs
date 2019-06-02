-- DROP PROCEDURE IF EXISTS [dbo].[GetChatId]

CREATE FUNCTION dbo.GetChatId (
	@chat AS VARCHAR(15)
)
RETURNS INT AS
BEGIN
	DECLARE @chatId AS INT

	SELECT @chatId = Id
	FROM dbo.Chat c
	WHERE c.Chat = @chat

	RETURN @chatId
END
GO

SELECT * FROM dbo.Chat
SELECT dbo.GetChatId('22572') AS ChatId
SELECT dbo.GetChatId('1252') AS ChatId

