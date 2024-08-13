USE [LibraryDB]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/1/2024 2:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[PublishDateUtc] [datetime] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/1/2024 2:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/1/2024 2:29:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([Id], [CategoryId], [Title], [Description], [PublishDateUtc]) VALUES (1, N'a376d52d-6d4e-4d19-94b1-87fb00c8c849', N'Boolean War', N'Epsom Lorem', CAST(N'2024-01-31T20:29:09.170' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'a376d52d-6d4e-4d19-94b1-87fb00c8c849', N'Action')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'f1945a20-8ded-4a0c-88ec-9118a7b72360', N'Romance')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'5946ba4e-5bc6-48e6-bdb2-99defc58565e', N'Fantasy')
GO
INSERT [dbo].[Category] ([Id], [Name]) VALUES (N'ba40b5d6-d428-4684-b439-bba76947260b', N'Drama')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password]) VALUES (1, N'admin', N'admin123')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
