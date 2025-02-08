using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos
{
    public class Contexto : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SucursalesTabla>().ToTable("SUCURSALES");
            modelBuilder.Entity<ProductosTabla>().ToTable("PRODUCTOS");
            modelBuilder.Entity<ProveedoresTabla>().ToTable("PROVEEDORES");
            modelBuilder.Entity<EstadoDisponibilidadTabla>().ToTable("ESTADO_DISPONIBILIDAD");

            modelBuilder.Entity<UsuariosTabla>().ToTable("AspNetUsers");
            modelBuilder.Entity<RolesTabla>().ToTable("AspNetRoles");
            modelBuilder.Entity<UserRolesTabla>().ToTable("AspNetUserRoles");


            modelBuilder.Entity<ServiciosTabla>().ToTable("SERVICIOS");
            modelBuilder.Entity<ColaboradoresTabla>().ToTable("COLABORADORES");

        }
        public DbSet<SucursalesTabla> SucursalesTabla { get; set; }
        public DbSet<ProductosTabla> ProductosTabla { get; set; }
        public DbSet<ProveedoresTabla> ProveedoresTabla { get; set; }
        public DbSet<EstadoDisponibilidadTabla> EstadoDisponibilidadTabla { get; set; }

        public DbSet<UsuariosTabla> UsuariosTabla { get; set; }
        public DbSet<RolesTabla> RolesTabla { get; set; }
        public DbSet<UserRolesTabla> UserRolesTabla { get; set; }


        public DbSet<ServiciosTabla> ServiciosTabla { get; set; }
        public DbSet<ColaboradoresTabla> ColaboradoresTabla { get; set; }


    }
}
