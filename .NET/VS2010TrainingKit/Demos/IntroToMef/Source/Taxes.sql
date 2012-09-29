USE [Taxes]
GO
/****** Object:  Table [dbo].[SalesTax]    Script Date: 05/18/2009 10:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesTax](
	[State] [char](2) NOT NULL,
	[Percentage] [money] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[SalesTax] ([State], [Percentage]) VALUES (N'WA', 0.0650)
INSERT [dbo].[SalesTax] ([State], [Percentage]) VALUES (N'OR', 0.0000)
INSERT [dbo].[SalesTax] ([State], [Percentage]) VALUES (N'CA', 0.0825)
