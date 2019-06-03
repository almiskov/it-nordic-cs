USE [LiveHeroTour2]
GO
-- Объединения

-- Найти список товаров с ценой, количеством и стоимостью для заказа c ID = 22,
-- а также посчитать полную стоимость этого заказа
---
-- Сначала объединяем таблицы по связанным полям
--SELECT *
--FROM [dbo].[Order] AS O
--INNER JOIN [dbo].[OrderItem] AS OI
--	ON OI.[OrderId] = O.[Id]
--INNER JOIN [dbo].[Product] AS P
--	ON P.[Id] = OI.[ProductId]
--
-- затем определяем выводимые поля и фильтр
SELECT
	P.[Name],
	P.[Price],
	OI.[NumberOfItems],
	P.[Price] * OI.NumberOfItems AS [SubTotal]
FROM [dbo].[Order] AS O
INNER JOIN [dbo].[OrderItem] AS OI
	ON OI.[OrderId] = O.[Id]
INNER JOIN [dbo].[Product] AS P
	ON P.[Id] = OI.[ProductId]
WHERE O.[Id] = 22

-- 2. Посчитать итоговую сумму товара
SELECT SUM(P.[Price] * OI.NumberOfItems) AS [Total]
FROM [dbo].[Order] AS O
INNER JOIN [dbo].[OrderItem] AS OI
	ON OI.[OrderId] = O.[Id]
INNER JOIN [dbo].[Product] AS P
	ON P.[Id] = OI.[ProductId]
WHERE O.[Id] = 22