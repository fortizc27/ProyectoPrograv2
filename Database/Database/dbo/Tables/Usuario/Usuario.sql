CREATE TABLE [dbo].[Usuario]
(
	[Usuario] VARCHAR(10) NOT NULL PRIMARY KEY, 
    [Nombre] VARCHAR(250) NOT NULL, 
    [Clave] VARBINARY(MAX) NOT NULL, 
    [Rol_id] INT NOT NULL CONSTRAINT FK_Usuario_Rol FOREIGN KEY(Rol_id) REFERENCES dbo.Rol(Rol_id), 
    [Estado] INT NOT NULL
)
