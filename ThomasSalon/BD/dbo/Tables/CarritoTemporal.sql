CREATE TABLE [dbo].[CarritoTemporal] (
    [IdCarrito]      INT             IDENTITY (1, 1) NOT NULL,
    [IdUsuario]      NVARCHAR (128)  NOT NULL,
    [IdProducto]     INT             NOT NULL,
    [Cantidad]       INT             NOT NULL,
    [PrecioUnitario] DECIMAL (10, 2) NOT NULL,
    [FechaAgregado]  DATETIME        DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([IdCarrito] ASC),
    CONSTRAINT [FK_CarritoTemporal_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[PRODUCTOS] ([IdProducto]),
    CONSTRAINT [FK_CarritoTemporal_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

