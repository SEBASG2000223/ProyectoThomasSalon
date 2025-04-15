CREATE PROCEDURE SP_InsertarInventarioSucursalGerente
    @IdSucursal INT,
    @IdProducto INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ErrorMensaje NVARCHAR(255);

    -- Iniciar la transacción
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Verificar si el producto ya existe en la sucursal
        IF EXISTS (
            SELECT 1 
            FROM INVENTARIO_SUCURSAL 
            WHERE IdSucursal = @IdSucursal AND IdProducto = @IdProducto
        )
        BEGIN
            SET @ErrorMensaje = 'El producto ya existe en la sucursal y no puede ser agregado nuevamente.';
            THROW 10001, @ErrorMensaje, 1;
        END

        -- Si todo está bien, insertar en la tabla
        INSERT INTO INVENTARIO_SUCURSAL (IdInventarioSucursal,IdSucursal, IdProducto, Cantidad, IdEstado)
        VALUES (NEWID(),@IdSucursal, @IdProducto, @Cantidad, 1);

		  -- Insertar o actualizar en la tabla INVENTARIO_GENERAL
        IF EXISTS (SELECT 1 FROM INVENTARIO_GENERAL WHERE IdProducto = @IdProducto)
        BEGIN
            -- Si el producto ya existe en el inventario general, actualizar la cantidad
            UPDATE INVENTARIO_GENERAL
            SET CantidadTotal = CantidadTotal + @Cantidad
            WHERE IdProducto = @IdProducto;
        END
        ELSE
        BEGIN
            -- Si el producto no existe en el inventario general, insertarlo
           INSERT INTO INVENTARIO_GENERAL (IdInventarioGeneral, IdProducto, CantidadTotal, IdEstado)
        VALUES (NEWID(), @IdProducto, @Cantidad, 1);
        END

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, revertir la transacción
        ROLLBACK TRANSACTION;
        -- Lanzar el error capturado
        THROW;
    END CATCH;
END;