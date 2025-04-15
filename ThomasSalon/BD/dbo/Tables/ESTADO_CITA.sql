CREATE TABLE [dbo].[ESTADO_CITA] (
    [IdEstadoCita] UNIQUEIDENTIFIER NOT NULL,
    [Nombre]       VARCHAR (50)     NOT NULL,
    [Descripcion]  VARCHAR (50)     NULL,
    PRIMARY KEY CLUSTERED ([IdEstadoCita] ASC)
);

