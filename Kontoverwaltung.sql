--Erstellung der Datenbank
--CREATE DATABASE Kontoverwaltung;
--go

--USE Kontoverwaltung;

-- Erstellung von Tabellen
CREATE TABLE Kunde (
	Kunde_id INT IDENTITY (1, 1) PRIMARY KEY,
	Kunde_name VARCHAR (255) NOT NULL,
	Geburstdatum DATE NOT NULL
);
CREATE TABLE Konto (
	Konto_id INT IDENTITY (1, 1) PRIMARY KEY,
	Kunde_id INT NOT NULL,
	FOREIGN KEY (Kunde_id) REFERENCES Kunde(Kunde_id) ON DELETE CASCADE ON UPDATE CASCADE,
);
CREATE TABLE verwaltung (
	Verwaltung_id INT IDENTITY (1, 1) PRIMARY KEY,
	verwaltung_name VARCHAR (255) NOT NULL, 
	Kunde_id INT NOT NULL,
	Konto_id INT NOT NULL,
	FOREIGN KEY (Kunde_id) REFERENCES Kunde(Kunde_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (Konto_id) REFERENCES Konto(Konto_id) ON DELETE CASCADE ON UPDATE CASCADE,
);
-- Daten wird geladen
--Kunde
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(1,'Johnson')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(2,'Pratt')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(3,'Watkins')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(4,'Rollins')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(5,'Ritchey')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(6,'Emerson')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(7,'Campbell')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(8,'Browning')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(9,'Hamilton')
INSERT INTO Kunde(Kunde_id,Kunde_name) VALUES(10,'Carlson')
--Konto
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(1,'Johnson')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(2,'Pratt')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(3,'Watkins')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(4,'Rollins')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(5,'Ritchey')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(6,'Emerson')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(7,'Campbell')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(8,'Browning')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(9,'Hamilton')
INSERT INTO Konto(Konto_id,Kunde_id) VALUES(10,'Carlson')








