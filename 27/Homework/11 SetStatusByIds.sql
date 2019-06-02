-- DROP PROCEDURE IF EXISTS [dbo].[SetStatusByIds]

CREATE PROCEDURE dbo.SetStatusByIds (
	@reminderIds AS dbo.ListGuid READONLY,
	@status AS VARCHAR(20)
)
AS BEGIN
	SET NOCOUNT ON
	
	CREATE TABLE #temp (
		ReminderId UNIQUEIDENTIFIER,
		StatusId INT
	)

	INSERT INTO #temp (ReminderId)
	SELECT Id FROM @reminderIds
	UPDATE #temp
	SET StatusId = dbo.GetStatusId(@status)

	INSERT INTO dbo.ReminderStatus (ReminderId, StatusId)
	SELECT t.ReminderId, t.StatusId FROM #temp t

	DELETE #temp
END
GO


DECLARE @ids AS dbo.ListGuid

INSERT INTO @ids (Id)
SELECT r.ReminderId
FROM dbo.GetRemindersByStatus('ReadyToSend') r

EXECUTE dbo.SetStatusByIds @ids, 'Sent'



SELECT * FROM dbo.Reminder
SELECT * FROM dbo.ReminderStatus

DECLARE @targetId AS UNIQUEIDENTIFIER
SELECT TOP 1 @targetId = Id
FROM dbo.Reminder r
WHERE ChatId = 2

EXECUTE dbo.SetStatusById @targetId, 'Failed'


