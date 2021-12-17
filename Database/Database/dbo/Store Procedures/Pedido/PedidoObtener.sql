CREATE PROCEDURE [dbo].[PedidoObtener]

	@IdPedido INT = NULL

AS BEGIN

	SET NOCOUNT ON
	
	SELECT	PE.IdPedido,
			PE.IdCliente,
			PE.Codigo,
			PE.Fecha,
			PE.SubTotal,
			PE.IVA,
			PE.Total,

			C.IdCliente,
			C.NombreCliente,
			C.PrimerAPEllidoCliente,
			C.SegundoAPEllidoCliente,
			C.TelefonoCliente,

			PR.IdProducto,
			PR.Nombre,
			PR.Precio
			
	FROM [dbo].[Pedido] PE
	LEFT JOIN dbo.Cliente C
	ON PE.IdCliente = C.IdCliente
	LEFT JOIN dbo.Producto PR
	ON PE.IdProducto = PR.IdProducto
	WHERE (@IdPedido IS NULL OR IdPedido = @IdPedido)
END
