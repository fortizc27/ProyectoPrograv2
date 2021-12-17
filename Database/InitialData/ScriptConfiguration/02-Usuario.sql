DROP TABLE IF EXISTS #UsuarioTemp

SELECT 
Usuario, Nombre, Clave, Estado, Rol_id INTO #UsuarioTemp
FROM (
VALUES
('admin', 'Administrador',ENCRYPTBYPASSPHRASE('password', 'admin'),1,1)
) AS TEMP (Usuario, Nombre, Clave, Estado, Rol_id);

----ACTUALIZAR DATOS---
UPDATE P SET
  P.Usuario = TM.Usuario,
  P.Nombre = TM.Nombre,
  P.Clave = TM.Clave,
  P.Estado = TM.Estado,
  P.Rol_id = TM.Rol_id
FROM Usuario P
INNER JOIN #UsuarioTemp TM
    ON P.Usuario = TM.Usuario;


----INSERTAR DATOS---

INSERT INTO Usuario (
Usuario, Nombre, Clave, Estado, Rol_id)
SELECT
Usuario, Nombre, Clave, Estado, Rol_id
FROM #UsuarioTemp
EXCEPT
SELECT
Usuario, Nombre, Clave, Estado, Rol_id
FROM Usuario;

GO