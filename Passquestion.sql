USE [master]
GO
/****** Object:  Database [pastquestion]    Script Date: 8/28/2023 9:20:08 AM ******/
CREATE DATABASE [pastquestion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pastquestion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\pastquestion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pastquestion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\pastquestion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pastquestion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pastquestion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pastquestion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pastquestion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pastquestion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pastquestion] SET ARITHABORT OFF 
GO
ALTER DATABASE [pastquestion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pastquestion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pastquestion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pastquestion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pastquestion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pastquestion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pastquestion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pastquestion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pastquestion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pastquestion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [pastquestion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pastquestion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pastquestion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pastquestion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pastquestion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pastquestion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pastquestion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pastquestion] SET RECOVERY FULL 
GO
ALTER DATABASE [pastquestion] SET  MULTI_USER 
GO
ALTER DATABASE [pastquestion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pastquestion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pastquestion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pastquestion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'pastquestion', N'ON'
GO
USE [pastquestion]
GO
/****** Object:  Table [dbo].[feesettings]    Script Date: 8/28/2023 9:20:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feesettings](
	[id] [varchar](200) NOT NULL,
	[feename] [varchar](200) NULL,
	[description] [varchar](200) NULL,
	[amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_feesettings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments]    Script Date: 8/28/2023 9:20:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments](
	[id] [varchar](200) NOT NULL,
	[userid] [varchar](200) NULL,
	[name] [varchar](200) NULL,
	[email] [varchar](200) NULL,
	[phone] [varchar](200) NULL,
	[paymentdate] [datetime] NULL,
	[amount] [decimal](18, 2) NULL,
	[duedate] [datetime] NULL,
 CONSTRAINT [PK_payments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[questions]    Script Date: 8/28/2023 9:20:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[questions](
	[id] [varchar](200) NOT NULL,
	[names] [varchar](200) NULL,
	[description] [varchar](200) NULL,
	[subjectid] [varchar](200) NULL,
	[examyear] [varchar](200) NULL,
	[examtype] [varchar](200) NULL,
	[insertdate] [date] NULL,
	[photo] [varchar](max) NULL,
 CONSTRAINT [PK_questions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subjects]    Script Date: 8/28/2023 9:20:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subjects](
	[id] [varchar](200) NOT NULL,
	[name] [varchar](200) NULL,
	[description] [varchar](200) NULL,
 CONSTRAINT [PK_subjects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[useraccounts]    Script Date: 8/28/2023 9:20:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[useraccounts](
	[id] [varchar](200) NOT NULL,
	[name] [varchar](200) NULL,
	[phone] [varchar](200) NULL,
	[address] [varchar](200) NULL,
	[email] [varchar](200) NULL,
	[password] [varchar](max) NULL,
	[insertdate] [datetime] NULL,
	[usertype] [varchar](200) NULL,
 CONSTRAINT [PK_useraccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[useraccounts] ([id], [name], [phone], [address], [email], [password], [insertdate], [usertype]) VALUES (N'325DC503', N'Yusuf', N'07060601330', N'admin @ Home', N'user@gmail.com', N'240u0HKuQlMH2bEJymBRwg==', CAST(N'2023-08-26T14:45:32.630' AS DateTime), N'USER')
GO
INSERT [dbo].[useraccounts] ([id], [name], [phone], [address], [email], [password], [insertdate], [usertype]) VALUES (N'609ADD58', N'Admin', N'07060601330', N'admin @ Home', N'admin@gmail.com', N'240u0HKuQlMH2bEJymBRwg==', CAST(N'2023-08-26T14:44:26.273' AS DateTime), N'ADMIN')
GO
ALTER TABLE [dbo].[payments] ADD  CONSTRAINT [DF_payments_paymentdate]  DEFAULT (getdate()) FOR [paymentdate]
GO
ALTER TABLE [dbo].[payments] ADD  CONSTRAINT [DF_payments_duedate]  DEFAULT (getdate()) FOR [duedate]
GO
ALTER TABLE [dbo].[questions] ADD  CONSTRAINT [DF_questions_insertdate]  DEFAULT (getdate()) FOR [insertdate]
GO
ALTER TABLE [dbo].[useraccounts] ADD  CONSTRAINT [DF_useraccounts_insertdate]  DEFAULT (getdate()) FOR [insertdate]
GO
ALTER TABLE [dbo].[payments]  WITH CHECK ADD  CONSTRAINT [FK_payments_useraccounts] FOREIGN KEY([userid])
REFERENCES [dbo].[useraccounts] ([id])
GO
ALTER TABLE [dbo].[payments] CHECK CONSTRAINT [FK_payments_useraccounts]
GO
ALTER TABLE [dbo].[questions]  WITH CHECK ADD  CONSTRAINT [FK_questions_subjects] FOREIGN KEY([subjectid])
REFERENCES [dbo].[subjects] ([id])
GO
ALTER TABLE [dbo].[questions] CHECK CONSTRAINT [FK_questions_subjects]
GO
USE [master]
GO
ALTER DATABASE [pastquestion] SET  READ_WRITE 
GO
