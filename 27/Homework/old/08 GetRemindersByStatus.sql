-- DROP FUNCTION IF EXISTS [dbo].[GetRemindersByStatus]

CREATE FUNCTION dbo.GetRemindersByStatus (
	@status AS VARCHAR(20)
)
RETURNS TABLE AS
	RETURN
		SELECT *
		FROM dbo.ReminderStatus rs
		WHERE rs.StatusId = dbo.GetStatusId(@status)
GO


SELECT ReminderId FROM dbo.GetRemindersByStatus('Awaiting')
SELECT * FROM dbo.GetRemindersByStatus('ReadyToSend')