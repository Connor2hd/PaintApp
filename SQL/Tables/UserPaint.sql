USE [Paint]
GO

/****** Object:  Table [dbo].[UserPaint]    Script Date: 5/13/2022 6:22:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserPaint](
	[UserPaintId] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[UserId] [uniqueidentifier] NULL,
	[PaintId] [uniqueidentifier] NULL,
	[DateCreated] [datetime] NULL DEFAULT GETDATE(),
 CONSTRAINT [PK_UserPaint] PRIMARY KEY CLUSTERED 
(
	[UserPaintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


