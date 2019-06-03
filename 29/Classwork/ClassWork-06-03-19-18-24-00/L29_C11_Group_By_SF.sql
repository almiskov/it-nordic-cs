USE [LiveHeroTour2]
GO

-- Написать запрос, возвращающий полную итоговую сумму, потраченную каждым клиентом
SELECT 
	C.[Id],
	C.[Name],
	SUM(P.[Price] * OI.NumberOfItems) AS [Total]
FROM [dbo].[Order] AS O
INNER JOIN [dbo].[OrderItem] AS OI
	ON OI.[OrderId] = O.[Id]
INNER JOIN [dbo].[Product] AS P
	ON P.[Id] = OI.[ProductId]
RIGHT JOIN [dbo].[Customer] AS C
	ON C.[Id] = O.[CustomerId]
GROUP BY C.[Id], C.[Name]