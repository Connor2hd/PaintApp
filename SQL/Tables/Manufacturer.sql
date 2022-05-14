USE [Paint]
GO

/****** Object:  Table [dbo].[Manufacturer]    Script Date: 5/13/2022 6:21:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Manufacturer](
	[ManufacturerId] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[ManufacturerName] [nvarchar](max) NULL,
	[ManufacturerDescription] [nvarchar](max) NULL,
	[LogoImageURL] [nvarchar](max) NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ManufacturerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


