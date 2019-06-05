CREATE PROCEDURE dbo.AddOrder (
	@customerId AS INT,
	@orderDate AS DATETIMEOFFSET,
	@discount AS FLOAT = NULL,
	@id AS INT OUTPUT
)
AS BEGIN
	INSERT INTO dbo.[Order] (CustomerId, OrderDate, Discount)
	VALUES (@customerId, @orderDate, @discount)

	SET @id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE dbo.AddOrderItem (
	@orderId AS INT,
	@productId AS INT,
	@numberOfItems AS INT
)
AS BEGIN
	INSERT INTO dbo.OrderItem (OrderId, ProductId, NumberOfItems)
	VALUES (@orderId, @productId, @numberOfItems)
END
GO





SELECT * FROM dbo.[Order]
SELECT * FROM dbo.[OrderItem]

SELECT * FROM dbo.Customer