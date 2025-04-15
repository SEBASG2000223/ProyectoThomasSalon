CREATE TABLE [dbo].[CITAS] (
    [IdCita]        UNIQUEIDENTIFIER NOT NULL,
    [IdServicio]    INT              NOT NULL,
    [IdSucursal]    INT              NOT NULL,
    [IdPersona]     INT              NOT NULL,
    [IdColaborador] INT              NULL,
    [IdEstadoCita]  UNIQUEIDENTIFIER NOT NULL,
    [FechaHora]     DATETIME         NOT NULL,
    [Comentario]    VARCHAR (100)    NULL,
    PRIMARY KEY CLUSTERED ([IdCita] ASC),
    CONSTRAINT [FK_IdColaborador_Citas] FOREIGN KEY ([IdColaborador]) REFERENCES [dbo].[COLABORADORES] ([IdColaborador]),
    CONSTRAINT [FK_IdEstadoCita] FOREIGN KEY ([IdEstadoCita]) REFERENCES [dbo].[ESTADO_CITA] ([IdEstadoCita]),
    CONSTRAINT [FK_IdPersona_Citas] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Personas] ([IdPersona]),
    CONSTRAINT [FK_IdServicio] FOREIGN KEY ([IdServicio]) REFERENCES [dbo].[SERVICIOS] ([IdServicio]),
    CONSTRAINT [FK_IdSucursal] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[SUCURSALES] ([IdSucursal])
);


GO
CREATE TRIGGER TR_CITAS_SetComentarioDefault
ON CITAS
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE C
    SET Comentario = 'Ningún comentario'
    FROM CITAS C
    INNER JOIN inserted I ON C.IdCita = I.IdCita
    WHERE I.Comentario IS NULL;
END;