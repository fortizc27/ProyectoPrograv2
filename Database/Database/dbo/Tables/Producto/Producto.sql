CREATE TABLE [dbo].[Producto]
(
	[IdProducto]  INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_ProductoId PRIMARY KEY CLUSTERED([IdProducto]),
    [IdCategoria] INT NOT NULL CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY ([IdCategoria]) REFERENCES dbo.Categoria([IdCategoria]),
    [Nombre] VARCHAR(250) NOT NULL,
    [Cantidad] INT NOT NULL, 
    [Caracteristicas] VARCHAR(250) NOT NULL,
    [Precio] INT NOT NULL,
    [Estado] BIT NOT NULL
) WITH (DATA_COMPRESSION = PAGE)
GO
