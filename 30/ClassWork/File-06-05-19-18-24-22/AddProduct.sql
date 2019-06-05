USE OnlineStore
GO

CREATE PROCEDURE dbo.AddProduct (
	@name AS VARCHAR(300),
	@price AS SMALLMONEY,
	@id AS INT OUTPUT
)
AS BEGIN
	INSERT INTO dbo.Product ([Name], Price)
	VALUES (@name, @price)

	SET @id = SCOPE_IDENTITY();
END
GO

SELECT * FROM dbo.Product