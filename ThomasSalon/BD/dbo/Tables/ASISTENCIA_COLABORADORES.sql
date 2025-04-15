CREATE TABLE [dbo].[ASISTENCIA_COLABORADORES] (
    [IdAsistencia]  UNIQUEIDENTIFIER NOT NULL,
    [IdColaborador] INT              NOT NULL,
    [Fecha]         DATETIME         DEFAULT (getdate()) NULL,
    [IdTipoJornada] INT              NOT NULL,
    [IdSucursal]    INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([IdAsistencia] ASC),
    CONSTRAINT [FK_Asistencia_Colaboradores] FOREIGN KEY ([IdColaborador]) REFERENCES [dbo].[COLABORADORES] ([IdColaborador]),
    CONSTRAINT [FK_Asistencia_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[SUCURSALES] ([IdSucursal]),
    CONSTRAINT [FK_Asistencia_TipoJornada] FOREIGN KEY ([IdTipoJornada]) REFERENCES [dbo].[TIPOS_JORNADA] ([IdTipoJornada])
);

