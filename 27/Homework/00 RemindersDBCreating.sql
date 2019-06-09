-- DROP DATABASE RemindersDB
-- CREATE DATABASE RemindersDB;
-- GO

USE RemindersDB;

ALTER TABLE dbo.Reminder DROP CONSTRAINT FK_Reminder_ChatId
ALTER TABLE dbo.ReminderStatus DROP CONSTRAINT FK_ReminderStatus_ReminderId
ALTER TABLE dbo.ReminderStatus DROP CONSTRAINT FK_ReminderStatus_StatusId

DROP TABLE dbo.Chat
DROP TABLE dbo.Reminder
DROP TABLE dbo.ReminderStatus
DROP TABLE dbo.[Status]

-- Creating tables

CREATE TABLE dbo.[Status] (
	Id TINYINT NOT NULL IDENTITY(1,1),
	[Status] VARCHAR(20) NOT NULL,
	CONSTRAINT PK_Status PRIMARY KEY CLUSTERED (Id)
);

CREATE TABLE dbo.Chat (
	Id INT NOT NULL IDENTITY(1,1),
	Chat VARCHAR(15) NOT NULL,
	CONSTRAINT PK_Chat PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Chat_Chat UNIQUE (Chat)
);

CREATE TABLE dbo.Reminder (
	Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Reminder_Id DEFAULT NEWID(),
	CreationDate DATETIMEOFFSET(0) NOT NULL CONSTRAINT DF_Reminder_CreationDate DEFAULT SYSDATETIMEOFFSET(),
	TargetDate DATETIMEOFFSET(0) NOT NULL,
	[Message] VARCHAR(300) NOT NULL CONSTRAINT DF_Reminder_Message DEFAULT 'Smth',
	ChatId INT NOT NULL,
	CONSTRAINT PK_Reminder PRIMARY KEY CLUSTERED (Id)
);

CREATE TABLE dbo.ReminderStatus (
	ReminderId UNIQUEIDENTIFIER NOT NULL,
	StatusId TINYINT NOT NULL,
	StatusChanged DATETIMEOFFSET(0) NOT NULL CONSTRAINT DF_StatusChanged DEFAULT SYSDATETIMEOFFSET(),
	CONSTRAINT PK_ReminderStatus PRIMARY KEY (ReminderId, StatusId),
	CONSTRAINT CK_StatusId CHECK (StatusId >= 1 AND StatusId <= 4)
);

-- Setting foreign keys

ALTER TABLE dbo.Reminder
ADD CONSTRAINT FK_Reminder_ChatId FOREIGN KEY (ChatId)
	REFERENCES Chat(Id);

ALTER TABLE dbo.ReminderStatus
ADD CONSTRAINT FK_ReminderStatus_ReminderId FOREIGN KEY (ReminderId)
	REFERENCES Reminder(Id);

ALTER TABLE dbo.ReminderStatus
ADD CONSTRAINT FK_ReminderStatus_StatusId FOREIGN KEY (StatusId)
	REFERENCES [Status](Id);

-- Inserting basic data

INSERT INTO dbo.[Status] ([Status])
VALUES ('Awaiting'), ('Ready'), ('Sent'), ('Failed')