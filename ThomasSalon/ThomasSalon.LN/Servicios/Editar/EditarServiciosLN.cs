using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Editar;
using ThomasSalon.Abstracciones.Modelos.Servicios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Servicios.Editar;

namespace ThomasSalon.LN.Servicios.Editar
{
    public class EditarServiciosLN : IEditarServiciosLN
    {
        IEditarServiciosAD _editarServiciosAD;

        public EditarServiciosLN()
        {
            _editarServiciosAD = new EditarServiciosAD();
        }
        public async Task<int> Editar(ServiciosDto elServicioEnVista)
        {
            int cantidadDeDatosGuardados = await _editarServiciosAD.Editar(ConvertirAServiciosTabla(elServicioEnVista));
            return cantidadDeDatosGuardados;
        }
        private ServiciosTabla ConvertirAServiciosTabla(ServiciosDto elServicio)
        {
            return new ServiciosTabla
            {
                IdServicio = elServicio.IdServicio,
                Nombre = elServicio.Nombre,
                LinkImagen = elServicio.LinkImagen,
                Descripcion = elServicio.Descripcion,
                Precio = elServicio.Precio,
                Duracion = elServicio.Duracion,
                IdTipoServicios = elServicio.IdTipoServicios
            };
        }
    }
}