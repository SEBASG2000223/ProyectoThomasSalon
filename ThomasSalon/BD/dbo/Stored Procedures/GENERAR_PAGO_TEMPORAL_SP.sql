CREATE PROCEDURE GENERAR_PAGO_TEMPORAL_SP
    @IdColaborador INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE 
        @FechaInicioSemana DATE,
        @FechaFinSemana DATE,
        @FechaPago DATE = GETDATE(),
        @DiasCompletos INT,
        @DiasMedioTiempos INT,
        @TotalComision DECIMAL(10,2) = 0,  
        @TotalDeducciones DECIMAL(10,2) = 0, 
        @TotalGastos DECIMAL(10,2) = 0, 
        @TotalPago DECIMAL(10,2) = 0,  
        @SalarioBase DECIMAL(10,2),
        @SalarioDia DECIMAL(10,2);

    -- 1. Calcular FechaInicioSemana (día después del último pago)
    SELECT @FechaInicioSemana = DATEADD(DAY, 1, MAX(FechaPago))
    FROM PAGOS
    WHERE IdColaborador = @IdColaborador;

    -- Establecer el primer día de la semana en lunes
    SET DATEFIRST 1;

    -- Si es el primer pago o la fecha de pago es hoy, usar el lunes de hace dos semanas
    IF @FechaInicioSemana IS NULL OR @FechaPago = CAST(GETDATE() AS DATE)
    BEGIN
        SET @FechaInicioSemana = DATEADD(DAY, -14 - DATEPART(WEEKDAY, GETDATE()) + 1, CAST(GETDATE() AS DATE));
    END
    -- Si no es el primer pago, usar el día siguiente de la última fecha de pago
    ELSE
    BEGIN
        SET @FechaInicioSemana = DATEADD(DAY, 1, @FechaInicioSemana);
    END

    -- 2. Calcular FechaFinSemana (domingo anterior más cercano a hoy)
    SET @FechaFinSemana = 
        CASE 
            WHEN DATEPART(WEEKDAY, GETDATE()) = 1 THEN DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) -- si hoy es domingo, usar el domingo anterior
            ELSE DATEADD(DAY, -DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) -- calcular el domingo pasado
        END;

    -- Verificar si las fechas están en orden correcto
    IF @FechaInicioSemana > @FechaFinSemana
    BEGIN
        -- Si la fecha de inicio es después de la fecha de fin, intercambiarlas
        DECLARE @Temp DATE = @FechaInicioSemana;
        SET @FechaInicioSemana = @FechaFinSemana;
        SET @FechaFinSemana = @Temp;
    END

    -- Verificar si ya existe un pago temporal para este colaborador
    IF EXISTS (SELECT 1 FROM PagosTemporales WHERE IdColaborador = @IdColaborador)
    BEGIN
        -- Si ya existe, simplemente devolver los datos
        SELECT * FROM PagosTemporales WHERE IdColaborador = @IdColaborador;
    END
    ELSE
    BEGIN
        -- 3. Obtener días completos (tipo jornada = 1)
        SELECT @DiasCompletos = COUNT(*) 
        FROM ASISTENCIA_COLABORADORES
        WHERE IdColaborador = @IdColaborador
          AND IdTipoJornada = 1
          AND Fecha BETWEEN @FechaInicioSemana AND @FechaFinSemana;

        -- 4. Obtener días medio tiempo (tipo jornada = 2)
        SELECT @DiasMedioTiempos = COUNT(*) 
        FROM ASISTENCIA_COLABORADORES
        WHERE IdColaborador = @IdColaborador
          AND IdTipoJornada = 2
          AND Fecha BETWEEN @FechaInicioSemana AND @FechaFinSemana;

        -- 5. Obtener comisiones
        SELECT @TotalComision = ISNULL(SUM(DPV.Comision), 0)
        FROM VENTAS V
        JOIN DETALLE_PRODUCTOS_VENTAS DPV ON V.IdVenta = DPV.IdVenta
        WHERE V.IdColaborador = @IdColaborador
        AND V.Fecha BETWEEN @FechaInicioSemana AND @FechaFinSemana;

        -- 6. Obtener deducciones
        SELECT @TotalDeducciones = ISNULL(MontoSemanal, 0)
        FROM DEDUCCIONES
        WHERE IdColaborador = @IdColaborador;

        -- 7. Obtener gastos
        SELECT @TotalGastos = ISNULL(SUM(Monto), 0)
        FROM REGISTRO_GASTOS
        WHERE IdColaborador = @IdColaborador
        AND Fecha BETWEEN @FechaInicioSemana AND @FechaFinSemana;

        -- 8. Obtener el salario por día del colaborador
        SELECT @SalarioDia = SalarioDia
        FROM COLABORADORES
        WHERE IdColaborador = @IdColaborador;

        -- Calcular salario base real
        SET @SalarioBase = (@DiasCompletos * @SalarioDia) + (@DiasMedioTiempos * (@SalarioDia / 2));

        -- 9. Calcular total a pagar
        SET @TotalPago = (@SalarioBase + @TotalComision) - @TotalDeducciones - @TotalGastos;

        -- Insertar en la tabla permanente PagosTemporales
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
    END

    -- Devolver los datos de la tabla permanente para mostrarlos en la aplicación
    SELECT * FROM PagosTemporales WHERE IdColaborador = @IdColaborador;
END;