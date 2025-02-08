using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.Modelos.Usuarios;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.Listar
{
    public interface IListarUsuariosLN
    {
        List<UsuariosDto> Listar();
        List<UsuariosDto> ListarAdministradores();
        List<UsuariosDto> ListarGerentes();
        List<UsuariosDto> ListarUsuarios();
    }
}
