CREATE PROCEDURE sp_ResumenVentas
AS
BEGIN
    SELECT 
        V.IdVenta,
        V.Fecha,
        V.MontoTotal,
        
        -- Cliente
        P.Nombre AS NombreCliente,
        P.Telefono,
        P.Identificacion,

        -- Colaborador
        PC.Nombre AS NombreColaborador,

        -- Método de pago
        MP.Nombre AS MetodoPago,

        -- Sucursal
        S.Nombre AS NombreSucursal,
        
        -- Ingreso del día
        I.MontoTotalDia,
        I.MontoTotalTransferencias,
        I.MontoTotalSinpe,
        I.MontoTotalTarjeta,
        I.MontoTotalEfectivo,
        I.MontoTotalGastos

    FROM VENTAS V
    INNER JOIN INGRESOS_DIARIOS I ON V.IdIngreso = I.IdIngreso
    INNER JOIN SUCURSALES S ON I.IdSucursal = S.IdSucursal
    INNER JOIN METODOS_PAGO MP ON V.IdMetodoPago = MP.IdMetodoPago
    INNER JOIN PERSONAS P ON V.IdPersona = P.IdPersona
    INNER JOIN COLABORADORES C ON V.IdColaborador = C.IdColaborador
    INNER JOIN PERSONAS PC ON C.IdPersona = PC.IdPersona
END