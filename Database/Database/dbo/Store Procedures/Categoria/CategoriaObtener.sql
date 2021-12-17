CREATE PROCEDURE [dbo].[CategoriaObtener]
	@IdCategoria int = null
AS BEGIN
  SET NOCOUNT ON

	SELECT 
		IdCategoria,
		NombreCategoria
	FROM dbo.Categoria WHERE (@IdCategoria IS NULL OR IdCategoria = @IdCategoria)

END