CREATE TABLE [dbo].[Pedido]
(
	[IdPedido] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_PedidoId PRIMARY KEY CLUSTERED([IdPedido]),
    [IdCliente] INT NOT NULL CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES dbo.Cliente([IdCliente]),
	[IdProducto] INT NOT NULL CONSTRAINT [FK_Pedido_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES dbo.Producto([IdProducto]),
	[Codigo] NVARCHAR(200) NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[Cantidad] INT NOT NULL,
	[PrecioUnitario] INT NOT NULL,
	[Envio] INT NOT NULL,
	[SubTotal] INT NOT NULL,
	[IVA] DECIMAL(18, 2) NOT NULL,
    [Total] DECIMAL(18, 2) NOT NULL
) WITH (DATA_COMPRESSION = PAGE)
GO

