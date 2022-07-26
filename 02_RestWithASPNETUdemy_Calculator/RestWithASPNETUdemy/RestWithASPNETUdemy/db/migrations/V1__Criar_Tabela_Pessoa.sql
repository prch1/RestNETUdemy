USE [UASP_NET]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pessoa]') AND type in (N'U'))
DROP TABLE [dbo].[Pessoa]
GO

CREATE TABLE [dbo].[Pessoa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PRIMEIRO_NOME] [varchar](50) NULL,
	[SOBRE_NOME] [varchar](50) NULL,
	[ENDERECO] [varchar](50) NULL,
	[GENERO] [char](2) NULL
) ON [PRIMARY]
GO
