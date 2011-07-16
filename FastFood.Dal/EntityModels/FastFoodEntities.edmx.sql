
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/15/2011 19:36:36
-- Generated from EDMX file: C:\Users\MM\Documents\Visual Studio 2010\Projects\FastFood\FastFood.Dal\EntityModels\FastFoodEntities.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ClientAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_ClientAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderDeliveryBoy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderDeliveryBoy];
GO
IF OBJECT_ID(N'[dbo].[FK_RestaurantAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restaurants] DROP CONSTRAINT [FK_RestaurantAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_DeliveryBoyRestaurant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeliveryBoys] DROP CONSTRAINT [FK_DeliveryBoyRestaurant];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ClientOrders];
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
IF OBJECT_ID(N'[dbo].[DeliveryBoys]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliveryBoys];
GO
IF OBJECT_ID(N'[dbo].[Restaurants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaurants];
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
    [Status] smallint  NOT NULL,
    [Cost] decimal(18,0)  NOT NULL,
    [ClientId] int  NOT NULL,
    [DeliveryBoy_Nick] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
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
    [PostalCode] int  NOT NULL,
    [Number] smallint  NOT NULL,
    [ApartmentNumber] nvarchar(max)  NULL
);
GO

-- Creating table 'DeliveryBoys'
CREATE TABLE [dbo].[DeliveryBoys] (
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [SuccesfulDeliveries] int  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Nick] nvarchar(20)  NOT NULL,
    [Restaurant_Name] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'Restaurants'
CREATE TABLE [dbo].[Restaurants] (
    [Name] nvarchar(30)  NOT NULL,
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

-- Creating primary key on [Nick] in table 'DeliveryBoys'
ALTER TABLE [dbo].[DeliveryBoys]
ADD CONSTRAINT [PK_DeliveryBoys]
    PRIMARY KEY CLUSTERED ([Nick] ASC);
GO

-- Creating primary key on [Name] in table 'Restaurants'
ALTER TABLE [dbo].[Restaurants]
ADD CONSTRAINT [PK_Restaurants]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [DeliveryBoy_Nick] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderDeliveryBoy]
    FOREIGN KEY ([DeliveryBoy_Nick])
    REFERENCES [dbo].[DeliveryBoys]
        ([Nick])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDeliveryBoy'
CREATE INDEX [IX_FK_OrderDeliveryBoy]
ON [dbo].[Orders]
    ([DeliveryBoy_Nick]);
GO

-- Creating foreign key on [Address_Id] in table 'Restaurants'
ALTER TABLE [dbo].[Restaurants]
ADD CONSTRAINT [FK_RestaurantAddress]
    FOREIGN KEY ([Address_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RestaurantAddress'
CREATE INDEX [IX_FK_RestaurantAddress]
ON [dbo].[Restaurants]
    ([Address_Id]);
GO

-- Creating foreign key on [Restaurant_Name] in table 'DeliveryBoys'
ALTER TABLE [dbo].[DeliveryBoys]
ADD CONSTRAINT [FK_DeliveryBoyRestaurant]
    FOREIGN KEY ([Restaurant_Name])
    REFERENCES [dbo].[Restaurants]
        ([Name])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliveryBoyRestaurant'
CREATE INDEX [IX_FK_DeliveryBoyRestaurant]
ON [dbo].[DeliveryBoys]
    ([Restaurant_Name]);
GO

-- Creating foreign key on [ClientId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ClientOrders]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientOrders'
CREATE INDEX [IX_FK_ClientOrders]
ON [dbo].[Orders]
    ([ClientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------