using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Servicios.Editar
{
    public class EditarServiciosAD : IEditarServiciosAD
    {
        Contexto _elContexto;

        public EditarServiciosAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(ServiciosTabla elServicioParaEditar)
        {
            ServiciosTabla elServicioEnBD = _elContexto.ServiciosTabla.Where(s => s.IdServicio == elServicioParaEditar.IdServicio).FirstOrDefault();

            if (elServicioEnBD != null)
            {
                elServicioEnBD.Nombre = elServicioParaEditar.Nombre;
                elServicioEnBD.Descripcion = elServicioParaEditar.Descripcion;
                elServicioEnBD.Precio = elServicioParaEditar.Precio;
                elServicioEnBD.LinkImagen = elServicioParaEditar.LinkImagen;
                elServicioEnBD.Duracion = elServicioParaEditar.Duracion;
                elServicioEnBD.IdTipoServicios = elServicioParaEditar.IdTipoServicios;
                _elContexto.Entry(elServicioEnBD).State = EntityState.Modified;
                int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosGuardados;
            }

            return 0;
        }
    }
}
