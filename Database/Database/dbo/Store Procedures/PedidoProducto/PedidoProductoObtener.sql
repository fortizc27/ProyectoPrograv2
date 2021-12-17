CREATE PROCEDURE [dbo].[PedidoProductoObtener]
	
	@IdPedido INT = NULL

AS BEGIN

	SET NOCOUNT ON
	
	SELECT PP.IdPedidoProducto,
		   PP.IdPedido,
		   PP.IdProducto,
		   PR.Nombre,
		   PP.Cantidad,
		   PP.PrecioUnitario,
		   PP.Total
	FROM [dbo].[PedidoProducto] AS PP
	LEFT JOIN [dbo].[Pedido] AS PE
	ON PP.IdPedido = PE.IdPedido
	LEFT JOIN [dbo].Producto AS PR
	ON PP.IdProducto= PR.IdProducto
	WHERE
		(@IdPedido IS NULL OR PP.IdPedido = @IdPedido)
END
GO
