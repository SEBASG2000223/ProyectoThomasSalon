CREATE PROCEDURE sp_RegistrarVentaProductos
    @IdColaborador INT,
    @IdMetodoPago UNIQUEIDENTIFIER,
    @IdPersona INT,
    @IdSucursal INT,
    @Productos Tipo_ProductoVenta READONLY
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FechaHoy DATE = CAST(GETDATE() AS DATE);
    DECLARE @IdIngreso UNIQUEIDENTIFIER;
    DECLARE @IdVenta UNIQUEIDENTIFIER = NEWID();
    DECLARE @MontoTotalVenta DECIMAL(10, 2) = 0;

    -- Buscar o crear ingreso del día
    SELECT TOP 1 @IdIngreso = IdIngreso
    FROM INGRESOS_DIARIOS
    WHERE IdSucursal = @IdSucursal AND CAST(Fecha AS DATE) = @FechaHoy;

    IF @IdIngreso IS NULL
    BEGIN
        SET @IdIngreso = NEWID();
        INSERT INTO INGRESOS_DIARIOS (IdIngreso, Fecha, IdSucursal)
        VALUES (@IdIngreso, GETDATE(), @IdSucursal);
    END

    -- Calcular monto total
    SELECT @MontoTotalVenta = SUM(Cantidad * PrecioUnitario)
    FROM @Productos;

    -- Insertar venta
    INSERT INTO VENTAS (IdVenta, IdIngreso, IdColaborador, IdMetodoPago, IdPersona, MontoTotal, Fecha)
    VALUES (@IdVenta, @IdIngreso, @IdColaborador, @IdMetodoPago, @IdPersona, @MontoTotalVenta, GETDATE());

    -- Insertar detalle de productos
    INSERT INTO DETALLE_PRODUCTOS_VENTAS (
        IdDetalleProducto, IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal
    )
    SELECT 
        NEWID(), 
        @IdVenta, 
        IdProducto, 
        Cantidad, 
        PrecioUnitario, 
        Cantidad * PrecioUnitario
    FROM @Productos;


    -- Actualizar ingresos diarios directamente con ID del método de pago
    -- Reemplaza los GUID por los que realmente usas
    IF @IdMetodoPago = '07D9FB11-7585-4425-AA0F-E5DC51BF48DB' -- Efectivo
        UPDATE INGRESOS_DIARIOS
        SET MontoTotalEfectivo += @MontoTotalVenta, MontoTotalDia += @MontoTotalVenta
        WHERE IdIngreso = @IdIngreso;

    ELSE IF @IdMetodoPago = 'EB0BBFCE-E2D4-4D6E-8762-063315C82225' -- Tarjeta
        UPDATE INGRESOS_DIARIOS
        SET MontoTotalTarjeta += @MontoTotalVenta, MontoTotalDia += @MontoTotalVenta
        WHERE IdIngreso = @IdIngreso;

    ELSE IF @IdMetodoPago = 'B5AF949F-FBB1-41C1-9F4E-6F31BB2203F1' -- Sinpe
        UPDATE INGRESOS_DIARIOS
        SET MontoTotalSinpe += @MontoTotalVenta, MontoTotalDia += @MontoTotalVenta
        WHERE IdIngreso = @IdIngreso;

    ELSE IF @IdMetodoPago = '6A7711B3-982B-41C7-8AD1-CAEC33DB83F5' -- Transferencia
        UPDATE INGRESOS_DIARIOS
        SET MontoTotalTransferencias += @MontoTotalVenta, MontoTotalDia += @MontoTotalVenta
        WHERE IdIngreso = @IdIngreso;

    ELSE
        UPDATE INGRESOS_DIARIOS
        SET MontoTotalDia += @MontoTotalVenta
        WHERE IdIngreso = @IdIngreso;
END;