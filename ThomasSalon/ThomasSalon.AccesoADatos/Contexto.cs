using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Personas;
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
            modelBuilder.Entity<TipoServiciosTabla>().ToTable("TIPOS_SERVICIOS");
            modelBuilder.Entity<ColaboradoresTabla>().ToTable("COLABORADORES");
            modelBuilder.Entity<PersonasTabla>().ToTable("Personas");

            modelBuilder.Entity<CitasTabla>().ToTable("CITAS");
            modelBuilder.Entity<EstadoCitaTabla>().ToTable("ESTADO_CITA");
            modelBuilder.Entity<PedidosTabla>().ToTable("PEDIDOS");

            modelBuilder.Entity<InventarioGeneralTabla>().ToTable("INVENTARIO_GENERAL");
            modelBuilder.Entity<InventarioSucursalTabla>().ToTable("INVENTARIO_SUCURSAL");
            modelBuilder.Entity<DetallePedidoTabla>().ToTable("DETALLE_PEDIDOS");

            modelBuilder.Entity<CarritoTemporalTabla>().ToTable("CarritoTemporal");

           
            modelBuilder.Entity<MetodosDePagoTabla>().ToTable("METODOS_PAGO");
            modelBuilder.Entity<ProvinciasTabla>().ToTable("PROVINCIAS");
            modelBuilder.Entity<TipoDeEntregaTabla>().ToTable("TIPOS_ENTREGA");

            modelBuilder.Entity<EstadoDePedidoTabla>().ToTable("ESTADO_PEDIDO");

            modelBuilder.Entity<AdjuntosPedidosTabla>().ToTable("ADJUNTOS_PEDIDOS");







        }
        public DbSet<AdjuntosPedidosTabla> AdjuntosPedidosTabla { get; set; }
        public DbSet<EstadoDePedidoTabla> EstadoDePedidoTabla { get; set; }

        public DbSet<PedidosTabla> PedidosTabla { get; set; }

        public DbSet<PersonasTabla> PersonasTabla { get; set; }

        public DbSet<SucursalesTabla> SucursalesTabla { get; set; }
        public DbSet<ProductosTabla> ProductosTabla { get; set; }
        public DbSet<ProveedoresTabla> ProveedoresTabla { get; set; }
        public DbSet<EstadoDisponibilidadTabla> EstadoDisponibilidadTabla { get; set; }

        public DbSet<DetallePedidoTabla> DetallePedidoTabla { get; set; }
        public DbSet<UsuariosTabla> UsuariosTabla { get; set; }
        public DbSet<RolesTabla> RolesTabla { get; set; }
        public DbSet<UserRolesTabla> UserRolesTabla { get; set; }

        public DbSet<CitasTabla> CitasTabla { get; set; }
        public DbSet<EstadoCitaTabla> EstadoCitaTabla { get; set; }
        public DbSet<TipoServiciosTabla> TipoServiciosTabla { get; set; }
        public DbSet<ServiciosTabla> ServiciosTabla { get; set; }
        public DbSet<ColaboradoresTabla> ColaboradoresTabla { get; set; }
        public DbSet<InventarioGeneralTabla> InventarioGeneralTabla { get; set; }
        public DbSet<InventarioSucursalTabla> InventarioSucursalTabla { get; set; }

        public DbSet<CarritoTemporalTabla> CarritoTemporalTabla { get; set; }

        public DbSet<TipoDeEntregaTabla> TipoDeEntregaTabla { get; set; }
        public DbSet<ProvinciasTabla> ProvinciasTabla { get; set; }
        public DbSet<MetodosDePagoTabla> MetodosDePagoTabla { get; set; }





    }
}
