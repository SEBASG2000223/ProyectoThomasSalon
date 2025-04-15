CREATE TABLE [dbo].[DEDUCCIONES] (
    [IdDeduccion]   UNIQUEIDENTIFIER NOT NULL,
    [IdColaborador] INT              NOT NULL,
    [MontoSemanal]  DECIMAL (10, 2)  NOT NULL,
    [TotalSaldo]    DECIMAL (10, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IdDeduccion] ASC),
    CONSTRAINT [FK_Deducciones_Colaborador] FOREIGN KEY ([IdColaborador]) REFERENCES [dbo].[COLABORADORES] ([IdColaborador])
);

