using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.Editar
{
    public interface IEditarUsuariosAD
    {
        Task<int> Editar(UsuariosTabla elUsuarioParaEditar);

    }
}
