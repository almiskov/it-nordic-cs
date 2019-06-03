USE [LiveHeroTour2]
GO
-- Подзапросы

-- 1. Номер заказа с максимальной скидкой в 2016 году
SELECT O.[Id]
FROM [dbo].[Order] AS O
WHERE O.Discount = ( 
	SELECT MAX(O.[Discount])
	FROM [dbo].[Order] AS O
	WHERE YEAR(O.OrderDate) = 2016)

-- 2. Номер первого заказа в 2019 году
SELECT O.[Id]
FROM [dbo].[Order] AS O
WHERE O.[OrderDate] = ( 
	SELECT MIN(O.[OrderDate])
	FROM [dbo].[Order] AS O
	WHERE YEAR(O.OrderDate) = 2019)

-- 3. Найти ID и имя клиента, получившего максимальную скидку в 2016 году
SELECT C.[Id], C.[Name]
FROM [dbo].[Customer] AS C
WHERE C.[Id] IN (
	SELECT O.[CustomerId]
	FROM [dbo].[Order] AS O
	WHERE O.Discount = ( 
		SELECT MAX(O.[Discount])
		FROM [dbo].[Order] AS O
		WHERE YEAR(O.OrderDate) = 2016))

-- 4. ID и имя клиента, сделавшего первый заказ в 2019 году
SELECT C.[Id], C.[Name]
FROM [dbo].[Customer] AS C
WHERE C.[Id] IN (
	SELECT O.[CustomerId]
	FROM [dbo].[Order] AS O
	WHERE O.[OrderDate] = ( 
		SELECT MIN(O.[OrderDate])
		FROM [dbo].[Order] AS O
		WHERE YEAR(O.OrderDate) = 2019))
