CREATE TABLE [dbo].[BITACORA_DEDUCCIONES] (
    [IdDeduccionBitacora] UNIQUEIDENTIFIER NOT NULL,
    [IdDeduccion]         UNIQUEIDENTIFIER NOT NULL,
    [Fecha]               DATE             NOT NULL,
    [MontoDebitado]       DECIMAL (10, 2)  NOT NULL,
    [TotalSaldo]          DECIMAL (10, 2)  NOT NULL,
    [IdPago]              INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDeduccionBitacora] ASC),
    CONSTRAINT [FK_BitacoraDeducciones_Deducciones] FOREIGN KEY ([IdDeduccion]) REFERENCES [dbo].[DEDUCCIONES] ([IdDeduccion]),
    CONSTRAINT [FK_BitacoraDeducciones_Pagos] FOREIGN KEY ([IdPago]) REFERENCES [dbo].[PAGOS] ([IdPago])
);

