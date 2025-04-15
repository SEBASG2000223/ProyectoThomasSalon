CREATE TABLE [dbo].[DETALLE_PEDIDOS] (
    [IdDetallePedido] UNIQUEIDENTIFIER NOT NULL,
    [IdPedido]        UNIQUEIDENTIFIER NOT NULL,
    [IdProducto]      INT              NOT NULL,
    [Cantidad]        INT              NOT NULL,
    [PrecioUnitario]  DECIMAL (10, 2)  NOT NULL,
    [Subtotal]        DECIMAL (10, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDetallePedido] ASC),
    CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY ([IdPedido]) REFERENCES [dbo].[PEDIDOS] ([IdPedido]),
    CONSTRAINT [FK_DetallePedido_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[PRODUCTOS] ([IdProducto])
);

