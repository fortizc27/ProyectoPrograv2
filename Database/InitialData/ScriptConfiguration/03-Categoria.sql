DROP TABLE IF EXISTS #CategoriaTemp

SELECT 
IdCategoria, NombreCategoria INTO #CategoriaTemp
FROM (
VALUES
(1, 'COCINA'),
(2, 'SALA'),
(3, 'COMEDOR'),
(4, 'DORMITORIO'),
(5, 'BAÑO')
)AS TEMP (IdCategoria, NombreCategoria)


----ACTUALIZAR DATOS---
UPDATE C SET
  C.NombreCategoria= TM.NombreCategoria
FROM dbo.Categoria C
INNER JOIN #CategoriaTemp TM
    ON C.IdCategoria= TM.IdCategoria


----INSERTAR DATOS---

SET IDENTITY_INSERT dbo.Categoria ON

INSERT INTO dbo.Categoria(
IdCategoria, NombreCategoria)
SELECT
IdCategoria, NombreCategoria
FROM #CategoriaTemp


EXCEPT
SELECT
IdCategoria, NombreCategoria
FROM dbo.Categoria


SET IDENTITY_INSERT dbo.Categoria OFF

GO