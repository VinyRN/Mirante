USE [Mirante_ToDo]
GO

/****** Object:  Table [dbo].[ToDoTask]    Script Date: 16/12/2025 14:59:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ToDoTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](255) NOT NULL,
	[Descricao] [nvarchar](400) NOT NULL,
	[Status] [int] NOT NULL,
	[DtVencimento] [smalldatetime] NULL,
	[DtInclusao] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ToDoTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


