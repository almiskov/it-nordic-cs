-- DROP PROCEDURE IF EXISTS [dbo].[CreateReminder]

CREATE PROCEDURE dbo.CreateReminder (
	@targetDate AS DATETIMEOFFSET(0),
	@message AS VARCHAR(300),
	@chat AS VARCHAR(15)
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @creationDate AS DATETIMEOFFSET(0)
	SET @creationDate = SYSDATETIMEOFFSET()
	
	DECLARE @reminderId AS UNIQUEIDENTIFIER
	SET @reminderId = NEWID(); 

	DECLARE @chatId AS INT
	SET @chatId = dbo.GetChatId(@chat)

	IF(@chatId IS NULL)
		EXECUTE dbo.CreateChat @chat = @chat, @chatId = @chatId OUTPUT

	INSERT INTO dbo.Reminder
		(Id, CreationDate, TargetDate, [Message], ChatId)
	VALUES
		(@reminderId, @creationDate, @targetDate, @message, @chatId)

	EXECUTE dbo.SetStatusById @reminderId, 'Awaiting'
END
GO

SELECT * FROM dbo.Chat
SELECT * FROM dbo.Reminder
SELECT * FROM dbo.ReminderStatus

EXECUTE dbo.CreateReminder '2019-07-01 22:00', 'first message', '1252'
EXECUTE dbo.CreateReminder '2019-07-01 22:00', 'some another message', '22572'
EXECUTE dbo.CreateReminder '2019-06-01 18:26+03:00', 'second message', '1252'

TRUNCATE TABLE dbo.Reminder
TRUNCATE TABLE dbo.Chat
TRUNCATE TABLE dbo.ReminderStatus

SELECT r.[Message] ReminderMessage, ch.Chat, (DATEDIFF(SS, SYSDATETIMEOFFSET(), r.TargetDate)) SecondsToSend
FROM Reminder r
FULL JOIN Chat ch
ON r.ChatId = ch.Id 

