CREATE TABLE [dbo].[Customers]
(
	[CustId] INT IDENTITY(1, 1) NOT NULL,
	[FirstName] NVARCHAR(50) NULL,
	[LastName] NVARCHAR(50) NULL,
	PRIMARY KEY CLUSTERED ([CustID] ASC)
);