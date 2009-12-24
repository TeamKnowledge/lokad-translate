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



/*************************************** ELMAH ******************************************/

/*
 
   ELMAH - Error Logging Modules and Handlers for ASP.NET
   Copyright (c) 2004-9 Atif Aziz. All rights reserved.
 
    Author(s):
 
        Atif Aziz, http://www.raboof.com
        Phil Haacked, http://haacked.com
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
 
      http://www.apache.org/licenses/LICENSE-2.0
 
   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/

-- ELMAH DDL script for Microsoft SQL Server 2000 or later.

CREATE TABLE [dbo].[ELMAH_Error]
(
    [ErrorId]     UNIQUEIDENTIFIER NOT NULL,
    [Application] NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Host]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Type]        NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Source]      NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Message]     NVARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [User]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [StatusCode]  INT NOT NULL,
    [TimeUtc]     DATETIME NOT NULL,
    [Sequence]    INT IDENTITY (1, 1) NOT NULL,
    [AllXml]      NVARCHAR(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)

GO

ALTER TABLE [dbo].[ELMAH_Error] WITH NOCHECK ADD
    CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED ([ErrorId])
GO

ALTER TABLE [dbo].[ELMAH_Error] ADD
    CONSTRAINT [DF_ELMAH_Error_ErrorId] DEFAULT (NEWID()) FOR [ErrorId]
GO

CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error]
(
    [Application]   ASC,
    [TimeUtc]       DESC,
    [Sequence]      DESC
)
GO

/* ------------------------------------------------------------------------
        STORED PROCEDURES                                                      
   ------------------------------------------------------------------------ */

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT
        [AllXml]
    FROM
        [ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId
    AND
        [Application] = @Application

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT
        @TotalCount = COUNT(1)
    FROM
        [ELMAH_Error]
    WHERE
        [Application] = @Application

    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM
            [ELMAH_Error]
        WHERE  
            [Application] = @Application
        ORDER BY
            [TimeUtc] DESC,
            [Sequence] DESC

    END
    ELSE
    BEGIN


        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT
        errorId     = [ErrorId],
        application = [Application],
        host        = [Host],
        type        = [Type],
        source      = [Source],
        message     = [Message],
        [user]      = [User],
        statusCode  = [StatusCode],
        time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM
        [ELMAH_Error] error
    WHERE
        [Application] = @Application
    AND
        [TimeUtc] <= @FirstTimeUTC
    AND
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC,
        [Sequence] DESC
    FOR
        XML AUTO

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NVARCHAR(MAX),
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
