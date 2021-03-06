USE [TeCASDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/01/2022 11:03:24 a. m. ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 28/01/2022 11:03:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [uniqueidentifier] NOT NULL,
	[CreateById] [nvarchar](max) NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[NoAccount] [varchar](16) NOT NULL,
	[TypeAccount] [int] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 28/01/2022 11:03:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[CreateById] [nvarchar](max) NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[FullName] [varchar](45) NOT NULL,
	[INE] [varchar](13) NOT NULL,
	[Phone] [varchar](10) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 28/01/2022 11:03:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [uniqueidentifier] NOT NULL,
	[CreateById] [nvarchar](max) NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[CurrentBalance] [decimal](18, 2) NOT NULL,
	[MovementAmount] [decimal](18, 2) NOT NULL,
	[TypeTransaction] [int] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/01/2022 11:03:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[CreateById] [nvarchar](max) NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[FullName] [varchar](45) NOT NULL,
	[Email] [varchar](45) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[Status] [int] NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220128155849_CreateInitial', N'3.1.22')
GO
INSERT [dbo].[Accounts] ([Id], [CreateById], [CreateAt], [NoAccount], [TypeAccount], [CustomerId]) VALUES (N'4b5e0fe2-be78-4a73-fbe6-08d9e279eb90', NULL, CAST(N'2022-01-28T16:19:12.0621803' AS DateTime2), N'1', 0, N'5460b1fb-5d25-4ccd-4d74-08d9e2794366')
GO
INSERT [dbo].[Customers] ([Id], [CreateById], [CreateAt], [FullName], [INE], [Phone], [Address], [Status]) VALUES (N'5460b1fb-5d25-4ccd-4d74-08d9e2794366', NULL, CAST(N'2022-01-28T16:14:29.0000000' AS DateTime2), N'Rogelio Chavez Salinas', N'123456789', N'7441652431', N'Calle 20 #8 Col. Alta Vista', 0)
INSERT [dbo].[Customers] ([Id], [CreateById], [CreateAt], [FullName], [INE], [Phone], [Address], [Status]) VALUES (N'9143fa2f-8292-4525-b24e-08d9e27de197', NULL, CAST(N'2022-01-28T16:47:33.0000000' AS DateTime2), N'Juani Ramírez José', N'0987654321', N'7443338251', N'Col. Vacacional C.P.31210', 0)
GO
INSERT [dbo].[Transactions] ([Id], [CreateById], [CreateAt], [AccountId], [CurrentBalance], [MovementAmount], [TypeTransaction]) VALUES (N'bfa2997c-7c39-41e8-85dc-08d9e27c059e', NULL, CAST(N'2022-01-28T10:34:14.7561184' AS DateTime2), N'4b5e0fe2-be78-4a73-fbe6-08d9e279eb90', CAST(150.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Transactions] ([Id], [CreateById], [CreateAt], [AccountId], [CurrentBalance], [MovementAmount], [TypeTransaction]) VALUES (N'e58e3d8a-b721-432b-52fc-08d9e27d135e', NULL, CAST(N'2022-01-28T10:41:47.3237895' AS DateTime2), N'4b5e0fe2-be78-4a73-fbe6-08d9e279eb90', CAST(100.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Transactions] ([Id], [CreateById], [CreateAt], [AccountId], [CurrentBalance], [MovementAmount], [TypeTransaction]) VALUES (N'be410772-94af-46ad-52fd-08d9e27d135e', NULL, CAST(N'2022-01-28T10:42:10.5627482' AS DateTime2), N'4b5e0fe2-be78-4a73-fbe6-08d9e279eb90', CAST(300.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), 0)
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Account_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Account_Customer]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transaction_Account]
GO
