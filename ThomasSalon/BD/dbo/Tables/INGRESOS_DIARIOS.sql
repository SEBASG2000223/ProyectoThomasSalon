CREATE TABLE [dbo].[INGRESOS_DIARIOS] (
    [IdIngreso]                UNIQUEIDENTIFIER NOT NULL,
    [Fecha]                    DATETIME         DEFAULT (getdate()) NOT NULL,
    [IdSucursal]               INT              NOT NULL,
    [MontoTotalDia]            DECIMAL (10, 2)  DEFAULT ((0)) NOT NULL,
    [MontoTotalTransferencias] DECIMAL (10, 2)  DEFAULT ((0)) NOT NULL,
    [MontoTotalSinpe]          DECIMAL (10, 2)  DEFAULT ((0)) NOT NULL,
    [MontoTotalTarjeta]        DECIMAL (10, 2)  DEFAULT ((0)) NOT NULL,
    [MontoTotalEfectivo]       DECIMAL (10, 2)  DEFAULT ((0)) NOT NULL,
    [MontoTotalGastos]         DECIMAL (10, 2)  DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdIngreso] ASC),
    CONSTRAINT [FK_Ingresos_Sucursal] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[SUCURSALES] ([IdSucursal])
);

