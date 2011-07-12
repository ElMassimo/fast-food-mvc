
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2011 19:19:20
-- Generated from EDMX file: c:\users\mm\documents\visual studio 2010\Projects\FastFood\FastFood.Core\EntityModels\FastFoodEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FastFood];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrderClient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_OrderClient];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_ClientAddress];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [DateOrdered] datetime  NOT NULL,
    [DateDelivered] datetime  NULL,
    [Status] nchar(1)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [DeliveryBoy_Id] int  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Orders_Id] int  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [PostalCode] int  NULL,
    [Number] smallint  NOT NULL,
    [ApartmentNumber] smallint  NULL
);
GO

-- Creating table 'DeliveryBoys'
CREATE TABLE [dbo].[DeliveryBoys] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [SuccesfulDeliveries] int  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Branch_Id] int  NOT NULL
);
GO

-- Creating table 'Branchs'
CREATE TABLE [dbo].[Branchs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeliveryBoys'
ALTER TABLE [dbo].[DeliveryBoys]
ADD CONSTRAINT [PK_DeliveryBoys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Branchs'
ALTER TABLE [dbo].[Branchs]
ADD CONSTRAINT [PK_Branchs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Orders_Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_OrderClient]
    FOREIGN KEY ([Orders_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderClient'
CREATE INDEX [IX_FK_OrderClient]
ON [dbo].[Clients]
    ([Orders_Id]);
GO

-- Creating foreign key on [Address_Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_ClientAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAddress'
CREATE INDEX [IX_FK_ClientAddress]
ON [dbo].[Clients]
    ([Address_Id]);
GO

-- Creating foreign key on [DeliveryBoy_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderDeliveryBoy]
    FOREIGN KEY ([DeliveryBoy_Id])
    REFERENCES [dbo].[DeliveryBoys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDeliveryBoy'
CREATE INDEX [IX_FK_OrderDeliveryBoy]
ON [dbo].[Orders]
    ([DeliveryBoy_Id]);
GO

-- Creating foreign key on [Address_Id] in table 'Branchs'
ALTER TABLE [dbo].[Branchs]
ADD CONSTRAINT [FK_BranchAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchAddress'
CREATE INDEX [IX_FK_BranchAddress]
ON [dbo].[Branchs]
    ([Address_Id]);
GO

-- Creating foreign key on [Branch_Id] in table 'DeliveryBoys'
ALTER TABLE [dbo].[DeliveryBoys]
ADD CONSTRAINT [FK_DeliveryBoyBranch]
    FOREIGN KEY ([Branch_Id])
    REFERENCES [dbo].[Branchs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliveryBoyBranch'
CREATE INDEX [IX_FK_DeliveryBoyBranch]
ON [dbo].[DeliveryBoys]
    ([Branch_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------