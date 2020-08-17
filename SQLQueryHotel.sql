CREATE DATABASE HotelDB;
GO

USE HotelDB;
Go

IF OBJECT_ID('dbo.tblManager') IS NOT NULL DROP TABLE dbo.tblManager;
GO

GO
CREATE TABLE tblUser(
	UserId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50),
	Surname nvarchar(50),
	DateOfBirth date,
	Username nvarchar(40) UNIQUE,
	Password nvarchar(150)
);

GO
CREATE TABLE tblManager(
    ManagerID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Floor nvarchar(10),
	Experience int,
	Qualifications nvarchar(5),
	UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL
);

GO
CREATE TABLE tblEmployee(
	EmployeeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Floor nvarchar(10),
	Gender char,
	Citizenship nvarchar(30),
	Responsability nvarchar(50),
	Salary nvarchar(20),
	UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL
);

GO
CREATE VIEW vwManager AS
	SELECT tblUser.*, tblManager.Floor, tblManager.Experience, tblManager.Qualifications, tblManager.ManagerID
	FROM tblUser, tblManager
	WHERE tblUser.UserId = tblManager.UserId

GO
CREATE VIEW vwEmployee AS
	SELECT tblUser.*, tblEmployee.Floor, tblEmployee.Gender, tblEmployee.Citizenship, 
			tblEmployee.Responsability, tblEmployee.Salary, tblEmployee.EmployeeID
	FROM tblUser, tblEmployee
	WHERE tblUser.UserId = tblEmployee.UserId