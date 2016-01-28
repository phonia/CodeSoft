
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/26/2016 16:02:34
-- Generated from EDMX file: E:\Code\CodeSoft\ERP.Models\DataContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyERP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MSModuleMSRight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MSRightSet] DROP CONSTRAINT [FK_MSModuleMSRight];
GO
IF OBJECT_ID(N'[dbo].[FK_MSFuncMSRight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MSRightSet] DROP CONSTRAINT [FK_MSFuncMSRight];
GO
IF OBJECT_ID(N'[dbo].[FK_MSRightMSRole_MSRight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MSRightMSRole] DROP CONSTRAINT [FK_MSRightMSRole_MSRight];
GO
IF OBJECT_ID(N'[dbo].[FK_MSRightMSRole_MSRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MSRightMSRole] DROP CONSTRAINT [FK_MSRightMSRole_MSRole];
GO
IF OBJECT_ID(N'[dbo].[FK_MSRoleMSUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MSUserSet] DROP CONSTRAINT [FK_MSRoleMSUser];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeSet] DROP CONSTRAINT [FK_DepartmentEmployee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MSUserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSUserSet];
GO
IF OBJECT_ID(N'[dbo].[MSModuleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSModuleSet];
GO
IF OBJECT_ID(N'[dbo].[MSFuncSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSFuncSet];
GO
IF OBJECT_ID(N'[dbo].[MSRightSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSRightSet];
GO
IF OBJECT_ID(N'[dbo].[MSRoleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSRoleSet];
GO
IF OBJECT_ID(N'[dbo].[DepartmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartmentSet];
GO
IF OBJECT_ID(N'[dbo].[EmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSet];
GO
IF OBJECT_ID(N'[dbo].[MSRightMSRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MSRightMSRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MSUserSet'
CREATE TABLE [dbo].[MSUserSet] (
    [UserId] uniqueidentifier  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [MSRole_RoleId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'MSModuleSet'
CREATE TABLE [dbo].[MSModuleSet] (
    [ModuleId] nvarchar(50)  NOT NULL,
    [ModuleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MSFuncSet'
CREATE TABLE [dbo].[MSFuncSet] (
    [FuncId] nvarchar(50)  NOT NULL,
    [FuncName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MSRightSet'
CREATE TABLE [dbo].[MSRightSet] (
    [RightId] uniqueidentifier  NOT NULL,
    [MSModule_ModuleId] nvarchar(50)  NULL,
    [MSFunc_FuncId] nvarchar(50)  NULL
);
GO

-- Creating table 'MSRoleSet'
CREATE TABLE [dbo].[MSRoleSet] (
    [RoleId] uniqueidentifier  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DepartmentSet'
CREATE TABLE [dbo].[DepartmentSet] (
    [DepartmentId] int IDENTITY(1,1) NOT NULL,
    [DepartmentName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmployeeSet'
CREATE TABLE [dbo].[EmployeeSet] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sex] int  NOT NULL,
    [Age] int  NOT NULL,
    [Department_DepartmentId] int  NULL
);
GO

-- Creating table 'MSRightMSRole'
CREATE TABLE [dbo].[MSRightMSRole] (
    [MSRight_RightId] uniqueidentifier  NOT NULL,
    [MSRole_RoleId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'MSUserSet'
ALTER TABLE [dbo].[MSUserSet]
ADD CONSTRAINT [PK_MSUserSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ModuleId] in table 'MSModuleSet'
ALTER TABLE [dbo].[MSModuleSet]
ADD CONSTRAINT [PK_MSModuleSet]
    PRIMARY KEY CLUSTERED ([ModuleId] ASC);
GO

-- Creating primary key on [FuncId] in table 'MSFuncSet'
ALTER TABLE [dbo].[MSFuncSet]
ADD CONSTRAINT [PK_MSFuncSet]
    PRIMARY KEY CLUSTERED ([FuncId] ASC);
GO

-- Creating primary key on [RightId] in table 'MSRightSet'
ALTER TABLE [dbo].[MSRightSet]
ADD CONSTRAINT [PK_MSRightSet]
    PRIMARY KEY CLUSTERED ([RightId] ASC);
GO

-- Creating primary key on [RoleId] in table 'MSRoleSet'
ALTER TABLE [dbo].[MSRoleSet]
ADD CONSTRAINT [PK_MSRoleSet]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [DepartmentId] in table 'DepartmentSet'
ALTER TABLE [dbo].[DepartmentSet]
ADD CONSTRAINT [PK_DepartmentSet]
    PRIMARY KEY CLUSTERED ([DepartmentId] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [PK_EmployeeSet]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [MSRight_RightId], [MSRole_RoleId] in table 'MSRightMSRole'
ALTER TABLE [dbo].[MSRightMSRole]
ADD CONSTRAINT [PK_MSRightMSRole]
    PRIMARY KEY CLUSTERED ([MSRight_RightId], [MSRole_RoleId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MSModule_ModuleId] in table 'MSRightSet'
ALTER TABLE [dbo].[MSRightSet]
ADD CONSTRAINT [FK_MSModuleMSRight]
    FOREIGN KEY ([MSModule_ModuleId])
    REFERENCES [dbo].[MSModuleSet]
        ([ModuleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MSModuleMSRight'
CREATE INDEX [IX_FK_MSModuleMSRight]
ON [dbo].[MSRightSet]
    ([MSModule_ModuleId]);
GO

-- Creating foreign key on [MSFunc_FuncId] in table 'MSRightSet'
ALTER TABLE [dbo].[MSRightSet]
ADD CONSTRAINT [FK_MSFuncMSRight]
    FOREIGN KEY ([MSFunc_FuncId])
    REFERENCES [dbo].[MSFuncSet]
        ([FuncId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MSFuncMSRight'
CREATE INDEX [IX_FK_MSFuncMSRight]
ON [dbo].[MSRightSet]
    ([MSFunc_FuncId]);
GO

-- Creating foreign key on [MSRight_RightId] in table 'MSRightMSRole'
ALTER TABLE [dbo].[MSRightMSRole]
ADD CONSTRAINT [FK_MSRightMSRole_MSRight]
    FOREIGN KEY ([MSRight_RightId])
    REFERENCES [dbo].[MSRightSet]
        ([RightId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MSRole_RoleId] in table 'MSRightMSRole'
ALTER TABLE [dbo].[MSRightMSRole]
ADD CONSTRAINT [FK_MSRightMSRole_MSRole]
    FOREIGN KEY ([MSRole_RoleId])
    REFERENCES [dbo].[MSRoleSet]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MSRightMSRole_MSRole'
CREATE INDEX [IX_FK_MSRightMSRole_MSRole]
ON [dbo].[MSRightMSRole]
    ([MSRole_RoleId]);
GO

-- Creating foreign key on [MSRole_RoleId] in table 'MSUserSet'
ALTER TABLE [dbo].[MSUserSet]
ADD CONSTRAINT [FK_MSRoleMSUser]
    FOREIGN KEY ([MSRole_RoleId])
    REFERENCES [dbo].[MSRoleSet]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MSRoleMSUser'
CREATE INDEX [IX_FK_MSRoleMSUser]
ON [dbo].[MSUserSet]
    ([MSRole_RoleId]);
GO

-- Creating foreign key on [Department_DepartmentId] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [FK_DepartmentEmployee]
    FOREIGN KEY ([Department_DepartmentId])
    REFERENCES [dbo].[DepartmentSet]
        ([DepartmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentEmployee'
CREATE INDEX [IX_FK_DepartmentEmployee]
ON [dbo].[EmployeeSet]
    ([Department_DepartmentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------