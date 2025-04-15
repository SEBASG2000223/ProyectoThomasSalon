CREATE TABLE [dbo].[DETALLE_SERVICIOS_VENTAS] (
    [IdDetalleServicio] UNIQUEIDENTIFIER NOT NULL,
    [IdVenta]           UNIQUEIDENTIFIER NOT NULL,
    [IdServicio]        INT              NOT NULL,
    [Precio]            DECIMAL (10, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDetalleServicio] ASC),
    CONSTRAINT [FK_DetalleServicio_Servicio] FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[SERVICIOS] ([IdServicio]),
    CONSTRAINT [FK_DetalleServicio_Venta] FOREIGN KEY ([IdVenta]) REFERENCES [dbo].[VENTAS] ([IdVenta])
);

