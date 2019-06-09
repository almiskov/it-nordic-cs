-- Creating test reminders
EXECUTE dbo.CreateReminder '2019-06-02 23:45+03:00', '1st reminder', '11111'
EXECUTE dbo.CreateReminder '2019-06-02 23:40+03:00', '2nd reminder', '22222'
EXECUTE dbo.CreateReminder '2019-06-22 00:00+03:00', '3rd reminder', '33333'
EXECUTE dbo.CreateReminder '2019-06-02 23:55+03:00', '4th reminder', '22222'
EXECUTE dbo.CreateReminder '2019-07-02 23:45+03:00', '5th reminder', '11111'

-- Check tables
SELECT * FROM dbo.Reminder
SELECT * FROM dbo.Chat
SELECT * FROM dbo.ReminderStatus

-- Getting reminders count
SELECT dbo.GetRemindersCount() AS [Reminders count]

-- Getting out-of-date reminders
SELECT
	*,
	DATEDIFF(s, SYSDATETIMEOFFSET(), ou.TargetDate) AS [Time Left]
FROM dbo.GetOutOfDateReminders() ou

-- Getting reminder by id
DECLARE @id AS UNIQUEIDENTIFIER
SET @id = (SELECT Id FROM dbo.Reminder WHERE [Message] = '4th reminder')
SELECT * FROM dbo.GetReminderById(@id)

-- Setting out-of-date reminders status as ReadyToSend
DECLARE @ids AS dbo.ListGuid
INSERT INTO @ids SELECT Id FROM dbo.GetOutOfDateReminders()
EXECUTE dbo.SetStatusByIds @ids, 'ReadyToSend'

SELECT * FROM dbo.ReminderStatus

-- Getting reminders by status
SELECT * FROM dbo.GetRemindersByStatus('ReadyToSend')
SELECT * FROM dbo.GetRemindersByStatus('Awaiting')

-- Getting not sent reminders
SELECT *
FROM dbo.ReminderStatus rs
WHERE rs.ReminderId NOT IN ( 
	SELECT aw.ReminderId
	FROM dbo.GetRemindersByStatus('ReadyToSend') aw)

SELECT * FROM dbo.ReminderStatus

-- Deleting all the data from tables except status table
DELETE dbo.Reminder
DELETE dbo.ReminderStatus
DELETE dbo.Chat