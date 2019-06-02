-- DROP FUNCTION IF EXISTS dbo.GetOutOfDateReminders

CREATE FUNCTION dbo.GetOutOfDateReminders()
RETURNS TABLE AS
	RETURN (
		SELECT *
		FROM dbo.Reminder r
		WHERE DATEDIFF(s, SYSDATETIMEOFFSET(), r.TargetDate) < 0
	)
GO

SELECT * FROM dbo.Reminder
SELECT * FROM dbo.Chat

EXECUTE dbo.CreateReminder '2019-06-02 22:53+03:00', 'im not out of date yet', '22323'

SELECT DATEDIFF(s, SYSDATETIMEOFFSET(), ou.TargetDate) AS SecondsLeft, ou.[Message], ou.ChatId
FROM dbo.GetOutOfDateReminders() ou

TRUNCATE TABLE dbo.Reminder
TRUNCATE TABLE dbo.Chat
TRUNCATE TABLE dbo.ReminderStatus