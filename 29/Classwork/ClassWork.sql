SELECT * FROM dbo.Product
SELECT * FROM dbo.Customer
SELECT * FROM dbo.[Order]
SELECT * FROM dbo.OrderItem


SELECT LEN(' Hello   ')

SELECT p.[Name], LEN(p.[Name])
FROM Product p

SELECT p.[Name]
FROM Product p
WHERE LEN(p.[Name]) >  25

DECLARE @year AS INT
SET @year = YEAR(GETUTCDATE())
SELECT @year

SELECT *
FROM dbo.[Order] o
WHERE YEAR(o.OrderDate) = 2017

SELECT COUNT(*)
FROM dbo.Product p

SELECT
	MIN(o.OrderDate) AS FirstOrder,
	MAX(o.OrderDate) AS LastOrder
FROM dbo.[Order] o

-- 2
SELECT COUNT(DISTINCT oi.OrderId) AS NumberOfOrders
FROM dbo.[OrderItem] oi

-- 3
SELECT MAX(o.Id) AS MaxIdNumber
FROM dbo.[Order] o

-- 4
SELECT AVG(o.Discount) AS AverageDiscount
FROM dbo.[Order] o

-- 6
SELECT MAX(o.OrderDate) AS LatestOrderIn2018
FROM dbo.[Order] o
WHERE YEAR(o.OrderDate) = 2018

-- 7
SELECT MAX(LEN(p.[Name])) AS MaxProductName
FROM dbo.Product p

SELECT c.Id, c.[Name]
FROM dbo.Customer c
WHERE c.Id IN (
	SELECT o.CustomerId
	FROM dbo.[Order] o
	WHERE YEAR(o.OrderDate) = 2015
)

SELECT TOP 1 p1.Id, p1.[Name]
FROM dbo.Product p1
WHERE LEN(p1.[Name]) = (
	SELECT MAX(LEN(p2.[Name]))
	FROM dbo.Product p2
)

-- 1
SELECT o1.Id
FROM dbo.[Order] o1
WHERE o1.Discount = (
	SELECT MAX(o2.Discount)
	FROM dbo.[Order] o2
	WHERE YEAR(o2.OrderDate) = 2016
)

-- 2
SELECT o1.Id
FROM dbo.[Order] o1
WHERE o1.OrderDate = (
	SELECT MIN(o2.OrderDate)
	FROM dbo.[Order] o2
	WHERE YEAR(o2.OrderDate) = 2019
)

-- 3
SELECT c.Id, c.[Name]
FROM dbo.Customer c
WHERE c.Id = (
	SELECT o1.CustomerId
	FROM dbo.[Order] o1
	WHERE o1.Discount = (
		SELECT MAX(o.Discount)
		FROM dbo.[Order] o
		WHERE YEAR(o.OrderDate) = 2016
	)
)

-- 4
SELECT *
FROM dbo.Customer c
WHERE c.Id = (
	SELECT o1.CustomerId
	FROM dbo.[Order] o1
	WHERE o1.OrderDate = (
		SELECT MIN(o.OrderDate)
		FROM dbo.[Order] o
		WHERE YEAR(o.OrderDate) = 2019
	)
)

-- 5
SELECT *
FROM dbo.Customer c
WHERE c.Id IN (
	SELECT o.CustomerId
	FROM dbo.[Order] o
	WHERE o.Discount IS NULL
)

SELECT
	p.Id As ProductId,
	p.[Name],
	p.Price,
	oi.NumberOfItems, 
	p.Price * oi.NumberOfItems AS TotalPrice
FROM dbo.OrderItem oi
INNER JOIN dbo.Product p
	ON p.Id = oi.ProductId
WHERE oi.OrderId = 22

SELECT
	SUM(p.Price * oi.NumberOfItems) AS TotalSum
FROM dbo.OrderItem oi
INNER JOIN dbo.Product p
	ON p.Id = oi.ProductId
WHERE oi.OrderId = 22


SELECT 
	(SELECT SUM(p.Price * oi.NumberOfItems)
		FROM dbo.[Order] o
		INNER JOIN dbo.OrderItem oi
			ON o.Id = oi.OrderId
		INNER JOIN dbo.Customer c
			ON o.CustomerId = c.Id
		INNER JOIN dbo.Product p
			ON oi.ProductId = p.Id
		WHERE c.[Name] = 'Мария'
	) * 100
	/ 
	(SELECT SUM(p.Price * oi.NumberOfItems)
		FROM dbo.[Order] o
		INNER JOIN dbo.OrderItem oi
			ON o.Id = oi.OrderId
		INNER JOIN dbo.Customer c
			ON o.CustomerId = c.Id
		INNER JOIN dbo.Product p
			ON oi.ProductId = p.Id
	)



DECLARE @totalSum AS MONEY

SELECT @totalSum = SUM(Total)
FROM (
	SELECT c.[Name], o.Discount, (1 - ISNULL(o.Discount, 0)) * SUM(p.Price * oi.NumberOfItems) AS Total
	FROM dbo.[Order] o
	INNER JOIN dbo.OrderItem oi
		ON o.Id = oi.OrderId
	INNER JOIN dbo.Customer c
		ON o.CustomerId = c.Id
	INNER JOIN dbo.Product p
		ON oi.ProductId = p.Id
	GROUP BY c.[Name], o.Discount
) AS SubTotal

SELECT SubTotal.[Name], SUM(Total) AS TotalSum, SUM(Total) * 100 / @totalSum AS [Percent]
FROM (
	SELECT c.[Name], o.Discount, (1 - ISNULL(o.Discount, 0)) * SUM(p.Price * oi.NumberOfItems) AS Total
	FROM dbo.[Order] o
	INNER JOIN dbo.OrderItem oi
		ON o.Id = oi.OrderId
	INNER JOIN dbo.Customer c
		ON o.CustomerId = c.Id
	INNER JOIN dbo.Product p
		ON oi.ProductId = p.Id
	GROUP BY c.[Name], o.Discount
) AS SubTotal
GROUP BY SubTotal.[Name]
