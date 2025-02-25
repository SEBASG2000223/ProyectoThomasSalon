using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Usuarios.ObtenerPorId
{
    public class ObtenerUsuariosPorIdAD : IObtenerUsuariosPorIdAD
    {
        Contexto _elContexto;

        public ObtenerUsuariosPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public UsuariosTabla Obtener(string IdUsuario)
        {
            UsuariosTabla elUsuarioEnBD = _elContexto.UsuariosTabla.Where(elUsuario => elUsuario.Id == IdUsuario.ToString()).FirstOrDefault();
            return elUsuarioEnBD;
        }
    }
}
