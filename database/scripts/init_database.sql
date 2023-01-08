USE master;
GO

CREATE DATABASE post;
GO

USE post;
GO

-- CREATE TABLES

CREATE TABLE [dbo].[ApplicationUser] (
    [Id] VARCHAR(30) NOT NULL,
    [FirstName] VARCHAR(30) NOT NULL,
    [LastName] VARCHAR(30) NOT NULL,
    [PasswordHash] VARCHAR(MAX) NOT NULL,
    [IsEmployee] BIT NOT NULL,
    CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED([Id] ASC) 
)
GO

CREATE TABLE [dbo].[PostMachine] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] VARCHAR(30) NOT NULL,
    [Country] VARCHAR(3) NOT NULL,
    [City] VARCHAR(30) NOT NULL,
    [PostalCode] VARCHAR(6) NOT NULL,
    [Street] VARCHAR(30) NOT NULL,
    [Number] VARCHAR(5) NOT NULL,
    [PreciseLocation] VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_PostMacgine] PRIMARY KEY CLUSTERED([Id] ASC) 
)
GO

CREATE SCHEMA [dict]
GO

CREATE TABLE [dict].[Status] (
    [Id] INT NOT NULL,
    [Name] VARCHAR(20) NOT NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED([Id] ASC) 

)
GO

INSERT INTO [dict].[Status] ([Id], [Name]) VALUES (0, 'Problem');
INSERT INTO [dict].[Status] ([Id], [Name]) VALUES (1, 'Delivered');
INSERT INTO [dict].[Status] ([Id], [Name]) VALUES (2, 'On the way');
INSERT INTO [dict].[Status] ([Id], [Name]) VALUES (3, 'In preparation');
GO

CREATE TABLE [dbo].[Package] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [AddresseeId] VARCHAR(30) NOT NULL CONSTRAINT FK_Package_Addressee REFERENCES dbo.ApplicationUser(Id),
    [SenderId] VARCHAR(30) NULL CONSTRAINT FK_Package_Sender REFERENCES dbo.ApplicationUser(Id),
    [PostMachineId] INT NOT NULL CONSTRAINT FK_Package_PostMachine REFERENCES dbo.PostMachine(Id),
    [StatusId] INT NOT NULL CONSTRAINT FK_Package_Status REFERENCES dict.Status(Id),
    CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED([Id] ASC)
);
GO


