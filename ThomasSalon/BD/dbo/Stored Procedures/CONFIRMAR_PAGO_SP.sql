CREATE PROCEDURE CONFIRMAR_PAGO_SP
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

    -- 1. Obtener los datos de la tabla PagosTemporales
    SELECT 
        @FechaInicioSemana = FechaInicioSemana,
        @FechaFinSemana = FechaFinSemana,
        @DiasCompletos = DiasCompletos,
        @DiasMedioTiempos = DiasMedioTiempos,
        @TotalComision = TotalComision,
        @TotalDeducciones = TotalDeducciones,
        @TotalGastos = TotalGastos,
        @TotalPago = TotalPago
    FROM PagosTemporales
    WHERE IdColaborador = @IdColaborador;

    -- 2. Insertar en la tabla PAGOS
    INSERT INTO PAGOS (
        IdColaborador, FechaInicioSemana, FechaFinSemana, FechaPago,
        DiasCompletos, DiasMedioTiempos, TotalComision, 
        TotalDeducciones, TotalGastos, TotalPago
    )
    VALUES (
        @IdColaborador, @FechaInicioSemana, @FechaFinSemana, @FechaPago,
        @DiasCompletos, @DiasMedioTiempos, @TotalComision,
        @TotalDeducciones, @TotalGastos, @TotalPago
    );

    -- 3. Eliminar el registro de la tabla PagosTemporales
    DELETE FROM PagosTemporales WHERE DiasCompletos > -1;
END;