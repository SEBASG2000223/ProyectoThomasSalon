CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE   TRIGGER trg_ValidarSucursal
ON AspNetUserRoles
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

 
    UPDATE u
    SET u.IdSucursal = NULL
    FROM AspNetUsers u
    INNER JOIN inserted i ON u.Id = i.UserId
    WHERE i.RoleId IN (1, 3);

  
END;