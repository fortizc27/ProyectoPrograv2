CREATE PROCEDURE [dbo].[ProductoActualizar]
	@IdProducto INT,
	@IdCategoria INT,
	@Nombre VARCHAR(250),
	@Cantidad INT,
	@Caracteristicas VARCHAR(250),
	@Precio INT,
	@Estado BIT

AS BEGIN
  
	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			UPDATE [dbo].[Producto]
			SET  IdCategoria=@IdCategoria
				,Nombre=@Nombre
				,Cantidad=@Cantidad
				,Caracteristicas=@Caracteristicas
				,Precio=@Precio
				,Estado=@Estado
			WHERE IdProducto = @IdProducto
			
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

