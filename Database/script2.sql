USE [master]
GO
/****** Object:  Database [BusinessInformationDB]    Script Date: 24/05/2021 11:47:35 a. m. ******/
CREATE DATABASE [BusinessInformationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusinessInformationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BusinessInformationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BusinessInformationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BusinessInformationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BusinessInformationDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusinessInformationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusinessInformationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BusinessInformationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusinessInformationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusinessInformationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BusinessInformationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusinessInformationDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BusinessInformationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BusinessInformationDB] SET  MULTI_USER 
GO
ALTER DATABASE [BusinessInformationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusinessInformationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusinessInformationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusinessInformationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BusinessInformationDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BusinessInformationDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BusinessInformationDB] SET QUERY_STORE = OFF
GO
USE [BusinessInformationDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/05/2021 11:47:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataBisness]    Script Date: 24/05/2021 11:47:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataBisness](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_PersonalData] [int] NOT NULL,
	[Name_KindOfPerson] [varchar](30) NULL,
	[NameBusiness] [varchar](100) NOT NULL,
	[Adress] [varchar](200) NOT NULL,
	[Name_Municipality] [varchar](200) NULL,
	[Phone] [varchar](25) NOT NULL,
 CONSTRAINT [PK_DataBisness] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KindOfPerson]    Script Date: 24/05/2021 11:47:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KindOfPerson](
	[Name_KindOfPerson] [varchar](30) NOT NULL,
 CONSTRAINT [PK_KindOfPerson] PRIMARY KEY CLUSTERED 
(
	[Name_KindOfPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Municipality]    Script Date: 24/05/2021 11:47:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Municipality](
	[Municipalitys] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Municipality] PRIMARY KEY CLUSTERED 
(
	[Municipalitys] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalData]    Script Date: 24/05/2021 11:47:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalData](
	[Id] [bigint] NOT NULL,
	[Name_Type_Document] [varchar](40) NULL,
	[NumberDocument] [int] NOT NULL,
	[NameBusiness] [varchar](100) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[MiddleName] [varchar](20) NULL,
	[FirstLastName] [varchar](20) NOT NULL,
	[SecondLastName] [varchar](20) NULL,
	[Email] [varchar](100) NOT NULL,
	[AuthorizePhone] [tinyint] NOT NULL,
	[AuthorizeEmail] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_PersonalData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeDocument]    Script Date: 24/05/2021 11:47:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeDocument](
	[Name_Type_Document] [varchar](40) NOT NULL,
 CONSTRAINT [PK_TypeDocument] PRIMARY KEY CLUSTERED 
(
	[Name_Type_Document] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210523215638_v1.0.0', N'3.1.15')
GO
INSERT [dbo].[KindOfPerson] ([Name_KindOfPerson]) VALUES (N'Persona Juridica')
INSERT [dbo].[KindOfPerson] ([Name_KindOfPerson]) VALUES (N'Persona Natural')
GO
INSERT [dbo].[Municipality] ([Municipalitys]) VALUES (N'Colombia - Cundinamarca- Bogota DC')
GO
INSERT [dbo].[PersonalData] ([Id], [Name_Type_Document], [NumberDocument], [NameBusiness], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [Email], [AuthorizePhone], [AuthorizeEmail], [Status]) VALUES (123456789, N'CC', 123456789, N'Pruebas', N'Jhon', N'Alex', N'Rodriguez', N'Acevedo', N'jhon12389.com@gmail.com', 1, 1, 1)
INSERT [dbo].[PersonalData] ([Id], [Name_Type_Document], [NumberDocument], [NameBusiness], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [Email], [AuthorizePhone], [AuthorizeEmail], [Status]) VALUES (123789456, N'CC', 987654321, N'Pruebas1', N'Yesenia', N'Alejandra', N'Casallas', N'Sarmiento', N'YEsenia.casallas@gmail.com', 1, 1, 0)
INSERT [dbo].[PersonalData] ([Id], [Name_Type_Document], [NumberDocument], [NameBusiness], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [Email], [AuthorizePhone], [AuthorizeEmail], [Status]) VALUES (900674335, N'CC', 0, N'Pruebas1', N'Yesenia', N'Alejandra', N'Casallas', N'Sarmiento', N'YEsenia.casallas@gmail.com', 1, 1, 0)
INSERT [dbo].[PersonalData] ([Id], [Name_Type_Document], [NumberDocument], [NameBusiness], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [Email], [AuthorizePhone], [AuthorizeEmail], [Status]) VALUES (987654321, N'CC', 0, N'Pruebas1', N'Yesenia', N'Alejandra', N'Casallas', N'Sarmiento', N'YEsenia.casallas@gmail.com', 1, 1, 0)
INSERT [dbo].[PersonalData] ([Id], [Name_Type_Document], [NumberDocument], [NameBusiness], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [Email], [AuthorizePhone], [AuthorizeEmail], [Status]) VALUES (1234543234, N'cc', 123454321, N'asdfsxdcfd', N'dsfdsadf', N'dsfgdsfg', N'sdfgdsfg', N'dsfgfdfg', N'fdfgsdfg@gmailcim', 1, 1, 1)
INSERT [dbo].[PersonalData] ([Id], [Name_Type_Document], [NumberDocument], [NameBusiness], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [Email], [AuthorizePhone], [AuthorizeEmail], [Status]) VALUES (2134532122, N'cc', 2345675, N'dsfdsadf', N'dfdsfg', N'sdfdsf', N'sdfgds', N'fdsfds', N'dfsdf@gmaIL.COM', 1, 1, 1)
INSERT [dbo].[PersonalData] ([Id], [Name_Type_Document], [NumberDocument], [NameBusiness], [FirstName], [MiddleName], [FirstLastName], [SecondLastName], [Email], [AuthorizePhone], [AuthorizeEmail], [Status]) VALUES (2134532123, N'cc', 2345675, N'dsfdsadf', N'dfdsfg', N'sdfdsf', N'sdfgds', N'fdsfds', N'dfsdf@gmaIL.COM', 1, 1, 1)
GO
INSERT [dbo].[TypeDocument] ([Name_Type_Document]) VALUES (N'cc')
INSERT [dbo].[TypeDocument] ([Name_Type_Document]) VALUES (N'ce')
INSERT [dbo].[TypeDocument] ([Name_Type_Document]) VALUES (N'ps')
GO
USE [master]
GO
ALTER DATABASE [BusinessInformationDB] SET  READ_WRITE 
GO
