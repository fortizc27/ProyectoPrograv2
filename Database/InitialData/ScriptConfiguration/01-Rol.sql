DROP TABLE IF EXISTS #RolTemp

SELECT 
Rol_id, Rol_Description INTO #RolTemp
FROM (
VALUES
(1, 'Administrador'),
(2, 'Super Usuario'),
(3, 'Sólo Lectura')
)AS TEMP (Rol_id, Rol_Description)


----ACTUALIZAR DATOS---
UPDATE P SET
  P.Rol_id = TM.Rol_id,
  P.Rol_Description = TM.Rol_Description
FROM Rol P
INNER JOIN #RolTemp TM
    ON P.Rol_id= TM.Rol_id


----INSERTAR DATOS---

INSERT INTO Rol (
Rol_id, Rol_Description)
SELECT
Rol_id, Rol_Description
FROM #RolTemp


EXCEPT
SELECT
Rol_id, Rol_Description
FROM Rol

GO