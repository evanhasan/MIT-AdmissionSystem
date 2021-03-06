/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2012 (11.0.2100)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [MITAdmissionDB]    Script Date: 9/18/2017 11:26:16 AM ******/
CREATE DATABASE [MITAdmissionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MITAdmissionDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MITAdmissionDB.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MITAdmissionDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\MITAdmissionDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MITAdmissionDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MITAdmissionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MITAdmissionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MITAdmissionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MITAdmissionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MITAdmissionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MITAdmissionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MITAdmissionDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MITAdmissionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MITAdmissionDB] SET  MULTI_USER 
GO
ALTER DATABASE [MITAdmissionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MITAdmissionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MITAdmissionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MITAdmissionDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MITAdmissionDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9/18/2017 11:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 9/18/2017 11:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Designation] [nvarchar](max) NOT NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ConfirmPassword] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Admins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bachelors]    Script Date: 9/18/2017 11:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bachelors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Digree] [nvarchar](max) NULL,
	[Decription] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Bachelors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 9/18/2017 11:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameofApplicant] [nvarchar](max) NOT NULL,
	[FatherName] [nvarchar](max) NOT NULL,
	[MotherName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ParmanentAddress] [nvarchar](max) NOT NULL,
	[Nationality] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[DateofBirth] [datetime] NOT NULL,
	[SSCSchool] [nvarchar](max) NOT NULL,
	[SSCYear] [nvarchar](4) NOT NULL,
	[SSCGroup] [nvarchar](max) NOT NULL,
	[SSCPoint] [float] NOT NULL,
	[HSCCollege] [nvarchar](max) NOT NULL,
	[HSCYear] [nvarchar](4) NOT NULL,
	[HSCGroup] [nvarchar](max) NOT NULL,
	[HSCPoint] [float] NOT NULL,
	[BachelorId] [nvarchar](max) NOT NULL,
	[BachelorUniversity] [nvarchar](max) NOT NULL,
	[BachelorYear] [nvarchar](max) NOT NULL,
	[BachelorGrade] [float] NOT NULL,
	[MasterUniversity] [nvarchar](max) NULL,
	[MasterYear] [nvarchar](max) NULL,
	[MasterGrade] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ConfirmPassword] [nvarchar](max) NOT NULL,
	[PhotoPath] [nvarchar](max) NULL,
	[SignaturePath] [nvarchar](max) NULL,
	[BachelorCertificatePath] [nvarchar](max) NULL,
	[PayStatus] [int] NOT NULL,
	[TrxId] [int] NOT NULL,
	[ShortList] [int] NOT NULL,
	[Admit] [int] NOT NULL,
	[RollNumber] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Registrations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 9/18/2017 11:26:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamName] [nvarchar](max) NOT NULL,
	[ExamDescription] [nvarchar](max) NULL,
	[RegStartDate] [datetime] NOT NULL,
	[RegEndDate] [datetime] NOT NULL,
	[AdmitCardDate] [datetime] NOT NULL,
	[ExamDate] [datetime] NOT NULL,
	[Brochure] [nvarchar](max) NULL,
	[ExamFee] [float] NOT NULL,
	[ExamTime] [nvarchar](max) NULL,
	[Venue] [nvarchar](max) NULL,
	[WrittenTestResult] [datetime] NOT NULL,
	[VivaDate] [datetime] NOT NULL,
	[FinalResult] [datetime] NOT NULL,
	[AdmissionDate] [datetime] NOT NULL,
	[AdmissionDateWaitingList] [datetime] NOT NULL,
	[ClassStart] [datetime] NOT NULL,
	[AdmissionDateEnd] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ('') FOR [PhotoPath]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ('') FOR [SignaturePath]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ('') FOR [BachelorCertificatePath]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ((0)) FOR [PayStatus]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ((0)) FOR [TrxId]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ((0)) FOR [ShortList]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ((0)) FOR [Admit]
GO
ALTER TABLE [dbo].[Registrations] ADD  DEFAULT ((0)) FOR [RollNumber]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ((0)) FOR [ExamFee]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [WrittenTestResult]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [VivaDate]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [FinalResult]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [AdmissionDate]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [AdmissionDateWaitingList]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [ClassStart]
GO
ALTER TABLE [dbo].[Settings] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [AdmissionDateEnd]
GO
USE [master]
GO
ALTER DATABASE [MITAdmissionDB] SET  READ_WRITE 
GO
