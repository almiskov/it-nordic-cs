-- USE master;

-- DROP DATABASE RemindersDB
CREATE DATABASE RemindersDB;
GO

USE RemindersDB;

-- DROP TABLE dbo.Status
CREATE TABLE dbo.[Status] (
	Id TINYINT NOT NULL IDENTITY(1,1),
	[Status] VARCHAR(20) NOT NULL,
	CONSTRAINT PK_Status PRIMARY KEY CLUSTERED (Id)
);

INSERT INTO dbo.[Status] ([Status])
VALUES ('Awaiting'), ('ReadyToSend'), ('Sent'), ('Failed')

-- DROP TABLE dbo.Chat
CREATE TABLE dbo.Chat (
	Id INT NOT NULL IDENTITY(1,1),
	Chat VARCHAR(15) NOT NULL,
	CONSTRAINT PK_Chat PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Chat_Chat UNIQUE (Chat)
);

-- DROP TABLE dbo.Reminder
CREATE TABLE dbo.Reminder (
	Id UNIQUEIDENTIFIER NOT NULL,
	CreationDate DATETIMEOFFSET(0) NOT NULL,
	TargetDate DATETIMEOFFSET(0) NOT NULL,
	[Message] VARCHAR(300) NOT NULL DEFAULT 'Smth',
	ChatId INT NOT NULL,
	CONSTRAINT PK_Reminder PRIMARY KEY CLUSTERED (Id)
);

-- DROP TABLE dbo.ReminderStatus
CREATE TABLE dbo.ReminderStatus (
	ReminderId UNIQUEIDENTIFIER NOT NULL,
	StatusId TINYINT NOT NULL,
	StatusChanged DATETIMEOFFSET(0) NOT NULL CONSTRAINT DF_StatusChanged DEFAULT SYSDATETIMEOFFSET(),
	CONSTRAINT PK_ReminderStatus PRIMARY KEY (ReminderId, StatusId),
);


-- Setting foreign keys

-- ALTER TABLE DROP CONSTRAINT FK_Reminder_ChatId
ALTER TABLE dbo.Reminder
ADD CONSTRAINT FK_Reminder_ChatId FOREIGN KEY (ChatId)
	REFERENCES Chat(Id);

-- ALTER TABLE DROP CONSTRAINT FK_ReminderStatus_ReminderId
ALTER TABLE dbo.ReminderStatus
ADD CONSTRAINT FK_ReminderStatus_ReminderId FOREIGN KEY (ReminderId)
	REFERENCES Reminder(Id);

-- ALTER TABLE DROP CONSTRAINT FK_ReminderStatus_StatusId
ALTER TABLE dbo.ReminderStatus
ADD CONSTRAINT FK_ReminderStatus_StatusId FOREIGN KEY (StatusId)
	REFERENCES [Status](Id);
