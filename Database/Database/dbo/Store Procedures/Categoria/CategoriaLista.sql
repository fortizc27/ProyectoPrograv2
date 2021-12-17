CREATE PROCEDURE [dbo].[CategoriaLista]
AS
	BEGIN
	SET NOCOUNT ON


	SELECT
	 IdCategoria,
	 NombreCategoria
	FROM dbo.Categoria

	END