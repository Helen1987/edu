USE Northwind
go

-- Table structure for table 'SiteMap'
IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'SiteMap')) DROP TABLE [SiteMap]
GO
CREATE TABLE [SiteMap] (
[ID] int IDENTITY NOT NULL,
[Url] varchar(100),
[Title] varchar(100) NOT NULL,
[Description] varchar(250),
[ParentID] int)
GO

CREATE UNIQUE CLUSTERED INDEX PK_SiteMap ON [SiteMap] (ID)
GO


-- Dumping data for table 'SiteMap'
--

-- Enable identity insert
SET IDENTITY_INSERT [SiteMap] ON
GO

INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(1, '~/default.aspx', 'Home', 'Home', NULL)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(2, '~/Products.aspx', 'Products', 'Our Products', 1)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(5, '~/Hardware.aspx', 'Hardware', 'Hardware Choices', 2)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(6, '~/Software.aspx', 'Software', 'Software Choices', 2)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(7, '~/Services.aspx', 'Services', 'Services We Offer', 1)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(8, '~/Training.aspx', 'Training', 'Training Classes', 7)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(9, '~/Consulting.aspx', 'Consulting', 'Consulting Services', 7)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(10, '~/Support.aspx', 'Support', 'Support Plans', 7)
GO


IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'GetSiteMap') AND (xtype = 'P')) DROP PROCEDURE [GetSiteMap]
GO
CREATE PROCEDURE GetSiteMap AS SELECT * FROM SiteMap
GO

