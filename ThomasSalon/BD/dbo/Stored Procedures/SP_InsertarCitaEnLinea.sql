CREATE PROCEDURE SP_InsertarCitaEnLinea
    @IdServicio INT,
    @IdSucursal INT,
	@IdColaborador INT,
    @IdUsuario NVARCHAR(128),
    @FechaHora DATETIME,
    @Comentario VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION; 

    BEGIN TRY
        -- Verificar si el servicio existe
        IF NOT EXISTS (SELECT 1 FROM SERVICIOS WHERE IdServicio = @IdServicio)
        BEGIN
            RAISERROR ('El servicio no existe.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar si la sucursal existe
        IF NOT EXISTS (SELECT Nombre FROM SUCURSALES WHERE IdSucursal = @IdSucursal)
        BEGIN
            RAISERROR ('La sucursal no existe.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Obtener IdPersona desde el IdUsuario (usuario logueado)
        DECLARE @IdPersona INT;
        SELECT @IdPersona = p.IdPersona 
        FROM AspNetUsers u
        JOIN Personas p ON u.IdPersona = p.IdPersona
        WHERE u.Id = @IdUsuario;

        IF @IdPersona IS NULL
        BEGIN
            RAISERROR ('El usuario no tiene una persona asociada.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insertar la cita en la tabla
        INSERT INTO CITAS (IdCita, IdServicio, IdSucursal, IdPersona, IdColaborador, IdEstadoCita, FechaHora, Comentario)
        VALUES (NEWID(), @IdServicio, @IdSucursal, @IdPersona, @IdColaborador, 'C24391BE-8BAE-4BCC-996D-E64D33326BA2', @FechaHora, @Comentario);

        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END;