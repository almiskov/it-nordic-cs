-- DROP FUNCTION IF EXISTS [dbo].[GetReminderById]

CREATE FUNCTION dbo.GetReminderById (
	@reminderId AS UNIQUEIDENTIFIER
)
RETURNS TABLE AS
	RETURN 
		SELECT *
		FROM dbo.Reminder r
		WHERE r.Id = @reminderId
GO


DECLARE @reminderId AS UNIQUEIDENTIFIER
SELECT TOP 1 @reminderId = r.Id
FROM dbo.Reminder r
WHERE r.ChatId = 2

SELECT * from dbo.GetReminderById (@reminderId)