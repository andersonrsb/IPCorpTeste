USE [IPCorp]
GO

/****** Object:  Table [dbo].[Log]    Script Date: 22/06/2018 00:57:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Log](
	[LogSistemaId] [int] NULL,
	[Data] [datetime] NULL,
	[Origem] [varchar](max) NULL,
	[Context] [varchar](max) NULL,
	[Severidade] [varchar](max) NULL,
	[Mensagem] [varchar](max) NULL,
	[ArquivoFonte] [varchar](max) NULL,
	[MetodoFonte] [varchar](max) NULL,
	[Maquina] [varchar](max) NULL,
	[LinhaFonte] [int] NULL,
	[Propriedades] [varchar](max) NULL,
	[Excecao] [varchar](max) NULL,
	[OrigemId] [int] NULL,
	[LogContextoId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


