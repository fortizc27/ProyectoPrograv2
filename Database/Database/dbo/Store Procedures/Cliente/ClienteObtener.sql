CREATE PROCEDURE [dbo].[ClienteObtener]
      
      @IdCliente INT  = NULL

AS BEGIN
  
	SET NOCOUNT ON

	SELECT   IdCliente
			,NombreCliente
			,PrimerApellidoCliente
			,SegundoApellidoCliente
			,DireccionCliente
			,FechaDeNacimientoCliente
			,TelefonoCliente
			,CedulaCliente
	FROM [dbo].[Cliente]
	WHERE (@IdCliente IS NULL OR IdCliente = @IdCliente)

END