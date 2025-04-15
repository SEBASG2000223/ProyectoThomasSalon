CREATE PROCEDURE InsertarAsistenciaColaborador
    @IdColaborador INT,
    @IdTipoJornada INT,
    @IdSucursal INT,
    @Fecha DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ASISTENCIA_COLABORADORES (
        IdAsistencia,
        IdColaborador,
        Fecha,
        IdTipoJornada,
        IdSucursal
    )
    VALUES (
        NEWID(),
        @IdColaborador,
        ISNULL(@Fecha, GETDATE()),
        @IdTipoJornada,
        @IdSucursal
    );
END;