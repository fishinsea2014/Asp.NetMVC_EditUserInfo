
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2019 16:32:19
-- Generated from EDMX file: D:\my_projects\Interview_Netflex\MVC\MyProfile\DataSource\Users.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyProfile];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserPermission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permission] DROP CONSTRAINT [FK_UserPermission];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionsPermission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permission] DROP CONSTRAINT [FK_ActionsPermission];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permission];
GO
IF OBJECT_ID(N'[dbo].[Actions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FName] nvarchar(50)  NOT NULL,
    [LName] nvarchar(50)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [OrgName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [TimeZoneId] nvarchar(max)  NULL,
    [PhotoLink] nvarchar(max)  NULL,
    [DelFlag] smallint  NULL,
    [DefaultTimeZoneId] nvarchar(max)  NULL
);
GO

-- Creating table 'Permission'
CREATE TABLE [dbo].[Permission] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ActionId] int  NOT NULL,
    [Status] smallint  NOT NULL
);
GO

-- Creating table 'Actions'
CREATE TABLE [dbo].[Actions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActionName] nvarchar(50)  NOT NULL,
    [Remark] nvarchar(200)  NULL,
    [DelFlag] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [PK_Permission]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [PK_Actions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [FK_UserPermission]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPermission'
CREATE INDEX [IX_FK_UserPermission]
ON [dbo].[Permission]
    ([UserId]);
GO

-- Creating foreign key on [ActionId] in table 'Permission'
ALTER TABLE [dbo].[Permission]
ADD CONSTRAINT [FK_ActionsPermission]
    FOREIGN KEY ([ActionId])
    REFERENCES [dbo].[Actions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionsPermission'
CREATE INDEX [IX_FK_ActionsPermission]
ON [dbo].[Permission]
    ([ActionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------