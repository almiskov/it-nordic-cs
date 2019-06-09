-- DROP FUNCTION IF EXISTS [dbo].[GetRemindersCount]

CREATE FUNCTION dbo.GetRemindersCount()
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(*)
		FROM dbo.Reminder
	)
END
GO

SELECT * FROM dbo.Reminder
SELECT dbo.GetRemindersCount()

EXECUTE dbo.CreateReminder '2019-06-01 20:35+03:00', 'Hello, im here', '22233'