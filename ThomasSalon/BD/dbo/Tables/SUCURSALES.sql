CREATE TABLE [dbo].[SUCURSALES] (
    [IdSucursal]    INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        VARCHAR (100) NOT NULL,
    [LinkDireccion] VARCHAR (MAX) NOT NULL,
    [LinkImagen]    VARCHAR (MAX) NOT NULL,
    [Telefono]      VARCHAR (15)  NULL,
    [IdEstado]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdSucursal] ASC),
    CONSTRAINT [FK_IdEstado_Sucursales] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado])
);

