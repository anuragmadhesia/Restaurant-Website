USE [master]
GO
/****** Object:  Database [CityRestaurant]    Script Date: 10/30/2020 07:41:24 ******/
CREATE DATABASE [CityRestaurant] ON  PRIMARY 
( NAME = N'CityRestaurant', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL\MSSQL\DATA\CityRestaurant.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CityRestaurant_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL\MSSQL\DATA\CityRestaurant_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CityRestaurant] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CityRestaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CityRestaurant] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CityRestaurant] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CityRestaurant] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CityRestaurant] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CityRestaurant] SET ARITHABORT OFF
GO
ALTER DATABASE [CityRestaurant] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CityRestaurant] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CityRestaurant] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CityRestaurant] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CityRestaurant] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CityRestaurant] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CityRestaurant] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CityRestaurant] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CityRestaurant] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CityRestaurant] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CityRestaurant] SET  DISABLE_BROKER
GO
ALTER DATABASE [CityRestaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CityRestaurant] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CityRestaurant] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CityRestaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CityRestaurant] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CityRestaurant] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CityRestaurant] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CityRestaurant] SET  READ_WRITE
GO
ALTER DATABASE [CityRestaurant] SET RECOVERY SIMPLE
GO
ALTER DATABASE [CityRestaurant] SET  MULTI_USER
GO
ALTER DATABASE [CityRestaurant] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CityRestaurant] SET DB_CHAINING OFF
GO
USE [CityRestaurant]
GO
/****** Object:  Table [dbo].[Tbl_Registration]    Script Date: 10/30/2020 07:41:26 ******/
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
/****** Object:  Table [dbo].[Tbl_orders]    Script Date: 10/30/2020 07:41:26 ******/
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
/****** Object:  Table [dbo].[Tbl_menu]    Script Date: 10/30/2020 07:41:26 ******/
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
/****** Object:  Table [dbo].[Tbl_login]    Script Date: 10/30/2020 07:41:26 ******/
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
/****** Object:  Table [dbo].[Tbl_feedbacks]    Script Date: 10/30/2020 07:41:26 ******/
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
/****** Object:  Table [dbo].[Tbl_Contacts]    Script Date: 10/30/2020 07:41:26 ******/
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
/****** Object:  Table [dbo].[Tbl_Bookings]    Script Date: 10/30/2020 07:41:26 ******/
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
