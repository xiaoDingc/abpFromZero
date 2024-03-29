USE [PoemNew]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2019/11/14 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryPoem]    Script Date: 2019/11/14 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryPoem](
	[CategoryPoem] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PeomId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryPoem] PRIMARY KEY CLUSTERED 
(
	[CategoryPoem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Poem]    Script Date: 2019/11/14 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poem](
	[PoemId] [int] IDENTITY(1,1) NOT NULL,
	[PoetId] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Content] [nvarchar](50) NULL,
	[Volumn] [nvarchar](50) NULL,
	[Num] [nvarchar](50) NULL,
 CONSTRAINT [PK_Poem] PRIMARY KEY CLUSTERED 
(
	[PoemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Poet]    Script Date: 2019/11/14 16:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poet](
	[PoetID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Poet] PRIMARY KEY CLUSTERED 
(
	[PoetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'cateName1')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'cateName2')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[CategoryPoem] ON 

INSERT [dbo].[CategoryPoem] ([CategoryPoem], [CategoryId], [PeomId]) VALUES (1, 1, 1)
INSERT [dbo].[CategoryPoem] ([CategoryPoem], [CategoryId], [PeomId]) VALUES (3, 2, 1)
SET IDENTITY_INSERT [dbo].[CategoryPoem] OFF
SET IDENTITY_INSERT [dbo].[Poem] ON 

INSERT [dbo].[Poem] ([PoemId], [PoetId], [Title], [Content], [Volumn], [Num]) VALUES (1, 1, N'mybook', N'good', N'12', N'2')
SET IDENTITY_INSERT [dbo].[Poem] OFF
SET IDENTITY_INSERT [dbo].[Poet] ON 

INSERT [dbo].[Poet] ([PoetID], [Name], [Description]) VALUES (1, N'test', N'test')
INSERT [dbo].[Poet] ([PoetID], [Name], [Description]) VALUES (2, N'张三', N'hha')
SET IDENTITY_INSERT [dbo].[Poet] OFF
ALTER TABLE [dbo].[CategoryPoem]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPoem_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[CategoryPoem] CHECK CONSTRAINT [FK_CategoryPoem_Category]
GO
ALTER TABLE [dbo].[CategoryPoem]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPoem_Poem] FOREIGN KEY([PeomId])
REFERENCES [dbo].[Poem] ([PoemId])
GO
ALTER TABLE [dbo].[CategoryPoem] CHECK CONSTRAINT [FK_CategoryPoem_Poem]
GO
ALTER TABLE [dbo].[Poem]  WITH CHECK ADD  CONSTRAINT [FK_Poem_Poem] FOREIGN KEY([PoetId])
REFERENCES [dbo].[Poet] ([PoetID])
GO
ALTER TABLE [dbo].[Poem] CHECK CONSTRAINT [FK_Poem_Poem]
GO
