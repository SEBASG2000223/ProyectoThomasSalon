CREATE PROCEDURE SP_ActualizarInventarioSucursalGerente
    @IdSucursal INT,
    @IdProducto INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ErrorMensaje NVARCHAR(255);

    -- Iniciar la transaccio?n
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Verificar si el producto existe en la sucursal
        IF NOT EXISTS (
            SELECT 1 
            FROM INVENTARIO_SUCURSAL 
            WHERE IdSucursal = @IdSucursal AND IdProducto = @IdProducto
        )
        BEGIN
            SET @ErrorMensaje = 'El producto no existe en la sucursal y no puede ser actualizado.';
            THROW 10001, @ErrorMensaje, 1;
        END

        -- Actualizar la cantidad en la tabla INVENTARIO_SUCURSAL
        UPDATE INVENTARIO_SUCURSAL
        SET Cantidad = @Cantidad
        WHERE IdSucursal = @IdSucursal AND IdProducto = @IdProducto;

        -- Actualizar la cantidad total en la tabla INVENTARIO_GENERAL
        UPDATE INVENTARIO_GENERAL
        SET CantidadTotal = (
            SELECT SUM(Cantidad)
            FROM INVENTARIO_SUCURSAL
            WHERE IdProducto = @IdProducto
        )
        WHERE IdProducto = @IdProducto;

        -- Confirmar la transaccio?n
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si ocurre un error, revertir la transaccio?n
        ROLLBACK TRANSACTION;
        -- Lanzar el error capturado
        THROW;
    END CATCH;
END;