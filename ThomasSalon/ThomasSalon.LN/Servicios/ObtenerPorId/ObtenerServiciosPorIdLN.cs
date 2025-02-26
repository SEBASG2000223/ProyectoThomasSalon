using System;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Servicios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Servicios.ObtenerPorId;

namespace ThomasSalon.LN.Servicios.ObtenerPorId
{
    public class ObtenerServiciosPorIdLN : IObtenerServiciosPorIdLN
    {
        IObtenerServiciosPorIdAD _obtenerPorIdAD;

        public ObtenerServiciosPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerServiciosPorIdAD();
        }

        public ServiciosDto Obtener(int IdServicio)
        {
            ServiciosTabla elServicioEnDb = _obtenerPorIdAD.Obtener(IdServicio);
            ServiciosDto elServicioAMostrar = ConvertirAServicioAMostrar(elServicioEnDb);
            return elServicioAMostrar;
        }

        private ServiciosDto ConvertirAServicioAMostrar(ServiciosTabla elServicioEnDb)
        {
            return new ServiciosDto
            {
                IdServicio = elServicioEnDb.IdServicio,
                Nombre = elServicioEnDb.Nombre,
                LinkImagen = elServicioEnDb.LinkImagen,
                Descripcion = elServicioEnDb.Descripcion,
                Precio = elServicioEnDb.Precio,
                Duracion = elServicioEnDb.Duracion,
                IdEstado = elServicioEnDb.IdEstado,
                IdTipoServicios = elServicioEnDb.IdTipoServicios
            };
        }
    }
}