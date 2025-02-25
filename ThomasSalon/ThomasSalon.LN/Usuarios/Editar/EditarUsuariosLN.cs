using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Usuarios;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.Editar;
using ThomasSalon.Abstracciones.Modelos.Usuarios;
using ThomasSalon.AccesoADatos.Usuarios.Editar;
using ThomasSalon.LN.General.Conversiones.Usuarios;

namespace ThomasSalon.LN.Usuarios.Editar
{
    public class EditarUsuariosLN : IEditarUsuariosLN
    {
        IEditarUsuariosAD _editarUsuariosAD;
        IConvertirAUsuariosTabla _convertirAUsuariosTabla;
        public EditarUsuariosLN()
        {
            _editarUsuariosAD = new EditarUsuariosAD();
            _convertirAUsuariosTabla = new ConvertirAUsuariosTabla();
        }

        public async Task<int> Editar(UsuariosDto elUsuarioEnVista)
        {
            int cantidadDeDatosGuardados = await _editarUsuariosAD.Editar(_convertirAUsuariosTabla.ConvertirObjetoAUsuariosTabla(elUsuarioEnVista));
            return cantidadDeDatosGuardados;
        }
    }
}
