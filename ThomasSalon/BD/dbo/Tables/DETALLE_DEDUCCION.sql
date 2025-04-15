CREATE TABLE [dbo].[DETALLE_DEDUCCION] (
    [IdDetalleDeduccion] UNIQUEIDENTIFIER NOT NULL,
    [IdDeduccion]        UNIQUEIDENTIFIER NOT NULL,
    [Fecha]              DATE             DEFAULT (getdate()) NOT NULL,
    [MontoAgregado]      DECIMAL (10, 2)  NOT NULL,
    [Descripcion]        VARCHAR (200)    NULL,
    PRIMARY KEY CLUSTERED ([IdDetalleDeduccion] ASC),
    CONSTRAINT [FK_DetalleDeduccion_Deducciones] FOREIGN KEY ([IdDeduccion]) REFERENCES [dbo].[DEDUCCIONES] ([IdDeduccion])
);

