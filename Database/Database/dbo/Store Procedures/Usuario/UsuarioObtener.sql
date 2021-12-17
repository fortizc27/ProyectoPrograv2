CREATE PROCEDURE [dbo].[UsuarioObtener]
      @Usuario varchar(10) = NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
     a.Usuario,
	 a.Nombre,
     CONVERT(VARCHAR(MAX),DECRYPTBYPASSPHRASE('password', a.Clave)) Clave,
	 a.Estado,
	 b.Rol_id,
     b.Rol_Description
    FROM Usuario a
        INNER JOIN Rol b
       ON a.Rol_id= b.Rol_id
    WHERE
    (@Usuario IS NULL OR Usuario = @Usuario)

END