CREATE TABLE [dbo].[PROVEEDORES] (
    [IdProveedor] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)  NOT NULL,
    [Descripcion] VARCHAR (100) NOT NULL,
    [Telefono]    VARCHAR (15)  NOT NULL,
    [Direccion]   VARCHAR (50)  NOT NULL,
    [IdEstado]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdProveedor] ASC),
    CONSTRAINT [FK_IdEstado_Proveedores] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado])
);

