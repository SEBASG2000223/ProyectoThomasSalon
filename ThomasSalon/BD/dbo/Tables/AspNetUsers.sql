CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [IdPersona]            INT            NOT NULL,
    [IdEstado]             INT            NOT NULL,
    [IdSucursal]           INT            NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUsers_Personas] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Personas] ([IdPersona]),
    CONSTRAINT [FK_IdEstado_Usuarios] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[ESTADO_DISPONIBILIDAD] ([IdEstado]),
    CONSTRAINT [FK_IdSucursal_Usuarios] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[SUCURSALES] ([IdSucursal])
);

