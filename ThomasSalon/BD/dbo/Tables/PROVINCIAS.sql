CREATE TABLE [dbo].[PROVINCIAS] (
    [IdProvincia]   UNIQUEIDENTIFIER NOT NULL,
    [Nombre]        VARCHAR (100)    NOT NULL,
    [PrecioEntrega] DECIMAL (10, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IdProvincia] ASC)
);

