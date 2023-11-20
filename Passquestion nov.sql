USE [master]
GO
/****** Object:  Database [pastquestion]    Script Date: 20/11/2023 14:43:48 ******/
CREATE DATABASE [pastquestion]
  
CREATE TABLE [dbo].[B_booking](
	[id] [varchar](200) NOT NULL,
	[name] [varchar](200) NULL,
	[email] [varchar](200) NULL,
	[phone] [varchar](200) NULL,
	[address] [varchar](200) NULL,
	[feeid] [varchar](200) NULL,
	[trxid] [varchar](200) NULL,
	[userid] [varchar](200) NULL,
	[amount] [decimal](18, 2) NULL,
	[tenxdate] [datetime] NULL,
	[status] [varchar](200) NULL,
	[insertdate] [date] NULL,
	[booking_date] [date] NULL,
	[paymentid] [varchar](200) NULL,
	[refno] [varchar](200) NULL,
	[ptype] [varchar](200) NULL,
	[notes] [varchar](200) NULL,
	[insertuser] [varchar](200) NULL,
	[attendance_status] [varchar](200) NULL,
	[examtype] [varchar](200) NULL,
	[examyear] [varchar](200) NULL,
 CONSTRAINT [PK_B_booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[examtype]    Script Date: 20/11/2023 14:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[examtype](
	[id] [varchar](200) NOT NULL,
	[type] [varchar](200) NULL,
	[description] [varchar](200) NULL,
 CONSTRAINT [PK_examtype] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[examyear]    Script Date: 20/11/2023 14:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[examyear](
	[id] [varchar](200) NOT NULL,
	[year] [varchar](200) NULL,
	[description] [varchar](200) NULL,
 CONSTRAINT [PK_examyear] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[F_settings]    Script Date: 20/11/2023 14:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[F_settings](
	[id] [varchar](200) NOT NULL,
	[examyearid] [varchar](200) NULL,
	[examtypeid] [varchar](200) NULL,
	[amount] [varchar](200) NULL,
	[per_discount] [varchar](200) NULL,
 CONSTRAINT [PK_F_settings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[initializepayment]    Script Date: 20/11/2023 14:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[initializepayment](
	[id] [varchar](200) NOT NULL,
	[feeid] [varchar](200) NULL,
	[name] [varchar](200) NULL,
	[trxid] [varchar](200) NULL,
	[email] [varchar](200) NULL,
	[userid] [varchar](200) NULL,
	[phone] [varchar](200) NULL,
	[amount] [decimal](18, 2) NULL,
	[tenxdate] [datetime] NULL,
	[status] [varchar](200) NULL,
	[notes] [varchar](200) NULL,
	[gatewayref] [varchar](200) NULL,
	[ptype] [varchar](200) NULL,
	[insertuser] [varchar](200) NULL,
	[insertdate] [date] NULL,
 CONSTRAINT [PK_initializepayment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payments]    Script Date: 20/11/2023 14:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payments](
	[id] [varchar](200) NOT NULL,
	[feeid] [varchar](200) NULL,
	[name] [varchar](200) NULL,
	[trxid] [varchar](200) NULL,
	[email] [varchar](200) NULL,
	[userid] [varchar](200) NULL,
	[phone] [varchar](200) NULL,
	[amount] [decimal](18, 2) NULL,
	[tenxdate] [datetime] NULL,
	[status] [varchar](200) NULL,
	[notes] [varchar](200) NULL,
	[gatewayref] [varchar](200) NULL,
	[ptype] [varchar](200) NULL,
	[insertuser] [varchar](200) NULL,
	[insertdate] [date] NULL,
	[examtype] [varchar](200) NULL,
	[examyear] [varchar](200) NULL,
 CONSTRAINT [PK_payments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[questions]    Script Date: 20/11/2023 14:43:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[questions](
	[id] [varchar](200) NOT NULL,
	[names] [varchar](200) NULL,
	[description] [varchar](200) NULL,
	[subjectid] [varchar](200) NULL,
	[examyearid] [varchar](200) NULL,
	[examtypeid] [varchar](200) NULL,
	[insertdate] [date] NULL,
	[photo] [varchar](max) NULL,
	[expdate] [date] NULL,
	[status] [varchar](200) NULL,
	[url] [varchar](200) NULL,
	[doctype] [varchar](200) NULL,
 CONSTRAINT [PK_questions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subjects]    Script Date: 20/11/2023 14:43:48 ******/
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
/****** Object:  Table [dbo].[useraccounts]    Script Date: 20/11/2023 14:43:48 ******/
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
INSERT [dbo].[B_booking] ([id], [name], [email], [phone], [address], [feeid], [trxid], [userid], [amount], [tenxdate], [status], [insertdate], [booking_date], [paymentid], [refno], [ptype], [notes], [insertuser], [attendance_status], [examtype], [examyear]) VALUES (N'PASTQUESTION2F1D9ACA', N'Admin', N'admin@gmail.com', N'07060601330', N'admin @ Home', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', NULL, N'609ADD58', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T14:34:23.057' AS DateTime), N'BOOKED', CAST(N'2023-11-20' AS Date), CAST(N'0001-01-01' AS Date), NULL, NULL, N'PENDING', N'Paid online on: 20/11/2023 14:34:23', N'admin@gmail.com', N'PENDING', N'Jamb', N'1991-01-02')
GO
INSERT [dbo].[B_booking] ([id], [name], [email], [phone], [address], [feeid], [trxid], [userid], [amount], [tenxdate], [status], [insertdate], [booking_date], [paymentid], [refno], [ptype], [notes], [insertuser], [attendance_status], [examtype], [examyear]) VALUES (N'PASTQUESTION6FBC17E4', N'Admin', N'admin@gmail.com', N'07060601330', N'admin @ Home', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', NULL, N'609ADD58', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T14:39:10.420' AS DateTime), N'BOOKED', CAST(N'2023-11-20' AS Date), CAST(N'0001-01-01' AS Date), NULL, NULL, N'PENDING', N'Paid online on: 20/11/2023 14:39:10', N'admin@gmail.com', N'PENDING', N'Jamb', N'1991-01-02')
GO
INSERT [dbo].[examtype] ([id], [type], [description]) VALUES (N'0f4c46b9-7c9f-407a-8a8f-aaf609881f1c', N'Waec', N'Waec')
GO
INSERT [dbo].[examtype] ([id], [type], [description]) VALUES (N'42f7d38b-6de3-4381-bbb2-c917199cb1e5', N'Jamb', N'Jamb')
GO
INSERT [dbo].[examtype] ([id], [type], [description]) VALUES (N'5e9c4b5a-a42b-46a0-bfd5-ad8c0cffde36', N'Common Entrance', N'Primary 6')
GO
INSERT [dbo].[examtype] ([id], [type], [description]) VALUES (N'c7b83bd0-bcc0-4b62-b882-6fad0d177dff', N'Neco', N'Neco')
GO
INSERT [dbo].[examtype] ([id], [type], [description]) VALUES (N'f9b6812f-8cfe-4186-8f55-846aea4568e3', N'Nabtech', N'Nabtech')
GO
INSERT [dbo].[examyear] ([id], [year], [description]) VALUES (N'040b40a4-b392-453a-9119-5e82b735b225', N'1992-01-01', N'1992')
GO
INSERT [dbo].[examyear] ([id], [year], [description]) VALUES (N'66d03310-321a-46c6-943e-81c81f4dbd44', N'1991-01-02', N'1991')
GO
INSERT [dbo].[examyear] ([id], [year], [description]) VALUES (N'9d4d21a6-a793-4030-836b-6a6cc133cd2f', N'1993-01-01', N'1993')
GO
INSERT [dbo].[F_settings] ([id], [examyearid], [examtypeid], [amount], [per_discount]) VALUES (N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'42f7d38b-6de3-4381-bbb2-c917199cb1e5', N'1000', N'10')
GO
INSERT [dbo].[F_settings] ([id], [examyearid], [examtypeid], [amount], [per_discount]) VALUES (N'23240184-5f95-4589-9385-e92c62b52033', N'9d4d21a6-a793-4030-836b-6a6cc133cd2f', N'c7b83bd0-bcc0-4b62-b882-6fad0d177dff', N'1000', N'10')
GO
INSERT [dbo].[F_settings] ([id], [examyearid], [examtypeid], [amount], [per_discount]) VALUES (N'9302232f-c82b-4d7a-b675-cf9f81380ac8', N'040b40a4-b392-453a-9119-5e82b735b225', N'0f4c46b9-7c9f-407a-8a8f-aaf609881f1c', N'1000', N'10')
GO
INSERT [dbo].[F_settings] ([id], [examyearid], [examtypeid], [amount], [per_discount]) VALUES (N'd72fc4a2-2f35-4d3e-a5ba-4bafa30cb145', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'5e9c4b5a-a42b-46a0-bfd5-ad8c0cffde36', N'1000', N'10')
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'1e687e54-d6ad-4ee4-bc78-5dd653a5522f', N'23240184-5f95-4589-9385-e92c62b52033', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-10-03T15:52:12.873' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-01-06' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'20255315-0d78-4a25-84cd-1773bf582bf3', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-14T19:04:02.120' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-14' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'283dd59b-b075-410f-94b5-45cafc3a5c0e', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T10:51:52.130' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'5a7b4449-184a-4949-a6c2-88df9ac461f9', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T11:09:03.637' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'6eac3647-3bd8-4b90-86d9-18be727aaca4', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T11:13:03.373' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'70227ba4-2f4f-423f-9910-c86e11e1aa47', N'23240184-5f95-4589-9385-e92c62b52033', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-10-09T09:01:01.633' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-10-06' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'7568af97-1cda-42ad-9462-f91a28d5632b', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-06T10:43:00.703' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-10-06' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'7bfd5950-9023-400e-8191-4485a9609cda', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T11:11:02.710' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'869677ea-50cd-4b46-84c7-c2161597e818', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-15T12:00:03.187' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-15' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'98cc1224-677d-4034-a5b3-7b21b182a068', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-06T11:05:14.247' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-06' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'af8a4390-6184-4e51-af5f-22dbb5a3ad0e', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T10:48:38.033' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'b001011d-be32-4460-b5f6-985be01b5b2d', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T10:56:46.393' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'b4ea1762-a9ea-4462-8c0a-e18a87e78340', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T10:49:51.027' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'd39d63f4-46b0-4e2c-a122-9de6f546277a', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-15T17:05:48.410' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-15' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'e49bd0a1-3c8c-45f6-81d2-80f7640ae538', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T10:49:44.573' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[initializepayment] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate]) VALUES (N'e7da5064-0052-4359-99b4-31ccecd0f624', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Admin', NULL, N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-20T11:34:19.020' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-11-20' AS Date))
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'1955abb9-8686-43a7-90af-c1e86dec5481', N'23240184-5f95-4589-9385-e92c62b52033', N'Admin', NULL, N'teacher@yason.com', N'325DC503', N'07060601330', CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-09-27T13:44:18.413' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-01-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'20255315-0d78-4a25-84cd-1773bf582bf3', NULL, N'admin@gmail.com', N'20255315-0d78-4a25-84cd-1773bf582bf3', N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-14T19:04:20.663' AS DateTime), N'success', N'Ref No: 20255315-0d78-4a25-84cd-1773bf582bf3 Gateway_ref: 20255315-0d78-4a25-84cd-1773bf582bf3 currency: NGN', N'20255315-0d78-4a25-84cd-1773bf582bf3', N'ONLINE', NULL, CAST(N'2023-11-14' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'51db4db0-8331-4a87-99a1-b6c1c384c652', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'English', NULL, N'admin@gmail.com', N'325DC503', N'07098765328', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-09-28T09:49:18.357' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-10-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'70227ba4-2f4f-423f-9910-c86e11e1aa47', N'23240184-5f95-4589-9385-e92c62b52033', N'admin@gmail.com', N'70227ba4-2f4f-423f-9910-c86e11e1aa47', N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-10-09T09:02:28.577' AS DateTime), N'success', N'Ref No: 70227ba4-2f4f-423f-9910-c86e11e1aa47 Gateway_ref: 70227ba4-2f4f-423f-9910-c86e11e1aa47 currency: NGN', N'70227ba4-2f4f-423f-9910-c86e11e1aa47', N'ONLINE', NULL, CAST(N'2023-11-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'733c204a-df3e-4050-8407-0ddb3f6039f4', N'1745ef23-2e16-4d58-a0ad-5076fcd76595', N'Yusuf', NULL, N'admin@gmail.com', N'325DC503', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-09-28T09:46:35.533' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-02-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'75744950-5402-4c92-a2a9-cebcc89a9863', N'23240184-5f95-4589-9385-e92c62b52033', N'Admin', NULL, N'admin@gmail.com', N'325DC503', N'07060601330', CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-09-28T11:45:45.177' AS DateTime), N'PENDING', NULL, NULL, NULL, NULL, CAST(N'2023-03-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'98cc1224-677d-4034-a5b3-7b21b182a068', N'23240184-5f95-4589-9385-e92c62b52033', N'admin@gmail.com', N'98cc1224-677d-4034-a5b3-7b21b182a068', N'admin@gmail.com', N'609ADD58', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-06T11:05:34.123' AS DateTime), N'success', N'Ref No: 98cc1224-677d-4034-a5b3-7b21b182a068 Gateway_ref: 98cc1224-677d-4034-a5b3-7b21b182a068 currency: NGN', N'98cc1224-677d-4034-a5b3-7b21b182a068', N'ONLINE', NULL, CAST(N'2023-04-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'ac4f1835-eee3-436b-b0e6-bfda61efb80d', N'9302232f-c82b-4d7a-b675-cf9f81380ac8', N'Admin', NULL, N'admin@gmail.com', N'325DC503', N'07060601330', CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-09-28T11:42:05.287' AS DateTime), N'success', NULL, NULL, NULL, NULL, CAST(N'2023-05-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[payments] ([id], [feeid], [name], [trxid], [email], [userid], [phone], [amount], [tenxdate], [status], [notes], [gatewayref], [ptype], [insertuser], [insertdate], [examtype], [examyear]) VALUES (N'ad99fd5b-2462-4707-9136-bc734da6a968', N'23240184-5f95-4589-9385-e92c62b52033', N'Admin', NULL, N'admin@gmail.com', N'325DC503', N'07060601330', CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-10-03T14:38:40.477' AS DateTime), N'success', NULL, NULL, NULL, NULL, CAST(N'2023-06-06' AS Date), NULL, NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'257a59fe-9fd5-49ce-98c6-a530ddc4fc70', N' document 001', N' document 001', N'591de8f1-2d6f-4f42-99f1-28079cc9bd0a', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'f9b6812f-8cfe-4186-8f55-846aea4568e3', CAST(N'2023-10-10' AS Date), NULL, CAST(N'0001-01-01' AS Date), N'True', N'/UploadedFiles/Files//Dornier PRD - Sheet1.pdf', NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'33e61c19-2fc6-4560-8927-fe0f25bee7e8', N'Testing', N'', N'93d57771-1aae-4ef3-82ca-907ba5a8515c', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'5e9c4b5a-a42b-46a0-bfd5-ad8c0cffde36', CAST(N'2023-10-10' AS Date), NULL, CAST(N'0001-01-01' AS Date), N'True', N'/UploadedFiles/Files//PS.txt', NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'3491a851-d669-481a-b0a0-28655b274dc9', N'Remove document ', N'Remove document ', N'93d57771-1aae-4ef3-82ca-907ba5a8515c', N'9d4d21a6-a793-4030-836b-6a6cc133cd2f', N'0f4c46b9-7c9f-407a-8a8f-aaf609881f1c', CAST(N'2023-10-10' AS Date), NULL, CAST(N'0001-01-01' AS Date), N'True', N'/UploadedFiles/Files//Dornier PRD - Sheet1.pdf', NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'5392a65a-09f3-43d7-9c59-fedbdf3abed9', N'Biology 001', N'Biology 001', N'93d57771-1aae-4ef3-82ca-907ba5a8515c', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'c7b83bd0-bcc0-4b62-b882-6fad0d177dff', CAST(N'2023-09-13' AS Date), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'73ead59b-12c0-430b-91da-a4f3525799e8', N'english 001', N'e', N'591de8f1-2d6f-4f42-99f1-28079cc9bd0a', N'040b40a4-b392-453a-9119-5e82b735b225', N'c7b83bd0-bcc0-4b62-b882-6fad0d177dff', NULL, N'73ead59b-12c0-430b-91da-a4f3525799e8.png', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'7726279e-92be-4470-8e37-fdb931ed8e6d', N'english 001', N'good', N'93d57771-1aae-4ef3-82ca-907ba5a8515c', NULL, NULL, NULL, N'logo-sm.png', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'8bd67997-aaef-4363-99f6-de60a6dfef07', N'Testing qwerty', N'f1', N'93d57771-1aae-4ef3-82ca-907ba5a8515c', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'5e9c4b5a-a42b-46a0-bfd5-ad8c0cffde36', CAST(N'2023-10-10' AS Date), NULL, CAST(N'0001-01-01' AS Date), N'True', N'/UploadedFiles/Files//Dornier PRD - Sheet1.pdf', NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'b278ccb2-9928-4414-a662-dd98c5b7f856', N'maths 001', N'maths 001', N'591de8f1-2d6f-4f42-99f1-28079cc9bd0a', N'9d4d21a6-a793-4030-836b-6a6cc133cd2f', N'5e9c4b5a-a42b-46a0-bfd5-ad8c0cffde36', CAST(N'2023-09-11' AS Date), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'da136a27-4f96-4055-8a14-418a16ed1d48', N'Remove document ', N'f1', N'93d57771-1aae-4ef3-82ca-907ba5a8515c', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'5e9c4b5a-a42b-46a0-bfd5-ad8c0cffde36', CAST(N'2023-10-10' AS Date), NULL, CAST(N'0001-01-01' AS Date), N'True', N'/UploadedFiles/Files//Dornier PRD - Sheet1.pdf', NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'f1e0c5ab-8889-42ce-9dbb-dcdb87220a49', N'maths 002', N'nab T', N'591de8f1-2d6f-4f42-99f1-28079cc9bd0a', N'66d03310-321a-46c6-943e-81c81f4dbd44', N'f9b6812f-8cfe-4186-8f55-846aea4568e3', CAST(N'2023-09-12' AS Date), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[questions] ([id], [names], [description], [subjectid], [examyearid], [examtypeid], [insertdate], [photo], [expdate], [status], [url], [doctype]) VALUES (N'f337b5a5-232c-43f4-bbd4-fd8c6314d5c7', N'maths 001', N'maths', N'591de8f1-2d6f-4f42-99f1-28079cc9bd0a', N'040b40a4-b392-453a-9119-5e82b735b225', N'0f4c46b9-7c9f-407a-8a8f-aaf609881f1c', CAST(N'2023-09-13' AS Date), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[subjects] ([id], [name], [description]) VALUES (N'591de8f1-2d6f-4f42-99f1-28079cc9bd0a', N'Mathematics', N'maths')
GO
INSERT [dbo].[subjects] ([id], [name], [description]) VALUES (N'93d57771-1aae-4ef3-82ca-907ba5a8515c', N'English', N'Language')
GO
INSERT [dbo].[useraccounts] ([id], [name], [phone], [address], [email], [password], [insertdate], [usertype]) VALUES (N'325DC503', N'Yusuf', N'07060601330', N'admin @ Home', N'user@gmail.com', N'240u0HKuQlMH2bEJymBRwg==', CAST(N'2023-08-26T14:45:32.630' AS DateTime), N'USER')
GO
INSERT [dbo].[useraccounts] ([id], [name], [phone], [address], [email], [password], [insertdate], [usertype]) VALUES (N'609ADD58', N'Admin', N'07060601330', N'admin @ Home', N'admin@gmail.com', N'240u0HKuQlMH2bEJymBRwg==', CAST(N'2023-08-26T14:44:26.273' AS DateTime), N'ADMIN')
GO
ALTER TABLE [dbo].[B_booking] ADD  CONSTRAINT [DF_B_booking_tenxdate]  DEFAULT (getdate()) FOR [tenxdate]
GO
ALTER TABLE [dbo].[B_booking] ADD  CONSTRAINT [DF_B_booking_status_2]  DEFAULT (getdate()) FOR [status]
GO
ALTER TABLE [dbo].[B_booking] ADD  CONSTRAINT [DF_B_booking_insertdate_2]  DEFAULT (getdate()) FOR [insertdate]
GO
ALTER TABLE [dbo].[initializepayment] ADD  CONSTRAINT [DF_initializepayment_tenxdate]  DEFAULT (getdate()) FOR [tenxdate]
GO
ALTER TABLE [dbo].[payments] ADD  CONSTRAINT [DF_payments_tenxdate_1]  DEFAULT (getdate()) FOR [tenxdate]
GO
ALTER TABLE [dbo].[questions] ADD  CONSTRAINT [DF_questions_insertdate]  DEFAULT (getdate()) FOR [insertdate]
GO
ALTER TABLE [dbo].[useraccounts] ADD  CONSTRAINT [DF_useraccounts_insertdate]  DEFAULT (getdate()) FOR [insertdate]
GO
ALTER TABLE [dbo].[F_settings]  WITH CHECK ADD  CONSTRAINT [FK_F_settings_examtype] FOREIGN KEY([examtypeid])
REFERENCES [dbo].[examtype] ([id])
GO
ALTER TABLE [dbo].[F_settings] CHECK CONSTRAINT [FK_F_settings_examtype]
GO
ALTER TABLE [dbo].[F_settings]  WITH CHECK ADD  CONSTRAINT [FK_F_settings_examyear] FOREIGN KEY([examyearid])
REFERENCES [dbo].[examyear] ([id])
GO
ALTER TABLE [dbo].[F_settings] CHECK CONSTRAINT [FK_F_settings_examyear]
GO
ALTER TABLE [dbo].[payments]  WITH CHECK ADD  CONSTRAINT [FK_payments_F_settings] FOREIGN KEY([feeid])
REFERENCES [dbo].[F_settings] ([id])
GO
ALTER TABLE [dbo].[payments] CHECK CONSTRAINT [FK_payments_F_settings]
GO
ALTER TABLE [dbo].[payments]  WITH CHECK ADD  CONSTRAINT [FK_payments_useraccounts] FOREIGN KEY([userid])
REFERENCES [dbo].[useraccounts] ([id])
GO
ALTER TABLE [dbo].[payments] CHECK CONSTRAINT [FK_payments_useraccounts]
GO
ALTER TABLE [dbo].[questions]  WITH CHECK ADD  CONSTRAINT [FK_questions_examtype] FOREIGN KEY([examtypeid])
REFERENCES [dbo].[examtype] ([id])
GO
ALTER TABLE [dbo].[questions] CHECK CONSTRAINT [FK_questions_examtype]
GO
ALTER TABLE [dbo].[questions]  WITH CHECK ADD  CONSTRAINT [FK_questions_examyear] FOREIGN KEY([examyearid])
REFERENCES [dbo].[examyear] ([id])
GO
ALTER TABLE [dbo].[questions] CHECK CONSTRAINT [FK_questions_examyear]
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
