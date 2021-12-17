/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\ScriptConfiguration\01-Rol.sql
:r .\ScriptConfiguration\02-Usuario.sql
:r .\ScriptConfiguration\03-Categoria.sql
:r .\ScriptConfiguration\04-Pedido.sql