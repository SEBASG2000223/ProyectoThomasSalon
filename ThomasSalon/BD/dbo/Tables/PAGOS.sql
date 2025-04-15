CREATE TABLE [dbo].[PAGOS] (
    [IdPago]            INT             IDENTITY (1, 1) NOT NULL,
    [IdColaborador]     INT             NOT NULL,
    [FechaInicioSemana] DATE            NOT NULL,
    [FechaFinSemana]    DATE            NOT NULL,
    [FechaPago]         DATE            NOT NULL,
    [DiasCompletos]     INT             NOT NULL,
    [DiasMedioTiempos]  INT             NOT NULL,
    [TotalComision]     DECIMAL (10, 2) DEFAULT ((0)) NOT NULL,
    [TotalDeducciones]  DECIMAL (10, 2) DEFAULT ((0)) NOT NULL,
    [TotalGastos]       DECIMAL (10, 2) DEFAULT ((0)) NOT NULL,
    [TotalPago]         DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdPago] ASC),
    CONSTRAINT [FK_Pagos_Colaboradores] FOREIGN KEY ([IdColaborador]) REFERENCES [dbo].[COLABORADORES] ([IdColaborador])
);

