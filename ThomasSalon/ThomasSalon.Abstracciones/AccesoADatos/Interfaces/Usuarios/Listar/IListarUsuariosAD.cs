using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.Modelos.Usuarios;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.Listar
{
    public interface IListarUsuariosAD
    {
        List<UsuariosDto> Listar();
        List<UsuariosDto> ListarGerentes();
        List<UsuariosDto> ListarAdministradores();
        List<UsuariosDto> ListarUsuarios();
    }
}
