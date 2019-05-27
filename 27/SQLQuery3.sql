INSERT INTO dbo.City (Id, [Name])
	VALUES (1, 'Москва');

INSERT INTO dbo.City (Id, [Name])
	VALUES (2, 'Санкт-Петербург');

INSERT INTO dbo.Address(Id, CityId, [Address])
	VALUES (1, 1, 'ул. Большая Садовая, д. 10');

DELETE FROM dbo.[Address] WHERE Id = 1;

