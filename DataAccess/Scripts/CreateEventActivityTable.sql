USE [EventSample]
GO

/****** Object:  Table [dbo].[EventActivity]    Script Date: 12/7/2016 6:29:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EventActivity](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventDate] [datetime] NULL,
	[ClassName] [varchar](100) NULL,
	[MethodName] [varchar](150) NULL,
	[EventLevel] [int] NULL,
	[ExceptionData] [varchar](500) NULL,
	[CompanyName] [varchar](100) NULL,
	[CompanyId] [int] NULL,
	[DataBlock] [nvarchar](max) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EventActivity] ADD  CONSTRAINT [DF_Table_1_EventDate]  DEFAULT (getdate()) FOR [EventDate]
GO


