CREATE PROCEDURE [dbo].[UsuarioInsertar]
	@Usuario varchar(10),
	@Nombre varchar(250),
	@Clave varchar(MAX),
	@Estado bit,
	@Rol_id int

AS BEGIN
SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

    BEGIN TRY
	
	INSERT INTO Usuario
	(Usuario,
	 Nombre,
	 Clave,
	 Estado,
	 Rol_id
	)
	VALUES
	(
	@Usuario,
	@Nombre,
	ENCRYPTBYPASSPHRASE('password', @Clave),
	@Estado,
	@Rol_id
	)

  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError

  END TRY

  BEGIN CATCH

   SELECT 
         ERROR_NUMBER() AS CodeError,
		 ERROR_MESSAGE() AS MsgError
   
   ROLLBACK TRANSACTION TRASA

   END CATCH

 END