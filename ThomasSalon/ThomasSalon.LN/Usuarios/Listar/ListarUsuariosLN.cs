using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.Listar;
using ThomasSalon.Abstracciones.Modelos.Usuarios;
using ThomasSalon.AccesoADatos.Usuarios.Listar;

namespace ThomasSalon.LN.Usuarios.Listar
{
    public class ListarUsuariosLN : IListarUsuariosLN
    {
        IListarUsuariosAD _listarUsuariosAD;


        public ListarUsuariosLN()
        {
            _listarUsuariosAD = new ListarUsuariosAD();
        }

        public List<UsuariosDto> Listar()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuariosAD.Listar();
            return laListaDeUsuarios;
        }

        public List<UsuariosDto> ListarAdministradores()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuariosAD.ListarAdministradores();
            return laListaDeUsuarios;
        }

        public List<UsuariosDto> ListarGerentes()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuariosAD.ListarGerentes();
            return laListaDeUsuarios;
        }

        public List<UsuariosDto> ListarUsuarios()
        {
            List<UsuariosDto> laListaDeUsuarios = _listarUsuariosAD.ListarUsuarios();
            return laListaDeUsuarios;
        }
    }
}
