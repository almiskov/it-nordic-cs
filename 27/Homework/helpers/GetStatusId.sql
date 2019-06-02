-- DROP FUNCTION IF EXISTS [dbo].[GetStatusId]

CREATE FUNCTION dbo.GetStatusId (
	@status AS VARCHAR(20)
)
RETURNS TINYINT AS
BEGIN
	RETURN (
		SELECT Id
		FROM dbo.[Status]
		WHERE [Status].[Status] = @status
	)
END
GO