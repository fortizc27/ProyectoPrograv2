CREATE PROCEDURE dbo.Login
@Usuario VARCHAR(10),
@Clave VARCHAR(250)
AS 
BEGIN
	SET NOCOUNT  ON

	IF NOT EXISTS(SELECT * FROM Usuario WHERE Usuario=@Usuario) 
	BEGIN
		SELECT -1 AS CodeError, 'El nombre del usuario no existe' AS MsgError
	END
	ELSE IF EXISTS(SELECT * FROM Usuario WHERE Usuario = @Usuario AND Estado = 0) 
	BEGIN
		SELECT -1 AS CodeError, 'El Usuario se encuentra inactivo!' AS MsgError
	END
	ELSE IF  NOT EXISTS(SELECT * FROM Usuario WHERE Usuario = @Usuario and CONVERT(VARCHAR(MAX),DECRYPTBYPASSPHRASE('password', Clave)) = @Clave AND Estado =1) 
	BEGIN
		SELECT -1 AS CodeError, 'La contraseña es incorrecta por favor volver a intentar!' AS MsgError
	END
	ELSE 
	BEGIN
		SELECT 
			0 AS CodeError,
			Usuario,
			Nombre
		FROM 
			Usuario
		WHERE Usuario = @Usuario and  CONVERT(VARCHAR(MAX),DECRYPTBYPASSPHRASE('password', Clave)) = @Clave; 
	END
END