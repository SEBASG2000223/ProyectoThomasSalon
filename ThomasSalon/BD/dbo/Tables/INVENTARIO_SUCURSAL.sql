CREATE TABLE [dbo].[INVENTARIO_SUCURSAL] (
    [IdInventarioSucursal] UNIQUEIDENTIFIER NOT NULL,
    [IdSucursal]           INT              NOT NULL,
    [IdProducto]           INT              NOT NULL,
    [Cantidad]             INT              NOT NULL,
    [IdEstado]             INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([IdInventarioSucursal] ASC),
    CONSTRAINT [FK_IdEstado_Inventario_Sucursal] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado]),
    CONSTRAINT [FK_IdProducto_Inventario_Sucursal] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[PRODUCTOS] ([IdProducto]),
    CONSTRAINT [FK_IdSucursal_Inventario_Sucursal] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[SUCURSALES] ([IdSucursal])
);

