CREATE PROCEDURE SP_InsertarCitaPresencial
    @IdServicio INT,
    @IdSucursal INT,
    @IdColaborador INT,
    @Identificacion NVARCHAR(50),
    @FechaHora DATETIME,
    @Comentario VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION; 

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM SERVICIOS WHERE IdServicio = @IdServicio)
        BEGIN
            RAISERROR ('El servicio no existe.', 16, 1);
            ROLLBACK TRANSACTION; 
            RETURN;
        END

        IF NOT EXISTS (SELECT 1 FROM SUCURSALES WHERE IdSucursal = @IdSucursal)
        BEGIN
            RAISERROR ('La sucursal no existe.', 16, 1);
            ROLLBACK TRANSACTION;  
            RETURN;
        END

        DECLARE @IdPersona INT;
        SELECT @IdPersona = IdPersona FROM Personas WHERE Identificacion = @Identificacion;

        IF @IdPersona IS NULL
        BEGIN
            RAISERROR ('La persona no está registrada en la base de datos.', 16, 1);
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
        THROW;
    END CATCH
END;