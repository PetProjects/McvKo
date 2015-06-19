USE [mvcko]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 19.06.2015 20:02:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[Id] int IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](128) NOT NULL,
	[LastName] [nchar](128) NOT NULL,
	[Age] [smallint] NOT NULL,
	[Description] [nchar](255) NULL,
	[Gender] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


