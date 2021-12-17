CREATE PROCEDURE [dbo].[PedidoActualizar]
	@IdPedido INT,
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

	DECLARE @CantidadAnterior int
	DECLARE @Diferencia int
	DECLARE @Existencias int

	select @CantidadAnterior = Cantidad  from [dbo].[Pedido] where IdPedido = @IdPedido;
	set @Diferencia = @Cantidad - @CantidadAnterior

	select @Existencias = Cantidad  from [dbo].[Producto] where IdProducto = @IdProducto;

	BEGIN TRANSACTION TRANS
		BEGIN TRY 
			
			IF @Diferencia <= @Existencias
			BEGIN

				UPDATE [dbo].[Pedido]
				SET  IdCliente = @IdCliente
					,IdProducto = @IdProducto
					,Codigo = @Codigo
					,Fecha = @Fecha
					,Cantidad = @Cantidad
					,PrecioUnitario = @PrecioUnitario
					,Envio = @Envio
					,SubTotal = (@Cantidad * @PrecioUnitario) + @Envio
					,IVA = ((@Cantidad * @PrecioUnitario) + @Envio) * 0.13
					,Total = ((@Cantidad * @PrecioUnitario) + @Envio) * 1.13
				WHERE IdPedido = @IdPedido
			
				Update [dbo].[Producto]
				set Cantidad = Cantidad - @Diferencia
				WHERE IdProducto = @IdProducto;
			END
			ELSE
			BEGIN
				SELECT -1 AS CodeError, 'No hay existencias suficientes' AS MsgError
			END

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


