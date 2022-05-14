USE [Paint]
GO

/****** Object:  Table [dbo].[PaintGroup]    Script Date: 5/13/2022 6:20:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaintGroup](
	[PaintGroupId] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[ManufacturerId] [uniqueidentifier] NULL,
	[PaintGroupName] [nvarchar](max) NULL,
	[PaintGroupDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_PaintGroup] PRIMARY KEY CLUSTERED 
(
	[PaintGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


