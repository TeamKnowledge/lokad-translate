GO
/****** Object:  Table [dbo].[Lang]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lang](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Languages_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF) 
) 
GO
/****** Object:  Table [dbo].[Feed]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feed](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Feeds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF ) 
) 
GO
/****** Object:  Table [dbo].[DbVersion]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbVersion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL
) 
GO
/****** Object:  Table [dbo].[RestRegex]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestRegex](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IsHistory] [bit] NOT NULL,
	[IsDiff] [bit] NOT NULL,
	[IsEdit] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MatchRegex] [nvarchar](255) NOT NULL,
	[ReplaceRegex] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_RestRegex] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF) 
) 
GO
/****** Object:  Table [dbo].[Page]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Url] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[IsIgnored] [bit] NOT NULL,
 CONSTRAINT [PK_Pages_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF) 
) 
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OpenId] [nvarchar](255) NOT NULL,
	[Created] [datetime] NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[IsManager] [bit] NOT NULL,
	[Code] [nvarchar](10) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF) 
) 
GO
/****** Object:  Table [dbo].[UpdateBatch]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpdateBatch](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[User_id] [bigint] NOT NULL,
	[WordCount] [int] NOT NULL,
	[IsPaid] [bit] NOT NULL,
 CONSTRAINT [PK_UpdateBatch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF) 
) 
GO
/****** Object:  Table [dbo].[Update]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Update](
	[Mapping_id] [bigint] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Version] [nvarchar](50) NOT NULL,
	[WordCount] [int] NOT NULL,
	[User_id] [bigint] NOT NULL,
	[UpdateBatch_id] [bigint] NULL,
 CONSTRAINT [PK_Updates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF) 
) 
GO
/****** Object:  Table [dbo].[Mapping]    Script Date: 11/29/2009 11:32:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mapping](
	[Page_id] [bigint] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[DestinationUrl] [nvarchar](255) NULL,
	[LastUpdated] [datetime] NOT NULL,
	[Version] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mappings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH ( STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF) 
) 
GO
/****** Object:  Default [DF_Version_Created]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[DbVersion] ADD  CONSTRAINT [DF_Version_Created]  DEFAULT (getutcdate()) FOR [Created]
GO
/****** Object:  Default [DF_Feed_Created]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[Feed] ADD  CONSTRAINT [DF_Feed_Created]  DEFAULT (getutcdate()) FOR [Created]
GO
/****** Object:  Default [DF_Mappings_Created]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[Mapping] ADD  CONSTRAINT [DF_Mappings_Created]  DEFAULT (getutcdate()) FOR [Created]
GO
/****** Object:  Default [DF_Pages_Created]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[Page] ADD  CONSTRAINT [DF_Pages_Created]  DEFAULT (getutcdate()) FOR [Created]
GO
/****** Object:  Default [DF_Page_IsIgnored]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[Page] ADD  CONSTRAINT [DF_Page_IsIgnored]  DEFAULT ((0)) FOR [IsIgnored]
GO
/****** Object:  Default [DF_Updates_Created]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[Update] ADD  CONSTRAINT [DF_Updates_Created]  DEFAULT (getutcdate()) FOR [Created]
GO
/****** Object:  Default [DF_UpdateBatch_IsPaid]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[UpdateBatch] ADD  CONSTRAINT [DF_UpdateBatch_IsPaid]  DEFAULT ((0)) FOR [IsPaid]
GO
/****** Object:  ForeignKey [FK_Mapping_PageId]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Mapping_PageId] FOREIGN KEY([Page_id])
REFERENCES [dbo].[Page] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mapping] CHECK CONSTRAINT [FK_Mapping_PageId]
GO
/****** Object:  ForeignKey [FK_Update_UserId]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[Update]  WITH CHECK ADD  CONSTRAINT [FK_Update_UserId] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Update] CHECK CONSTRAINT [FK_Update_UserId]
GO
/****** Object:  ForeignKey [FK_UpdateBatch_UserId]    Script Date: 11/29/2009 11:32:04 ******/
ALTER TABLE [dbo].[UpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_UpdateBatch_UserId] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UpdateBatch] CHECK CONSTRAINT [FK_UpdateBatch_UserId]
GO
