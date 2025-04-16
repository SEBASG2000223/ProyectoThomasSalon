CREATE TABLE [dbo].[PRODUCTOS] (
    [IdProducto]   INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (50)    NOT NULL,
    [Descripcion]  VARCHAR (100)   NOT NULL,
    [Precio]       DECIMAL (10, 2) NOT NULL,
    [IdProveedor]  INT             NOT NULL,
    [LinkImagen]   VARCHAR (MAX)   NOT NULL,
    [UnidadMedida] INT             NOT NULL,
    [IdEstado]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([IdProducto] ASC),
    CONSTRAINT [FK_IdEstado_Productos] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado]),
    CONSTRAINT [FK_IdProveedor_Productos] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[PROVEEDORES] ([IdProveedor])
);

