-- DROP TABLE dbo.Goods
CREATE TABLE dbo.Goods
(
	Id INT NOT NULL IDENTITY(1,1),
	CategoryId UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Goods PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Goods_Name UNIQUE ([Name])
);

SELECT * FROM dbo.Goods;

ALTER TABLE dbo.Goods
	ADD CONSTRAINT FK_Goods_CategoryId FOREIGN KEY (CategoryId)
		REFERENCES dbo.Category(Id);

DECLARE @guid AS UNIQUEIDENTIFIER

SELECT @guid = Id
	FROM dbo.Category
	WHERE [Name] LIKE 'Mob%';

-- PRINT @guid;

INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (@guid, 'iPhone X');
PRINT 'Id of iPhone X is ' + CONVERT(VARCHAR(15), SCOPE_IDENTITY());


INSERT INTO dbo.Goods (CategoryId, [Name])
	VALUES (@guid, 'Xiaomi Mi9');
PRINT 'Id of Xiaomi Mi9 is ' + CAST(SCOPE_IDENTITY() AS VARCHAR(15));

--DELETE FROM dbo.Goods;
TRUNCATE TABLE dbo.Goods;