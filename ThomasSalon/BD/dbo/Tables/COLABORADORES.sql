CREATE TABLE [dbo].[COLABORADORES] (
    [IdColaborador] INT             IDENTITY (1, 1) NOT NULL,
    [IdPersona]     INT             NULL,
    [SalarioDia]    DECIMAL (10, 2) NOT NULL,
    [IdEstado]      INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([IdColaborador] ASC),
    CONSTRAINT [FK_Colaboradores_Personas] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Personas] ([IdPersona]),
    CONSTRAINT [FK_IdEstado_Colaboradores] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado])
);

