CREATE PROCEDURE [dbo].[ClienteActualizar]
    
	@IdCliente INT,
	@NombreCliente VARCHAR(50),
	@PrimerApellidoCliente VARCHAR(50),
	@SegundoApellidoCliente VARCHAR(50),
	@DireccionCliente VARCHAR(250),
	@FechaDeNacimientoCliente DATETIME,
	@TelefonoCliente VARCHAR(250),
	@CedulaCliente VARCHAR(250)

AS BEGIN
  
	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			UPDATE [dbo].[Cliente]
			SET  NombreCliente = @NombreCliente
				,PrimerApellidoCliente = @PrimerApellidoCliente
				,SegundoApellidoCliente = @SegundoApellidoCliente
				,DireccionCliente = @DireccionCliente
				,FechaDeNacimientoCliente = @FechaDeNacimientoCliente
				,TelefonoCliente = @TelefonoCliente
				,CedulaCliente = @CedulaCliente
			WHERE IdCliente = @IdCliente
			
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