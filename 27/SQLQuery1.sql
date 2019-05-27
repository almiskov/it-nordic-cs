CREATE DATABASE Correspondence;
GO
USE Correspondence;

-- DROP TABLE dbo.PostalItem
CREATE TABLE dbo.PostalItem
(
	Id INT NOT NULL,
	[Name] VARCHAR(250) NOT NULL,
	NumberOfPages INT NOT NULL
);
GO

ALTER TABLE dbo.PostalItem
ADD CONSTRAINT PK_PostalItem PRIMARY KEY CLUSTERED (Id);
GO

-- DROP TABLE dbo.Contractor
CREATE TABLE dbo.Contractor
(
	Id INT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	PositionId INT NOT NULL
);
GO

ALTER TABLE dbo.Contractor
ADD CONSTRAINT PK_Contractor PRIMARY KEY CLUSTERED (Id);
GO

-- DROP TABLE dbo.Position
CREATE TABLE dbo.Position
(
	Id INT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	CONSTRAINT PK_Position PRIMARY KEY CLUSTERED (Id)
);
GO

-- DROP TABLE dbo.[Address]
CREATE TABLE dbo.[Address]
(
	Id INT NOT NULL,
	CityId INT NOT NULL,
	[Address] VARCHAR(200) NOT NULL,
	CONSTRAINT PK_Address PRIMARY KEY CLUSTERED (Id)
);
GO

-- DROP TABLE dbo.City
CREATE TABLE dbo.City
(
	Id INT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	CONSTRAINT PK_City PRIMARY KEY CLUSTERED (Id)
);
GO

-- DROP TABLE dbo.[Status]
CREATE TABLE dbo.[Status]
(
	Id INT NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Status PRIMARY KEY CLUSTERED (Id)
);
GO

-- DROP TABLE dbo.SendingStatus
CREATE TABLE dbo.SendingStatus
(
	PostalItemId INT NOT NULL,
	StatusId INT NOT NULL,
	UpdateStatusDateTime DATETIMEOFFSET NOT NULL,
	SenderId INT NOT NULL,
	SenderAddress INT NOT NULL,
	RecieverId INT NOT NULL,
	RecieverAddress INT NOT NULL
	CONSTRAINT PK_SendingStatus PRIMARY KEY CLUSTERED
	(
		PostalItemId,
		StatusId,
		UpdateStatusDateTime,
		SenderId,
		SenderAddress,
		RecieverId,
		RecieverAddress
	)
);
GO

-- Create foreign keys
ALTER TABLE dbo.[Address]
ADD CONSTRAINT FK_Address_CityId FOREIGN KEY (CityId)
	REFERENCES dbo.City(Id);

ALTER TABLE dbo.Contractor
ADD CONSTRAINT FK_Contractor_PositionId FOREIGN KEY (PositionId)
	REFERENCES dbo.Position(Id);

ALTER TABLE [dbo].[SendingStatus]
ADD CONSTRAINT FK_SendingStatus_PostalItemId FOREIGN KEY ([PostalItemId])
	REFERENCES dbo.PostalItem(Id);

ALTER TABLE [dbo].[SendingStatus]
ADD CONSTRAINT FK_SendingStatus_StatusId FOREIGN KEY ([StatusId])
	REFERENCES dbo.[Status](Id);

ALTER TABLE [dbo].[SendingStatus]
ADD CONSTRAINT FK_SendingStatus_SenderId FOREIGN KEY ([SenderId])
	REFERENCES [dbo].[Contractor](Id);

ALTER TABLE [dbo].[SendingStatus]
ADD CONSTRAINT FK_SendingStatus_RecieverId FOREIGN KEY ([RecieverId])
	REFERENCES [dbo].[Contractor](Id);

ALTER TABLE [dbo].[SendingStatus]
ADD CONSTRAINT FK_SendingStatus_SenderAddress FOREIGN KEY ([SenderAddress])
	REFERENCES [dbo].[Address](Id);

ALTER TABLE [dbo].[SendingStatus]
ADD CONSTRAINT FK_SendingStatus_RecieverAddress FOREIGN KEY ([RecieverAddress])
	REFERENCES [dbo].[Address](Id);