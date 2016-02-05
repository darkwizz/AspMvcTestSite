--CREATE TABLE Book(
--	Id INT IDENTITY PRIMARY KEY,
--	Name NVARCHAR(50),
--	PageCount INT,
--	Author NVARCHAR(50),
--	ReceivingDate DATE
--);

--USE [|DataDirectory|/LIBRARYDB.MDF]
--GO

SET DATEFORMAT DMY

INSERT INTO [dbo].[Books]([Name], [PageCount], [Author], [ReceivingDate])
VALUES ('Atata', 300, 'Igor', '23.04.2005'),
('goog', 143, 'Petr', Convert(Date, GetDate())),
('azaza', 42, 'Axe', '26.11.2015');