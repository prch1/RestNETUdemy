USE UASP_NET

GO

DROP TABLE IF EXISTS Livro

GO

CREATE TABLE Livro
(
  ID INT IDENTITY(1,1),
  TITULO VARCHAR(50),
  EDITORA VARCHAR(50),
  PRECO DECIMAL(10,2)
)