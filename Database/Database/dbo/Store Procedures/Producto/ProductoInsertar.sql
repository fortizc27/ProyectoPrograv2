CREATE PROCEDURE [dbo].[ProductoInsertar]      
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
			
			INSERT INTO [dbo].[Producto]
			(
				 IdCategoria
				,Nombre
				,Cantidad
				,Caracteristicas
				,Precio
				,Estado
			)
			VALUES
			(
				 @IdCategoria
				,@Nombre
				,@Cantidad
				,@Caracteristicas
				,@Precio
				,@Estado
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
