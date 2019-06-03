USE [LiveHeroTour2]
GO

-- 1. Полное количество записей в таблице OrderItem
SELECT COUNT(OI.OrderId) FROM [dbo].[OrderItem] AS OI

-- 2. Количество уникальных заказов (по таблице OrderItem)
SELECT COUNT(DISTINCT OI.[OrderId]) FROM [dbo].[OrderItem] AS OI

-- 3. Максимальный номер заказа (по таблице OrderItem)
SELECT MAX(DISTINCT OI.[OrderId]) FROM [dbo].[OrderItem] AS OI

-- 4. Средний размер скидки (по таблице Order)
SELECT AVG(O.[Discount]) FROM [dbo].[Order] AS O

-- 5. Дата первой и последней продажи (по таблице Order)
SELECT
	MIN(O.[OrderDate]) AS [FirstOrderDate],
	MAX(O.[OrderDate]) AS [LastOrderDate]
FROM [dbo].[Order] AS O

-- 6 Дата последней продажи в 2018 году (по таблице Order)
SELECT MAX(O.[OrderDate]) AS [LastOrderDate]
FROM [dbo].[Order] AS O
WHERE YEAR(O.OrderDate) = 2018

-- 7. Максимальная длина наименования товара (по таблице Product)
SELECT MAX(LEN(P.[Name]))
FROM [dbo].Product AS P