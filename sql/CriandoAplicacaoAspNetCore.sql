IF DB_ID('CriandoAplicacaoAspNetCore') IS NULL BEGIN
	CREATE DATABASE CriandoAplicacaoAspNetCore
END
GO

USE CriandoAplicacaoAspNetCore

IF OBJECT_ID('Usuario', 'U') IS NULL BEGIN
	CREATE TABLE Usuario
	(
		IdUsuario INT IDENTITY(1, 1) NOT NULL,
		Nome VARCHAR(100) NOT NULL,
		Email VARCHAR(150) NULL,
		Login VARCHAR(50) NOT NULL,
		Hash VARCHAR(256) NOT NULL,
		Salt VARCHAR(256) NOT NULL,
		CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario)
	)
END
GO


IF NOT EXISTS(SELECT 1 FROM Usuario WHERE Login = 'admin') BEGIN
	INSERT INTO Usuario (Nome, Login, Hash, Salt)
	VALUES ('Administrador', 'admin', 'NLAZBttBU8HbUrODUPQxViEDr1d7RMi4B/2F6yaKOrQ=', 'Nkt8krN4/TBHUJXu4zEm6A==')
END
GO
