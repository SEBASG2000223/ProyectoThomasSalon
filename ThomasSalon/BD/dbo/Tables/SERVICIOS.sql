CREATE TABLE [dbo].[SERVICIOS] (
    [IdServicio]      INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]          VARCHAR (100)   NOT NULL,
    [Descripcion]     VARCHAR (100)   NOT NULL,
    [LinkImagen]      VARCHAR (MAX)   NOT NULL,
    [Precio]          DECIMAL (10, 2) NOT NULL,
    [Duracion]        TIME (7)        NOT NULL,
    [IdEstado]        INT             NOT NULL,
    [IdTipoServicios] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([IdServicio] ASC),
    CONSTRAINT [FK_IdEstado_Servicios] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado]),
    CONSTRAINT [FK_IdTipoServicios_Servicios] FOREIGN KEY ([IdTipoServicios]) REFERENCES [dbo].[TIPOS_SERVICIOS] ([IdTipoServicios])
);

