using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Usuarios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Usuarios.ObtenerPorId;

namespace ThomasSalon.LN.Usuarios.ObtenerPorId
{
    public class ObtenerUsuariosPorIdLN : IObtenerUsuariosPorIdLN
    {
        IObtenerUsuariosPorIdAD _obtenerPorIdAD;

        public ObtenerUsuariosPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerUsuariosPorIdAD();
        }

        public UsuariosDto Obtener(string IdUsuario)
        {
            UsuariosTabla elUsuarioEnDb = _obtenerPorIdAD.Obtener(IdUsuario);
            UsuariosDto elUsuarioAMostrar = ConvertirAUsuariolAMostrar(elUsuarioEnDb);
            return elUsuarioAMostrar;
        }
        private UsuariosDto ConvertirAUsuariolAMostrar(UsuariosTabla elUsuarioEnDb)
        {
            return new UsuariosDto
            {
                Id = elUsuarioEnDb.Id,
                Email = elUsuarioEnDb.Email,
             
                Nombre = elUsuarioEnDb.Nombre,
                Genero = elUsuarioEnDb.Genero,
                Direccion = elUsuarioEnDb.Direccion,
                Edad = elUsuarioEnDb.Edad,
                Identificacion = elUsuarioEnDb.Identificacion,
                IdEstado = elUsuarioEnDb.IdEstado,
                IdSucursal = elUsuarioEnDb.IdSucursal,
                PhoneNumber = elUsuarioEnDb.PhoneNumber

            };
        }
    }
}
