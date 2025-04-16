CREATE PROCEDURE sp_RegistrarVentaServicios
    @IdColaborador INT,
    @IdMetodoPago UNIQUEIDENTIFIER,
    @IdPersona INT,
    @IdSucursal INT,
    @Servicios Tipo_ServicioVenta READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @IdIngreso UNIQUEIDENTIFIER;
        DECLARE @IdVenta UNIQUEIDENTIFIER = NEWID();
        DECLARE @Fecha DATETIME = GETDATE();
        DECLARE @FechaBase DATE = CONVERT(DATE, @Fecha);
        DECLARE @MontoTotal DECIMAL(10,2) = 0;

        -- Calcular total de todos los servicios
        SELECT @MontoTotal = SUM(Precio) FROM @Servicios;

        -- Verificar o crear ingreso diario
        IF EXISTS (
            SELECT 1 FROM INGRESOS_DIARIOS 
            WHERE CONVERT(DATE, Fecha) = @FechaBase 
            AND IdSucursal = @IdSucursal
        )
        BEGIN
            SELECT @IdIngreso = IdIngreso 
            FROM INGRESOS_DIARIOS 
            WHERE CONVERT(DATE, Fecha) = @FechaBase 
              AND IdSucursal = @IdSucursal;
        END
        ELSE
        BEGIN
            SET @IdIngreso = NEWID();
            INSERT INTO INGRESOS_DIARIOS (IdIngreso, Fecha, IdSucursal)
            VALUES (@IdIngreso, @FechaBase, @IdSucursal);
        END

        -- Actualizar montos
        UPDATE INGRESOS_DIARIOS
        SET 
            MontoTotalDia = MontoTotalDia + @MontoTotal,
            MontoTotalEfectivo = MontoTotalEfectivo + CASE WHEN @IdMetodoPago = '07D9FB11-7585-4425-AA0F-E5DC51BF48DB' THEN @MontoTotal ELSE 0 END,
            MontoTotalTarjeta = MontoTotalTarjeta + CASE WHEN @IdMetodoPago = 'EB0BBFCE-E2D4-4D6E-8762-063315C82225' THEN @MontoTotal ELSE 0 END,
            MontoTotalSinpe = MontoTotalSinpe + CASE WHEN @IdMetodoPago = 'B5AF949F-FBB1-41C1-9F4E-6F31BB2203F1' THEN @MontoTotal ELSE 0 END,
            MontoTotalTransferencias = MontoTotalTransferencias + CASE WHEN @IdMetodoPago = '6A7711B3-982B-41C7-8AD1-CAEC33DB83F5' THEN @MontoTotal ELSE 0 END
        WHERE IdIngreso = @IdIngreso;

        -- Insertar venta
        INSERT INTO VENTAS (IdVenta, IdIngreso, IdColaborador, IdMetodoPago, IdPersona, MontoTotal, Fecha)
        VALUES (@IdVenta, @IdIngreso, @IdColaborador, @IdMetodoPago, @IdPersona, @MontoTotal, @Fecha);

        -- Insertar todos los servicios
        INSERT INTO DETALLE_SERVICIOS_VENTAS (IdDetalleServicio, IdVenta, IdServicio, Precio)
        SELECT NEWID(), @IdVenta, IdServicio, Precio
        FROM @Servicios;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END