CREATE TABLE [dbo].[PagosTemporales] (
    [IdColaborador]     INT             NULL,
    [FechaInicioSemana] DATE            NULL,
    [FechaFinSemana]    DATE            NULL,
    [FechaPago]         DATE            NULL,
    [DiasCompletos]     INT             NULL,
    [DiasMedioTiempos]  INT             NULL,
    [TotalComision]     DECIMAL (10, 2) NULL,
    [TotalDeducciones]  DECIMAL (10, 2) NULL,
    [TotalGastos]       DECIMAL (10, 2) NULL,
    [TotalPago]         DECIMAL (10, 2) NULL,
    [FechaCreacion]     DATETIME        DEFAULT (getdate()) NULL
);

