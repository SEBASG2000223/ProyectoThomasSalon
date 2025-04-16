CREATE PROCEDURE sp_RegistrarGasto
    @IdColaborador INT,
    @IdSucursal INT,
    @Descripcion VARCHAR(100),
    @Monto DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @IdIngreso UNIQUEIDENTIFIER;
        DECLARE @IdGasto UNIQUEIDENTIFIER = NEWID();
        DECLARE @Fecha DATE = CONVERT(DATE, GETDATE());

        -- Verificar o crear ingreso diario
        IF EXISTS (
            SELECT 1 FROM INGRESOS_DIARIOS 
            WHERE CONVERT(DATE, Fecha) = @Fecha 
              AND IdSucursal = @IdSucursal
        )
        BEGIN
            SELECT @IdIngreso = IdIngreso 
            FROM INGRESOS_DIARIOS 
            WHERE CONVERT(DATE, Fecha) = @Fecha 
              AND IdSucursal = @IdSucursal;
        END
        ELSE
        BEGIN
            SET @IdIngreso = NEWID();
            INSERT INTO INGRESOS_DIARIOS (IdIngreso, Fecha, IdSucursal, MontoTotalDia, MontoTotalGastos)
            VALUES (@IdIngreso, @Fecha, @IdSucursal, -@Monto, @Monto);
        END

        -- Actualizar ingreso con gasto
        UPDATE INGRESOS_DIARIOS
        SET 
            MontoTotalGastos = MontoTotalGastos + @Monto,
            MontoTotalDia = MontoTotalDia - @Monto
        WHERE IdIngreso = @IdIngreso;

        -- Insertar gasto
        INSERT INTO REGISTRO_GASTOS (IdGastos, Fecha, IdIngreso, Monto, IdColaborador, Descripcion)
        VALUES (@IdGasto, @Fecha, @IdIngreso, @Monto, @IdColaborador, @Descripcion);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;