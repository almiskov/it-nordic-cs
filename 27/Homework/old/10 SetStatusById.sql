-- DROP PROCEDURE IF EXISTS [dbo].[SetStatusById]

CREATE PROCEDURE dbo.SetStatusById (
	@reminderId AS UNIQUEIDENTIFIER,
	@status AS VARCHAR(20)
)
AS BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.ReminderStatus
		(ReminderId, StatusId)
	VALUES
		(@reminderId, dbo.GetStatusId(@status))
END
GO

SELECT * FROM dbo.Reminder
SELECT * FROM dbo.ReminderStatus