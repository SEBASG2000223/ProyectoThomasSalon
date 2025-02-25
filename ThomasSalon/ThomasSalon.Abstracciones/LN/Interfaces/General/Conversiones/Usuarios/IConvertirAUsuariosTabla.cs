using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Usuarios;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Usuarios
{
    public interface IConvertirAUsuariosTabla
    {
        UsuariosTabla ConvertirObjetoAUsuariosTabla(UsuariosDto elUsuario);

    }
}
