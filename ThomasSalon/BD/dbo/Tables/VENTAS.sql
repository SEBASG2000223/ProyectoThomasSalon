CREATE TABLE [dbo].[VENTAS] (
    [IdVenta]       UNIQUEIDENTIFIER NOT NULL,
    [IdIngreso]     UNIQUEIDENTIFIER NOT NULL,
    [IdColaborador] INT              NOT NULL,
    [IdMetodoPago]  UNIQUEIDENTIFIER NOT NULL,
    [IdPersona]     INT              NOT NULL,
    [MontoTotal]    DECIMAL (10, 2)  NOT NULL,
    [Fecha]         DATETIME         DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdVenta] ASC),
    CONSTRAINT [FK_IdPersonaVentas] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Personas] ([IdPersona]),
    CONSTRAINT [FK_Ventas_Colaborador] FOREIGN KEY ([IdColaborador]) REFERENCES [dbo].[COLABORADORES] ([IdColaborador]),
    CONSTRAINT [FK_Ventas_Ingreso] FOREIGN KEY ([IdIngreso]) REFERENCES [dbo].[INGRESOS_DIARIOS] ([IdIngreso]),
    CONSTRAINT [FK_Ventas_MetodoPago] FOREIGN KEY ([IdMetodoPago]) REFERENCES [dbo].[METODOS_PAGO] ([IdMetodoPago])
);


GO
CREATE TRIGGER TR_InsertRegistroPago
ON VENTAS
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    
    INSERT INTO REGISTRO_TIPO_PAGOS (IdTipoPago, IdVenta, Monto, NombreCliente, Fecha, IdMetodoPago)
    SELECT 
        NEWID(),                          
        i.IdVenta,                        
        i.MontoTotal,                    
        p.Nombre,                        
        CONVERT(DATE, i.Fecha),          
        i.IdMetodoPago                    
    FROM 
        INSERTED i                       
    INNER JOIN 
        Personas p ON i.IdPersona = p.IdPersona;  
END;