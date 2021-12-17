CREATE PROCEDURE [dbo].[ProductoObtener]
	@IdProducto int=NULL
AS BEGIN
SET NOCOUNT ON
	SELECT
		P.IdProducto,
		P.Nombre,
		P.Cantidad,
		P.Caracteristicas,
		P.Precio,
		P.Estado,

		
		C.IdCategoria,
		C.NombreCategoria

	FROM dbo.Producto P 
	LEFT JOIN dbo.Categoria C
	ON P.IdProducto= C.IdCategoria
	WHERE
		(@IdProducto IS NULL OR IdProducto=@IdProducto)
END
GO
