CREATE TABLE [dbo].[PEDIDOS] (
    [IdPedido]        UNIQUEIDENTIFIER NOT NULL,
    [IdEstadoPedido]  INT              DEFAULT ((1)) NOT NULL,
    [IdSucursal]      INT              NOT NULL,
    [IdUsuario]       NVARCHAR (128)   NOT NULL,
    [IdMetodoPago]    UNIQUEIDENTIFIER NOT NULL,
    [IdTipoEntrega]   UNIQUEIDENTIFIER NOT NULL,
    [IdProvincia]     UNIQUEIDENTIFIER NULL,
    [DireccionExacta] VARCHAR (255)    NULL,
    [Comentario]      VARCHAR (255)    NULL,
    [Fecha]           DATETIME         DEFAULT (getdate()) NOT NULL,
    [MontoTotal]      DECIMAL (10, 2)  NOT NULL,
    [MontoIVA]        DECIMAL (10, 2)  NOT NULL,
    [IdAdjuntos]      UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([IdPedido] ASC),
    CONSTRAINT [FK_IdAdjuntos] FOREIGN KEY ([IdAdjuntos]) REFERENCES [dbo].[ADJUNTOS_PEDIDOS] ([IdAdjuntos]),
    CONSTRAINT [FK_IdEstadoPedido] FOREIGN KEY ([IdEstadoPedido]) REFERENCES [dbo].[ESTADO_PEDIDO] ([IdEstadoPedido]),
    CONSTRAINT [FK_IdMetodoPago] FOREIGN KEY ([IdMetodoPago]) REFERENCES [dbo].[METODOS_PAGO] ([IdMetodoPago]),
    CONSTRAINT [FK_IdProvincia] FOREIGN KEY ([IdProvincia]) REFERENCES [dbo].[PROVINCIAS] ([IdProvincia]),
    CONSTRAINT [FK_IdTipoEntrega] FOREIGN KEY ([IdTipoEntrega]) REFERENCES [dbo].[TIPOS_ENTREGA] ([IdTipoEntrega]),
    CONSTRAINT [FK_IdUsuarioPedidos] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Pedidos_Sucursal] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[SUCURSALES] ([IdSucursal])
);

