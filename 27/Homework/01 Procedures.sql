-- DROP PROCEDURE IF EXISTS dbo.GetRemindersCount
CREATE PROCEDURE dbo.GetRemindersCount(
	@count AS INT OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	SELECT @count = COUNT(*)
	FROM dbo.Reminder
END
GO

-- DROP PROCEDURE IF EXISTS dbo.GetChatId
CREATE PROCEDURE dbo.GetChatId(
	@chat AS VARCHAR(15),
	@id AS INT OUTPUT
)
AS BEGIN
	SET NOCOUNT ON
	
	DECLARE @tempId AS INT

	SELECT @tempId = c.Id
	FROM dbo.Chat c
	WHERE c.Chat = @chat

	IF(@tempId IS NULL)
	BEGIN
		INSERT INTO dbo.Chat (Chat)
		VALUES (@chat)
		
		SET @tempId = SCOPE_IDENTITY();
	END

	SET @id = @tempId
END
GO

-- DROP PROCEDURE IF EXISTS dbo.GetStatusId
CREATE PROCEDURE dbo.GetStatusId(
	@status AS VARCHAR(20),
	@statusId AS TINYINT OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	SELECT @statusId = s.Id
	FROM dbo.[Status] s
	WHERE s.[Status] = @status
END
GO

-- DROP PROCEDURE IF EXISTS dbo.AddReminderStatus
CREATE PROCEDURE dbo.AddReminderStatus(
	@reminderId AS UNIQUEIDENTIFIER,
	@status AS VARCHAR(20)
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @statusId AS TINYINT

	EXECUTE dbo.GetStatusId @status, @statusId OUTPUT

	INSERT INTO dbo.ReminderStatus (ReminderId, StatusId)
	VALUES (@reminderId, @statusId)
END
GO

-- DROP PROCEDURE IF EXISTS dbo.CreateReminder
CREATE PROCEDURE dbo.CreateReminder(
	@targetDate AS DATETIMEOFFSET(0),
	@chat AS VARCHAR(15),
	@message AS VARCHAR(300),
	@status AS VARCHAR(20),
	@id AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @newId AS UNIQUEIDENTIFIER
	SET @newId = NEWID();

	DECLARE @chatId AS INT
	EXECUTE dbo.GetChatId @chat, @chatId OUTPUT

	INSERT INTO dbo.Reminder (Id, TargetDate, [Message], ChatId)
	VALUES (@newId, @targetDate, @message, @chatId)

	SET @id = @newId

	EXECUTE dbo.AddReminderStatus @id, @status
END
GO

-- DROP PROCEDURE IF EXISTS dbo.ClearReminders
CREATE PROCEDURE dbo.ClearReminders
AS BEGIN
	SET NOCOUNT ON

	DELETE FROM dbo.ReminderStatus
	DELETE FROM dbo.Reminder
END
GO

-- DROP PROCEDURE IF EXISTS dbo.GetReminderById
CREATE PROCEDURE dbo.GetReminderById(
	@id AS UNIQUEIDENTIFIER,
	@targetDate AS DATETIMEOFFSET(0) OUTPUT,
	@message AS VARCHAR(300) OUTPUT,
	@chat AS VARCHAR(15) OUTPUT,
	@statusId AS TINYINT OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	-- find targetDate, message and chatId by reminder Id
	DECLARE @chatId AS INT

	SELECT
		@targetDate = r.TargetDate,
		@message = r.[Message],
		@chatId = r.ChatId
	FROM dbo.Reminder r
	WHERE r.Id = @id

	-- find chat as varchar by its id
	SELECT @chat = c.Chat
	FROM dbo.Chat c
	WHERE c.Id = @chatId

	-- find statusId by reminderId

	SELECT TOP 1 @statusId = rs.StatusId
	FROM dbo.ReminderStatus rs
	WHERE rs.ReminderId = @id
	ORDER BY rs.StatusChanged DESC
END
GO

-- DROP PROCEDURE IF EXISTS dbo.GetRemindersByLastStatus
CREATE PROCEDURE dbo.GetRemindersByLastStatus(
	@status AS VARCHAR(20)
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @statusId AS TINYINT
	EXECUTE dbo.GetStatusId @status, @statusId OUTPUT

	SELECT r.Id, r.TargetDate, c.Chat, r.[Message], s.[Status]
	FROM (
		SELECT rs.ReminderId, MAX(rs.StatusId) AS LastStatus
		FROM dbo.ReminderStatus rs
		GROUP BY rs.ReminderId
		) AS rls
	JOIN dbo.Reminder r ON r.Id = rls.ReminderId
	JOIN dbo.[Status] s ON s.Id = rls.LastStatus
	JOIN dbo.Chat c ON  c.Id = r.ChatId
	WHERE rls.LastStatus = @statusId
END
GO
