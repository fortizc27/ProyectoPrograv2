CREATE TABLE [dbo].[PedidoProducto]
(
	[IdPedidoProducto] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_IdPedidoProducto PRIMARY KEY CLUSTERED(IdPedidoProducto), 
    [IdPedido] INT NOT NULL CONSTRAINT [FK_PedidoProducto_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES dbo.Pedido([IdPedido]),
	[IdProducto] INT NOT NULL CONSTRAINT [FK_PedidoProducto_Producto] FOREIGN KEY ([IdProducto]) REFERENCES dbo.Producto([IdProducto]),
    [Cantidad] INT NOT NULL, 
    [PrecioUnitario] INT NOT NULL, 
    [Total] INT NOT NULL
) WITH (DATA_COMPRESSION = PAGE)
GO

