CREATE DATABASE AirportInfo;
GO

USE AirportInfo;

CREATE TABLE DepartureBoard
	(
		Flight VARCHAR(10) NOT NULL,
		FromCountry VARCHAR(50) NOT NULL,
		FromTown VARCHAR(50) NOT NULL,
		Departure DATETIMEOFFSET(0) NOT NULL,
		ToCountry VARCHAR(50) NOT NULL,
		ToTown VARCHAR(50) NOT NULL,
		Arrival DATETIMEOFFSET(0) NOT NULL,
		AirborneTimeMinutes AS DATEDIFF(MINUTE, Departure, Arrival),
		Carrier VARCHAR(30) NOT NULL,
		AirplaneModel VARCHAR(30),
		CONSTRAINT CK_Departure CHECK (Departure > SYSDATETIMEOFFSET()),
		CONSTRAINT CK_Arrival CHECK (Arrival > Departure),
	);

INSERT INTO DepartureBoard 
	(
		Flight,
		FromCountry, FromTown, Departure,
		ToCountry, ToTown, Arrival,
		Carrier, AirplaneModel
	)
VALUES
	(
		'ZF-8895',
		'Russia', 'Surgut', '2019-07-27 05:40+05:00',
		'Turkey', 'Antalya', '2019-07-27 09:35+03:00',
		'Azur Air', 'Boeing 777-300ER'
	),
	(
		'ZF-4243',
		'Russia', 'Moscow', '2019-07-27 09:20+03:00',
		'USA', 'New York', '2019-07-27 12:15-04:00',
		'Aeroflot', 'Boeing 757-200'
	)

SELECT * FROM DepartureBoard;
GO

USE master;
GO

DROP DATABASE AirportInfo;