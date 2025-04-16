CREATE TABLE [dbo].[REGISTRO_TIPO_PAGOS] (
    [IdTipoPago]    UNIQUEIDENTIFIER NOT NULL,
    [IdVenta]       UNIQUEIDENTIFIER NOT NULL,
    [Monto]         DECIMAL (10, 2)  NOT NULL,
    [NombreCliente] VARCHAR (100)    NOT NULL,
    [Fecha]         DATE             NOT NULL,
    [IdMetodoPago]  UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([IdTipoPago] ASC),
    CONSTRAINT [FK_RegistroPago_Venta_TipoPagos] FOREIGN KEY ([IdVenta]) REFERENCES [dbo].[VENTAS] ([IdVenta])
);

