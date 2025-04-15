CREATE TABLE [dbo].[DETALLE_PRODUCTOS_VENTAS] (
    [IdDetalleProducto] UNIQUEIDENTIFIER NOT NULL,
    [IdVenta]           UNIQUEIDENTIFIER NOT NULL,
    [IdProducto]        INT              NOT NULL,
    [Cantidad]          INT              NOT NULL,
    [PrecioUnitario]    DECIMAL (10, 2)  NOT NULL,
    [Subtotal]          DECIMAL (10, 2)  NOT NULL,
    [Comision]          AS               (case when [PrecioUnitario]>(20000) then (2000) when [PrecioUnitario]>(10000) then (1000) else (500) end) PERSISTED NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDetalleProducto] ASC),
    CONSTRAINT [FK_DetalleProducto_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[PRODUCTOS] ([IdProducto]),
    CONSTRAINT [FK_DetalleProducto_Venta] FOREIGN KEY ([IdVenta]) REFERENCES [dbo].[VENTAS] ([IdVenta])
);

