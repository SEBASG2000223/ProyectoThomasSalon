CREATE TABLE [dbo].[ESTADO_PEDIDO] (
    [IdEstadoPedido] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    [Descripcion]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([IdEstadoPedido] ASC)
);

