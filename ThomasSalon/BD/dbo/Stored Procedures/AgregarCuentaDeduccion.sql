CREATE PROCEDURE AgregarCuentaDeduccion
    @IdColaborador INT,
    @MontoAgregado DECIMAL(10,2),
    @Descripcion VARCHAR(200)
AS
BEGIN
    -- Declarar variables
    DECLARE @IdDeduccion UNIQUEIDENTIFIER;
    
    -- Iniciar la transacción
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Verificar si ya existe una deducción para el colaborador
        SELECT @IdDeduccion = IdDeduccion
        FROM DEDUCCIONES
        WHERE IdColaborador = @IdColaborador;

        -- Si existe deducción, agregar detalle y actualizar saldo
        IF @IdDeduccion IS NOT NULL
        BEGIN
            -- Insertar un nuevo detalle de deducción
            INSERT INTO DETALLE_DEDUCCION (IdDetalleDeduccion, IdDeduccion, MontoAgregado, Descripcion)
            VALUES (NEWID(), @IdDeduccion, @MontoAgregado, @Descripcion);

            -- Actualizar el saldo total de la deducción
            UPDATE DEDUCCIONES
            SET TotalSaldo = TotalSaldo + @MontoAgregado
            WHERE IdDeduccion = @IdDeduccion;
        END
        -- Si no existe deducción, crear una nueva
        ELSE
        BEGIN
            -- Crear una nueva deducción para el colaborador
            SET @IdDeduccion = NEWID();
            INSERT INTO DEDUCCIONES (IdDeduccion, IdColaborador, MontoSemanal, TotalSaldo)
            VALUES (@IdDeduccion, @IdColaborador, @MontoAgregado, @MontoAgregado);

            -- Insertar el detalle de deducción
            INSERT INTO DETALLE_DEDUCCION (IdDetalleDeduccion, IdDeduccion, MontoAgregado, Descripcion)
            VALUES (NEWID(), @IdDeduccion, @MontoAgregado, @Descripcion);
        END

        -- Si todo es correcto, confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, hacer rollback de la transacción
        ROLLBACK TRANSACTION;

        -- Opcional: Lanzar el error para manejarlo fuera del procedimiento si es necesario
        THROW;
    END CATCH
END;