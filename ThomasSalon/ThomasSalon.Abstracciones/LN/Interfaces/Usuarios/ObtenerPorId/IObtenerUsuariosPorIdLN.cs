using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.Modelos.Usuarios;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId
{
    public interface IObtenerUsuariosPorIdLN
    {
        UsuariosDto Obtener(string IdUsuario);
    }
}
