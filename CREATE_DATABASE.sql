USE [database1]
GO

/****** Object:  Table [dbo].[SortedNumbers]    Script Date: 09/11/2023 18:09:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SortedNumbers](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[sorted_array] [varchar](max) NOT NULL,
	[sort_direction] [smallint] NOT NULL,
	[time_taken] [bigint] NULL,
	[is_sorted] [bit] NOT NULL,
 CONSTRAINT [PK_SortedNumbers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SortedNumbers] ADD  CONSTRAINT [DF_SortedNumbers_time_taken]  DEFAULT ((0)) FOR [time_taken]
GO

ALTER TABLE [dbo].[SortedNumbers] ADD  CONSTRAINT [DF_SortedNumbers_is_sorted]  DEFAULT ((0)) FOR [is_sorted]
GO


