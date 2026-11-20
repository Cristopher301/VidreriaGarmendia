-- Ejecutar en Azure Portal > bdvidreria > Query editor
-- Servidor: adminvidreria | Base de datos: bdvidreria

IF OBJECT_ID('dbo.Contactos', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Contactos
    (
        Id            INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Contactos PRIMARY KEY,
        Nombre        VARCHAR(100)  NOT NULL,
        Correo        VARCHAR(150)  NOT NULL,
        Telefono      VARCHAR(30)   NULL,
        Mensaje       VARCHAR(MAX)  NOT NULL,
        FechaRegistro DATETIME      NOT NULL CONSTRAINT DF_Contactos_Fecha DEFAULT (GETDATE())
    );
END
GO

-- Verificar
SELECT * FROM dbo.Contactos;
