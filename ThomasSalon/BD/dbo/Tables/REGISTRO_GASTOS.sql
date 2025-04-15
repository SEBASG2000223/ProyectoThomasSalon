CREATE TABLE [dbo].[REGISTRO_GASTOS] (
    [IdGastos]      UNIQUEIDENTIFIER NOT NULL,
    [Fecha]         DATE             NOT NULL,
    [IdIngreso]     UNIQUEIDENTIFIER NOT NULL,
    [Monto]         DECIMAL (10, 2)  NOT NULL,
    [IdColaborador] INT              NULL,
    [Descripcion]   VARCHAR (100)    NOT NULL,
    PRIMARY KEY CLUSTERED ([IdGastos] ASC),
    CONSTRAINT [FK_RegistroPago_Venta_RegistroGasto] FOREIGN KEY ([IdIngreso]) REFERENCES [dbo].[INGRESOS_DIARIOS] ([IdIngreso]),
    CONSTRAINT [FK_Ventas_Colaborador_RegistroGastos] FOREIGN KEY ([IdColaborador]) REFERENCES [dbo].[COLABORADORES] ([IdColaborador])
);

