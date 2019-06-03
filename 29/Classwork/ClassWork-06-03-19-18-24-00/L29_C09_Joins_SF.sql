USE [LiveHeroTour2]
GO
-- Объединения

-- Найти итоговую сумму, потраченную Марией
---
-- Сначала объединяем необходимые таблицы по связанным полям
SELECT *
FROM [dbo].[Order] AS O
INNER JOIN [dbo].[OrderItem] AS OI
	ON OI.[OrderId] = O.[Id]
INNER JOIN [dbo].[Product] AS P
	ON P.[Id] = OI.[ProductId]
INNER JOIN [dbo].[Customer] AS C
	ON C.[Id] = O.[CustomerId]
--
-- затем определяем выводимые поля и фильтр
SELECT SUM(P.[Price] * OI.NumberOfItems) AS [Total]
FROM [dbo].[Order] AS O
INNER JOIN [dbo].[OrderItem] AS OI
	ON OI.[OrderId] = O.[Id]
INNER JOIN [dbo].[Product] AS P
	ON P.[Id] = OI.[ProductId]
INNER JOIN [dbo].[Customer] AS C
	ON C.[Id] = O.[CustomerId]
WHERE C.[Name] = 'Мария'