CREATE TABLE [dbo].[INVENTARIO_GENERAL] (
    [IdInventarioGeneral] UNIQUEIDENTIFIER NOT NULL,
    [IdProducto]          INT              NOT NULL,
    [CantidadTotal]       INT              NOT NULL,
    [IdEstado]            INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([IdInventarioGeneral] ASC),
    CONSTRAINT [FK_IdEstado_InventarioGeneral] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado]),
    CONSTRAINT [FK_IdProducto_Inventario_General] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[PRODUCTOS] ([IdProducto])
);

