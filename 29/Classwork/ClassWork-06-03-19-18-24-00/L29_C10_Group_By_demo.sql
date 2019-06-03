USE [LiveHeroTour2]
GO
-- Группировки

-- Общее количество обработанных заказов
SELECT COUNT(*)
FROM [dbo].[Order] AS O

-- Количество обработанных заказов сгруппированных по годам
SELECT YEAR(O.[OrderDate]), COUNT(*)
FROM [dbo].[Order] AS O
GROUP BY YEAR(O.[OrderDate])

-- ID и даты заказов с полной итоговой суммой заказа
SELECT 
	O.[Id],
	O.[OrderDate],
	SUM(P.[Price] * OI.NumberOfItems) AS [Total]
FROM [dbo].[Order] AS O
INNER JOIN [dbo].[OrderItem] AS OI
	ON OI.[OrderId] = O.[Id]
INNER JOIN [dbo].[Product] AS P
	ON P.[Id] = OI.[ProductId]
GROUP BY O.[Id], O.[OrderDate]