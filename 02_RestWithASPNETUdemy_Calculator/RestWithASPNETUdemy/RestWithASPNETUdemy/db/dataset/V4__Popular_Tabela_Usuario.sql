USE [UASP_NET]
GO

INSERT INTO [dbo].[Usuario]
           ([NOME_USUARIO]
           ,[SENHA]
           ,[NOME_COMPLETO]
           ,[TOKEN]
           ,[VALIDADE_TOKEN])
     VALUES
           ('pr'
           ,'24-0B-E5-18-FA-BD-27-24-DD-B6-F0-4E-EB-1D-A5-96-74-48-D7-E8-31-C0-8C-8F-A8-22-80-9F-74-C7-20-A9'
           ,'PAULO RICARDO '
           ,'h9lzVOoLlBoTbcQrh/e16/aIj+4p6C67lLdDbBRMsjE='
           , DATEADD(DAY,4,GETDATE()))
GO
