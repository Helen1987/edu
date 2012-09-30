-- Table structure for table 'Users'
IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users')) DROP TABLE [Users]
GO
CREATE TABLE [Users] (
[ID] int IDENTITY NOT NULL,
[UserName] varchar(50) NOT NULL,
[AddressName] varchar(50),
[AddressStreet] varchar(50),
[AddressCity] varchar(50),
[AddressState] varchar(50),
[AddressZipCode] varchar(50),
[AddressCountry] varchar(50))
GO

CREATE UNIQUE NONCLUSTERED INDEX IX_Users ON [Users] (UserName)
GO

CREATE UNIQUE CLUSTERED INDEX PK_Users ON [Users] (ID)
GO


-- Dumping data for table 'Users'
--

-- Enable identity insert
SET IDENTITY_INSERT [Users] ON
GO

INSERT INTO [Users] ([ID], [UserName], [AddressName], [AddressStreet], [AddressCity], [AddressState], [AddressZipCode], [AddressCountry])
VALUES(1, 'FARIAMAT\Faria', 'Faria', '524 S. Walnut', 'Lansing', 'Michigan', '48933', 'U.S.A.')
GO
INSERT INTO [Users] ([ID], [UserName], [AddressName], [AddressStreet], [AddressCity], [AddressState], [AddressZipCode], [AddressCountry])
VALUES(2, 'FARIAMAT\Matthew', 'Matthew', '310 Smokra St', 'Toronto', 'Ontario', 'M5N1J6', 'Canada')
GO



IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users_Delete') AND (xtype = 'P')) DROP PROCEDURE [Users_Delete]
GO
CREATE PROCEDURE [Users_Delete]	(@UserName varchar(50)) AS DELETE [aspnetdb].[dbo].[Users] WHERE 	( UserName	 = @UserName)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users_GetByUserName') AND (xtype = 'P')) DROP PROCEDURE [Users_GetByUserName]
GO
CREATE PROCEDURE Users_GetByUserName (@UserName varchar(50))
 AS SELECT * FROM Users WHERE UserName = @UserName
GO

IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users_Update') AND (xtype = 'P')) DROP PROCEDURE [Users_Update]
GO
CREATE PROCEDURE [Users_Update]	( @UserName 	[varchar](50),	 @AddressName 	[varchar](50),	 @AddressStreet 	[varchar](50),	 @AddressCity 	[varchar](50),	 @AddressState 	[varchar](50),	 @AddressZipCode 	[varchar](50),	 @AddressCountry 	[varchar](50))AS DECLARE @Match intSELECT @Match = COUNT(*) FROM Users    WHERE  UserName = @UserName    IF (@Match = 0)    INSERT INTO Users	 (	 [UserName],	 [AddressName],	 [AddressStreet],	 [AddressCity],	 [AddressState],	 [AddressZipCode],	 [AddressCountry])  VALUES 	(	 @UserName,	 @AddressName,	 @AddressStreet,	 @AddressCity,	 @AddressState,	 @AddressZipCode,	 @AddressCountry)    IF (@Match = 1)UPDATE [aspnetdb].[dbo].[Users] SET  	 [UserName]	 = @UserName,	 [AddressName]	 = @AddressName,	 [AddressStreet]	 = @AddressStreet,	 [AddressCity]	 = @AddressCity,	 [AddressState]	 = @AddressState,	 [AddressZipCode]	 = @AddressZipCode,	 [AddressCountry]	 = @AddressCountry WHERE 	( UserName	 = @UserName)
GO

