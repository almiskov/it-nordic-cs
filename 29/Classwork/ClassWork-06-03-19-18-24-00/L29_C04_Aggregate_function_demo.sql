USE [LiveHeroTour2]
GO
-- Агрегатные функции в рамках одной таблицы

-- Количество  записей в таблице
SELECT COUNT(*)
FROM dbo.Product
--
SELECT COUNT(DISTINCT [Name])
FROM dbo.Product

-- Суммарная стоимость продкутов в магазине
SELECT SUM(P.Price) AS SummaryPrice
FROM dbo.Product AS P

-- Цена самого дешёвого товара
SELECT MIN(P.Price) AS MinPrice
FROM dbo.Product AS P

-- Цена самого дорогого товара
SELECT MAX(P.Price) AS MaxPrice
FROM dbo.Product AS P

-- Средняя стоимость продкутов в магазине
SELECT AVG(P.Price) AS AveragePrice
FROM dbo.Product AS P

-- Вся статистика по таблице Product в одном запросе
SELECT
	COUNT(*) AS '# of Products in Catalog',
	SUM(P.Price) AS SummaryPrice,
	MIN(P.Price) AS MinPrice,
	MAX(P.Price) AS MaxPrice,
	AVG(P.Price) AS AveragePrice
FROM dbo.Product AS P