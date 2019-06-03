USE [LiveHeroTour2]
GO
-- Подзапросы

-- Найти ID и имена клиентов, сделавших заказы в 2018 году
SELECT C.[Id], C.[Name]
FROM [dbo].[Customer] AS C
WHERE C.[Id] IN (
	SELECT O.CustomerId
	FROM [dbo].[Order] AS O
	WHERE YEAR(O.OrderDate) = 2018
)
	
-- Найти ID и название товара с максимальной длиной наименования
--
-- (надо понимать, что потенциально такой запрос может вернуть N записей,
---- в случае, если у нас N единиц товара, имеющих одинаковую длину, 
-- которая окажется максимальной)
SELECT Id, [Name]
FROM [dbo].Product AS P
WHERE LEN(P.[Name]) = (
	SELECT MAX(LEN(P.[Name]))
	FROM [dbo].Product AS P)