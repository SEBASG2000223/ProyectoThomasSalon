CREATE PROCEDURE GENERAR_PAGO_TEMPORAL_SP
    @IdColaborador INT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Verificar si ya existe un registro con el mismo colaborador y fecha reciente (menos de 5 días)
    IF EXISTS (
        SELECT 1
        FROM PagosTemporales
        WHERE IdColaborador = @IdColaborador
          AND DATEDIFF(DAY, FechaPago, GETDATE()) <= 5
    )
    BEGIN
        -- Si ya existe un pago temporal reciente, devolver el registro existente
        SELECT * 
        FROM PagosTemporales 
        WHERE IdColaborador = @IdColaborador
          AND DATEDIFF(DAY, FechaPago, GETDATE()) <= 5;

        -- Terminar el procedimiento sin continuar con los cálculos innecesarios
        RETURN;
    END

    -- Si no existe un pago reciente, continuar con los cálculos

    DECLARE 
        @FechaInicioSemana DATE,
        @FechaFinSemana DATE,
        @FechaPago DATE = CAST(GETDATE() AS DATE),
        @DiasCompletos INT = 0,
        @DiasMedioTiempos INT = 0,
        @TotalComision DECIMAL(10,2) = 0,  
        @TotalDeducciones DECIMAL(10,2) = 0, 
        @TotalGastos DECIMAL(10,2) = 0, 
        @TotalPago DECIMAL(10,2) = 0,  
        @SalarioDia DECIMAL(10,2);

    -- Establecer primer día de la semana como lunes
    SET DATEFIRST 1;

    -- 2. Calcular FechaFinSemana = domingo anterior más próximo
    SET @FechaFinSemana = 
        CASE 
            WHEN DATEPART(WEEKDAY, @FechaPago) = 1 THEN DATEADD(DAY, -7, @FechaPago)
            ELSE DATEADD(DAY, -DATEPART(WEEKDAY, @FechaPago), @FechaPago)
        END;

    -- 3. Buscar último pago registrado para el colaborador
    DECLARE @UltimaFechaFin DATE;

    SELECT @UltimaFechaFin = MAX(FechaFinSemana)
    FROM PAGOS
    WHERE IdColaborador = @IdColaborador;

    -- 4. Calcular FechaInicioSemana
    IF @UltimaFechaFin IS NULL
    BEGIN
        -- Si no hay pago previo, usar fecha de inicio de la semana hace 15 días
        SET @FechaInicioSemana = DATEADD(DAY, -15, @FechaFinSemana);
    END
    ELSE
    BEGIN
        -- Si ya hay un pago previo, tomar el día siguiente al último pago
        SET @FechaInicioSemana = DATEADD(DAY, 1, @UltimaFechaFin);
    END

    -- 5. Obtener el salario por día para el colaborador
    SELECT @SalarioDia = SalarioDia
    FROM COLABORADORES
    WHERE IdColaborador = @IdColaborador;

    -- 6. Contar días completos y medio tiempo dentro del rango de fechas de la semana
    SELECT 
        @DiasCompletos = SUM(CASE WHEN IdTipoJornada = 1 AND CAST(Fecha AS DATE) BETWEEN @FechaInicioSemana AND @FechaFinSemana THEN 1 ELSE 0 END),
        @DiasMedioTiempos = SUM(CASE WHEN IdTipoJornada = 2 AND CAST(Fecha AS DATE) BETWEEN @FechaInicioSemana AND @FechaFinSemana THEN 1 ELSE 0 END)
    FROM ASISTENCIA_COLABORADORES
    WHERE IdColaborador = @IdColaborador;

    -- 7. Calcular la comisión desde la tabla de ventas y detalles de venta
    SELECT @TotalComision = SUM(DV.Comision)
    FROM DETALLE_PRODUCTOS_VENTAS DV
    INNER JOIN VENTAS V ON DV.IdVenta = V.IdVenta
    WHERE V.IdColaborador = @IdColaborador
      AND V.Fecha BETWEEN @FechaInicioSemana AND @FechaFinSemana;

    -- 8. Calcular deducciones desde la tabla Deducciones para el rango de fechas
    SELECT @TotalDeducciones = SUM(MontoSemanal)
    FROM DEDUCCIONES
    WHERE IdColaborador = @IdColaborador;

    -- 9. Calcular gastos desde la tabla Gastos para el rango de fechas
    SELECT @TotalGastos = SUM(Monto)
    FROM REGISTRO_GASTOS
    WHERE IdColaborador = @IdColaborador
      AND Fecha BETWEEN @FechaInicioSemana AND @FechaFinSemana;

    -- 10. Calcular el total de pago
    SET @TotalPago = (@DiasCompletos * @SalarioDia) + (@DiasMedioTiempos * @SalarioDia / 2) + @TotalComision - @TotalDeducciones - @TotalGastos;

    -- 11. Insertar el nuevo pago en la tabla de pagos temporales
    INSERT INTO PagosTemporales (
        IdColaborador, FechaInicioSemana, FechaFinSemana, FechaPago,
        DiasCompletos, DiasMedioTiempos, TotalComision, 
        TotalDeducciones, TotalGastos, TotalPago
    )
    VALUES (
        @IdColaborador, @FechaInicioSemana, @FechaFinSemana, @FechaPago,
        @DiasCompletos, @DiasMedioTiempos, @TotalComision,
        @TotalDeducciones, @TotalGastos, @TotalPago
    );

    -- 12. Retornar el registro recién insertado
    SELECT * 
    FROM PagosTemporales
    WHERE IdColaborador = @IdColaborador
END