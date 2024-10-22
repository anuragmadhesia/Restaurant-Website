USE [CityRestaurant]
GO
/****** Object:  Table [dbo].[Tbl_Registration]    Script Date: 10/30/2020 18:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Registration](
	[name] [varchar](50) NULL,
	[dob] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[email] [varchar](50) NOT NULL,
	[mobile] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[pincode] [int] NULL,
	[Rdt] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_Registration] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_orders]    Script Date: 10/30/2020 18:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[itemcodes] [varchar](500) NULL,
	[itemnames] [varchar](500) NULL,
	[totalprice] [varchar](50) NULL,
	[useremail] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[usermobile] [varchar](50) NULL,
	[address] [varchar](500) NULL,
	[purchased] [varchar](50) NULL,
	[pdt] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_menu]    Script Date: 10/30/2020 18:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_menu](
	[iid] [int] IDENTITY(1,1) NOT NULL,
	[iname] [varchar](50) NULL,
	[idesc] [varchar](500) NULL,
	[iprice] [varchar](50) NULL,
	[ipic] [varchar](max) NULL,
	[idate] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_menu] PRIMARY KEY CLUSTERED 
(
	[iid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_login]    Script Date: 10/30/2020 18:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_login](
	[loginid] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[usertype] [varchar](50) NULL,
	[LDT] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_feedbacks]    Script Date: 10/30/2020 18:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_feedbacks](
	[fno] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[rating] [int] NULL,
	[feedback] [varchar](500) NULL,
	[Fdt] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Contacts]    Script Date: 10/30/2020 18:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Contacts](
	[cno] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[message] [varchar](500) NULL,
	[cdt] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Bookings]    Script Date: 10/30/2020 18:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Bookings](
	[bno] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[mobile] [int] NULL,
	[email] [varchar](50) NULL,
	[date] [varchar](50) NULL,
	[time] [varchar](50) NULL,
	[tabletype] [varchar](50) NULL,
	[preference] [varchar](50) NULL,
	[bdt] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
