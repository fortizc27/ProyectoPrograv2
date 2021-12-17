CREATE TABLE [dbo].[Cliente]
(
	[IdCliente] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_ClienteId PRIMARY KEY CLUSTERED([IdCliente]),
    [NombreCliente] VARCHAR(50) NOT NULL,
	[PrimerApellidoCliente] VARCHAR(50) NOT NULL,
	[SegundoApellidoCliente] VARCHAR(50) NOT NULL,
	[DireccionCliente] VARCHAR(250) NOT NULL,
	[FechaDeNacimientoCliente] DATETIME NOT NULL,
	[TelefonoCliente] VARCHAR(250) NOT NULL,
	[CedulaCliente] VARCHAR(250) NOT NULL CONSTRAINT UC_Cliente UNIQUE(CedulaCliente)
) WITH (DATA_COMPRESSION = PAGE)
GO