CREATE PROCEDURE [dbo].[PedidoProductoInsertar]      
	@IdPedido INT,
	@IdProducto INT,
	@Cantidad INT,
	@PrecioUnitario INT
	
AS BEGIN
  
	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			INSERT INTO [dbo].[PedidoProducto]
			( 
				 IdPedido
				,IdProducto
				,Cantidad
				,PrecioUnitario
				,Total
			)
			VALUES
			(
				 @IdPedido
				,@IdProducto
				,@Cantidad
				,@PrecioUnitario
				,@Cantidad * @PrecioUnitario --Total 
			)
			
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
