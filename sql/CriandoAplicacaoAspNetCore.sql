CREATE DATABASE CriandoAplicacaoAspNetCore
GO

USE CriandoAplicacaoAspNetCore

CREATE TABLE Usuario
(
    IdUsuario INT IDENTITY(1, 1) NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NULL,
    Login VARCHAR(50) NOT NULL,
    Senha VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario)
)
GO
