CREATE TABLE [dbo].[Personas] (
    [IdPersona]      INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]         NVARCHAR (100) NOT NULL,
    [Telefono]       NVARCHAR (20)  NULL,
    [Genero]         NVARCHAR (255) NULL,
    [Direccion]      NVARCHAR (255) NULL,
    [Edad]           INT            NULL,
    [Identificacion] NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IdPersona] ASC)
);

