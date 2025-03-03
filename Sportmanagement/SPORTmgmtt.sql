USE [ASP03]
GO
/****** Object:  Table [dbo].[Tbl_Registration]    Script Date: 09/26/2020 17:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Registration](
	[name] [varchar](50) NULL,
	[fname] [varchar](50) NULL,
	[email] [varchar](50) NOT NULL,
	[mobile] [varchar](50) NULL,
	[passwd] [varchar](50) NULL,
	[branch] [varchar](50) NULL,
	[year] [varchar](50) NULL,
	[address] [varchar](500) NULL,
	[Gender] [varchar](50) NULL,
	[stype] [varchar](50) NULL,
	[picture] [varchar](max) NULL,
	[Rdt] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_Registration] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_LOGIN]    Script Date: 09/26/2020 17:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_LOGIN](
	[userid] [varchar](50) NULL,
	[passwd] [varchar](50) NULL,
	[utype] [varchar](50) NULL,
	[LDT] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_feedback]    Script Date: 09/26/2020 17:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_feedback](
	[fid] [int] IDENTITY(1,1) NOT NULL,
	[rate] [varchar](50) NULL,
	[msg] [varchar](50) NULL,
	[id] [varchar](50) NULL,
	[fdt] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_feedback] PRIMARY KEY CLUSTERED 
(
	[fid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Enquiry]    Script Date: 09/26/2020 17:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Enquiry](
	[EId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [bigint] NULL,
	[Msg] [varchar](150) NULL,
	[EDT] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_Enquiry] PRIMARY KEY CLUSTERED 
(
	[EId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
