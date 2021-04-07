CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Firstname] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [PolicyReferenceNumber] NCHAR(9) NOT NULL, 
    [DateOfBirth] DATETIME NULL, 
    [Email] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
)
