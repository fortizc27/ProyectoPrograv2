﻿CREATE PROCEDURE [dbo].[PedidoInsertar]      
	@IdCliente INT,
	@IdProducto INT,
	@Codigo NVARCHAR(200),
	@Fecha datetime,
	@Cantidad INT,
	@PrecioUnitario INT,
	@Envio INT,
	@SubTotal INT,
	@IVA decimal(18,2),
	@Total decimal(18,2) 
	
AS BEGIN
  
	SET NOCOUNT ON

	declare @Existencias int
	SELECT @Existencias = Cantidad FROM Producto WHERE IdProducto = @IdProducto;

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 

			IF @Cantidad <= @Existencias
			BEGIN
				INSERT INTO [dbo].[Pedido]
				( 
					IdCliente
					,IdProducto
					,Codigo
					,Fecha
					,Cantidad
					,PrecioUnitario
					,Envio
					,SubTotal
					,IVA
					,Total
				)
				VALUES
				(
					@IdCliente
					,@IdProducto
					,@Codigo
					,@Fecha
					,@Cantidad
					,@PrecioUnitario
					,@Envio
					,(@Cantidad * @PrecioUnitario) + @Envio
					,((@Cantidad * @PrecioUnitario) + @Envio) * 0.13
					,((@Cantidad * @PrecioUnitario) + @Envio) * 1.13
				)

				Update [dbo].[Producto]
				set Cantidad = Cantidad - @Cantidad
				WHERE IdProducto = @IdProducto;
			
				COMMIT TRANSACTION TRANS
				SELECT 0 AS CodeError, '' AS MsgError
				END
				ELSE
				BEGIN
					SELECT -1 AS CodeError, 'No hay existencias suficientes' AS MsgError
				END

		END TRY

		BEGIN CATCH
			
			SELECT   ERROR_NUMBER() AS CodeError
					,ERROR_MESSAGE() AS MsgError
		
			ROLLBACK TRANSACTION TRANS

		END CATCH
END
GO
