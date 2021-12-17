CREATE PROCEDURE [dbo].[RolLista]
AS
	BEGIN
	SET NOCOUNT ON

	SELECT 
		Rol_id,
		Rol_Description
	FROM 
		Rol;

END