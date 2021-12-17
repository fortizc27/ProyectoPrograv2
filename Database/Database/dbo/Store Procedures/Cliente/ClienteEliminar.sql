CREATE PROCEDURE [dbo].[ClienteEliminar]
    
	@IdCliente INT

AS BEGIN
  
	SET NOCOUNT ON

	--BEGIN TRANSACTION TRANS
	
		--IF EXISTS (SELECT COUNT(*) FROM [dbo].[Pedido] AS P WHERE P.IdCliente = @IdCliente)  
			
		--	SELECT -1 AS CodeError, 'El cliente realizo un pedido no se puede eliminar al cliente' AS MsgError
			

		--ELSE	

			--BEGIN TRY 
			
				DELETE FROM [dbo].[Cliente]
				WHERE IdCliente = @IdCliente
			
				COMMIT TRANSACTION TRANS
				SELECT 0 AS CodeError, '' AS MsgError

			----END TRY

			----BEGIN CATCH
			
			--	SELECT   ERROR_NUMBER() AS CodeError
			--			,ERROR_MESSAGE() AS MsgError
		
			--	ROLLBACK TRANSACTION TRANS

			--END CATCH

		END	--IF STATEMENT END
--END