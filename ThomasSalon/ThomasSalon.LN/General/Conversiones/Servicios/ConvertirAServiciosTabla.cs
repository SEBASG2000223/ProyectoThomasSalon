using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Servicios;
using ThomasSalon.Abstracciones.Modelos.Servicios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.Servicios
{
    internal class ConvertirAServiciosTabla : IConvertirAServiciosTabla
    {
        public ServiciosTabla ConvertirObjetoAServiciosTabla(ServiciosDto elServicio)
        {
            return new ServiciosTabla
            {
                IdServicio = elServicio.IdServicio,
                Nombre = elServicio.Nombre,
                LinkImagen = elServicio.LinkImagen,
                Descripcion = elServicio.Descripcion,
                Precio = elServicio.Precio,
                Duracion = elServicio.Duracion,
                IdEstado = elServicio.IdEstado
            };
        }
    }
}