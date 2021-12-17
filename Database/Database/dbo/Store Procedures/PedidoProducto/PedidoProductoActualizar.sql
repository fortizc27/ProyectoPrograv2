CREATE PROCEDURE [dbo].[PedidoProductoActualizar]
	
	@IdPedidoProducto INT,
	@IdPedido INT,
	@IdProducto INT,
	@Cantidad INT,
	@PrecioUnitario INT
	
AS BEGIN

	SET NOCOUNT ON
	BEGIN TRANSACTION TRANS
		BEGIN TRY 
			
			UPDATE [dbo].[PedidoProducto]
			SET IdPedido = @IdPedido
				,IdProducto = @IdProducto
				,Cantidad = @Cantidad
				,PrecioUnitario = @PrecioUnitario
				,Total = @Cantidad * @PrecioUnitario --Total 
			WHERE IdPedidoProducto = @IdPedidoProducto
			
			COMMIT TRANSACTION TRANS
			SELECT 0 AS CodeError, '' AS MsgError

		END TRY

		BEGIN CATCH
			
			SELECT   ERROR_NUMBER() AS CodeError
					,ERROR_MESSAGE() AS MsgError
		
			ROLLBACK TRANSACTION TRANS

		END CATCH
END
GO


