CREATE PROCEDURE [dbo].[PedidoEliminar]
    
	@IdPedido INT

AS BEGIN
  
	SET NOCOUNT ON


		BEGIN TRANSACTION TRAS
		BEGIN TRY
			
			Update Pr
			set Pr.Cantidad = Pr.Cantidad + Pe.Cantidad
			from 
				[dbo].[Producto] Pr inner join
				[dbo].[Pedido] Pe
				  on Pr.IdProducto = Pe.IdProducto

			DELETE FROM [dbo].[Pedido]
			WHERE IdPedido = @IdPedido
			
			COMMIT TRANSACTION TRANS
			SELECT 0 AS CodeError, '' AS MsgError
		END TRY

		BEGIN CATCH
			SELECT
				ERROR_NUMBER() AS CodeError,
				ERROR_MESSAGE() AS MsgError
			ROLLBACK TRANSACTION TRASA
		END CATCH
END	
GO