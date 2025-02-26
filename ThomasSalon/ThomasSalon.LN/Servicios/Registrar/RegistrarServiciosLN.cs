using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Registrar;
using ThomasSalon.Abstracciones.Modelos.Servicios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Servicios.Registrar;

namespace ThomasSalon.LN.Servicios.Registrar
{
    public class RegistrarServiciosLN : IRegistrarServiciosLN
    {
        IRegistrarServiciosAD _registrarServiciosAD;

        public RegistrarServiciosLN()
        {
            _registrarServiciosAD = new RegistrarServiciosAD();
        }
        public async Task<int> Registrar(ServiciosDto modelo)
        {
            modelo.IdEstado = 1;
            int cantidadDeDatosGuardados = await _registrarServiciosAD.Registrar(ConvertirAServiciosTabla(modelo));
            return cantidadDeDatosGuardados;
        }
        private ServiciosTabla ConvertirAServiciosTabla(ServiciosDto elServicio)
        {
            return new ServiciosTabla
            {
                Nombre = elServicio.Nombre,
                Descripcion = elServicio.Descripcion,
                Precio = elServicio.Precio,
                LinkImagen = elServicio.LinkImagen,
                Duracion = elServicio.Duracion,
                IdEstado = elServicio.IdEstado,
                IdTipoServicios = elServicio.IdTipoServicios
            
            };
        }
    }
}