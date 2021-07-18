USE tempdb;
BEGIN TRY
  ALTER DATABASE AutoLot SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
  DROP DATABASE AutoLot;
END TRY
BEGIN CATCH
  PRINT 'База данных AutoLot не существует.';
END CATCH
GO

CREATE DATABASE AutoLot;
GO

USE AutoLot;
CREATE TABLE Customers
(
	customer_id INT PRIMARY KEY IDENTITY,
	first_name NVARCHAR(50) NULL,
	last_name NVARCHAR(50) NULL,
);
CREATE TABLE Inventory
(
	car_id INT PRIMARY KEY IDENTITY,
	make NVARCHAR(50) NULL,
	color NVARCHAR(50) NULL,
	[name] NVARCHAR(50) NULL
);
CREATE TABLE Orders
(
	order_id INT PRIMARY KEY IDENTITY,
	customer_id INT NOT NULL,
	car_id INT NOT NULL,
	CONSTRAINT FK_Orders_Customers FOREIGN KEY(customer_id)
	REFERENCES Customers(customer_id) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT FK_Orders_Inventory FOREIGN KEY(car_id)
	REFERENCES Inventory(car_id) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE CreditRisks
(
	customer_id INT PRIMARY KEY IDENTITY,
	first_name NVARCHAR(50) NULL,
	last_name NVARCHAR(50) NULL
);
GO

CREATE PROCEDURE ReadCarName
@car_id int,
@car_name nvarchar(50) output
AS
SELECT @car_name = [Name] FROM Inventory WHERE car_id = @car_id