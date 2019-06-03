USE [LiveHeroTour2]
GO
-- Скалярные функции

-- LEN: вызов для константы или переменной
SELECT LEN('Hello, world!');

-- LEN: вызов в качестве вычисляемого поля
SELECT [Name], LEN([Name]) FROM [dbo].[Product]

-- LEN: вызов в условном выражении
SELECT * FROM [dbo].[Product] WHERE LEN([Name]) > 20

-- YEAR: вызов для константы или переменной
DECLARE @year AS INT
SET @year = YEAR(GETUTCDATE())
SELECT @year;

-- YEAR: вызов в качестве вычисляемого поля
SELECT [Id], YEAR([OrderDate]) FROM [dbo].[Order]

-- LEN: вызов в условном выражении
SELECT [Id] FROM [dbo].[Order] WHERE YEAR([OrderDate]) = @year
