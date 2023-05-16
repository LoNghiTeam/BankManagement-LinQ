
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/17/2023 00:29:12
-- Generated from EDMX file: C:\Users\admin\Documents\GitHub\BankManagement-LinQ\BankManagement\BankModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bank];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GiaoDichTaiKhoan_GiaoDich]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiaoDichTaiKhoan] DROP CONSTRAINT [FK_GiaoDichTaiKhoan_GiaoDich];
GO
IF OBJECT_ID(N'[dbo].[FK_GiaoDichTaiKhoan_TaiKhoan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GiaoDichTaiKhoan] DROP CONSTRAINT [FK_GiaoDichTaiKhoan_TaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[FK_KhoanVayTaiKhoan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KhoanVays] DROP CONSTRAINT [FK_KhoanVayTaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[FK_SoTietKiemTaiKhoan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoTietKiems] DROP CONSTRAINT [FK_SoTietKiemTaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[FK_TheTinDungTaiKhoan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TheTinDungs] DROP CONSTRAINT [FK_TheTinDungTaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[FK_TheChapKhoanVay]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TheChaps] DROP CONSTRAINT [FK_TheChapKhoanVay];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TaiKhoans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaiKhoans];
GO
IF OBJECT_ID(N'[dbo].[GiaoDiches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiaoDiches];
GO
IF OBJECT_ID(N'[dbo].[KhoanVays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KhoanVays];
GO
IF OBJECT_ID(N'[dbo].[SoTietKiems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoTietKiems];
GO
IF OBJECT_ID(N'[dbo].[TheTinDungs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TheTinDungs];
GO
IF OBJECT_ID(N'[dbo].[TheChaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TheChaps];
GO
IF OBJECT_ID(N'[dbo].[GiaoDichTaiKhoan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiaoDichTaiKhoan];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TaiKhoans'
CREATE TABLE [dbo].[TaiKhoans] (
    [SoTK] int IDENTITY(1,1) NOT NULL,
    [TenTK] nvarchar(max)  NOT NULL,
    [MatKhau] nvarchar(max)  NOT NULL,
    [HoVaTen] nvarchar(max)  NOT NULL,
    [NgaySinh] datetime  NOT NULL,
    [CCCD] nvarchar(12)  NOT NULL,
    [DiaChi] nvarchar(max)  NOT NULL,
    [SDT] nvarchar(10)  NOT NULL,
    [IsAdmin] int  NOT NULL,
    [SoDu] float  NOT NULL,
    [NgayMoTaiKhoan] nvarchar(max)  NOT NULL,
    [DanhSachDen] int  NOT NULL
);
GO

-- Creating table 'GiaoDiches'
CREATE TABLE [dbo].[GiaoDiches] (
    [MaGD] int IDENTITY(1,1) NOT NULL,
    [LoaiGD] int  NOT NULL,
    [MaNguoiGui] int  NOT NULL,
    [MaNguoiNhan] int  NOT NULL,
    [SoTienGD] float  NOT NULL,
    [NgayGD] datetime  NOT NULL,
    [NoiDungGD] nvarchar(max)  NOT NULL,
    [TrangThaiGD] int  NOT NULL
);
GO

-- Creating table 'KhoanVays'
CREATE TABLE [dbo].[KhoanVays] (
    [SoKV] int IDENTITY(1,1) NOT NULL,
    [SoTK] int  NOT NULL,
    [NgayVay] datetime  NOT NULL,
    [NgayHan] datetime  NOT NULL,
    [ThoiGian] int  NOT NULL,
    [SoTienVay] float  NOT NULL,
    [LaiSuat] float  NOT NULL,
    [TinhTrang] int  NOT NULL,
    [LoaiKhoanVay] int  NOT NULL,
    [NgayTatToan] datetime  NULL
);
GO

-- Creating table 'SoTietKiems'
CREATE TABLE [dbo].[SoTietKiems] (
    [MaSTK] int IDENTITY(1,1) NOT NULL,
    [SoTK] int  NOT NULL,
    [TenSo] nvarchar(max)  NOT NULL,
    [NgayGui] datetime  NOT NULL,
    [NgayHan] datetime  NOT NULL,
    [SoTienGui] float  NOT NULL,
    [LaiSuat] float  NOT NULL,
    [ThoiGian] int  NOT NULL,
    [TinhTrang] int  NOT NULL,
    [NgayTatToan] datetime  NULL
);
GO

-- Creating table 'TheTinDungs'
CREATE TABLE [dbo].[TheTinDungs] (
    [MaTTD] int IDENTITY(1,1) NOT NULL,
    [SoTK] int  NOT NULL,
    [TenChuThe] nvarchar(max)  NOT NULL,
    [SoDu] float  NOT NULL,
    [HanMuc] float  NOT NULL,
    [TrangThai] int  NOT NULL,
    [NgayMoThe] datetime  NOT NULL,
    [NgayHan] datetime  NOT NULL,
    [MaBaoMat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TheChaps'
CREATE TABLE [dbo].[TheChaps] (
    [MaKVTC] int IDENTITY(1,1) NOT NULL,
    [VatTheChap] nvarchar(max)  NOT NULL,
    [GiaTriTheChap] float  NOT NULL,
    [KhoanVay_SoKV] int  NOT NULL
);
GO

-- Creating table 'GiaoDichTaiKhoan'
CREATE TABLE [dbo].[GiaoDichTaiKhoan] (
    [GiaoDiches_MaGD] int  NOT NULL,
    [TaiKhoans_SoTK] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SoTK] in table 'TaiKhoans'
ALTER TABLE [dbo].[TaiKhoans]
ADD CONSTRAINT [PK_TaiKhoans]
    PRIMARY KEY CLUSTERED ([SoTK] ASC);
GO

-- Creating primary key on [MaGD] in table 'GiaoDiches'
ALTER TABLE [dbo].[GiaoDiches]
ADD CONSTRAINT [PK_GiaoDiches]
    PRIMARY KEY CLUSTERED ([MaGD] ASC);
GO

-- Creating primary key on [SoKV] in table 'KhoanVays'
ALTER TABLE [dbo].[KhoanVays]
ADD CONSTRAINT [PK_KhoanVays]
    PRIMARY KEY CLUSTERED ([SoKV] ASC);
GO

-- Creating primary key on [MaSTK] in table 'SoTietKiems'
ALTER TABLE [dbo].[SoTietKiems]
ADD CONSTRAINT [PK_SoTietKiems]
    PRIMARY KEY CLUSTERED ([MaSTK] ASC);
GO

-- Creating primary key on [MaTTD] in table 'TheTinDungs'
ALTER TABLE [dbo].[TheTinDungs]
ADD CONSTRAINT [PK_TheTinDungs]
    PRIMARY KEY CLUSTERED ([MaTTD] ASC);
GO

-- Creating primary key on [MaKVTC] in table 'TheChaps'
ALTER TABLE [dbo].[TheChaps]
ADD CONSTRAINT [PK_TheChaps]
    PRIMARY KEY CLUSTERED ([MaKVTC] ASC);
GO

-- Creating primary key on [GiaoDiches_MaGD], [TaiKhoans_SoTK] in table 'GiaoDichTaiKhoan'
ALTER TABLE [dbo].[GiaoDichTaiKhoan]
ADD CONSTRAINT [PK_GiaoDichTaiKhoan]
    PRIMARY KEY CLUSTERED ([GiaoDiches_MaGD], [TaiKhoans_SoTK] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GiaoDiches_MaGD] in table 'GiaoDichTaiKhoan'
ALTER TABLE [dbo].[GiaoDichTaiKhoan]
ADD CONSTRAINT [FK_GiaoDichTaiKhoan_GiaoDich]
    FOREIGN KEY ([GiaoDiches_MaGD])
    REFERENCES [dbo].[GiaoDiches]
        ([MaGD])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TaiKhoans_SoTK] in table 'GiaoDichTaiKhoan'
ALTER TABLE [dbo].[GiaoDichTaiKhoan]
ADD CONSTRAINT [FK_GiaoDichTaiKhoan_TaiKhoan]
    FOREIGN KEY ([TaiKhoans_SoTK])
    REFERENCES [dbo].[TaiKhoans]
        ([SoTK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GiaoDichTaiKhoan_TaiKhoan'
CREATE INDEX [IX_FK_GiaoDichTaiKhoan_TaiKhoan]
ON [dbo].[GiaoDichTaiKhoan]
    ([TaiKhoans_SoTK]);
GO

-- Creating foreign key on [SoTK] in table 'KhoanVays'
ALTER TABLE [dbo].[KhoanVays]
ADD CONSTRAINT [FK_KhoanVayTaiKhoan]
    FOREIGN KEY ([SoTK])
    REFERENCES [dbo].[TaiKhoans]
        ([SoTK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KhoanVayTaiKhoan'
CREATE INDEX [IX_FK_KhoanVayTaiKhoan]
ON [dbo].[KhoanVays]
    ([SoTK]);
GO

-- Creating foreign key on [SoTK] in table 'SoTietKiems'
ALTER TABLE [dbo].[SoTietKiems]
ADD CONSTRAINT [FK_SoTietKiemTaiKhoan]
    FOREIGN KEY ([SoTK])
    REFERENCES [dbo].[TaiKhoans]
        ([SoTK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SoTietKiemTaiKhoan'
CREATE INDEX [IX_FK_SoTietKiemTaiKhoan]
ON [dbo].[SoTietKiems]
    ([SoTK]);
GO

-- Creating foreign key on [SoTK] in table 'TheTinDungs'
ALTER TABLE [dbo].[TheTinDungs]
ADD CONSTRAINT [FK_TheTinDungTaiKhoan]
    FOREIGN KEY ([SoTK])
    REFERENCES [dbo].[TaiKhoans]
        ([SoTK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TheTinDungTaiKhoan'
CREATE INDEX [IX_FK_TheTinDungTaiKhoan]
ON [dbo].[TheTinDungs]
    ([SoTK]);
GO

-- Creating foreign key on [KhoanVay_SoKV] in table 'TheChaps'
ALTER TABLE [dbo].[TheChaps]
ADD CONSTRAINT [FK_TheChapKhoanVay]
    FOREIGN KEY ([KhoanVay_SoKV])
    REFERENCES [dbo].[KhoanVays]
        ([SoKV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TheChapKhoanVay'
CREATE INDEX [IX_FK_TheChapKhoanVay]
ON [dbo].[TheChaps]
    ([KhoanVay_SoKV]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------