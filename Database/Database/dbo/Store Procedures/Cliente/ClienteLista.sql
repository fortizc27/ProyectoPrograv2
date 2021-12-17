CREATE PROCEDURE [dbo].[ClienteLista]
AS BEGIN

	SET NOCOUNT ON

	SELECT IdCliente
		   ,NombreCliente
		   ,PrimerApellidoCliente
		   ,SegundoApellidoCliente
		   TelefonoCliente
	FROM [dbo].[Cliente]
END