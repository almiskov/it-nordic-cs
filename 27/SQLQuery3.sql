INSERT INTO dbo.City (Id, [Name])
	VALUES (1, '������');

INSERT INTO dbo.City (Id, [Name])
	VALUES (2, '�����-���������');

INSERT INTO dbo.Address(Id, CityId, [Address])
	VALUES (1, 1, '��. ������� �������, �. 10');

DELETE FROM dbo.[Address] WHERE Id = 1;

