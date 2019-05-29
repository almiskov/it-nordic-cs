USE LiveHeroTour;
GO

CREATE PROCEDURE dbo.CreateCategory (
	@categoryName AS VARCHAR(50),
	@guid AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @tempGuid AS UNIQUEIDENTIFIER
	SELECT @tempGuid = NEWID()

	INSERT INTO dbo.Category (Id, [Name])
	VALUES (@tempGuid, @categoryName)

	SET @guid = @tempGuid
END
GO


DELETE FROM dbo.Category WHERE [Name] = 'TEST'

DECLARE @guid AS UNIQUEIDENTIFIER
EXECUTE dbo.CreateCategory @categoryName = 'TEST', @guid = @guid OUTPUT
PRINT @guid

--SELECT @guid

SELECT * FROM dbo.Category
