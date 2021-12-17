CREATE PROCEDURE [dbo].[PedidoObtener]

	@IdPedido INT = NULL

AS BEGIN

	SET NOCOUNT ON
	
	SELECT	PE.IdPedido,
			PE.IdCliente,
			PE.IdProducto,
			PE.Codigo,
			PE.Fecha,
			PE.Cantidad,
			PE.PrecioUnitario,
			PE.Envio,
			PE.SubTotal,
			PE.IVA,
			PE.Total,

			C.NombreCliente + ' ' + C.PrimerAPEllidoCliente + ' ' + C.SegundoAPEllidoCliente as Clientex,
			C.TelefonoCliente as Telefono,

			PR.Nombre,
			PR.Precio
			
	FROM [dbo].[Pedido] PE
	LEFT JOIN dbo.Cliente C
	ON PE.IdCliente = C.IdCliente
	LEFT JOIN dbo.Producto PR
	ON PE.IdProducto = PR.IdProducto
	WHERE (@IdPedido IS NULL OR IdPedido = @IdPedido)
END
