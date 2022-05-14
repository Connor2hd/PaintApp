USE [Paint]
GO

/****** Object:  Table [dbo].[Paint]    Script Date: 5/13/2022 6:19:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Paint](
	[PaintId] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[GroupId] [uniqueidentifier] NULL,
	[PaintName] [nvarchar](max) NULL,
	[PaintSize] [int] NULL,
	[StockImageURL] [nvarchar](max) NULL,
	[MSRP] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Paint] PRIMARY KEY CLUSTERED 
(
	[PaintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


